using System;
using System.ComponentModel;

namespace TurboRater
{
  /// <summary>
  /// Media type used for http requests.
  /// </summary>
  public enum MediaType
  {
    Json,
    Xml,
  }

  /// <summary>
  /// Defines different client-side modes for Caesar rating.
  /// </summary>
  public enum CaesarMode
  {
    /// <summary>
    /// Normal mode, goes all the way to the end and uploads the premium to TWE.
    /// </summary>
    [Description("Normal")]
    Normal,
    /// <summary>
    /// For bridging only, goes to the end but does not close the Caesar client, nor does it upload anything.
    /// </summary>
    [Description("BridgeOnly")]
    BridgeOnly
  }

  /// <summary>
  /// Did the user rate this policy as full rate, assumed credit value, or don't rate?
  /// </summary>
  public enum RateOption
  {
    Assumed,
    Full,
    DontRate
  }

  public enum SR22Reason
  {
    NoInsurance,
    AccidentWithDeath,
    AccidentNoInsurance,
    MultipleRecklessMajorRelated,
    AlcoholDrugRelated,
    MandatoryInsuranceSupervision,
    EmancipatedMinor,
    Other,
    Blank
  }

  public enum InterfaceMessageType
  {
    [Description("Information")]
    Information,
    [Description("Warning")]
    Warning,
    [Description("Error")]
    Error,
    [Description("Success")]
    Success
  }

  public enum Relation
  {
    Insured,
    Spouse,
    Child,
    OtherRelated,
    OtherNonRelated,
    Parent
  }

  public enum Employment
  {
    Employed,
    Unemployed,
    Military,
    Retired,
    Student,
    HomeMaker,
    SelfEmployed
  }

  public enum Gender
  {
    Male,
    Female,
    NonBinary
  }

  public enum SortOrder
  {
    Ascending,
    Descending
  }

  public enum EducationLevel
  {
    [Description("None")]
    None,
    [Description("BachelorsDegree")]
    BachelorsDegree,
    [Description("MastersDegree")]
    MastersDegree,
    [Description("Doctorate")]
    DoctorateDegree,
    [Description("DoctorMedicine")]
    MedicalDegree,
    [Description("LawDegree")]
    LawDegree,
    [Description("LessThanHighSchoolDiploma")]
    NoHighSchoolDiploma,
    [Description("HighSchool")]
    HighSchoolDiploma,
    [Description("AssociatesDegree")]
    AssociatesDegree,
    [Description("SomeCollegeNoDegree")]
    SomeCollege,
    [Description("VocationalTechnical")]
    VocationalDegree
  }

  public enum Duration
  {
    Years,
    Months,
    Days,
    Hours,
    Minutes,
    Seconds,
    Milliseconds
  }

  public enum USState
  {
    NoneSelected,
    Alabama,
    Alaska,
    AmericanSamoa,
    Arizona,
    Arkansas,
    California,
    Colorado,
    Connecticut,
    Delaware,
    DistrictOfColumbia,
    Florida,
    Georgia,
    Guam,
    Hawaii,
    Idaho,
    Illinois,
    Indiana,
    Iowa,
    Kansas,
    Kentucky,
    Louisiana,
    Maine,
    Maryland,
    Massachusetts,
    Michigan,
    Minnesota,
    Mississippi,
    Missouri,
    Montana,
    Nebraska,
    Nevada,
    NewHampshire,
    NewJersey,
    NewMexico,
    NewYork,
    NorthCarolina,
    NorthDakota,
    Ohio,
    Oklahoma,
    Oregon,
    Pennsylvania,
    PuertoRico,
    RhodeIsland,
    SouthCarolina,
    SouthDakota,
    Tennessee,
    Texas,
    Utah,
    Vermont,
    VirginIslands,
    Virginia,
    Washington,
    WestVirginia,
    Wisconsin,
    Wyoming
  }

  public enum Maritals
  {
    Married,
    Single,
    Divorced,
    Widowed,
    Separated,
    DomesticPartner,
    CommonLaw
  };

  public enum YesNoBlank
  {
    Blank,
    No,
    Yes
  }

  /// <summary>
  /// as of 7/08, used by the os server for searching for quotes.
  /// ex: search for any quote where the insured's first name starts with "bob"
  /// </summary>
  public enum SearchType
  {
    StartsWith,
    EndsWith,
    ExactMatch,
    AnyPart
  }

  public sealed class ITCConstants
  {
    /// <summary>
    /// Hiding the default constructor
    /// </summary>
    private ITCConstants()
    {
    }

    /// <summary>
    /// Converts a boolean value to either a "Y" or "N".
    /// </summary>
    /// <param name="value">The boolean value to convert</param>
    /// <returns>"Y" if true, "N" if false</returns>
    public static string BoolToYN(bool value)
    {
      if (value)
        return "Y";
      return "N";
    }

    /// <summary>
    /// Converts a boolean value to either a "Yes" or "No".
    /// </summary>
    /// <param name="value">The boolean value to convert</param>
    /// <returns>"Yes" if true, "No" if false</returns>
    public static string BoolToYesNo(bool value)
    {
      if (value)
        return "Yes";
      return "No";
    }

    /// <summary>
    /// Checks if a date is valid. Invalid dates are one of these two constants:
    /// InvalidDate: 1/1/1753. This value is used by our web/.net stuff
    /// InvalidWindowsDate: 4/7/3000. This value is used by our windows stuff.
    ///   we need to reference this because of bridged tt2 files sent from the client.
    /// </summary>
    /// <param name="value">The DateTime value to check</param>
    /// <returns>False if the date/time is one of the Invalid values,
    /// otherwise true</returns>
    public static bool IsValidDate(DateTime value)
    {
      return ((value.Date != InvalidWindowsDate) && (value.Date != InvalidDate));
    }

    public const string CompanyDomain = "turborater.com";
    public const string CompanyName = "Insurance Technologies Corporation";
    public const string ShortCompanyName = "ITC";
    public const int WM_KEYDOWN = 0x0100;

    public static readonly int InvalidNum = -1;

    //minimum date/time value allowed in sql server
    public static readonly DateTime InvalidDate = DateTime.Parse("1/1/1753").Date;
    public static readonly DateTime InvalidWindowsDate = DateTime.Parse("04/07/3000").Date;

    public static string[] StateValues
    {
      get
      {
        return Enum.GetNames(typeof(USState));
      }
    }

