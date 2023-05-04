using System;
using System.ComponentModel;

namespace TurboRater.Insurance.HO
{
  /// <summary>
  /// Stores texas endorsements.
  /// </summary>
  [Serializable]
  public class HOTXEndorsements : BaseStoredRecord
  {
    private int m_policyLinkId = ITCConstants.InvalidNum;
    private bool m_ho101;
    private double m_ho101Premium;
    private bool m_ho102;
    private double m_ho102Premium;
    private bool m_ho105;
    private int m_ho105Limit;
    private double m_ho105Premium;
    private bool m_ho110;
    private int m_ho110Limit;
    private double m_ho110Premium;
    private bool m_ho111;
    private double m_ho111Premium;
    private int m_ho111Limit;
    private bool m_ho112;
    private double m_ho112Premium;
    private int m_ho112Limit;
    private bool m_ho113;
    private double m_ho113Premium;
    private int m_ho113Limit;
    private bool m_ho120;
    private double m_ho120Premium;
    private int m_ho120Limit;
    private bool m_ho121;
    private double m_ho121Premium;
    private int m_ho121PlainGlassLimit;
    private int m_ho121AllOtherGlassLimit;
    private bool m_ho122;
    private double m_ho122Premium;
    private int m_ho122Limit;
    private bool m_ho123;
    private double m_ho123Premium;
    private bool m_ho125;
    private double m_ho125Premium;
    private int m_ho125Limit;
    private bool m_ho126;
    private double m_ho126Premium;
    private int m_ho126Limit;
    private bool m_ho130;
    private double m_ho130Premium;
    private bool m_ho140;
    private double m_ho140Premium;
    private double m_ho140BaseReduction;
    private double m_ho140OtherStructuresReduction;
    private double m_ho140DeductibleReduction;
    private double m_ho140OrdOrLawReduction;
    private double m_ho140ReplacementCostReduction;
    private bool m_ho142;
    private double m_ho142Premium;
    private bool m_ho160;
    private double m_ho160Premium;
    private int m_ho160Cameras;
    private double m_ho160CamerasSubPremium;
    private int m_ho160CoinCollections;
    private double m_ho160CoinCollectionsSubPremium;
    private int m_ho160FineArts;
    private double m_ho160FineArtsSubPremium;
    private int m_ho160FineArtsWithBreakage;
    private double m_ho160FineArtsWithBreakageSubPremium;
    private int m_ho160Furs;
    private double m_ho160FursSubPremium;
    private int m_ho160GolfersEquipment;
    private double m_ho160GolfersEquipmentSubPremium;
    private int m_ho160Jewelry;
    private double m_ho160JewelrySubPremium;
    private int m_ho160MusicalInstruments;
    private double m_ho160MusicalInstrumentsSubPremium;
    private int m_ho160OtherProperty;
    private double m_ho160OtherPropertySubPremium;
    private int m_ho160Silverware;
    private double m_ho160SilverwareSubPremium;
    private int m_ho160StampCollections;
    private double m_ho160StampCollectionsSubPremium;
    private bool m_ho161To167;
    private double m_ho161To167Premium;
    private bool m_ho170;
    private double m_ho170Premium;
    private bool m_ho180;
    private double m_ho180Premium;
    private int m_ho180Limit;
    private bool m_ho201;
    private double m_ho201Premium;
    private bool m_ho201EliminateExclusion3;
    private bool m_ho205;
    private double m_ho205Premium;
    private bool m_ho205SameResidence;
    private int m_ho205AdditionalResidencesOneFamily;
    private int m_ho205AdditionalResidencesTwoFamily;
    private bool m_ho205MedicalPayments;
    private bool m_ho210;
    private double m_ho210Premium;
    private int m_ho210Acres;
    private int m_ho210Animals;
    private int m_ho210TotalPayroll;
    private int m_ho210AdditionalResidences;
    private int m_ho210AdditionalFarms;
    private int m_ho210CustomFarming;
    private bool m_ho215;
    private int m_ho215MotorAHorsepower;
    private int m_ho215MotorBHorsepower;
    private int m_ho215MotorCHorsepower;
    private string m_ho215MotorAManufacturer = "";
    private string m_ho215MotorBManufacturer = "";
    private string m_ho215MotorCManufacturer = "";
    private string m_ho215InboardDescription1 = "";
    private string m_ho215InboardDescription2 = "";
    private string m_ho215InboardDescription3 = "";
    private string m_ho215WatercraftType1 = WatercraftType.None.ToString();
    private string m_ho215WatercraftType2 = WatercraftType.None.ToString();
    private int m_ho215Horsepower1;
    private int m_ho215Horsepower2;
    private int m_ho215Length1;
    private int m_ho215Length2;
    private int m_ho215MilesPerHour1;
    private int m_ho215MilesPerHour2;
    private double m_ho215Premium;
    private bool m_ho220;
    private double m_ho220Premium;
    private bool m_ho220MedicalPayments;
    private bool m_ho220IsOwner;
    private string m_ho220PremiumGroup = "A";
    private bool m_ho220TeacherLiability;
    private bool m_ho225;
    private double m_ho225Premium;
    private int m_ho225AdditionalResidencesOneFamily;
    private int m_ho225AdditionalResidencesTwoFamily;
    private bool m_ho225MedicalPayments;
    private bool m_ho301;
    private double m_ho301Premium;
    private string m_ho301Section = "I";
    private bool m_ho310;
    private double m_ho310Premium;
    private int m_ho310LiabilityLimit;
    private bool m_ho315;
    private int m_ho315LiabilityLimit;
    private double m_ho315Premium;
    private bool m_ho330;
    private double m_ho330Premium;
    private int m_ho330Percent;
    private bool m_ho380;
    private double m_ho380Premium;
    private bool m_ho381;
    private double m_ho381Premium;
    private bool m_ho382;
    private double m_ho382Premium;
    private int m_ho382LiabilityLimit;
    private bool m_ho0468;
    private double m_ho0468Premium;
    private bool m_ho0495;
    private double m_ho0495Premium;
    private bool m_ho0483;
    private double m_ho0483Premium;
    private bool m_ho0477;
    private int m_ho0477Ordinance;
    private int m_ho0477CoOrdinance;
    private double m_ho477Premium;

