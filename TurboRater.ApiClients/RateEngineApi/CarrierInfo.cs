using System;
using System.ComponentModel.DataAnnotations;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Information about a specific carrier and agency used during the rating process.
  /// </summary>
  public class CarrierInfo
  {
    /// <summary>
    /// The agencyID for the TWE account. REQUIRED! 
    /// </summary>
    [Required]
    public Guid? AgencyID { get; set; }
    /// <summary>
    /// The carriers login for credit scoring with a company, or rating through realtime portals. 
    /// Leave blank if there is no value to pass.
    /// </summary>
    public string CarrierID { get; set; }
    /// <summary>
    /// The carriers passwords for credit scoring with a company, or rating through realtime portals. 
    /// Leave blank if there is no value to pass.
    /// </summary>
    public string CarrierPassword { get; set; }
    /// <summary>
    /// The producer code assigned to the carrier for the company. 
    /// Leave this blank if there is no code assigned.
    /// </summary>
    public string ProducerCode { get; set; }
    /// <summary>
    /// The subproducer code assigned to the carrier for the company. 
    /// Leave this blank if there is no code assigned.
    /// </summary>
    public string SubProducerCode { get; set; }
    /// <summary>
    /// The company IDs of the company you wish to return rates for. REQUIRED!
    /// </summary>
    [Range(1, Int64.MaxValue)]
    public Int64 CompanyID { get; set; }
    /// <summary>
    /// The program ID of the company if there is a specific program to rate. -1 Otherwise.
    /// </summary>
    public int ProgramID { get; set; }
    /// <summary>
    /// True/False for allowing ordering of credit.
    /// </summary>
    public bool OrderCreditScore { get; set; }
    /// <summary>
    /// The DOS Company ID of the rates. REQUIRED!
    /// </summary>
    public Int32 DOSCompanyID { get; set; }
    /// <summary>
    /// An agency fee amount to add to the downpayment.
    /// </summary>
    public double AgencyFee { get; set; }
    /// <summary>
    /// Should this product be rated? This is used internally in our Rating API. Clients need not set this value.
    /// </summary>
    internal bool ShouldRate { get; set; }
  }
}
