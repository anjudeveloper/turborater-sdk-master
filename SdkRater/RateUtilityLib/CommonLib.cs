using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRater.ApiClients.Imp;
using TurboRater.Insurance.AU;
using TurboRater.Insurance;
using TurboRater.InterfaceSpecifications;
using TurboRater.ApiClients.Imp.Itc.EFContexts;
using System.Net;
using TurboRater;
using TurboRater.ApiClients.RateEngineApi;
using TurboRater.Insurance.DataTransformation;
using Microsoft.OData.Core;
using Microsoft.OData.Edm;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web;
using System.Windows.Forms;
using System.Threading;
using SdkRater.RateUtilityLib;
using OfficeOpenXml;

namespace SdkRater.RateUtilityLib
{
  /// <summary>
  /// Contains general purpose methods called by the various buttons from MainForm, aka a Common Library
  /// </summary>
  public class CommonLib
  {
    /// <summary>
    /// The generic imp client
    /// </summary>
    public IImpClient ApiImpClient;

    /// <summary>
    /// A generic rate engine api client.
    /// </summary>
    public IRateEngineApiClient rateEngineApiClient;

    /// <summary>
    /// The rating request created using a single policy along w/ a single carrier
    /// </summary>
    private ITCRateEngineRequest ratingRequest;

    /// <summary>
    /// Multiple ratingRequest objects 
    /// </summary>
    private List<ITCRateEngineRequest> ratingRequests;

    /// <summary>
    /// All companies returned from the ITC rating service whether active or not
    /// </summary>
    private List<CompanyInfo> Companies;

    /// <summary>
    /// RatingResponses returned per quote requested.  the main list is per quote, the inner list is per payment option returned
    /// </summary>
    private List<List<ITCRateEngineResponse>> RatingCompanyResponses;

    /// <summary>
    /// List of realtime carriers selected by the user
    /// </summary>
    public IOrderedEnumerable<CompanyInfo> SelectedRealtimeCarriers;

    /// <summary>
    /// something to display to the users to let them know rating is occurring.
    /// </summary>
    private StatusForm progressForm;

    /// <summary>
    /// delegate to show progress of selected quotes being rated
    /// </summary>
    /// <param name="numQuotes">total # of quotes being rated</param>
    /// <param name="currentQuote">current quote being rated</param>
    public delegate void QuoteProgress(int numQuotes, int currentQuote);

    /// <summary>
    /// event to hook to the delegate QuoteProgress
    /// </summary>
    public event QuoteProgress OnQuoteProgress;