    private bool m_dfWindstormExclusion;
    private bool m_dfReplacementCostPersonalProperty;
    private double m_dfReplacementCostPersonalPropertyPremium;
    private bool m_dfExclusionOfResidentialCommunityPropertyClause;
    private bool m_dfAdditionalNamedInsured;
    private int m_dfNumOfAdditionalNamedInsured = 1;
    private double m_dfAdditionalNamedInsuredPremium;
    private bool m_dfAgreedAmountOnDwelling;
    private bool m_dfResidenceGlass;
    private int m_dfResidenceGlassLimit;
    private double m_dfResidenceGlassPremium;
    private bool m_dfLossPayableClause;
    private int m_dfNumOfLossPayees = 1;
    private double m_dfLossPayableClausePremium;
    private bool m_dfVacancyClause;
    private int m_dfNumOfVacancyMonths = 1;
    private double m_dfVacancyClausePremium;
    private bool m_dfMiscellaneousPropertySchedule;
    private int m_dfMiscPropOutbuildingsLimit;
    private double m_dfMiscPropOutbuildingsPremium;
    private int m_dfMiscPropBoatHousesLimit;
    private double m_dfMiscPropBoatHousesPremium;
    private int m_dfMiscPropClothAwningsLimit;
    private double m_dfMiscPropClothAwningsPremium;
    private int m_dfMiscPropFencesLimit;
    private double m_dfMiscPropFencesPremium;
    private int m_dfMiscPropFlagPolesLimit;
    private double m_dfMiscPropFlagPolesPremium;
    private int m_dfMiscPropFloodLightsMetalPoleLimit;
    private double m_dfMiscPropFloodLightsMetalPolePremium;
    private int m_dfMiscPropFloodLightsWoodPoleLimit;
    private double m_dfMiscPropFloodLightsWoodPolePremium;
    private int m_dfMiscPropPlainGlassGreenhouseLimit;
    private double m_dfMiscPropPlainGlassGreenhousePremium;
    private int m_dfMiscPropGreenhousesNotPlainGlassLimit;
    private double m_dfMiscPropGreenhousesNotPlainGlassPremium;
    private int m_dfMiscPropLandAndOutsideSiteImprovementsLimit;
    private double m_dfMiscPropLandAndOutsideSiteImprovementsPremium;
    private int m_dfMiscPropMasonrySwimmingPoolsLimit;
    private double m_dfMiscPropMasonrySwimmingPoolsPremium;
    private int m_dfMiscPropNonMasonrySwimmingPoolsLimit;
    private double m_dfMiscPropNonMasonrySwimmingPoolsPremium;
    private int m_dfMiscPropTennisAndSlabCourtsLimit;
    private double m_dfMiscPropTennisAndSlabCourtsPremium;
    private int m_dfMiscPropTVAndRadioAntennaLimit;
    private double m_dfMiscPropTVAndRadioAntennaPremium;
    private int m_dfMiscPropTreesPlantsAndShrubsLimit;
    private double m_dfMiscPropTreesPlantsAndShrubsPremium;
    private int m_dfMiscPropWindmillsLimit;
    private double m_dfMiscPropWindmillsPremium;
    private double m_dfMiscellaneousPropertySchedulePremium;
    private bool m_dfLossAssessmentPropertyCoverage;
    private int m_dfLossAssessmentLimit;
    private double m_dfLossAssessmentPropertyCoveragePremium;
    private bool m_dfContractOfSale;
    private double m_dfContractOfSalePremium;
    private bool m_ho0455;
    private double m_ho0455Premium;

    /// <summary>
    /// foreign-key link back to the policy
    /// </summary>
    public int PolicyLinkId
    {
      get { return m_policyLinkId; }
      set { m_policyLinkId = value; }
    }

    /// <summary>
    /// Replacement of personal property.
    /// </summary>
    [Description("Replacement of personal property")]
    public bool HO101
    {
      get { return m_ho101; }
      set { m_ho101 = value; }
    }

    /// <summary>
    /// Agreed amount on dwelling.
    /// </summary>
    [Description("Agreed amount on dwelling")]
    public bool HO102
    {
      get { return m_ho102; }
      set { m_ho102 = value; }
    }

    /// <summary>
    /// Residence glass.
    /// </summary>
    [Description("Residential glass")]
    public bool HO105
    {
      get { return m_ho105; }
      set { m_ho105 = value; }
    }

    /// <summary>
    /// HO-105 limit.
    /// </summary>
    public int HO105Limit
    {
      get { return m_ho105Limit; }
      set { m_ho105Limit = value; }
    }

    /// <summary>
    /// Increased limit on jewelry, glass and furs
    /// </summary>
    [Description("Increased limit on jewelry, glass and furs")]
    public bool HO110
    {
      get { return m_ho110; }
      set { m_ho110 = value; }
    }

    /// <summary>
    /// HO-101 limit.
    /// </summary>
    public int HO110Limit
    {
      get { return m_ho110Limit; }
      set { m_ho110Limit = value; }
    }

    /// <summary>
    /// Increased limit on business personal property
    /// </summary>
    [Description("Increased limit on business personal property")]
    public bool HO111
    {
      get { return m_ho111; }
      set { m_ho111 = value; }
    }

    /// <summary>
    /// HO-111 limit.
    /// </summary>
    public int HO111Limit
    {
      get { return m_ho111Limit; }
      set { m_ho111Limit = value; }
    }

    /// <summary>
    /// Increased limit on money/bank cards
    /// </summary>
    [Description("Increased limit on money/bank cards")]
    public bool HO112
    {
      get { return m_ho112; }
      set { m_ho112 = value; }
    }

    /// <summary>
    /// HO-112 limit
    /// </summary>
    public int HO112Limit
    {
      get { return m_ho112Limit; }
      set { m_ho112Limit = value; }
    }

    /// <summary>
    /// Inreased limit on bullion/valuable papers
    /// </summary>
    [Description("Increased limit on bullion/valuable papers")]
    public bool HO113
    {
      get { return m_ho113; }
      set { m_ho113 = value; }
    }

    /// <summary>
    /// HO-113 limit
    /// </summary>
    public int HO113Limit
    {
      get { return m_ho113Limit; }
      set { m_ho113Limit = value; }
    }

    /// <summary>
    /// Television and radio antenna
    /// </summary>
    [Description("Television and radio antenna")]
    public bool HO120
    {
      get { return m_ho120; }
      set { m_ho120 = value; }
    }

    /// <summary>
    /// HO-120 limit
    /// </summary>
    public int HO120Limit
    {
      get { return m_ho120Limit; }
      set { m_ho120Limit = value; }
    }

    /// <summary>
    /// Windstorm coverage for green houses
    /// </summary>
    [Description("Windstorm coverage for green houses")]
    public bool HO121
    {
      get { return m_ho121; }
      set { m_ho121 = value; }
    }

    /// <summary>
    /// HO-121 plain glass limit
    /// </summary>
    public int HO121PlainGlassLimit
    {
      get { return m_ho121PlainGlassLimit; }
      set { m_ho121PlainGlassLimit = value; }
    }

    /// <summary>
    /// HO-121 all other glass limit
    /// </summary>
    public int HO121AllOtherGlassLimit
    {
      get { return m_ho121AllOtherGlassLimit; }
      set { m_ho121AllOtherGlassLimit = value; }
    }

    /// <summary>
    /// Windstorm coverage for cloth awnings
    /// </summary>
    [Description("Windstorm coverage for cloth awnings")]
    public bool HO122
    {
      get { return m_ho122; }
      set { m_ho122 = value; }
    }

    /// <summary>
    /// HO-121 limit
    /// </summary>
    public int HO122Limit
    {
      get { return m_ho122Limit; }
      set { m_ho122Limit = value; }
    }

    /// <summary>
    /// HO-123
    /// </summary>
    [Description("HO 123")]
    public bool HO123
    {
      get { return m_ho123; }
      set { m_ho123 = value; }
    }

    /// <summary>
    /// Physicians', surgeons' and dentists' outside coverage
    /// </summary>
    [Description("Physicians', surgeons' and dentists' outside coverage")]
    public bool HO125
    {
      get { return m_ho125; }
      set { m_ho125 = value; }
    }

    /// <summary>
    /// HO-125 limit
    /// </summary>
    public int HO125Limit
    {
      get { return m_ho125Limit; }
      set { m_ho125Limit = value; }
    }

    /// <summary>
    /// Personal computer coverage
    /// </summary>
    [Description("Personal computer coverage")]
    public bool HO126
    {
      get { return m_ho126; }
      set { m_ho126 = value; }
    }

    /// <summary>
    /// HO-126 limit
    /// </summary>
    public int HO126Limit
    {
      get { return m_ho126Limit; }
      set { m_ho126Limit = value; }
    }

