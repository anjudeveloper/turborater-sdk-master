using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurboRater.ApiClients.Imp;
using TurboRater.Insurance.AU;
using TurboRater.Insurance;
using TurboRater.InterfaceSpecifications;
using TurboRater.ApiClients.Imp.Itc.EFContexts;
using System.Net;
using TurboRater;
using TurboRater.ApiClients.RateEngineApi;
using TurboRater.Insurance.DataTransformation;

namespace SdkRater.RateUtilityLib
{
  /// <summary>
  /// A library that includes all CSV related functionality used for exporting the rating results in a pleasing manner
  /// </summary>
  public class CsvLibrary
  {
    /// <summary>
    /// Multiple ratingRequest objects 
    /// </summary>
    public static List<ITCRateEngineRequest> ratingRequests;

    /// <summary>
    /// RatingResponses returned per quote requested.  the main list is per quote, the inner list is per payment option returned
    /// </summary>
    public static List<List<ITCRateEngineResponse>> RatingCompanyResponses;

    /// <summary>
    /// All companies returned from the ITC rating service whether active or not
    /// </summary>
    public static List<CompanyInfo> Companies;

    /// <summary>
    /// Generate a new row for the export csv file
    /// </summary>
    /// <returns>A new row for the export csv file</returns>
    private static string GetNewRow()
    {
      return "\r\n";
    }

    /// <summary>
    /// Generate a new cell for the export csv file being created
    /// </summary>
    /// <param name="cellText">Text used for the individual cell</param>
    /// <returns>A new cell for the export csv file being created</returns>
    private static string GetNewCell(string cellText)
    {
      cellText = cellText.Replace("\"", "'");
      if (cellText.IndexOf(",", StringComparison.OrdinalIgnoreCase) != -1)
        cellText = "\"" + cellText + "\"";
      return cellText + ",";
    }

    /// <summary>
    /// Generate a header for the csv file being generated
    /// </summary>
    /// <param name="ratingCompanyResponse">response returned by the carrier, this is per payment option</param>
    /// <param name="errors">add an extra row if errors is true, not if not</param>
    /// <returns></returns>
    public static StringBuilder GenerateHeader(ITCRateEngineResponse ratingCompanyResponse, bool errors)
    {
      StringBuilder csvOutput = new StringBuilder();
      csvOutput.Append(GetNewCell("Quote #"));
      csvOutput.Append(GetNewCell("Company name"));
      csvOutput.Append(GetNewCell("Tier"));
      csvOutput.Append(GetNewCell("Term"));
      csvOutput.Append(GetNewCell("Effective date"));
      csvOutput.Append(GetNewCell("Quote Name"));
      csvOutput.Append(GetNewCell("Policy fee"));
      csvOutput.Append(GetNewCell("Sr22 fee"));
      csvOutput.Append(GetNewCell("Total premium"));
      if (!errors)
        csvOutput.Append(GetNewCell("Pay plan description"));
      csvOutput.Append(GetNewCell("Down payment"));
      csvOutput.Append(GetNewCell("Payment amount"));
      if (!errors)
        foreach (ResponseCar car in ratingCompanyResponse.Cars)
        {
          string displayedVehicle = "Car " + (car.CarNumber).ToString();
          csvOutput.Append(GetNewCell(displayedVehicle + " Vin"));
          csvOutput.Append(GetNewCell(displayedVehicle + " Year"));
          csvOutput.Append(GetNewCell(displayedVehicle + " Make"));
          csvOutput.Append(GetNewCell(displayedVehicle + " Model"));
          csvOutput.Append(GetNewCell(displayedVehicle + " Symbol"));
          foreach (Coverage covg in car.Coverages)
          {
            csvOutput.Append(GetNewCell(displayedVehicle + " Coverage"));
            csvOutput.Append(GetNewCell(displayedVehicle + " Limit/Deductible"));
            csvOutput.Append(GetNewCell(displayedVehicle + " Premium"));
          }
        }
      if (errors)
        csvOutput.Append(GetNewCell("Errors"));
      csvOutput.Append(GetNewRow());
      return csvOutput;
    }

