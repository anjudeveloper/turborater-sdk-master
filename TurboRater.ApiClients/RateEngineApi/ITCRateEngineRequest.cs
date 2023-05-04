using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TurboRater.Insurance;
using TurboRater.Insurance.AU;
using TurboRater.Insurance.DataTransformation;
using TurboRater.Insurance.HO;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A rating request sent to the rating API
  /// </summary>
  [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/ITC.WebApiClients.RateEngineApi")]
  public class ITCRateEngineRequest
  {
    #region Public
    //Account Fields
    #region AccountFields
    /// <summary>
    /// The account name provided by ITC for accessing the rating service.
    /// </summary>
    [Required]
    public string AccountName { get; set; }
    /// <summary>
    /// The account number provided by ITC for accessing the rating service.
    /// </summary>
    [Required]
    public string AccountNumber { get; set; }
    /// <summary>
    /// The access ID provided by ITC for accessing the rating service.
    /// </summary>
    [Required]
    public string AccessID { get; set; }
    /// <summary>
    /// The realtime account number provided by ITC for accessing the realtime rating server.
    /// </summary>
    public string RealTimeAccountNumber { get; set; }
    #endregion AccountFields

    //Common Fields
    #region CommonFields
    /// <summary>
    /// Test flag for transactions. 
    /// </summary>
    public Boolean Test { get; set; }
    /// <summary>
    /// This is used to track a transaction count.They supply this value! 20 ops/single insured/24 hours
    /// Make sure we underwrite that this is set!
    /// </summary>
    [Required]
    public string TransactionID { get; set; }
    /// <summary>
    /// This is a unique token to associate the transaction with the customer. This is a required field.
    /// </summary>
    [Required]
    public string CustomerID { get; set; }
    /// <summary>
    /// The insured's first name.
    /// </summary>
    public string InsuredFirstName { get; set; }
    /// <summary>
    /// The insured's middle name.
    /// </summary>
    public string InsuredMiddleName { get; set; }
    /// <summary>
    /// The insured's last name.
    /// </summary>
    public string InsuredLastName { get; set; }
    #endregion CommonFields

    //Control Fields
    #region ControlFields
    /// <summary>
    /// The state abbreviation for the state rated. Example: "TX"
    /// </summary>
    [Required]
    [StringLength(2, MinimumLength = 2)]
    public string RateState { get; set; }
    /// <summary>
    /// The line of insurance the rates are for. PersonalAuto, HomeOwners, etc.
    /// </summary>
    public InsuranceLine? LineOfInsurance { get; set; }
    /// <summary>
    /// This control tag sets how you wish to have limits and deductibles "bumped" from what is requested to what a company will support.
    /// </summary>
    [Required]
    public RateEngineBumpingEnum? BumpLimits { get; set; }
    /// <summary>
    /// This is a True/False value that controls whether a supported closest term is returned if the company does not support the requested
    /// term, or an error is returned instead.
    /// </summary>
    public bool EstimateTerm { get; set; }

    /// <summary>
    /// If true, the producer code, sub-producer code, user name and password are used from the request, not from the
    /// agency table.
    /// </summary>
    public bool UseRequestCredentials { get; set; }

    /// <summary>
    /// If true, the producer code, sub-producer code, user name and password are used from the request, 
    /// avoids the company groups entirely.
    /// </summary>
    public bool UseExactCarrierInfo { get; set; }

    /// <summary>
    /// If set to true, the rating method will only return an HTTP response when
    /// it has finished processing all requested rates.
    /// </summary>
    public bool OnlyRespondWhenFinished { get; set; }

    #endregion ControlFields

    //Policy Data
    #region PolicyData
    /// <summary>
    /// The policy data in string format. Either TT2 or Accord XML. 
    /// </summary>
    [Required]
    public string PolicyData { get; set; }

    /// <summary>
    /// Takes the policy data sent in, which is a string of some sort, and converts it to an ITC Policy object.
    /// </summary>
    /// <returns>The deserialized policy, or null if the line of insurance is not supported.</returns>
    public InsPolicy GetPolicy()
    {
      if (String.IsNullOrWhiteSpace(PolicyData))
        return null;
      switch (LineOfInsurance)
      {
        case InsuranceLine.PersonalAuto:
        case InsuranceLine.Motorcycle:
          return TransformationHelper.DeserializePolicy<AUPolicy>(PolicyData);
        case InsuranceLine.Homeowners:
        case InsuranceLine.DwellingFire:
          return TransformationHelper.DeserializePolicy<HOPolicy>(PolicyData);
        default:
          return null;
      }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public ITCRateEngineRequest()
    {
      this.CarrierInformation = new List<CarrierInfo>();
    }
    #endregion PolicyData

    //CarrierInfo
    #region CarrierInfo
    /// <summary>
    /// The list of CarrierInfo objects.
    /// </summary>
    public List<CarrierInfo> CarrierInformation { get; set; }
    #endregion CarrierInfo
    #endregion Public
  }
}