    /// <summary>
    /// $250 theft deductible
    /// </summary>
    [Description("$250 theft deductible")]
    public bool HO130
    {
      get { return m_ho130; }
      set { m_ho130 = value; }
    }

    /// <summary>
    /// Windstorm, hurricane and hail exclusion
    /// </summary>
    [Description("Windstorm, hurricane and hail exclusion")]
    public bool HO140
    {
      get { return m_ho140; }
      set { m_ho140 = value; }
    }

    /// <summary>
    /// Exclusion of residential community property
    /// </summary>
    [Description("Exclusion of residential community property")]
    public bool HO142
    {
      get { return m_ho142; }
      set { m_ho142 = value; }
    }

    /// <summary>
    /// Scheduled valuable possessions
    /// </summary>
    [Description("Scheduled valuable possesions")]
    public bool HO160
    {
      get { return m_ho160; }
      set { m_ho160 = value; }
    }

    /// <summary>
    /// HO-160 cameras
    /// </summary>
    public int HO160Cameras
    {
      get { return m_ho160Cameras; }
      set { m_ho160Cameras = value; }
    }

    /// <summary>
    /// HO-160 coin collections
    /// </summary>
    public int HO160CoinCollections
    {
      get { return m_ho160CoinCollections; }
      set { m_ho160CoinCollections = value; }
    }

    /// <summary>
    /// HO-160 fine arts
    /// </summary>
    public int HO160FineArts
    {
      get { return m_ho160FineArts; }
      set { m_ho160FineArts = value; }
    }

    /// <summary>
    /// HO-160 fine arts with breakage
    /// </summary>
    public int HO160FineArtsWithBreakage
    {
      get { return m_ho160FineArtsWithBreakage; }
      set { m_ho160FineArtsWithBreakage = value; }
    }

    /// <summary>
    /// HO-160 furs
    /// </summary>
    public int HO160Furs
    {
      get { return m_ho160Furs; }
      set { m_ho160Furs = value; }
    }

    /// <summary>
    /// HO-160 golfers equipment
    /// </summary>
    public int HO160GolfersEquipment
    {
      get { return m_ho160GolfersEquipment; }
      set { m_ho160GolfersEquipment = value; }
    }

    /// <summary>
    /// HO-160 jewelry
    /// </summary>
    public int HO160Jewelry
    {
      get { return m_ho160Jewelry; }
      set { m_ho160Jewelry = value; }
    }

    /// <summary>
    /// HO-160 musical instruments
    /// </summary>
    public int HO160MusicalInstruments
    {
      get { return m_ho160MusicalInstruments; }
      set { m_ho160MusicalInstruments = value; }
    }

    /// <summary>
    /// HO-160 other property
    /// </summary>
    public int HO160OtherProperty
    {
      get { return m_ho160OtherProperty; }
      set { m_ho160OtherProperty = value; }
    }

    /// <summary>
    /// HO-160 silverware
    /// </summary>
    public int HO160Silverware
    {
      get { return m_ho160Silverware; }
      set { m_ho160Silverware = value; }
    }

    /// <summary>
    /// HO-160 stamp collections
    /// </summary>
    public int HO160StampCollections
    {
      get { return m_ho160StampCollections; }
      set { m_ho160StampCollections = value; }
    }

    /// <summary>
    /// Mold, fungi or other microbes coverage
    /// </summary>
    [Description("Mold, fungi or other microbes coverage")]
    public bool HO161To167
    {
      get { return m_ho161To167; }
      set { m_ho161To167 = value; }
    }

    /// <summary>
    /// Additional extended coverage
    /// </summary>
    [Description("Additional extended coverage")]
    public bool HO170
    {
      get { return m_ho170; }
      set { m_ho170 = value; }
    }

    /// <summary>
    /// Unit Owners Outbuilding and Other Structures
    /// </summary>
    [Description("Unit owners outbuilding and other structures")]
    public bool HO180
    {
      get { return m_ho180; }
      set { m_ho180 = value; }
    }

    /// <summary>
    /// HO-180 limit
    /// </summary>
    public int HO180Limit
    {
      get { return m_ho180Limit; }
      set { m_ho180Limit = value; }
    }

    /// <summary>
    /// Personal injury coverage
    /// </summary>
    [Description("Personal injury coverage")]
    public bool HO201
    {
      get { return m_ho201; }
      set { m_ho201 = value; }
    }

    /// <summary>
    /// HO-201 eliminate exclusion 3
    /// </summary>
    public bool HO201EliminateExclusion3
    {
      get { return m_ho201EliminateExclusion3; }
      set { m_ho201EliminateExclusion3 = value; }
    }

    /// <summary>
    /// Office, private school or studio
    /// </summary>
    [Description("Office, private school or studio")]
    public bool HO205
    {
      get { return m_ho205; }
      set { m_ho205 = value; }
    }

    /// <summary>
    /// HO-205 same residence
    /// </summary>
    public bool HO205SameResidence
    {
      get { return m_ho205SameResidence; }
      set { m_ho205SameResidence = value; }
    }

    /// <summary>
    /// HO-205 additional residences 1 family
    /// </summary>
    public int HO205AdditionalResidencesOneFamily
    {
      get { return m_ho205AdditionalResidencesOneFamily; }
      set { m_ho205AdditionalResidencesOneFamily = value; }
    }

    /// <summary>
    /// HO-205 additional residences 2 family
    /// </summary>
    public int HO205AdditionalResidencesTwoFamily
    {
      get { return m_ho205AdditionalResidencesTwoFamily; }
      set { m_ho205AdditionalResidencesTwoFamily = value; }
    }

    /// <summary>
    /// HP-205 medical payments
    /// </summary>
    public bool HO205MedicalPayments
    {
      get { return m_ho205MedicalPayments; }
      set { m_ho205MedicalPayments = value; }
    }

    /// <summary>
    /// HO-210 Farmers personal liability
    /// </summary>
    [Description("Farmers personal liability")]
    public bool HO210
    {
      get { return m_ho210; }
      set { m_ho210 = value; }
    }

    /// <summary>
    /// HO-210 number of acres
    /// </summary>
    public int HO210Acres
    {
      get { return m_ho210Acres; }
      set { m_ho210Acres = value; }
    }

    /// <summary>
    /// HO-210 number of animals
    /// </summary>
    public int HO210Animals
    {
      get { return m_ho210Animals; }
      set { m_ho210Animals = value; }
    }

    /// <summary>
    /// HO-210 total payroll
    /// </summary>
    public int HO210TotalPayroll
    {
      get { return m_ho210TotalPayroll; }
      set { m_ho210TotalPayroll = value; }
    }

    /// <summary>
    /// HO-210 additional residences
    /// </summary>
    public int HO210AdditionalResidences
    {
      get { return m_ho210AdditionalResidences; }
      set { m_ho210AdditionalResidences = value; }
    }

    /// <summary>
    /// HO-210 additional farms
    /// </summary>
    public int HO210AdditionalFarms
    {
      get { return m_ho210AdditionalFarms; }
      set { m_ho210AdditionalFarms = value; }
    }

    /// <summary>
    /// HO-210 custom farming
    /// </summary>
    public int HO210CustomFarming
    {
      get { return m_ho210CustomFarming; }
      set { m_ho210CustomFarming = value; }
    }

    /// <summary>
    /// Watercraft liability coverage
    /// </summary>
    [Description("Watercraft liability coverage")]
    public bool HO215
    {
      get { return m_ho215; }
      set { m_ho215 = value; }
    }