    public static readonly string[] StateNames = 
      {
        "None Selected",
        "Alabama",
        "Alaska",
				"American Samoa",
        "Arizona",
        "Arkansas",
        "California",
        "Colorado",
        "Connecticut",
        "Delaware",
				"District of Columbia",
        "Florida",
        "Georgia",
				"Guam",
        "Hawaii",
        "Idaho",
        "Illinois",
        "Indiana",
        "Iowa",
        "Kansas",
        "Kentucky",
        "Louisiana",
        "Maine",
        "Maryland",
        "Massachusetts",
        "Michigan",
        "Minnesota",
        "Mississippi",
        "Missouri",
        "Montana",
        "Nebraska",
        "Nevada",
        "New Hampshire",
        "New Jersey",
        "New Mexico",
        "New York",
        "North Carolina",
        "North Dakota",
        "Ohio",
        "Oklahoma",
        "Oregon",
        "Pennsylvania",
				"Puerto Rico",
        "Rhode Island",
        "South Carolina",
        "South Dakota",
        "Tennessee",
        "Texas",
        "Utah",
        "Vermont",
				"Virgin Islands",
        "Virginia",
        "Washington",
        "West Virginia",
        "Wisconsin",
        "Wyoming"
      };
    public static readonly string[] StateAbbreviations = 
      {
        "",
        "AL",
        "AK",
				"AS",
        "AZ",
        "AR",
        "CA",
        "CO",
        "CT",
        "DE",
				"DC",
        "FL",
        "GA",
				"GU",
        "HI",
        "ID",
        "IL",
        "IN",
        "IA",
        "KS",
        "KY",
        "LA",
        "ME",
        "MD",
        "MA",
        "MI",
        "MN",
        "MS",
        "MO",
        "MT",
        "NE",
        "NV",
        "NH",
        "NJ",
        "NM",
        "NY",
        "NC",
        "ND",
        "OH",
        "OK",
        "OR",
        "PA",
				"PR",
        "RI",
        "SC",
        "SD",
        "TN",
        "TX",
        "UT",
        "VT",
				"VI",
        "VA",
        "WA",
        "WV",
        "WI",
        "WY"
      };

    public static readonly string[] YesNoNames =
      {
        "No",
        "Yes"
      };

    public static readonly string[] GLYesNoNames =
      {
        "GlNo",
        "GlYes"
      };

    public static readonly string[] TrueFalseNames =
      {
        false.ToString().ToLower(),
        true.ToString().ToLower()
      };

    public static readonly string[] MaritalNames = 
      {
        "Married",
        "Single",
        "Divorced",
        "Widowed",
        "Separated",
        "Domestic Partner",
        "Common Law"
      };

    public static readonly string[] GLMaritalNames = 
      {
        "GlMarried",
        "GlSingle",
        "GlDivorced",
        "GlWidowed",
        "GlSeparated",
        "GlDomesticPartner",
        "GlCommonLaw"
      };

    public static readonly string[] MaritalChars = 
      {
        "M",
        "S",
        "D",
        "W",
        "E",
        "C",
        "L"
      };

    public static readonly string[] RatedStatusNames =
    {
      "Ignored",
      "Rated"
    };

    public static readonly string[] RatedStatusChars =
    {
      "I",
      "R"
    };

    public static readonly string[] EmploymentNames =
		{
			"Employed",
			"Unemployed",
			"Military",
			"Retired",
			"Student",
			"HomeMaker",
			"Self Employed"
		};

    public static readonly string[] EmploymentChars =
		{
			"E",
			"U",
			"M",
			"R",
			"S",
			"H",
			"F"
		};

    public static readonly string[] YesNoBlankTypeNames = 
    {
      "",
      "No",
      "Yes"
    };

    public static readonly string[] YesNoBlankTypeChars = 
      {
        "B",
        "N",
        "Y"
      };

    public static readonly string[] RelationNames =
		{
			"Insured",
			"Spouse",
			"Child",
			"Other Related",
			"Other Non-Related",
			"Parent"
		};

    public static readonly string[] GLRelationNames =
		{
			"GlInsured",
			"GlSpouse",
			"GlChild",
			"GlOtherRelated",
			"GlOtherNonRelated",
			"GlParent"
		};

    public static readonly string[] RelationChars =
		{
			"I",
			"S",
			"C",
			"R",
			"N",
			"P"
		};

    public static readonly string[] GenderNames = 
		{
      "Male",
      "Female",
      "Non-Binary"
    };

    public static readonly string[] GLGenderNames = 
		{
      "GlMale",
      "GlFemale",
      "GlNonBinary"
    };

    public static readonly string[] GenderChars = 
		{
      "M",
      "F",
      "X"
    };

    public static readonly string[] EducationLevelNames =
    {
      "",
      "Bachelors Degree",
      "Masters Degree",
      "Ph. D/Doctorate",
      "Medical Degree",
      "Law Degree",
      "No High School Diploma",
      "High School Diploma",
      "Associates Degree",
      "Some College - No Degree",
      "Vocational/Technical Degree"
    };

    public static readonly string[] EducationLevelChars =
    {
      " ",
      "B",
      "S",
      "P",
      "M",
      "L",
      "N",
      "H",
      "A",
      "C",
      "V"
    };

    public static readonly string[] SR22ReasonNames =
		{
			"No Insurance",
			"Accident with Death",
			"Accident with No Insurance",
			"Multiple Reckless/Majors",
			"Drug/Alcohol Related",
			"Mandatory Insurance Supervision",
      "Emancipated Minor",
			"Other",
      string.Empty
		};

    public static readonly string[] SR22ReasonChars =
		{
			"N",
			"A",
			"I",
			"M",
			"D",
			"S",
      "E",
			"O",
      " "
		};

    public const string BlankGuidString = "00000000000000000000000000000000";
    public static readonly System.Guid BlankGuid = new Guid(BlankGuidString);

    public const string NonMatchingArrayError = "Character array size does not match name array size.";

    /// <summary>
    /// ITC (Progressive/GMAC) Industry Values.
    /// </summary>
    public static readonly string[] IndustryChars =
    {
      "01",
      "02",
      "03",
      "04",
      "AA",
      "AB",
      "AC",
      "AD",
      "AE",
      "AF",
      "AG",
      "AH",
      "AJ",
      "AK",
      "AL",
      "AM",
      "AN",
      "AP",
      "AQ",
      "AR",
      "AS",
      "AT"
    };

    /// <summary>
    /// ITC (Progressive/GMAC) Industry Descriptions.
    /// </summary>
    public static readonly string[] IndustryNames =
    {
      "Homemaker(full-time)",                       //01
      "Retired(full-time)",                         //02
      "Unemployed",                                 //03
      "Student(full-time)",                         //04
      "Agriculture/Forestry/Fishing",               //AA
      "Art/Design/Media",                           //AB
      "Banking/Finance/Real Estate",                //AC
      "Business/Sales/Office",                      //AD
      "Construction/Energy/Mining",                 //AE
      "Education/Library",                          //AF
      "Engineer/Architect/Science/Math",            //AG
      "Food Service/Hotel Services",                //AH
      "Government/Military",                        //AJ
      "Information Technology",                     //AK
      "Insurance",                                  //AL
      "Legal/Law Enforcement/Security",             //AM
      "Medical/Social Services/Religion",           //AN
      "Personal Care/Service",                      //AP
      "Production/Manufacturing",                   //AQ
      "Repair/Maintenance/Grounds",                 //AR
      "Sports/Recreation",                          //AS
      "Travel/Transportation/Storage"               //AT
    };

