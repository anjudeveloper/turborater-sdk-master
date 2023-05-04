using System;
using System.ComponentModel;

namespace TurboRater.Insurance.HO
{

  /// <summary>
  /// Base class for ISO-enabled homeowners endorsements.
  /// </summary>
  [Serializable]
  public class HOISOEndorsements : HOEndorsements
  {
    private int m_policyLinkID = ITCConstants.InvalidNum;
    private bool m_ho0015;
    private double m_ho0015Premium;
    private bool m_ho493;
    private double m_ho493Premium;
    private bool m_ho527;
    private double m_ho527Premium;
    private string m_ho527StudentName = string.Empty;
    private string m_ho527City = string.Empty;
    private string m_ho527SchoolName = string.Empty;
    private string m_ho527Address = string.Empty;
    private string m_ho527State = string.Empty;
    private bool m_ho412;
    private bool m_ho412InStorage;
    private bool m_ho412OnPremises;
    private int m_ho412TotalLimit;
    private double m_ho412Premium;
    private bool m_ho2471;
    private bool m_ho2471MedicalPayments;
    private bool m_ho2471IsOwner;
    private bool m_ho2471EligibleBusinessClassA;
    private bool m_ho2471EligibleBusinessClassB;
    private string m_ho2471PremiumGroup = "A";
    private bool m_ho2471TeacherLiability;
    private int m_ho2471Employees = 1;
    private double m_ho2471Premium;
    private bool m_ho0466;
    private int m_ho0466Jewelry;
    private int m_ho0466Money;
    private int m_ho0466Securities;
    private int m_ho0466Silverware;
    private int m_ho0466Firearms;
    private int m_ho0466Furs;
    private int m_ho0466Electronics;
    private double m_ho0466JewelrySubPremium;
    private double m_ho0466MoneySubPremium;
    private double m_ho0466SecuritiesSubPremium;
    private double m_ho0466SilverwareSubPremium;
    private double m_ho0466FirearmsSubPremium;
    private double m_ho0466FursSubPremium;
    private double m_ho0466ElectronicsSubPremium;
    private double m_ho0466Premium;
    private bool m_ho0453;
    private int m_ho0453TotalLimit;
    private int m_coHO0453TotalLimit;
    private double m_ho0453Premium;
    private bool m_ho0454;
    private string m_ho0454Veneer = string.Empty;
    private int m_ho0454Dwelling;
    private int m_ho0454OtherStructures;
    private int m_ho0454Contents = 5000;
    private int m_ho0454LossOfUse = 1500;
    private bool m_ho0454SlopeOver30;
    private bool m_ho0454ArtificialFill;
    private bool m_ho0454EngineeringServices;
    private double m_ho0454EngineeringServicesPremium;
    private bool m_ho0454ReconstructionCost;
    private double m_ho0454ReconstructionCostPremium;
    private double m_ho0454Premium;
    private int m_ho0454Deductible = 5;
    private bool m_ho0497;
    private int m_ho0497NumberOfPeople;
    private double m_ho0497Premium;
    private bool m_ho0455;
    private double m_ho0455Premium;
    private bool m_ho2472;
    private double m_ho2472Premium;
    private bool m_ho2383;
    private double m_ho2383Premium;
    private bool m_ho0477;
    private int m_ho0477Ordinance;
    private int m_coHO0477Ordinance;
    private double m_ho477Premium;
    private bool m_ho0458;
    private string m_ho0458FirstName = string.Empty;
    private string m_ho0458LastName = string.Empty;
    private double m_ho0458Premium;
    private bool m_ho2443;
    private bool m_ho2443Dwelling;
    private bool m_ho2443AnotherBusiness;
    private bool m_ho2443Office;
    private double m_ho2443Premium;
    private bool m_ho0442;
    private bool m_ho0442Dwelling;
    private bool m_ho0442AnotherBusiness;
    private bool m_ho0442Office;
    private string m_ho0442BusinessDescription = string.Empty;
    private int m_ho0442OtherStructureLimit;
    private bool m_ho0442SectionII;
    private bool m_ho0442ProfessionalInstruction;
    private double m_ho0442Premium;
    private bool m_ho2482;
    private double m_ho2482Premium;
    private bool m_ho0450;
    private int m_ho0450IncreasedLimit;
    private double m_ho0450Premium;
    private bool m_ho0498;
    private double m_ho0498Premium;
    private bool m_ho0490;
    private int m_ho0490Limit;
    private double m_ho0490Premium;
    private bool m_ho0440;
    private int m_ho0440Value;
    private double m_ho0440Premium;
    private bool m_ho998016;
    private int m_ho998016Limit;
    private double m_ho998016Premium;
    private bool m_waterBackup;
    private int m_waterBackupLimit;
    private double m_waterBackupPremium;
    private bool m_ho0492;
    private int m_ho0492Limit;
    private double m_ho0492Premium;
    private bool m_ho0416;
    private string m_ho0416ProtectiveDevices = string.Empty;
    private double m_ho0416Premium;
    private bool m_ho0461;
    private int m_ho0461BicyclesLimit;
    private double m_ho0461BicyclesSubPremium;
    private int m_ho0461CameraLimit;
    private double m_ho0461CameraSubPremium;
    private int m_ho0461ProfessionalCameraLimit;
    private double m_ho0461ProfessionalCameraSubPremium;
    private int m_ho0461CollectiblesLimit;
    private double m_ho0461CollectiblesSubPremium;
    private int m_ho0461CoinsLimit;
    private double m_ho0461CoinsSubPremium;
    private int m_ho0461FineArtsWithoutBreakageLimit;
    private double m_ho0461FineArtsWithoutBreakageSubPremium;
    private int m_ho0461FineArtsWithBreakageLimit;
    private double m_ho0461FineArtsWithBreakageSubPremium;
    private int m_ho0461CollectibleFirearmsLimit;
    private double m_ho0461CollectibleFirearmsSubPremium;
    private int m_ho0461FirearmsLimit;
    private double m_ho0461FirearmsSubPremium;
    private int m_ho0461FursLimit;
    private double m_ho0461FursSubPremium;
    private int m_ho0461GolfersEquipmentLimit;
    private double m_ho0461GolfersEquipmentSubPremium;
    private int m_ho0461JewelryLimit;
    private double m_ho0461JewelrySubPremium;
    private int m_ho0461JewelryInVaultsLimit;
    private double m_ho0461JewelryInVaultsSubPremium;
    private int m_ho0461MusicalInstrumentsLimit;
    private double m_ho0461MusicalInstrumentsSubPremium;
    private int m_ho0461ProfessionalMusicalInstrumentsLimit;
    private double m_ho0461ProfessionalMusicalInstrumentsSubPremium;
    private int m_ho0461SportsEquipmentLimit;
    private double m_ho0461SportsEquipmentSubPremium;
    private int m_ho0461SilverwareLimit;
    private double m_ho0461SilverwareSubPremium;
    private int m_ho0461StampsLimit;
    private double m_ho0461StampsSubPremium;
    private double m_ho0461Premium;
    private bool m_scheduledGlass;
    private int m_scheduledGlassLimit;
    private double m_scheduledGlassPremium;
    private bool m_ho2470;
    private int m_ho24701Family;
    private int m_ho24702Family;
    private int m_ho24703Family;
    private int m_ho24704Family;
    private double m_ho2470Premium;
    private int m_ho2472OnPremises;
    private double m_ho2472OnPremisesSubPremium;
    private int m_ho2472OffPremises;
    private double m_ho2472OffPremisesSubPremium;
    private bool m_ho0435;
    private int m_ho0435ResidencePremise = 1000;
    private bool m_ho0435AdditionalResidences;
    private int m_ho0435NumAdditionalResidences = 1;
    private int m_ho0435AdditionalResidence1 = 1000;
    private int m_ho0435AdditionalResidence2 = 1000;
    private int m_ho0435AdditionalResidence3 = 1000;
    private int m_ho0435AdditionalResidence4 = 1000;
    private double m_ho0435Premium;
    private bool m_earthquakeLossAssessment;
    private int m_earthquakeLossAssessmentLimit;
    private double m_earthquakeLossAssessmentPremium;
    private int m_ho0498Limit;
    private bool m_ho0499;
    private double m_ho0499Premium;
    private bool m_ho2475;
    private string m_ho2475WatercraftType1 = WatercraftType.None.ToString();
    private int m_ho2475Horsepower1;
    private int m_ho2475MilesPerHour1;
    private int m_ho2475Length1;
    private string m_ho2475WatercraftType2 = WatercraftType.None.ToString();
    private int m_ho2475Horsepower2;
    private int m_ho2475MilesPerHour2;
    private int m_ho2475Length2;
    private double m_ho2475Premium;
    private bool m_ho2464;
    private int m_ho2464NumberOfSnowmobiles;
    private double m_ho2464Premium;
    private bool m_ho0494;
    private double m_ho0494CreditPremium;
    private bool m_ho0444;
    private int m_ho0444NumOfFamilies = 3;
    private bool m_ho0446;
    private int m_ho0446Percentage = 4;
    private int m_coHO0446Percentage = 4;
    private double m_ho0446Premium;
    private bool m_incidentalFarmingOnPremises;
    private bool m_incidentalFarmingAwayFromPremises;
    private bool m_ho0524;
    private double m_ho0524Premium;
    private bool m_ho1731;
    private double m_ho1731Premium;
    private bool m_ho1732;
    private double m_ho1732Premium;
    private bool m_mold;
    private int m_moldLimit;
    private int m_coMoldLimit;
    private double m_moldPremium;
    private bool m_waterDamageExclusion;
    private double m_waterDamageExclusionPremium;
    private bool m_limitedWaterDamageCoverage;
    private double m_limitedWaterDamageCoveragePremium;
    private bool m_limitedHurricaneOutdoorProperty;
    private int m_limitedHurricaneOutdoorPropertyLimit;
    private int m_coLimitedHurricaneOutdoorPropertyLimit;
    private double m_limitedHurricaneOutdoorPropertyPremium;
    private bool m_ho0420;
    private double m_ho0420Premium;
    private bool m_golfcartLiability;
    private int m_numberOfGolfcarts;
    private double m_golfcartLiabilityPremium;