    /// <summary>
    /// Watercraft #1 Type
    /// </summary>
    public string HO215WatercraftType1
    {
      get { return m_ho215WatercraftType1; }
      set { m_ho215WatercraftType1 = value; }
    }

    /// <summary>
    /// Watercraft #2 Type
    /// </summary>
    public string HO215WatercraftType2
    {
      get { return m_ho215WatercraftType2; }
      set { m_ho215WatercraftType2 = value; }
    }

    /// <summary>
    /// Watercraft #1 Horsepower
    /// </summary>
    public int HO215Horsepower1
    {
      get { return m_ho215Horsepower1; }
      set { m_ho215Horsepower1 = value; }
    }

    /// <summary>
    /// Watercraft #2 Horsepower
    /// </summary>
    public int HO215Horsepower2
    {
      get { return m_ho215Horsepower2; }
      set { m_ho215Horsepower2 = value; }
    }

    /// <summary>
    /// Watercraft #1 Length
    /// </summary>
    public int HO215Length1
    {
      get { return m_ho215Length1; }
      set { m_ho215Length1 = value; }
    }

    /// <summary>
    /// Watercraft #2 Length
    /// </summary>
    public int HO215Length2
    {
      get { return m_ho215Length2; }
      set { m_ho215Length2 = value; }
    }

    /// <summary>
    /// Watercraft #1 Miles Per Hour
    /// </summary>
    public int HO215MilesPerHour1
    {
      get { return m_ho215MilesPerHour1; }
      set { m_ho215MilesPerHour1 = value; }
    }

    /// <summary>
    /// Watercraft #2 Miles Per Hour
    /// </summary>
    public int HO215MilesPerHour2
    {
      get { return m_ho215MilesPerHour2; }
      set { m_ho215MilesPerHour2 = value; }
    }

    /// <summary>
    /// HO-215 Outboard motor A horsepower
    /// </summary>
    public int HO215MotorAHorsepower
    {
      get { return m_ho215MotorAHorsepower; }
      set { m_ho215MotorAHorsepower = value; }
    }

    /// <summary>
    /// HO-215 Outboard motor B horsepower
    /// </summary>
    public int HO215MotorBHorsepower
    {
      get { return m_ho215MotorBHorsepower; }
      set { m_ho215MotorBHorsepower = value; }
    }

    /// <summary>
    /// HO-215 Outboard motor C horsepower
    /// </summary>
    public int HO215MotorCHorsepower
    {
      get { return m_ho215MotorCHorsepower; }
      set { m_ho215MotorCHorsepower = value; }
    }

    /// <summary>
    /// HO-215 motor A manufacturer
    /// </summary>
    public string HO215MotorAManufacturer
    {
      get { return m_ho215MotorAManufacturer; }
      set { m_ho215MotorAManufacturer = value; }
    }

    /// <summary>
    /// HO-215 motor B manufacturer
    /// </summary>
    public string HO215MotorBManufacturer
    {
      get { return m_ho215MotorBManufacturer; }
      set { m_ho215MotorBManufacturer = value; }
    }

    /// <summary>
    /// HO-215 motor C manufacturer
    /// </summary>
    public string HO215MotorCManufacturer
    {
      get { return m_ho215MotorCManufacturer; }
      set { m_ho215MotorCManufacturer = value; }
    }

    /// <summary>
    /// HO-215 inboard description 1
    /// </summary>
    public string HO215InboardDescription1
    {
      get { return m_ho215InboardDescription1; }
      set { m_ho215InboardDescription1 = value; }
    }

    /// <summary>
    /// HO-215 inboard description 2
    /// </summary>
    public string HO215InboardDescription2
    {
      get { return m_ho215InboardDescription2; }
      set { m_ho215InboardDescription2 = value; }
    }

    /// <summary>
    /// HO-215 inboard description 3
    /// </summary>
    public string HO215InboardDescription3
    {
      get { return m_ho215InboardDescription3; }
      set { m_ho215InboardDescription3 = value; }
    }

    /// <summary>
    /// Business pursuits liability
    /// </summary>
    [Description("Business pursuits liability")]
    public bool HO220
    {
      get { return m_ho220; }
      set { m_ho220 = value; }
    }

    /// <summary>
    /// HO-220 medical payments
    /// </summary>
    public bool HO220MedicalPayments
    {
      get { return m_ho220MedicalPayments; }
      set { m_ho220MedicalPayments = value; }
    }

    /// <summary>
    /// HO-220 Owner, Partner or Financial Controller of Business
    /// </summary>
    public bool HO220IsOwner
    {
      get { return m_ho220IsOwner; }
      set { m_ho220IsOwner = value; }
    }

    /// <summary>
    /// HO-220 premium group
    /// </summary>
    public string HO220PremiumGroup
    {
      get { return m_ho220PremiumGroup; }
      set { m_ho220PremiumGroup = value; }
    }

    /// <summary>
    /// HO-220 teacher liability
    /// </summary>
    public bool HO220TeacherLiability
    {
      get { return m_ho220TeacherLiability; }
      set { m_ho220TeacherLiability = value; }
    }

    /// <summary>
    /// Additional premises liability
    /// </summary>
    [Description("Additional premises liability")]
    public bool HO225
    {
      get { return m_ho225; }
      set { m_ho225 = value; }
    }

    /// <summary>
    /// HO-225 additional residences 1 family
    /// </summary>
    public int HO225AdditionalResidencesOneFamily
    {
      get { return m_ho225AdditionalResidencesOneFamily; }
      set { m_ho225AdditionalResidencesOneFamily = value; }
    }

    /// <summary>
    /// HO-225 additional residences 2 family
    /// </summary>
    public int HO225AdditionalResidencesTwoFamily
    {
      get { return m_ho225AdditionalResidencesTwoFamily; }
      set { m_ho225AdditionalResidencesTwoFamily = value; }
    }

    /// <summary>
    /// HO-225 medical payments
    /// </summary>
    public bool HO225MedicalPayments
    {
      get { return m_ho225MedicalPayments; }
      set { m_ho225MedicalPayments = value; }
    }

    /// <summary>
    /// Additional insured
    /// </summary>
    [Description("Additional insured")]
    public bool HO301
    {
      get { return m_ho301; }
      set { m_ho301 = value; }
    }

    /// <summary>
    /// HO-301 section
    /// </summary>
    public string HO301Section
    {
      get { return m_ho301Section; }
      set { m_ho301Section = value; }
    }

    /// <summary>
    /// Townhouse loss assessment coverage
    /// </summary>
    [Description("Townhouse loss assessment coverage")]
    public bool HO310
    {
      get { return m_ho310; }
      set { m_ho310 = value; }
    }

    /// <summary>
    /// HO-310 liability limit
    /// </summary>
    public int HO310LiabilityLimit
    {
      get { return m_ho310LiabilityLimit; }
      set { m_ho310LiabilityLimit = value; }
    }

    /// <summary>
    /// Neighborhood homeonwers loss assessment
    /// </summary>
    [Description("Loss assessment")]
    public bool HO315
    {
      get { return m_ho315; }
      set { m_ho315 = value; }
    }

    /// <summary>
    /// HO-315 liability limit
    /// </summary>
    public int HO315LiabilityLimit
    {
      get { return m_ho315LiabilityLimit; }
      set { m_ho315LiabilityLimit = value; }
    }

    /// <summary>
    /// Permium surcharge - Claims
    /// </summary>
    [Description("Premium surcharge - claims")]
    public bool HO330
    {
      get { return m_ho330; }
      set { m_ho330 = value; }
    }