    /// <summary>
    /// ITC (Progressive/GMAC) Occupation Codes.
    /// The AcordExportCodes list is the same length, if modifying
    /// this list, the AcordExportCodes must also be modified in the
    /// same indexes so that there is an equivalent mapping.
    /// </summary>
    public static readonly string[] OccupationChars =
    {
      "010",
      "020",
      "030",
      "040",
      "AA0",
      "AA1",
      "AA2",
      "AA3",
      "AA4",
      "AA5",
      "AA6",
      "AA7",
      "AA8",
      "AA9",
      "AAA",
      "AAB",
      "AAC",
      "AAD",
      "AAE",
      "AAF",
      "AAZ",
      "AB0",
      "AB1",
      "AB2",
      "AB3",
      "AB4",
      "AB5",
      "AB6",
      "AB7",
      "AB8",
      "AB9",
      "ABA",
      "ABB",
      "ABC",
      "ABD",
      "ABE",
      "ABF",
      "ABG",
      "ABH",
      "ABJ",
      "ABK",
      "ABZ",
      "AC0",
      "AC1",
      "AC2",
      "AC3",
      "AC4",
      "AC5",
      "AC6",
      "AC7",
      "AC8",
      "AC9",
      "ACA",
      "ACB",
      "ACC",
      "ACD",
      "ACE",
      "ACF",
      "ACG",
      "ACH",
      "ACJ",
      "ACK",
      "ACL",
      "ACM",
      "ACN",
      "ACP",
      "ACQ",
      "ACR",
      "ACZ",
      "AD0",
      "AD1",
      "AD2",
      "AD3",
      "AD4",
      "AD5",
      "AD6",
      "AD7",
      "AD8",
      "AD9",
      "ADA",
      "ADB",
      "ADC",
      "ADD",
      "ADE",
      "ADF",
      "ADG",
      "ADH",
      "ADJ",
      "ADK",
      "ADL",
      "ADM",
      "ADN",
      "ADP",
      "ADQ",
      "ADZ",
      "AE0",
      "AE1",
      "AE2",
      "AE3",
      "AE4",
      "AE5",
      "AE6",
      "AE7",
      "AE8",
      "AE9",
      "AEA",
      "AEB",
      "AEC",
      "AED",
      "AEE",
      "AEF",
      "AEG",
      "AEH",
      "AEJ",
      "AEK",
      "AEL",
      "AEM",
      "AEN",
      "AEP",
      "AEQ",
      "AER",
      "AES",
      "AET",
      "AEZ",
      "AF0",
      "AF1",
      "AF2",
      "AF3",
      "AF4",
      "AF5",
      "AF6",
      "AF7",
      "AF8",
      "AF9",
      "AFA",
      "AFB",
      "AFC",
      "AFD",
      "AFE",
      "AFF",
      "AFZ",
      "AG0",
      "AG1",
      "AG2",
      "AG3",
      "AG4",
      "AG5",
      "AG6",
      "AG7",
      "AG8",
      "AG9",
      "AGA",
      "AGB",
      "AGC",
      "AGD",
      "AGE",
      "AGF",
      "AGG",
      "AGH",
      "AGJ",
      "AGK",
      "AGZ",
      "AH0",
      "AH1",
      "AH2",
      "AH3",
      "AH4",
      "AH5",
      "AH6",
      "AH7",
      "AH8",
      "AH9",
      "AHA",
      "AHB",
      "AHC",
      "AHD",
      "AHE",
      "AHF",
      "AHG",
      "AHH",
      "AHJ",
      "AHK",
      "AHZ",
      "AJ0",
      "AJ1",
      "AJ2",
      "AJ3",
      "AJ4",
      "AJ5",
      "AJ6",
      "AJ7",
      "AJ8",
      "AJ9",
      "AJA",
      "AJB",
      "AJC",
      "AJD",
      "AJE",
      "AJF",
      "AJG",
      "AJH",
      "AJJ",
      "AJK",
      "AJL",
      "AJM",
      "AJZ",
      "AK0",
      "AK1",
      "AK2",
      "AK3",
      "AK4",
      "AK5",
      "AK6",
      "AK7",
      "AK8",
      "AK9",
      "AKA",
      "AKB",
      "AKC",
      "AKD",
      "AKE",
      "AKF",
      "AKG",
      "AKZ",
      "AL0",
      "AL1",
      "AL2",
      "AL3",
      "AL4",
      "AL5",
      "AL6",
      "AL7",
      "AL8",
      "AL9",
      "ALA",
      "ALB",
      "ALC",
      "ALD",
      "ALE",
      "ALF",
      "ALG",
      "ALH",
      "ALZ",
      "AM0",
      "AM1",
      "AM2",
      "AM3",
      "AM4",
      "AM5",
      "AM6",
      "AM7",
      "AM8",
      "AM9",
      "AMA",
      "AMB",
      "AMC",
      "AMD",
      "AME",
      "AMF",
      "AMG",
      "AMH",
      "AMJ",
      "AMK",
      "AML",
      "AMM",
      "AMN",
      "AMP",
      "AMZ",
      "AN0",
      "AN1",
      "AN2",
      "AN3",
      "AN4",
      "AN5",
      "AN6",
      "AN7",
      "AN8",
      "AN9",
      "ANA",
      "ANB",
      "ANC",
      "AND",
      "ANE",
      "ANF",
      "ANG",
      "ANH",
      "ANJ",
      "ANK",
      "ANL",
      "ANM",
      "ANN",
      "ANP",
      "ANQ",
      "ANR",
      "ANS",
      "ANT",
      "ANU",
      "ANZ",
      "AP0",
      "AP1",
      "AP2",
      "AP3",
      "AP4",
      "AP5",
      "AP6",
      "AP7",
      "AP8",
      "APZ",
      "AQ0",
      "AQ1",
      "AQ2",
      "AQ3",
      "AQ4",
      "AQ5",
      "AQ6",
      "AQ7",
      "AQ8",
      "AQ9",
      "AQA",
      "AQB",
      "AQC",
      "AQD",
      "AQE",
      "AQF",
      "AQG",
      "AQH",
      "AQZ",
      "AR0",
      "AR1",
      "AR2",
      "AR3",
      "AR4",
      "AR5",
      "AR6",
      "AR7",
      "AR8",
      "AR9",
      "ARZ",
      "AS0",
      "AS1",
      "AS2",
      "AS3",
      "AS4",
      "AS5",
      "AS6",
      "AS7",
      "AS8",
      "AS9",
      "ASA",
      "ASB",
      "ASC",
      "ASD",
      "ASE",
      "ASF",
      "ASG",
      "ASH",
      "ASZ",
      "AT0",
      "AT1",
      "AT2",
      "AT3",
      "AT4",
      "AT5",
      "AT6",
      "AT7",
      "AT8",
      "AT9",
      "ATA",
      "ATB",
      "ATC",
      "ATD",
      "ATE",
      "ATF",
      "ATG",
      "ATH",
      "ATJ",
      "ATK",
      "ATL",
      "ATM",
      "ATN",
      "ATP",
      "ATZ"
    };

