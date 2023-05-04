using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TurboRater.ApiClients.RateEngineApi;
using TurboRater.Insurance;
using TurboRater.Insurance.AU;
using TurboRater.Insurance.DataTransformation;
using TurboRater.Insurance.HO;

namespace TurboRater.Samples
{
  [TestClass]
  public class RatingApiSamples
  {
    IRateEngineApiClient rateEngineApiClient;

    /// <summary>
    /// Creates a sample policy for use in the rating API. Note that this is an extremely
    /// sparsely populated policy. Normally a client would fill in much more info than
    /// what is shown here. Failure to fully populate a policy before rating will often
    /// result in inaccurate rates.
    /// </summary>
    /// <returns>A sample AU Policy</returns>
    private AUPolicy CreateSamplePolicy()
    {
      var policy = new AUPolicy(InsuranceLine.PersonalAuto);
      var insured = new AUDriver(TypeOfPerson.NamedInsured, InsuranceLine.PersonalAuto);
      insured.Policy = policy;
      insured.FirstName = "Test";
      insured.LastName = "Client";
      insured.Relation = ITCConstants.RelationChars[(int)Relation.Insured];
      insured.DOB = DateTime.Today.AddYears(-30);
      insured.Sex = ITCConstants.GenderChars[(int)Gender.Male];
      insured.Gender = ITCConstants.GenderChars[(int)Gender.Male];
      insured.Address1 = "1234 Test Street";
      insured.City = "Carrollton";
      insured.State = USState.Texas;
      insured.ZipCode = "75006";
      policy.Insured = insured;
      policy.EffectiveDate = DateTime.Today;
      policy.MailingAddress.Address1 = insured.Address1;
      policy.MailingAddress.City = insured.City;
      policy.MailingAddress.State = insured.State;
      policy.MailingAddress.ZipCode = insured.ZipCode;
      policy.Term = 6;
      var driver = new AUDriver();
      policy.Drivers.Add(driver);
      policy.CopyInsuredInfoToInsuredDriver();
      //A sample driver violation. In this case, an at-fault accident.
      //driver.Violation.Add(new AUViolation() { AtFault = true, ViolCode = AUConstants.vcAccAtFault, ViolDate = new DateTime(2017, 8, 16) }); 
      var car = new AUCar();
      car.ZipCode = 75006;
      car.VIN = "1FAHP2D80E";
      car.LiabBI = true;
      car.LiabLimits1 = 50;
      car.LiabLimits2 = 100;
      car.LiabPD = true;
      car.LiabLimits3 = 50;
      car.UninsBI = false;
      car.UninsPD = false;
      car.Comp = false;
      car.Coll = false;
      car.PurchaseCost = 15000;
      car.MSRP = 15000;
      policy.Cars.Add(car);
      return policy;
    }

    /// <summary>
    /// Creates a sample policy for use in the rating API that includes DMV Actions (Suspensions) added to driver 1. Note that this is an extremely
    /// sparsely populated policy. Normally a client would fill in much more info than
    /// what is shown here. Failure to fully populate a policy before rating will often
    /// result in inaccurate rates.
    /// </summary>
    /// <returns>A sample AU Policy</returns>
    private AUPolicy CreateSamplePolicyWithDMVActions()
    {
      var policy = new AUPolicy(InsuranceLine.PersonalAuto);
      var insured = new AUDriver(TypeOfPerson.NamedInsured, InsuranceLine.PersonalAuto);
      insured.Policy = policy;
      insured.FirstName = "Test";
      insured.LastName = "Client";
      insured.Relation = ITCConstants.RelationChars[(int)Relation.Insured];
      insured.DOB = DateTime.Today.AddYears(-30);
      insured.Sex = ITCConstants.GenderChars[(int)Gender.Male];
      insured.Address1 = "1234 Test Street";
      insured.City = "Carrollton";
      insured.State = USState.Texas;
      insured.ZipCode = "75006";
      policy.Insured = insured;
      policy.EffectiveDate = DateTime.Today;
      policy.MailingAddress.Address1 = insured.Address1;
      policy.MailingAddress.City = insured.City;
      policy.MailingAddress.State = insured.State;
      policy.MailingAddress.ZipCode = insured.ZipCode;
      policy.Term = 6;
      var driver = new AUDriver();
      policy.Drivers.Add(driver);
      policy.CopyInsuredInfoToInsuredDriver();

      driver.DMVActions.Add(new DMVAction() { Action = DMVActions.Expired, DMVActionDate = DateTime.Parse("06/25/2015") });
      driver.DMVActions.Add(new DMVAction() { Action = DMVActions.Suspended, DMVActionDate = DateTime.Parse("06/25/2015") });
      driver.DMVActions.Add(new DMVAction() { Action = DMVActions.Expired, DMVActionDate = DateTime.Parse("11/18/2015"), DMVReinstatementDate = DateTime.Parse("12/18/2015") });
      driver.DMVActions.Add(new DMVAction() { Action = DMVActions.Suspended, DMVActionDate = DateTime.Parse("11/13/2015"), DMVReinstatementDate = DateTime.Parse("12/13/2015") });

      var car = new AUCar();
      car.ZipCode = 75006;
      car.VIN = "1FAHP2D80E";
      car.LiabBI = true;
      car.LiabLimits1 = 50;
      car.LiabLimits2 = 100;
      car.LiabPD = true;
      car.LiabLimits3 = 50;
      car.UninsBI = false;
      car.UninsPD = false;
      car.Comp = false;
      car.Coll = false;
      car.PurchaseCost = 15000;
      car.MSRP = 15000;
      policy.Cars.Add(car);
      return policy;
    }