    /// <summary>
    /// HO-330 percent
    /// </summary>
    public int HO330Percent
    {
      get { return m_ho330Percent; }
      set { m_ho330Percent = value; }
    }

    /// <summary>
    /// Unit owners rental to others (B Con)
    /// </summary>
    [Description("Unit owners rental to others (B Con)")]
    public bool HO380
    {
      get { return m_ho380; }
      set { m_ho380 = value; }
    }

    /// <summary>
    /// Unit owners rental to others (C Con)
    /// </summary>
    [Description("Unit owners rental to others (C Con)")]
    public bool HO381
    {
      get { return m_ho381; }
      set { m_ho381 = value; }
    }

    /// <summary>
    /// Condo loss assessment coverage
    /// </summary>
    [Description("Condo loss assessment coverage")]
    public bool HO382
    {
      get { return m_ho382; }
      set { m_ho382 = value; }
    }

    /// <summary>
    /// HO-382 liability limit
    /// </summary>
    public int HO382LiabilityLimit
    {
      get { return m_ho382LiabilityLimit; }
      set { m_ho382LiabilityLimit = value; }
    }

    /// <summary>
    /// HO-101 Premium.
    /// </summary>
    public double HO101Premium
    {
      get { return m_ho101Premium; }
      set { m_ho101Premium = value; }
    }

    /// <summary>
    /// HO-103 premium
    /// </summary>
    public double HO102Premium
    {
      get { return m_ho102Premium; }
      set { m_ho102Premium = value; }
    }

    /// <summary>
    /// HO-105 premium
    /// </summary>
    public double HO105Premium
    {
      get { return m_ho105Premium; }
      set { m_ho105Premium = value; }
    }

    /// <summary>
    /// HO-110 premium
    /// </summary>
    public double HO110Premium
    {
      get { return m_ho110Premium; }
      set { m_ho110Premium = value; }
    }

    /// <summary>
    /// HO-111 premium
    /// </summary>
    public double HO111Premium
    {
      get { return m_ho111Premium; }
      set { m_ho111Premium = value; }
    }

    /// <summary>
    /// HO-113 premium
    /// </summary>
    public double HO112Premium
    {
      get { return m_ho112Premium; }
      set { m_ho112Premium = value; }
    }

    /// <summary>
    /// HO-113 premium
    /// </summary>
    public double HO113Premium
    {
      get { return m_ho113Premium; }
      set { m_ho113Premium = value; }
    }

    /// <summary>
    /// HO-120 premium
    /// </summary>
    public double HO120Premium
    {
      get { return m_ho120Premium; }
      set { m_ho120Premium = value; }
    }

    /// <summary>
    /// HO-121 premium
    /// </summary>
    public double HO121Premium
    {
      get { return m_ho121Premium; }
      set { m_ho121Premium = value; }
    }

    /// <summary>
    /// HO-122 premium
    /// </summary>
    public double HO122Premium
    {
      get { return m_ho122Premium; }
      set { m_ho122Premium = value; }
    }

    /// <summary>
    /// HO-123 premium
    /// </summary>
    public double HO123Premium
    {
      get { return m_ho123Premium; }
      set { m_ho123Premium = value; }
    }

    /// <summary>
    /// HO-125 premium
    /// </summary>
    public double HO125Premium
    {
      get { return m_ho125Premium; }
      set { m_ho125Premium = value; }
    }

    /// <summary>
    /// HO-126 premium
    /// </summary>
    public double HO126Premium
    {
      get { return m_ho126Premium; }
      set { m_ho126Premium = value; }
    }

    /// <summary>
    /// HO-130 premium
    /// </summary>
    public double HO130Premium
    {
      get { return m_ho130Premium; }
      set { m_ho130Premium = value; }
    }

    /// <summary>
    /// HO-140 premium
    /// </summary>
    public double HO140Premium
    {
      get { return m_ho140Premium; }
      set { m_ho140Premium = value; }
    }

    /// <summary>
    /// Base premium reduction for HO-140
    /// </summary>
    public double HO140BaseReduction
    {
      get { return m_ho140BaseReduction; }
      set { m_ho140BaseReduction = value; }
    }

    /// <summary>
    /// Other structures premium reduction for HO-140
    /// </summary>
    public double HO140OtherStructuresReduction
    {
      get { return m_ho140OtherStructuresReduction; }
      set { m_ho140OtherStructuresReduction = value; }
    }

    /// <summary>
    /// Deductible premium reduction for HO-140
    /// </summary>
    public double HO140DeductibleReduction
    {
      get { return m_ho140DeductibleReduction; }
      set { m_ho140DeductibleReduction = value; }
    }

    /// <summary>
    /// Ordinance or Law premium reduction for HO-140
    /// </summary>
    public double HO140OrdOrLawReduction
    {
      get { return m_ho140OrdOrLawReduction; }
      set { m_ho140OrdOrLawReduction = value; }
    }

    /// <summary>
    /// Personal Property Replacement Cost premium reduction for HO-140
    /// </summary>
    public double HO140ReplacementCostReduction
    {
      get { return m_ho140ReplacementCostReduction; }
      set { m_ho140ReplacementCostReduction = value; }
    }

    /// <summary>
    /// HO-142 premium
    /// </summary>
    public double HO142Premium
    {
      get { return m_ho142Premium; }
      set { m_ho142Premium = value; }
    }

    /// <summary>
    /// HO-160 premium
    /// </summary>
    public double HO160Premium
    {
      get { return m_ho160Premium; }
      set { m_ho160Premium = value; }
    }

    /// <summary>
    /// HO-160 Cameras sub total premium
    /// </summary>
    public double HO160CamerasSubPremium
    {
      get { return m_ho160CamerasSubPremium; }
      set { m_ho160CamerasSubPremium = value; }
    }

    /// <summary>
    /// HO-160 coin collections sub total premium
    /// </summary>
    public double HO160CoinCollectionsSubPremium
    {
      get { return m_ho160CoinCollectionsSubPremium; }
      set { m_ho160CoinCollectionsSubPremium = value; }
    }

    /// <summary>
    /// HO-160 Fine Arts sub total premium
    /// </summary>
    public double HO160FineArtsSubPremium
    {
      get { return m_ho160FineArtsSubPremium; }
      set { m_ho160FineArtsSubPremium = value; }
    }

    /// <summary>
    /// HO-160 Fine Arts with breakage sub total premium
    /// </summary>
    public double HO160FineArtsWithBreakageSubPremium
    {
      get { return m_ho160FineArtsWithBreakageSubPremium; }
      set { m_ho160FineArtsWithBreakageSubPremium = value; }
    }

    /// <summary>
    /// HO-160 Furs sub total premium
    /// </summary>
    public double HO160FursSubPremium
    {
      get { return m_ho160FursSubPremium; }
      set { m_ho160FursSubPremium = value; }
    }

    /// <summary>
    /// HO-160 Golfers equipment premium
    /// </summary>
    public double HO160GolfersEquipmentSubPremium
    {
      get { return m_ho160GolfersEquipmentSubPremium; }
      set { m_ho160GolfersEquipmentSubPremium = value; }
    }

    /// <summary>
    /// HO-160 Jewelry premium
    /// </summary>
    public double HO160JewelrySubPremium
    {
      get { return m_ho160JewelrySubPremium; }
      set { m_ho160JewelrySubPremium = value; }
    }