    /// <summary>
    /// ITC (Progressive/GMAC) Occupation Descriptions.
    /// </summary>
    public static readonly string[] OccupationNames = 
    {
      "Homemaker(full-time)",                        //010
      "Retired(full-time)",                          //020
      "Unemployed",                                  //030
      "Student(full-time)",                          //040
      "Agriculture Inspector/Grader",                //AA0
      "Arborist",                                    //AA1
      "Clerk",                                       //AA2
      "Equipment Operator",                          //AA3
      "Farm/Ranch Owner",                            //AA4
      "Farm/Ranch Worker",                           //AA5
      "Fisherman",                                   //AA6
      "Florist",                                     //AA7
      "Laborer/Worker",                              //AA8
      "Landscaper",                                  //AA9
      "Landscaping/Nursery Worker",                  //AAA
      "Logger",                                      //AAB
      "Mill Worker",                                 //AAC
      "Ranger",                                      //AAD
      "Supervisor",                                  //AAE
      "Timber Grader/Scaler",                        //AAF
      "Other",                                       //AAZ
      "Actor",                                       //AB0
      "Administrative Assistant",                    //AB1
      "Announcer/Broadcaster",                       //AB2
      "Artist/Animator",                             //AB3
      "Author/Writer",                               //AB4
      "Choreography/Dancer",                         //AB5
      "Clerk",                                       //AB6
      "Composer/Director",                           //AB7
      "Curator",                                     //AB8
      "Designer",                                    //AB9
      "Editor",                                      //ABA
      "Journalist/Reporter",                         //ABB
      "Musician/Singer",                             //ABC
      "Photographer",                                //ABD
      "Printer",                                     //ABE
      "Producer",                                    //ABF
      "Production Crew",                             //ABG
      "Projectionist",                               //ABH
      "Receptionist/Secretary",                      //ABJ
      "Ticket Sales/Usher",                          //ABK
      "Other",                                       //ABZ
      "Accountant/Auditor",                          //AC0
      "Administrative Assistant",                    //AC1
      "Analyst",                                     //AC2
      "Appraiser-Real Estate",                       //AC3
      "Bookkeeper",                                  //AC4
      "Broker",                                      //AC5
      "Branch Manager",                              //AC6
      "Clerk",                                       //AC7
      "Collections",                                 //AC8
      "Consultant",                                  //AC9
      "Controller",                                  //ACA
      "CSR/Teller",                                  //ACB
      "Director/Administrator",                      //ACC
      "Executive",                                   //ACD
      "Financial Advisor",                           //ACE
      "Investment Banker",                           //ACF
      "Investor",                                    //ACG
      "Loan/Escrow Processor",                       //ACH
      "Manager-Credit/Loan",                         //ACJ
      "Manager-Portfolio/Production",                //ACK
      "Manager-Property",                            //ACL
      "Realtor",                                     //ACM
      "Receptionist/Secretary",                      //ACN
      "Sales Agent/Representative",                  //ACP
      "Trader Financial Instruments",                //ACQ
      "Underwriter",                                 //ACR
      "Other",                                       //ACZ
      "Account Executive",                           //AD0
      "Administrative Assistant",                    //AD1
      "Buyer",                                       //AD2
      "Cashier/Checker",                             //AD3
      "Clerk-Office",                                //AD4
      "Consultant",                                  //AD5
      "Customer Service Representative",             //AD6
      "Director/Administrator",                      //AD7
      "Executive",                                   //AD8
      "H.R. Representative",                         //AD9
      "Manager-Department/Store",                    //ADA
      "Manager-District",                            //ADB
      "Manager-Finance/Insurance",                   //ADC
      "Manager-General Operations",                  //ADD
      "Manager-H.R./Public Relations",               //ADE
      "Manager-Marketing/Sales",                     //ADF
      "Manager/Supervisor-Office",                   //ADG
      "Marketing Researcher",                        //ADH
      "Messenger/Courier",                           //ADJ
      "Receptionist/Secretary",                      //ADK
      "Sales-Counter/Rental",                        //ADL
      "Sales-Homebased",                             //ADM
      "Sales-Manufacture Rep",                       //ADN
      "Sales-Retail/Wholesale",                      //ADP
      "Sales-Route/Vendor",                          //ADQ
      "Other",                                       //ADZ
      "Appraiser-Real Estate",                       //AE0
      "Boiler Operator/Maker",                       //AE1
      "Bricklayer/Mason",                            //AE2
      "Carpenter",                                   //AE3
      "Carpet Installer",                            //AE4
      "Concrete Worker",                             //AE5
      "Construction-Project Manager",                //AE6
      "Construction Worker",                         //AE7
      "Contractor",                                  //AE8
      "Crane Operator",                              //AE9
      "Electrician/Linesman",                        //AEA
      "Elevator Technician/Installer",               //AEB
      "Equipment Operator",                          //AEC
      "Floor Layer/Finisher",                        //AED
      "Foreman/Supervisor",                          //AEE
      "Handyman",                                    //AEF
      "Heat/Air Technician",                         //AEG
      "Inspector",                                   //AEH
      "Laborer/Worker",                              //AEJ
      "Metalworker",                                 //AEK
      "Miner",                                       //AEL
      "Oil/Gas Driller/Rig Operator",                //AEM
      "Painter",                                     //AEN
      "Plaster/Drywall/Stucco",                      //AEP
      "Plumber",                                     //AEQ
      "Roofer",                                      //AER
      "Utility Worker",                              //AES
      "Welder",                                      //AET
      "Other",                                       //AEZ
      "Administrative Assistant",                    //AF0
      "Audio-Visual Tech",                           //AF1
      "Child/Daycare Worker",                        //AF2
      "Clerk",                                       //AF3
      "Counselor",                                   //AF4
      "Graduate Teaching Assistant",                 //AF5
      "Instructor-Vocation",                         //AF6
      "Librarian/Curator",                           //AF7
      "Principal",                                   //AF8
      "Professor College",                           //AF9
      "Receptionist/Secretary",                      //AFA
      "Superintendent",                              //AFB
      "Teacher College",                             //AFC
      "Teacher K-12",                                //AFD
      "Teaching Assistant/Aide",                     //AFE
      "Tutor",                                       //AFF
      "Other",                                       //AFZ
      "Actuary",                                     //AG0
      "Administrative Assistant",                    //AG1
      "Analyst",                                     //AG2
      "Architect",                                   //AG3
      "Chemist",                                     //AG4
      "Clerk",                                       //AG5
      "Clinical Data Coordinator",                   //AG6
      "Drafter",                                     //AG7
      "Engineer",                                    //AG8
      "Lab Assistant",                               //AG9
      "Manager-Project",                             //AGA
      "Manager-R&D",                                 //AGB
      "Mathematician",                               //AGC
      "Receptionist/Secretary",                      //AGD
      "Research Program Director",                   //AGE
      "Researcher",                                  //AGF
      "Scientist",                                   //AGG
      "Sociologist",                                 //AGH
      "Surveyor/Mapmaker",                           //AGJ
      "Technician",                                  //AGK
      "Other",                                       //AGZ
      "Baker",                                       //AH0
      "Bartender",                                   //AH1
      "Bellhop",                                     //AH2
      "Bus Person",                                  //AH3
      "Caterer",                                     //AH4
      "Chef",                                        //AH5
      "Concessionaire",                              //AH6
      "Concierge",                                   //AH7
      "Cook-Restaurant/Cafeteria",                   //AH8
      "Cook/Worker-Fast Food",                       //AH9
      "Delivery Person",                             //AHA
      "Desk Clerk",                                  //AHB
      "Dishwasher",                                  //AHC
      "Food Production/Packing",                     //AHD
      "Host/Maitre d'",                              //AHE
      "Housekeeper/Maid",                            //AHF
      "Manager",                                     //AHG
      "Valet",                                       //AHH
      "Waiter/Waitress",                             //AHJ
      "Wine Steward",                                //AHK
      "Other",                                       //AHZ
      "Accountant/Auditor",                          //AJ0
      "Administrative Assistant",                    //AJ1
      "Analyst",                                     //AJ2
      "Attorney",                                    //AJ3
      "Chief Executive",                             //AJ4
      "Clerk",                                       //AJ5
      "Commissioner",                                //AJ6
      "Council Member",                              //AJ7
      "Director/Administrator",                      //AJ8
      "Enlisted Military Personnel(E1-E4)",          //AJ9
      "Legislator",                                  //AJA
      "Mayor/City Manager",                          //AJB
      "Meter Reader",                                //AJC
      "NCO (E5-9)",                                  //AJD
      "Officer-Commissioned",                        //AJE
      "Officer-Warrant",                             //AJF
      "Park Ranger",                                 //AJG
      "Planner",                                     //AJH
      "Postmaster",                                  //AJJ
      "Receptionist/Secretary",                      //AJK
      "Regulator",                                   //AJL
      "US Postal Worker",                            //AJM
      "Other",                                       //AJZ
      "Administrative Assistant",                    //AK0
      "Analyst",                                     //AK1
      "Clerk",                                       //AK2
      "Director/Administrator",                      //AK3
      "Engineer-Hardware",                           //AK4
      "Engineer-Software",                           //AK5
      "Engineer-Systems",                            //AK6
      "Executive",                                   //AK7
      "Manager-Systems",                             //AK8
      "Network Administrator",                       //AK9
      "Programmer",                                  //AKA
      "Project Coordinator",                         //AKB
      "Receptionist/Secretary",                      //AKC
      "Support Technician",                          //AKD
      "Systems Security",                            //AKE
      "Technical Writer",                            //AKF
      "Web Developer",                               //AKG
      "Other",                                       //AKZ
      "Accountant/Auditor",                          //AL0
      "Actuary",                                     //AL1
      "Actuarial Clerk",                             //AL2
      "Administrative Assistant",                    //AL3
      "Agent/Broker",                                //AL4
      "Analyst",                                     //AL5
      "Attorney",                                    //AL6
      "Claims Adjuster",                             //AL7
      "Clerk",                                       //AL8
      "Commissioner",                                //AL9
      "Customer Service Representative",             //ALA
      "Director/Administrator",                      //ALB
      "Executive",                                   //ALC
      "Insurance CSR",                               //ALD
      "Product Manager",                             //ALE
      "Receptionist/Secretary",                      //ALF
      "Sales Representative",                        //ALG
      "Underwriter",                                 //ALH
      "Other",                                       //ALZ
      "Airport Security Officer",                    //AM0
      "Animal Control Officer",                      //AM1
      "Attorney",                                    //AM2
      "Bailiff",                                     //AM3
      "Corrections Officer",                         //AM4
      "Court Clerk/Reporter",                        //AM5
      "Deputy Sheriff",                              //AM6
      "Dispatcher",                                  //AM7
      "Examiner",                                    //AM8
      "Federal Agent/Marshall",                      //AM9
      "Fire Chief",                                  //AMA
      "Fire Fighter/Supervisor",                     //AMB
      "Gaming Officer/Investigator",                 //AMC
      "Highway Patrol Officer",                      //AMD
      "Judge/Hearing Officer",                       //AME
      "Legal Assistant/Secretary",                   //AMF
      "Paralegal/Law Clerk",                         //AMG
      "Police Chief",                                //AMH
      "Police Detective/Investigator",               //AMJ
      "Police Officer/Supervisor",                   //AMK
      "Private Investigator/Detective",              //AML
      "Process Server",                              //AMM
      "Security Guard",                              //AMN
      "Sheriff",                                     //AMP
      "Other",                                       //AMZ
      "Administrative Assistant",                    //AN0
      "Assistant-Medic/Dent/Vet",                    //AN1
      "Chiropractor",                                //AN2
      "Clergy",                                      //AN3
      "Clerk",                                       //AN4
      "Client Care Worker",                          //AN5
      "Dental Hygienist",                            //AN6
      "Dentist",                                     //AN7
      "Dietician",                                   //AN8
      "Doctor",                                      //AN9
      "Hospice Volunteer",                           //ANA
      "Lab Assistant",                               //ANB
      "Mortician",                                   //ANC
      "Nurse-C.N.A.",                                //AND
      "Nurse-LPN",                                   //ANE
      "Nurse-RN",                                    //ANF
      "Nurse Practioner",                            //ANG
      "Optometrist",                                 //ANH
      "Orthodontist",                                //ANJ
      "Paramedic/E.M. Technician",                   //ANK
      "Pharmacist",                                  //ANL
      "Physical Therapist",                          //ANM
      "Psychologist",                                //ANN
      "Receptionist/Secretary",                      //ANP
      "Social Worker",                               //ANQ
      "Support Services",                            //ANR
      "Technician",                                  //ANS
      "Therapist",                                   //ANT
      "Veterinarian",                                //ANU
      "Other",                                       //ANZ
      "Caregiver",                                   //AP0
      "Dry Cleaner/Laundry",                         //AP1
      "Hair Stylist/Barber",                         //AP2
      "Housekeeper",                                 //AP3
      "Manicurist",                                  //AP4
      "Masseuse",                                    //AP5
      "Nanny",                                       //AP6
      "Pet Services",                                //AP7
      "Receptionist/Secretary",                      //AP8
      "Other",                                       //APZ
      "Administrative Assistant",                    //AQ0
      "Clerk",                                       //AQ1
      "Factory Worker",                              //AQ2
      "Foreman/Supervisor",                          //AQ3
      "Furniture Finisher",                          //AQ4
      "Inspector",                                   //AQ5
      "Jeweler",                                     //AQ6
      "Machine Operator",                            //AQ7
      "Packer",                                      //AQ8
      "Plant Manager",                               //AQ9
      "Printer/Bookbinder",                          //AQA
      "Quality Control",                             //AQB
      "Receptionist/Secretary",                      //AQC
      "Refining Operator",                           //AQD
      "Shoemaker",                                   //AQE
      "Tailor/Custom Sewer",                         //AQF
      "Textile Worker",                              //AQG
      "Upholsterer",                                 //AQH
      "Other",                                       //AQZ
      "Building Maintenance Engineer",               //AR0
      "Custodian/Janitor",                           //AR1
      "Electrician",                                 //AR2
      "Field Service Technician",                    //AR3
      "Handyman",                                    //AR4
      "Heat/Air Conditioner Repairman",              //AR5
      "Housekeeper/Maid",                            //AR6
      "Landscape/Grounds Maintenance",               //AR7
      "Maintenance Mechanic",                        //AR8
      "Mechanic",                                    //AR9
      "Other",                                       //ARZ
      "Activity/Recreational Assistant",             //AS0
      "Administrative Assistant",                    //AS1
      "Agent",                                       //AS2
      "Athlete",                                     //AS3
      "Camp Counselor/Lead",                         //AS4
      "Clerk",                                       //AS5
      "Coach",                                       //AS6
      "Concessionaire",                              //AS7
      "Director Program",                            //AS8
      "Event Manager/Promoter",                      //AS9
      "Life Guard",                                  //ASA
      "Manager-Fitness Club",                        //ASB
      "Park Ranger",                                 //ASC
      "Receptionist/Secretary",                      //ASD
      "Sales-Ticket/Membership",                     //ASE
      "Sports Broadcast/Journalist",                 //ASF
      "Trainer/Instructor",                          //ASG
      "Umpire/Referee",                              //ASH
      "Other",                                       //ASZ
      "Administrative Assistant",                    //AT0
      "Air Traffic Control",                         //AT1
      "Airport Operations Crew",                     //AT2
      "Bellhop/Porter",                              //AT3
      "Clerk",                                       //AT4
      "Crane Loader/Operator",                       //AT5
      "Dispatcher",                                  //AT6
      "Driver-Bus/Streetcar",                        //AT7
      "Driver-Taxi/Limo",                            //AT8
      "Driver-Truck/Delivery",                       //AT9
      "Flight Attendant",                            //ATA
      "Laborer",                                     //ATB
      "Longshoreman",                                //ATC
      "Manager-Warehouse/District",                  //ATD
      "Mate/Sailor",                                 //ATE
      "Parking Lot Attendant",                       //ATF
      "Pilot/Captain/Engineer",                      //ATG
      "Railroad Worker",                             //ATH
      "Receptionist/Secretary",                      //ATJ
      "Shipping/Receiving Clerk",                    //ATK
      "Subway/Light Rail Operator",                  //ATL
      "Ticket Agent",                                //ATM
      "Transportation Specialist",                   //ATN
      "Travel Agent",                                //ATP
      "Other"                                        //ATZ
    };