    /// <summary>
    /// Creates a sample homeowner policy for use in the rating API. Note that this is an extremely
    /// sparsely populated policy. Normally a client would fill in much more info than
    /// what is shown here. Failure to fully populate a policy before rating will often
    /// result in inaccurate rates.
    /// </summary>
    /// <returns>A sample HO Policy</returns>
    private HOPolicy CreateSampleHOPolicy()
    {
      var policy = new HOPolicy();
      var insured = new PropertyPerson(TypeOfPerson.NamedInsured);
      insured.Policy = policy;
      policy.Insured = insured;
      insured.PolicyType = InsuranceLine.Homeowners;

      insured.FirstName = "Test";
      insured.LastName = "Client";
      insured.Relation = ITCConstants.RelationChars[(int)Relation.Insured];
      insured.DOB = DateTime.Today.AddYears(-30);
      insured.Sex = ITCConstants.GenderChars[(int)Gender.Male];
      insured.Address1 = "1234 Test Street";
      insured.City = "Carrollton";
      insured.State = USState.Texas;
      insured.County = "Denton";
      insured.ZipCode = "75006";
      policy.EffectiveDate = DateTime.Today;

      policy.MailingAddress.Address1 = insured.Address1;
      policy.MailingAddress.City = insured.City;
      policy.MailingAddress.State = insured.State;
      policy.MailingAddress.County = insured.County;
      policy.MailingAddress.ZipCode = insured.ZipCode;

      policy.InsuredProperty.Address1 = insured.Address1;
      policy.InsuredProperty.City = insured.City;
      policy.InsuredProperty.State = insured.State;
      policy.InsuredProperty.County = insured.County;
      policy.InsuredProperty.ZipCode = insured.ZipCode;

      policy.YearOfConstruction = 1980;
      policy.SquareFootage = 2000;
      policy.PurchaseDate = new DateTime(1990, 1, 1);

      policy.Term = 1;
      policy.TermDuration = Duration.Years;
      policy.PriorEffDate = ITCConstants.InvalidWindowsDate;
      policy.Form = "B";
      policy.Construction = HOConstants.ConstructionChars[(int)Construction.Brick];
      policy.DwellingUse = InsConstants.DwellingUseChars[(int)DwellingUse.Dwelling];
      policy.Occupancy = HOConstants.OccupancyChars[(int)Occupancy.OwnerOccupied];
      policy.RoofComposition = HOConstants.RoofCompositionChars[(int)RoofComposition.CompositeShingle];
      policy.Deductible1 = "1";
      policy.Deductible2 = "4";
      policy.Deductible3 = "250";
      policy.ProtectionClass = "0";
      policy.LiabLimit = 25000;
      policy.MedPayLimit = 1000;
      policy.DwellingAmt = 740000;
      policy.ContentsAmt = 296000;
      policy.LossOfUseAmt = 370000;

      policy.TXEndorsements.HO0455 = true;
      policy.TXEndorsements.HO160 = true;
      policy.TXEndorsements.HO160Cameras = 1000;
      policy.TXEndorsements.HO160MusicalInstruments = 1000;

      return policy;
    }