    private bool m_dfAutomaticIncreaseInInsurance;
    private int m_dfAutomaticIncreaseInInsurancePercent = 4;
    private double m_dfAutomaticIncreaseInInsurancePremium;
    private bool m_dfEarthquake;
    private int m_dfEarthquakeZone;
    private int m_dfEarthquakeDeductible;
    private bool m_dfEarthquakeRateVeneerAsMasonry;
    private double m_dfEarthquakePremium;
    private bool m_dfImprovementsAdditionsAndAlterations;
    private int m_dfImprovementsAdditionsAndAlterationsLimit;
    private double m_dfImprovementsAdditionsAndAlterationsPremium;
    private bool m_dfInflationGuard;
    private double m_dfInflationGuardPremium;
    private bool m_dfLossAssessmentCoverage;
    private int m_dfLossAssessmentCoverageLimit;
    private double m_dfLossAssessmentCoveragePremium;
    private bool m_dfOrdinanceOrLaw;
    private int m_dfOrdinanceOrLawPercentage = 10;
    private double m_dfOrdinanceOrLawPremium;
    private bool m_dfTreesShrubsAndPlants;
    private int m_dfTreesShrubsAndPlantsLimit;
    private double m_dfTreesShrubsAndPlantsPremium;
    private bool m_dfBroadTheftCoverageOnPremises;
    private int m_dfBroadTheftOnPremisesLimit = 1000;
    private double m_dfBroadTheftOnPremisesPremium;
    private bool m_dfBroadTheftCoverageOffPremises;
    private double m_dfBroadTheftOffPremisesPremium;
    private int m_dfBroadTheftOffPremisesLimit = 1000;
    private bool m_dfLimitedTheftCoverage;
    private int m_dfLimitedTheftCoverageLimit = 1000;
    private double m_dfLimitedTheftCoveragePremium;
    private bool m_dfAdditionalInsuredLocation;
    private int m_dfAdditionalInsuredLocationNumOfFamilies = 1;
    private double m_dfAdditionalInsuredLocationPremium;
    private bool m_dfAdditionalResidenceRentedToOthers;
    private int m_dfNumOfAdd1FamResidenceRentedToOthers;
    private double m_dfAdd1FamResidenceRentedToOthersPremium;
    private int m_dfNumOfAdd2FamResidenceRentedToOthers;
    private double m_dfAdd2FamResidenceRentedToOthersPremium;
    private int m_dfNumOfAdd3FamResidenceRentedToOthers;
    private double m_dfAdd3FamResidenceRentedToOthersPremium;
    private int m_dfNumOfAdd4FamResidenceRentedToOthers;
    private double m_dfAdd4FamResidenceRentedToOthersPremium;
    private double m_dfAdditionalResidenceRentedToOthersPremium;
    private bool m_dfAdditionalNamedInsured;
    private int m_dfNumOfAdditionalInsureds = 1;
    private double m_dfAdditionalNamedInsuredPremium;
    private bool m_dfAnimalLiabilityLimitation;
    private double m_dfAnimalLiabilityPremium;
    private bool m_dfAnimalLiabilityExclusion;
    private double m_dfAnimalLiabilityExclusionPremium;
    private bool m_dfBusinessPursuits;
    private int m_dfBusinessPursuitsNumOfEmployees = 1;
    private string m_dfBusinessPursuitsClassification = "A";
    private bool m_dfBusinessPursuitsCorporalPunishement;
    private double m_dfBusinessPursuitsPremium;
    private bool m_dfHomeDayCare;
    private double m_dfHomeDayCarePremium;
    private bool m_dfPermittedIncidentalOccupancy;
    private double m_dfPermittedIncidentalOccupancyPremium;
    private bool m_dfWatercraftLiability;
    private int m_dfWatercraftLiabilityNumOfBoats = 1;
    private double m_dfWatercraftLiabilityPremium;
    private bool m_dfWorkersCompensation;
    private int m_dfNumOfOccasionalEmployees;
    private int m_dfNumOfInservantEmployees;
    private int m_dfNumOfPartTimeInservantEmployees;
    private int m_dfNumOfOutservantEmployees;
    private int m_dfNumOfPartTimeOutservantEmployees;
    private double m_dfWorkersCompOccasionalEmployeesPremium;
    private double m_dfWorkersCompFullTimeInservantEmployeesPremium;
    private double m_dfWorkersCompPartTimeInservantEmployeesPremium;
    private double m_dfWorkersCompFullTimeOutservantEmployeesPremium;
    private double m_dfWorkersCompPartTimeOutservantEmployeesPremium;
    private double m_dfWorkersCompensationPremium;

    /// <summary>
    /// foreign-key link back to the policy
    /// </summary>
    public new int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// Special Personal Property
    /// </summary>
    [Description("HO 015")]
    public virtual bool HO0015
    {
      get { return m_ho0015; }
      set { m_ho0015 = value; }
    }

    /// <summary>
    /// Special Personal Property Premium
    /// </summary>
    public virtual double HO0015Premium
    {
      get { return m_ho0015Premium; }
      set { m_ho0015Premium = value; }
    }

    /// <summary>
    /// ACV - Wind / Hail to roof
    /// </summary>
    [Description("HO 493")]
    public virtual bool HO493
    {
      get { return m_ho493; }
      set { m_ho493 = value; }
    }

    /// <summary>
    /// ACV - Wind / Hail to roof Premium 
    /// </summary>
    public virtual double HO493Premium
    {
      get { return m_ho493Premium; }
      set { m_ho493Premium = value; }
    }

    /// <summary>
    /// Additional Insured - resident premises
    /// </summary>
    [Description("HO 527")]
    public virtual bool HO527
    {
      get { return m_ho527; }
      set { m_ho527 = value; }
    }

    /// <summary>
    /// Additional Insured - resident premises premium 
    /// </summary>
    public virtual double HO527Premium
    {
      get { return m_ho527Premium; }
      set { m_ho527Premium = value; }
    }

    /// <summary>
    /// Additional Insured - resident premises; Student name
    /// </summary>
    [Description("HO 527 Student Name")]
    public virtual string HO527StudentName
    {
      get { return m_ho527StudentName; }
      set { m_ho527StudentName = value; }
    }

    /// <summary>
    /// Additional Insured - resident premises; City
    /// </summary>
    [Description("HO 527 City")]
    public virtual string HO527City
    {
      get { return m_ho527City; }
      set { m_ho527City = value; }
    }

    /// <summary>
    /// Additional Insured - resident premises; School Name 
    /// </summary>
    [Description("HO 527 School Name")]
    public virtual string HO527SchoolName
    {
      get { return m_ho527SchoolName; }
      set { m_ho527SchoolName = value; }
    }

    /// <summary>
    /// Additional Insured - resident premises; Address
    /// </summary>
    [Description("HO 527 Address")]
    public virtual string HO527Address
    {
      get { return m_ho527Address; }
      set { m_ho527Address = value; }
    }

    /// <summary>
    /// Additional Insured - resident premises; State
    /// </summary>
    [Description("HO 527 State")]
    public virtual string HO527State
    {
      get { return m_ho527State; }
      set { m_ho527State = value; }
    }

    /// <summary>
    /// Business Property
    /// </summary>
    [Description("HO 412")]
    public virtual bool HO412
    {
      get { return m_ho412; }
      set { m_ho412 = value; }
    }

    /// <summary>
    /// Business Property - In Storage
    /// </summary>
    [Description("HO 412 In Storage")]
    public virtual bool HO412InStorage
    {
      get { return m_ho412InStorage; }
      set { m_ho412InStorage = value; }
    }

    /// <summary>
    /// Business Property - On Premises
    /// </summary>
    [Description("HO 412 On Premises")]
    public virtual bool HO412OnPremises
    {
      get { return m_ho412OnPremises; }
      set { m_ho412OnPremises = value; }
    }

    /// <summary>
    /// Business Property - Total Limit
    /// </summary>
    [Description("HO 412 Total Limit")]
    public virtual int HO412TotalLimit
    {
      get { return m_ho412TotalLimit; }
      set { m_ho412TotalLimit = value; }
    }

    /// <summary>
    /// Business Property - Premium
    /// </summary>
    public virtual double HO412Premium
    {
      get { return m_ho412Premium; }
      set { m_ho412Premium = value; }
    }

    /// <summary>
    /// Additional Residences Rented to Others
    /// </summary>
    [Description("HO 2470")]
    public virtual bool HO2470
    {
      get { return m_ho2470; }
      set { m_ho2470 = value; }
    }

    /// <summary>
    /// Number of Additional 1-Family Residences rented to others
    /// </summary>
    [Description("HO 2470 1-Family")]
    public virtual int HO24701Family
    {
      get { return m_ho24701Family; }
      set { m_ho24701Family = value; }
    }

    /// <summary>
    /// Number of Additional 2-Family Residences rented to others
    /// </summary>
    [Description("HO 2470 2-Family")]
    public virtual int HO24702Family
    {
      get { return m_ho24702Family; }
      set { m_ho24702Family = value; }
    }

    /// <summary>
    /// Number of Additional 3-Family Residences rented to others
    /// </summary>
    [Description("HO 2470 3-Family")]
    public virtual int HO24703Family
    {
      get { return m_ho24703Family; }
      set { m_ho24703Family = value; }
    }

    /// <summary>
    /// Number of Additional 4-Family Residences rented to others
    /// </summary>
    [Description("HO 2470 4-Family")]
    public virtual int HO24704Family
    {
      get { return m_ho24704Family; }
      set { m_ho24704Family = value; }
    }

    /// <summary>
	  /// Premium for Additional Residences Rented to Others
	  /// </summary>
    public virtual double HO2470Premium
    {
      get { return m_ho2470Premium; }
      set { m_ho2470Premium = value; }
    }

    /// <summary>
    /// Business pursuits
    /// </summary>
    [Description("HO 2471")]
    public virtual bool HO2471
    {
      get { return m_ho2471; }
      set { m_ho2471 = value; }
    }

    /// <summary>
    /// Business Pursuits Medical Payments
    /// </summary>
    public virtual bool HO2471MedicalPayments
    {
      get { return m_ho2471MedicalPayments; }
      set { m_ho2471MedicalPayments = value; }
    }

    /// <summary>
    /// Business pursuits is owner
    /// </summary>
    [Description("HO 2471 Is Owner")]
    public virtual bool HO2471IsOwner
    {
      get { return m_ho2471IsOwner; }
      set { m_ho2471IsOwner = value; }
    }

    /// <summary>
    /// Business pursuits - Eligible business class A
    /// </summary>
    [Description("HO 2471 Eligible Class A")]
    public virtual bool HO2471EligibleBusinessClassA
    {
      get { return m_ho2471EligibleBusinessClassA; }
      set { m_ho2471EligibleBusinessClassA = value; }
    }

    /// <summary>
    /// Business pursuits - Eligible business class B
    /// </summary>
    [Description("HO 2471 Eligible Class B")]
    public virtual bool HO2471EligibleBusinessClassB
    {
      get { return m_ho2471EligibleBusinessClassB; }
      set { m_ho2471EligibleBusinessClassB = value; }
    }

    /// <summary>
    /// Business Pursuits Premium Group
    /// </summary>
    public virtual string HO2471PremiumGroup
    {
      get { return m_ho2471PremiumGroup; }
      set { m_ho2471PremiumGroup = value; }
    }

    /// <summary>
    /// Business Pursuits Liability for Corporal Punishment
    /// </summary>
    public virtual bool HO2471TeacherLiability
    {
      get { return m_ho2471TeacherLiability; }
      set { m_ho2471TeacherLiability = value; }
    }

    /// <summary>
    /// Busines Pursuits Liability number of employees
    /// </summary>
    public virtual int HO2471Employees
    {
      get { return m_ho2471Employees; }
      set { m_ho2471Employees = value; }
    }

    /// <summary>
    /// Business Pursuits Premium
    /// </summary>
    public virtual double HO2471Premium
    {
      get { return m_ho2471Premium; }
      set { m_ho2471Premium = value; }
    }

    /// <summary>
    /// Coverage C - Increased special limits of liability
    /// </summary>
    [Description("HO 466")]
    public virtual bool HO0466
    {
      get { return m_ho0466; }
      set { m_ho0466 = value; }
    }

    /// <summary>
    /// Coverage C - Increased special limits of liability (jewelry)
    /// </summary>
    [Description("HO 466 Jewelry")]
    public virtual int HO0466Jewelry
    {
      get { return m_ho0466Jewelry; }
      set { m_ho0466Jewelry = value; }
    }

    /// <summary>
    /// Coverage C - Increased special limits of liability (Money)
    /// </summary>
    [Description("HO 466 Money")]
    public virtual int HO0466Money
    {
      get { return m_ho0466Money; }
      set { m_ho0466Money = value; }
    }

    /// <summary>
    /// Coverage C - Increased special limits of liability (Securities)
    /// </summary>
    [Description("HO 466 Securities")]
    public virtual int HO0466Securities
    {
      get { return m_ho0466Securities; }
      set { m_ho0466Securities = value; }
    }

    /// <summary>
    /// Coverage C - Increased special limits of liability (Silverware)
    /// </summary>
    [Description("HO 466 Silverware")]
    public virtual int HO0466Silverware
    {
      get { return m_ho0466Silverware; }
      set { m_ho0466Silverware = value; }
    }

    /// <summary>
    /// Coverage C - Increased special limits of liability (Firearms)
    /// </summary>
    [Description("HO 466 Firearms")]
    public virtual int HO0466Firearms
    {
      get { return m_ho0466Firearms; }
      set { m_ho0466Firearms = value; }
    }

    /// <summary>
    /// Coverage C = Increased special limits of liability (Furs)
    /// </summary>
    [Description("HO 466 Furs")]
    public virtual int HO0466Furs
    {
      get { return m_ho0466Furs; }
      set { m_ho0466Furs = value; }
    }

    /// <summary>
    /// Coverage C - Increased special limits of liability (Electronics)
    /// </summary>
    [Description("HO 466 Electronics")]
    public virtual int HO0466Electronics
    {
      get { return m_ho0466Electronics; }
      set { m_ho0466Electronics = value; }
    }