    /// <summary>
    /// Search quotes in the customer's quotes.
    /// </summary>
    /// <param name="QuotesGridView">list of quotes used in MainForm</param>
    public bool SearchQuotes(DataGridView QuotesGridView)
    {
      var oDataImpClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(Constants.ImpConstantsUrl + "api"));
      try
      {
        QuotesGridView.DataSource = null;
        if (String.IsNullOrWhiteSpace(Constants.SearchLastName) && String.IsNullOrWhiteSpace(Constants.SearchFirstName) && String.IsNullOrWhiteSpace(Constants.SearchPhoneNumber))
        {
          MessageBox.Show("You must specify a search value");
          return false;
        }

        string token = null;
        if (Constants.BearerAuthorization && !string.IsNullOrWhiteSpace(Constants.BearerToken))
          token = Constants.BearerToken;

        oDataImpClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, token, ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty));
        };

        var clients = oDataImpClient.Clients
          .Expand("AutoPolicies")
          .Where(client => client.State == Constants.SearchProductState)
          .OrderBy(client => client.LastName);

        if (!String.IsNullOrWhiteSpace(Constants.SearchLastName))
          clients = clients.Where(client => client.LastName.StartsWith(Constants.SearchLastName))
            .OrderBy(client => client.LastName);

        if (!String.IsNullOrWhiteSpace(Constants.SearchFirstName))
          clients = clients.Where(client => client.FirstName.StartsWith(Constants.SearchFirstName))
            .OrderBy(client => client.FirstName);

        if (!String.IsNullOrWhiteSpace(Constants.SearchPhoneNumber))
          clients = clients.Where(client => client.Phone.StartsWith(Constants.SearchPhoneNumber))
            .OrderBy(client => client.Phone);

        var clientsList = clients.ToList();
        var autoQuotes = from client in clientsList
                         from policy in client.AutoPolicies
                         where !policy.Deleted
                         orderby policy.LastQuotedDate descending
                         select new ClientsList()
                         {
                           FirstName = client.FirstName,
                           LastName = client.LastName,
                           EmailAddress = client.EmailAddress,
                           Phone = client.Phone,
                           PolicyId = policy.RecordId,
                           DateQuoted = (DateTimeOffset)policy.DateQuoted,
                           EffectiveDate = (DateTimeOffset)policy.EffectiveDate,
                           LastQuotedDate = (DateTimeOffset)(policy.LastQuotedDate != null ? policy.LastQuotedDate : policy.DateQuoted),
                           QuoteNumber = policy.QuoteNumber,
                           Lob = InsuranceLine.PersonalAuto,
                         };
        var quotes = (from quote in autoQuotes select quote)
                      .OrderByDescending(quote => quote.LastQuotedDate)
                      .OrderByDescending(quote => quote.PolicyId);

        QuotesGridView.AutoGenerateColumns = false;
        QuotesGridView.ColumnHeadersVisible = true;
        QuotesGridView.DataSource = quotes.ToList();
        QuotesGridView.Focus();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.GetBaseException() != null ? ex.GetBaseException().ToString() : ex.Message);
        return false;
      }
      return true;
    }

    /// <summary>
    /// Acquire a bearer token if need be
    /// </summary>
    public bool AcquireToken()
    {
      var agency = ApiImpClient.GetAgency(Constants.BearerAuthorization ? Constants.BearerToken : null, ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty));
      try
      {
        if (Constants.BearerAuthorization && !String.IsNullOrWhiteSpace(Constants.ImpIntegrationKey) && ITCConvert.ToGuid(Constants.ImpIntegrationKey, Guid.Empty) != Guid.Empty)
        {
          try
          {
            Constants.BearerToken = ApiImpClient.GetBearerToken(ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty), Constants.ImpIntegrationKey);
            if (String.IsNullOrWhiteSpace(Constants.BearerToken))
              Constants.BearerToken = ApiImpClient.GetBearerToken(ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty), Constants.ImpIntegrationKey);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.GetBaseException().ToString());
            return false;
          }
        }
      }
      catch (WebException webEx)
      {
        MessageBox.Show(webEx.GetBaseException().ToString());
        return false;
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.GetBaseException().ToString());
        return false;
      }
      finally
      {
        if (String.IsNullOrWhiteSpace(Constants.BearerToken))
          Constants.BearerToken = String.Empty;
      }
      return true;
    }

    /// <summary>
    /// Validate the users credentials based on the test or live site.
    /// </summary>
    /// <returns></returns>
    public bool ValidateCredentials()
    {
      if (Constants.LiveSite)
      {
        if (string.IsNullOrWhiteSpace(Constants.LiveImpAccountId))
        {
          MessageBox.Show("Live IMP Account ID is a required field.");
          return false;
        }
        var agency = ApiImpClient.GetAgency(Constants.BearerAuthorization ? Constants.BearerToken : null, ITCConvert.ToGuid(Constants.LiveImpAccountId, Guid.Empty));
        if (agency == null)
        {
          MessageBox.Show("Live IMP Account ID is a required field.");
          return false;
        }
        if (string.IsNullOrWhiteSpace(Constants.LiveItcRatingServiceAccountId))
        {
          MessageBox.Show("Live ITC Rating Service Account ID is a required field.");
          return false;
        }
        if (string.IsNullOrWhiteSpace(Constants.LiveAgencyAccountName))
        {
          MessageBox.Show("Live Agency Account Name is a required field.");
          return false;
        }
        if (string.IsNullOrWhiteSpace(Constants.LiveAgencyId))
        {
          MessageBox.Show("Live Agency ID is a required field.");
          return false;
        }
        if (Constants.BearerAuthorization)
        {
          if (string.IsNullOrWhiteSpace(Constants.LiveImpIntegrationKey))
          {
            MessageBox.Show("Live Integration Key is a required field.");
            return false;
          }
        }
      }
      else
      {
        if (string.IsNullOrWhiteSpace(Constants.TestImpAccountId))
        {
          MessageBox.Show("Test IMP Account ID is a required field.");
          return false;
        }
        var agency = ApiImpClient.GetAgency(Constants.BearerAuthorization ? Constants.BearerToken : null, ITCConvert.ToGuid(Constants.TestImpAccountId, Guid.Empty));
        if (agency == null)
        {
          MessageBox.Show("Test IMP Account ID is a required field.");
          return false;
        }
        if (string.IsNullOrWhiteSpace(Constants.TestItcRatingServiceAccountId))
        {
          MessageBox.Show("Test ITC Rating Service Account ID is a required field.");
          return false;
        }
        if (string.IsNullOrWhiteSpace(Constants.TestAgencyAccountName))
        {
          MessageBox.Show("Test Agency Account Name is a required field.");
          return false;
        }
        if (string.IsNullOrWhiteSpace(Constants.TestAgencyId))
        {
          MessageBox.Show("Test Agency ID is a required field.");
          return false;
        }
        if (Constants.BearerAuthorization)
        {
          if (string.IsNullOrWhiteSpace(Constants.TestImpIntegrationKey))
          {
            MessageBox.Show("Test Integration Key is a required field.");
            return false;
          }
        }
      }
      return true;
    }

    /// <summary>
    /// create the rating request for each quote selected by the user.  manufactured carriers are automatically included, we're giving the user the option of including any selected realtime carriers they have active.
    /// </summary>
    /// <param name="QuotesGridView">list of quotes used in MainForm selected by the user</param>
    /// <param name="RealTimeCompaniesGridView">active realtime carriers returned from the users account</param>
    public void BuildRatingRequest(DataGridView QuotesGridView, DataGridView RealTimeCompaniesGridView)
    {
      ratingRequests = new List<ITCRateEngineRequest>();
      if (ValidateCredentials())
      {
        var APIAgency = ApiImpClient.GetAgency(Constants.BearerAuthorization ? Constants.BearerToken : null, ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty));
        try
        {
          foreach (DataGridViewRow dataGridRow in QuotesGridView.Rows)
          {
            if (ITCConvert.ToBoolean(dataGridRow.Cells["Selected"].Value, false))
            {
              List<string> autoLineOfBusiness = new List<string>() { "PA", "PersonalAuto" };
              QuoteLoadWrapper loadResult = null;
              if (Constants.BearerAuthorization && !String.IsNullOrWhiteSpace(Constants.BearerToken))
                loadResult = ApiImpClient.LoadPolicy(Constants.BearerToken,
                autoLineOfBusiness.Exists(lob => lob == dataGridRow.Cells["Lob"].Value.ToString()) ? InsuranceLine.PersonalAuto : InsuranceLine.Homeowners,
                ITCConvert.ToInt32(dataGridRow.Cells["PolicyId"].Value, -1),
                autoLineOfBusiness.Exists(lob => lob == dataGridRow.Cells["Lob"].Value.ToString()) ? BridgeContentType.TT2 : BridgeContentType.Custom);
              else
                loadResult = ApiImpClient.LoadPolicy(ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty),
                autoLineOfBusiness.Exists(lob => lob == dataGridRow.Cells["Lob"].Value.ToString()) ? InsuranceLine.PersonalAuto : InsuranceLine.Homeowners,
                ITCConvert.ToInt32(dataGridRow.Cells["PolicyId"].Value, -1),
                autoLineOfBusiness.Exists(lob => lob == dataGridRow.Cells["Lob"].Value.ToString()) ? BridgeContentType.TT2 : BridgeContentType.Custom);
              InsPolicy policy = loadResult.Policy; // for readability
              bool successfulPolicySave = true;

              ratingRequest = new ITCRateEngineRequest();
              ratingRequest.AccessID = Constants.AgencyAccountName; // "API SDK Utility"; // ImpConstants.ValidAccessLevelGUIDs[(int)AccessLevels.StandardAccess];
              ratingRequest.AccountName = Constants.AgencyAccountName;
              ratingRequest.AccountNumber = Constants.ItcRatingServiceAccountId;
              ratingRequest.BumpLimits = RateEngineBumpingEnum.bBumpUp;
              ratingRequest.TransactionID = Guid.NewGuid().ToString();
              ratingRequest.CustomerID = Guid.NewGuid().ToString();
              ratingRequest.Test = rateEngineApiClient.BaseUrl == RateEngineApiConstants.BaseUrlTest;

              ratingRequest.LineOfInsurance = autoLineOfBusiness.Exists(lob => lob == dataGridRow.Cells["Lob"].Value.ToString()) ? InsuranceLine.PersonalAuto : InsuranceLine.Homeowners;
              ratingRequest.RateState = TurboRater.ITCConstants.StateAbbreviations[(int)policy.Insured.State];
              ratingRequest.RealTimeAccountNumber = APIAgency.AccountNumber;

              ratingRequest.PolicyData = TransformationHelper.SerializePolicy(policy);
              ratingRequest.EstimateTerm = true;
              ratingRequest.InsuredFirstName = policy.Insured.FirstName;
              ratingRequest.InsuredMiddleName = policy.Insured.MiddleName;
              ratingRequest.InsuredLastName = policy.Insured.LastName;
              ratingRequest.EstimateTerm = true;
              ratingRequest.UseRequestCredentials = false;

              if (policy.MarketBasketItemID <= 0 && ratingRequest.LineOfInsurance == InsuranceLine.PersonalAuto && policy.LineOfInsurance == InsuranceLine.PersonalAuto)  // if not set we need to set it, otherwise we'll re-use what is already in there.
              {
                RateEngineAPIMarketBasketRequest rateEngineAPIMarketBasketRequest = new RateEngineAPIMarketBasketRequest();
                rateEngineAPIMarketBasketRequest.CustomerID = ratingRequest.CustomerID;
                rateEngineAPIMarketBasketRequest.PolicyData = ratingRequest.PolicyData;
                rateEngineAPIMarketBasketRequest.Test = ratingRequest.Test;
                rateEngineAPIMarketBasketRequest.AccountNumber = Constants.ItcRatingServiceAccountId;

                RateEngineAPIMarketBasketResponse rateEngineAPIMarketBasketResponse = rateEngineApiClient.PreFetchMarketBasket(rateEngineAPIMarketBasketRequest);
                policy.MarketBasketItemID = rateEngineAPIMarketBasketResponse.MarketBasketItemID;
                var policyResult = ApiImpClient.SavePolicy(new Guid(Constants.ImpAccountId), policy, false, true);
              }

              if (successfulPolicySave)
              {
                // temporary changes to get a rate if the quote hasn't been quoted in some time.  these won't be saved to the policy
                if (ratingRequest.LineOfInsurance == InsuranceLine.PersonalAuto || ratingRequest.LineOfInsurance == InsuranceLine.Motorcycle)
                {
                  if (policy.EffectiveDate < DateTime.Now)
                    policy.EffectiveDate = DateTime.Now;
                  if (((AUPolicy)policy).Drivers[0].PriorInsurance)
                    policy.PriorExpDate = policy.EffectiveDate.AddDays(-((AUPolicy)policy).Drivers[0].PriorDaysLapse);
                  if (!String.IsNullOrWhiteSpace(policy.InsuranceScoreData))
                    policy.InsuranceScoreData = String.Empty;

                  AUPolicy autoPolicy = (AUPolicy)policy;
                  if (autoPolicy.NonOwner || autoPolicy.FRBond || autoPolicy.Broadform)
                    foreach (AUCar car in autoPolicy.Cars)
                    {
                      if (String.IsNullOrEmpty(car.Maker))
                        car.Maker = "null";
                      if (String.IsNullOrEmpty(car.Model))
                        car.Model = "null";
                      if (car.Year < 1971)
                        car.Year = 1971;
                    }
                }
                if (ratingRequest.LineOfInsurance == InsuranceLine.Homeowners || ratingRequest.LineOfInsurance == InsuranceLine.DwellingFire)
                {
                  if (policy.EffectiveDate < DateTime.Now)
                    policy.EffectiveDate = DateTime.Now;
                }
                ratingRequest.PolicyData = TransformationHelper.SerializePolicy(policy);

                var companyInfoRequest = new CompanyInfoRequest() { AccessID = "API SDK Utility", AccountName = "API SDK Utility", AccountNumber = Constants.ItcRatingServiceAccountId, AgencyId = ITCConvert.ToGuid(APIAgency.AgencyID, Guid.Empty), IncludeCompanyQuestions = false, State = ratingRequest.RateState, Type = "All" };
                var companyInfoResponse = rateEngineApiClient.GetCompanyInfo(companyInfoRequest);

                Companies = companyInfoResponse.CompanyInfoList.Where(company => company.Active).OrderBy(company => company.CompanyName).ToList();
                List<int> realtimeDOSCompanyIDs = new List<int>() { InsConstants.RealTimeRateIndicator, InsConstants.HybridRealTimeRateIndicator, InsConstants.MulticoRealTimeIndicator };
                var manufacturedCompanies = Companies.Where(company => !realtimeDOSCompanyIDs.Exists(realtimeDOSCompanyID => realtimeDOSCompanyID == company.DOSCompanyID)).OrderBy(company => company.CompanyName);

                // build a list of selected realtime carriers to add to the manufactured carriers
                List<CompanyInfo> realtimeCarriers = new List<CompanyInfo>();
                foreach (DataGridViewRow companyDataGridRow in RealTimeCompaniesGridView.Rows)
                  if (ITCConvert.ToBoolean(companyDataGridRow.Cells["SelectedCarrier"].Value, false))
                  {
                    realtimeCarriers.Add(new CompanyInfo()
                    {
                      RecordID = ITCConvert.ToInt64(companyDataGridRow.Cells["RecordID"].Value, 0),
                      CompanyID = ITCConvert.ToInt64(companyDataGridRow.Cells["CompanyID"].Value, 0),
                      ProductID = ITCConvert.ToInt32(companyDataGridRow.Cells["ProductID"].Value, 0),
                      CompanyName = companyDataGridRow.Cells["CompanyName"].Value.ToString(),
                      ProgramID = ITCConvert.ToInt32(companyDataGridRow.Cells["ProgramID"].Value, 0),
                      ProgramName = companyDataGridRow.Cells["ProgramName"].Value.ToString(),
                      ModuleName = companyDataGridRow.Cells["ModuleName"].Value.ToString(),
                      RateEffectiveDate = ITCConvert.ToDateTime(companyDataGridRow.Cells["RateEffectiveDate"].Value, DateTime.Now),
                      RateType = companyDataGridRow.Cells["RateType"].Value.ToString(),
                      LineOfInsurance = companyDataGridRow.Cells["LineOfInsurance"].Value.ToString(),
                      CreditRequired = ITCConvert.ToBoolean(companyDataGridRow.Cells["CreditRequired"].Value, false),
                      DOSCompanyID = ITCConvert.ToInt32(companyDataGridRow.Cells["DOSCompanyID"].Value, 0),
                      State = companyDataGridRow.Cells["State"].Value.ToString(),
                      Active = ITCConvert.ToBoolean(companyDataGridRow.Cells["Active"].Value, false),
                    });
                  }
                var carriers = manufacturedCompanies.Union(realtimeCarriers);

                foreach (CompanyInfo carrierInfo in carriers)
                {
                  ratingRequest.CarrierInformation.Add(new CarrierInfo()
                  {
                    AgencyID = ITCConvert.ToGuid(APIAgency.AgencyID, Guid.Empty), // new Guid(Constants.AgencyId),
                    CarrierID = String.Empty,
                    CarrierPassword = String.Empty,
                    CompanyID = carrierInfo.CompanyID,
                    DOSCompanyID = carrierInfo.DOSCompanyID,
                    OrderCreditScore = carrierInfo.CreditRequired,
                    ProgramID = carrierInfo.ProgramID,
                    ProducerCode = String.Empty,
                    SubProducerCode = String.Empty,
                  });
                }
                ratingRequests.Add(ratingRequest);
              }
              else
                MessageBox.Show("Market Basket ID not returned/saved for quote");

            }
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.GetBaseException().Message);
        }
      }
    }

    /// <summary>
    /// This generates a generic response if an exception has been thrown.
    /// </summary>
    /// <param name="request">The request created by the user to populate the fatal response</param>
    /// <param name="ex">The exception thrown</param>
    /// <returns>A single response with generic info pulled from request and the excetion information from ex</returns>
    private ITCRateEngineResponse GenerateFatalResponse(ITCRateEngineRequest request, Exception ex, long companyId, int programId)
    {
      ITCRateEngineResponse fatalResponse = new ITCRateEngineResponse();
      fatalResponse.ATPAFee = 0;

      string companyName = String.Empty;
      if (Companies.ToList().Exists(carrier => carrier.CompanyID == companyId && carrier.ProgramID == programId))
        if (Companies.ToList().FindIndex(carrier => carrier.CompanyID == companyId && carrier.ProgramID == programId) != -1)
        {
          int companyIndex = Companies.ToList().FindIndex(carrier => carrier.CompanyID == companyId && carrier.ProgramID == programId);
          companyName = Companies.ToList()[companyIndex].CompanyName;
        }
      fatalResponse.CompanyName = companyName;
      fatalResponse.Tier = String.Empty;
      fatalResponse.Term = request.GetPolicy().Term;
      fatalResponse.EffectiveDate = request.GetPolicy().EffectiveDate;
      fatalResponse.PolicyFee = 0;
      fatalResponse.SR22Fee = 0;
      fatalResponse.TotalPremium = 0;
      fatalResponse.PayPlanDownPayment = 0;
      fatalResponse.PayPlanPaymentAmount = 0;
      fatalResponse.Cars = new List<ResponseCar>();
      for (int carIndex = 0; carIndex < ((AUPolicy)request.GetPolicy()).NumOfCars; carIndex++)
      {
        AUCar requestCar = ((AUPolicy)request.GetPolicy()).Cars[carIndex];
        ResponseCar errorCar = new ResponseCar();
        errorCar.CarNumber = carIndex + 1;
        errorCar.Coverages = new List<Coverage>();
        errorCar.Make = requestCar.Maker;
        errorCar.Model = requestCar.Model;
        errorCar.VIN = requestCar.VIN;
        errorCar.Year = requestCar.Year;
        fatalResponse.Cars.Add(errorCar);
      }
      fatalResponse.FatalErrors = new List<string>();
      fatalResponse.FatalErrors.Add(ex.Message.ToString());
      fatalResponse.Errors = new List<ResponseMessage>();
      fatalResponse.Errors.Add(new ResponseMessage() { Text = ex.Message, Scope = ItemScope.Policy });
      return fatalResponse;
    }

    public void DoShowProgress(string formText)
    {
      progressForm = new StatusForm();
      progressForm.Show();
      progressForm.Minimum = 1;
      progressForm.Step = 1;
      progressForm.ProgressValue = 1;
      progressForm.StartTime = DateTime.Now;
      progressForm.Text = formText;
    }

    public void CommonLib_RateQuoteProgress(int numQuotes, int currentQuote)
    {
      if ((progressForm.Maximum != numQuotes) && (numQuotes != -1))
        progressForm.Maximum = numQuotes;
      if (numQuotes != -1)
      {
        progressForm.PerformStep(String.Format("Processing quote {0} of {1}", currentQuote, numQuotes), "Time Elapsed: " + (DateTime.Now - progressForm.StartTime).ToString());
        progressForm.FormText = String.Format("{0}%-Progress(File Import)", (int)(((double)currentQuote / (double)numQuotes) * 100));
      }
      else
        progressForm.ProgressText = "Estimating # of quotes in request";
      Application.DoEvents();
    }

    /// <summary>
    /// Create rating threads per quote in ratingRequests with the expectation of populating RatingCompanyResponses with the results
    /// </summary>
    /// <param name="QuotesGridView">list of quotes used in MainForm selected by the user</param>
    /// <param name="RealTimeCompaniesGridView">active realtime carriers returned from the users account</param>
    public void RateQuotes(DataGridView QuotesGridView, DataGridView RealTimeCompaniesGridView)
    {
      int currentRequest = 0;
      RatingCompanyResponses = new List<List<ITCRateEngineResponse>>();
      if (ratingRequests.Count > 0)
      {
        DoShowProgress("Rating Selected Quotes");
        progressForm.Maximum = ratingRequests.Count;
        OnQuoteProgress(-1, -1);
        foreach (var request in ratingRequests)
        {
          currentRequest++;
          try
          {
            rateEngineApiClient.RatePolicy(request);
            var stopwatch = new System.Diagnostics.Stopwatch();
            List<ITCRateEngineResponse> allPayPlanResponses = new List<ITCRateEngineResponse>();
            stopwatch.Start();
            do
            {
              Thread.Sleep(1000);
              try
              {
                var responses = rateEngineApiClient.GetRateResults(request.TransactionID, false);
                if (responses != null && responses.Count > 0)
                {
                  allPayPlanResponses.AddRange(responses);
                  if (responses.First().AllRatingComplete)
                    break;
                }
              }
              catch (HttpException ex)
              {
                if (ex.GetHttpCode() != 404)
                {
                  ITCRateEngineResponse fatalResponse = GenerateFatalResponse(request, ex, -1, -1);
                  allPayPlanResponses.Add(fatalResponse);
                  break;
                }
              }
            } while (stopwatch.Elapsed < Constants.RateTimeout);
            stopwatch.Stop();
            RatingCompanyResponses.Add(allPayPlanResponses);
            if (OnQuoteProgress != null)
              OnQuoteProgress(ratingRequests.Count, currentRequest);
          }
          catch (HttpException ex)
          {
            //if it's a validation error, handle appropriately.
            if (ex.GetHttpCode() == (int)HttpStatusCode.BadRequest)
            {
              var validationMessages = ex.Message;
              if (!String.IsNullOrWhiteSpace(validationMessages))
              {
                List<ITCRateEngineResponse> fatalResponses = new List<ITCRateEngineResponse>();
                // per request?
                foreach (CarrierInfo carrierInfo in request.CarrierInformation)
                {
                  //do something with validation message(s)
                  ITCRateEngineResponse fatalResponse = GenerateFatalResponse(request, ex, carrierInfo.CompanyID, carrierInfo.ProgramID);
                  fatalResponse.CustomerID = request.CustomerID;
                  fatalResponses.Add(fatalResponse);
                }
                RatingCompanyResponses.Add(fatalResponses);
              }
            }
            else
            //throw; //if it wasn't a validation error, rethrow the exception
            {
              foreach (CarrierInfo carrierInfo in request.CarrierInformation)
              {
                ITCRateEngineResponse fatalResponse = GenerateFatalResponse(request, ex, carrierInfo.CompanyID, carrierInfo.ProgramID);
                fatalResponse.CustomerID = request.CustomerID;
                List<ITCRateEngineResponse> fatalResponses = new List<ITCRateEngineResponse>();
                fatalResponses.Add(fatalResponse);
                RatingCompanyResponses.Add(fatalResponses);
              }
            }
          }
        }
        // we have responses for all quoting scenarios, now what?  report them!
        if (progressForm != null)
        {
          progressForm.Hide();
          progressForm = null;
        }
      }
    }

    /// <summary>
    /// Generate an Excel or CSV export depending on whether the user has Excel installed
    /// </summary>
    public void ExportResults()
    {
      var excelApplication = new Microsoft.Office.Interop.Excel.Application();
      if (excelApplication == null)  // Excel isn't installed on the machine, time to give them a CSV export
      {
        CsvLibrary.Companies = Companies;
        CsvLibrary.ratingRequests = ratingRequests;
        CsvLibrary.RatingCompanyResponses = RatingCompanyResponses;
        CsvLibrary.GenerateCSVResponse();
      }
      else
      {
        ExcelLibrary.Companies = Companies;
        ExcelLibrary.ratingRequests = ratingRequests;
        ExcelLibrary.RatingCompanyResponses = RatingCompanyResponses;
        ExcelLibrary.GenerateExcelResponse();
      }
    }

    /// <summary>
    /// Load the realtime carriers into RealTimeCompaniesGridView based on the carrier info returned from the users's account
    /// </summary>
    /// <param name="RealTimeCompaniesGridView">active realtime carriers returned from the users account</param>
    public void AcquireCarriers(DataGridView RealTimeCompaniesGridView)
    {
      var APIAgency = ApiImpClient.GetAgency(Constants.BearerAuthorization ? Constants.BearerToken : null, ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty));
      var companyInfoRequest = new CompanyInfoRequest() { AccessID = "API SDK Utility", AccountName = "API SDK Utility", AccountNumber = Constants.ItcRatingServiceAccountId, AgencyId = ITCConvert.ToGuid(APIAgency.AgencyID, Guid.Empty), IncludeCompanyQuestions = true, State = Constants.SearchProductState, Type = "All" };
      var companyInfoResponse = rateEngineApiClient.GetCompanyInfo(companyInfoRequest);
      Companies = companyInfoResponse.CompanyInfoList.Where(company => company.Active).OrderBy(company => company.CompanyName).ToList();
      List<int> realtimeDOSCompanyIDs = new List<int>() { InsConstants.RealTimeRateIndicator, InsConstants.HybridRealTimeRateIndicator, InsConstants.MulticoRealTimeIndicator };
      var realtimeCompanies = Companies.Where(company => realtimeDOSCompanyIDs.Exists(realtimeDOSCompanyID => realtimeDOSCompanyID == company.DOSCompanyID)).OrderBy(company => company.ProgramName);
      realtimeCompanies = realtimeCompanies.OrderBy(company => company.CompanyName);

      SelectedRealtimeCarriers = realtimeCompanies;
    }

  }
}