    /// <summary>
    /// Exports a policy as TT2
    /// </summary>
    /// <param name="policy">the policy to export</param>
    /// <returns>tt2 of the policy</returns>
    private string ExportPolicy(AUPolicy policy)
    {
      var bridge = new TT2AUBridge();
      bridge.Policy = policy;
      return bridge.ExportPolicyInfo();
    }

    /// <summary>
    /// Exports a homeowner policy as serialized XML.
    /// </summary>
    /// <param name="policy">the policy to export</param>
    /// <returns>XML of the policy</returns>
    private string ExportHOPolicy(HOPolicy policy)
    {
      return TransformationHelper.SerializePolicy(policy);
    }

    /// <summary>
    /// Helper method for generating a sample rate request.
    /// </summary>
    /// <returns></returns>
    private ITCRateEngineRequest DoGenerateRateRequest()
    {
      var request = new ITCRateEngineRequest();
      var policy = CreateSamplePolicy();

      //Populate the request with samples--normally you will put your own information in here
      request.AccessID = "[YOUR_ACCESS_ID_HERE]";
      request.AccountName = "[YOUR_ACCOUNT_NAME_HERE]";
      request.AccountNumber = "[YOUR_ACCOUNT_NUMBER_HERE]";
      request.BumpLimits = RateEngineBumpingEnum.bBumpUp;
      request.RealTimeAccountNumber = "[YOUR_REALTIME_ACCOUNT_NUMBER_HERE]";
      request.TransactionID = Guid.NewGuid().ToString();
      request.CustomerID = Guid.NewGuid().ToString();
      request.RateState = "TX";
      request.PolicyData = ExportPolicy(policy);
      request.LineOfInsurance = InsuranceLine.PersonalAuto;
      request.EstimateTerm = true;
      request.InsuredFirstName = "Test";
      request.InsuredMiddleName = "";
      request.InsuredLastName = "Client";
      request.Test = true;
      request.CarrierInformation.Add(new CarrierInfo()
        {
          AgencyID = new Guid("[YOUR_AGENCY_ID_HERE]"),
          CarrierID = "",
          CarrierPassword = "",
          CompanyID = 98175044,
          DOSCompanyID = -1,
          OrderCreditScore = false,
          ProducerCode = "",
          ProgramID = -1,
          SubProducerCode = ""
        });
      return request;
    }

    /// <summary>
    /// Helper method for generating a sample rate request.
    /// </summary>
    /// <returns></returns>
    private ITCRateEngineRequest DoGenerateHORateRequest()
    {
      var request = new ITCRateEngineRequest();
      var policy = CreateSampleHOPolicy();

      //Populate the request with samples--normally you will put your own information in here
      request.AccessID = "[YOUR_ACCESS_ID_HERE]";
      request.AccountName = "[YOUR_ACCOUNT_NAME_HERE]";
      request.AccountNumber = "[YOUR_ACCOUNT_NUMBER_HERE]";
      request.BumpLimits = RateEngineBumpingEnum.bBumpUp;
      request.RealTimeAccountNumber = "[YOUR_REALTIME_ACCOUNT_NUMBER_HERE]";
      request.TransactionID = Guid.NewGuid().ToString();
      request.CustomerID = Guid.NewGuid().ToString();
      request.RateState = "TX";
      request.PolicyData = ExportHOPolicy(policy);
      request.LineOfInsurance = InsuranceLine.Homeowners;
      request.EstimateTerm = true;
      request.InsuredFirstName = "Test";
      request.InsuredMiddleName = "";
      request.InsuredLastName = "Client";
      request.Test = true;
      request.CarrierInformation.Add(new CarrierInfo()
      {
        AgencyID = new Guid("[YOUR_AGENCY_ID_HERE]"),
        CarrierID = "",
        CarrierPassword = "",
        CompanyID = 94639222,
        DOSCompanyID = 99999999,
        OrderCreditScore = true,
        ProducerCode = "",
        ProgramID = -1,
        SubProducerCode = ""
      });
      return request;
    }

    [TestInitialize]
    public void Initialize()
    {
      rateEngineApiClient = new RateEngineApiClient() { AuthId = "[YOUR_ACCOUNT_NUMBER_HERE]", AuthPassword = "[YOUR_ACCOUNT_NUMBER_HERE]" };
      rateEngineApiClient.BaseUrl = RateEngineApiConstants.BaseUrlTest;
    }