    /// <summary>
    /// Coverage C - Increased Special Limits of Liability - Jewelry subtotal
    /// </summary>
    public virtual double HO0466JewelrySubPremium
    {
      get { return m_ho0466JewelrySubPremium; }
      set { m_ho0466JewelrySubPremium = value; }
    }

    /// <summary>
    /// Coverage C - Increased Special Limits of Liability - Money subtotal
    /// </summary>
    public virtual double HO0466MoneySubPremium
    {
      get { return m_ho0466MoneySubPremium; }
      set { m_ho0466MoneySubPremium = value; }
    }

    /// <summary>
    /// Coverage C - Increased Special Limits of Liability - Securities subtotal
    /// </summary>
    public virtual double HO0466SecuritiesSubPremium
    {
      get { return m_ho0466SecuritiesSubPremium; }
      set { m_ho0466SecuritiesSubPremium = value; }
    }

    /// <summary>
    /// Coverage C - Increased Special Limits of Liability - Silverware subtotal
    /// </summary>
    public virtual double HO0466SilverwareSubPremium
    {
      get { return m_ho0466SilverwareSubPremium; }
      set { m_ho0466SilverwareSubPremium = value; }
    }

    /// <summary>
    /// Coverage C - Increased Special Limits of Liability - Firearms subtotal
    /// </summary>
    public virtual double HO0466FirearmsSubPremium
    {
      get { return m_ho0466FirearmsSubPremium; }
      set { m_ho0466FirearmsSubPremium = value; }
    }

    /// <summary>
    /// Coverage C - Increased Special Limits of Liability = Furs Subtotal
    /// </summary>
    public virtual double HO0466FursSubPremium
    {
      get { return m_ho0466FursSubPremium; }
      set { m_ho0466FursSubPremium = value; }
    }

    /// <summary>
    /// Coverage C - Increased Special Limits of Liability = Electronics Subtotal
    /// </summary>
    public virtual double HO0466ElectronicsSubPremium
    {
      get { return m_ho0466ElectronicsSubPremium; }
      set { m_ho0466ElectronicsSubPremium = value; }
    }

    /// <summary>
    /// Coverage C - Increased Special Limits of Liability
    /// </summary>
    public virtual double HO0466Premium
    {
      get { return m_ho0466Premium; }
      set { m_ho0466Premium = value; }
    }

    /// <summary>
    /// Credit Card Forgery
    /// </summary>
    [Description("HO 453")]
    public virtual bool HO0453
    {
      get { return m_ho0453; }
      set { m_ho0453 = value; }
    }

    /// <summary>
    /// Credit Card Forgery Limit
    /// </summary>
    [Description("HO 453 Limit")]
    public virtual int HO0453TotalLimit
    {
      get { return m_ho0453TotalLimit; }
      set { m_ho0453TotalLimit = value; }
    }

    /// <summary>
    /// Actual rated limit for Credit Card Forgery
    /// </summary>
    public virtual int CoHO0453TotalLimit
    {
      get { return m_coHO0453TotalLimit; }
      set { m_coHO0453TotalLimit = value; }
    }

    /// <summary>
    /// Credit Card electronic fund transfer card or access device forgery Premium
    /// </summary>
    public virtual double HO0453Premium
    {
      get { return m_ho0453Premium; }
      set { m_ho0453Premium = value; }
    }

    /// <summary>
    /// Earthquake coverage
    /// </summary>
    [Description("HO 454")]
    public virtual bool HO0454
    {
      get { return m_ho0454; }
      set { m_ho0454 = value; }
    }

    /// <summary>
    /// Earthquake coverage for veneer
    /// </summary>
    [Description("HO 454 Veneer")]
    public virtual string HO0454Veneer
    {
      get { return m_ho0454Veneer; }
      set { m_ho0454Veneer = value; }
    }

    /// <summary>
    /// Amount of Dwelling covered for earthquake
    /// </summary>
    [Description("HO 454 Dwelling")]
    public virtual int HO0454Dwelling
    {
      get { return m_ho0454Dwelling; }
      set { m_ho0454Dwelling = value; }
    }

    /// <summary>
    /// Amount of Other Structures covered for earthquake
    /// </summary>
    [Description("HO 454 Other Structures")]
    public virtual int HO0454OtherStructures
    {
      get { return m_ho0454OtherStructures; }
      set { m_ho0454OtherStructures = value; }
    }

    /// <summary>
    /// Amount of Contents coverage for earthquake
    /// </summary>
	  [Description("HO 454 Personal Property")]
    public virtual int HO0454Contents
    {
      get { return m_ho0454Contents; }
      set { m_ho0454Contents = value; }
    }

    /// <summary>
    /// Amount of Loss of Use coverage for earthquake
    /// </summary>
    [Description("HO 454 Loss Of Use")]
    public virtual int HO0454LossOfUse
    {
      get { return m_ho0454LossOfUse; }
      set { m_ho0454LossOfUse = value; }
    }

    /// <summary>
    /// Is risk located on a slope over 30%
    /// </summary>
    [Description("HO 454 Slope Greater Than 30$")]
    public virtual bool HO0454SlopeOver30
    {
      get { return m_ho0454SlopeOver30; }
      set { m_ho0454SlopeOver30 = value; }
    }

    /// <summary>
    /// Is risk located on bay mud or artificial fill
    /// </summary>
	  [Description("HO 454 Bay Mud/Artificial Fill")]
    public virtual bool HO0454ArtificialFill
    {
      get { return m_ho0454ArtificialFill; }
      set { m_ho0454ArtificialFill = value; }
    }

    /// <summary>
    /// Coverage for determining habitability and
    /// demolition costs after an earthquake
    /// </summary>
	  [Description("HO 454 Engineering Services")]
    public virtual bool HO0454EngineeringServices
    {
      get { return m_ho0454EngineeringServices; }
      set { m_ho0454EngineeringServices = value; }
    }

    /// <summary>
    /// Premium charge for Earthquake Engineering Services
    /// </summary>
    public virtual double HO0454EngineeringServicesPremium
    {
      get { return m_ho0454EngineeringServicesPremium; }
      set { m_ho0454EngineeringServicesPremium = value; }
    }

    /// <summary>
    /// Coverage for cost to bring dwelling up
    /// to current building code after an
    /// earthquake
    /// </summary>
    [Description("HO 454 Reconstruction Cost")]
    public virtual bool HO0454ReconstructionCost
    {
      get { return m_ho0454ReconstructionCost; }
      set { m_ho0454ReconstructionCost = value; }
    }

    /// <summary>
    /// Premium charge for Earthquake Reconstruction Cost
    /// </summary>
    public virtual double HO0454ReconstructionCostPremium
    {
      get { return m_ho0454ReconstructionCostPremium; }
      set { m_ho0454ReconstructionCostPremium = value; }
    }

    /// <summary>
    /// Earthquake deductible
    /// </summary>
    [Description("HO 454 Deductible")]
    public virtual int HO0454Deductible

    {
      get { return m_ho0454Deductible; }
      set { m_ho0454Deductible = value; }
    }

    /// <summary>
    /// Earthquake premium
    /// </summary>
    public virtual double HO0454Premium
    {
      get { return m_ho0454Premium; }
      set { m_ho0454Premium = value; }
    }

    /// <summary>
    /// Home day care coverage 
    /// </summary>
    [Description("HO 497")]
    public virtual bool HO0497
    {
      get { return m_ho0497; }
      set { m_ho0497 = value; }
    }

    /// <summary>
    /// Home day care coverage - number of people 
    /// </summary>
    [Description("HO 497 Number of people")]
    public virtual int HO0497NumberOfPeople
    {
      get { return m_ho0497NumberOfPeople; }
      set { m_ho0497NumberOfPeople = value; }
    }