    /// <summary>
    /// ACORD Occupation Codes.  This list is used for mapping
    /// ITC Occupation Codes on export to ACORD standards if the
    /// vendor is expecting ACORD.
    /// </summary>
    public static readonly string[] AcordExportCodes =
    {
      // ACORD Code      Description
      "HO",              // "Homemaker(full-time)",                        
      "RET",             // "Retired(full-time)",                          
      "UNEM",            // "Unemployed",                                  
      "ST",              // "Student(full-time)",                          
      "HRT",             // "Agriculture Inspector/Grader",                
      "HRT",             // "Arborist",                                    
      "ADM",             // "Clerk",                                       
      "FAC",             // "Equipment Operator",                          
      "FRM",             // "Farm/Ranch Owner",                            
      "FRM",             // "Farm/Ranch Worker",                           
      "FSH",             // "Fisherman",                                   
      "HRT",             // "Florist",                                     
      "LAB",             // "Laborer/Worker",                              
      "HRT",             // "Landscaper",                                  
      "HRT",             // "Landscaping/Nursery Worker",                  
      "SK",              // "Logger",                                      
      "FAC",             // "Mill Worker",                                 
      "FOR",             // "Ranger",                                      
      "SPR",             // "Supervisor",                                  
      "HRT",             // "Timber Grader/Scaler",                        
      "OT",              // "Other",                                       
      "ENT",             // "Actor",                                       
      "ADM",             // "Administrative Assistant",                    
      "ENT",             // "Announcer/Broadcaster",                       
      "ART",             // "Artist/Animator",                             
      "WRT",             // "Author/Writer",                               
      "ENT",             // "Choreography/Dancer",                         
      "ADM",             // "Clerk",                                       
      "ENT",             // "Composer/Director",                           
      "PAD",             // "Curator",                                     
      "GDP",             // "Designer",                                    
      "WRT",             // "Editor",                                      
      "WRT",             // "Journalist/Reporter",                         
      "ENT",             // "Musician/Singer",                             
      "PHO",             // "Photographer",                                
      "GDP",             // "Printer",                                     
      "ENT",             // "Producer",                                    
      "ENT",             // "Production Crew",                             
      "ENT",             // "Projectionist",                               
      "ADM",             // "Receptionist/Secretary",                      
      "SAL",             // "Ticket Sales/Usher",                          
      "OT",              // "Other",                                       
      "ACT",             // "Accountant/Auditor",                          
      "ADM",             // "Administrative Assistant",                    
      "FIN",             // "Analyst",                                     
      "APR",             // "Appraiser-Real Estate",                       
      "BKP",             // "Bookkeeper",                                  
      "FIN",             // "Broker",                                      
      "MGR",             // "Branch Manager",                              
      "BFI",             // "Clerk",                                       
      "COL",             // "Collections",                                 
      "COT",             // "Consultant",                                  
      "FIN",             // "Controller",                                  
      "BFI",             // "CSR/Teller",                                  
      "ADD",             // "Director/Administrator",                      
      "EXE",             // "Executive",                                   
      "FIN",             // "Financial Advisor",                           
      "FIN",             // "Investment Banker",                           
      "FIN",             // "Investor",                                    
      "FIN",             // "Loan/Escrow Processor",                       
      "MGR",             // "Manager-Credit/Loan",                         
      "MGR",             // "Manager-Portfolio/Production",                
      "MGR",             // "Manager-Property",                            
      "REA",             // "Realtor",                                     
      "ADM",             // "Receptionist/Secretary",                      
      "OF",              // "Sales Agent/Representative",                  
      "FIN",             // "Trader Financial Instruments",                
      "BFI",             // "Underwriter",                                 
      "OT",              // "Other",                                       
      "EXE",             // "Account Executive",                           
      "ADM",             // "Administrative Assistant",                    
      "BUY",             // "Buyer",                                       
      "CAS",             // "Cashier/Checker",                             
      "ADM",             // "Clerk-Office",                                
      "COT",             // "Consultant",                                  
      "BFI",             // "Customer Service Representative",             
      "ADD",             // "Director/Administrator",                      
      "EXE",             // "Executive",                                   
      "CHM",             // "H.R. Representative",                         
      "MGR",             // "Manager-Department/Store",                    
      "MGR",             // "Manager-District",                            
      "MGR",             // "Manager-Finance/Insurance",                   
      "MGR",             // "Manager-General Operations",                  
      "MGR",             // "Manager-H.R./Public Relations",               
      "MGR",             // "Manager-Marketing/Sales",                     
      "MGR",             // "Manager/Supervisor-Office",                   
      "MKT",             // "Marketing Researcher",                        
      "MSG",             // "Messenger/Courier",                           
      "ADM",             // "Receptionist/Secretary",                      
      "RTS",             // "Sales-Counter/Rental",                        
      "SAL",             // "Sales-Homebased",                             
      "SAL",             // "Sales-Manufacture Rep",                       
      "RTS",             // "Sales-Retail/Wholesale",                      
      "CAN",             // "Sales-Route/Vendor",                          
      "OT",              // "Other",                                       
      "APR",             // "Appraiser-Real Estate",                       
      "TRD",             // "Boiler Operator/Maker",                       
      "CFT",             // "Bricklayer/Mason",                            
      "CRP",             // "Carpenter",                                   
      "CFT",             // "Bricklayer/Mason",                            
      "TRD",             // "Concrete Worker",                             
      "MGR",             // "Construction-Project Manager",                
      "TRD",             // "Construction Worker",                         
      "GC",              // "Contractor",                                  
      "TRD",             // "Crane Operator",                              
      "ELE",             // "Electrician/Linesman",                        
      "MNT",             // "Elevator Technician/Installer",               
      "FAC",             // "Equipment Operator",                          
      "TRD",             // "Floor Layer/Finisher",                        
      "SPR",             // "Foreman/Supervisor",                          
      "MNT",             // "Handyman",                                    
      "TRD",             // "Heat/Air Technician",                         
      "TRD",             // "Inspector",                                   
      "LAB",             // "Laborer/Worker",                              
      "TRD",             // "Metalworker",                                 
      "MIN",             // "Miner",                                       
      "RGO",             // "Oil/Gas Driller/Rig Operator",                
      "PNT",             // "Painter",                                     
      "PNT",             // "Plaster/Drywall/Stucco",                      
      "TRD",             // "Plumber",                                     
      "TRD",             // "Roofer",                                      
      "TRD",             // "Utility Worker",                              
      "CFT",             // "Welder",                                      
      "OT",              // "Other",                                       
      "ADM",             // "Administrative Assistant",                    
      "SCT",             // "Audio-Visual Tech",                           
      "DAY",             // "Child/Daycare Worker",                        
      "ADM",             // "Clerk",                                       
      "SCT",             // "Counselor",                                   
      "PCD",             // "Graduate Teaching Assistant",                 
      "INS",             // "Instructor-Vocation",                         
      "LIB",             // "Librarian/Curator",                           
      "SUP",             // "Principal",                                   
      "PRO",             // "Professor College",                           
      "ADM",             // "Receptionist/Secretary",                      
      "SUP",             // "Superintendent",                              
      "SCT",             // "Teacher College",                             
      "SCT",             // "Teacher K-12",                                
      "SCT",             // "Teaching Assistant/Aide",                     
      "SCT",             // "Tutor",                                       
      "OT",              // "Other",                                       
      "ATY",             // "Actuary",                                     
      "ADM",             // "Administrative Assistant",                    
      "TEC",             // "Analyst",                                     
      "AR",              // "Architect",                                   
      "PAD",             // "Chemist",                                     
      "ADM",             // "Clerk",                                       
      "ALLOT",           // "Clinical Data Coordinator",                   
      "AR",              // "Drafter",                                     
      "ENG",             // "Engineer",                                    
      "TEC",             // "Lab Assistant",                               
      "MGR",             // "Manager-Project",                             
      "MGR",             // "Manager-R&D",                                 
      "PAD",             // "Mathematician",                               
      "ADM",             // "Receptionist/Secretary",                      
      "PAD",             // "Research Program Director",                   
      "SC",              // "Researcher",                                  
      "SC",              // "Scientist",                                   
      "PCD",             // "Sociologist",                                 
      "PAD",             // "Surveyor/Mapmaker",                           
      "TEC",             // "Technician",                                  
      "OT",              // "Other",                                       
      "RSC",             // "Baker",                                       
      "RSB",             // "Bartender",                                   
      "HOT",             // "Bellhop",                                     
      "RSB",             // "Bus Person",                                  
      "RSC",             // "Caterer",                                     
      "CHF",             // "Chef",                                        
      "HOT",             // "Concessionaire",                              
      "HOT",             // "Concierge",                                   
      "RSC",             // "Cook-Restaurant/Cafeteria",                   
      "RSC",             // "Cook/Worker-Fast Food",                       
      "DELY",            // "Delivery Person",                             
      "HOT",             // "Desk Clerk",                                  
      "RSB",             // "Dishwasher",                                  
      "FOD",             // "Food Production/Packing",                     
      "MAITR",           // "Host/Maitre d'",                              
      "HOT",             // "Housekeeper/Maid",                            
      "MGR",             // "Manager",                                     
      "ALLOT",           // "Valet",                                       
      "RSB",             // "Waiter/Waitress",                             
      "WNS",             // "Wine Steward",                                
      "OT",              // "Other",                                       
      "ACT",             // "Accountant/Auditor",                          
      "ADM",             // "Administrative Assistant",                    
      "ALLOT",           // "Analyst",                                     
      "LAW",             // "Attorney",                                    
      "EXE",             // "Chief Executive",                             
      "ADM",             // "Clerk",                                       
      "CS",              // "Commissioner",                                
      "CS",              // "Council Member",                              
      "ADD",             // "Director/Administrator",                      
      "MI",              // "Enlisted Military Personnel(E1-E4)",          
      "CS",              // "Legislator",                                  
      "CS",              // "Mayor/City Manager",                          
      "CS",              // "Meter Reader",                                
      "MI",              // "NCO (E5-9)",                                  
      "MI",              // "Officer-Commissioned",                        
      "POL",             // "Officer-Warrant",                             
      "FOR",             // "Park Ranger",                                 
      "CS",              // "Planner",                                     
      "PST",             // "Postmaster",                                  
      "ADM",             // "Receptionist/Secretary",                      
      "CS",              // "Regulator",                                   
      "PST",             // "US Postal Worker",                            
      "OT",              // "Other",                                       
      "ADM",             // "Administrative Assistant",                    
      "CMP",             // "Analyst",                                     
      "ADM",             // "Clerk",                                       
      "ADD",             // "Director/Administrator",                      
      "CMP",             // "Engineer-Hardware",                           
      "CMP",             // "Engineer-Software",                           
      "CMP",             // "Engineer-Systems",                            
      "EXE",             // "Executive",                                   
      "TES",             // "Manager-Systems",                             
      "CMP",             // "Network Administrator",                       
      "CMP",             // "Programmer",                                  
      "CMP",             // "Project Coordinator",                         
      "ADM",             // "Receptionist/Secretary",                      
      "CMP",             // "Support Technician",                          
      "CMP",             // "Systems Security",                            
      "WRT",             // "Technical Writer",                            
      "CMP",             // "Web Developer",                               
      "OT",              // "Other",                                       
      "ACT",             // "Accountant/Auditor",                          
      "ATY",             // "Actuary",                                     
      "ADM",             // "Actuarial Clerk",                             
      "ADM",             // "Administrative Assistant",                    
      "IAB",             // "Agent/Broker",                                
      "ALLOT",           // "Analyst",                                     
      "LAW",             // "Attorney",                                    
      "IAD",             // "Claims Adjuster",                             
      "ADM",             // "Clerk",                                       
      "CS",              // "Commissioner",                                
      "ALLOT",           // "Customer Service Representative",             
      "ADD",             // "Director/Administrator",                      
      "EXE",             // "Executive",                                   
      "ALLOT",           // "Insurance CSR",                               
      "MGR",             // "Product Manager",                             
      "ADM",             // "Receptionist/Secretary",                      
      "OF",              // "Sales Representative",                        
      "IUW",             // "Underwriter",                                 
      "OT",              // "Other",                                       
      "SEC",             // "Airport Security Officer",                    
      "CS",              // "Animal Control Officer",                      
      "LAW",             // "Attorney",                                    
      "CRT",             // "Bailiff",                                     
      "POL",             // "Corrections Officer",                         
      "CRT",             // "Court Clerk/Reporter",                        
      "POL",             // "Deputy Sheriff",                              
      "ADM",             // "Dispatcher",                                  
      "CS",              // "Examiner",                                    
      "POL",             // "Federal Agent/Marshall",                      
      "FF",              // "Fire Chief",                                  
      "FF",              // "Fire Fighter/Supervisor",                     
      "POL",             // "Gaming Officer/Investigator",                 
      "POL",             // "Highway Patrol Officer",                      
      "CS",              // "Judge/Hearing Officer",                       
      "ADM",             // "Legal Assistant/Secretary",                   
      "ADM",             // "Paralegal/Law Clerk",                         
      "POL",             // "Police Chief",                                
      "POL",             // "Police Detective/Investigator",               
      "POL",             // "Police Officer/Supervisor",                   
      "POL",             // "Private Investigator/Detective",              
      "ADM",             // "Process Server",                              
      "SEC",             // "Security Guard",                              
      "POL",             // "Sheriff",                                     
      "OT",              // "Other",                                       
      "ADM",             // "Administrative Assistant",                    
      "TEC",             // "Assistant-Medic/Dent/Vet",                    
      "CHIROPRACTOR",    // "Chiropractor",                                
      "CL",              // "Clergy",                                      
      "ADM",             // "Clerk",                                       
      "ALLOT",           // "Client Care Worker",                          
      "DHY",             // "Dental Hygienist",                            
      "DEN",             // "Dentist",                                     
      "DIE",             // "Dietician",                                   
      "PHY",             // "Doctor",                                      
      "ALLOT",           // "Hospice Volunteer",                           
      "TEC",             // "Lab Assistant",                               
      "MSP",             // "Mortician",                                   
      "NRS",             // "Nurse-C.N.A.",                                
      "NRS",             // "Nurse-LPN",                                   
      "NRS",             // "Nurse-RN",                                    
      "NRS",             // "Nurse Practioner",                            
      "OPT",             // "Optometrist",                                 
      "MSP",             // "Orthodontist",                                
      "TEC",             // "Paramedic/E.M. Technician",                   
      "PHR",             // "Pharmacist",                                  
      "THR",             // "Physical Therapist",                          
      "MSP",             // "Psychologist",                                
      "ADM",             // "Receptionist/Secretary",                      
      "CS",              // "Social Worker",                               
      "ALLOT",           // "Support Services",                            
      "TEC",             // "Technician",                                  
      "THR",             // "Therapist",                                   
      "VET",             // "Veterinarian",                                
      "OT",              // "Other",                                       
      "DAY",             // "Caregiver",                                   
      "STK",             // "Dry Cleaner/Laundry",                         
      "BRB",             // "Hair Stylist/Barber",                         
      "MNT",             // "Housekeeper",                                 
      "SK",              // "Manicurist",                                  
      "SK",              // "Masseuse",                                    
      "DAY",             // "Nanny",                                       
      "SK",              // "Pet Services",                                
      "ADM",             // "Receptionist/Secretary",                      
      "OT",              // "Other",                                       
      "ADM",             // "Administrative Assistant",                    
      "ADM",             // "Clerk",                                       
      "FAC",             // "Factory Worker",                              
      "SPR",             // "Foreman/Supervisor",                          
      "CFT",             // "Furniture Finisher",                          
      "FAC",             // "Inspector",                                   
      "CFT",             // "Jeweler",                                     
      "FAC",             // "Machine Operator",                            
      "FAC",             // "Packer",                                      
      "MGR",             // "Plant Manager",                               
      "GDP",             // "Printer/Bookbinder",                          
      "FAC",             // "Quality Control",                             
      "ADM",             // "Receptionist/Secretary",                      
      "FAC",             // "Refining Operator",                           
      "CFT",             // "Shoemaker",                                   
      "SMS",             // "Tailor/Custom Sewer",                         
      "FAC",             // "Textile Worker",                              
      "CFT",             // "Upholsterer",                                 
      "OT",              // "Other",                                       
      "MNT",             // "Building Maintenance Engineer",               
      "CST",             // "Custodian/Janitor",                           
      "ELE",             // "Electrician",                                 
      "MNT",             // "Field Service Technician",                    
      "MNT",             // "Handyman",                                    
      "MNT",             // "Heat/Air Conditioner Repairman",              
      "MNT",             // "Housekeeper/Maid",                            
      "MNT",             // "Landscape/Grounds Maintenance",               
      "MNT",             // "Maintenance Mechanic",                        
      "AUM",             // "Mechanic",                                    
      "OT",              // "Other",                                       
      "FIT",             // "Activity/Recreational Assistant",             
      "ADM",             // "Administrative Assistant",                    
      "ALLOT",           // "Agent",                                       
      "ATH",             // "Athlete",                                     
      "ALLOT",           // "Camp Counselor/Lead",                         
      "ADM",             // "Clerk",                                       
      "FIT",             // "Coach",                                       
      "RSC",             // "Concessionaire",                              
      "ADD",             // "Director Program",                            
      "ENT",             // "Event Manager/Promoter",                      
      "FIT",             // "Life Guard",                                  
      "MGR",             // "Manager-Fitness Club",                        
      "FOR",             // "Park Ranger",                                 
      "ADM",             // "Receptionist/Secretary",                      
      "SAL",             // "Sales-Ticket/Membership",                     
      "ENT",             // "Sports Broadcast/Journalist",                 
      "FIT",             // "Trainer/Instructor",                          
      "FIT",             // "Umpire/Referee",                              
      "OT",              // "Other",                                       
      "ADM",             // "Administrative Assistant",                    
      "AIR",             // "Air Traffic Control",                         
      "AIR",             // "Airport Operations Crew",                     
      "HOT",             // "Bellhop/Porter",                              
      "ADM",             // "Clerk",                                       
      "TRD",             // "Crane Loader/Operator",                       
      "ADM",             // "Dispatcher",                                  
      "DRP",             // "Driver-Bus/Streetcar",                        
      "DRT",             // "Driver-Taxi/Limo",                            
      "TRK",             // "Driver-Truck/Delivery",                       
      "FLA",             // "Flight Attendant",                            
      "LAB",             // "Laborer",                                     
      "TRD",             // "Longshoreman",                                
      "MGR",             // "Manager-Warehouse/District",                  
      "SK",              // "Mate/Sailor",                                 
      "SSAT",            // "Parking Lot Attendant",                       
      "PLT",             // "Pilot/Captain/Engineer",                      
      "PTO",             // "Railroad Worker",                             
      "ADM",             // "Receptionist/Secretary",                      
      "SHP",             // "Shipping/Receiving Clerk",                    
      "PTO",             // "Subway/Light Rail Operator",                  
      "SAL",             // "Ticket Agent",                                
      "PTO",             // "Transportation Specialist",                   
      "SAL",             // "Travel Agent",                                
      "OT"               // "Other" 
    };