    /// <summary>
    /// This method hits the ITC test rating API servers to request a rate, then loops
    /// through retrieval of rate results. Because we do not wish
    /// to have our test system hit with unit tests we have removed the [TestMethod] attribute.
    /// </summary>
    //[TestMethod]
    public void RateAndGetResults()
    {
      var request = DoGenerateRateRequest();
      try
      {
        rateEngineApiClient.RatePolicy(request);
      }
      catch (HttpException ex)
      {
        //if it's a validation error, handle appropriately.
        if (ex.GetHttpCode() == (int)HttpStatusCode.BadRequest)
        {
          var validationMessages = ex.Message;
          if (!String.IsNullOrWhiteSpace(validationMessages))
          {
            //do something with validation message(s)
          }
        }
        else
          throw; //if it wasn't a validation error, rethrow the exception
      }
      var stopwatch = new Stopwatch();
      bool is404 = false;
      bool receivedAllResponses = false;
      List<ITCRateEngineResponse> allResponses = new List<ITCRateEngineResponse>();
      stopwatch.Start();
      do
      {
        is404 = false;
        Thread.Sleep(2000);
        try
        {
          receivedAllResponses = true;
          var responses = rateEngineApiClient.GetRateResults(request.TransactionID, false);
          allResponses.AddRange(responses);

          //Because I'm only retrieving those rates which I hadn't retrieved from previous calls to GetRateResults,
          //I have to check to see if I've received a response for each company requested.
          var requestedCompanyIds = from carrierInfo in request.CarrierInformation
                                    select carrierInfo.CompanyID;
          foreach (var companyId in requestedCompanyIds)
          {
            if (!allResponses.Exists(item => item.CompanyID == companyId))
            {
              receivedAllResponses = false;
              break;
            }
          }
        }
        catch (HttpException ex)
        {
          is404 = ex.GetHttpCode() == 404;
          receivedAllResponses = false;
        }
      } while (stopwatch.ElapsedMilliseconds < 20000 && !is404 && !receivedAllResponses);
      stopwatch.Stop();
      Assert.IsTrue(true); //not looking for anything special here...if we didn't throw an exception then the test worked.
    }

    /// <summary>
    /// This method hits the ITC test rating API servers to request a rate, then loops
    /// through retrieval of rate results. Because we do not wish
    /// to have our test system hit with unit tests we have removed the [TestMethod] attribute.
    /// How is this unit test different from the non-asynchronous unit test? 2 ways:
    /// 1) It runs the async version of RatePolicyAsync().
    /// 2) It uses the new (4th quarter 2015) property AllRatingComplete within rate response objects to determine if rating is completed.
    /// </summary>
    //[TestMethod]
    public void RateAndGetResultsAsync()
    {
      var request = DoGenerateRateRequest();
      try
      {
        rateEngineApiClient.RatePolicyAsync(request).GetAwaiter().GetResult(); //NOTE: as a client of this class, it's better to call "await rateEngineApiClient.RatePolicyAsync(request);". it's done this other way here because of quirks of unit testing. 
      }
      catch (HttpException ex)
      {
        //if it's a validation error, handle appropriately.
        if (ex.GetHttpCode() == (int)HttpStatusCode.BadRequest)
        {
          var validationMessages = ex.Message;
          if (!String.IsNullOrWhiteSpace(validationMessages))
          {
            //do something with validation message(s)
          }
        }
        else
          throw; //if it wasn't a validation error, rethrow the exception
      }
      var stopwatch = new Stopwatch();
      bool is404 = false;
      bool receivedAllResponses = false;
      List<ITCRateEngineResponse> allResponses = new List<ITCRateEngineResponse>();
      stopwatch.Start();
      do
      {
        is404 = false;
        Thread.Sleep(2000);
        try
        {
          var responses = rateEngineApiClient.GetRateResults(request.TransactionID, false);
          allResponses.AddRange(responses);
          receivedAllResponses = responses.Select(rsp => rsp.AllRatingComplete).First();
        }
        catch (HttpException ex)
        {
          is404 = ex.GetHttpCode() == 404;
          receivedAllResponses = false;
        }
      } while (stopwatch.ElapsedMilliseconds < 20000 && !is404 && !receivedAllResponses);
      stopwatch.Stop();
      Assert.IsTrue(true); //not looking for anything special here...if we didn't throw an exception then the test worked.
    }