    /// <summary>
    /// Home day care coverage
    /// </summary>
    public virtual double HO0497Premium
    {
      get { return m_ho0497Premium; }
      set { m_ho0497Premium = value; }
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
    /// Incidental farming personal liability
    /// </summary>
    [Description("HO 2472")]
    public virtual bool HO2472
    {
      get { return m_ho2472; }
      set { m_ho2472 = value; }
    }

    /// <summary>
    /// Incidental farming on premises
    /// </summary>
    [Description("HO 2472 On Premises")]
    public virtual int HO2472OnPremises
    {
      get { return m_ho2472OnPremises; }
      set { m_ho2472OnPremises = value; }
    }

    /// <summary>
    /// Incidental farming off premises
    /// </summary>
    [Description("HO 2472 Off Premises")]
    public virtual int HO2472OffPremises
    {
      get { return m_ho2472OffPremises; }
      set { m_ho2472OffPremises = value; }
    }

    /// <summary>
    /// Incidental farming on premises premium
    /// </summary>
    public virtual double HO2472OnPremisesSubPremium
    {
      get { return m_ho2472OnPremisesSubPremium; }
      set { m_ho2472OnPremisesSubPremium = value; }
    }

    /// <summary>
    /// Incidental farming off premises premium
    /// </summary>
    public virtual double HO2472OffPremisesSubPremium
    {
      get { return m_ho2472OffPremisesSubPremium; }
      set { m_ho2472OffPremisesSubPremium = value; }
    }

    /// <summary>
    /// Incidental farming personal liab premium 
    /// </summary>
    public virtual double HO2472Premium
    {
      get { return m_ho2472Premium; }
      set { m_ho2472Premium = value; }
    }

    /// <summary>
    /// Loss Assessment Coverage
    /// </summary>
    [Description("HO 435")]
    public virtual bool HO0435
    {
      get { return m_ho0435; }
      set { m_ho0435 = value; }
    }

    /// <summary>
    /// Loss Assessment Coverage for Additional Residences
    /// </summary>
    [Description("HO 435 Additional Residences")]
    public virtual bool HO0435AdditionalResidences
    {
      get { return m_ho0435AdditionalResidences; }
      set { m_ho0435AdditionalResidences = value; }
    }

    /// <summary>
    /// Number of Additional Residences with increased Loss Assessment
    /// </summary>
    [Description("HO 435 Number of Additional Residences")]
    public virtual int HO0435NumAdditionalResidences
    {
      get { return m_ho0435NumAdditionalResidences; }
      set { m_ho0435NumAdditionalResidences = value; }
    }

    /// <summary>
    /// Loss Assessment Coverage - Residence Premise
    /// </summary>
    [Description("HO 435 Residence Premise")]
    public virtual int HO0435ResidencePremise
    {
      get { return m_ho0435ResidencePremise; }
      set { m_ho0435ResidencePremise = value; }
    }

    /// <summary>
    /// Actual rated amount of loss assessment coverage for the residence premise
    /// </summary>
    public virtual int CoHO0435ResidencePremise { get; set; }

    /// <summary>
    /// Loss Assessment Coverage - Additional Residence 1
    /// </summary>
    [Description("HO 435 Additional Residence 1")]
    public virtual int HO0435AdditionalResidence1
    {
      get { return m_ho0435AdditionalResidence1; }
      set { m_ho0435AdditionalResidence1 = value; }
    }

    /// <summary>
    /// Actual rated amount of loss assessment coverage for additional residence 1
    /// </summary>
    public virtual int CoHO0435AdditionalResidence1 { get; set; }

    /// <summary>
    /// Loss Assessment Coverage - Additional Residence 2
    /// </summary>
    [Description("HO 435 Additional Residence 2")]
    public virtual int HO0435AdditionalResidence2
    {
      get { return m_ho0435AdditionalResidence2; }
      set { m_ho0435AdditionalResidence2 = value; }
    }

    /// <summary>
    /// Actual rated amount of loss assessment coverage for additional residence 2
    /// </summary>
    public virtual int CoHO0435AdditionalResidence2 { get; set; }

    /// <summary>
    /// Loss Assessment Coverage - Additional Residence 3
    /// </summary>
    [Description("HO 435 Additional Residence 3")]
    public virtual int HO0435AdditionalResidence3
    {
      get { return m_ho0435AdditionalResidence3; }
      set { m_ho0435AdditionalResidence3 = value; }
    }

    /// <summary>
    /// Actual rated amount of loss assessment coverage for additional residence 3
    /// </summary>
    public virtual int CoHO0435AdditionalResidence3 { get; set; }

    /// <summary>
    /// Loss Assessment Coverage - Additional Residence 4
    /// </summary>
    [Description("HO 435 Additional Residence 4")]
    public virtual int HO0435AdditionalResidence4
    {
      get { return m_ho0435AdditionalResidence4; }
      set { m_ho0435AdditionalResidence4 = value; }
    }

    /// <summary>
    /// Actual rated amount of loss assessment coverage for additional residence 4
    /// </summary>
    public virtual int CoHO0435AdditionalResidence4 { get; set; }

    /// <summary>
    /// Loss Assessment Premium
    /// </summary>
    public virtual double HO0435Premium
    {
      get { return m_ho0435Premium; }
      set { m_ho0435Premium = value; }
    }

    /// <summary>
    /// Earthquake Loss Assessment Coverage
    /// </summary>
    [Description("Earthquake Loss Assessment")]
    public virtual bool EarthquakeLossAssessment
    {
      get { return m_earthquakeLossAssessment; }
      set { m_earthquakeLossAssessment = value; }
    }

    /// <summary>
    /// Earthquake Loss Assessment Coverage Limit
    /// </summary>
    [Description("Earthquake Loss Assessment Limit")]
    public virtual int EarthquakeLossAssessmentLimit
    {
      get { return m_earthquakeLossAssessmentLimit; }
      set { m_earthquakeLossAssessmentLimit = value; }
    }

    /// <summary>
    /// Earthquake Loss Assessment Premium
    /// </summary>
    public virtual double EarthquakeLossAssessmentPremium
    {
      get { return m_earthquakeLossAssessmentPremium; }
      set { m_earthquakeLossAssessmentPremium = value; }
    }

    /// <summary>
    /// Sinkhole Collapse
    /// </summary>
    [Description("HO 499")]
    public virtual bool HO0499
    {
      get { return m_ho0499; }
      set { m_ho0499 = value; }
    }

    /// <summary>
    /// Sinkhole collapse premium
    /// </summary>
    public virtual double HO0499Premium
    {
      get { return m_ho0499Premium; }
      set { m_ho0499Premium = value; }
    }

    /// <summary>
    /// Watercraft
    /// </summary>
    [Description("HO 2475")]
    public virtual bool HO2475
    {
      get { return m_ho2475; }
      set { m_ho2475 = value; }
    }

    /// <summary>
    /// Watercraft #1 Type
    /// </summary>
    [Description("HO 2475 Watercraft 1 Type")]
    public virtual string HO2475WatercraftType1
    {
      get { return m_ho2475WatercraftType1; }
      set { m_ho2475WatercraftType1 = value; }
    }

    /// <summary>
    /// Watercraft #1 Horsepower
    /// </summary>
    [Description("HO 2475 Watercraft 1 Horsepower")]
    public virtual int HO2475Horsepower1
    {
      get { return m_ho2475Horsepower1; }
      set { m_ho2475Horsepower1 = value; }
    }

    /// <summary>
    /// Watercraft #1 Speed
    /// </summary>
    [Description("HO 2475 Watercraft 1 Speed")]
    public virtual int HO2475MilesPerHour1
    {
      get { return m_ho2475MilesPerHour1; }
      set { m_ho2475MilesPerHour1 = value; }
    }

    /// <summary>
    /// Watercraft #1 Length
    /// </summary>
    [Description("HO 2475 Watercraft 1 Length")]
    public virtual int HO2475Length1
    {
      get { return m_ho2475Length1; }
      set { m_ho2475Length1 = value; }
    }

    /// <summary>
    /// Watercraft #2 Type
    /// </summary>
    [Description("HO 2475 Watercraft 2 Type")]
    public virtual string HO2475WatercraftType2
    {
      get { return m_ho2475WatercraftType2; }
      set { m_ho2475WatercraftType2 = value; }
    }

    /// <summary>
    /// Watercraft #2 Horsepower
    /// </summary>
    [Description("HO 2475 Watercraft 2 Horsepower")]
    public virtual int HO2475Horsepower2
    {
      get { return m_ho2475Horsepower2; }
      set { m_ho2475Horsepower2 = value; }
    }

    /// <summary>
    /// Watercraft #2 Speed
    /// </summary>
    [Description("HO 2475 Watercraft 2 Speed")]
    public virtual int HO2475MilesPerHour2
    {
      get { return m_ho2475MilesPerHour2; }
      set { m_ho2475MilesPerHour2 = value; }
    }

    /// <summary>
    /// Watercraft #2 Length
    /// </summary>
    [Description("HO 2475 Watercraft 2 Length")]
    public virtual int HO2475Length2
    {
      get { return m_ho2475Length2; }
      set { m_ho2475Length2 = value; }
    }

    /// <summary>
    /// Watercraft Premium
    /// </summary>
	  public virtual double HO2475Premium
    {
      get { return m_ho2475Premium; }
      set { m_ho2475Premium = value; }
    }

    /// <summary>
    /// Snowmobile
    /// </summary>
    [Description("HO 2464")]
    public virtual bool HO2464
    {
      get { return m_ho2464; }
      set { m_ho2464 = value; }
    }

    /// <summary>
    /// Number of Snowmobiles
    /// </summary>
    [Description("HO 2464 Number of Snowmobiles")]
    public virtual int HO2464NumberOfSnowmobiles
    {
      get { return m_ho2464NumberOfSnowmobiles; }
      set { m_ho2464NumberOfSnowmobiles = value; }
    }

    /// <summary>
    /// Snowmobile Premium
    /// </summary>
    public virtual double HO2464Premium
    {
      get { return m_ho2464Premium; }
      set { m_ho2464Premium = value; }
    }

    /// <summary>
    /// Wind, Hurricane and Hail Exclusion
    /// </summary>
    [Description("HO 04 94 Windstorm Exclusion")]
    public virtual bool HO0494
    {
      get { return m_ho0494; }
      set { m_ho0494 = value; }
    }

    /// <summary>
    /// Credit premium for Windstorm Exclusion
    /// </summary>
    public virtual double HO0494CreditPremium
    {
      get { return m_ho0494CreditPremium; }
      set { m_ho0494CreditPremium = value; }
    }

    /// <summary>
    /// 3 or 4 Family Dwelling Premises Liability
    /// </summary>
    [Description("HO 04 44 Three or Four Family Dwelling - Premises Liability")]
    public virtual bool HO0444
    {
      get { return m_ho0444; }
      set { m_ho0444 = value; }
    }

    /// <summary>
    /// HO 04 44 Number of Families
    /// </summary>
    [Description("HO 04 44 Number of Families")]
    public virtual int HO0444NumOfFamilies
    {
      get { return m_ho0444NumOfFamilies; }
      set { m_ho0444NumOfFamilies = value; }
    }

    /// <summary>
    /// HO 04 46 Inflation Guard
    /// </summary>
    [Description("HO 04 46 Inflation Guard")]
    public virtual bool HO0446
    {
      get { return m_ho0446; }
      set { m_ho0446 = value; }
    }

    /// <summary>
    /// HO 04 46 Inflation Guard Percentage
    /// </summary>
    [Description("HO 04 46 Inflation Guard Percentage")]
    public virtual int HO0446Percentage
    {
      get { return m_ho0446Percentage; }
      set { m_ho0446Percentage = value; }
    }

    /// <summary>
    /// 
    /// </summary>
	  public virtual int CoHO0446Percentage
    {
      get { return m_coHO0446Percentage; }
      set { m_coHO0446Percentage = value; }
    }

    /// <summary>
    /// Premium charge for HO 04 46 Inflation Guard endorsement
    /// </summary>
    public virtual double HO0446Premium
    {
      get { return m_ho0446Premium; }
      set { m_ho0446Premium = value; }
    }

    /// <summary>
    /// Is any incidental farming occurring on the premises
    /// </summary>
    [Description("HO 24 72 On Premises")]
    public virtual bool IncidentalFarmingOnPremises
    {
      get { return m_incidentalFarmingOnPremises; }
      set { m_incidentalFarmingOnPremises = value; }
    }

    /// <summary>
    /// Is any incidental farming occurring away from premises
    /// </summary>
    [Description("HO 24 72 Away from Premises")]
    public virtual bool IncidentalFarmingAwayFromPremises
    {
      get { return m_incidentalFarmingAwayFromPremises; }
      set { m_incidentalFarmingAwayFromPremises = value; }
    }

    /// <summary>
    /// Special Personal Property for Form HO-4
    /// </summary>
	  [Description("HO 524")]
    public virtual bool HO0524
    {
      get { return m_ho0524; }
      set { m_ho0524 = value; }
    }

    /// <summary>
    /// Premium charge for Special Personal Property on Form HO-4
    /// </summary>
    public virtual double HO0524Premium
    {
      get { return m_ho0524Premium; }
      set { m_ho0524Premium = value; }
    }

    /// <summary>
    /// Unit Owners Coverage C Special Coverage
    /// </summary>
	  [Description("HO 1731")]
    public virtual bool HO1731
    {
      get { return m_ho1731; }
      set { m_ho1731 = value; }
    }

    /// <summary>
    /// Premium charge for Unit Owners Coverage C Special Coverage
    /// </summary>
	  public virtual double HO1731Premium
    {
      get { return m_ho1731Premium; }
      set { m_ho1731Premium = value; }
    }

    /// <summary>
    /// Unit Owners Coverage A Special Coverage
    /// </summary>
	  [Description("HO 1732")]
    public virtual bool HO1732
    {
      get { return m_ho1732; }
      set { m_ho1732 = value; }
    }

    /// <summary>
    /// Premium charge for Unit Owners Coverage A Special Coverage
    /// </summary>
	  public virtual double HO1732Premium
    {
      get { return m_ho1732Premium; }
      set { m_ho1732Premium = value; }
    }

    /// <summary>
    /// Mine subsidence coverage
    /// </summary>
    [Description("HO 2383")]
    public virtual bool HO2383
    {
      get { return m_ho2383; }
      set { m_ho2383 = value; }
    }

    /// <summary>
    /// Mine Subsidence coverage premium
    /// </summary>
    public virtual double HO2383Premium
    {
      get { return m_ho2383Premium; }
      set { m_ho2383Premium = value; }
    }

    /// <summary>
    /// Ordinance or law coverage
    /// </summary>
    [Description("HO 477")]
    public virtual bool HO0477
    {
      get { return m_ho0477; }
      set { m_ho0477 = value; }
    }

    /// <summary>
    /// Ordinance or law percentage of coverage
    /// </summary>
    [Description("HO 477 Percentage of covg")]
    public virtual int HO0477Ordinance
    {
      get { return m_ho0477Ordinance; }
      set { m_ho0477Ordinance = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual int CoHO0477Ordinance
    {
      get { return m_coHO0477Ordinance; }
      set { m_coHO0477Ordinance = value; }
    }

    /// <summary>
    /// Ordinance or law coverage premium 
    /// </summary>
    public virtual double HO477Premium
    {
      get { return m_ho477Premium; }
      set { m_ho477Premium = value; }
    }

    /// <summary>
    /// Other members of your house hold 
    /// </summary>
    [Description("HO 458")]
    public virtual bool HO0458
    {
      get { return m_ho0458; }
      set { m_ho0458 = value; }
    }

    /// <summary>
    /// Other members of your house hold (First Name)
    /// </summary>
    [Description("HO 458 First Name")]
    public virtual string HO0458FirstName
    {
      get { return m_ho0458FirstName; }
      set { m_ho0458FirstName = value; }
    }

    /// <summary>
    /// Other members of your house hold (Last Name)
    /// </summary>
    [Description("HO 458 Last Name")]
    public virtual string HO0458LastName
    {
      get { return m_ho0458LastName; }
      set { m_ho0458LastName = value; }
    }

    /// <summary>
    /// Other members of your household premium 
    /// </summary>
    public virtual double HO0458Premium
    {
      get { return m_ho0458Premium; }
      set { m_ho0458Premium = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Other residence 
    /// </summary>
    [Description("HO 2443")]
    public virtual bool HO2443
    {
      get { return m_ho2443; }
      set { m_ho2443 = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Dwelling occupied
    /// </summary>
    [Description("HO 2443 dwelling occupied")]
    public virtual bool HO2443Dwelling
    {
      get { return m_ho2443Dwelling; }
      set { m_ho2443Dwelling = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Another business
    /// </summary>
    [Description("HO 2443 Another business")]
    public virtual bool HO2443AnotherBusiness
    {
      get { return m_ho2443AnotherBusiness; }
      set { m_ho2443AnotherBusiness = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Office
    /// </summary>
    [Description("HO 2443 Office")]
    public virtual bool HO2443Office
    {
      get { return m_ho2443Office; }
      set { m_ho2443Office = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Other residence premium 
    /// </summary>
    public virtual double HO2443Premium
    {
      get { return m_ho2443Premium; }
      set { m_ho2443Premium = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Residence Premises
    /// </summary>
    [Description("HO 0442")]
    public virtual bool HO0442
    {
      get { return m_ho0442; }
      set { m_ho0442 = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Dwelling Occupied
    /// </summary>
    [Description("HO 0442 Dwelling")]
    public virtual bool HO0442Dwelling
    {
      get { return m_ho0442Dwelling; }
      set { m_ho0442Dwelling = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Another Business
    /// </summary>
    [Description("HO 0442 Another Business")]
    public virtual bool HO0442AnotherBusiness
    {
      get { return m_ho0442AnotherBusiness; }
      set { m_ho0442AnotherBusiness = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Office
    /// </summary>
    [Description("HO 0442 Office")]
    public virtual bool HO0442Office
    {
      get { return m_ho0442Office; }
      set { m_ho0442Office = value; }
    }

    /// <summary>
    /// Permitted Incidental Occupancy - Description of Business
    /// </summary>
    [Description("HO 0442 Business Description")]
    public virtual string HO0442BusinessDescription
    {
      get { return m_ho0442BusinessDescription; }
      set { m_ho0442BusinessDescription = value; }
    }

    /// <summary>
    /// Permitted Incidental Occupany - limit if occupancy in other structure
    /// </summary>
    [Description("HO 0442 Other Structure Limit")]
    public virtual int HO0442OtherStructureLimit
    {
      get { return m_ho0442OtherStructureLimit; }
      set { m_ho0442OtherStructureLimit = value; }
    }

    /// <summary>
    /// Permitted Incidental Occupancy - Section II
    /// </summary>
    [Description("HO 0442 Section II")]
    public virtual bool HO0442SectionII
    {
      get { return m_ho0442SectionII; }
      set { m_ho0442SectionII = value; }
    }

    /// <summary>
    /// Permitted Incidental Occupancy - Professional Instruction
    /// </summary>
    [Description("HO 0442 Professional Instruction")]
    public virtual bool HO0442ProfessionalInstruction
    {
      get { return m_ho0442ProfessionalInstruction; }
      set { m_ho0442ProfessionalInstruction = value; }
    }

    /// <summary>
    /// Permitted incidental occupancies - Residence premises Premium
    /// </summary>
    public virtual double HO0442Premium
    {
      get { return m_ho0442Premium; }
      set { m_ho0442Premium = value; }
    }

    /// <summary>
    /// Personal Injury
    /// </summary>
    [Description("HO 2482")]
    public virtual bool HO2482
    {
      get { return m_ho2482; }
      set { m_ho2482 = value; }
    }

    /// <summary>
    /// Personal Injury Premium 
    /// </summary>
    public virtual double HO2482Premium
    {
      get { return m_ho2482Premium; }
      set { m_ho2482Premium = value; }
    }

    /// <summary>
    /// Personal property at other residences 
    /// </summary>
    [Description("HO 450")]
    public virtual bool HO0450
    {
      get { return m_ho0450; }
      set { m_ho0450 = value; }
    }

    /// <summary>
    /// Personal property at other residences - Increase limit
    /// </summary>
    [Description("HO 450 Personal property")]
    public virtual int HO0450IncreasedLimit
    {
      get { return m_ho0450IncreasedLimit; }
      set { m_ho0450IncreasedLimit = value; }
    }

    /// <summary>
    /// Personal Property at other residences - premium 
    /// </summary>
    public virtual double HO0450Premium
    {
      get { return m_ho0450Premium; }
      set { m_ho0450Premium = value; }
    }

    /// <summary>
    /// Refrigerated products coverage
    /// </summary>
    [Description("HO 498")]
    public virtual bool HO0498
    {
      get { return m_ho0498; }
      set { m_ho0498 = value; }
    }

    /// <summary>
    /// Refrigerated Property Coverage Amount
    /// </summary>
    [Description("HO 498 Limit")]
    public virtual int HO0498Limit
    {
      get { return m_ho0498Limit; }
      set { m_ho0498Limit = value; }
    }

    /// <summary>
    /// Refrigerated products coverage premium 
    /// </summary>
    public virtual double HO0498Premium
    {
      get { return m_ho0498Premium; }
      set { m_ho0498Premium = value; }
    }

    /// <summary>
    /// Personal Property Replacement Cost
    /// </summary>
    [Description("HO 490")]
    public virtual bool HO0490
    {
      get { return m_ho0490; }
      set { m_ho0490 = value; }
    }

    /// <summary>
    /// Personal Property Replacement Cost limit - not applicable
    /// </summary>
    [Description("HO 490 Limit")]
    public virtual int HO0490Limit
    {
      get { return m_ho0490Limit; }
      set { m_ho0490Limit = value; }
    }

    /// <summary>
    /// Personal Property Replacement Cost premium 
    /// </summary>
    public virtual double HO0490Premium
    {
      get { return m_ho0490Premium; }
      set { m_ho0490Premium = value; }
    }

    /// <summary>
    /// Structures rented to others 
    /// </summary>
    [Description("HO 440 Rented Structures")]
    public virtual bool HO0440
    {
      get { return m_ho0440; }
      set { m_ho0440 = value; }
    }

    /// <summary>
    /// Value of structures rented to others
    /// </summary>
    [Description("HO 440 Value")]
    public virtual int HO0440Value
    {
      get { return m_ho0440Value; }
      set { m_ho0440Value = value; }
    }

    /// <summary>
    /// Structures rented to others - Premium 
    /// </summary>
    public virtual double HO0440Premium
    {
      get { return m_ho0440Premium; }
      set { m_ho0440Premium = value; }
    }

    /// <summary>
    /// Theft of building materials
    /// </summary>
    [Description("HO 998016")]
    public virtual bool HO998016
    {
      get { return m_ho998016; }
      set { m_ho998016 = value; }
    }

    /// <summary>
    /// Theft of building materials - Limit
    /// </summary>
    [Description("HO 998016 Limit")]
    public virtual int HO998016Limit
    {
      get { return m_ho998016Limit; }
      set { m_ho998016Limit = value; }
    }

    /// <summary>
    /// Theft of building materials premium 
    /// </summary>
    public virtual double HO998016Premium
    {
      get { return m_ho998016Premium; }
      set { m_ho998016Premium = value; }
    }

    /// <summary>
    /// Water back up and sump discharge of overflow
    /// </summary>
    [Description("HO Water backup")]
    public virtual bool WaterBackup
    {
      get { return m_waterBackup; }
      set { m_waterBackup = value; }
    }

    /// <summary>
    /// Water back up and sump discharge of overflow Limit
    /// </summary>
    [Description("HO Water backup Limit")]
    public virtual int WaterBackupLimit
    {
      get { return m_waterBackupLimit; }
      set { m_waterBackupLimit = value; }
    }

    /// <summary>
    /// Water backup premium
    /// </summary>
    public virtual double WaterBackupPremium
    {
      get { return m_waterBackupPremium; }
      set { m_waterBackupPremium = value; }
    }

    /// <summary>
    /// Specific structures away from residence
    /// </summary>
    [Description("HO 0492")]
    public virtual bool HO0492
    {
      get { return m_ho0492; }
      set { m_ho0492 = value; }
    }

    /// <summary>
    /// Coverage Limit for Specific Structures away from residence
    /// </summary>
    [Description("HO 0492 Limit")]
    public virtual int HO0492Limit
    {
      get { return m_ho0492Limit; }
      set { m_ho0492Limit = value; }
    }

    /// <summary>
    /// Premium for Specific Structures away from residence
    /// </summary>
    public virtual double HO0492Premium
    {
      get { return m_ho0492Premium; }
      set { m_ho0492Premium = value; }
    }

    /// <summary>
    /// Premises Alarm or Fire Protection System
    /// </summary>
    [Description("HO 0416")]
    public virtual bool HO0416
    {
      get { return m_ho0416; }
      set { m_ho0416 = value; }
    }

    /// <summary>
    /// Premises Alarm or Fire Protection device
    /// </summary>
    [Description("HO 0416 Device")]
    public virtual string HO0416ProtectiveDevices
    {
      get { return m_ho0416ProtectiveDevices; }
      set { m_ho0416ProtectiveDevices = value; }
    }

    /// <summary>
    /// Premium credit for Premises Alarm or Fire Protection System
    /// </summary>
    public virtual double HO0416Premium
    {
      get { return m_ho0416Premium; }
      set { m_ho0416Premium = value; }
    }

    /// <summary>
    /// Scheduled Personal Property
    /// </summary>
    [Description("HO 0461")]
    public virtual bool HO0461
    {
      get { return m_ho0461; }
      set { m_ho0461 = value; }
    }

    /// <summary>
    /// Limit for Scheduled Bicycles
    /// </summary>
    [Description("HO 0461 Bicycles Limit")]
    public virtual int HO0461BicyclesLimit
    {
      get { return m_ho0461BicyclesLimit; }
      set { m_ho0461BicyclesLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Bicycles
    /// </summary>
    public virtual double HO0461BicyclesSubPremium
    {
      get { return m_ho0461BicyclesSubPremium; }
      set { m_ho0461BicyclesSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Cameras
    /// </summary>
    [Description("HO 0461 Camera Limit")]
    public virtual int HO0461CameraLimit
    {
      get { return m_ho0461CameraLimit; }
      set { m_ho0461CameraLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Cameras
    /// </summary>
    public virtual double HO0461CameraSubPremium
    {
      get { return m_ho0461CameraSubPremium; }
      set { m_ho0461CameraSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Professional Cameras
    /// </summary>
	  [Description("HO 0461 Professional Camera Limit")]
    public virtual int HO0461ProfessionalCameraLimit
    {
      get { return m_ho0461ProfessionalCameraLimit; }
      set { m_ho0461ProfessionalCameraLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Professional Cameras
    /// </summary>
    public virtual double HO0461ProfessionalCameraSubPremium
    {
      get { return m_ho0461ProfessionalCameraSubPremium; }
      set { m_ho0461ProfessionalCameraSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Collectibles
    /// </summary>
    [Description("HO 0461 Collectibles")]
    public virtual int HO0461CollectiblesLimit
    {
      get { return m_ho0461CollectiblesLimit; }
      set { m_ho0461CollectiblesLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Collectibles
    /// </summary>
    public virtual double HO0461CollectiblesSubPremium
    {
      get { return m_ho0461CollectiblesSubPremium; }
      set { m_ho0461CollectiblesSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Coins
    /// </summary>
    [Description("HO 0461 Coins Limit")]
    public virtual int HO0461CoinsLimit
    {
      get { return m_ho0461CoinsLimit; }
      set { m_ho0461CoinsLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Coins
    /// </summary>
    public virtual double HO0461CoinsSubPremium
    {
      get { return m_ho0461CoinsSubPremium; }
      set { m_ho0461CoinsSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Fine Arts without Breakage coverage
    /// </summary>
    [Description("HO 0461 Fine Arts without Breakage Limit")]
    public virtual int HO0461FineArtsWithoutBreakageLimit
    {
      get { return m_ho0461FineArtsWithoutBreakageLimit; }
      set { m_ho0461FineArtsWithoutBreakageLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Fine Arts without Breakage
    /// </summary>
    public virtual double HO0461FineArtsWithoutBreakageSubPremium
    {
      get { return m_ho0461FineArtsWithoutBreakageSubPremium; }
      set { m_ho0461FineArtsWithoutBreakageSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Fine Arts with Breakage coverage
    /// </summary>
    [Description("HO 0461 Fine Arts with Breakage Limit")]
    public virtual int HO0461FineArtsWithBreakageLimit
    {
      get { return m_ho0461FineArtsWithBreakageLimit; }
      set { m_ho0461FineArtsWithBreakageLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Fine Arts with Breakage
    /// </summary>
    public virtual double HO0461FineArtsWithBreakageSubPremium
    {
      get { return m_ho0461FineArtsWithBreakageSubPremium; }
      set { m_ho0461FineArtsWithBreakageSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Collectible Firearms
    /// </summary>
    [Description("HO 0461 Collectible Firearms limit")]
    public virtual int HO0461CollectibleFirearmsLimit
    {
      get { return m_ho0461CollectibleFirearmsLimit; }
      set { m_ho0461CollectibleFirearmsLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Collectible Firearms
    /// </summary>
    public virtual double HO0461CollectibleFirearmsSubPremium
    {
      get { return m_ho0461CollectibleFirearmsSubPremium; }
      set { m_ho0461CollectibleFirearmsSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Fire Arms
    /// </summary>
    [Description("HO 0461 Fire Arms Limit")]
    public virtual int HO0461FirearmsLimit
    {
      get { return m_ho0461FirearmsLimit; }
      set { m_ho0461FirearmsLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Fire Arms
    /// </summary>
    public virtual double HO0461FirearmsSubPremium
    {
      get { return m_ho0461FirearmsSubPremium; }
      set { m_ho0461FirearmsSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Furs
    /// </summary>
    [Description("HO 0461 Furs Limit")]
    public virtual int HO0461FursLimit
    {
      get { return m_ho0461FursLimit; }
      set { m_ho0461FursLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Furs
    /// </summary>
    public virtual double HO0461FursSubPremium
    {
      get { return m_ho0461FursSubPremium; }
      set { m_ho0461FursSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Golfers Equipment
    /// </summary>
    [Description("HO 0461 Golfers Equipment Limit")]
    public virtual int HO0461GolfersEquipmentLimit
    {
      get { return m_ho0461GolfersEquipmentLimit; }
      set { m_ho0461GolfersEquipmentLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Golfers Equipment
    /// </summary>
    public virtual double HO0461GolfersEquipmentSubPremium
    {
      get { return m_ho0461GolfersEquipmentSubPremium; }
      set { m_ho0461GolfersEquipmentSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Jewelry
    /// </summary>
    [Description("HO 0461 Jewelry Limit")]
    public virtual int HO0461JewelryLimit
    {
      get { return m_ho0461JewelryLimit; }
      set { m_ho0461JewelryLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Jewelry
    /// </summary>
    public virtual double HO0461JewelrySubPremium
    {
      get { return m_ho0461JewelrySubPremium; }
      set { m_ho0461JewelrySubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Jewelry in Vaults
    /// </summary>
    [Description("HO 0461 Jewelry In Vaults Limit")]
    public virtual int HO0461JewelryInVaultsLimit
    {
      get { return m_ho0461JewelryInVaultsLimit; }
      set { m_ho0461JewelryInVaultsLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Jewelry in Vaults
    /// </summary>
    public virtual double HO0461JewelryInVaultsSubPremium
    {
      get { return m_ho0461JewelryInVaultsSubPremium; }
      set { m_ho0461JewelryInVaultsSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Musical Instruments
    /// </summary>
    [Description("HO 0461 Musical Instruments Limit")]
    public virtual int HO0461MusicalInstrumentsLimit
    {
      get { return m_ho0461MusicalInstrumentsLimit; }
      set { m_ho0461MusicalInstrumentsLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Musical Instruments
    /// </summary>
    public virtual double HO0461MusicalInstrumentsSubPremium
    {
      get { return m_ho0461MusicalInstrumentsSubPremium; }
      set { m_ho0461MusicalInstrumentsSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Professional Musical Instruments
    /// </summary>
    [Description("HO 0461 Professional Musical Instruments")]
    public virtual int HO0461ProfessionalMusicalInstrumentsLimit
    {
      get { return m_ho0461ProfessionalMusicalInstrumentsLimit; }
      set { m_ho0461ProfessionalMusicalInstrumentsLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Professional Musical Instruments
    /// </summary>
    public virtual double HO0461ProfessionalMusicalInstrumentsSubPremium
    {
      get { return m_ho0461ProfessionalMusicalInstrumentsSubPremium; }
      set { m_ho0461ProfessionalMusicalInstrumentsSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Sports Equipment
    /// </summary>
    [Description("HO 0461 Other Sports Equipment")]
    public virtual int HO0461SportsEquipmentLimit
    {
      get { return m_ho0461SportsEquipmentLimit; }
      set { m_ho0461SportsEquipmentLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Sports Equipment
    /// </summary>
    public virtual double HO0461SportsEquipmentSubPremium
    {
      get { return m_ho0461SportsEquipmentSubPremium; }
      set { m_ho0461SportsEquipmentSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Silverware
    /// </summary>
    [Description("HO 0461 Silverware Limit")]
    public virtual int HO0461SilverwareLimit
    {
      get { return m_ho0461SilverwareLimit; }
      set { m_ho0461SilverwareLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Silverware
    /// </summary>
    public virtual double HO0461SilverwareSubPremium
    {
      get { return m_ho0461SilverwareSubPremium; }
      set { m_ho0461SilverwareSubPremium = value; }
    }

    /// <summary>
    /// Limit for Scheduled Stamps
    /// </summary>
    [Description("HO 0461 Stamps Limit")]
    public virtual int HO0461StampsLimit
    {
      get { return m_ho0461StampsLimit; }
      set { m_ho0461StampsLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Stamps
    /// </summary>
    public virtual double HO0461StampsSubPremium
    {
      get { return m_ho0461StampsSubPremium; }
      set { m_ho0461StampsSubPremium = value; }
    }

    /// <summary>
    /// Scheduled Personal Property premium
    /// </summary>
    public virtual double HO0461Premium
    {
      get { return m_ho0461Premium; }
      set { m_ho0461Premium = value; }
    }

    /// <summary>
    /// Scheduled Glass endorsement
    /// </summary>
    [Description("Scheduled Glass")]
    public virtual bool ScheduledGlass
    {
      get { return m_scheduledGlass; }
      set { m_scheduledGlass = value; }
    }

    /// <summary>
    /// Coverage limit for Scheduled Glass
    /// </summary>
    [Description("Scheduled Glass Limit")]
    public virtual int ScheduledGlassLimit
    {
      get { return m_scheduledGlassLimit; }
      set { m_scheduledGlassLimit = value; }
    }

    /// <summary>
    /// Premium charge for Scheduled Glass
    /// </summary>
    public virtual double ScheduledGlassPremium
    {
      get { return m_scheduledGlassPremium; }
      set { m_scheduledGlassPremium = value; }
    }

    /// <summary>
    /// Mold endorsement
    /// </summary>
    [Description("Mold")]
    public virtual bool Mold
    {
      get { return m_mold; }
      set { m_mold = value; }
    }

    /// <summary>
    /// Coverage limit for mold
    /// </summary>
    [Description("Mold Limit")]
    public virtual int MoldLimit
    {
      get { return m_moldLimit; }
      set { m_moldLimit = value; }
    }

    /// <summary>
    /// Actual rated mold limit.
    /// </summary>
    public virtual int CoMoldLimit
    {
      get { return m_coMoldLimit; }
      set { m_coMoldLimit = value; }
    }

    /// <summary>
    /// Premium charge for mold endoresement
    /// </summary>
    public virtual double MoldPremium
    {
      get { return m_moldPremium; }
      set { m_moldPremium = value; }
    }

    /// <summary>
    /// Water damage exclusion endorsement
    /// </summary>
    [Description("Water Damage Exclusion")]
    public virtual bool WaterDamageExclusion
    {
      get { return m_waterDamageExclusion; }
      set { m_waterDamageExclusion = value; }
    }

    /// <summary>
    /// Premium charge for water damage exclustion
    /// </summary>
    public virtual double WaterDamageExclusionPremium
    {
      get { return m_waterDamageExclusionPremium; }
      set { m_waterDamageExclusionPremium = value; }
    }

    /// <summary>
    /// Limited water damage coverage endorsement
    /// </summary>
    [Description("Limited Water Damage Coverage")]
    public virtual bool LimitedWaterDamageCoverage
    {
      get { return m_limitedWaterDamageCoverage; }
      set { m_limitedWaterDamageCoverage = value; }
    }

    /// <summary>
    /// Premium charge for Limited Water Damage Coverage
    /// </summary>
    public virtual double LimitedWaterDamageCoveragePremium
    {
      get { return m_limitedWaterDamageCoveragePremium; }
      set { m_limitedWaterDamageCoveragePremium = value; }
    }

    /// <summary>
    /// Limited Hurricane for Outdoor Property endorsement
    /// </summary>
    [Description("Limited Hurricane for Outdoor Property")]
    public virtual bool LimitedHurricaneOutdoorProperty
    {
      get { return m_limitedHurricaneOutdoorProperty; }
      set { m_limitedHurricaneOutdoorProperty = value; }
    }

    /// <summary>
    /// Coverage limit for Limited Hurricane for Outdoor Property
    /// </summary>
    [Description("Limited Hurricane for Outdoor Property Limit")]
    public virtual int LimitedHurricaneOutdoorPropertyLimit
    {
      get { return m_limitedHurricaneOutdoorPropertyLimit; }
      set { m_limitedHurricaneOutdoorPropertyLimit = value; }
    }

    /// <summary>
    /// Actual rated limit for Limited Hurricane for Outdoor Property
    /// </summary>
    public virtual int CoLimitedHurricaneOutdoorPropertyLimit
    {
      get { return m_coLimitedHurricaneOutdoorPropertyLimit; }
      set { m_coLimitedHurricaneOutdoorPropertyLimit = value; }
    }

    /// <summary>
    /// Premium charge for Limited Hurricane for Outdoor Property
    /// </summary>
    public virtual double LimitedHurricaneOutdoorPropertyPremium
    {
      get { return m_limitedHurricaneOutdoorPropertyPremium; }
      set { m_limitedHurricaneOutdoorPropertyPremium = value; }
    }

    /// <summary>
    /// Increased Replacement Cost on Dwelling
    /// </summary>
    [Description("Increased Replacement Cost on Dwelling")]
    public virtual bool HO0420
    {
      get { return m_ho0420; }
      set { m_ho0420 = value; }
    }

    /// <summary>
    /// Premium charge for Increased Replacement Cost on Dwelling
    /// </summary>
    public virtual double HO0420Premium
    {
      get { return m_ho0420Premium; }
      set { m_ho0420Premium = value; }
    }

    /// <summary>
    /// Golf Cart Liability
    /// </summary>
    [Description("Golf Cart Liability")]
    public virtual bool GolfcartLiability
    {
      get { return m_golfcartLiability; }
      set { m_golfcartLiability = value; }
    }

    /// <summary>
    /// Number of Golf Carts covered for Liability
    /// </summary>
    [Description("Number of Golf Carts")]
    public virtual int NumberOfGolfcarts
    {
      get { return m_numberOfGolfcarts; }
      set { m_numberOfGolfcarts = value; }
    }

    /// <summary>
    /// Premium charge for Golf Cart Liability
    /// </summary>
    public virtual double GolfcartLiabilityPremium
    {
      get { return m_golfcartLiabilityPremium; }
      set { m_golfcartLiabilityPremium = value; }
    }

    /// <summary>
    /// Automatic Increase in Insurance endorsement for Dwelling Fire
    /// </summary>
    [Description("Automatic Increase in Insurance")]
    public virtual bool DFAutomaticIncreaseInInsurance
    {
      get { return m_dfAutomaticIncreaseInInsurance; }
      set { m_dfAutomaticIncreaseInInsurance = value; }
    }

    /// <summary>
    /// Automatic Increase in Insurance Increase Percentage for Dwelling Fire
    /// </summary>
    [Description("Automatic Increase in Insurance Percent")]
    public virtual int DFAutomaticIncreaseInInsurancePercent
    {
      get { return m_dfAutomaticIncreaseInInsurancePercent; }
      set { m_dfAutomaticIncreaseInInsurancePercent = value; }
    }

    /// <summary>
    /// Calculated premium for Automatic Increase in Insurance for Dwelling Fire
    /// </summary>
	  public virtual double DFAutomaticIncreaseInInsurancePremium
    {
      get { return m_dfAutomaticIncreaseInInsurancePremium; }
      set { m_dfAutomaticIncreaseInInsurancePremium = value; }
    }

    /// <summary>
    /// Earthquake endorsement for Dwelling Fire
    /// </summary>
    [Description("Earthquake")]
    public virtual bool DFEarthquake
    {
      get { return m_dfEarthquake; }
      set { m_dfEarthquake = value; }
    }

    /// <summary>
    /// Rating zone for Earthquake endorsement in Dwelling Fire
    /// </summary>
    [Description("Earthquake Zone")]
    public virtual int DFEarthquakeZone
    {
      get { return m_dfEarthquakeZone; }
      set { m_dfEarthquakeZone = value; }
    }

    /// <summary>
    /// Deductible for Earthquake coverage in Dwelling Fire
    /// </summary>
    [Description("Earthquake Deductible")]
    public virtual int DFEarthquakeDeductible
    {
      get { return m_dfEarthquakeDeductible; }
      set { m_dfEarthquakeDeductible = value; }
    }

    /// <summary>
    /// Flag showing whether to rate veneer as masonry for Earthquake in Dwelling Fire
    /// </summary>
    [Description("Rate Veneer as Masonry")]
    public virtual bool DFEarthquakeRateVeneerAsMasonry
    {
      get { return m_dfEarthquakeRateVeneerAsMasonry; }
      set { m_dfEarthquakeRateVeneerAsMasonry = value; }
    }

    /// <summary>
    /// Calculated premium for Earthquake for Dwelling Fire
    /// </summary>
	  public virtual double DFEarthquakePremium
    {
      get { return m_dfEarthquakePremium; }
      set { m_dfEarthquakePremium = value; }
    }

    /// <summary>
    /// Improvements, Additions and Alterations endorsement for Dwelling Fire
    /// </summary>
    [Description("Improvements, Additions and Alterations")]
    public virtual bool DFImprovementsAdditionsAndAlterations
    {
      get { return m_dfImprovementsAdditionsAndAlterations; }
      set { m_dfImprovementsAdditionsAndAlterations = value; }
    }

    /// <summary>
    /// Coverage Limit for Improvements, Additions and Alterations for Dwelling Fire
    /// </summary>
    [Description("Improvements, Additions and Alterations Limit")]
    public virtual int DFImprovementsAdditionsAndAlterationsLimit
    {
      get { return m_dfImprovementsAdditionsAndAlterationsLimit; }
      set { m_dfImprovementsAdditionsAndAlterationsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Improvements, Additions and Alterations for Dwelling Fire
    /// </summary>
	  public virtual double DFImprovementsAdditionsAndAlterationsPremium
    {
      get { return m_dfImprovementsAdditionsAndAlterationsPremium; }
      set { m_dfImprovementsAdditionsAndAlterationsPremium = value; }
    }

    /// <summary>
    /// Inflation Guard endorsement for Dwelling Fire
    /// </summary>
    [Description("Inflation Guard")]
    public virtual bool DFInflationGuard
    {
      get { return m_dfInflationGuard; }
      set { m_dfInflationGuard = value; }
    }

    /// <summary>
    /// Calculated premium for Inflation Guard for Dwelling Fire
    /// </summary>
	  public virtual double DFInflationGuardPremium
    {
      get { return m_dfInflationGuardPremium; }
      set { m_dfInflationGuardPremium = value; }
    }

    /// <summary>
    /// Loss Assessent Coverage Endorsement for Dwelling Fire
    /// </summary>
    [Description("Loss Assessment Coverage")]
    public virtual bool DFLossAssessmentCoverage
    {
      get { return m_dfLossAssessmentCoverage; }
      set { m_dfLossAssessmentCoverage = value; }
    }

    /// <summary>
    /// Coverage Limit for Loss Assessment Coverage in Dwelling Fire
    /// </summary>
    [Description("Loss Assessment Coverage Limit")]
    public virtual int DFLossAssessmentCoverageLimit
    {
      get { return m_dfLossAssessmentCoverageLimit; }
      set { m_dfLossAssessmentCoverageLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Loss Assessment Coverage for Dwelling Fire
    /// </summary>
	  public virtual double DFLossAssessmentCoveragePremium
    {
      get { return m_dfLossAssessmentCoveragePremium; }
      set { m_dfLossAssessmentCoveragePremium = value; }
    }

    /// <summary>
    /// Ordinance or Law endorsement for Dwelling Fire
    /// </summary>
    [Description("Ordinance or Law")]
    public virtual bool DFOrdinanceOrLaw
    {
      get { return m_dfOrdinanceOrLaw; }
      set { m_dfOrdinanceOrLaw = value; }
    }

    /// <summary>
    /// Percentage of Coverage A for Ordinance or Law endorsement in Dwelling Fire
    /// </summary>
    [Description("Ordinance or Law Percentage of Coverage A")]
    public virtual int DFOrdinanceOrLawPercentage
    {
      get { return m_dfOrdinanceOrLawPercentage; }
      set { m_dfOrdinanceOrLawPercentage = value; }
    }

    /// <summary>
    /// Calculated premium for Ordinance Or Law for Dwelling Fire
    /// </summary>
	  public virtual double DFOrdinanceOrLawPremium
    {
      get { return m_dfOrdinanceOrLawPremium; }
      set { m_dfOrdinanceOrLawPremium = value; }
    }

    /// <summary>
    /// Trees, Shrubs and Other Plants endorsement for Dwelling Fire
    /// </summary>
    [Description("Trees, Plants and Shrubs")]
    public virtual bool DFTreesShrubsAndPlants
    {
      get { return m_dfTreesShrubsAndPlants; }
      set { m_dfTreesShrubsAndPlants = value; }
    }

    /// <summary>
    /// Trees, Shrubs and Other Plants Limit for Dwelling Fire
    /// </summary>
    [Description("Trees, Shrubs and Other Plants Limit")]
    public virtual int DFTreesShrubsAndPlantsLimit
    {
      get { return m_dfTreesShrubsAndPlantsLimit; }
      set { m_dfTreesShrubsAndPlantsLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Trees, Shrubs and Plants for Dwelling Fire
    /// </summary>
	  public virtual double DFTreesShrubsAndPlantsPremium
    {
      get { return m_dfTreesShrubsAndPlantsPremium; }
      set { m_dfTreesShrubsAndPlantsPremium = value; }
    }

    /// <summary>
    /// Owner Occupied Theft Coverage for Dwelling Fire
    /// </summary>
    [Description("Broad Theft Coverage On Premises")]
    public virtual bool DFBroadTheftCoverageOnPremises
    {
      get { return m_dfBroadTheftCoverageOnPremises; }
      set { m_dfBroadTheftCoverageOnPremises = value; }
    }

    /// <summary>
    /// Coverage Limit for Owner Occupied Theft Coverage On Premises in Dwelling Fire
    /// </summary>
    [Description("Broad Theft Coverage On Premises Limit")]
    public virtual int DFBroadTheftOnPremisesLimit
    {
      get { return m_dfBroadTheftOnPremisesLimit; }
      set { m_dfBroadTheftOnPremisesLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Broad Theft on Premises for Dwelling Fire
    /// </summary>
	  public virtual double DFBroadTheftOnPremisesPremium
    {
      get { return m_dfBroadTheftOnPremisesPremium; }
      set { m_dfBroadTheftOnPremisesPremium = value; }
    }

    /// <summary>
    /// Owner Occupied Theft Coverage Off Premises for Dwelling Fire
    /// </summary>
    [Description("Broad Theft Coverage Off Premises")]
    public virtual bool DFBroadTheftCoverageOffPremises
    {
      get { return m_dfBroadTheftCoverageOffPremises; }
      set { m_dfBroadTheftCoverageOffPremises = value; }
    }

    /// <summary>
    /// Coverage Limit for Owner Occupied Theft Coverage Off Premises in Dwelling Fire
    /// </summary>
    [Description("Broad Theft Coverage Off Premises Limit")]
    public virtual int DFBroadTheftOffPremisesLimit
    {
      get { return m_dfBroadTheftOffPremisesLimit; }
      set { m_dfBroadTheftOffPremisesLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Broad Theft Off Premises for Dwelling Fire
    /// </summary>
	  public virtual double DFBroadTheftOffPremisesPremium
    {
      get { return m_dfBroadTheftOffPremisesPremium; }
      set { m_dfBroadTheftOffPremisesPremium = value; }
    }

    /// <summary>
    /// Non-Onwer Occupied Theft Coverage On Premises for Dwelling Fire
    /// </summary>
    [Description("Limited Theft Coverage On Premises")]
    public virtual bool DFLimitedTheftCoverage
    {
      get { return m_dfLimitedTheftCoverage; }
      set { m_dfLimitedTheftCoverage = value; }
    }

    /// <summary>
    /// Coverage Limit for Non-Owner Occupied Theft Coverage On Premises in Dwelling Fire
    /// </summary>
    [Description("Limited Theft Coverage On Premises Limit")]
    public virtual int DFLimitedTheftCoverageLimit
    {
      get { return m_dfLimitedTheftCoverageLimit; }
      set { m_dfLimitedTheftCoverageLimit = value; }
    }

    /// <summary>
    /// Calculated premium for Limited Theft Coverage for Dwelling Fire
    /// </summary>
	  public virtual double DFLimitedTheftCoveragePremium
    {
      get { return m_dfLimitedTheftCoveragePremium; }
      set { m_dfLimitedTheftCoveragePremium = value; }
    }

    /// <summary>
    /// Additional Insured Location endorsement for Dwelling Fire
    /// </summary>
    [Description("Additional Insured Location")]
    public virtual bool DFAdditionalInsuredLocation
    {
      get { return m_dfAdditionalInsuredLocation; }
      set { m_dfAdditionalInsuredLocation = value; }
    }

    /// <summary>
    /// Number of Families of the Additional Insured Location in Dwelling Fire
    /// </summary>
    [Description("Additional Insured Location Number of Families")]
    public virtual int DFAdditionalInsuredLocationNumOfFamilies
    {
      get { return m_dfAdditionalInsuredLocationNumOfFamilies; }
      set { m_dfAdditionalInsuredLocationNumOfFamilies = value; }
    }

    /// <summary>
    /// Calculated premium for Additional Insured Location for Dwelling Fire
    /// </summary>
	  public virtual double DFAdditionalInsuredLocationPremium
    {
      get { return m_dfAdditionalInsuredLocationPremium; }
      set { m_dfAdditionalInsuredLocationPremium = value; }
    }

    /// <summary>
    /// Additional Residence Premises Rented to Other endorsement for Dwelling Fire
    /// </summary>
    [Description("Additional Residence Premises Rented to Others")]
    public virtual bool DFAdditionalResidenceRentedToOthers
    {
      get { return m_dfAdditionalResidenceRentedToOthers; }
      set { m_dfAdditionalResidenceRentedToOthers = value; }
    }

    /// <summary>
    /// Number of Additional 1 Family Residences Rented to Others in Dwelling Fire
    /// </summary>
    [Description("Number of Additional 1 Family Residences Rented to Others")]
    public virtual int DFNumOfAdd1FamResidenceRentedToOthers
    {
      get { return m_dfNumOfAdd1FamResidenceRentedToOthers; }
      set { m_dfNumOfAdd1FamResidenceRentedToOthers = value; }
    }

    /// <summary>
    /// Calculated premium for Additional 1 Family Residences Rented to Others for Dwelling Fire
    /// </summary>
	  public virtual double DFAdd1FamResidenceRentedToOthersPremium
    {
      get { return m_dfAdd1FamResidenceRentedToOthersPremium; }
      set { m_dfAdd1FamResidenceRentedToOthersPremium = value; }
    }

    /// <summary>
    /// Number of Additional 2 Family Residences Rented to Others in Dwelling Fire
    /// </summary>
    [Description("Number of Additional 2 Family Residences Rented to Others")]
    public virtual int DFNumOfAdd2FamResidenceRentedToOthers
    {
      get { return m_dfNumOfAdd2FamResidenceRentedToOthers; }
      set { m_dfNumOfAdd2FamResidenceRentedToOthers = value; }
    }

    /// <summary>
    /// Calculated premium for Additional 2 Family Residences Rented to Others for Dwelling Fire
    /// </summary>
	  public virtual double DFAdd2FamResidenceRentedToOthersPremium
    {
      get { return m_dfAdd2FamResidenceRentedToOthersPremium; }
      set { m_dfAdd2FamResidenceRentedToOthersPremium = value; }
    }

    /// <summary>
    /// Number of Additional 3 Family Residences Rented to Others in Dwelling Fire
    /// </summary>
    [Description("Number of Additional 3 Family Residences Rented to Others")]
    public virtual int DFNumOfAdd3FamResidenceRentedToOthers
    {
      get { return m_dfNumOfAdd3FamResidenceRentedToOthers; }
      set { m_dfNumOfAdd3FamResidenceRentedToOthers = value; }
    }

    /// <summary>
    /// Calculated premium for Additional 3 Family Residences Rented to Others for Dwelling Fire
    /// </summary>
	  public virtual double DFAdd3FamResidenceRentedToOthersPremium
    {
      get { return m_dfAdd3FamResidenceRentedToOthersPremium; }
      set { m_dfAdd3FamResidenceRentedToOthersPremium = value; }
    }

    /// <summary>
    /// Number of Additional 4 Family Residences Rented to Others in Dwelling Fire
    /// </summary>
    [Description("Number of Additional 4 Family Residences Rented to Others")]
    public virtual int DFNumOfAdd4FamResidenceRentedToOthers
    {
      get { return m_dfNumOfAdd4FamResidenceRentedToOthers; }
      set { m_dfNumOfAdd4FamResidenceRentedToOthers = value; }
    }

    /// <summary>
    /// Calculated premium for Additional 4 Family Residences Rented to Others for Dwelling Fire
    /// </summary>
	  public virtual double DFAdd4FamResidenceRentedToOthersPremium
    {
      get { return m_dfAdd4FamResidenceRentedToOthersPremium; }
      set { m_dfAdd4FamResidenceRentedToOthersPremium = value; }
    }

    /// <summary>
    /// Calculated premium for Additional Residence Rented To Others Premium for Dwelling Fire
    /// </summary>
	  public virtual double DFAdditionalResidenceRentedToOthersPremium
    {
      get { return m_dfAdditionalResidenceRentedToOthersPremium; }
      set { m_dfAdditionalResidenceRentedToOthersPremium = value; }
    }

    /// <summary>
    /// Additional Named Insured Liability endorsement for Dwelling Fire
    /// </summary>
    [Description("Additional Named Insured")]
    public virtual bool DFAdditionalNamedInsured
    {
      get { return m_dfAdditionalNamedInsured; }
      set { m_dfAdditionalNamedInsured = value; }
    }

    /// <summary>
    /// Number of Additional Named Insureds in Dwelling Fire
    /// </summary>
    [Description("Number of Additional Named Insured")]
    public virtual int DFNumOfAdditionalInsureds
    {
      get { return m_dfNumOfAdditionalInsureds; }
      set { m_dfNumOfAdditionalInsureds = value; }
    }

    /// <summary>
    /// Calculated premium for Additional Named Insured for Dwelling Fire
    /// </summary>
	  public virtual double DFAdditionalNamedInsuredPremium
    {
      get { return m_dfAdditionalNamedInsuredPremium; }
      set { m_dfAdditionalNamedInsuredPremium = value; }
    }

    /// <summary>
    /// Animal Liability Endorsement for Dwelling Fire
    /// </summary>
    [Description("Animal Liability")]
    public virtual bool DFAnimalLiabilityLimitation
    {
      get { return m_dfAnimalLiabilityLimitation; }
      set { m_dfAnimalLiabilityLimitation = value; }
    }

    /// <summary>
    /// Calculated premium for Animal Liability for Dwelling Fire
    /// </summary>
	  public virtual double DFAnimalLiabilityPremium
    {
      get { return m_dfAnimalLiabilityPremium; }
      set { m_dfAnimalLiabilityPremium = value; }
    }

    /// <summary>
    /// Animal Liability Exclusion endorsement for Dwelling Fire
    /// </summary>
    [Description("Animal Liability Exclusion")]
    public virtual bool DFAnimalLiabilityExclusion
    {
      get { return m_dfAnimalLiabilityExclusion; }
      set { m_dfAnimalLiabilityExclusion = value; }
    }

    /// <summary>
    /// Calculated premium for Animal Liability Exclusion for Dwelling Fire
    /// </summary>
	  public virtual double DFAnimalLiabilityExclusionPremium
    {
      get { return m_dfAnimalLiabilityExclusionPremium; }
      set { m_dfAnimalLiabilityExclusionPremium = value; }
    }

    /// <summary>
    /// Business Pursuits endorsement for Dwelling Fire
    /// </summary>
    [Description("Business Pursuits")]
    public virtual bool DFBusinessPursuits
    {
      get { return m_dfBusinessPursuits; }
      set { m_dfBusinessPursuits = value; }
    }

    /// <summary>
    /// Number of Employees attribute for Business Pursuits endorsement in Dwelling Fire
    /// </summary>
    [Description("Number of Employees")]
    public virtual int DFBusinessPursuitsNumOfEmployees
    {
      get { return m_dfBusinessPursuitsNumOfEmployees; }
      set { m_dfBusinessPursuitsNumOfEmployees = value; }
    }

    /// <summary>
    /// Classification attribute for Business Pursuits endorsement in Dwelling Fire
    /// </summary>
    [Description("Business Pursuits Classification")]
    public virtual string DFBusinessPursuitsClassification
    {
      get { return m_dfBusinessPursuitsClassification; }
      set { m_dfBusinessPursuitsClassification = value; }
    }

    /// <summary>
    /// Teachers Liabiltiy for Corporal Punishment attribute for Business Pursuits endorsement in Dwelling Fire
    /// </summary>
    [Description("Business Pursuits Liability for Corporal Punishment")]
    public virtual bool DFBusinessPursuitsCorporalPunishement
    {
      get { return m_dfBusinessPursuitsCorporalPunishement; }
      set { m_dfBusinessPursuitsCorporalPunishement = value; }
    }

    /// <summary>
    /// Calculated premium for Business Pursuits for Dwelling Fire
    /// </summary>
	  public virtual double DFBusinessPursuitsPremium
    {
      get { return m_dfBusinessPursuitsPremium; }
      set { m_dfBusinessPursuitsPremium = value; }
    }

    /// <summary>
    /// Home Day Care Liability endorsement for Dwelling Fire
    /// </summary>
    [Description("Home Day Care")]
    public virtual bool DFHomeDayCare
    {
      get { return m_dfHomeDayCare; }
      set { m_dfHomeDayCare = value; }
    }

    /// <summary>
    /// Calculated premium for Home Day Care for Dwelling Fire
    /// </summary>
	  public virtual double DFHomeDayCarePremium
    {
      get { return m_dfHomeDayCarePremium; }
      set { m_dfHomeDayCarePremium = value; }
    }

    /// <summary>
    /// Permitted Incidental Occupancy endorsement for Dwelling Fire
    /// </summary>
    [Description("Permitted Incidental Occupancy")]
    public virtual bool DFPermittedIncidentalOccupancy
    {
      get { return m_dfPermittedIncidentalOccupancy; }
      set { m_dfPermittedIncidentalOccupancy = value; }
    }

    /// <summary>
    /// Calculated premium for Permitted Incidental Occupancy for Dwelling Fire
    /// </summary>
    public virtual double DFPermittedIncidentalOccupancyPremium
    {
      get { return m_dfPermittedIncidentalOccupancyPremium; }
      set { m_dfPermittedIncidentalOccupancyPremium = value; }
    }

    /// <summary>
    /// Watercraft Liability endorsement for Dwelling Fire
    /// </summary>
    [Description("Watercraft Liability")]
    public virtual bool DFWatercraftLiability
    {
      get { return m_dfWatercraftLiability; }
      set { m_dfWatercraftLiability = value; }
    }

    /// <summary>
    /// Number of Boats with Liability Coverage in Dwelling Fire
    /// </summary>
    [Description("Number of Boats")]
    public virtual int DFWatercraftLiabilityNumOfBoats
    {
      get { return m_dfWatercraftLiabilityNumOfBoats; }
      set { m_dfWatercraftLiabilityNumOfBoats = value; }
    }

    /// <summary>
    /// Calculated premium for Watercraft Liability for Dwelling Fire
    /// </summary>
	  public virtual double DFWatercraftLiabilityPremium
    {
      get { return m_dfWatercraftLiabilityPremium; }
      set { m_dfWatercraftLiabilityPremium = value; }
    }

    /// <summary>
    /// Workers Compensation endorsement for Dwelling Fire
    /// </summary>
    [Description("Workers Compensation")]
    public virtual bool DFWorkersCompensation
    {
      get { return m_dfWorkersCompensation; }
      set { m_dfWorkersCompensation = value; }
    }

    /// <summary>
    /// Number of Occasional Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
    [Description("Occasional Employees")]
    public virtual int DFNumOfOccasionalEmployees
    {
      get { return m_dfNumOfOccasionalEmployees; }
      set { m_dfNumOfOccasionalEmployees = value; }
    }

    /// <summary>
    /// Number of Inservant Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
    [Description("Inservant Employees")]
    public virtual int DFNumOfInservantEmployees
    {
      get { return m_dfNumOfInservantEmployees; }
      set { m_dfNumOfInservantEmployees = value; }
    }

    /// <summary>
    /// Number of Part-Time Inservant Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
    [Description("Part-Time Inservant Employees")]
    public virtual int DFNumOfPartTimeInservantEmployees
    {
      get { return m_dfNumOfPartTimeInservantEmployees; }
      set { m_dfNumOfPartTimeInservantEmployees = value; }
    }

    /// <summary>
    /// Number of Outservant Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
    [Description("Outservant Employees")]
    public virtual int DFNumOfOutservantEmployees
    {
      get { return m_dfNumOfOutservantEmployees; }
      set { m_dfNumOfOutservantEmployees = value; }
    }

    /// <summary>
    /// Number of Part-Time Outservant Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
    [Description("Part-Time Outservant Employees")]
    public virtual int DFNumOfPartTimeOutservantEmployees
    {
      get { return m_dfNumOfPartTimeOutservantEmployees; }
      set { m_dfNumOfPartTimeOutservantEmployees = value; }
    }

    /// <summary>
    /// Calculated premium for Occasional Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
	  public virtual double DFWorkersCompOccasionalEmployeesPremium
    {
      get { return m_dfWorkersCompOccasionalEmployeesPremium; }
      set { m_dfWorkersCompOccasionalEmployeesPremium = value; }
    }

    /// <summary>
    /// Calculated premium for Full-Time Inservant Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
	  public virtual double DFWorkersCompFullTimeInservantEmployeesPremium
    {
      get { return m_dfWorkersCompFullTimeInservantEmployeesPremium; }
      set { m_dfWorkersCompFullTimeInservantEmployeesPremium = value; }
    }

    /// <summary>
    /// Calculated premium for Part-Time Inservant Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
	  public virtual double DFWorkersCompPartTimeInservantEmployeesPremium
    {
      get { return m_dfWorkersCompPartTimeInservantEmployeesPremium; }
      set { m_dfWorkersCompPartTimeInservantEmployeesPremium = value; }
    }

    /// <summary>
    /// Calculated premium for Full-Time Outservant Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
	  public virtual double DFWorkersCompFullTimeOutservantEmployeesPremium
    {
      get { return m_dfWorkersCompFullTimeOutservantEmployeesPremium; }
      set { m_dfWorkersCompFullTimeOutservantEmployeesPremium = value; }
    }

    /// <summary>
    /// Calculated premium for Part-Time Outservant Employees covered by Workers Compensation for Dwelling Fire
    /// </summary>
	  public virtual double DFWorkersCompPartTimeOutservantEmployeesPremium
    {
      get { return m_dfWorkersCompPartTimeOutservantEmployeesPremium; }
      set { m_dfWorkersCompPartTimeOutservantEmployeesPremium = value; }
    }

    /// <summary>
    /// Calculated premium for Workers Compensation for Dwelling Fire
    /// </summary>
    public virtual double DFWorkersCompensationPremium
    {
      get { return m_dfWorkersCompensationPremium; }
      set { m_dfWorkersCompensationPremium = value; }
    }
  }
}
