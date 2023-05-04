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
using OfficeOpenXml;

namespace SdkRater.RateUtilityLib
{
  /// <summary>
  /// A library that includes all Excel related functionality used for exporting the rating results in a pleasing manner
  /// </summary>
  public class ExcelLibrary
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
    /// Create a row of Excel data in worksheet
    /// </summary>
    /// <param name="worksheet">the worksheet to generate the row data to</param>
    /// <param name="ratedCompanyByPayPlanResponse">the company response to fill the row's cell data with</param>
    /// <param name="rowNum">the current row</param>
    /// <param name="headerRow">if header row display a nice header, otherwise fill with cell data</param>
    /// <param name="errors">if errors exist </param>
    /// <param name="quoteNumber">quote number of the returned quote</param>
    public static void GenerateRow(ExcelWorksheet worksheet, ITCRateEngineResponse ratedCompanyByPayPlanResponse, int rowNum, bool headerRow, bool errors, int quoteNumber)
    {
      int columnIndex = 0;
      if (headerRow)
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = "Quote #";
      else
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = quoteNumber;
      columnIndex++;
      ITCRateEngineRequest request = ratingRequests.Find(item => item.CustomerID == ratedCompanyByPayPlanResponse.CustomerID);
      DateTime effectiveDateTime = ratedCompanyByPayPlanResponse.EffectiveDate;
      string companyName = ratedCompanyByPayPlanResponse.CompanyName;
      if (String.IsNullOrWhiteSpace(companyName))
      {
        if (Companies.ToList().Exists(carrier => carrier.CompanyID == ratedCompanyByPayPlanResponse.CompanyID && carrier.ProgramID == ratedCompanyByPayPlanResponse.ProgramID))
          if (Companies.ToList().FindIndex(carrier => carrier.CompanyID == ratedCompanyByPayPlanResponse.CompanyID && carrier.ProgramID == ratedCompanyByPayPlanResponse.ProgramID) != -1)
          {
            int companyIndex = Companies.ToList().FindIndex(carrier => carrier.CompanyID == ratedCompanyByPayPlanResponse.CompanyID && carrier.ProgramID == ratedCompanyByPayPlanResponse.ProgramID);
            companyName = Companies.ToList()[companyIndex].CompanyName;
            effectiveDateTime = Companies.ToList()[companyIndex].RateEffectiveDate;
          }
        if (String.IsNullOrWhiteSpace(companyName))
          if (Companies.ToList().Exists(carrier => carrier.CompanyID == request.CarrierInformation[0].CompanyID && carrier.ProgramID == request.CarrierInformation[0].ProgramID))
            if (Companies.ToList().FindIndex(carrier => carrier.CompanyID == request.CarrierInformation[0].CompanyID && carrier.ProgramID == request.CarrierInformation[0].ProgramID) != -1)
            {
              int companyIndex = Companies.ToList().FindIndex(carrier => carrier.CompanyID == request.CarrierInformation[0].CompanyID && carrier.ProgramID == request.CarrierInformation[0].ProgramID);
              companyName = Companies.ToList()[companyIndex].CompanyName;
            }
      }
      worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? "Company Name" : companyName;
      columnIndex++;
      worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? "Tier" : ratedCompanyByPayPlanResponse.Tier;
      columnIndex++;
      if (headerRow)
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = "Term";
      else
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ratedCompanyByPayPlanResponse.Term;
      columnIndex++;
      worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? "Effective Date" : effectiveDateTime.ToString("MM/dd/yyyy");
      columnIndex++;
      worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? "Quote Name" : request != null ? (request.InsuredLastName + ", " + request.InsuredFirstName) : String.Empty;
      columnIndex++;

      if (headerRow)
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = "Policy Fee";
      else
      {
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ratedCompanyByPayPlanResponse.PolicyFee;
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Style.Numberformat.Format = "$#,##0.00";
      }
      columnIndex++;
      if (headerRow)
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = "Sr22 Fee";
      else
      {
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ratedCompanyByPayPlanResponse.SR22Fee;
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Style.Numberformat.Format = "$#,##0.00";
      }
      columnIndex++;
      if (headerRow)
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = "Total Premium";
      else
      {
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ratedCompanyByPayPlanResponse.TotalPremium;
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Style.Numberformat.Format = "$#,##0.00";
      }
      columnIndex++;
      if (headerRow)
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = "Pay Plan Description";
      else
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ratedCompanyByPayPlanResponse.PayPlanDescription;
      columnIndex++;
      if (headerRow)
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = "Down Payment";
      else
      {
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ratedCompanyByPayPlanResponse.PayPlanDownPayment;
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Style.Numberformat.Format = "$#,##0.00";
      }
      columnIndex++;
      if (headerRow)
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = "Payment Amount";
      else
      {
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ratedCompanyByPayPlanResponse.PayPlanPaymentAmount;
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Style.Numberformat.Format = "$#,##0.00";
      }
      columnIndex++;

      if (!errors)
      {
        foreach (ResponseCar car in ratedCompanyByPayPlanResponse.Cars)
        {
          string displayedVehicle = "Car " + (car.CarNumber).ToString();
          worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? displayedVehicle + " Vin" : car.VIN;
          columnIndex++;
          if (headerRow)
            worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = displayedVehicle + " Year";
          else
            worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = car.Year;
          columnIndex++;
          worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? displayedVehicle + " Make" : car.Make;
          columnIndex++;
          worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? displayedVehicle + " Model" : car.Model;
          columnIndex++;
          worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? displayedVehicle + " Symbol" : car.Symbol;
          columnIndex++;
          foreach (Coverage covg in car.Coverages)
          {
            worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? displayedVehicle + " Coverage" : covg.CoverageName;
            columnIndex++;
            if (headerRow)
              worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = displayedVehicle + " Limit/Deductible";
            else
            {
              if (ExtractSingleCoverageLimitByName(covg.CoverageName, car.Coverages) != -1)
                worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ExtractSingleCoverageLimitByName(covg.CoverageName, car.Coverages);
              else if (ExtractSingleCoverageDeductibleByName(covg.CoverageName, car.Coverages) != -1)
                worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ExtractSingleCoverageDeductibleByName(covg.CoverageName, car.Coverages);
              else
                worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = ExtractCoverageLimitDeductibleByName(covg.CoverageName, car.Coverages);
            }
            columnIndex++;
            if (headerRow)
              worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = displayedVehicle + " Premium";
            else
            {
              if (covg.Premium != InsConstants.IncludedPremium)
                worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Style.Numberformat.Format = "$0.00";
              string premium = covg.Premium == InsConstants.IncludedPremium ? "Incl" : covg.Premium.ToString();
              worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = premium; 
            }
            columnIndex++;
          }
        }
      }
      else
      {
        string errorText = "";
        foreach (ResponseMessage error in ratedCompanyByPayPlanResponse.Errors)
          errorText += error.Text + " ";
        errorText = errorText.Trim();
        worksheet.Cells[GetColumnName(columnIndex) + rowNum.ToString()].Value = headerRow ? "Errors" : errorText;
      }
    }