    /// <summary>
    /// This method hits the ITC test rating API servers to request a rate, then loops
    /// through retrieval of rate results. Because we do not wish
    /// to have our test system hit with unit tests we have removed the [TestMethod] attribute.
    /// How is this unit test different from the non-asynchronous unit test? 2 ways:
    /// 1) It runs the async version of RatePolicyAsync().
    /// 2) It uses the new (4th quarter 2015) property AllRatingComplete within rate response objects to determine if rating is completed.
    /// </summary>
    //[TestMethod]
    public void RateHOAndGetResultsAsync()
    {
      var request = DoGenerateHORateRequest();
      try
      {
        rateEngineApiClient.RatePolicyAsync(request).GetAwaiter().GetResult(); //NOTE: as a client of this class, it's better to call "await rateEngineApiClient.RatePolicyAsync(request);". it's done this other way here because of quirks of unit testing. 
      }
      catch (HttpException ex)
      {
        //if it's a validation error, handle appropriately.
        if (ex.GetHttpCode() == (int)HttpStatusCode.BadRequest)
        {
          var validationMessages = ex.Message;
          if (!String.IsNullOrWhiteSpace(validationMessages))
          {
            //do something with validation message(s)
          }
        }
        else
          throw; //if it wasn't a validation error, rethrow the exception
      }
      var stopwatch = new Stopwatch();
      bool is404 = false;
      bool receivedAllResponses = false;
      List<ITCRateEngineResponseHO2> allResponses = new List<ITCRateEngineResponseHO2>();
      stopwatch.Start();
      do
      {
        is404 = false;
        Thread.Sleep(2000);
        try
        {
          var responses = rateEngineApiClient.GetHORateResults(request.TransactionID, false);
          allResponses.AddRange(responses);
          receivedAllResponses = responses.Select(rsp => rsp.AllRatingComplete).First();
        }
        catch (HttpException ex)
        {
          is404 = ex.GetHttpCode() == 404;
          receivedAllResponses = false;
        }
      } while (stopwatch.ElapsedMilliseconds < 30000 && is404 && !receivedAllResponses);
      stopwatch.Stop();
      Assert.IsTrue(true); //not looking for anything special here...if we didn't throw an exception then the test worked.
    }


    /// <summary>
    /// An example of retrieving rating company information from the ITC rating servers. 
    /// </summary>
    public void GetCompanyInfo()
    {
      var request = DoGenerateGetCompanyInfoRequest();
      rateEngineApiClient.BaseUrl = TurboRater.ApiClients.RateEngineApi.RateEngineApiConstants.BaseUrlLive;
      var companyInfoResponse = rateEngineApiClient.GetCompanyInfo(request);
      Assert.IsNotNull(companyInfoResponse);
      Assert.IsTrue(companyInfoResponse.CompanyInfoList != null && companyInfoResponse.CompanyInfoList.Count > 0);
    }

    /// <summary>
    /// Generates a request object used to retrieve company information from the ITC Rate Engine API.
    /// </summary>
    /// <returns>Request object used to retrieve company information from the ITC Rate Engine API.</returns>
    private CompanyInfoRequest DoGenerateGetCompanyInfoRequest()
    {
      return new CompanyInfoRequest()
      {
        AccessID = "[YOUR_ACCESS_ID_HERE]",
        AccountName = "[YOUR_ACCOUNT_NAME_HERE]",
        AccountNumber = "[YOUR_ACCOUNT_NUMBER_HERE]", 
        //OPTIONAL-AgencyId = Guid.Parse("[YOUR_AGENCY_ID_HERE]"),
        IncludeCompanyQuestions = false,
        State = "TX",
        Type = "All",
      };
    }