    /// <summary>
    /// HO-160 Musical Instruments premium
    /// </summary>
    public double HO160MusicalInstrumentsSubPremium
    {
      get { return m_ho160MusicalInstrumentsSubPremium; }
      set { m_ho160MusicalInstrumentsSubPremium = value; }
    }

    /// <summary>
    /// HO-160 Other Property premium
    /// </summary>
    public double HO160OtherPropertySubPremium
    {
      get { return m_ho160OtherPropertySubPremium; }
      set { m_ho160OtherPropertySubPremium = value; }
    }

    /// <summary>
    /// HO-160 Sivlerware premium
    /// </summary>
    public double HO160SilverwareSubPremium
    {
      get { return m_ho160SilverwareSubPremium; }
      set { m_ho160SilverwareSubPremium = value; }
    }

    /// <summary>
    /// HO-160 Stamp Collections premium
    /// </summary>
    public double HO160StampCollectionsSubPremium
    {
      get { return m_ho160StampCollectionsSubPremium; }
      set { m_ho160StampCollectionsSubPremium = value; }
    }

    /// <summary>
    /// HO-161 to 167 premium
    /// </summary>
    public double HO161To167Premium
    {
      get { return m_ho161To167Premium; }
      set { m_ho161To167Premium = value; }
    }

    /// <summary>
    /// HO-170 premium
    /// </summary>
    public double HO170Premium
    {
      get { return m_ho170Premium; }
      set { m_ho170Premium = value; }
    }

    /// <summary>
    /// HO-180 premium
    /// </summary>
    public double HO180Premium
    {
      get { return m_ho180Premium; }
      set { m_ho180Premium = value; }
    }

    /// <summary>
    /// HO-201 premium
    /// </summary>
    public double HO201Premium
    {
      get { return m_ho201Premium; }
      set { m_ho201Premium = value; }
    }

    /// <summary>
    /// HO-205 premium
    /// </summary>
    public double HO205Premium
    {
      get { return m_ho205Premium; }
      set { m_ho205Premium = value; }
    }

    /// <summary>
    /// HO-210 premium
    /// </summary>
    public double HO210Premium
    {
      get { return m_ho210Premium; }
      set { m_ho210Premium = value; }
    }

    /// <summary>
    /// HO-215 premium
    /// </summary>
    public double HO215Premium
    {
      get { return m_ho215Premium; }
      set { m_ho215Premium = value; }
    }

    /// <summary>
    /// HO-220 premium
    /// </summary>
    public double HO220Premium
    {
      get { return m_ho220Premium; }
      set { m_ho220Premium = value; }
    }

    /// <summary>
    /// HO-225 premium
    /// </summary>
    public double HO225Premium
    {
      get { return m_ho225Premium; }
      set { m_ho225Premium = value; }
    }

    /// <summary>
    /// HO-301 premium
    /// </summary>
    public double HO301Premium
    {
      get { return m_ho301Premium; }
      set { m_ho301Premium = value; }
    }

    /// <summary>
    /// HO-310 premium
    /// </summary>
    public double HO310Premium
    {
      get { return m_ho310Premium; }
      set { m_ho310Premium = value; }
    }

    /// <summary>
    /// HO-315 Premium
    /// </summary>
    public double HO315Premium
    {
      get { return m_ho315Premium; }
      set { m_ho315Premium = value; }
    }

    /// <summary>
    /// Ho-330 premium
    /// </summary>
    public double HO330Premium
    {
      get { return m_ho330Premium; }
      set { m_ho330Premium = value; }
    }

    /// <summary>
    /// HO-380 premium
    /// </summary>
    public double HO380Premium
    {
      get { return m_ho380Premium; }
      set { m_ho380Premium = value; }
    }

    /// <summary>
    /// HO-381 premium
    /// </summary>
    public double HO381Premium
    {
      get { return m_ho381Premium; }
      set { m_ho381Premium = value; }
    }

    /// <summary>
    /// HO-382 premium
    /// </summary>
    public double HO382Premium
    {
      get { return m_ho382Premium; }
      set { m_ho382Premium = value; }
    }

    /// <summary>
    /// Windstorm, Hurricane and Hail Exclusion endorsement for Dwelling Fire
    /// </summary>
    public bool DFWindstormExclusion
    {
      get { return m_dfWindstormExclusion; }
      set { m_dfWindstormExclusion = value; }
    }

    /// <summary>
    /// Replacement Cost for Personal Property endorsement for Dwelling Fire
    /// </summary>
    public bool DFReplacementCostPersonalProperty
    {
      get { return m_dfReplacementCostPersonalProperty; }
      set { m_dfReplacementCostPersonalProperty = value; }
    }

    /// <summary>
    /// Calculated Premium for Replacement Cost Personal Property for Dwelling Fire
    /// </summary>
    public double DFReplacementCostPersonalPropertyPremium
    {
      get { return m_dfReplacementCostPersonalPropertyPremium; }
      set { m_dfReplacementCostPersonalPropertyPremium = value; }
    }

    /// <summary>
    /// Exclusion of Residential Community Property Clause endo for Dwelling Fire
    /// </summary>
    public bool DFExclusionOfResidentialCommunityPropertyClause
    {
      get { return m_dfExclusionOfResidentialCommunityPropertyClause; }
      set { m_dfExclusionOfResidentialCommunityPropertyClause = value; }
    }

    /// <summary>
    /// Additional Named Insured endorsement for Dwelling Fire
    /// </summary>
    public bool DFAdditionalNamedInsured
    {
      get { return m_dfAdditionalNamedInsured; }
      set { m_dfAdditionalNamedInsured = value; }
    }

    /// <summary>
    /// Number of Additional Named Insureds for Dwelling Fire
    /// </summary>
    public int DFNumOfAdditionalNamedInsured
    {
      get { return m_dfNumOfAdditionalNamedInsured; }
      set { m_dfNumOfAdditionalNamedInsured = value; }
    }

    /// <summary>
    /// Calculated premium for Additional Named Insured for Dwelling Fire
    /// </summary>
    public double DFAdditionalNamedInsuredPremium
    {
      get { return m_dfAdditionalNamedInsuredPremium; }
      set { m_dfAdditionalNamedInsuredPremium = value; }
    }

    /// <summary>
    /// Agreed Amount on Dwelling endorsement for Dwelling Fire
    /// </summary>
    public bool DFAgreedAmountOnDwelling
    {
      get { return m_dfAgreedAmountOnDwelling; }
      set { m_dfAgreedAmountOnDwelling = value; }
    }

    /// <summary>
    /// Residence Glass Coverage endorsement for Dwelling Fire
    /// </summary>
    public bool DFResidenceGlass
    {
      get { return m_dfResidenceGlass; }
      set { m_dfResidenceGlass = value; }
    }

