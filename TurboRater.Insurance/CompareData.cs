using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace TurboRater.Insurance
{
  /// <summary>
  /// status of the rate for this comparison object
  /// </summary>
  public enum ComparisonRateStatus
  {
    /// <summary>
    /// no status
    /// </summary>
    Nothing,

    /// <summary>
    /// warnings on the rate
    /// </summary>
    Warnings,

    /// <summary>
    /// it's still rating
    /// </summary>
    Rating,

    /// <summary>
    /// it has werrors
    /// </summary>
    Errors
  }

  /// <summary>
  /// Defines different modes for Caesar rating.
  /// </summary>
  public enum CaesarRateMode
  {
    /// <summary>
    /// Rating mode, goes all the way to the end and uploads the premium to TWE.
    /// </summary>
    [Description("Rate")]
    Rate,
    /// <summary>
    /// For bridging only, goes to the end but does not close the Caesar client, nor does it upload anything.
    /// </summary>
    [Description("Write")]
    Write
  }

  /// <summary>
  /// Base compare data object
  /// Holds the info that would be common to any type of policy
  /// </summary>
  [Serializable]
  public class CompareData
  {
    private int m_companyID = ITCConstants.InvalidNum;
    private int m_rateRevision = ITCConstants.InvalidNum;
    private int m_programID = ITCConstants.InvalidNum;
    private int m_pfProgramID = ITCConstants.InvalidNum;
    private int m_payPlanID = ITCConstants.InvalidNum;
    private bool m_defaultPayPlan;
    private bool m_independentlyFinanced;
    private bool m_flexBandCompany;
    private int m_financeCompanyID = ITCConstants.InvalidNum;
    private int m_financePFProgramID = ITCConstants.InvalidNum;
    private int m_financePayPlanID = ITCConstants.InvalidNum;
    private string m_companyName = "";
    private string m_naicCode = "";
    private DateTime m_rateEffectiveDate = ITCConstants.InvalidDate;
    private double m_commissionPercent;
    private double m_commissionPremium;
    private MessageList m_warnings = new MessageList();
    private MessageList m_errors = new MessageList();
    private bool m_selected;
    private bool m_financeQualified;
    private double m_financeCharge;
    private bool m_payPlanProtected;
    private double m_downPayment;
    private int m_numOfPayments;
    private double m_paymentAmount;
    private double m_paymentTotal;
    private double m_percentDown = 100.0;
    private int m_policyTerm = 6;
    private int m_originalTerm;
    private double m_premiumBeforeTermEstimation;
    private double m_totalPremium;
    private string m_tt2Data = "";
    private ComparisonRateStatus m_status = ComparisonRateStatus.Rating;
    private string m_programName = "";
    private int m_productID = ITCConstants.InvalidNum;
    private bool m_isRealtime;
    private bool m_isDotNetManufactured;
    private string m_termString = "";
    private string m_producerCode = "";
    private string m_companyCode = string.Empty;
    private RateOption m_rateOption = RateOption.Full;
    private bool m_isCreditRequired;
    private double m_policyFee;
    private List<ComparisonCar> m_comparisonCars = new List<ComparisonCar>();
    private double m_financeAmount;
    private string m_thirdPartyTransactionId = "";
    private string m_payPlanDescription = "";
    private string m_tierName = "";
    private double m_serviceFeePerPayment;
    private double m_totalServiceFee;
    private bool m_isClientSideRatingOnly;
    private bool m_hasClientSideRatingBeenInitiated;
    private bool m_hasClientSideRatingBeenUpdated;
    private CaesarMode m_caesarMode = CaesarMode.Normal;
    private double m_sR22Fee;
    private double m_atpaFee;
    private double m_fR44Fee;
    private MessageList m_secondaryWarnings = new MessageList();
    private string m_secondaryProducerCode = string.Empty;
    private string m_secondaryCompanyCode = string.Empty;
    private int m_secondaryProductID = ITCConstants.InvalidNum;
    private string m_agencyName = string.Empty;
    private string m_agencyAddress = string.Empty;
    private string m_agencyCity = string.Empty;
    private USState m_agencyState = USState.NoneSelected;
    private string m_agencyZip = string.Empty;
    private int m_rankByTotalPremium = ITCConstants.InvalidNum;
    private int m_rankByDownPayment = ITCConstants.InvalidNum;
    private double m_differencePercentage1 = ITCConstants.InvalidNum;
    private double m_differencePercentage2 = ITCConstants.InvalidNum;
    private double m_differencePercentage3 = ITCConstants.InvalidNum;
    private int m_totalComparisons;
    private List<ComparisonDriver> m_comparisonDrivers = new List<ComparisonDriver>();
    private RTRCreditOrderStatus m_rTRThirdPartyCreditOrderStatus = RTRCreditOrderStatus.NoDataReceived;
    private int m_companyRanking = ITCConstants.InvalidNum;
    private string m_companyRankString = string.Empty;
    private int m_programRecordID = ITCConstants.InvalidNum;
    private double m_FHCFEmergencyAssessmentSurcharge;
    private double m_programRebate;
    private Guid? m_agencyId = Guid.Empty;

    /// <summary>
    /// Double comparison that shifts 0 values to the bottom of the list.
    /// </summary>
    /// <param name="value1">first value for comparison.</param>
    /// <param name="value2">second value for comparison.</param>
    protected static int DoubleComparison(double value1, double value2)
    {
      value1 = value1 <= 0 ? Double.MaxValue : value1;
      value2 = value2 <= 0 ? Double.MaxValue : value2;
      return value1.CompareTo(value2);
    }

    /// <summary>
    /// ITC CompanyID of the company rated
    /// </summary>
    public int CompanyID
    {
      get { return m_companyID; }
      set { m_companyID = value; }
    }

    /// <summary>
    /// Rate revision of the company rated
    /// </summary>
    public int RateRevision
    {
      get { return m_rateRevision; }
      set { m_rateRevision = value; }
    }

    /// <summary>
    /// Program ID of the company rated
    /// </summary>
    public int ProgramID
    {
      get { return m_programID; }
      set { m_programID = value; }
    }

    /// <summary>
    /// premium finance program id
    /// </summary>
    public int PFProgramID
    {
      get { return m_pfProgramID; }
      set { m_pfProgramID = value; }
    }

    /// <summary>
    /// pay plan id
    /// </summary>
    public int PayPlanID
    {
      get { return m_payPlanID; }
      set { m_payPlanID = value; }
    }

    /// <summary>
    /// is this the default pay plan?
    /// </summary>
    public bool DefaultPayPlan
    {
      get { return m_defaultPayPlan; }
      set { m_defaultPayPlan = value; }
    }

    /// <summary>
    /// is this independently financed?
    /// </summary>
    public bool IndependentlyFinanced
    {
      get { return m_independentlyFinanced; }
      set { m_independentlyFinanced = value; }
    }

    /// <summary>
    /// does this represent a flex band company
    /// </summary>
    public bool FlexBandCompany
    {
      get { return m_flexBandCompany; }
      set { m_flexBandCompany = value; }
    }

    /// <summary>
    /// company id of the finance company chosen
    /// </summary>
    public int FinanceCompanyID
    {
      get { return m_financeCompanyID; }
      set { m_financeCompanyID = value; }
    }

    /// <summary>
    /// program id of the premium finance program chosen
    /// </summary>
    public int FinancePFProgramID
    {
      get { return m_financePFProgramID; }
      set { m_financePFProgramID = value; }
    }

    /// <summary>
    /// pay plan id of the finance pay plan chosen
    /// </summary>
    public int FinancePayPlanID
    {
      get { return m_financePayPlanID; }
      set { m_financePayPlanID = value; }
    }

    /// <summary>
    /// name of the company this represents
    /// </summary>
    public string CompanyName
    {
      get { return m_companyName; }
      set { m_companyName = value; }
    }

    /// <summary>
    /// naic company code
    /// </summary>
    public string NAICCode
    {
      get { return m_naicCode; }
      set { m_naicCode = value; }
    }

    /// <summary>
    /// effective date of the rates
    /// </summary>
    public DateTime RateEffectiveDate
    {
      get { return m_rateEffectiveDate; }
      set { m_rateEffectiveDate = value; }
    }

    /// <summary>
    /// a spiffily-formatted string representing the effective date of the rates
    /// </summary>
    public string RateEffectiveDateString
    {
      get
      {
        if (((m_isRealtime) && (!m_isDotNetManufactured)) || (m_rateEffectiveDate == ITCConstants.InvalidDate))
          return "";
        else
          return String.Format("{0:d}", m_rateEffectiveDate);
      }
    }

    /// <summary>
    /// percent of agent's commission
    /// </summary>
    public double CommissionPercent
    {
      get { return m_commissionPercent; }
      set { m_commissionPercent = value; }
    }

    /// <summary>
    /// amount of agent's commission, i think
    /// </summary>
    public double CommissionPremium
    {
      get { return m_commissionPremium; }
      set { m_commissionPremium = value; }
    }

    /// <summary>
    /// policy down payment amount
    /// </summary>
    public double DownPayment
    {
      get { return m_downPayment; }
      set { m_downPayment = value; }
    }

    /// <summary>
    /// number of payments
    /// </summary>
    public int NumOfPayments
    {
      get { return m_numOfPayments; }
      set { m_numOfPayments = value; }
    }

    /// <summary>
    /// amount of each payment
    /// </summary>
    public double PaymentAmount
    {
      get { return m_paymentAmount; }
      set { m_paymentAmount = value; }
    }

    /// <summary>
    /// total amount of all payments
    /// </summary>
    public double PaymentTotal
    {
      get { return m_paymentTotal; }
      set { m_paymentTotal = value; }
    }

    /// <summary>
    /// percent down
    /// </summary>
    public double PercentDown
    {
      get { return m_percentDown; }
      set { m_percentDown = value; }
    }

    /// <summary>
    /// policy term, in months
    /// </summary>
    public int PolicyTerm
    {
      get { return m_policyTerm; }
      set { m_policyTerm = value; }
    }

    /// <summary>
    /// policy term, in months. Note that this
    /// is the original, user-entered term. If 0 then
    /// the request came from the desktop or 
    /// term bumping was not used. If non-0 value,
    /// then term bumping was used. This field
    /// is only used to determine if term bumping was
    /// used on the client-side.
    /// </summary>
    public int OriginalTerm
    {
      get { return m_originalTerm; }
      set { m_originalTerm = value; }
    }

    /// <summary>
    /// policy premium. Note that this
    /// is the original, pre-term-estimation premium. This
    /// field is used by market basket. This field will
    /// only be set if term estimation was used.
    /// </summary>
    public double PremiumBeforeTermEstimation
    {
      get { return m_premiumBeforeTermEstimation; }
      set { m_premiumBeforeTermEstimation = value; }
    }

    /// <summary>
    /// total premium amount of the policy
    /// </summary>
    public double TotalPremium
    {
      get { return m_totalPremium; }
      set { m_totalPremium = value; }
    }

    /// <summary>
    /// rating warnings on the policy
    /// </summary>
    public MessageList Warnings
    {
      get { return m_warnings; }
      set { m_warnings = value; }
    }

    /// <summary>
    /// rating errors on the policy
    /// </summary>
    public MessageList Errors
    {
      get { return m_errors; }
      set { m_errors = value; }
    }

    /// <summary>
    /// was this item selected by the user?
    /// </summary>
    public bool Selected
    {
      get { return m_selected; }
      set { m_selected = value; }
    }

    /// <summary>
    /// is this policy qualified for financing?
    /// </summary>
    public bool FinanceQualified
    {
      get { return m_financeQualified; }
      set { m_financeQualified = value; }
    }

    /// <summary>
    /// finance charge
    /// </summary>
    public double FinanceCharge
    {
      get { return m_financeCharge; }
      set { m_financeCharge = value; }
    }

    /// <summary>
    /// is this pay plan protected?
    /// </summary>
    public bool PayPlanProtected
    {
      get { return m_payPlanProtected; }
      set { m_payPlanProtected = value; }
    }

    /// <summary>
    /// rating data, in tt2 form
    /// </summary>
    public string TT2Data
    {
      get { return m_tt2Data; }
      set { m_tt2Data = value; }
    }

    /// <summary>
    /// status of this comparison rate
    /// </summary>
    public ComparisonRateStatus Status
    {
      get { return m_status; }
      set { m_status = value; }
    }

    /// <summary>
    /// name of the rating program
    /// </summary>
    public string ProgramName
    {
      get { return m_programName; }
      set { m_programName = value; }
    }

    /// <summary>
    /// product id rated
    /// </summary>
    public int ProductID
    {
      get { return m_productID; }
      set { m_productID = value; }
    }

    /// <summary>
    /// is this a real-time product?
    /// </summary>
    public bool IsRealtime
    {
      get { return m_isRealtime; }
      set { m_isRealtime = value; }
    }

    /// <summary>
    /// is this a .net manufactured product?
    /// </summary>
    public bool IsDotNetManufactured
    {
      get { return m_isDotNetManufactured; }
      set { m_isDotNetManufactured = value; }
    }

    /// <summary>
    /// string representing the term chosen
    /// </summary>
    public string TermString
    {
      get { return m_termString; }
      set { m_termString = value; }
    }

    /// <summary>
    /// producer code of the rating agent for the rated product
    /// </summary>
    public string ProducerCode
    {
      get { return m_producerCode; }
      set { m_producerCode = value; }
    }

    /// <summary>
    /// company code (sub-code) of the rating agent 
    /// for the rated product
    /// </summary>
    public string CompanyCode
    {
      get { return m_companyCode; }
      set { m_companyCode = value; }
    }

    /// <summary>
    /// rating option that the user chose for this product (full, assumed, don't rate)
    /// note: this is only marked as a stored property so that tt2 import will work properly. (due to it being an enum)
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 25, EnumerationType = typeof(RateOption), IsSaveable = false, IsLoadable = false)]
    public RateOption RateOption
    {
      get { return m_rateOption; }
      set { m_rateOption = value; }
    }

    /// <summary>
    /// Is credit required for the product/program represented? Currently used
    /// by market basket only (June 2010). Note that this is looked up by the
    /// intermediate MB service; it's not set properly within the TWE interface
    /// and we don't expect it to be.
    /// </summary>
    public bool IsCreditRequired
    {
      get { return m_isCreditRequired; }
      set { m_isCreditRequired = value; }
    }

    /// <summary>
    /// policy fee associated with this rate
    /// </summary>
    public double PolicyFee
    {
      get { return m_policyFee; }
      set { m_policyFee = value; }
    }

    /// <summary>
    /// vehicle premiums+limits+deductibles associated with this rate
    /// </summary>
    public List<ComparisonCar> ComparisonCars
    {
      get { return m_comparisonCars; }
      set { m_comparisonCars = value; }
    }

    /// <summary>
    /// Additional driver attributes stored with each comparison.
    /// </summary>
    public List<ComparisonDriver> ComparisonDrivers
    {
      get { return m_comparisonDrivers; }
      set { m_comparisonDrivers = value; }
    }

    /// <summary>
    /// amount being financed
    /// </summary>
    public double FinanceAmount
    {
      get { return m_financeAmount; }
      set { m_financeAmount = value; }
    }

    /// <summary>
    /// assuming the carrier has a transaction id that they want us to use, this is it. mostly
    /// 
    /// </summary>
    public string ThirdPartyTransactionId
    {
      get { return m_thirdPartyTransactionId; }
      set { m_thirdPartyTransactionId = value; }
    }

    /// <summary>
    /// Description of the pay plan rated for this item
    /// </summary>
    public string PayPlanDescription
    {
      get { return m_payPlanDescription; }
      set { m_payPlanDescription = value; }
    }

    /// <summary>
    /// name of the rating tier
    /// </summary>
    public string TierName
    {
      get { return m_tierName; }
      set { m_tierName = value; }
    }

    /// <summary>
    /// pay plan installment/service fee, per payment
    /// </summary>
    public double ServiceFeePerPayment
    {
      get { return m_serviceFeePerPayment; }
      set { m_serviceFeePerPayment = value; }
    }

    /// <summary>
    /// pay plan installment/service fee total (sum of all payments)
    /// </summary>
    public double TotalServiceFee
    {
      get { return m_totalServiceFee; }
      set { m_totalServiceFee = value; }
    }

    /// <summary>
    /// is this product a client-side-rating only product? these products rate through caesar
    /// </summary>
    public bool IsClientSideRatingOnly
    {
      get { return m_isClientSideRatingOnly; }
      set { m_isClientSideRatingOnly = value; }
    }

    /// <summary>
    /// Has the user begun the client-side rating process? meaning, they clicked the "bridge to rate" link
    /// </summary>
    public bool HasClientSideRatingBeenInitiated
    {
      get { return m_hasClientSideRatingBeenInitiated; }
      set { m_hasClientSideRatingBeenInitiated = value; }
    }

    /// <summary>
    /// Has the user pulled in the caesar rates from the client?
    /// </summary>
    public bool HasClientSideRatingBeenUpdated
    {
      get { return m_hasClientSideRatingBeenUpdated; }
      set { m_hasClientSideRatingBeenUpdated = value; }
    }

    /// <summary>
    /// Indicates the type of client-side rating that will be done.
    /// </summary>
    public CaesarMode CaesarMode
    {
      get { return m_caesarMode; }
      set { m_caesarMode = value; }
    }

    /// <summary>
    /// total sr22 fee applied on the policy. note that this would also include fees incurred from an sr-22a. 
    /// yes this is auto-specific, but AUCompareData is defined down in TWE and the
    /// mb intermediate service only accepts an object of type CompareData. 
    /// </summary>
    public double SR22Fee
    {
      get { return m_sR22Fee; }
      set { m_sR22Fee = value; }
    }

    /// <summary>
    /// Total atpa fee applied on the policy. 
    /// yes this is auto-specific, but AUCompareData is defined down in TWE and the
    /// mb intermediate service only accepts an object of type CompareData. 
    /// </summary>
    public double ATPAFee
    {
      get { return m_atpaFee; }
      set { m_atpaFee = value; }
    }

    /// <summary>
    /// total fr44 fee applied on the policy. 
    /// yes this is auto-specific, but AUCompareData is defined down in TWE and the
    /// mb intermediate service only accepts an object of type CompareData. 
    /// </summary>
    public double FR44Fee
    {
      get { return m_fR44Fee; }
      set { m_fR44Fee = value; }
    }

    /// <summary>
    /// Rating warnings on the secondary policy.
    /// </summary>
    public MessageList SecondaryWarnings
    {
      get { return m_secondaryWarnings; }
      set { m_secondaryWarnings = value; }
    }

    /// <summary>
    /// Producer code of the rating agent for the rated product for the secondary company.
    /// </summary>
    public string SecondaryProducerCode
    {
      get { return m_secondaryProducerCode; }
      set { m_secondaryProducerCode = value; }
    }

    /// <summary>
    /// Company code (sub-code) of the rating agent for the rated product for the secondary company.
    /// </summary>
    public string SecondaryCompanyCode
    {
      get { return m_secondaryCompanyCode; }
      set { m_secondaryCompanyCode = value; }
    }

    /// <summary>
    /// Product ID of the rated product for the secondary company.
    /// </summary>
    public int SecondaryProductID
    {
      get { return m_secondaryProductID; }
      set { m_secondaryProductID = value; }
    }

    /// <summary>
    /// Agency name stored for Market Basket.
    /// </summary>
    public string AgencyName
    {
      get { return m_agencyName; }
      set { m_agencyName = value; }
    }

    /// <summary>
    /// Agency address stored for Market Basket.
    /// </summary>
    public string AgencyAddress
    {
      get { return m_agencyAddress; }
      set { m_agencyAddress = value; }
    }

    /// <summary>
    /// Agency city stored for Market Basket.
    /// </summary>
    public string AgencyCity
    {
      get { return m_agencyCity; }
      set { m_agencyCity = value; }
    }

    /// <summary>
    /// Agency state stored for Market Basket.
    /// </summary>
    public USState AgencyState
    {
      get { return m_agencyState; }
      set { m_agencyState = value; }
    }

    /// <summary>
    /// Agency zip stored for Market Basket.
    /// </summary>
    public string AgencyZip
    {
      get { return m_agencyZip; }
      set { m_agencyZip = value; }
    }

    /// <summary>
    /// The rank of this comparison item sorted by total premium.
    /// </summary>
    public int RankByTotalPremium
    {
      get { return m_rankByTotalPremium; }
      set { m_rankByTotalPremium = value; }
    }

    /// <summary>
    /// The rank of this comparison item sorted by down payment.
    /// </summary>
    public int RankByDownPayment
    {
      get { return m_rankByDownPayment; }
      set { m_rankByDownPayment = value; }
    }

    /// <summary>
    /// The percentage difference of this item compared to the lowest.
    /// </summary>
    public double DifferencePercentage1
    {
      get { return m_differencePercentage1; }
      set { m_differencePercentage1 = value; }
    }

    /// <summary>
    /// The percentage difference of this item compared to the second lowest.
    /// </summary>
    public double DifferencePercentage2
    {
      get { return m_differencePercentage2; }
      set { m_differencePercentage2 = value; }
    }

    /// <summary>
    /// The percentage difference of this item compared to the third lowest.
    /// </summary>
    public double DifferencePercentage3
    {
      get { return m_differencePercentage3; }
      set { m_differencePercentage3 = value; }
    }

    /// <summary>
    /// The total number of comparisons included in the rankings.
    /// </summary>
    public int TotalComparisons
    {
      get { return m_totalComparisons; }
      set { m_totalComparisons = value; }
    }

    /// <summary>
    /// Real-Time Rating, whether the carrier ordered credit on their end or not.  Defaults to NoDataReceived.
    /// </summary>
    public RTRCreditOrderStatus RTRThirdPartyCreditOrderStatus
    {
      get { return m_rTRThirdPartyCreditOrderStatus; }
      set { m_rTRThirdPartyCreditOrderStatus = value; }
    }

    /// <summary>
    /// Company ranking number for sorting.
    /// </summary>
    public int CompanyRanking
    {
      get { return m_companyRanking; }
      set { m_companyRanking = value; }
    }

    /// <summary>
    /// String to display for company ranking.
    /// </summary>
    public string CompanyRankString
    {
      get { return m_companyRankString; }
      set { m_companyRankString = value; }
    }

    /// <summary>
    /// Program Record ID so program can be pulled up by ID it is stored in the database with.
    /// </summary>
    public int ProgramRecordID
    {
      get { return m_programRecordID; }
      set { m_programRecordID = value; }
    }

    /// <summary>
    /// Florida Hurricane Catastrophe Fund.
    /// </summary>
    public double FHCFEmergencyAssessmentSurcharge
    {
      get { return m_FHCFEmergencyAssessmentSurcharge; }
      set { m_FHCFEmergencyAssessmentSurcharge = value; }
    }

    /// <summary>
    /// Program rebate.
    /// </summary>
    public double ProgramRebate
    {
      get { return m_programRebate; }
      set { m_programRebate = value; }
    }

    /// <summary>
    /// Agencyid of this comparison rate. Normally this will either not be set, or it will be set to the same GUID
    /// as the Insured's AgencyGUID value. However for rate service things like gelato where a single policy
    /// can be rated with multiple agencies+carriers, we need to set this value at the compare level so we know
    /// which agency each comparison item is rated with
    /// </summary>
    public Guid? AgencyId
    {
      get { return m_agencyId; }
      set { m_agencyId = value; }
    }

    /// <summary>
    /// default constructor
    /// </summary>
    public CompareData()
    {
    }
  }
}