    /// <summary>
    /// ACORD Occupation Codes.  This list is used for mapping
    /// ACORD Occupation Codes on import to our internal ITC
    /// Occupation Codes.  When updating this list, you must also
    /// update the AcordImportToITCMapping list to be sure we have
    /// a corresponding mapping with the same indexing to your new listings.  
    /// </summary>
    public static readonly string[] AcordImportCodes =
    {
      // ACORD Code      ITC (Progressive/GMAC) Code
      "HO",              // "010",
      "RET",             // "020",
      "UNEM",            // "030",
      "ST",              // "040",
      "MI",              // "AJ9",
      "OT"               // "ADZ"
    };

    /// <summary>
    /// ITC (Progressive/GMAC) list of codes that corresponds to the AcordImportCodes.
    /// </summary>
    public static readonly string[] AcordImportToITCMapping =
    {
      "010",
      "020",
      "030",
      "040",
      "AJ9",
      "ADZ"
    };

    public const string CaesarRateWarning = "Get a rate for this company by clicking the \"Click to Rate\" link.";
    public const string CaesarUpdateRateWarning = "After you have completed quoting on the carrier's site, click 'Update Rate' to display the premium.";

    /// <summary>
    /// With the given media type, this returns the string representation of the media type for use in http requests.
    /// </summary>
    /// <param name="mediaType">the media type</param>
    /// <returns>the media type</returns>
    public static string GetMediaType(MediaType mediaType)
    {
      return "application/" + mediaType.ToString().ToLower();
    }

  }
}
