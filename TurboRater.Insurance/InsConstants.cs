using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TurboRater.Insurance
{
  /// <summary>
  /// Some companies can rate with an assumed credit level. For those that can, these are the valid values.
  /// </summary>
  public enum AssumedCreditLevel
  {
    Best = 1,
    Average = 2,
    Worst = 3,
    NoHit = 4,
    NoScore = 5
  }

  /// <summary>
  /// Which product generated the current policy? web cmp, win cmp, eturborater, etc
  /// </summary>
  public enum SourceProduct
  {
    WindowsComparative,
    WebComparative,
    eTurboRater,  //consumer rater
    ThirdPartyRater, //3rd party rater using our rate engine api
    StressTest,
    InsuranceWebsiteBuilder,
    AgencyBuzz,
    InsurancePro,
  }

  /// <summary>
  /// coverage exclusion codes used for combined coverage
  /// </summary>
  public enum ExclusionCodes
  {
    None,
    PAPDRestricted,
    PALiabilityRestricted
  }

  /// <summary>
  /// the status of undisclosed driver
  /// </summary>
  public enum UDDStatus
  {
    NotOrdered,
    Ordered,
    NoneFound,
    Failed,
    NotApplicable
  }

  /// <summary>
  /// the status of clue reporting
  /// </summary>
  public enum CLUEStatus
  {
    CompleteWResults,
    CompleteClear,
    ProductUnavailable,
    InvalidAccount,
    InsufficientData,
    StateLimitation,
    Errors,
    NotOrdered,
    NotApplicable
  }

  /// <summary>
  /// the valid status types for MVRStatus
  /// </summary>
  public enum MVRStatus
  {
    Clear,
    Hit,
    NoHit,
    InvalidOrder,
    PendingMVR,
    ActivityFileClear,
    SoundexReject,
    UnreturnedMVR,
    NotYetOrdered,
    NotApplicable
  }

  /// <summary>
  /// the valid status types for HOVStatus
  /// </summary>
  public enum HOVStatus
  {
    NotAvailable,
    AddressFound,
    Match,
    Probable,
    NoMatch,
    NotOrdered,
    AccountInvalid,
    InsufficientData,
    NotApplicable
  }

  /// <summary>
  /// The valid status types for CurrentCarrierStatus
  /// </summary>
  public enum CurrentCarrierStatus
  {
    RecordFound,
    RecordFoundSecondaryReport,
    NoRecordFound,
    NoRecordFoundSecondaryReport,
    InvalidAccount,
    InsufficientData,
    CCUnavailable,
    AccessNotPermitted,
    StateNotAvailable,
    NotOrdered,
    NotApplicable
  }

  /// <summary>
  /// The valid status types for whether or not a real time carrier ordered credit on their end.
  /// </summary>
  public enum RTRCreditOrderStatus
  {
    NoDataReceived,
    Ordered,
    NotOrdered
  }

  /// <summary>
  /// The types of coverage that can be placed on a policy.
  /// </summary>
  public enum CoverageType
  {
    Liab,
    LiabBI,
    LiabPD,
    LimitedLiabPD,
    MedPay,
    ExtraMed,
    PPI,
    GuestPIP,
    BuyBackPIP,
    WaivedPIP,
    OutStatePIP,
    FullAddtlPIP,
    PIP,
    Unins,
    UninsBI,
    UninsPD,
    UIM,
    UIMBI,
    UIMPD,
    SUM,
    IncLoss,
    AccDeath,
    Funeral,
    CombFirstParty,
    OBEL,
    Mexico,
    Comp,
    Coll,
    LienHolder,
    Towing,
    Rental,
    Equipment,
    WorkLoss,
    MedExpense,
    Medicare,
    Gap,
    FullGlass,
    TripInterruption,
    ReplacementCost,
    TransportTrailer,
    Tort,
    LimitedColl,
    OptionalBI,
    LegalExpense,
    MedicalExpenseOnly,
    ExtendedMedical,
    SpousalLiability,
		PIPAttendantCareOption
	}

	/// <summary>
	/// Do we bump limits up, down, or none?
	/// </summary>
	public enum BumpLimits
  {
    Up,
    Down,
    NoBump
  }

  /// <summary>
  /// Denotes the type of residence. Mailing address, insured property, etc.
  /// </summary>
  public enum TypeOfResidence
  {
    MailingAddress,
    InsuredProperty,
    Other
  }

  /// <summary>
  /// The scope type of an item such as a message or company question.
  /// </summary>
  public enum ItemScope
  {
    [Description("pol")] Policy,
    [Description("drv")] Driver,
    [Description("car")] Car,
    [Description("vio")] Violation,
    [Description("ppl")] PayPlan,
    [Description("exc")] Exclusion,
    [Description("sys")] System,
    [Description("rec")] Record,
    [Description("mpr")] MisPremium,
    [Description("quo")] Quote,
    [Description("ins")] Insured,
    [Description("not")] Notes,
    [Description("adr")] Address,
    [Description("com")] Comparison,
    [Description("hom")] Home,
    [Description("sus")] Suspension,
    [Description("lod")] ListOnlyDriver,
    [Description("rnb")] CarrierReasonNotBound,
    [Description("dct")] Discount,
    [Description("oti")] OtherInsured
  }

	/// <summary>
	/// The type of a company question
	/// </summary>
	public enum QuestionType
  {
    String,
    Numeric,
    FloatingPoint,
    Boolean,
    DropDownList,
    Date
  }

  /// <summary>
  /// The category of a company question (company data, non-stored data, or company module contents)
  /// </summary>
  public enum CompanyQuestionCategory
  {
    CompanyData,
    NonStoredData,
    CompanyModuleContents
  }

  /// <summary>
  /// Used by the Message class to denote the type of message
  /// </summary>
  public enum TypeOfMessage
  {
    Warning,
    Error,
    Discount,
    Surcharge,
    CoSurchargeFee
  }

  /// <summary>
  /// Roofing classes for property policies
  /// </summary>
  public enum TypeOfRoofCovering
  {
    None,
    Class1,
    Class2,
    Class3,
    Class4
  }

  /// <summary>
  /// Dwelling use types for property policies
  /// </summary>
  public enum DwellingUse
  {
    Dwelling,
    Apartment,
    Other,
    Townhouse,
    Condo,
    Duplex,
    Triplex
  }

  /// <summary>
  /// A line of insurance
  /// </summary>
  public enum InsuranceLine
  {
    [Description("Dwelling Fire")] DwellingFire,
    [Description("Homeowners")] Homeowners,
    [Description("Personal Auto")] PersonalAuto,
    [Description("Commercial Auto")] CommercialAuto,
    [Description("Flood")] Flood,
    [Description("Umbrella")] Umbrella,
    [Description("Wind Only")] FLCommWind,
    [Description("Multiperil")] FLCommProp,

    [Description("Multiple Lines")] // this one is mostly just used for transaction logging
    MultipleLines,
    [Description("Motorcycle")] Motorcycle
  }

  /// <summary>
  /// how is the item used? mostly this is for vehicles
  /// </summary>
  public enum UsageType
  {
    Primary,
    Secondary
  }

  /// <summary>
  /// Standard message types used for discounts, warnings, surcharges and errors
  /// </summary>
  public enum StandardMessage
  {
    NoStandardCode,
    DiscountRoofCovering,
    DiscountSprinklerCertificate,
    DiscountDryHydrants,
    DiscountStoveTopFire,
    DiscountMultiCar,
    DiscountPaidInFull,
    DiscountHomeowner,
    ErrorInvalidDeductible1,
    ErrorInvalidDeductible2,
    ErrorInvalidDeductible3,
    ErrorInvalidRatingTier,
    ErrorInvalidPolicyForm,
    ErrorInvalidConstruction,
    ErrorInvalidOccupancy,
    ErrorInvalidDwellingUse,
    ErrorInvalidTerritory,
    ErrorInvalidProtectionClass,
    ErrorInvalidLiabilityLimit,
    ErrorInvalidMedPayLimit,
    ErrorInvalidYearOfConstruction,
    ErrorInvalidRoofClass,
    ErrorInvalidStovetopFire,
    ErrorInvalidDeductibleForDwellingAmt,
    ErrorInvalidDeductibleForContentsAmt,
    WarningProtectionClass10,
    WarningMinPremium,
    ErrorInsuredAddressRequired,
    ErrorInsuredCityRequired,
    ErrorInsuredZipRequired,
    ErrorGaragingAddrRequired,
    ErrorGaragingCityRequired,
    ErrorGaragingZipRequired,
    ErrorVINRequired,
    ErrorDateLicensedRequired,
    ErrorDriversLicenseRequired,
    ErrorProducerCodeRequired,
    ErrorPriorExpirationRequired,
    ErrorPriorCarrierRequired,
    ErrorDOBRequired,
    ErrorInsuredFirstNameRequired,
    ErrorInsuredLastNameRequired,
    ErrorFirstNameRequired,
    ErrorLastNameRequired,
    ErrorNonOwnerNotAllowed,
    WarningInvalidTermAnnual,
    WarningInvalidTermMonthly,
    WarningInvalidTermQuarterly,
    WarningInvalidSemiAnnual,
    WarningPolicyFeesUndisclosed,
    ErrorUnknownError,
    SurchargeSR22,
    SurchargeVehicleUse,
    ErrorExclusionDOBRequired,
    ErrorNoRealTimeWithoutCredit,
    ErrorNoDailyTerm,
    WarningInvalidTermTwoMonth
  }

  /// <summary>
  /// What country is the person from? note that this is a rather
  /// incomplete list, as this is all the accuracy necessary for 
  /// an accurate insurance rate
  /// </summary>
  public enum CountryOfOrigin
  {
    None,
    International,
    Canada,
    Mexico,
    Poland,
    Matricula,
    Other
  }

  public enum MotorClub
  {
    [Description("None")]
    None,
    [Description("AAA Basic")]
    AAABasic,
    [Description("AAA Plus")]
    AAAPlus,
    [Description("Other")]
    Other
  }

  /// <summary>
  /// These are the three actions that can be applied to a particular property item in a quote template. 
  /// </summary>
  public enum QuoteTemplateAction
  {
    [Description("Show")]
    Show,
    [Description("Show as Blank and Required")]
    BlankAndRequired,
    [Description("Hide")]
    Hide
  }

  /// <summary>
  /// This is a list of all the fields that can be customized using a quote template. The string representation of this enumeration 
  /// is what is stored in tblQuoteTemplateItem. 
  /// </summary>
  public enum QuoteTemplateField
  {
    RatingState,
    Term,
    Address1,
    Address2,
    ApartmentNumber,
    City,
    Region,
    County,
    State,
    ZipCode,
    CountryOfOrigin,
    ResideTime,
    LicenseStatus,
    MonthsSuspended,
    MonthsForeignLicense,
    PriorAddress1,
    PriorAddress2,
    PriorCity,
    PriorState,
    PriorZipCode,
    EmailAddress,
    Phone,
    WorkPhone,
    WorkPhoneExt,
    CellPhone,
    NativeLanguage,
    PaperlessDiscount,
    MotorClub,
    MotorClubMonths,
    LeadSource,
    ContactSource,
    PaymentMethod,
    NonOwner,
    Broadform,
    LiabBI,
    LiabPD,
    PIP,
    PIPType,
    PIPDed,
    PIPCoPay,
    PIPCoPayPercent,
    PIPPPO,
    PIPLimit,
    PIPLimit2,
    PIPDedOption,
    Funeral,
    FuneralLimit,
    CombineBen,
    CombineBenLimit,
    WorkLoss,
    MedPayLimit,
    MedPay,
    UninsBI,
    UninsBILimits1,
    UninsBILimits2,
    AccDeathLimit,
    AccDeath,
    ManualCreditScore,
    PriorLiabLim1,
    PriorLiabLim2,
    PriorLiabLim3,
    DOB,
    MonthsLicensed,
    MonthsMVRExper,
    MonthsLicensedState,
    StateLicensed,
    OccasionalOperator,
    IndustryOccupation,
    EmployedTime,
    MilitaryDiscount,
    Disabled,
    MilesToWork,
    EducationLevel,
    ResidencyType,
    PropertyInsurance,
    CreditCard,
    GoodCredit,
    BankLienJudgStat,
    MonthsNoBillCollector,
    MultiPolicies,
    DriversTraining,
    DefensiveDriving,
    PriorLiabCarrier,
    SeniorDrvDisc,
    SingleParent,
    CivilUnion,
    NonSmoker,
    DrugAwareness,
    DefensiveDrivingCourseDate,
    SeniorDriverCourseDate,
    SR22,
    SR22A,
    SR22Reason,
    SR50,
    FR44,
    SR22State,
    PriorInsurance,
    ReasonForNoInsurance,
    PriorMonthsCovg,
    PriorExpDate,
    PriorInAgency,
    PriorTransferLevel,
    ParentsPolicy,
    Usage,
    CommutesOutOfState,
    Comp,
    Coll,
    CollType,
    Towing,
    TowingLimit,
    Rental,
    RentalLimit,
    CustomEquipValue,
    GapCoverage,
    PurchaseType,
    PercentToWork,
    RideShare,
    UsageBased,
    Miles,
    AnnualMiles,
    LeasedVehicle,
    Salvaged,
    MSRP,
    ACV,
    PrimaryOperator,
    AntiTheft,
    UMConversion,
    CarPhone,
    Garaged,
    PassSeatRestraint,
    RunningLights,
    GuardianInterlock,
    AntiLock,
    WindowID,
    LoJack,
    HoodLock,
    VINEtching,
    UninsPD,
    Employed,
    EffectiveDate,
    MilesToFireStation,
    FeetToHydrant,
    CityLimit,
    BrushHazard,
    Occupancy,
    DwellingUse,
    UsageType,
    Construction,
    PurchaseDate,
    PurchaseCost,
    YearOfConstruction,
    SquareFootage,
    StoryType,
    NumberOfStories,
    NumberOfFamilies,
    NumAdditionalResidences,
    RoofComposition,
    RoofGrade,
    RoofShape,
    RoofingUpdate,
    RoofingUpdateYear,
    RoofingUpdateLevel,
    HailResistantRoof,
    HeatingType,
    SecondaryHeatingType,
    HeatingUpdate,
    HeatingUpdateYear,
    HeatingUpdateLevel,
    ElectricalUpdate,
    ElectricalUpdateYear,
    ElectricalUpdateLevel,
    PlumbingUpdate,
    PlumbingUpdateYear,
    PlumbingUpdateLevel,
    FoundationType,
    NumberOfFullBaths,
    NumberOfThreeQuarterBaths,
    NumberOfHalfBaths,
    SwimmingPool,
    SwimmingPoolType,
    IsPoolFenced,
    DivingBoardOrSlide,
    Spa,
    SpaType,
    TrampolineOnPremise,
    Animals,
    ViciousDog,
    HomePolicyCancelled,
    SmokersInHousehold,
    OccupiedDuringDay,
    UnitsInFireDivision,
    LegalDescription,
    NumberOfMortgages,
    PriorCompID,
    CompanionPolicy,
    BurglarAlarm,
    Deadbolts,
    FireAlarm,
    FireExtinguisher,
    SmokeDetectors,
    Sprinklers,
    LightningProtection,
    ULImpactType,
    ULFireType,
    AccreditedBuilder,
    FireDepartmentSubscription,
    GatedCommunity,
    MatureHomeowner,
    ResidencyStatus,
    GoodStudent,
    HomingDevice,
    UninsPDDed,
    UninsPDLimit,
    SUM,
    SUMLimits1,
    SUMLimits2,
    FullGlass,
    FullTort,
    ReplacementCost,
    UIMBI,
    UIMBILimits1,
    UIMBILimits2,
    UIMPD,
    UIMPDLimit,
    LimitedColl,
    LimitedCollDed,
    IncomeLoss,
    IncomeLossLimit,
    IncomeLossLimit2,
    ExtraMed,
    ExtraMedLimit,
    StackedUM,
    StackedUIM,
    UninsType,
    LegalExpense,
    MunicipalTaxRate,
    StateTaxRate,
    BuyBackPIP,
    GuestPIP,
    OptionalBI,
    OptionalBILimit1,
    OptionalBILimit2,
    PIPWorkLossRejection,
    PPI,
    FullAddtlPIP,
    AddtlPIPLimit1,
    AddtlPIPLimit2,
    AdditionalPIPOption,
    MedicalExpenseOnly,
    ExtendedMedical,
    ExtendedMedicalLimit,
    OBEL,
    OBELLimit,
    FRBond,
    PrimaryPolicy,
    TotalDisability,
    TotalDisabilityLimit,
    TotalDisabilityType,
    InsuredResideTime,
    QuoteDescription,
    BCEGS,
    MilesToCoast,
    MonthsOwnerOccupied,
    NumberOfTownhouseUnits,
    NumberOfMonthsUnoccupied,
    ExteriorWallConstruction,
    UnderConstruction,
    WoodBurningStove,
    Porch,
    FloodZoneCode,
    Form,
    DwellingAmt,
    OtherStructuresAmt,
    ContentsAmt,
    LossOfUseAmt,
    LiabLimit,
    LiabLimits1,
    LiabLimits2,
    LiabLimits3,
    ExReplacementCostLimit,
    Deductible1,
    Deductible2,
    Deductible3,
    VehicleType,
    NumOfCyl,
    NumOfDoors,
    TwoSeater,
    Hatchback,
    TruckSize,
    ExtendedCab,
    Dualie,
    Turbo,
    FuelType,
    FourWD,
    FrontWD,
    FourWheelSteering,
    Convertible,
    TTops,
    SunRoof,
    Fiberglass,
    ForeignCar,
    GrayMarket,
    Custom,
    OutsizedTires,
    AirBags,
    LicensePlateNumber,
    Odometer,
    TXEndorsements,
    ISOEndorsements,
    WACV,
    Occupation,
    ExpiredLicense,
    SuspendedLic,
    LearnersPermit,
    LicensedState,
    Licensed,
    RankE5OrHigher,
    FRFiling,
    CompDed,
    CollDed,
    FirstName,
    LastName,
    ContentsPercent,
    LossOfUsePercent,
    OtherStructuresPercent,
    MiscPrem,
    PurchasePrice,
    SpousalLiability,
    LimitedLiabPD,
    LimitedLiabPDLimit,
    Gender,
    Marital,
    Sex,
    Notes,
    ProtectionClass,
    ExReplacementCost,
    DistantStudent,
    ConstructionStyle
  }

  /// <summary>
  /// Contains a set of constants used at the Ins level and throughout
  /// all the children levels such as HO, DF, etc.
  /// </summary>
  public sealed class InsConstants
  {
    /// <summary>
    /// Hiding the default constructor
    /// </summary>
    private InsConstants()
    {
    }

    public static List<USState> DailyTermStates = new List<USState>()
    {
      USState.Illinois,
      USState.Indiana
    };

    public static List<USState> WeeklyTermStates = new List<USState>()
    {
      USState.Michigan
    };

    public static readonly string[] CompanyQuestionCategoryPrefixes =
		{
			"cd_",
			"nsd_",
			"cmc_"
		};

    public static readonly int[] UDDCodes =
			{
				99,
				100,
				101,
				102,
				103,
				104,
				105,
				106,
				107,
				108,
				109,
				110,
				111  // server only at the moment, entered dob doesn't match insured's dob
			};

    public static readonly string[] UDDStringCodes =
			{
				"Your Undisclosed Driver searches have exceeded your monthly maximum, please call ITC Sales at 800.383.3482 to upgrade your product.",
				"Driver's license number not in use.",
				"Product Authentication Failure, product may be on an Accounting Hold Status.  Call ITC Accounting at 800.383.3482.",
				"Product Authentication Failure, product may be on an Accounting Hold Status.  Call ITC Accounting at 800.383.3482.",
				"The account code or product code is not valid.  Please call ITC at 800.383.3482 for further details.",
				"Success!",
				"Success!",
				"Driver's license number must be 8 characters (numbers).",
				"ITC Undisclosed Driver Feature Authentication Failure, product may be on an Accounting Hold status.  Call ITC Accounting at 800.383.3482.",
				"This is a trial demonstration of this feature, please call ITC Sales at 800.383.3482 to order this feature.",
				"This is a trial demonstration of this feature, please call ITC Sales at 800.383.3482 to order this feature.",
				"Demonstration period has expired, please call ITC Sales at 800.383.3482 to order this feature.",
				"Entered driver's DOB must match insured's DOB on file."  // server only at the moment, entered dob doesn't match insured's dob
			};

    public static readonly string[] UDDStatusNames =
			{
				"Not Ordered",
				"Ordered",
				"Ordered, None Found",
				"Failed",
				"N/A"
			};

    public static readonly string[] UDDStatusChars =
			{
				"N",
				"O",
				"E",
				"F",
				"Q"
			};

    public static readonly string[] CLUEStatusNames =
			{
				"Processing complete - with results information",
				"Processing complete - results clear",
				"Not processed; product unavailable",
				"Not processed; invalid account number",
				"Insufficient search data",
				"Not processed; state limitation",
				"Not processed; errors",
				"Not Yet Ordered",
				"N/A"
			};

    public static readonly string[] CLUEStatusChars =
			{
				"C",
				"R",
				"P",
				"A",
				"I",
				"S",
				"E",
				"N",
				"Q"
			};

    public static readonly string[] MVRStatusNames =
			{
				"Clear",
				"Hit",
				"No Hit",
				"Invalid Order",
				"Pending MVR",
				"Activity File Clear",
				"Soundex Reject",
				"Unreturned MVR",
				"Not Yet Ordered",
				"N/A"
			};

    public static readonly string[] MVRStatusChars =
			{
				"C",
				"H",
				"N",
				"I",
				"P",
				"A",
				"S",
				"U",
				"Y",
				"Q"
			};

    public static readonly string[] HOVStatusNames =
			{
				"Not Available",
				"Address Found",
				"Match",
				"Probable",
				"No Match",
				"Not Ordered",
				"Account Invalid",
				"Insufficient Data",
				"N/A"
			};

    public static readonly string[] HOVStatusChars =
			{
				"P",
				"I",
				"C",
				"O",
				"R",
				"N",
				"A",
				"D",
				"Q"
			};

    public static readonly string[] CurrentCarrierStatusNames =
			{
				"Record(s) Found",
				"Record(s) Found - Secondary Report",
				"No Record Found",
				"No Record Found - Secondary Report",
				"Invalid Account",
				"Insufficient Data",
				"Current Carrier Unavailable",
				"Access Not Permitted",
				"State Not Available For This Account",
				"Not Ordered",
				"N/A"
			};

    public static readonly string[] CurrentCarrierStatusChars =
			{
				"C",
				"S",
				"R",
				"T",
				"A",
				"I",
				"E",
				"X",
				"N",
				"Z",
				"Q"
			};

    public static readonly string[] DwellingUseNames =
			{
				"Dwelling",
				"Apartment",
				"Other Buildings",
				"Townhouses",
				"Condominiums",
				"Duplex",
				"Triplex"
			};

    public static readonly string[] DwellingUseChars =
			{
				"D",
				"A",
				"O",
				"T",
				"C",
				"X",
				"P"
			};

	public static readonly string[] ConstructionStyleNames =
			{
				"Backsplit",
				"Bi-Level",
				"Bi-Level/Row Center",
				"Bi-Level/Row End",
				"Bungalow",
				"Cape Cod",
				"Colonial",
				"Co-op",
				"Contemporary",
				"Cottage",
				"Federal Colonial",
				"Mediterranean",
				"Ornate Victorian",
				"Queen Anne",
				"Raised Ranch",
				"Rambler",
				"Ranch",
				"Rowhouse",
				"Rowhouse Center",
				"Rowhouse End",
				"Southwest Adobe",
				"Split Foyer",
				"Split Level",
				"Substandard",
				"Townhouse Center",
				"Townhouse End",
				"Tri-Level",
				"Tri-Level Center",
				"Victorian"
			};

    public static readonly string[] ConstructionStyleChars =
			{
				"BS",
				"BL",
				"BC",
				"BE",
				"BW",
				"CC",
				"CO",
				"CP",
				"CN",
				"CG",
				"FC",
				"ME",
				"OV",
				"QN",
				"RR",
				"RB",
				"RA",
				"RW",
				"RC",
				"RE",
				"SA",
				"SF",
				"SL",
				"SS",
				"TC",
				"TE",
				"TL",
				"TR",
				"VI"
			};
	  
    public static readonly string[] RoofCoveringCreditNames = 
			{
				"None",
				"Class 1",
				"Class 2",
				"Class 3",
				"Class 4"
			};

    public static readonly string[] RoofCoveringCreditChars = 
			{
				"N",
				"1",
				"2",
				"3",
				"4"
			};

    /// <summary>
    /// Standard messages used for discounts, warnings, surcharges and errors
    /// </summary>
    public static readonly string[] StandardMessageTexts =
		{
			"",
			"A Roof Covering Credit was Applied.",
			"A Sprinkler Certificate Credit was Applied.",
			"A Dry Hydrants Credit was Applied.",
			"A Stove Top Fire Suppression Device Credit was Applied.",
			"A multi car discount was applied.",
			"A paid-in-full discount was applied.",
			"A homeowner discount was applied.",
			"Invalid Deductible Entered for Deductible Clause 1.",
			"Invalid deductible entered for Deductible Clause 2.",
			"Invalid deductible entered for Deductible Clause 3.",
			"Invalid Tier Entered.",
			"Invalid Policy Form Entered.",
			"Invalid Type of Construction Entered.",
			"Invalid Type of Occupancy Entered.",
			"Invalid Type of Dwelling Use Entered.",
			"Invalid Territory Entered.",
			"Invalid Protection Class Entered.",
			"Invalid Limit of Liability Entered.",
			"Invalid Limit of Medical Payments to Others Entered.",
			"Invalid Year of Construction Entered.",
			"Invalid Roof Classification Entered.",
			"Invalid Stovetop Fire Suppression Device Category Entered.",
			"Invalid Deductible Entered for Selected Dwelling Amount.",
			"Invalid Deductible Entered for Selected Contents Amount.",
			"Subject to Pre-Approval Due to Protection Class 10.",
			"Minimum Premium Rule Applied.",
			"You must enter the insured's address.",
			"You must enter the insured's city.",
			"You must enter the insured's zip code.",
			"You must enter the vehicle's garaging address.",
			"You must enter the vehicle's garaging city.",
			"You must enter the vehicle's garaging zip code.",
			"You must enter the vehicle's VIN.",
			"You must enter the driver's date licensed.",
			"You must enter the driver's license number.",
			"You must enter a valid producer code.",
			"You must enter the expiration date of the prior policy.",
			"You must enter the name of the prior insurance carrier.",
			"You must enter the driver's date of birth.",
			"You must enter the first name of the insured.",
			"You must enter the last name of the insured.",
			"You must enter the driver's first name.",
			"You must enter the driver's last name.",
			"Non-Owner policies are not accepted.",
			"Invalid term entered. Annual rates shown.",
			"Invalid term entered. Monthly rates shown.",
			"Invalid term entered. Quarterly rates shown.",
			"Invalid term entered. Semi-Annual rates shown.",
			"Policy fee may include undisclosed company fees.",
			"An unknown problem prevented the policy from returning a premium.",
			"A SR-22 surcharge was applied.",
			"A vehicle use surcharge was applied.",
			"You must enter the excluded driver's date of birth.",
			"Company does not allow real time rating requests without ordering credit.",
			"This product does not allow daily term rating.",
			"Invalid term entered. Two Month rates shown."
	};

    /// <summary>
    /// An ITC-defined company id, usually used for Prior Insurance company definition.
    /// This list came from Progressive and GMAC and rather loosely matches some NAIC codes.
    /// </summary>
    public static readonly int[] PriorCompanyIDs =
		{ 
			10108, //21st CENTURY INS CO OF THE SOUTHWEST   
			10109, //21st CENTURY INSURANCE COMPANY         
			10110, //AAA TEXAS COUNTY MUTUAL INSURANCE CO   
			10111, //ACA INSURANCE COMPANY                  
			223,   //ACUITY                                 
			10112, //AETNA                                  
			92,    //AFFIRMATIVE INSURANCE COMPANY          
			787,   //AGRICULTURAL WORKERS MUTUAL AUTO INS CO
			10113, //21st Century Ins National Ins Co. Inc     
			10114, //AIGM                                   
			791,   //AIU INS CO                             
			10115, //ALFA                                   
			1452,  //ALFA VISION INSURANCE CORP             
			10116, //ALLIED AUTO                            
			10000, //ALLIED PROPERTY & CASUALTY INS CO      
			10117, //ALLMERICA FINANCIAL ALLIANCE INS CO    
			10118, //ALLSTATE COUNTY MUTUAL INSURANCE CO    
			10119, //ALLSTATE FIRE & CASUALTY INSURANCE CO  
			10001, //ALLSTATE INDEMNITY CO                  
			10002, //ALLSTATE INS CO (NOT INDEMNITY)        
			10003, //ALLSTATE PROP AND CAS INS CO           
			220,   //ALPHA PROPERTY & CASUALTY INSURANCE CO 
			1557,  //AMCO INS CO                            
			10120, //AMERICA FIRST INSURANCE CO             
			96,    //AMERICAN AMBASSADOR                    
			799,   //AMERICAN BANKERS INS CO OF FL          
			10121, //AMERICAN COMMERCE INSURANCE CO         
			10004, //AMERICAN ECONOMY INS CO                
			802,   //AMERICAN FAMILY HOME INS CO            
			10122, //AMERICAN FAMILY INS CO                 
			10005, //AMERICAN FAMILY MUTUAL                 
			10123, //AMERICAN FIRE & CASUALTY COMPANY       
			10124, //AMERICAN HOME ASSURANCE COMPANY        
			646,   //AMERICAN INDEPENDENT                   
			10006, //AMERICAN INS CO                        
			806,   //AMERICAN INTERNATIONAL INS CO          
			10007, //AMERICAN INTERNATIONAL SOUTH INS CO    
			10008, //AMERICAN MANUFACTURERS MUTUAL INS CO   
			408,   //AMERICAN MERCURY INS CO                
			3,     //AMERICAN MODERN HOME INS CO            
			10125, //AMERICAN NATIONAL COUNTY MUTUAL INS CO 
			811,   //AMERICAN NATIONAL GENERAL INS CO       
			10009, //AMERICAN NATIONAL PROP AND CAS CO      
			10010, //AMERICAN PREMIER INS CO                
			4,     //AMERICAN RELIABLE INS CO               
			10126, //AMERICAN SELECT INS CO                 
			97,    //AMERICAN SERVICE INS CO                
			10127, //AMERICAN SERVICE PATRIOT               
			10011, //AMERICAN STANDARD INS                  
			10128, //AMERICAN STANDARD INS CO OF OH         
			818,   //AMERICAN STANDARD INS CO OF WI         
			10012, //AMERICAN STATES INS CO                 
			10013, //AMERICAN STATES PREFERRED INS CO       
			762,   //AMERICAN UNDERWRITERS INS CO           
			821,   //AMERICAN WESTERN HOME INS CO           
			825,   //AMEX ASSURANCE COMPANY                 
			10015, //AMICA MUTUAL INS CO                    
			10129, //ASSIGNED RISK PLAN                     
			293,   //ATLANTA CASUALTY CO                    
			841,   //ATLANTA SPECIALTY INS CO               
			10130, //AUDUBON                                
			10016, //AUSTIN MUTUAL INS CO                   
			842,   //AUTO CLUB FAMILY INS CO (AAA)          
			10017, //AUTOMOBILE CLUB INTERINSURANCE EXCH-AAA
			10131, //AUTOMOBILE INS CO OF HARTFORD          
			1870,  //AUTO-OWNERS INS CO                     
			696,   //BEACON NATIONAL INS CO                 
			10132, //BIRMINGHAM FIRE INSURANCE CO OF PA     
			1566,  //BRISTOL WEST INS CO                    
			10133, //BRISTOL WEST/COAST NATIONAL            
			10134, //BUCKEYE STATE MUTUAL INS CO            
			10018, //BOSTON OLD COLONY INS CO               
			10019, //CALIFORNIA CASUALTY INDEMNITY EXCHANGE 
			10135, //CALIFORNIA CASUALTY INS CO             
			10136, //CAMERON MUTUAL INS CO                  
			1510,  //CELINA                                 
			10137, //CENTRAL MUTUAL INS CO                  
			10138, //CHARTER OAK FIRE INS CO                
			10139, //CHUBB LLOYDS INS CO OF TX              
			10020, //CIGNA SPECIALTY INS CO                 
			10140, //CINCINNATI INS CO                      
			10141, //CITIZENS INS CO OF AMERICA             
			10142, //CITIZENS INS CO OF MIDW                
			890,   //CLARENDON                              
			1561,  //CNA INS CO                             
			10,    //CNL INSURANCE                          
			10143, //COAST NATIONAL                         
			10144, //COLONIAL COUNTY MUTUAL INS CO          
			10021, //COLORADO CASUALTY INS CO               
			10022, //COLORADO FARM BUREAU MUTUAL            
			900,   //COLUMBIA MUTUAL INS CO                 
			10145, //COLUMBIA NATIONAL INS CO               
			10266, //CONSUMERS COUNTY MUTUAL INS CO         
			10146, //CONTINENTAL CASUALTY                   
			10023, //CONTINENTAL INS CO                     
			1872,  //CORNERSTONE NATIONAL INS CO            
			10147, //COTTON STATES                          
			10024, //COUNTRY MUTUAL INS CO                  
			10148, //COUNTRY PREFERRED INS CO               
			10149, //COUNTRYWAY INS CO                      
			10150, //DAIRYLAND COUNTY MUTUAL INS CO         
			105,   //DAIRYLAND INS CO                       
			683,   //DEERBROOK INS CO                       
			10151, //DEPOSITORS INS CO                      
			10152, //DIRECT GENERAL INS CO                  
			10153, //DIRECT GENERAL INS CO OF MS            
			106,   //DIRECT INSURANCE                       
			10025, //ECONOMY PREMIER ASSURANCE              
			10154, //ELECTRIC INS CO                        
			10026, //EMCASCO INS CO                         
			108,   //EMPIRE FIRE AND MARINE INS CO          
			10027, //EMPLOYERS FIRE INS CO                  
			10028, //EMPLOYERS MUTUAL CASUALTY CO           
			10155, //ENCOMPASS INDEMNITY CORP               
			1957,  //ENCOMPASS PROPERTY AND CAS CO          
			1863,  //EQUITY INS CO                          
			10104, //ERIE INSURANCE COMPANY                 
			10105, //ERIE INSURANCE EXCHANGE                
			1729,  //ESURANCE INS CO                        
			10156, //F B INS CO                             
			705,   //FARM AND CITY INS CO                   
			10029, //FARM BUREAU COUNTY MUTUAL INS CO OF TX 
			10030, //FARM BUREAU MUTUAL INS CO              
			945,   //FARM BUREAU TOWN & COUNTY INS CO OF MO 
			10031, //FARMERS ALLIANCE MUTUAL INS CO         
			10157, //FARMERS AUTOMOBILE INSURANCE ASSN      
			10158, //FARMERS INS CO                         
			10159, //FARMERS INS CO OF AZ                   
			10032, //FARMERS INS EXCHANGE                   
			952,   //FARMERS INSURANCE OF COLUMBUS          
			969,   //FARMERS TEXAS COUNTY MUTUAL INS CO     
			10033, //FEDERAL INS CO                         
			10034, //FEDERATED MUTUAL INS CO                
			10160, //FIDELITY AND CASUALTY OF NY            
			10274, //FINANCIAL INDEMNITY CO                 
			539,   //FIREMANS FUND INS CO                   
			10035, //FIREMANS FUND INS CO OF NE             
			19,    //FIRST GENERAL INS CO                   
			10161, //FIRST LIBERTY INS CORP                 
			10036, //FIRST NATIONAL INS CO OF AMERICA       
			991,   //FOREMOST COUNTY MUTAL INS CO           
			990,   //FOREMOST INS CO GRAND RAPIDS MI        
			233,   //FOUNDERS INS CO                        
			112,   //GATEWAY INS CO                         
			10037, //GE CASUALTY INS CO                     
			10038, //GE PROP AND CAS INS CO                 
			27,    //GEICO CASUALTY CO                      
			10094, //GEICO GENERAL INS CO                   
			10095, //GEICO INDEMNITY                        
			10039, //GENERAL INS CO OF AMERICA              
			10162, //GERMAN MUTUAL INS CO (OH)              
			1004,  //GERMANIA FIRE & CASUALTY CO            
			10163, //GERMANIA SELECT INS CO                 
			10164, //GHS PROPERTY & CASUALTY INS CO         
			10165, //GLENN FALLS                            
			10166, //GLOBE AMERICAN CASUALTY CO             
			120,   //GMAC (AKA NATIONAL GENERAL INS)                                   
			10040, //GMAC INS CO ONLINE INC (AKA NATIONAL GENERAL ONLINE, INC)                 
			127,   //GO AMERICA                             
			10041, //GOVERNMENT EMPLOYEES INS CO            
			10167, //GRANGE INDEMNITY INS CO                
			1009,  //GRANGE INS ASSOCIATION                 
			239,   //GRANGE MUTUAL CASUALTY CO              
			10168, //GRANITE STATE INS CO                   
			31,    //GREAT AMERICAN INS CO                  
			10042, //GREAT NORTHERN INS CO                  
			99,    //GREAT TEXAS COUNTY MUTUAL INS CO       
			1021,  //GRINNELL MUTUAL REINSURANCE CO         
			10279,  //GUARANTY NATIONAL INS CO               
			10043, //GUIDANT CASUALTY INS CO                
			10044, //GUIDANT MUTUAL INS CO                  
			61,    //GUIDEONE AMERICA INS CO                
			1480,  //GUIDEONE ELITE INS CO                  
			10169, //GUIDEONE MUTUAL INS CO                 
			10170, //HAMILTON MUTUAL INS CO                 
			10171, //HANOVER AMERICAN INS CO                
			10106, //HANOVER INSURANCE COMPANY              
			586,   //HARTFORD CASUALTY INS CO               
			10172, //HARTFORD FIRE INS CO                   
			10096, //HARTFORD INS CO OF MIDWEST             
			10097, //HARTFORD UNDERWRITERS INS CO           
			1874,  //HASTINGS MUTUAL INS CO                 
			1571,  //HAWKEYE-SECURITY INS CO                
			10276,   //HERITAGE                               
			1032,  //HOCHHEIM PRAIRIE CASUALTY INS CO       
			36,    //HOME STATE COUNTY MUTUAL INS CO        
			1035,  //HOME-OWNERS INS CO                     
			10173, //HOOSIER INS CO                         
			10045, //HORACE MANN INS CO                     
			10174, //HOUSTON GENERAL INSURANCE EXCHANGE     
			1042,  //ILLINOIS FARMERS INS CO                
			10046, //ILLINOIS NATIONAL INS CO               
			671,   //IMPERIAL FIRE AND CASUALTY INS CO      
			39,    //INDIANA FARMERS MUTUAL INS CO          
			10175, //INDIANA INS CO                         
			40,    //INFINITY INS CO                        
			10176, //INSURANCE COMPANY OF STATE OF PA       
			1406,  //INSUREMAX INS CO                       
			10177, //INTEGON CASUALTY INS CO                
			10272, //INTEGON GENERAL INS CORP               
			10047, //INTEGON INDEMNITY CORP                 
			10048, //INTEGON NATIONAL INS CO                
			10178, //INTEGON PREFERRED INS CO               
			10049, //INTERINS EXCH OF THE AUTOMOBILE CLUB   
			1821,  //KEMPER AUTO AND HOME INS CO            
			10050, //KENTUCKY CENTRAL INS CO                
			10179, //KENTUCKY FARM BUREAU MUTUAL INS CO     
			1056,  //KEYSTONE INS CO                        
			122,   //LEADER                                 
			10180, //LIBERTY COUNTY MUTUAL INS CO           
			10051, //LIBERTY INS CORP                       
			497,   //LIBERTY MUTUAL FIRE INS CO             
			1065,  //LIGHTNING ROD MUTUAL INS CO            
			1757,  //LINCOLN GENERAL                        
			10052, //MARATHON INS CO                        
			10053, //MARKEL AMERICAN INS CO                 
			10107, //MARYLAND AUTOMOBILE INSURANCE FUND     
			10181, //MASSACHUSETTS BAY INS CO               
			10182, //MEMBERSELECT INS CO                    
			10054, //MENDAKOTA INS CO                       
			124,   //MENDOTA INS CO                         
			1088,  //MERCURY CASUALTY COMPANY               
			10277,   //MERCURY COUNTY MUTUAL INS CO           
			10183, //MERIDIAN SECURITY INS CO               
			10055, //METROPOLITAN CASUALTY INS CO           
			10056, //METROPOLITAN DRT PROP AND CAS INS CO   
			10057, //METROPOLITAN GENERAL INS CO            
			10184, //METROPOLITAN GROUP PROP & CAS INS CO   
			10185, //METROPOLITAN LLOYDS INS CO OF TX       
			232,   //METROPOLITAN PROP AND CAS INS CO       
			1926,  //MGA INS CO INC                         
			10186, //MID CENTURY/FARMERS                    
			10187, //MID-AMERICAN FIRE AND CASUALTY CO      
			10058, //MID-CENTURY INS CO                     
			10188, //MID-CENTURY INS CO OF TX               
			10189, //MID-CONTINENT CASUALTY CO              
			48,    //MIDLAND RISK                           
			10190, //MIDWESTERN INDEMNITY CORP              
			1121,  //MODERN SERVICE INS CO                  
			10191, //MOTORISTS MUTUAL INS CO                
			10059, //MOUNTAIN LAUREL ASSURANCE CO (NONSTD)  
			10192, //MUTUAL OF OMAHA                        
			10060, //NATIONAL ALLIANCE INS CO               
			10061, //NATIONAL FARMERS UNION P AND C CO      
			1142,  //NATIONAL GENERAL ASSURANCE CO          
			10193, //NATIONAL MUTUAL INS CO                 
			10194, //NATIONAL SECURITY FIRE                 
			10195, //NATIONAL UNION FIRE INS CO PITTSBURGH  
			10196, //NATIONWIDE ASSURANCE CO                
			1148,  //NATIONWIDE GENERAL INS CO              
			10197, //NATIONWIDE INS CO OF AMERICA           
			10198, //NATIONWIDE MUTUAL FIRE INS CO          
			10098, //NATIONWIDE MUTUAL INS CO               
			10199, //NATIONWIDE PROP & CAS INS CO           
			1380,  //NAU COUNTY INS CO                      
			10062, //NEW HAMPSHIRE INDEMNITY                
			10200, //NGM INS CO                             
			10063, //NORTH POINTE INS CO                    
			10064, //NORTHBROOK INDEMNITY CO                
			10201, //OAK BROOK COUNTY MUTUAL INS CO         
			1958,  //OHIO CASUALTY INS CO                   
			10065, //OHIO SECURITY INS CO                   
			10066, //OKLAHOMA FARM BUREAU MUTUAL INS CO     
			10202, //OKLAHOMA FARMERS UNION MUTUAL INS CO   
			10203, //OLD AMERICAN COUNTY MUTUAL FIRE INS CO 
			280,   //OMAHA PROPERTY AND CASUALTY INS CO     
			10204, //OMNI INDEMNITY CO                      
			168,   //OMNI INS CO                            
			10278,  //ORION AUTO                             
			10067, //OTHER                                  
			10068, //OWNERS INS CO                          
			1178,  //PACIFIC INDEMNITY CO                   
			131,   //PAFCO                                  
			10205, //PATRIOT GENERAL                        
			10206, //PEKIN                                  
			1197,  //PENNSYLVANIA NATL MUTUAL CAS INS       
			59,    //PERMANENT GENERAL                      
			10207, //PERMANENT GENERAL ASSURANCE CORP OF OH 
			60,    //PERSONAL SERVICE INS CO                
			10208, //PGA                                    
			648,   //PHOENIX INDEMNITY INS CO               
			10209, //PHOENIX INS CO                         
			10069, //PREFERRED ABSTAINERS INS CO            
			1214,  //PREFERRED RISK MUTUAL INS CO           
			10210, //PROGRESSIVE INSURANCE
      //136,   //PROGRESSIVE CASUALTY INS CO (NON STD)  
      //10211, //PROGRESSIVE CLASSIC INS CO             
      //10212, //PROGRESSIVE COUNTY MUTUAL INS CO       
      //10213, //PROGRESSIVE GULF INS CO                
      //10099, //PROGRESSIVE HALCYON INS CO             
      //10214, //PROGRESSIVE HOME INS CO                
      //10215, //PROGRESSIVE MAX INS CO                 
      //10100, //PROGRESSIVE MOUNTAIN INS CO            
      //10216, //PROGRESSIVE NORTHERN INS CO            
      //10217, //PROGRESSIVE NORTHWESTERN INS CO        
      //10218, //PROGRESSIVE PALOVERDE INS CO           
      //10101, //PROGRESSIVE PREFERRED INS CO           
      //10102, //PROGRESSIVE SPECIALTY INS CO           
      //10219, //PROGRESSIVE UNIVERSAL INS CO           
			10220, //PROPERTY & CASUALTY INS CO OF HARTFORD 
			10070, //PRUDENTIAL COMMERCIAL INS CO           
			1221,  //PRUDENTIAL GENERAL INS CO              
			10071, //PRUDENTIAL PROPERTY AND CASUALTY INS CO
			1225,  //RAMSEY INS CO                          
			10072, //REGAL INS CO                           
			1568,  //RELIANCE INS CO                        
			10073, //RELIANCE NATIONAL INDEMNITY CO         
			10074, //RELIANCE NATIONAL INS CO               
			10075, //RELIANCE NATIONAL INS CO OF NY         
			1720,  //RELIANT                                
			10221, //RESPONSE WORLDWIDE DIRECT AUTO INS     
			1232,  //ROCKFORD MUTUAL INS                    
			10222, //ROCKINGHAM CASUALTY COMPANY            
			10076, //ROCKY MOUNTAIN FIRE AND CASUALTY CO    
			10223, //SAFE AUTO INS CO                       
			1921,  //SAFECO INS CO OF AMERICA               
			10077, //SAFECO INS CO OF IL                    
			1236,  //SAFECO LLOYDS INS CO                   
			10078, //SAFECO NATIONAL INS CO                 
			141,   //SAFEWAY INS CO                         
			274,   //SAGAMORE INS CO                        
			1247,  //SECURITY NATIONAL INS CO (UNITRIN GRP) 
			1249,  //SENTINEL INS CO LTD                    
			10224, //SENTRY INSURANCE MUTUAL COMPANY        
			10271,    //SHELBY                                 
			1252,  //SHELTER GENERAL INS CO                 
			10079, //SHELTER MUTUAL INS CO                  
			10080, //SKANDIA U S INS CO                     
			65,    //SOUTHERN COUNTY MUTUAL INS CO          
			10225, //SOUTHERN FB CASUALTY INS CO            
			1261,  //SOUTHERN GENERAL                       
			10226, //SOUTHERN GUARANTY                      
			10227, //SOUTHERN HERITAGE                      
			10228, //SOUTHERN INS CO                        
			1960,  //SOUTHERN INS CO OF VA                  
			10229, //SOUTHERN PILOT                         
			10230, //SOUTHERN TRUST                         
			272,   //SOUTHERN UNITED FIRE                   
			10081, //ST. PAUL GUARDIAN INS CO               
			10231, //STANDARD FIRE INS CO                   
			1272,  //STANDARD MUTUAL INS CO                 
			10232, //STATE AND COUNTY MUTUAL FIRE INS CO    
			1273,  //STATE AUTO NATIONAL INS CO             
			10233, //STATE AUTO P & C INS CO                
			1383,  //STATE AUTOMOBILE MUTUAL INS CO         
			1275,  //STATE FARM COUNTY MUTUAL INS CO OF TX  
			10268, //STATE FARM FIRE AND CASUALTY CO        
			10082, //STATE FARM MUTUAL AUTOMOBILE INS CO    
			1633,  //STATE MUTUAL INS CO                    
			10273, //SUPERIOR                               
			10234, //TEACHERS INS CO                        
			10235, //TICO INS CO                            
			71,    //TIG INS CO                             
			509,   //TITAN INDEMNITY CO                     
			10269, //TITAN INS CO                           
			10236, //TOPA INS CO                            
			146,   //TRADERS INS CO                         
			72,    //TRANSPORTATION INS CO                  
			10237, //TRAVCO INS CO                          
			10238, //TRAVELERS CASUALTY COMPANY OF CT       
			10239, //TRAVELERS COMMERCIAL INS CO            
			10240, //TRAVELERS HOME AND MARINE INS CO       
			10241, //TRAVELERS INDEMNITY CO OF AMERICA      
			10083, //TRAVELERS INDEMNITY CO OF IL           
			459,   //TRAVELERS INS CO                       
			10270, //TRAVELERS PERSONAL INS CO              
			10242, //TRAVELERS PROP CAS CO OF AMERICA       
			1444,  //TRAVELERS PROPERTY CASUALTY INS CO     
			73,    //TRINITY UNIVERSAL INS CO               
			10084, //TRINITY UNIVERSAL INS CO OF KS         
			1754,  //TRUMBULL INS CO                        
			1303,  //TRUSTGARD INS CO                       
			10267, //TWIN CITY FIRE INS CO                  
			10243, //UFB CASUALTY INS CO                    
			10085, //UNION INS CO                           
			10086, //UNION INS CO OF PROVIDENCE             
			1560,  //UNITED AUTOMOBILE INS CO               
			10244, //UNITED FARM FAMILY MUTUAL INS CO       
			10087, //UNITED FIRE AND CASUALTY CO            
			1315,  //UNITED OHIO INS CO                     
			10088, //UNITED SECURITY INS CO                 
			10089, //UNITED SERVICES AUTOMOBILE ASSOCIATION 
			10090, //UNITED STATES FIDELITY AND GUARANTY CO 
			10245, //UNITRIN AUTO AND HOME INS CO           
			10246, //UNITRIN COUNTY MUTUAL INS CO           
			1809,  //UNITRIN DIRECT INS                     
			8,     //UNITRIN/CHARTER                        
			10275, //UNITRIN/FIC                            
			224,   //UNIVERSAL CASUALTY                     
			1693,  //US AUTO                                
			1458,  //USAA CASUALTY INS CO                   
			10247, //USAA COUNTY MUTUAL INS CO              
			10103, //USAA GENERAL INDEMNITY CO              
			10248, //USAUTO INS CO INC                      
			10249, //VALLEY FORGE                           
			10250, //VALLEY INS CO                          
			10251, //VICTORIA AUTOMOBILE INS CO             
			148,   //VICTORIA FIRE AND CASUALTY             
			10252, //VICTORIA SELECT INS CO                 
			10253, //VICTORIA/TITAN                         
			10091, //VIGILANT INS CO                        
			10254, //VIKING COUNTY MUTUAL INS CO            
			10092, //VIKING INS CO OF WI                    
			10255, //VIRGINIA FARM BUREAU MUTUAL INS CO     
			10256, //VIRGINIA FB TOWN AND COUNTRY INS CO    
			10257, //VIRGINIA MUTUAL INS CO                 
			1770,  //VISION                                 
			1331,  //WAYNE MUTUAL INS CO                    
			10093, //WEST AMERICAN INS CO                   
			10258, //WEST BEND MUTUAL INS CO                
			10259, //WESTERN AGRICULTURAL INS CO            
			10260, //WESTERN RESERVE MUTUAL CASUALTY        
			1344,  //WESTERN UNITED INS CO                  
			10261, //WESTFIELD INS CO                       
			10262, //WESTFIELD NATIONAL INS CO              
			10263, //WINDSOR AUTO                           
			150,   //WINDSOR INS CO                         
			10264, //WOLVERINE MUTUAL INS CO                
			768,   //WORKMENS AUTO INS CO                   
			10265, //YOUNG AMERICA INS CO                   
      10280, //MAPFRE INS CO                                         
		};

    /// <summary>
    /// An ITC-defined company id, usually used for Prior Insurance company definition.
    /// This list came from Progressive and GMAC and rather loosely matches some NAIC codes.
    /// </summary>
    public static readonly string[] PriorCompanyNames =
		{ 
			"21st CENTURY INS CO OF THE SOUTHWEST",   //10108
			"21st CENTURY INSURANCE COMPANY",         //10109
			"AAA TEXAS COUNTY MUTUAL INSURANCE CO",   //10110
			"ACA INSURANCE COMPANY",                  //10111
			"ACUITY",                                 //223
			"AETNA",                                  //10112
			"AFFIRMATIVE INSURANCE COMPANY",          //92
			"AGRICULTURAL WORKERS MUTUAL AUTO INS CO",//787
			"21ST CENTURY INS NATIONAL INS CO. INC",  //10113
			"AIGM",                                   //10114
			"AIU INS CO",                             //791
			"ALFA",                                   //10115
			"ALFA VISION INSURANCE CORP",             //1452
			"ALLIED AUTO",                            //10116
			"ALLIED PROPERTY & CASUALTY INS CO",      //10000
			"ALLMERICA FINANCIAL ALLIANCE INS CO",    //10117
			"ALLSTATE COUNTY MUTUAL INSURANCE CO",    //10118
			"ALLSTATE FIRE & CASUALTY INSURANCE CO",  //10119
			"ALLSTATE INDEMNITY CO",                  //10001
			"ALLSTATE INS CO (NOT INDEMNITY)",        //10002
			"ALLSTATE PROP AND CAS INS CO",           //10003
			"ALPHA PROPERTY & CASUALTY INSURANCE CO", //220
			"AMCO INS CO",                            //1557
			"AMERICA FIRST INSURANCE CO",             //10120
			"AMERICAN AMBASSADOR",                    //96
			"AMERICAN BANKERS INS CO OF FL",          //799
			"AMERICAN COMMERCE INSURANCE CO",         //10121
			"AMERICAN ECONOMY INS CO",                //10004
			"AMERICAN FAMILY HOME INS CO",            //802
			"AMERICAN FAMILY INS CO",                 //10122
			"AMERICAN FAMILY MUTUAL",                 //10005
			"AMERICAN FIRE & CASUALTY COMPANY",       //10123
			"AMERICAN HOME ASSURANCE COMPANY",        //10124
			"AMERICAN INDEPENDENT",                   //646
			"AMERICAN INS CO",                        //10006
			"AMERICAN INTERNATIONAL INS CO",          //806
			"AMERICAN INTERNATIONAL SOUTH INS CO",    //10007
			"AMERICAN MANUFACTURERS MUTUAL INS CO",   //10008
			"AMERICAN MERCURY INS CO",                //408
			"AMERICAN MODERN HOME INS CO",            //3
			"AMERICAN NATIONAL COUNTY MUTUAL INS CO", //10125
			"AMERICAN NATIONAL GENERAL INS CO",       //811
			"AMERICAN NATIONAL PROP AND CAS CO",      //10009
			"AMERICAN PREMIER INS CO",                //10010
			"AMERICAN RELIABLE INS CO",               //4
			"AMERICAN SELECT INS CO",                 //10126
			"AMERICAN SERVICE INS CO",                //97
			"AMERICAN SERVICE PATRIOT",               //10127
			"AMERICAN STANDARD INS",                  //10011
			"AMERICAN STANDARD INS CO OF OH",         //10128
			"AMERICAN STANDARD INS CO OF WI",         //818
			"AMERICAN STATES INS CO",                 //10012
			"AMERICAN STATES PREFERRED INS CO",       //10013
			"AMERICAN UNDERWRITERS INS CO",           //762
			"AMERICAN WESTERN HOME INS CO",           //821
			"AMEX ASSURANCE COMPANY",                 //825
			"AMICA MUTUAL INS CO",                    //10015
			"ASSIGNED RISK PLAN",                     //10129
			"ATLANTA CASUALTY CO",                    //293
			"ATLANTA SPECIALTY INS CO",               //841
			"AUDUBON",                                //10130
			"AUSTIN MUTUAL INS CO",                   //10016
			"AUTO CLUB FAMILY INS CO (AAA)",          //842
			"AUTOMOBILE CLUB INTERINSURANCE EXCH-AAA",//10017
			"AUTOMOBILE INS CO OF HARTFORD",          //10131
			"AUTO-OWNERS INS CO",                     //1870
			"BEACON NATIONAL INS CO",                 //696
			"BIRMINGHAM FIRE INSURANCE CO OF PA",     //10132
			"BRISTOL WEST INS CO",                    //1566
			"BRISTOL WEST/COAST NATIONAL",            //10133
			"BUCKEYE STATE MUTUAL INS CO",            //10134
			"BOSTON OLD COLONY INS CO",               //10018
			"CALIFORNIA CASUALTY INDEMNITY EXCHANGE", //10019
			"CALIFORNIA CASUALTY INS CO",             //10135
			"CAMERON MUTUAL INS CO",                  //10136
			"CELINA",                                 //1510
			"CENTRAL MUTUAL INS CO",                  //10137
			"CHARTER OAK FIRE INS CO",                //10138
			"CHUBB LLOYDS INS CO OF TX",              //10139
			"CIGNA SPECIALTY INS CO",                 //10020
			"CINCINNATI INS CO",                      //10140
			"CITIZENS INS CO OF AMERICA",             //10141
			"CITIZENS INS CO OF MIDW",                //10142
			"CLARENDON",                              //890
			"CNA INS CO",                             //1561
			"CNL INSURANCE",                          //10
			"COAST NATIONAL",                         //10143
			"COLONIAL COUNTY MUTUAL INS CO",          //10144
			"COLORADO CASUALTY INS CO",               //10021
			"COLORADO FARM BUREAU MUTUAL",            //10022
			"COLUMBIA MUTUAL INS CO",                 //900
			"COLUMBIA NATIONAL INS CO",               //10145
			"CONSUMERS COUNTY MUTUAL INS CO",         //3
			"CONTINENTAL CASUALTY",                   //10146
			"CONTINENTAL INS CO",                     //10023
			"CORNERSTONE NATIONAL INS CO",            //1872
			"COTTON STATES",                          //10147
			"COUNTRY MUTUAL INS CO",                  //10024
			"COUNTRY PREFERRED INS CO",               //10148
			"COUNTRYWAY INS CO",                      //10149
			"DAIRYLAND COUNTY MUTUAL INS CO",         //10150
			"DAIRYLAND INS CO",                       //105
			"DEERBROOK INS CO",                       //683
			"DEPOSITORS INS CO",                      //10151
			"DIRECT GENERAL INS CO",                  //10152
			"DIRECT GENERAL INS CO OF MS",            //10153
			"DIRECT INSURANCE",                       //106
			"ECONOMY PREMIER ASSURANCE",              //10025
			"ELECTRIC INS CO",                        //10154
			"EMCASCO INS CO",                         //10026
			"EMPIRE FIRE AND MARINE INS CO",          //108
			"EMPLOYERS FIRE INS CO",                  //10027
			"EMPLOYERS MUTUAL CASUALTY CO",           //10028
			"ENCOMPASS INDEMNITY CORP",               //10155
			"ENCOMPASS PROPERTY AND CAS CO",          //1957
			"EQUITY INS CO",                          //1863
			"ERIE INSURANCE COMPANY",                 //10104
			"ERIE INSURANCE EXCHANGE",                //10105
			"ESURANCE INS CO",                        //1729
			"F B INS CO",                             //10156
			"FARM AND CITY INS CO",                   //705
			"FARM BUREAU COUNTY MUTUAL INS CO OF TX", //10029
			"FARM BUREAU MUTUAL INS CO",              //10030
			"FARM BUREAU TOWN & COUNTY INS CO OF MO", //945
			"FARMERS ALLIANCE MUTUAL INS CO",         //10031
			"FARMERS AUTOMOBILE INSURANCE ASSN",      //10157
			"FARMERS INS CO",                         //10158
			"FARMERS INS CO OF AZ",                   //10159
			"FARMERS INS EXCHANGE",                   //10032
			"FARMERS INSURANCE OF COLUMBUS",          //952
			"FARMERS TEXAS COUNTY MUTUAL INS CO",     //969
			"FEDERAL INS CO",                         //10033
			"FEDERATED MUTUAL INS CO",                //10034
			"FIDELITY AND CASUALTY OF NY",            //10160
			"FINANCIAL INDEMNITY CO",                 //220
			"FIREMANS FUND INS CO",                   //539
			"FIREMANS FUND INS CO OF NE",             //10035
			"FIRST GENERAL INS CO",                   //19
			"FIRST LIBERTY INS CORP",                 //10161
			"FIRST NATIONAL INS CO OF AMERICA",       //10036
			"FOREMOST COUNTY MUTAL INS CO",           //991
			"FOREMOST INS CO GRAND RAPIDS MI",        //990
			"FOUNDERS INS CO",                        //233
			"GATEWAY INS CO",                         //112
			"GE CASUALTY INS CO",                     //10037
			"GE PROP AND CAS INS CO",                 //10038
			"GEICO CASUALTY CO",                      //27
			"GEICO GENERAL INS CO",                   //10094
			"GEICO INDEMNITY",                        //10095
			"GENERAL INS CO OF AMERICA",              //10039
			"GERMAN MUTUAL INS CO (OH)",              //10162
			"GERMANIA FIRE & CASUALTY CO",            //1004
			"GERMANIA SELECT INS CO",                 //10163
			"GHS PROPERTY & CASUALTY INS CO",         //10164
			"GLENN FALLS",                            //10165
			"GLOBE AMERICAN CASUALTY CO",             //10166
			"NATIONAL GENERAL INS",                   //120
			"NATIONAL GENERAL ONLINE, INC",           //10040
			"GO AMERICA",                             //127
			"GOVERNMENT EMPLOYEES INS CO",            //10041
			"GRANGE INDEMNITY INS CO",                //10167
			"GRANGE INS ASSOCIATION",                 //1009
			"GRANGE MUTUAL CASUALTY CO",              //239
			"GRANITE STATE INS CO",                   //10168
			"GREAT AMERICAN INS CO",                  //31
			"GREAT NORTHERN INS CO",                  //10042
			"GREAT TEXAS COUNTY MUTUAL INS CO",       //99
			"GRINNELL MUTUAL REINSURANCE CO",         //1021
			"GUARANTY NATIONAL INS CO",               //1605
			"GUIDANT CASUALTY INS CO",                //10043
			"GUIDANT MUTUAL INS CO",                  //10044
			"GUIDEONE AMERICA INS CO",                //61
			"GUIDEONE ELITE INS CO",                  //1480
			"GUIDEONE MUTUAL INS CO",                 //10169
			"HAMILTON MUTUAL INS CO",                 //10170
			"HANOVER AMERICAN INS CO",                //10171
			"HANOVER INSURANCE COMPANY",              //10106
			"HARTFORD CASUALTY INS CO",               //586
			"HARTFORD FIRE INS CO",                   //10172
			"HARTFORD INS CO OF MIDWEST",             //10096
			"HARTFORD UNDERWRITERS INS CO",           //10097
			"HASTINGS MUTUAL INS CO",                 //1874
			"HAWKEYE-SECURITY INS CO",                //1571
			"HERITAGE",                               //223
			"HOCHHEIM PRAIRIE CASUALTY INS CO",       //1032
			"HOME STATE COUNTY MUTUAL INS CO",        //36
			"HOME-OWNERS INS CO",                     //1035
			"HOOSIER INS CO",                         //10173
			"HORACE MANN INS CO",                     //10045
			"HOUSTON GENERAL INSURANCE EXCHANGE",     //10174
			"ILLINOIS FARMERS INS CO",                //1042
			"ILLINOIS NATIONAL INS CO",               //10046
			"IMPERIAL FIRE AND CASUALTY INS CO",      //671
			"INDIANA FARMERS MUTUAL INS CO",          //39
			"INDIANA INS CO",                         //10175
			"INFINITY INS CO",                        //40
			"INSURANCE COMPANY OF STATE OF PA",       //10176
			"INSUREMAX INS CO",                       //1406
			"INTEGON CASUALTY INS CO",                //10177
			"INTEGON GENERAL INS CORP",               //120
			"INTEGON INDEMNITY CORP",                 //10047
			"INTEGON NATIONAL INS CO",                //10048
			"INTEGON PREFERRED INS CO",               //10178
			"INTERINS EXCH OF THE AUTOMOBILE CLUB",   //10049
			"KEMPER AUTO AND HOME INS CO",            //1821
			"KENTUCKY CENTRAL INS CO",                //10050
			"KENTUCKY FARM BUREAU MUTUAL INS CO",     //10179
			"KEYSTONE INS CO",                        //1056
			"LEADER",                                 //122
			"LIBERTY COUNTY MUTUAL INS CO",           //10180
			"LIBERTY INS CORP",                       //10051
			"LIBERTY MUTUAL FIRE INS CO",             //497
			"LIGHTNING ROD MUTUAL INS CO",            //1065
			"LINCOLN GENERAL",                        //1757
			"MARATHON INS CO",                        //10052
			"MARKEL AMERICAN INS CO",                 //10053
			"MARYLAND AUTOMOBILE INSURANCE FUND",     //10107
			"MASSACHUSETTS BAY INS CO",               //10181
			"MEMBERSELECT INS CO",                    //10182
			"MENDAKOTA INS CO",                       //10054
			"MENDOTA INS CO",                         //124
			"MERCURY CASUALTY COMPANY",               //1088
			"MERCURY COUNTY MUTUAL INS CO",           //408
			"MERIDIAN SECURITY INS CO",               //10183
			"METROPOLITAN CASUALTY INS CO",           //10055
			"METROPOLITAN DRT PROP AND CAS INS CO",   //10056
			"METROPOLITAN GENERAL INS CO",            //10057
			"METROPOLITAN GROUP PROP & CAS INS CO",   //10184
			"METROPOLITAN LLOYDS INS CO OF TX",       //10185
			"METROPOLITAN PROP AND CAS INS CO",       //232
			"MGA INS CO INC",                         //1926
			"MID CENTURY/FARMERS",                    //10186
			"MID-AMERICAN FIRE AND CASUALTY CO",      //10187
			"MID-CENTURY INS CO",                     //10058
			"MID-CENTURY INS CO OF TX",               //10188
			"MID-CONTINENT CASUALTY CO",              //10189
			"MIDLAND RISK",                           //48
			"MIDWESTERN INDEMNITY CORP",              //10190
			"MODERN SERVICE INS CO",                  //1121
			"MOTORISTS MUTUAL INS CO",                //10191
			"MOUNTAIN LAUREL ASSURANCE CO (NONSTD)",  //10059
			"MUTUAL OF OMAHA",                        //10192
			"NATIONAL ALLIANCE INS CO",               //10060
			"NATIONAL FARMERS UNION P AND C CO",      //10061
			"NATIONAL GENERAL ASSURANCE CO",          //1142
			"NATIONAL MUTUAL INS CO",                 //10193
			"NATIONAL SECURITY FIRE",                 //10194
			"NATIONAL UNION FIRE INS CO PITTSBURGH",  //10195
			"NATIONWIDE ASSURANCE CO",                //10196
			"NATIONWIDE GENERAL INS CO",              //1148
			"NATIONWIDE INS CO OF AMERICA",           //10197
			"NATIONWIDE MUTUAL FIRE INS CO",          //10198
			"NATIONWIDE MUTUAL INS CO",               //10098
			"NATIONWIDE PROP & CAS INS CO",           //10199
			"NAU COUNTY INS CO",                      //1380
			"NEW HAMPSHIRE INDEMNITY",                //10062
			"NGM INS CO",                             //10200
			"NORTH POINTE INS CO",                    //10063
			"NORTHBROOK INDEMNITY CO",                //10064
			"OAK BROOK COUNTY MUTUAL INS CO",         //10201
			"OHIO CASUALTY INS CO",                   //1958
			"OHIO SECURITY INS CO",                   //10065
			"OKLAHOMA FARM BUREAU MUTUAL INS CO",     //10066
			"OKLAHOMA FARMERS UNION MUTUAL INS CO",   //10202
			"OLD AMERICAN COUNTY MUTUAL FIRE INS CO", //10203
			"OMAHA PROPERTY AND CASUALTY INS CO",     //280
			"OMNI INDEMNITY CO",                      //10204
			"OMNI INS CO",                            //168
			"ORION AUTO",                             //1605
			"OTHER",                                  //10067
			"OWNERS INS CO",                          //10068
			"PACIFIC INDEMNITY CO",                   //1178
			"PAFCO",                                  //131
			"PATRIOT GENERAL",                        //10205
			"PEKIN",                                  //10206
			"PENNSYLVANIA NATL MUTUAL CAS INS",       //1197
			"PERMANENT GENERAL",                      //59
			"PERMANENT GENERAL ASSURANCE CORP OF OH", //10207
			"PERSONAL SERVICE INS CO",                //60
			"PGA",                                    //10208
			"PHOENIX INDEMNITY INS CO",               //648
			"PHOENIX INS CO",                         //10209
			"PREFERRED ABSTAINERS INS CO",            //10069
			"PREFERRED RISK MUTUAL INS CO",           //1214
			"PROGRESSIVE INSURANCE",                  //10210
      //"PROGRESSIVE CASUALTY INS CO (NON STD)",  //136
      //"PROGRESSIVE CLASSIC INS CO",             //10211
      //"PROGRESSIVE COUNTY MUTUAL INS CO",       //10212
      //"PROGRESSIVE GULF INS CO",                //10213
      //"PROGRESSIVE HALCYON INS CO",             //10099
      //"PROGRESSIVE HOME INS CO",                //10214
      //"PROGRESSIVE MAX INS CO",                 //10215
      //"PROGRESSIVE MOUNTAIN INS CO",            //10100
      //"PROGRESSIVE NORTHERN INS CO",            //10216
      //"PROGRESSIVE NORTHWESTERN INS CO",        //10217
      //"PROGRESSIVE PALOVERDE INS CO",           //10218
      //"PROGRESSIVE PREFERRED INS CO",           //10101
      //"PROGRESSIVE SPECIALTY INS CO",           //10102
      //"PROGRESSIVE UNIVERSAL INS CO",           //10219
			"PROPERTY & CASUALTY INS CO OF HARTFORD", //10220
			"PRUDENTIAL COMMERCIAL INS CO",           //10070
			"PRUDENTIAL GENERAL INS CO",              //1221
			"PRUDENTIAL PROPERTY AND CASUALTY INS CO",//10071
			"RAMSEY INS CO",                          //1225
			"REGAL INS CO",                           //10072
			"RELIANCE INS CO",                        //1568
			"RELIANCE NATIONAL INDEMNITY CO",         //10073
			"RELIANCE NATIONAL INS CO",               //10074
			"RELIANCE NATIONAL INS CO OF NY",         //10075
			"RELIANT",                                //1720
			"RESPONSE WORLDWIDE DIRECT AUTO INS",     //10221
			"ROCKFORD MUTUAL INS",                    //1232
			"ROCKINGHAM CASUALTY COMPANY",            //10222
			"ROCKY MOUNTAIN FIRE AND CASUALTY CO",    //10076
			"SAFE AUTO INS CO",                       //10223
			"SAFECO INS CO OF AMERICA",               //1921
			"SAFECO INS CO OF IL",                    //10077
			"SAFECO LLOYDS INS CO",                   //1236
			"SAFECO NATIONAL INS CO",                 //10078
			"SAFEWAY INS CO",                         //141
			"SAGAMORE INS CO",                        //274
			"SECURITY NATIONAL INS CO (UNITRIN GRP)", //1247
			"SENTINEL INS CO LTD",                    //1249
			"SENTRY INSURANCE MUTUAL COMPANY",        //10224
			"SHELBY",                                 //92
			"SHELTER GENERAL INS CO",                 //1252
			"SHELTER MUTUAL INS CO",                  //10079
			"SKANDIA U S INS CO",                     //10080
			"SOUTHERN COUNTY MUTUAL INS CO",          //65
			"SOUTHERN FB CASUALTY INS CO",            //10225
			"SOUTHERN GENERAL",                       //1261
			"SOUTHERN GUARANTY",                      //10226
			"SOUTHERN HERITAGE",                      //10227
			"SOUTHERN INS CO",                        //10228
			"SOUTHERN INS CO OF VA",                  //1960
			"SOUTHERN PILOT",                         //10229
			"SOUTHERN TRUST",                         //10230
			"SOUTHERN UNITED FIRE",                   //272
			"ST. PAUL GUARDIAN INS CO",               //10081
			"STANDARD FIRE INS CO",                   //10231
			"STANDARD MUTUAL INS CO",                 //1272
			"STATE AND COUNTY MUTUAL FIRE INS CO",    //10232
			"STATE AUTO NATIONAL INS CO",             //1273
			"STATE AUTO P & C INS CO",                //10233
			"STATE AUTOMOBILE MUTUAL INS CO",         //1383
			"STATE FARM COUNTY MUTUAL INS CO OF TX",  //1275
			"STATE FARM FIRE AND CASUALTY CO",        //1275
			"STATE FARM MUTUAL AUTOMOBILE INS CO",    //10082
			"STATE MUTUAL INS CO",                    //1633
			"SUPERIOR",                               //131
			"TEACHERS INS CO",                        //10234
			"TICO INS CO",                            //10235
			"TIG INS CO",                             //71
			"TITAN INDEMNITY CO",                     //509
			"TITAN INS CO",                           //509
			"TOPA INS CO",                            //10236
			"TRADERS INS CO",                         //146
			"TRANSPORTATION INS CO",                  //72
			"TRAVCO INS CO",                          //10237
			"TRAVELERS CASUALTY COMPANY OF CT",       //10238
			"TRAVELERS COMMERCIAL INS CO",            //10239
			"TRAVELERS HOME AND MARINE INS CO",       //10240
			"TRAVELERS INDEMNITY CO OF AMERICA",      //10241
			"TRAVELERS INDEMNITY CO OF IL",           //10083
			"TRAVELERS INS CO",                       //459
			"TRAVELERS PERSONAL INS CO",              //459
			"TRAVELERS PROP CAS CO OF AMERICA",       //10242
			"TRAVELERS PROPERTY CASUALTY INS CO",     //1444
			"TRINITY UNIVERSAL INS CO",               //73
			"TRINITY UNIVERSAL INS CO OF KS",         //10084
			"TRUMBULL INS CO",                        //1754
			"TRUSTGARD INS CO",                       //1303
			"TWIN CITY FIRE INS CO",                  //168
			"UFB CASUALTY INS CO",                    //10243
			"UNION INS CO",                           //10085
			"UNION INS CO OF PROVIDENCE",             //10086
			"UNITED AUTOMOBILE INS CO",               //1560
			"UNITED FARM FAMILY MUTUAL INS CO",       //10244
			"UNITED FIRE AND CASUALTY CO",            //10087
			"UNITED OHIO INS CO",                     //1315
			"UNITED SECURITY INS CO",                 //10088
			"UNITED SERVICES AUTOMOBILE ASSOCIATION", //10089
			"UNITED STATES FIDELITY AND GUARANTY CO", //10090
			"UNITRIN AUTO AND HOME INS CO",           //10245
			"UNITRIN COUNTY MUTUAL INS CO",           //10246
			"UNITRIN DIRECT INS",                     //1809
			"UNITRIN/CHARTER",                        //8
			"UNITRIN/FIC",                            //220
			"UNIVERSAL CASUALTY",                     //224
			"US AUTO",                                //1693
			"USAA CASUALTY INS CO",                   //1458
			"USAA COUNTY MUTUAL INS CO",              //10247
			"USAA GENERAL INDEMNITY CO",              //10103
			"USAUTO INS CO INC",                      //10248
			"VALLEY FORGE",                           //10249
			"VALLEY INS CO",                          //10250
			"VICTORIA AUTOMOBILE INS CO",             //10251
			"VICTORIA FIRE AND CASUALTY",             //148
			"VICTORIA SELECT INS CO",                 //10252
			"VICTORIA/TITAN",                         //10253
			"VIGILANT INS CO",                        //10091
			"VIKING COUNTY MUTUAL INS CO",            //10254
			"VIKING INS CO OF WI",                    //10092
			"VIRGINIA FARM BUREAU MUTUAL INS CO",     //10255
			"VIRGINIA FB TOWN AND COUNTRY INS CO",    //10256
			"VIRGINIA MUTUAL INS CO",                 //10257
			"VISION",                                 //1770
			"WAYNE MUTUAL INS CO",                    //1331
			"WEST AMERICAN INS CO",                   //10093
			"WEST BEND MUTUAL INS CO",                //10258
			"WESTERN AGRICULTURAL INS CO",            //10259
			"WESTERN RESERVE MUTUAL CASUALTY",        //10260
			"WESTERN UNITED INS CO",                  //1344
			"WESTFIELD INS CO",                       //10261
			"WESTFIELD NATIONAL INS CO",              //10262
			"WINDSOR AUTO",                           //10263
			"WINDSOR INS CO",                         //150
			"WOLVERINE MUTUAL INS CO",                //10264
			"WORKMENS AUTO INS CO",                   //768
			"YOUNG AMERICA INS CO",                   //10265
      "MAPFRE INS CO",                          //10280
		};

    /// <summary>
    /// NAIC code mapping as best as we have that maps NAIC codes to our
    /// PriorCompanyID list.
    /// </summary>
    public static readonly int[] PriorCompanyNaicCodes =
		{ 
  	  99998,     //10108,   21st CENTURY INS CO OF THE SOUTHWEST
			12963,     //10109,   21st CENTURY INSURANCE COMPANY
			99998,     //10110,   AAA TEXAS COUNTY MUTUAL INSURANCE CO
			10921,     //10111,   ACA INSURANCE COMPANY                  
			14184,     //223,     ACUITY                                 
			99998,     //10112,   AETNA
			42609,     //92,      AFFIRMATIVE INSURANCE COMPANY          
			99998,     //787,     AGRICULTURAL WORKERS MUTUAL AUTO INS CO
			12963,     //10113,   21st Century Ins National Ins Co. Inc     
			99998,     //10114,   AIGM                                   
			19399,     //791,     AIU INS CO                             
			99998,     //10115,   ALFA                                   
			99998,     //1452,    ALFA VISION INSURANCE CORP             
			99998,     //10116,   ALLIED AUTO                            
			42579,     //10000,   ALLIED PROPERTY & CASUALTY INS CO      
			10212,     //10117,   ALLMERICA FINANCIAL ALLIANCE INS CO    
			99998,     //10118,   ALLSTATE COUNTY MUTUAL INSURANCE CO    
			29688,     //10119,   ALLSTATE FIRE & CASUALTY INSURANCE CO  
			19240,     //10001,   ALLSTATE INDEMNITY CO                  
			19232,     //10002,   ALLSTATE INS CO (NOT INDEMNITY)        
			17230,     //10003,   ALLSTATE PROP AND CAS INS CO           
			38156,     //220,     ALPHA PROPERTY & CASUALTY INSURANCE CO 
			19100,     //1557,    AMCO INS CO                            
			12692,     //10120,   AMERICA FIRST INSURANCE CO             
			10073,     //96,      AMERICAN AMBASSADOR                    
			10111,     //799,     AMERICAN BANKERS INS CO OF FL          
			19941,     //10121,   AMERICAN COMMERCE INSURANCE CO         
			19690,     //10004,   AMERICAN ECONOMY INS CO                
			23450,     //802,     AMERICAN FAMILY HOME INS CO            
			10386,     //10122,   AMERICAN FAMILY INS CO                 
			99998,     //10005,   AMERICAN FAMILY MUTUAL                 
			24066,     //10123,   AMERICAN FIRE & CASUALTY COMPANY       
			19380,     //10124,   AMERICAN HOME ASSURANCE COMPANY        
			17957,     //646,     AMERICAN INDEPENDENT                   
			21857,     //10006,   AMERICAN INS CO                        
			32220,     //806,     AMERICAN INTERNATIONAL INS CO          
			40258,     //10007,   AMERICAN INTERNATIONAL SOUTH INS CO    
			30562,     //10008,   AMERICAN MANUFACTURERS MUTUAL INS CO   
			16810,     //408,     AMERICAN MERCURY INS CO                
			23469,     //3,       AMERICAN MODERN HOME INS CO            
			99998,     //10125,   AMERICAN NATIONAL COUNTY MUTUAL INS CO 
			39942,     //811,     AMERICAN NATIONAL GENERAL INS CO       
			28401,     //10009,   AMERICAN NATIONAL PROP AND CAS CO      
			19615,     //10010,   AMERICAN PREMIER INS CO                
			19615,     //4,       AMERICAN RELIABLE INS CO               
			19962,     //10126,   AMERICAN SELECT INS CO                 
			42897,     //97,      AMERICAN SERVICE INS CO                
			99998,     //10127,   AMERICAN SERVICE PATRIOT               
			99998,     //10011,   AMERICAN STANDARD INS                  
			10387,     //10128,   AMERICAN STANDARD INS CO OF OH         
			99998,     //818,     AMERICAN STANDARD INS CO OF WI         
			19704,     //10012,   AMERICAN STATES INS CO                 
			37214,     //10013,   AMERICAN STATES PREFERRED INS CO       
			99998,     //762,     AMERICAN UNDERWRITERS INS CO           
			35912,     //821,     AMERICAN WESTERN HOME INS CO           
			27928,     //825,     AMEX ASSURANCE COMPANY                 
			19976,     //10015,   AMICA MUTUAL INS CO                    
			99997,     //10129,   ASSIGNED RISK PLAN                     
			99998,     //293,     ATLANTA CASUALTY CO                    
			99998,     //841,     ATLANTA SPECIALTY INS CO               
			19933,     //10130,   AUDUBON                                
			13412,     //10016,   AUSTIN MUTUAL INS CO                   
			27235,     //842,     AUTO CLUB FAMILY INS CO (AAA)          
			15512,     //10017,   AUTOMOBILE CLUB INTERINSURANCE EXCH-AAA
			19062,     //10131,   AUTOMOBILE INS CO OF HARTFORD          
			18988,     //1870,    AUTO-OWNERS INS CO                     
			99998,     //696,     BEACON NATIONAL INS CO                 
			99998,     //10132,   BIRMINGHAM FIRE INSURANCE CO OF PA     
			19658,     //1566,    BRISTOL WEST INS CO                    
			99998,     //10133,   BRISTOL WEST/COAST NATIONAL            
			99998,     //10134,   BUCKEYE STATE MUTUAL INS CO            
			99998,     //10018,   BOSTON OLD COLONY INS CO               
			20117,     //10019,   CALIFORNIA CASUALTY INDEMNITY EXCHANGE 
			20125,     //10135,   CALIFORNIA CASUALTY INS CO             
			99998,     //10136,   CAMERON MUTUAL INS CO                  
			20176,     //1510,    CELINA                                 
			20230,     //10137,   CENTRAL MUTUAL INS CO                  
			25615,     //10138,   CHARTER OAK FIRE INS CO                
			99998,     //10139,   CHUBB LLOYDS INS CO OF TX              
			99998,     //10020,   CIGNA SPECIALTY INS CO                 
			10677,     //10140,   CINCINNATI INS CO                      
			31534,     //10141,   CITIZENS INS CO OF AMERICA             
			99998,     //10142,   CITIZENS INS CO OF MIDW                
			20532,     //890,     CLARENDON                              
			99998,     //1561,    CNA INS CO                             
			99998,     //10,      CNL INSURANCE                          
			25089,     //10143,   COAST NATIONAL                         
			99998,     //10144,   COLONIAL COUNTY MUTUAL INS CO          
			41785,     //10021,   COLORADO CASUALTY INS CO               
			99998,     //10022,   COLORADO FARM BUREAU MUTUAL            
			40371,     //900,     COLUMBIA MUTUAL INS CO                 
			19640,     //10145,   COLUMBIA NATIONAL INS CO               
			29246,     //10266,   CONSUMERS COUNTY MUTUAL INS CO         
			20443,     //10146,   CONTINENTAL CASUALTY                   
			35289,     //10023,   CONTINENTAL INS CO                     
			10783,     //1872,    CORNERSTONE NATIONAL INS CO            
			20966,     //10147,   COTTON STATES                          
			20990,     //10024,   COUNTRY MUTUAL INS CO                  
			21008,     //10148,   COUNTRY PREFERRED INS CO               
			10022,     //10149,   COUNTRYWAY INS CO                      
			99998,     //10150,   DAIRYLAND COUNTY MUTUAL INS CO         
			21164,     //105,     DAIRYLAND INS CO                       
			37907,     //683,     DEERBROOK INS CO                       
			42587,     //10151,   DEPOSITORS INS CO                      
			42781,     //10152,   DIRECT GENERAL INS CO                  
			99998,     //10153,   DIRECT GENERAL INS CO OF MS            
			37220,     //106,     DIRECT INSURANCE                       
			40649,     //10025,   ECONOMY PREMIER ASSURANCE              
			21261,     //10154,   ELECTRIC INS CO                        
			21407,     //10026,   EMCASCO INS CO                         
			21326,     //108,     EMPIRE FIRE AND MARINE INS CO          
			20648,     //10027,   EMPLOYERS FIRE INS CO                  
			21415,     //10028,   EMPLOYERS MUTUAL CASUALTY CO           
			15130,     //10155,   ENCOMPASS INDEMNITY CORP               
			10072,     //1957,    ENCOMPASS PROPERTY AND CAS CO          
			28746,     //1863,    EQUITY INS CO                          
			26263,     //10104,   ERIE INSURANCE COMPANY                 
			26271,     //10105,   ERIE INSURANCE EXCHANGE                
			25712,     //1729,    ESURANCE INS CO                        
			99998,     //10156,   F B INS CO                             
			99998,     //705,     FARM AND CITY INS CO                   
			99998,     //10029,   FARM BUREAU COUNTY MUTUAL INS CO OF TX 
			99998,     //10030,   FARM BUREAU MUTUAL INS CO              
			99998,     //945,     FARM BUREAU TOWN & COUNTY INS CO OF MO 
			99998,     //10031,   FARMERS ALLIANCE MUTUAL INS CO         
			99998,     //10157,   FARMERS AUTOMOBILE INSURANCE ASSN      
			99998,     //10158,   FARMERS INS CO                         
			99998,     //10159,   FARMERS INS CO OF AZ                   
			21652,     //10032,   FARMERS INS EXCHANGE                   
			99998,     //952,     FARMERS INSURANCE OF COLUMBUS          
			99998,     //969,     FARMERS TEXAS COUNTY MUTUAL INS CO     
			20281,     //10033,   FEDERAL INS CO                         
			13935,     //10034,   FEDERATED MUTUAL INS CO                
			99998,     //10160,   FIDELITY AND CASUALTY OF NY            
			19852,     //10274,   FINANCIAL INDEMNITY CO                 
			21873,     //539,     FIREMANS FUND INS CO                   
			99998,     //10035,   FIREMANS FUND INS CO OF NE             
			99998,     //19,      FIRST GENERAL INS CO                   
			33588,     //10161,   FIRST LIBERTY INS CORP                 
			24724,     //10036,   FIRST NATIONAL INS CO OF AMERICA       
			99998,     //991,     FOREMOST COUNTY MUTAL INS CO           
			11185,     //990,     FOREMOST INS CO GRAND RAPIDS MI        
			14249,     //233,     FOUNDERS INS CO                        
			28339,     //112,     GATEWAY INS CO                         
			99998,     //10037,   GE CASUALTY INS CO                     
			99998,     //10038,   GE PROP AND CAS INS CO                 
			41491,     //27,      GEICO CASUALTY CO                      
			35882,     //10094,   GEICO GENERAL INS CO                   
			22055,     //10095,   GEICO INDEMNITY                        
			24732,     //10039,   GENERAL INS CO OF AMERICA              
			99998,     //10162,   GERMAN MUTUAL INS CO (OH)              
			99998,     //1004,    GERMANIA FIRE & CASUALTY CO            
			99998,     //10163,   GERMANIA SELECT INS CO                 
			99998,     //10164,   GHS PROPERTY & CASUALTY INS CO         
			99998,     //10165,   GLENN FALLS                            
			11312,     //10166,   GLOBE AMERICAN CASUALTY CO             
			99998,     //120,     GMAC (AKA NATIONAL GENERAL INS)                                     
			11044,     //10040,   GMAC INS CO ONLINE INC (AKA NATIONAL GENERAL ONLINE, INC)                  
			99998,     //127,     GO AMERICA                             
			22063,     //10041,   GOVERNMENT EMPLOYEES INS CO            
			10322,     //10167,   GRANGE INDEMNITY INS CO                
			99998,     //1009,    GRANGE INS ASSOCIATION                 
			14060,     //239,     GRANGE MUTUAL CASUALTY CO              
			23809,     //10168,   GRANITE STATE INS CO                   
			16691,     //31,      GREAT AMERICAN INS CO                  
			20303,     //10042,   GREAT NORTHERN INS CO                  
			99998,     //99,      GREAT TEXAS COUNTY MUTUAL INS CO       
			99998,     //1021,    GRINNELL MUTUAL REINSURANCE CO         
			99998,     //10279,   GUARANTY NATIONAL INS CO               
			99998,     //10043,   GUIDANT CASUALTY INS CO                
			99998,     //10044,   GUIDANT MUTUAL INS CO                  
			42331,     //61,      GUIDEONE AMERICA INS CO                
			42803,     //1480,    GUIDEONE ELITE INS CO                  
			15032,     //10169,   GUIDEONE MUTUAL INS CO                 
			99998,     //10170,   HAMILTON MUTUAL INS CO                 
			36064,     //10171,   HANOVER AMERICAN INS CO                
			22292,     //10106,   HANOVER INSURANCE COMPANY              
			29424,     //586,     HARTFORD CASUALTY INS CO               
			19682,     //10172,   HARTFORD FIRE INS CO                   
			37478,     //10096,   HARTFORD INS CO OF MIDWEST             
			30104,     //10097,   HARTFORD UNDERWRITERS INS CO           
			99998,     //1874,    HASTINGS MUTUAL INS CO                 
			99998,     //1571,    HAWKEYE-SECURITY INS CO                
			99998,     //10276,   HERITAGE                               
			99998,     //1032,    HOCHHEIM PRAIRIE CASUALTY INS CO       
			99998,     //36,      HOME STATE COUNTY MUTUAL INS CO        
			26638,     //1035,    HOME-OWNERS INS CO                     
			99998,     //10173,   HOOSIER INS CO                         
			22578,     //10045,   HORACE MANN INS CO                     
			11988,     //10174,   HOUSTON GENERAL INSURANCE EXCHANGE     
			99998,     //1042,    ILLINOIS FARMERS INS CO                
			23817,     //10046,   ILLINOIS NATIONAL INS CO               
			44369,     //671,     IMPERIAL FIRE AND CASUALTY INS CO      
			99998,     //39,      INDIANA FARMERS MUTUAL INS CO          
			99998,     //10175,   INDIANA INS CO                         
			22268,     //40,      INFINITY INS CO                        
			19429,     //10176,   INSURANCE COMPANY OF STATE OF PA       
			10922,     //1406,    INSUREMAX INS CO                       
			99998,     //10177,   INTEGON CASUALTY INS CO                
			22780,     //10272,   INTEGON GENERAL INS CORP               
			22772,     //10047,   INTEGON INDEMNITY CORP                 
			29742,     //10048,   INTEGON NATIONAL INS CO                
			99998,     //10178,   INTEGON PREFERRED INS CO               
			15598,     //10049,   INTERINS EXCH OF THE AUTOMOBILE CLUB   
			99998,     //1821,    KEMPER AUTO AND HOME INS CO            
			99998,     //10050,   KENTUCKY CENTRAL INS CO                
			99998,     //10179,   KENTUCKY FARM BUREAU MUTUAL INS CO     
			11681,     //1056,    KEYSTONE INS CO                        
			99998,     //122,     LEADER                                 
			99998,     //10180,   LIBERTY COUNTY MUTUAL INS CO           
			42404,     //10051,   LIBERTY INS CORP                       
			23035,     //497,     LIBERTY MUTUAL FIRE INS CO             
			99998,     //1065,    LIGHTNING ROD MUTUAL INS CO            
			33855,     //1757,    LINCOLN GENERAL                        
			99998,     //10052,   MARATHON INS CO                        
			28932,     //10053,   MARKEL AMERICAN INS CO                 
			99998,     //10107,   MARYLAND AUTOMOBILE INSURANCE FUND     
			22306,     //10181,   MASSACHUSETTS BAY INS CO               
			99998,     //10182,   MEMBERSELECT INS CO                    
			22454,     //10054,   MENDAKOTA INS CO                       
			33650,     //124,     MENDOTA INS CO                         
			11908,     //1088,    MERCURY CASUALTY COMPANY               
			29394,     //10277,   MERCURY COUNTY MUTUAL INS CO           
			23353,     //10183,   MERIDIAN SECURITY INS CO               
			40169,     //10055,   METROPOLITAN CASUALTY INS CO           
			25321,     //10056,   METROPOLITAN DRT PROP AND CAS INS CO   
			39950,     //10057,   METROPOLITAN GENERAL INS CO            
			99998,     //10184,   METROPOLITAN GROUP PROP & CAS INS CO   
			99998,     //10185,   METROPOLITAN LLOYDS INS CO OF TX       
			26298,     //232,     METROPOLITAN PROP AND CAS INS CO       
			40150,     //1926,    MGA INS CO INC                         
			99998,     //10186,   MID CENTURY/FARMERS                    
			99998,     //10187,   MID-AMERICAN FIRE AND CASUALTY CO      
			21687,     //10058,   MID-CENTURY INS CO                     
			99998,     //10188,   MID-CENTURY INS CO OF TX               
			23418,     //10189,   MID-CONTINENT CASUALTY CO              
			99998,     //48,      MIDLAND RISK                           
			23515,     //10190,   MIDWESTERN INDEMNITY CORP              
			23655,     //1121,    MODERN SERVICE INS CO                  
			14621,     //10191,   MOTORISTS MUTUAL INS CO                
			44180,     //10059,   MOUNTAIN LAUREL ASSURANCE CO (NONSTD)  
			99998,     //10192,   MUTUAL OF OMAHA                        
			99998,     //10060,   NATIONAL ALLIANCE INS CO               
			16217,     //10061,   NATIONAL FARMERS UNION P AND C CO      
			42447,     //1142,    NATIONAL GENERAL ASSURANCE CO          
			20184,     //10193,   NATIONAL MUTUAL INS CO                 
			12114,     //10194,   NATIONAL SECURITY FIRE                 
			19445,     //10195,   NATIONAL UNION FIRE INS CO PITTSBURGH  
			10723,     //10196,   NATIONWIDE ASSURANCE CO                
			23760,     //1148,    NATIONWIDE GENERAL INS CO              
			25453,     //10197,   NATIONWIDE INS CO OF AMERICA           
			23779,     //10198,   NATIONWIDE MUTUAL FIRE INS CO          
			23787,     //10098,   NATIONWIDE MUTUAL INS CO               
			37877,     //10199,   NATIONWIDE PROP & CAS INS CO           
			99998,     //1380,    NAU COUNTY INS CO                      
			23841,     //10062,   NEW HAMPSHIRE INDEMNITY                
			14788,     //10200,   NGM INS CO                             
			27740,     //10063,   NORTH POINTE INS CO                    
			36455,     //10064,   NORTHBROOK INDEMNITY CO                
			99998,     //10201,   OAK BROOK COUNTY MUTUAL INS CO         
			24074,     //1958,    OHIO CASUALTY INS CO                   
			24082,     //10065,   OHIO SECURITY INS CO                   
			99998,     //10066,   OKLAHOMA FARM BUREAU MUTUAL INS CO     
			99998,     //10202,   OKLAHOMA FARMERS UNION MUTUAL INS CO   
			99998,     //10203,   OLD AMERICAN COUNTY MUTUAL FIRE INS CO 
			99998,     //280,     OMAHA PROPERTY AND CASUALTY INS CO     
			34940,     //10204,   OMNI INDEMNITY CO                      
			39098,     //168,     OMNI INS CO                            
			99998,     //10278,   ORION AUTO                             
			99998,     //10067,   OTHER                                  
			32700,     //10068,   OWNERS INS CO                          
			20346,     //1178,    PACIFIC INDEMNITY CO                   
			99998,     //131,     PAFCO                                  
			23442,     //10205,   PATRIOT GENERAL                        
			99998,     //10206,   PEKIN                                  
			14990,     //1197,    PENNSYLVANIA NATL MUTUAL CAS INS       
			37648,     //59,      PERMANENT GENERAL                      
			22906,     //10207,   PERMANENT GENERAL ASSURANCE CORP OF OH 
			12289,     //60,      PERSONAL SERVICE INS CO                
			99998,     //10208,   PGA                                    
			99998,     //648,     PHOENIX INDEMNITY INS CO               
			25623,     //10209,   PHOENIX INS CO                         
			99998,     //10069,   PREFERRED ABSTAINERS INS CO            
			99998,     //1214,    PREFERRED RISK MUTUAL INS CO           
			24252,     //10210,   PROGRESSIVE INSURANCE           
      //24260,     //136,     PROGRESSIVE CASUALTY INS CO (NON STD)  
      //42994,     //10211,   PROGRESSIVE CLASSIC INS CO             
      //29203,     //10212,   PROGRESSIVE COUNTY MUTUAL INS CO       
      //42412,     //10213,   PROGRESSIVE GULF INS CO                
      //99998,     //10099,   PROGRESSIVE HALCYON INS CO             
      //99998,     //10214,   PROGRESSIVE HOME INS CO                
      //24279,     //10215,   PROGRESSIVE MAX INS CO                 
      //35190,     //10100,   PROGRESSIVE MOUNTAIN INS CO            
      //38628,     //10216,   PROGRESSIVE NORTHERN INS CO            
      //42919,     //10217,   PROGRESSIVE NORTHWESTERN INS CO        
      //44695,     //10218,   PROGRESSIVE PALOVERDE INS CO           
      //37834,     //10101,   PROGRESSIVE PREFERRED INS CO           
      //32786,     //10102,   PROGRESSIVE SPECIALTY INS CO           
      //21727,     //10219,   PROGRESSIVE UNIVERSAL INS CO           
			34690,     //10220,   PROPERTY & CASUALTY INS CO OF HARTFORD 
			99998,     //10070,   PRUDENTIAL COMMERCIAL INS CO           
			36447,     //1221,    PRUDENTIAL GENERAL INS CO              
			36352,     //10071,   PRUDENTIAL PROPERTY AND CASUALTY INS CO
			99998,     //1225,    RAMSEY INS CO                          
			99998,     //10072,   REGAL INS CO                           
			99998,     //1568,    RELIANCE INS CO                        
			99998,     //10073,   RELIANCE NATIONAL INDEMNITY CO         
			99998,     //10074,   RELIANCE NATIONAL INS CO               
			99998,     //10075,   RELIANCE NATIONAL INS CO OF NY         
			99998,     //1720,    RELIANT                                
			20133,     //10221,   RESPONSE WORLDWIDE DIRECT AUTO INS     
			99998,     //1232,    ROCKFORD MUTUAL INS                    
			42595,     //10222,   ROCKINGHAM CASUALTY COMPANY            
			99998,     //10076,   ROCKY MOUNTAIN FIRE AND CASUALTY CO    
			25405,     //10223,   SAFE AUTO INS CO                       
			24740,     //1921,    SAFECO INS CO OF AMERICA               
			39012,     //10077,   SAFECO INS CO OF IL                    
			99998,     //1236,    SAFECO LLOYDS INS CO                   
			24759,     //10078,   SAFECO NATIONAL INS CO                 
			12521,     //141,     SAFEWAY INS CO                         
			40460,     //274,     SAGAMORE INS CO                        
			33120,     //1247,    SECURITY NATIONAL INS CO (UNITRIN GRP) 
			11000,     //1249,    SENTINEL INS CO LTD                    
			24988,     //10224,   SENTRY INSURANCE MUTUAL COMPANY        
			99998,     //10271,   SHELBY                                 
			23361,     //1252,    SHELTER GENERAL INS CO                 
			23388,     //10079,   SHELTER MUTUAL INS CO                  
			99998,     //10080,   SKANDIA U S INS CO                     
			99998,     //65,      SOUTHERN COUNTY MUTUAL INS CO          
			18325,     //10225,   SOUTHERN FB CASUALTY INS CO            
			37141,     //1261,    SOUTHERN GENERAL                       
			99998,     //10226,   SOUTHERN GUARANTY                      
			99998,     //10227,   SOUTHERN HERITAGE                      
			19216,     //10228,   SOUTHERN INS CO                        
			26867,     //1960,    SOUTHERN INS CO OF VA                  
			22861,     //10229,   SOUTHERN PILOT                         
			99998,     //10230,   SOUTHERN TRUST                         
			12629,     //272,     SOUTHERN UNITED FIRE                   
			24775,     //10081,   ST. PAUL GUARDIAN INS CO               
			19070,     //10231,   STANDARD FIRE INS CO                   
			99998,     //1272,    STANDARD MUTUAL INS CO                 
			99998,     //10232,   STATE AND COUNTY MUTUAL FIRE INS CO    
			19530,     //1273,    STATE AUTO NATIONAL INS CO             
			25127,     //10233,   STATE AUTO P & C INS CO                
			25135,     //1383,    STATE AUTOMOBILE MUTUAL INS CO         
			99998,     //1275,    STATE FARM COUNTY MUTUAL INS CO OF TX  
			25143,     //10268,   STATE FARM FIRE AND CASUALTY CO        
			25178,     //10082,   STATE FARM MUTUAL AUTOMOBILE INS CO    
			99998,     //1633,    STATE MUTUAL INS CO                    
			99998,     //10273,   SUPERIOR                               
			22683,     //10234,   TEACHERS INS CO                        
			99998,     //10235,   TICO INS CO                            
			99998,     //71,      TIG INS CO                             
			13242,     //509,     TITAN INDEMNITY CO                     
			36269,     //10269,   TITAN INS CO                           
			18031,     //10236,   TOPA INS CO                            
			42749,     //146,     TRADERS INS CO                         
			20494,     //72,      TRANSPORTATION INS CO                  
			28188,     //10237,   TRAVCO INS CO                          
			36170,     //10238,   TRAVELERS CASUALTY COMPANY OF CT       
			36137,     //10239,   TRAVELERS COMMERCIAL INS CO            
			27998,     //10240,   TRAVELERS HOME AND MARINE INS CO       
			25666,     //10241,   TRAVELERS INDEMNITY CO OF AMERICA      
			99998,     //10083,   TRAVELERS INDEMNITY CO OF IL           
			99998,     //459,     TRAVELERS INS CO                       
			38130,     //10270,   TRAVELERS PERSONAL INS CO              
			25674,     //10242,   TRAVELERS PROP CAS CO OF AMERICA       
			36161,     //1444,    TRAVELERS PROPERTY CASUALTY INS CO     
			19887,     //73,      TRINITY UNIVERSAL INS CO               
			15954,     //10084,   TRINITY UNIVERSAL INS CO OF KS         
			27120,     //1754,    TRUMBULL INS CO                        
			40118,     //1303,    TRUSTGARD INS CO                       
			29459,     //10267,   TWIN CITY FIRE INS CO                  
			99998,     //10243,   UFB CASUALTY INS CO                    
			99998,     //10085,   UNION INS CO                           
			99998,     //10086,   UNION INS CO OF PROVIDENCE             
			35319,     //1560,    UNITED AUTOMOBILE INS CO               
			29963,     //10244,   UNITED FARM FAMILY MUTUAL INS CO       
			13021,     //10087,   UNITED FIRE AND CASUALTY CO            
			99998,     //1315,    UNITED OHIO INS CO                     
			99998,     //10088,   UNITED SECURITY INS CO                 
			25941,     //10089,   UNITED SERVICES AUTOMOBILE ASSOCIATION 
			25887,     //10090,   UNITED STATES FIDELITY AND GUARANTY CO 
			16063,     //10245,   UNITRIN AUTO AND HOME INS CO           
			99998,     //10246,   UNITRIN COUNTY MUTUAL INS CO           
			10226,     //1809,    UNITRIN DIRECT INS                     
			99998,     //8,       UNITRIN/CHARTER                        
			99998,     //10275,   UNITRIN/FIC                            
			42862,     //224,     UNIVERSAL CASUALTY                     
			99998,     //1693,    US AUTO                                
			25968,     //1458,    USAA CASUALTY INS CO                   
			99998,     //10247,   USAA COUNTY MUTUAL INS CO              
			18600,     //10103,   USAA GENERAL INDEMNITY CO              
			99998,     //10248,   USAUTO INS CO INC                      
			20508,     //10249,   VALLEY FORGE                           
			99998,     //10250,   VALLEY INS CO                          
			10644,     //10251,   VICTORIA AUTOMOBILE INS CO             
			42889,     //148,     VICTORIA FIRE AND CASUALTY             
			10105,     //10252,   VICTORIA SELECT INS CO                 
			99998,     //10253,   VICTORIA/TITAN                         
			20397,     //10091,   VIGILANT INS CO                        
			99998,     //10254,   VIKING COUNTY MUTUAL INS CO            
			13137,     //10092,   VIKING INS CO OF WI                    
			99998,     //10255,   VIRGINIA FARM BUREAU MUTUAL INS CO     
			99998,     //10256,   VIRGINIA FB TOWN AND COUNTRY INS CO    
			99998,     //10257,   VIRGINIA MUTUAL INS CO                 
			99998,     //1770,    VISION                                 
			99998,     //1331,    WAYNE MUTUAL INS CO                    
			44393,     //10093,   WEST AMERICAN INS CO                   
			99998,     //10258,   WEST BEND MUTUAL INS CO                
			27871,     //10259,   WESTERN AGRICULTURAL INS CO            
			99998,     //10260,   WESTERN RESERVE MUTUAL CASUALTY        
			37770,     //1344,    WESTERN UNITED INS CO                  
			24112,     //10261,   WESTFIELD INS CO                       
			24120,     //10262,   WESTFIELD NATIONAL INS CO              
			99998,     //10263,   WINDSOR AUTO                           
			99998,     //150,     WINDSOR INS CO                         
			99998,     //10264,   WOLVERINE MUTUAL INS CO                
			13250,     //768,     WORKMENS AUTO INS CO                   
			27090,     //10265,   YOUNG AMERICA INS CO                   
      23876,     //10280    MAPFRE INS CO                                                
		};

    public static readonly string[] CountryOfOriginNames =
			{
				"None",
				"International",
				"Canada",
				"Mexico",
				"Poland",
        "Matricula",
        "Other"
			};

    public static readonly string[] CountryOfOriginChars =
			{
				"NONE",
				"INT",
				"CA",
				"MX",
				"PL",
        "MA",
        "ZZ"
			};

    [Obsolete("renamed to LimitShownText. Please update code in 2nd half of 2009 to use LimitShownText instead.")]
    public const string LimShownStr = " {0} limit shown.";
    public const string LimitShownText = " {0} limit shown.";

    [Obsolete("renamed to LimitsShownText. Please update code in 2nd half of 2009 to use LimitsShownText instead.")]
    public const string LimsShownStr = " {0} limits shown.";
    public const string LimitsShownText = " {0} limits shown.";

    public const string LimitsToMatchShownText = " {0} limits shown in order to match {1} limits.";
    public const string LimitToMatchShownText = " {0} limit shown in order to match {1} limits.";

    [Obsolete("renamed to DeductibleShownText. Please update code in 2nd half of 2009 to use DeductibleShownText instead.")]
    public const string DedShownStr = " {0} deductible shown.";
    public const string DeductibleShownText = " {0} deductible shown.";

    public const string DeductiblesShownText = " {0} deductibles shown.";
    public const string CustomEquipmentValueText = "${0} custom equipment value rated.";

    [Obsolete("renamed to InvalidLimitText. Please update code in 2nd half of 2009 to use InvalidLimitText instead.")]
    public const string InvalidLimitStr = "Invalid {0} Limit Entered.";
    public const string InvalidLimitText = "Invalid {0} Limit Entered.";

    [Obsolete("renamed to InvalidLimitsText. Please update code in 2nd half of 2009 to use InvalidLimitsText instead.")]
    public const string InvalidLimitsStr = "Invalid {0} Limits Entered.";
    public const string InvalidLimitsText = "Invalid {0} Limits Entered.";

    [Obsolete("renamed to InvalidDeductibleText. Please update code in 2nd half of 2009 to use InvalidDeductibleText instead.")]
    public const string InvalidDedStr = "Invalid {0} Deductible Entered.";
    public const string InvalidDeductibleText = "Invalid {0} Deductible Entered.";

    public const string InvalidDeductiblesText = "Invalid {0} Deductibles Entered.";

    [Obsolete("renamed to CoverageNotRatedByCompanyText. Please update code in 2nd half of 2009 to use CoverageNotRatedByCompanyText instead.")]
    public const string CoverageNotRatedByCompanyStr = "{0} was not rated by the company.";
    public const string CoverageNotRatedByCompanyText = "{0} was not rated by the company.";

    public const int UnlimitedLimitVal = 2147483646;
    public const int BlankLimitVal = 2147483645;
    public const string NoCoverageString = "None";
    public const string CSLString = "CSL";
    public const string BlankLimitString = "Yes";
    public const string UnlimitedString = "Unlimited";
    public const double IncludedPremium = 4294967295;

    public const int MinNAICCode = 1;
    public const int MaxNAICCode = 99999;
    public const int NAICCodeOther = 99998;

    public const int RealTimeRateIndicator = 99999999;
    public const int HybridRealTimeRateIndicator = 99999998;
    public const int DotNetManufacturedIndicator = 99999996;
    public const int MulticoManufacturedIndicator = 99999995;
    public const int MulticoRealTimeIndicator = 99999994;

    // Generic Agency Management System company id.
    public const int AgencyManagementSystemIndicator = 99999997;
    // InsurancePro company id.
    public const int InsuranceProCompanyID = 5049699;

    /// <summary>
    /// List of all Agency Management System company ids.
    /// </summary>
    public static readonly int[] AgencyManagementCompanyGroup =
    {
      AgencyManagementSystemIndicator,
      InsuranceProCompanyID
    };

    /// <summary>
    /// takes a delphi insurance line (an integer) and translates it to a .net insurance line (enum type value)
    /// </summary>
    /// <param name="tagValue">the tag value (integer)</param>
    /// <returns>.net insurance line</returns>
    public static InsuranceLine ConvertFromDelphiInsuranceLine(object tagValue)
    {
      int delphiValue = ITCConvert.ToInt32(tagValue, -1);
      switch (delphiValue)
      {
        case 1:
          return InsuranceLine.PersonalAuto;
        case 3:
          return InsuranceLine.CommercialAuto;
        case 4:
          return InsuranceLine.Homeowners;
        case 5:
          return InsuranceLine.DwellingFire;
        case 8:
          return InsuranceLine.Motorcycle;
        case 9:
          return InsuranceLine.Flood;
        case 10:
          return InsuranceLine.FLCommWind;
        case 11:
          return InsuranceLine.FLCommProp;
        default:
          return InsuranceLine.PersonalAuto;
      }
    }

    /// <summary>
    /// converts an insurance line to its short string representation. For example,
    /// PersonalAuto becomes "PA"
    /// </summary>
    /// <param name="insuranceLine">line of insurance</param>
    /// <returns>short-string representation of the line of insurance</returns>
    public static string InsuranceLineToShortString(InsuranceLine insuranceLine)
    {
      switch (insuranceLine)
      {
        case InsuranceLine.CommercialAuto: return "CA";
        case InsuranceLine.DwellingFire: return "DF";
        case InsuranceLine.FLCommProp: return "FP";
        case InsuranceLine.FLCommWind: return "FW";
        case InsuranceLine.Flood: return "FL";
        case InsuranceLine.Homeowners: return "HO";
        case InsuranceLine.MultipleLines: return "";
        case InsuranceLine.PersonalAuto: return "PA";
        case InsuranceLine.Umbrella: return "UM";
        case InsuranceLine.Motorcycle: return "MC";
        default: return "";
      }
    }

    /// <summary>
    /// Converts an insurance line string into it's enum representation.
    /// </summary>
    /// <param name="line">The string containing the insurance line.</param>
    /// <returns>The InsuranceLine enum corresponding to the provided string.</returns>
    public static InsuranceLine ShortStringToInsuranceLine(string line)
    {
      switch (line.ToUpper().Trim())
      {
        case "CA": return InsuranceLine.CommercialAuto;
        case "DF": return InsuranceLine.DwellingFire;
        case "FP": return InsuranceLine.FLCommProp;
        case "FW": return InsuranceLine.FLCommWind;
        case "FL": return InsuranceLine.Flood;
        case "HO": return InsuranceLine.Homeowners;
        case "": return InsuranceLine.MultipleLines;
        case "AU":
        case "PA": return InsuranceLine.PersonalAuto;
        case "UM": return InsuranceLine.Umbrella;
        case "MC": return InsuranceLine.Motorcycle;
        default: return InsuranceLine.MultipleLines;
      }
    }

    /// <summary>
    /// Insurance line short description.
    /// </summary>
    /// <param name="insuranceLine">The insurance line.</param>
    /// <returns>A short description of the insurance line.</returns>
	  public static string InsuranceLineShortDescription(InsuranceLine insuranceLine)
	  {
	    switch (insuranceLine)
	    {
        case InsuranceLine.PersonalAuto:
	        return "Auto";
          case InsuranceLine.Homeowners:
	        return "Home";
        case InsuranceLine.Motorcycle:
	        return "Cycle";
        case InsuranceLine.DwellingFire:
	        return "Fire";
        default:
	        return string.Empty;
	    }
	  }

    /// <summary>
    /// Returns an array of states that use
    /// "towing" instead of "roadside".
    /// </summary>
    public static readonly USState[] TowingStates = new USState[]
    {
       USState.Arizona, 
       USState.Arkansas, 
       USState.California, 
       USState.Colorado, 
       USState.Illinois, 
       USState.Indiana, 
       USState.Kansas, 
       USState.Kentucky,                                     
       USState.Louisiana, 
       USState.Missouri, 
       USState.Nevada, 
       USState.NewMexico, 
       USState.Ohio, 
       USState.Oklahoma, 
       USState.Tennessee, 
       USState.Texas,
       USState.Virginia, 
       USState.Wisconsin, 
       USState.NoneSelected
    };

    public const string ErrorMessage_LobNotSupported = "Line of Business not supported {0}";

    /// <summary>
    /// The various reasons a particular carrier was not bound.
    /// </summary>
    public enum CarrierReasonNotBound
    {
      [Description("Policy bound")]
      Bound,
      [Description("Premium changed due to Underwriting/Reports Ordered")]
      PremiumChanged,
      [Description("Unacceptable Risk after Underwriting/Reports Ordered")]
      UnacceptableRisk,
      [Description("Coverage needed not offered by Company")]
      CoverageNotOffered,
      [Description("Reason not listed")]
      ReasonNotListed
    }

    /// <summary>
    /// Text Options for Effective Date on Template Entry Pages
    /// </summary>
    public static string[] EffectiveDateTemplateOptionNames =
    {
    "",
    "Today's Date",
    "Tomorrow",
    "2 Days In Advance",
    "3 Days In Advance",
    "4 Days In Advance",
    "5 Days In Advance",
    "6 Days In Advance",
    "7 Days In Advance",
    "8 Days In Advance"
  };
    /// <summary>
    /// Value Options for Effective Date on Template Entry Pages
    /// </summary>

    public static string[] EffectiveDateTempationOptionValues =
    {
    "",
    "0",
    "1",
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8"
  };

		/// <summary>
		/// Health insurance carrier.  Used for MI PIP.
		/// </summary>
		public enum MIHealthInsuranceCarrier
		{
			[Description("Medicare")]
			MCare,
			[Description("Medicaid")]
			MCaid,
			[Description("Qualified Coverage")]
			QualCovg,
			[Description("Not Qualified Coverage")]
			NotQualCovg
		}

		/// <summary>
		/// Health insurance carrier strings.  Used for MI PIP.
		/// </summary>
		public static string[] MIHealthInsuranceCarrierStrings =
		{
			"MCARE",
			"MCAID",
			"QUAL",
			"NOTQUAL"
		};

	}
}
//turn back on xml comment warnings 
#pragma warning restore 1591