    /// <summary>
    /// Residence Glass Coverage limit for Dwelling Fire
    /// </summary>
    public int DFResidenceGlassLimit
    {
      get { return m_dfResidenceGlassLimit; }
      set { m_dfResidenceGlassLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Residence Glass for Dwelling Fire
    /// </summary>
    public double DFResidenceGlassPremium
    {
      get { return m_dfResidenceGlassPremium; }
      set { m_dfResidenceGlassPremium = value; }
    }

    /// <summary>
    /// Loss Payable Clause endorsement for Dwelling Fire
    /// </summary>
    public bool DFLossPayableClause
    {
      get { return m_dfLossPayableClause; }
      set { m_dfLossPayableClause = value; }
    }

    /// <summary>
    /// Number of Loss Payees for Dwelling Fire
    /// </summary>
    public int DFNumOfLossPayees
    {
      get { return m_dfNumOfLossPayees; }
      set { m_dfNumOfLossPayees = value; }
    }

    /// <summary>
    /// Calculated Premium for Loss Payable Clause for Dwelling Fire
    /// </summary>
    public double DFLossPayableClausePremium
    {
      get { return m_dfLossPayableClausePremium; }
      set { m_dfLossPayableClausePremium = value; }
    }

    /// <summary>
    /// Vacancy Clause endorsement for Dwelling Fire
    /// </summary>
    public bool DFVacancyClause
    {
      get { return m_dfVacancyClause; }
      set { m_dfVacancyClause = value; }
    }

    /// <summary>
    /// Number of Vacancy Months for Dwelling Fire
    /// </summary>
    public int DFNumOfVacancyMonths
    {
      get { return m_dfNumOfVacancyMonths; }
      set { m_dfNumOfVacancyMonths = value; }
    }

    /// <summary>
    /// Calculated premium for Vacancy Clause for Dwelling Fire
    /// </summary>
    public double DFVacancyClausePremium
    {
      get { return m_dfVacancyClausePremium; }
      set { m_dfVacancyClausePremium = value; }
    }

    /// <summary>
    /// Miscellaneous Property Schedule endorsement for Dwelling Fire
    /// </summary>
    public bool DFMiscellaneousPropertySchedule
    {
      get { return m_dfMiscellaneousPropertySchedule; }
      set { m_dfMiscellaneousPropertySchedule = value; }
    }

    /// <summary>
    /// Calculated total premium for Misc Property in Dwelling Fire
    /// </summary>
    public double DFMiscellaneousPropertySchedulePremium
    {
      get { return m_dfMiscellaneousPropertySchedulePremium; }
      set { m_dfMiscellaneousPropertySchedulePremium = value; }
    }

    /// <summary>
    /// Limit for Outbuildings under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropOutbuildingsLimit
    {
      get { return m_dfMiscPropOutbuildingsLimit; }
      set { m_dfMiscPropOutbuildingsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Misc Property Outbuildings for Dwelling Fire
    /// </summary>
    public double DFMiscPropOutbuildingsPremium
    {
      get { return m_dfMiscPropOutbuildingsPremium; }
      set { m_dfMiscPropOutbuildingsPremium = value; }
    }

    /// <summary>
    /// Limit for Boat Houses and Docks under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropBoatHousesLimit
    {
      get { return m_dfMiscPropBoatHousesLimit; }
      set { m_dfMiscPropBoatHousesLimit = value; }
    }

    /// <summary>
    /// Calculated preium for Misc Property Boat Houses for Dwelling Fire
    /// </summary>
    public double DFMiscPropBoatHousesPremium
    {
      get { return m_dfMiscPropBoatHousesPremium; }
      set { m_dfMiscPropBoatHousesPremium = value; }
    }

    /// <summary>
    /// Limit for Cloth Awnings under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropClothAwningsLimit
    {
      get { return m_dfMiscPropClothAwningsLimit; }
      set { m_dfMiscPropClothAwningsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Misc Prop Cloth Awnings for Dwelling Fire
    /// </summary>
    public double DFMiscPropClothAwningsPremium
    {
      get { return m_dfMiscPropClothAwningsPremium; }
      set { m_dfMiscPropClothAwningsPremium = value; }
    }

    /// <summary>
    /// Limit for Fences under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropFencesLimit
    {
      get { return m_dfMiscPropFencesLimit; }
      set { m_dfMiscPropFencesLimit = value; }
    }

    /// <summary>
    /// Calculated Premium for Misc Prop Fences for Dwelling Fire
    /// </summary>
    public double DFMiscPropFencesPremium
    {
      get { return m_dfMiscPropFencesPremium; }
      set { m_dfMiscPropFencesPremium = value; }
    }

    /// <summary>
    /// Limit for Flag Poles under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropFlagPolesLimit
    {
      get { return m_dfMiscPropFlagPolesLimit; }
      set { m_dfMiscPropFlagPolesLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Misc Prop Flag Poles for Dwelling Fire
    /// </summary>
    public double DFMiscPropFlagPolesPremium
    {
      get { return m_dfMiscPropFlagPolesPremium; }
      set { m_dfMiscPropFlagPolesPremium = value; }
    }

    /// <summary>
    /// Limit for Flood Lights on Metal Poles under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropFloodLightsMetalPoleLimit
    {
      get { return m_dfMiscPropFloodLightsMetalPoleLimit; }
      set { m_dfMiscPropFloodLightsMetalPoleLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Misc Prop Flood Lights on Metal Poles for Dwelling Fire
    /// </summary>
    public double DFMiscPropFloodLightsMetalPolePremium
    {
      get { return m_dfMiscPropFloodLightsMetalPolePremium; }
      set { m_dfMiscPropFloodLightsMetalPolePremium = value; }
    }

    /// <summary>
    /// Limit for Flood Lights on Wood Poles under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropFloodLightsWoodPoleLimit
    {
      get { return m_dfMiscPropFloodLightsWoodPoleLimit; }
      set { m_dfMiscPropFloodLightsWoodPoleLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Flood Lights on Wood Poles for Dwelling Fire
    /// </summary>
    public double DFMiscPropFloodLightsWoodPolePremium
    {
      get { return m_dfMiscPropFloodLightsWoodPolePremium; }
      set { m_dfMiscPropFloodLightsWoodPolePremium = value; }
    }

    /// <summary>
    /// Limit for Plain Glass Greenhouses under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropPlainGlassGreenhouseLimit
    {
      get { return m_dfMiscPropPlainGlassGreenhouseLimit; }
      set { m_dfMiscPropPlainGlassGreenhouseLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Plain Glass Greenhouses for Dwelling Fire
    /// </summary>
    public double DFMiscPropPlainGlassGreenhousePremium
    {
      get { return m_dfMiscPropPlainGlassGreenhousePremium; }
      set { m_dfMiscPropPlainGlassGreenhousePremium = value; }
    }

    /// <summary>
    /// Limit for Greenhouses Not Plain Glass under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropGreenhousesNotPlainGlassLimit
    {
      get { return m_dfMiscPropGreenhousesNotPlainGlassLimit; }
      set { m_dfMiscPropGreenhousesNotPlainGlassLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Greenhouses Not Plain Glass for Dwelling Fire
    /// </summary>
    public double DFMiscPropGreenhousesNotPlainGlassPremium
    {
      get { return m_dfMiscPropGreenhousesNotPlainGlassPremium; }
      set { m_dfMiscPropGreenhousesNotPlainGlassPremium = value; }
    }

    /// <summary>
    /// Limit for Land and Outside Site Improvements under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropLandAndOutsideSiteImprovementsLimit
    {
      get { return m_dfMiscPropLandAndOutsideSiteImprovementsLimit; }
      set { m_dfMiscPropLandAndOutsideSiteImprovementsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Land and Outside Site Improvements for Dwelling Fire
    /// </summary>
    public double DFMiscPropLandAndOutsideSiteImprovementsPremium
    {
      get { return m_dfMiscPropLandAndOutsideSiteImprovementsPremium; }
      set { m_dfMiscPropLandAndOutsideSiteImprovementsPremium = value; }
    }

    /// <summary>
    /// Limit for Masonry, Tile or Concrete Swimming Pools under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropMasonrySwimmingPoolsLimit
    {
      get { return m_dfMiscPropMasonrySwimmingPoolsLimit; }
      set { m_dfMiscPropMasonrySwimmingPoolsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Misc Prop Masonry Swimming Pools for Dwelling Fire
    /// </summary>
    public double DFMiscPropMasonrySwimmingPoolsPremium
    {
      get { return m_dfMiscPropMasonrySwimmingPoolsPremium; }
      set { m_dfMiscPropMasonrySwimmingPoolsPremium = value; }
    }

    /// <summary>
    /// Limit for Swimming Pools not Masonry, Tile or Concrete under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropNonMasonrySwimmingPoolsLimit
    {
      get { return m_dfMiscPropNonMasonrySwimmingPoolsLimit; }
      set { m_dfMiscPropNonMasonrySwimmingPoolsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Non-Masonry Swimming Pools for Dwelling Fire
    /// </summary>
    public double DFMiscPropNonMasonrySwimmingPoolsPremium
    {
      get { return m_dfMiscPropNonMasonrySwimmingPoolsPremium; }
      set { m_dfMiscPropNonMasonrySwimmingPoolsPremium = value; }
    }

    /// <summary>
    /// Limit for Tennis and Slab Courts under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropTennisAndSlabCourtsLimit
    {
      get { return m_dfMiscPropTennisAndSlabCourtsLimit; }
      set { m_dfMiscPropTennisAndSlabCourtsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Tennis and Slab Courts for Dwelling Fire
    /// </summary>
    public double DFMiscPropTennisAndSlabCourtsPremium
    {
      get { return m_dfMiscPropTennisAndSlabCourtsPremium; }
      set { m_dfMiscPropTennisAndSlabCourtsPremium = value; }
    }

    /// <summary>
    /// Limit for TV And Radio Antenna under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropTVAndRadioAntennaLimit
    {
      get { return m_dfMiscPropTVAndRadioAntennaLimit; }
      set { m_dfMiscPropTVAndRadioAntennaLimit = value; }
    }

    /// <summary>
    /// Calculated premium for TV and Radio Antenna for Dwelling Fire
    /// </summary>
    public double DFMiscPropTVAndRadioAntennaPremium
    {
      get { return m_dfMiscPropTVAndRadioAntennaPremium; }
      set { m_dfMiscPropTVAndRadioAntennaPremium = value; }
    }

    /// <summary>
    /// Limit for Trees, Plants and Shrubs under DF Misc Property Schedule
    /// </summary>
    public int DFMiscPropTreesPlantsAndShrubsLimit
    {
      get { return m_dfMiscPropTreesPlantsAndShrubsLimit; }
      set { m_dfMiscPropTreesPlantsAndShrubsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Trees, Plants and Shrubs for Dwelling Fire
    /// </summary>
    public double DFMiscPropTreesPlantsAndShrubsPremium
    {
      get { return m_dfMiscPropTreesPlantsAndShrubsPremium; }
      set { m_dfMiscPropTreesPlantsAndShrubsPremium = value; }
    }

    /// <summary>
    /// Limit for Windmills and Windchargers under DF Misc Property Scheduled
    /// </summary>
    public int DFMiscPropWindmillsLimit
    {
      get { return m_dfMiscPropWindmillsLimit; }
      set { m_dfMiscPropWindmillsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Windmills for Dwelling Fire
    /// </summary>
    public double DFMiscPropWindmillsPremium
    {
      get { return m_dfMiscPropWindmillsPremium; }
      set { m_dfMiscPropWindmillsPremium = value; }
    }

    /// <summary>
    /// Loss Assessment Property Coverage endorsement for Dwelling Fire
    /// </summary>
    public bool DFLossAssessmentPropertyCoverage
    {
      get { return m_dfLossAssessmentPropertyCoverage; }
      set { m_dfLossAssessmentPropertyCoverage = value; }
    }

    /// <summary>
    /// Coverage Limit for Loss Assessment Property Coverage under Dwelling Fire
    /// </summary>
    public int DFLossAssessmentLimit
    {
      get { return m_dfLossAssessmentLimit; }
      set { m_dfLossAssessmentLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Loss Assessment for Dwelling Fire
    /// </summary>
    public double DFLossAssessmentPropertyCoveragePremium
    {
      get { return m_dfLossAssessmentPropertyCoveragePremium; }
      set { m_dfLossAssessmentPropertyCoveragePremium = value; }
    }

    /// <summary>
    /// Contract of Sale endorsement for Dwelling Fire
    /// </summary>
    public bool DFContractOfSale
    {
      get { return m_dfContractOfSale; }
      set { m_dfContractOfSale = value; }
    }

    /// <summary>
    /// Calculated premium for Contract of Sale for Dwelling Fire
    /// </summary>
    public double DFContractOfSalePremium
    {
      get { return m_dfContractOfSalePremium; }
      set { m_dfContractOfSalePremium = value; }
    }

    /// <summary>
    /// Identity fraud expense coverage
    /// </summary>
    [Description("HO 455")]
    public virtual bool HO0455
    {
      get { return m_ho0455; }
      set { m_ho0455 = value; }
    }

    /// <summary>
    /// Identity fraud expense coverage premium 
    /// </summary>
    public virtual double HO0455Premium
    {
      get { return m_ho0455Premium; }
      set { m_ho0455Premium = value; }
    }

    /// <summary>
    /// Foundation coverage
    /// </summary>
    [Description("Foundation Coverage")]
    public virtual bool HO0468
    {
      get { return m_ho0468; }
      set { m_ho0468 = value; }
    }

    /// <summary>
    /// Foundation coverage premium
    /// </summary>
    public virtual double HO0468Premium
    {
      get { return m_ho0468Premium; }
      set { m_ho0468Premium = value; }
    }

    /// <summary>
    /// Water Back Up and Sump Discharge or Overflow 
    /// </summary>
    [Description("Water Back Up & Sump Discharge or Overflow")]
    public virtual bool HO0495
    {
      get { return m_ho0495; }
      set { m_ho0495 = value; }
    }

    /// <summary>
    /// Water Back Up and Sump Discharge or Overflow premium
    /// </summary>
    public virtual double HO0495Premium
    {
      get { return m_ho0495Premium; }
      set { m_ho0495Premium = value; }
    }

    /// <summary>
    /// Water Damage Coverage 
    /// </summary>
    [Description("Water Damage Coverage")]
    public virtual bool HO0483
    {
      get { return m_ho0483; }
      set { m_ho0483 = value; }
    }

    /// <summary>
    /// Water Damage Coverage premium
    /// </summary>
    public virtual double HO0483Premium
    {
      get { return m_ho0483Premium; }
      set { m_ho0483Premium = value; }
    }

    /// <summary>
    /// Ordinance or law coverage
    /// </summary>
    [Description("Ordinance or Law Coverage")]
    public virtual bool HO0477
    {
      get { return m_ho0477; }
      set { m_ho0477 = value; }
    }

    /// <summary>
    /// Ordinance or law percentage of coverage
    /// </summary>
    [Description("Ordinance or Law Percentage of coverage")]
    public virtual int HO0477Ordinance
    {
      get { return m_ho0477Ordinance; }
      set { m_ho0477Ordinance = value; }
    }

    /// <summary>
    /// Ordinance or Law percentage actually rated by company
    /// </summary>
    public virtual int HO0477CoOrdinance
    {
      get { return m_ho0477CoOrdinance; }
      set { m_ho0477CoOrdinance = value; }
    }

    /// <summary>
    /// Ordinance or law coverage premium 
    /// </summary>
    public virtual double HO477Premium
    {
      get { return m_ho477Premium; }
      set { m_ho477Premium = value; }
    }
  }
}