    /// <summary>
    /// Generate an Excel column name on the fly: AKA A1/CB4/etc....
    /// </summary>
    /// <param name="index">Index of the column being passed in</param>
    /// <returns>The cell to set data to, whether it be A1/CB4/etc....</returns>
    public static string GetColumnName(int index)
    {
      const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      var value = "";
      if (index >= letters.Length)
        value += letters[index / letters.Length - 1];
      value += letters[index % letters.Length];
      return value;
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
            return String.Empty;
          default:
            return String.Empty;
        }
      }
      return String.Empty;
    }

    /// <summary>
    /// Get the single limit value to include in the row cell
    /// </summary>
    /// <param name="name">Name of the coverage to search for</param>
    /// <param name="coverages">List of coverages in the company response</param>
    /// <returns></returns>
    private static int ExtractSingleCoverageLimitByName(string name, List<Coverage> coverages)
    {
      Coverage covgInfo = new Coverage();
      covgInfo = coverages.Find(item => item.CoverageName.Equals(name, StringComparison.OrdinalIgnoreCase));
      if (covgInfo != null)
      {
        if (covgInfo.CoverageName != "BI" &&
          covgInfo.CoverageName != "BI" &&
          covgInfo.CoverageName != "OPTBI" &&
          covgInfo.CoverageName != "UM" &&
          covgInfo.CoverageName != "UNDUM" &&
          covgInfo.CoverageName != "COMP" &&
          covgInfo.CoverageName != "COLL" &&
          covgInfo.CoverageName != "LCOL" &&
          covgInfo.CoverageName != "CWAIV")
          return covgInfo.Limit[0];
      }
      return -1;
    }

    /// <summary>
    /// Get the single deductible value to include in the row cell
    /// </summary>
    /// <param name="name">Name of the coverage to search for</param>
    /// <param name="coverages">List of coverages in the company response</param>
    /// <returns></returns>
    private static double ExtractSingleCoverageDeductibleByName(string name, List<Coverage> coverages)
    {
      Coverage covgInfo = new Coverage();
      covgInfo = coverages.Find(item => item.CoverageName.Equals(name, StringComparison.OrdinalIgnoreCase));
      if (covgInfo != null)
      {
        switch (covgInfo.CoverageName)
        {
          case "COMP":
          case "COLL":
          case "LCOL":
          case "CWAIV":
            return covgInfo.Deductible;
          default:
            return -1;
        }
      }
      return -1;
    }

    /// <summary>
    /// Return the number of columns in an ITCRateEngineResponse
    /// </summary>
    /// <param name="response">The response to count columns in</param>
    /// <returns>The number of columns in an ITCRateEngineResponse</returns>
    public static int NumberOfColumnsInARatingCompanyResponse(ITCRateEngineResponse response)
    {
      int result = 12; // row data up to the vehicle section
      foreach (ResponseCar car in response.Cars)
      {
        result += 4; // vin/year/make/model
        foreach (Coverage covg in car.Coverages)
          result += 3; // coverage/(limit/deductible)/premium
      }
      return result;
    }

    /// <summary>
    /// Given a list of successfulResponses find the response with the most columns to use as the header
    /// </summary>
    /// <param name="successfulResponses">the list of ITCRateEngineResponses to search through</param>
    /// <returns>The ITCRateEngineResponse with the most columns</returns>
    public static ITCRateEngineResponse LongestResponse(List<ITCRateEngineResponse> successfulResponses)
    {
      ITCRateEngineResponse longestResponse = successfulResponses[0];
      foreach (ITCRateEngineResponse response in successfulResponses)
        if (NumberOfColumnsInARatingCompanyResponse(response) > NumberOfColumnsInARatingCompanyResponse(longestResponse))
          longestResponse = response;
      return longestResponse;
    }

    /// <summary>
    /// Generate an excel spreadsheet based in returned rating information within RatingCompanyResponses
    /// </summary>
    /// <param name="ratingRequests"></param>
    /// <param name="RatingCompanyResponses"></param>
    /// <param name="Companies"></param>
    public static void GenerateExcelResponse() // List<ITCRateEngineRequest> ratingRequests, List<List<ITCRateEngineResponse>> RatingCompanyResponses, List<CompanyInfo> Companies)
    {
      if (RatingCompanyResponses.Count > 0 && RatingCompanyResponses[0].Count > 0)
      {
        SaveFileDialog saveFile = new SaveFileDialog();
        saveFile.Filter = "Excel Files (.xlsx)|*.xlsx|All Files (*.*)|*.*";
        saveFile.FilterIndex = 0;
        DialogResult result = saveFile.ShowDialog();

        System.IO.FileInfo fi = new System.IO.FileInfo(saveFile.FileName);
        if (fi.Exists)
          fi.Delete();
        using (ExcelPackage package = new ExcelPackage(fi))
        {
          int quoteNumber = 1;
          int successfulRowCount = 1;
          int erroredRowCount = 1;
          bool generateSuccessfulHeader = false;
          bool generateErroredHeader = false;
          foreach (List<ITCRateEngineResponse> ratingCompanyResponse in RatingCompanyResponses)
          {
            if (ratingCompanyResponse.Count() > 0)
            {
              var erroredData = ratingCompanyResponse.Where(x => x.Errors.Count > 0 && x.TotalPremium <= 0);
              var successfulData = ratingCompanyResponse.Except(erroredData);
              // successful rates section
              if (successfulData.Count() > 0)
              {
                string successfulTab = "Successful Auto Rates";
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(item => item.Name == successfulTab) != null ? package.Workbook.Worksheets.FirstOrDefault(item => item.Name == successfulTab) : package.Workbook.Worksheets.Add(successfulTab);

                GenerateRow(worksheet, LongestResponse(successfulData.ToList()), successfulRowCount, !generateSuccessfulHeader, false, quoteNumber);
                generateSuccessfulHeader = true;

                successfulRowCount++;
                foreach (ITCRateEngineResponse ratedCompanyByPayPlanResponse in successfulData)
                {
                  GenerateRow(worksheet, ratedCompanyByPayPlanResponse, successfulRowCount, false, false, quoteNumber);
                  successfulRowCount++;
                }
                worksheet.Cells.AutoFitColumns(0);
              }
              // errored rates section
              if (erroredData.Count() > 0)
              {
                string erroredTab = "Errored Auto Rates";

                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(item => item.Name == erroredTab) != null ? package.Workbook.Worksheets.FirstOrDefault(item => item.Name == erroredTab) : package.Workbook.Worksheets.Add(erroredTab);
                GenerateRow(worksheet, erroredData.ToList()[0], erroredRowCount, !generateErroredHeader, true, quoteNumber);
                generateErroredHeader = true;
                erroredRowCount++;
                foreach (ITCRateEngineResponse ratedCompanyByPayPlanResponse in erroredData)
                {
                  GenerateRow(worksheet, ratedCompanyByPayPlanResponse, erroredRowCount, false, true, quoteNumber);
                  erroredRowCount++;
                }
                worksheet.Cells.AutoFitColumns(0);
              }
            }
            quoteNumber++;
          }
          package.Workbook.Properties.Company = "Insurance Technologies Corp.";
          package.Save();
          MessageBox.Show("Successfully saved rated data.");
        }
      }
      else
        MessageBox.Show("No results returned from rating service.");
    }

  }
}