    //[TestMethod]
    public void RateHOFullProcess()
    {
      // See the HomeRating sample class to see what all this is doing.
      var rater = new HomeRating(new Guid("[Your IMP Account ID Here"), "[Your API Access ID Here]", "[Your API Account Name Here]", 
        "[Your API Account Number Here]", "[Your API Real-Time Account Number Here", true);

      // Find a client by name
      var quotes = rater.SearchHomeownerQuotesByName("Sample", "Homeowner");
      // Find the first quote belonging to the client
      var quoteId = quotes.First();
      // Load the saved quote by quote ID just retrieved
      var policy = rater.GetHomeownerQuoteById(quoteId);

      // Make a cloned copy of the policy (this is just an example, not needed for rating)
      var anotherPolicy = rater.ClonePolicy(policy);

      // If the quote is to be saved back to online storage, this will clear out the record IDs
      // of the policy so that it saves as a new policy and not over the old one. Also not necessary
      // for rating, just provided as an example.
      rater.ClearRecordIdsForFreshSave(policy);

      // Set some values to something other than the default in the saved quote
      policy.DwellingAmt = 300000;
      policy.ContentsAmt = 30000;
      policy.Insured.IndustryOccupation = ITCConstants.OccupationChars[3];

      // Get company info for Texas
      var companyInfoList = rater.GetHomeownerCompanyInfo(USState.Texas);      
      // Find company questions for Travelers TX, take first one, ignore program ID, not used for company questions
      var companyInfo = companyInfoList.First(company => company.CompanyID == 94639222);

      // Get company questions.  Company Credits work the same way as company questions, only use companyInfo.HOCompanyCredits
      var companyQuestions = companyInfo.HOCompanyQuestions;
      // Getting the default value for an arbitrary company question
      var defaultPackageSelectionValue = companyQuestions.First(question => question.Identifier == "TravelersPackageSelection").DefaultValue;
      // Getting the current value from the policy for a company question
      var currentPackageValue = policy.GetCompanyData("TravelersPackageSelection", string.Empty);
      // Setting the current value for a company question
      policy.SetCompanyData("TravelersPackageSelection", "Silver");
      // or, use the default just retrieved
      policy.SetCompanyData("TravelersPackageSelection", defaultPackageSelectionValue);

      // Get company endorsements
      var companyEndorsements = companyInfo.HOCompanyEndorsements;
      // Getting the default value for an arbitrary company endorsement:
      // NOTE: with Endorsements, there can be additional questions nested below the main one.  In this example,
      // TravelersEarthQuakeVeneer is a sub-question under TravelersEarthQuake.  So there are 2 values, 
      // the value for TravelersEarthQuake itself, and the value for TravelersEarthQuakeVeneer.
      var endorsement = companyEndorsements.First(endo => endo.Identifier == "TravelersEarthQuake");
      var veneerQuestion = endorsement.Questions.First(endo => endo.Identifier == "TravelersEarthQuakeVeneer");
      var defaultEndorsementValue = veneerQuestion.DefaultValue;
      // Getting the current value from the policy for an endorsement
      var currentVeneerValue = policy.GetCompanyData("TravelersEarthQuakeVeneer", string.Empty);
      // Setting the current value for an endorsement
      policy.SetCompanyData("TravelersEarthQuakeVeneer", "C");
      // or, use the default just retrieved
      policy.SetCompanyData("TravelersEarthQuakeVeneer", currentVeneerValue);

      var carrierInformation = new List<CarrierInfo>()
      {
        new CarrierInfo()
        {
          AgencyFee = 0,
          AgencyID = new Guid("[Your Agency ID Here]"),
          CarrierID = "[Your Carrier User ID Here]",
          CarrierPassword = "[Your Carrier Password Here]",
          DOSCompanyID = 99999999,
          OrderCreditScore = true,
          ProducerCode = "[Your producer code here]",
          SubProducerCode = string.Empty,
          CompanyID = 94639222,
          ProgramID = -1
        }
      };

      // Rate the policy
      var request = rater.SendHomeownerRateRequest(policy, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), USState.Texas, carrierInformation);

      // Wait for responses
      var stopwatch = new Stopwatch();
      bool is404 = false;
      bool receivedAllResponses = false;
      var allResponses = new List<ITCRateEngineResponseHO2>();
      stopwatch.Start();
      do
      {
        is404 = false;
        Thread.Sleep(2000);
        try
        {
          var responses = rateEngineApiClient.GetHORateResults(request.TransactionID, false);
          allResponses.AddRange(responses);
          receivedAllResponses = responses.Select(rsp => rsp.AllRatingComplete).First();
        }
        catch (HttpException ex)
        {
          is404 = ex.GetHttpCode() == 404;
          receivedAllResponses = false;
        }
      }
      while (stopwatch.ElapsedMilliseconds < 30000 && is404 && !receivedAllResponses);
      stopwatch.Stop();
    }

  }
}