    /// <summary>
    /// Return the limit/deductible based on the coverage name
    /// </summary>
    /// <param name="name">Name of the coverage to find the limit/deductible</param>
    /// <param name="coverages">The list of coverages the name could be in</param>
    /// <returns>The limit/deductible information based on parameter name</returns>
    private static string ExtractCoverageLimitDeductibleByName(string name, List<Coverage> coverages)
    {
      Coverage covgInfo = new Coverage();
      covgInfo = coverages.Find(item => item.CoverageName.Equals(name, StringComparison.OrdinalIgnoreCase));
      if (covgInfo != null)
      {
        switch (covgInfo.CoverageName)
        {
          case "BI":
          case "OPTBI":
          case "UM":
          case "UNDUM":
            return covgInfo.Limit[0] + "/" + covgInfo.Limit[1];
          case "COMP":
          case "COLL":
          case "LCOL":
          case "CWAIV":
            return covgInfo.Deductible.ToString();
          default:
            return covgInfo.Limit[0].ToString();
        }
      }
      return String.Empty;
    }

    /// <summary>
    /// Generate a CSV response from the rated company response data
    /// </summary>
    public static void GenerateCSVResponse()
    {
      if (RatingCompanyResponses.Count > 0 && RatingCompanyResponses[0].Count > 0)
      {
        SaveFileDialog saveFile = new SaveFileDialog();
        saveFile.Filter = "Comma Separated Files (.csv)|*.csv|All Files (*.*)|*.*";
        saveFile.FilterIndex = 0;
        DialogResult result = saveFile.ShowDialog();
        if (result == DialogResult.OK)
        {
          StringBuilder csvOutput = new StringBuilder();
          int quoteNumber = 1;
          foreach (List<ITCRateEngineResponse> ratingCompanyResponse in RatingCompanyResponses)
          {
            if (ratingCompanyResponse.Count() > 0)
            {
              var erroredData = ratingCompanyResponse.Where(x => x.Errors.Count > 0);
              var successfulData = ratingCompanyResponse.Except(erroredData);

              if (successfulData.Count() > 0)
              {
                csvOutput.Append(GenerateHeader(successfulData.ToList()[0], false));
                foreach (ITCRateEngineResponse ratedCompanyByPayPlanResponse in successfulData)
                {
                  // we need to pull the rating request to get more info, apparently just the last/first name of the insured
                  ITCRateEngineRequest request = ratingRequests.Find(item => item.CustomerID == ratedCompanyByPayPlanResponse.CustomerID);
                  csvOutput.Append(GetNewCell(quoteNumber.ToString()));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.CompanyName));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.Tier));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.Term.ToString()));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.EffectiveDate.ToString("MM/dd/yyyy")));
                  csvOutput.Append(GetNewCell(request.InsuredLastName + ", " + request.InsuredFirstName));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.PolicyFee.ToString("N2")));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.SR22Fee.ToString("N2")));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.TotalPremium.ToString("N2")));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.PayPlanDescription != null ? ratedCompanyByPayPlanResponse.PayPlanDescription : String.Empty));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.PayPlanDownPayment.ToString("N2")));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.PayPlanPaymentAmount.ToString("N2")));
                  foreach (ResponseCar car in ratedCompanyByPayPlanResponse.Cars)
                  {
                    string displayedVehicle = "Car " + (car.CarNumber).ToString();
                    csvOutput.Append(GetNewCell(car.VIN));
                    csvOutput.Append(GetNewCell(car.Year.ToString()));
                    csvOutput.Append(GetNewCell(car.Make));
                    csvOutput.Append(GetNewCell(car.Model));
                    csvOutput.Append(GetNewCell(car.Symbol));
                    foreach (Coverage covg in car.Coverages)
                    {
                      csvOutput.Append(GetNewCell(covg.CoverageName));
                      csvOutput.Append(GetNewCell(ExtractCoverageLimitDeductibleByName(covg.CoverageName, car.Coverages)));
                      string premium = covg.Premium == InsConstants.IncludedPremium ? "Incl" : covg.Premium.ToString();
                      csvOutput.Append(GetNewCell(premium));
                    }
                  }
                  csvOutput.Append(GetNewRow());
                }
              }
              if (successfulData.Count() > 0)
                csvOutput.Append(GetNewRow());

              if (erroredData.Count() > 0)
              {
                csvOutput.Append(GenerateHeader(erroredData.ToList()[0], true));
                // now fill in the gaps from the quote
                foreach (ITCRateEngineResponse ratedCompanyByPayPlanResponse in erroredData)
                {
                  // we need to pull the rating request to get more info, apparently just the last/first name of the insured
                  ITCRateEngineRequest request = ratingRequests.Find(item => item.CustomerID == ratedCompanyByPayPlanResponse.CustomerID);
                  csvOutput.Append(GetNewCell(quoteNumber.ToString()));
                  DateTime effectiveDateTime = ratedCompanyByPayPlanResponse.EffectiveDate;
                  string carrierName = ratedCompanyByPayPlanResponse.CompanyName;
                  if (String.IsNullOrWhiteSpace(carrierName))
                    if (Companies.ToList().Exists(carrier => carrier.CompanyID == ratedCompanyByPayPlanResponse.CompanyID && carrier.ProgramID == ratedCompanyByPayPlanResponse.ProgramID))
                      if (Companies.ToList().FindIndex(carrier => carrier.CompanyID == ratedCompanyByPayPlanResponse.CompanyID && carrier.ProgramID == ratedCompanyByPayPlanResponse.ProgramID) != -1)
                      {
                        int companyIndex = Companies.ToList().FindIndex(carrier => carrier.CompanyID == ratedCompanyByPayPlanResponse.CompanyID && carrier.ProgramID == ratedCompanyByPayPlanResponse.ProgramID);
                        carrierName = Companies.ToList()[companyIndex].CompanyName;
                        effectiveDateTime = Companies.ToList()[companyIndex].RateEffectiveDate;
                      }
                  csvOutput.Append(GetNewCell(carrierName));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.Tier));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.Term.ToString()));
                  csvOutput.Append(GetNewCell(effectiveDateTime.ToString("MM/dd/yyyy")));
                  csvOutput.Append(GetNewCell(request != null ? (request.InsuredLastName + ", " + request.InsuredFirstName) : String.Empty));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.PolicyFee.ToString("N2")));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.SR22Fee.ToString("N2")));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.TotalPremium.ToString("N2")));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.PayPlanDescription != null ? ratedCompanyByPayPlanResponse.PayPlanDescription : String.Empty));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.PayPlanDownPayment.ToString("N2")));
                  csvOutput.Append(GetNewCell(ratedCompanyByPayPlanResponse.PayPlanPaymentAmount.ToString("N2")));
                  string errorText = "";
                  foreach (ResponseMessage error in ratedCompanyByPayPlanResponse.Errors)
                    errorText += error.Text + " ";
                  errorText = errorText.Trim();
                  csvOutput.Append(GetNewCell(errorText));
                  csvOutput.Append(GetNewRow());
                }
                if (erroredData.Count() > 0)
                  csvOutput.Append(GetNewRow());
              }
            }
            else
              MessageBox.Show("No rating responses were returned.");
            quoteNumber++;
          }
          if (csvOutput.Length > 0)
          {
            System.IO.File.WriteAllText(saveFile.FileName, csvOutput.ToString());
            MessageBox.Show("Successfully saved rated data.");
          }
          else
            MessageBox.Show("An error occurred during the Save clicking process.");
        }
        else
          MessageBox.Show("An error occurred during the Save clicking process.");
      }
      else
        MessageBox.Show("No results returned from rating service.");
    }

  }
}