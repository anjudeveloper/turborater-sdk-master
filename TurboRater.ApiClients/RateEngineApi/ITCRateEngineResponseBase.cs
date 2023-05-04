using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TurboRater;
using TurboRater.ApiClients.RateEngineApi;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A base class for response messages sent back from retrieving rating results from the itc rate engine api.
  /// </summary>
  [XmlInclude(typeof(ITCRateEngineResponse)), XmlInclude(typeof(ITCRateEngineResponseHO2))]
  public class ITCRateEngineResponseBase
  {
    /// <summary>
    /// The realtime 3rd party (carrier) transaction id
    /// </summary>
    public virtual string RTRThirdPartyTransactionID { get; set; }

    /// <summary>
    /// The realtime 3rd party (carrier) quote url
    /// </summary>
    public virtual string RTRThirdPartyQuoteURL { get; set; }

    /// <summary>
    /// This is the auditing TransactionID they send to us. Logged to DB with timestamp, insured name.
    /// </summary>
    public virtual string TransactionID { get; set; }

    /// <summary>
    /// The customerID of the request.
    /// </summary>
    public virtual string CustomerID { get; set; }

    /// <summary>
    /// The ID TBD that identifies the rates for call in and such.
    /// </summary>
    public virtual string PhoneCode { get; set; }

    /// <summary>
    /// The URL for buy now.
    /// </summary>
    public virtual string BuyNowUrl { get; set; }

    /// <summary>
    /// The URL for requesting the agency contact the insured.
    /// </summary>
    public virtual string ContactUrl { get; set; }

    /// <summary>
    /// The URL to the carriers logo. We're going to send them a link.
    /// </summary>
    public virtual string LogoUrl { get; set; }

    /// <summary>
    /// List of fatal errors working with the rating service.
    /// </summary>
    public virtual List<string> FatalErrors { get; set; }

    /// <summary>
    /// The agencyID of the agency that the rates are for.
    /// </summary>
    public virtual Guid AgencyID { get; set; }

    /// <summary>
    /// The name of the agency.
    /// </summary>
    public virtual string AgencyName { get; set; }

    /// <summary>
    /// The line 1 address of the agency.
    /// </summary>
    public virtual string AgencyAddress1 { get; set; }

    /// <summary>
    /// The line 2 address of the agency.
    /// </summary>
    public virtual string AgencyAddress2 { get; set; }

    /// <summary>
    /// The city the agency is in.
    /// </summary>
    public virtual string AgencyCity { get; set; }

    /// <summary>
    /// The state the agency is in.
    /// </summary>
    public virtual USState AgencyState { get; set; }

    /// <summary>
    /// The zipcode for the agency.
    /// </summary>
    public virtual string AgencyZip { get; set; }

    /// <summary>
    /// The agencies phone number.
    /// </summary>
    public virtual string AgencyPhone { get; set; }

    /// <summary>
    /// 60 Character string for marketing line on comparison screen.
    /// </summary>
    public virtual string AgencyMarketingLine { get; set; }

    /// <summary>
    /// The summary items for the agency. The can have a 40 character highlighted line and an 80 character description line.
    /// Up to 4 of these are currently allowed.
    /// </summary>
    public virtual List<SummaryItem> SummaryItems { get; set; }

    /// <summary>
    /// The companyID of the rated company.
    /// </summary>
    public virtual Int64 CompanyID { get; set; }

    /// <summary>
    /// The name of the rated company.
    /// </summary>
    public virtual string CompanyName { get; set; }

    /// <summary>
    /// The programID of this program if there is one. -1 if there is no program.
    /// </summary>
    public virtual int ProgramID { get; set; }

    /// <summary>
    /// The program name if this is for a program.
    /// </summary>
    public virtual string ProgramName { get; set; }

    /// <summary>
    /// The term of the policy.
    /// </summary>
    public virtual int Term { get; set; }

    /// <summary>
    /// The tier for the rates if there is one.
    /// </summary>
    public virtual string Tier { get; set; }

    /// <summary>
    /// The effective date of the policy.
    /// </summary>
    public virtual DateTime EffectiveDate { get; set; }

    /// <summary>
    /// The expiration date of the policy.
    /// </summary>
    public virtual DateTime ExpirationDate { get; set; }

    /// <summary>
    /// The amount of the policy fee.
    /// </summary>
    public virtual double PolicyFee { get; set; }

    /// <summary>
    /// The agency fee. 
    /// </summary>
    public virtual double AgencyFee { get; set; }

    /// <summary>
    /// The total premium of the policy.
    /// </summary>
    public virtual double TotalPremium { get; set; }

    /// <summary>
    /// Indicates if rating has completed for policy.
    /// </summary>
    public virtual bool AllRatingComplete { get; set; }

    /// <summary>
    /// The description of the pay plan.
    /// </summary>
    public virtual string PayPlanDescription { get; set; }

    /// <summary>
    /// The number of payments the pay plan requires.
    /// </summary>
    public virtual int PayPlanNumOfPayments { get; set; }

    /// <summary>
    /// The down payment percentage of the pay plan.
    /// </summary>
    public virtual double PayPlanPercentDown { get; set; }

    /// <summary>
    /// The down payment amount.
    /// </summary>
    public virtual double PayPlanDownPayment { get; set; }

    /// <summary>
    /// The payment amount.
    /// </summary>
    public virtual double PayPlanPaymentAmount { get; set; }

    /// <summary>
    /// The service fee amount.
    /// </summary>
    public virtual double PayPlanServiceFees { get; set; }

    /// <summary>
    /// The total amount of payments.
    /// </summary>
    public virtual double PayPlanPaymentTotal { get; set; }

    /// <summary>
    /// ITC Internal Use Only.
    /// Was this pay plan fully rated? For some realtime modules the company might not rate the pay plan returned to us fully,
    /// but rather just return basic information about the pay plan. If the pay plan described here is fully rated this 
    /// property will be set to true, otherwise false.
    /// </summary>
    public virtual bool PayPlanWasFullyRated { get; set; }

    /// <summary>
    /// Is the pay plan qualified or not?
    /// </summary>
    public virtual bool PayPlanIsQualified { get; set; }

    /// <summary>
    /// The message of the pay plan.
    /// </summary>
    public virtual string PayPlanMessage { get; set; }

    /// <summary>
    /// A list of discount and surcharges that were applied to the policy.
    /// </summary>
    public virtual List<ResponseMessage> DiscountsAndSurcharges { get; set; }

    /// <summary>
    /// Any warnings the apply to the policy.
    /// </summary>
    public virtual List<ResponseMessage> Warnings { get; set; }

    /// <summary>
    /// Any errors the happened while the policy was being rated.
    /// </summary>
    public virtual List<ResponseMessage> Errors { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public ITCRateEngineResponseBase()
    {
    }

    /// <summary>
    /// constructor.
    /// </summary>
    /// <param name="initialize">If true, the initialize method will be called.</param>
    public ITCRateEngineResponseBase(bool initialize = false)
    {
      if (initialize)
        Initialize();
    }

    /// <summary>
    /// Initialize the response with defaulted values.
    /// </summary>
    public virtual void Initialize()
    {
      this.AllRatingComplete = false;
      this.BuyNowUrl = String.Empty;
      this.ContactUrl = String.Empty;
      this.LogoUrl = String.Empty;
      this.PhoneCode = String.Empty;
      this.TransactionID = String.Empty;
      this.CustomerID = String.Empty;
      this.FatalErrors = new List<string>();
      this.AgencyID = ITCConstants.BlankGuid;
      this.AgencyAddress1 = String.Empty;
      this.AgencyAddress2 = String.Empty;
      this.AgencyCity = String.Empty;
      this.AgencyMarketingLine = String.Empty;
      this.AgencyName = String.Empty;
      this.AgencyPhone = String.Empty;
      this.AgencyState = USState.Texas;
      this.AgencyZip = String.Empty;
      this.CompanyID = -1;
      this.CompanyName = String.Empty;
      this.DiscountsAndSurcharges = new List<ResponseMessage>();
      this.EffectiveDate = DateTime.Now;
      this.Term = 6;
      this.Errors = new List<ResponseMessage>();
      this.ExpirationDate = EffectiveDate.AddMonths(this.Term);
      this.FatalErrors = new List<string>();
      this.AgencyFee = 0;
      this.PayPlanDescription = String.Empty;
      this.PayPlanDownPayment = 0;
      this.PayPlanNumOfPayments = 0;
      this.PayPlanPaymentAmount = 0;
      this.PayPlanPaymentTotal = 0;
      this.PayPlanPercentDown = 0;
      this.PayPlanServiceFees = 0;
      this.PayPlanIsQualified = false;
      this.PayPlanMessage = string.Empty;
      this.PolicyFee = 0;
      this.ProgramID = -1;
      this.ProgramName = String.Empty;
      this.SummaryItems = new List<SummaryItem>();
      this.Tier = String.Empty;
      this.TotalPremium = 0;
      this.Warnings = new List<ResponseMessage>();
    }
  }
}
