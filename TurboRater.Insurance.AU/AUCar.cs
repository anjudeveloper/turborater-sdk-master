using System;
using System.Collections.Generic;
using System.Reflection;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// Represents an automobile. This can be a pickup, semi,
  /// motorcycle, trailer, etc. It is used in automobile insurance
  /// policies.
  /// </summary>
  public class AUCar : BaseStoredRecord
  {
    #region Private Variables
    private CompanyQuestionList m_companyQuestions = new CompanyQuestionList();
    private int m_policylinkid = ITCConstants.InvalidNum;
    private string m_maker = "";
    private string m_model = "";
    private string m_vin = "";
    private int m_year = 2005;
    private int m_acv;
    private int m_acvw;
    private string m_airBags = "N";
    private int m_annualMiles;
    private string m_antiLock = "N";
    private string m_antiTheft = "N";
    private string m_bodyType = "";
    private string m_city = "";
    private bool m_coll = true;
    private int m_collDed = 500;
    private double m_collPremium;
    private bool m_comp = true;
    private int m_compDed = 500;
    private double m_compPremium;
    private bool m_convertible;
    private string m_coSym = "";
    private string m_coTerr = "";
    private string m_county = "";
    private int m_coWhichDrv;
    private bool m_custom;
    private double m_customEquipPremium;
    private int m_customEquipValue;
    private bool m_dualie;
    private bool m_extendedCab;
    private bool m_fiberglass;
    private bool m_fourWheelDrive;
    private bool m_fourWheelSteering;
    private bool m_frontWD;
    private string m_fuelType = "G";
    private bool m_hatchback;
    private bool m_homingDevice;
    private bool m_hoodLock;
    private int m_isoSymbol = 8;
    private int m_isoTerritory;
    private string m_isoVSR = "";
    private bool m_liab = true;
    private bool m_liabBI = true;
    private double m_liabBIPremium;
    private bool m_liabPD = true;
    private double m_liabPDPremium;
    private bool m_loJack;
    private int m_makerCode = ITCConstants.InvalidNum;
    private bool m_medPay;
    private int m_medPayLimit = 500;
    private double m_medPayPremium;
    private bool m_mexicoCoverage;
    private double m_mexicoPremium;
    private int m_miles;
    private int m_modelCode = ITCConstants.InvalidNum;
    private int m_modelGroupCode = ITCConstants.InvalidNum;
    private int m_msrp;
    private int m_numOfCyl = 4;
    private int m_numOfDoors = 4;
    private int m_odometer;
    private string m_passSeatRestraint = "N";
    private int m_percentToWork = 100;
    private bool m_pip = true;
    private int m_pipLimit = 2500;
    private double m_pipPremium;
    private int m_points;
    private int m_primaryOperator = ITCConstants.InvalidNum;
    private string m_region = "";
    private bool m_rental;
    private int m_rentalLimit = 15;
    private double m_rentalPremium;
    private bool m_runningLights;
    private bool m_sunRoof;
    private int m_taisoSymbol = 4;
    private int m_taisoTerritory;
    private bool m_towing;
    private int m_towingLimit = 20;
    private double m_towingPremium;
    private string m_truckSize = "2";
    private bool m_ttops;
    private bool m_turbo;
    private bool m_twoSeater;
    private bool m_uimbi;
    private double m_uimbiPremium;
    private bool m_uimpd;
    private int m_uimpdLimit;
    private double m_uimpdPremium;
    private bool m_uninsBI = true;
    private double m_uninsBIPremium;
    private bool m_uninsPD = true;
    private int m_uninsPDLimit = 15;
    private double m_uninsPDPremium;
    private int m_uniqueSymCode = ITCConstants.InvalidNum;
    private int m_uniqueTerrCode = ITCConstants.InvalidNum;
    private string m_usage = "W";
    private string m_vehicleType = "C";
    private bool m_vinEtching;
    private bool m_windowID;
    private int m_zipCode = 75001;
    private int m_liabLimits1 = 20;
    private int m_liabLimits2 = 40;
    private int m_liabLimits3 = 15;
    private int m_coLiabLimits1 = 20000;
    private int m_coLiabLimits2 = 40000;
    private int m_coLiabLimits3 = 15000;
    private int m_coCompDed = 500;
    private int m_coCollDed = 500;
    private int m_coCustomEquipValue;
    private int m_coPIPLimit = 2500;
    private int m_coMedPayLimit = 500;
    private int m_coUIMBILimits1 = 20000;
    private int m_coUIMBILimits2 = 40000;
    private int m_coTowingLimit = 20;
    private int m_coUIMPDLimit = 15000;
    private int m_coUninsBILimits1 = 20000;
    private int m_coUninsBILimits2 = 40000;
    private int m_coUninsPDLimit = 15000;
    private int m_coRentalLimit = 15;
    private int m_uninsPDDed;
    private int m_coUninsPDDed;
    private int m_uninsBILimits1 = 20000;
    private int m_uninsBILimits2 = 40000;
    private bool m_conversionVan;
    private bool m_garaged;
    private string m_garagingZipCode = "";
    private string m_garagingCity = "";
    private string m_garagingAddr1 = "";
    private string m_garagingAddr2 = "";
    private USState m_garagingState = USState.NoneSelected;
    private string m_purchaseType = "N";
    private bool m_leasedVehicle;
    private string m_licensePlateNumber = "";
    private DateTime m_purchaseDate = ITCConstants.InvalidDate;
    private bool m_inspected;
    private bool m_ratedStatedAmount;
    private string m_collType = "";
    private string m_coCollType = "";
    private int m_pIPDed = InsConstants.BlankLimitVal;
    private int m_coPIPDed = InsConstants.BlankLimitVal;
    private string m_pIPType = "";
    private string m_coPIPType = "";
    private bool m_stackedPIP;
    private bool m_coStackedPIP;
    private bool m_guestPIP;
    private bool m_militaryPIP;
    private bool m_pIPCoPay;
    private int m_pIPCoPayPercent;
    private bool m_pIPPPO;
    private bool m_buyBackPIP;
    private bool m_waivedPIP;
    private bool m_fullAddtlPIP;
    private double m_addtlPIPPremium;
    private bool m_outStatePIP;
    private double m_outStatePIPPremium;
    private bool m_accDeath;
    private int m_accDeathLimit = InsConstants.BlankLimitVal;
    private int m_coAccDeathLimit = InsConstants.BlankLimitVal;
    private double m_accDeathPremium;
    private bool m_combineBen;
    private int m_combineBenLimit = InsConstants.BlankLimitVal;
    private int m_coCombineBenLimit = InsConstants.BlankLimitVal;
    private double m_combineBenPremium;
    private bool m_fullGlass;
    private bool m_coFullGlass;
    private double m_fullGlassPremium;
    private bool m_extraMed;
    private int m_extraMedLimit = InsConstants.BlankLimitVal;
    private int m_coExtraMedLimit = InsConstants.BlankLimitVal;
    private double m_extraMedPremium;
    private bool m_funeral;
    private int m_funeralLimit = InsConstants.BlankLimitVal;
    private int m_coFuneralLimit = InsConstants.BlankLimitVal;
    private double m_funeralPremium;
    private bool m_incomeLoss;
    private int m_incomeLossLimit = InsConstants.BlankLimitVal;
    private int m_incomeLossLimit2 = InsConstants.BlankLimitVal;
    private int m_coIncomeLossLimit = InsConstants.BlankLimitVal;
    private int m_coIncomeLossLimit2 = InsConstants.BlankLimitVal;
    private double m_incomeLossPremium;
    private bool m_limitedLiabPD;
    private int m_limitedLiabPDLimit = InsConstants.BlankLimitVal;
    private int m_coLimitedLiabPDLimit = InsConstants.BlankLimitVal;
    private double m_limitedLiabPDPremium;
    private bool m_loanLease;
    private bool m_coLoanLease;
    private double m_loanLeasePremium;
    private string m_medExpense = "";
    private int m_medPayDed = InsConstants.BlankLimitVal;
    private int m_coMedPayDed = InsConstants.BlankLimitVal;
    private bool m_oBEL;
    private int m_oBELLimit = InsConstants.BlankLimitVal;
    private int m_coOBELLimit = InsConstants.BlankLimitVal;
    private double m_oBELPremium;
    private bool m_pPI;
    private int m_pPILimit = InsConstants.BlankLimitVal;
    private int m_coPPILimit = InsConstants.BlankLimitVal;
    private double m_pPIPremium;
    private bool m_stackedUM;
    private bool m_coStackedUM;
    private bool m_uMConversion;
    private bool m_coUMConversion;
    private bool m_stackedUIM;
    private bool m_coStackedUIM;
    private bool m_sUM;
    private int m_sUMLimits1 = InsConstants.BlankLimitVal;
    private int m_sUMLimits2 = InsConstants.BlankLimitVal;
    private int m_coSUMLimits1 = InsConstants.BlankLimitVal;
    private int m_coSUMLimits2 = InsConstants.BlankLimitVal;
    private double m_sUMPremium;
    private bool m_workLoss;
    private double m_allocationFee;
    private bool m_carPhone;
    private double m_recoupmentFee;
    private int m_UIMBILimits1 = 20;
    private int m_UIMBILimits2 = 40;
    private string m_coCarTierStr = "";
    private int m_coLienHolderCollDed = InsConstants.BlankLimitVal;
    private int m_coLienHolderCompDed = InsConstants.BlankLimitVal;
    private bool m_coLienHolderDed;
    private string m_color = "";
    private bool m_coPIPCoPay;
    private int m_coPIPCoPayPercent;
    private bool m_coPIPPPO;
    private bool m_coWorkLoss;
    private bool m_foreignCar;
    private bool m_grayMarket;
    private bool m_guardianInterlock;
    private string m_lienHolderAddress1 = "";
    private string m_lienHolderAddress12 = "";
    private string m_lienHolderAddress2 = "";
    private string m_lienHolderAddress22 = "";
    private string m_lienHolderCity = "";
    private string m_lienHolderCity2 = "";
    private int m_lienHolderCollDed = InsConstants.BlankLimitVal;
    private int m_lienHolderCompDed = InsConstants.BlankLimitVal;
    private bool m_lienHolderDed;
    private string m_lienHolderFaxNum = "";
    private string m_lienHolderFaxNum2 = "";
    private string m_lienHolderID = "";
    private string m_lienHolderID2 = "";
    private string m_lienHolderName = "";
    private string m_lienHolderName2 = "";
    private string m_lienHolderPhone = "";
    private string m_lienHolderPhone2 = "";
    private double m_lienHolderPremium;
    private USState m_lienHolderState = USState.NoneSelected;
    private USState m_lienHolderState2 = USState.NoneSelected;
    private LienHolderType m_lienHolderType = LienHolderType.NoLienHolder;
    private LienHolderType m_lienHolderType2 = LienHolderType.NoLienHolder;
    private string m_lienHolderZip = "";
    private string m_lienHolderZip2 = "";
    private string m_loanNum = "";
    private string m_loanNum2 = "";
    private bool m_medicare;
    private bool m_outsizedTires;
    private int m_primaryOperatorID = ITCConstants.InvalidNum;
    private int m_purchaseCost;
    private bool m_restructureField;
    private string m_secondaryCoSym = "";
    private string m_secondaryCoTerr = "";
    private int m_secondaryCoWhichDrv;
    private int m_secondaryPoints;
    private int m_symRateMode;
    private string m_territory = "";
    private int m_isoLiabSymbol;
    private int m_isoLiabSymbol2008;
    private int m_isoLiabSymbol2010;
    private int m_isoLiabSymbol2012;
    private int m_isoLiabSymbol2014;
    private bool m_gapCoverage;
    private double m_gapPremium;
    private List<int> m_coveragePoints = new List<int>();
    private InsPolicy m_parentPolicy;
    private List<int> m_secondaryCoveragePoints = new List<int>();
    private bool m_salvaged;
    private bool m_licensedForRoadUse = true;
    private MotorcycleBody m_motorcycleBodyType = MotorcycleBody.RoadStreet;
    private int m_displacement;
    private bool m_modifications;
    private bool m_engineChangesExternal;
    private bool m_engineChangesInternal;
    private bool m_engineChangesOtherInternal;
    private MotorcycleVehicleUsage m_motorcycleUsage = MotorcycleVehicleUsage.ToWork;
    private bool m_tripInterruption;
    private int m_tripInterruptionLimit;
    private double m_tripInterruptionPremium;
    private int m_coTripInterruptionLimit;
    private bool m_replacementCost;
    private bool m_coReplacementCost;
    private double m_replacementCostPremium;
    private bool m_transportTrailer;
    private double m_transportTrailerPremium;
    private int m_transportTrailerValue;
    private int m_coTransportTrailerValue;
    private string m_symbol = string.Empty;
    private string m_highRisk = string.Empty;
    private string m_isoBodyType = string.Empty;
    private int m_UIMPDDed;
    private int m_coUIMPDDed;
    private int m_pipLimit2;
    private int m_coPIPLimit2;
    private bool m_tort;
    private double m_tortPremium;
    private int m_tortLimit;
    private int m_coTortLimit;
    private bool m_collWaiver;
    private int m_addtlPIPLimit1;
    private int m_coAddtlPIPLimit1;
    private int m_addtlPIPLimit2;
    private int m_coAddtlPIPLimit2;
    private bool m_limitedColl;
    private int m_limitedCollDed;
    private int m_coLimitedCollDed;
    private bool m_ignored;
    private string m_pIPDedOption = string.Empty;
    private string m_coPIPDedOption = string.Empty;
    private int m_pIPMedicalDed = InsConstants.BlankLimitVal;
    private int m_coPIPMedicalDed = InsConstants.BlankLimitVal;
    private PIPWorkLossDeductible m_pIPWorkLossDed = PIPWorkLossDeductible.NoDeductible;
    private PIPWorkLossDeductible m_coPIPWorkLossDed = PIPWorkLossDeductible.NoDeductible;
    private double m_pipDeathBenefitPremium;
    private string m_pIPWorkLossRejection = string.Empty;
    private string m_coPIPWorkLossRejection = string.Empty;
    private UninsType m_uninsType = UninsType.None;
    private bool m_optionalBI;
    private double m_optionalBIPremium;
    private int m_optionalBILimit1;
    private int m_optionalBILimit2;
    private int m_coOptionalBILimit1;
    private int m_coOptionalBILimit2;
    private bool m_totalDisability;
    private int m_totalDisabilityLimit;
    private TotalDisabilityType m_totalDisabilityType;
    private string m_rapaLiabilitySymbol = string.Empty;
    private string m_rapaGALiabilitySymbol = string.Empty;
    private string m_rapaSymbol = string.Empty;
    private string m_rapaGASymbol = string.Empty;
    private bool m_legalExpense;
    private double m_legalExpensePremium;
    private string m_rapaAntiLockIndicator = string.Empty;
    private string m_grapaAntiLockIndicator = string.Empty;
    private bool m_rejectUIMPD;
    private bool m_coRejectUIMPD;
    private bool m_garageAddressSameAsMailing = true;
    private USState m_commutesOutOfState = USState.NoneSelected;
    private bool m_usageBased;
    private string m_addPIPOption = string.Empty;
    private string m_coAddPIPOption = string.Empty;
    private bool m_medicalExpenseOnly;
    private bool m_coMedicalExpenseOnly;
    private double m_medicalExpenseOnlyPremium;
    private bool m_extendedMedical;
    private int m_extendedMedicalLimit;
    private int m_coExtendedMedicalLimit;
    private double m_extendedMedicalPremium;
    private bool m_spousalLiability;
    private double m_spousalLiabilityPremium;
    private bool m_rideshare = false;
    private int m_pipAttendantCareOptionLimit = InsConstants.BlankLimitVal;
    private int m_coPipAttendantCareOptionLimit = InsConstants.BlankLimitVal;
    private double m_pipAttendantCareOptionPremium;
    private bool m_pipAttendantCareOption;

    #endregion Private Variables

    #region Public Properties
    /// <summary>
    /// Is this vehicle to be ignored for rating purposes
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Ignored
    {
      get { return m_ignored; }
      set { m_ignored = value; }
    }

    /// <summary>
    /// The company questions associated with the car
    /// </summary>
    public virtual CompanyQuestionList CompanyQuestions
    {
      get { return m_companyQuestions; }
      set { m_companyQuestions = value; }
    }

    /// <summary>
    /// Foreign key link back to the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int, ForeignKeyClassType = typeof(AUPolicy))]
    public virtual int PolicyLinkID
    {
      get { return m_policylinkid; }
      set { m_policylinkid = value; }
    }

    /// <summary>
    /// Vehicle's maker. Ex: Toyota
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.MakerLength)]
    public virtual string Maker
    {
      get { return m_maker; }
      set { m_maker = value; }
    }

    /// <summary>
    /// Vehicle's model. Ex: F150
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ModelLength)]
    public virtual string Model
    {
      get { return m_model; }
      set { m_model = value; }
    }

    /// <summary>
    /// The VIN of the vehicle.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.VINLength)]
    public virtual string VIN
    {
      get { return m_vin; }
      set { m_vin = value; }
    }

    /// <summary>
    /// The vehicle's year model.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int Year
    {
      get { return m_year; }
      set { m_year = value; }
    }

    /// <summary>
    /// The vehicle's Actual Cash Value
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ACV
    {
      get { return m_acv; }
      set { m_acv = value; }
    }

    /// <summary>
    /// The vehicle's Wholesale Actual Cash Value
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ACVW
    {
      get { return m_acvw; }
      set { m_acvw = value; }
    }

    /// <summary>
    /// The vehicle's type of air bags.
    /// </summary>
    /// <seealso cref="AirBag">AirBag</seealso>
    /// <seealso cref="AUConstants.AirBagNames">AUConstants.AirBagNames</seealso>
    /// <seealso cref="AUConstants.AirBagChars">AUConstants.AirBagChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string AirBags
    {
      get { return m_airBags; }
      set { m_airBags = value; }
    }

    /// <summary>
    /// The average annual miles this vehicle is driven.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int AnnualMiles
    {
      get { return m_annualMiles; }
      set { m_annualMiles = value; }
    }

    /// <summary>
    /// The vehicle's antilock brakes type
    /// </summary>
    /// <seealso cref="AntiLockBrakes">AntiLockBrakes</seealso>
    /// <seealso cref="AUConstants.AntiLockBrakesNames">AUConstants.AntiLockBrakesNames</seealso>
    /// <seealso cref="AUConstants.AntiLockBrakesChars">AUConstants.AntiLockBrakesChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string AntiLock
    {
      get { return m_antiLock; }
      set { m_antiLock = value; }
    }

    /// <summary>
    /// The vehicle's anti-theft device type
    /// </summary>
    /// <seealso cref="AntiTheft">AntiTheft</seealso>
    /// <seealso cref="AUConstants.AntiTheftNames">AUConstants.AntiTheftNames</seealso>
    /// <seealso cref="AUConstants.AntiTheftNames">AUConstants.AntiTheftNames</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string AntiTheft
    {
      get { return m_antiTheft; }
      set { m_antiTheft = value; }
    }

    /// <summary>
    /// the vehicle's body type
    /// </summary>
    /// <seealso cref="CarBody">CarBody</seealso>
    /// <seealso cref="AUConstants.CarBodyNames">AUConstants.CarBodyNames</seealso>
    /// <seealso cref="AUConstants.CarBodyNames">AUConstants.CarBodyNames</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 2)]
    public virtual string BodyType
    {
      get { return m_bodyType; }
      set { m_bodyType = value; }
    }

    /// <summary>
    /// The city in which this vehicle is located.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.CityLength)]
    public virtual string City
    {
      get { return m_city; }
      set { m_city = value; }
    }

    /// <summary>
    /// Is collision coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Coll
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_coll;
      }
      set { m_coll = value; }
    }

    /// <summary>
    /// The collision coverage deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CollDed
    {
      get { return m_collDed; }
      set { m_collDed = value; }
    }

    /// <summary>
    /// Collision coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double CollPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_collPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_collPremium = value;
        }
        else
          m_collPremium = value;
      }
    }

    /// <summary>
    /// Is comprehensive coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Comp
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_comp;
      }
      set { m_comp = value; }
    }

    /// <summary>
    /// Comprehensive coverage deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CompDed
    {
      get { return m_compDed; }
      set { m_compDed = value; }
    }

    /// <summary>
    /// Comprehensive coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double CompPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_compPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_compPremium = value;
        }
        else
          m_compPremium = value;
      }
    }

    /// <summary>
    /// Is this vehicle a convertible?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Convertible
    {
      get { return m_convertible; }
      set { m_convertible = value; }
    }

    /// <summary>
    /// The vehicle's company symbol
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string CoSym
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return m_secondaryCoSym;
        }
        return m_coSym;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
          {
            m_secondaryCoSym = value;
            return;
          }
        }
        m_coSym = value;
      }
    }

    /// <summary>
    /// The vehicle's company territory
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string CoTerr
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return m_secondaryCoTerr;
        }
        return m_coTerr;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
          {
            m_secondaryCoTerr = value;
            return;
          }
        }
        m_coTerr = value;
      }
    }

    /// <summary>
    /// The county in which this vehicle is located
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 35)]
    public virtual string County
    {
      get { return m_county; }
      set { m_county = value; }
    }

    /// <summary>
    /// Which driver did the company assign this vehicle to?
    /// This is assuming a 1-index array unfortunately. Consider
    /// this a legacy of our Delphi code.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoWhichDrv
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return m_secondaryCoWhichDrv;
        }
        return m_coWhichDrv;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
          {
            m_secondaryCoWhichDrv = value;
            return;
          }
        }
        m_coWhichDrv = value;
      }
    }

    /// <summary>
    /// Is this a custom vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Custom
    {
      get { return m_custom; }
      set { m_custom = value; }
    }

    /// <summary>
    /// Custom equipment premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double CustomEquipPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_customEquipPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_customEquipPremium = value;
        }
        else
          m_customEquipPremium = value;
      }
    }

    /// <summary>
    /// Value of custom equipment
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CustomEquipValue
    {
      get { return m_customEquipValue; }
      set { m_customEquipValue = value; }
    }

    /// <summary>
    /// Is this vehicle a dualie?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Dualie
    {
      get { return m_dualie; }
      set { m_dualie = value; }
    }

    /// <summary>
    /// Is this vehicle an extended cab?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ExtendedCab
    {
      get { return m_extendedCab; }
      set { m_extendedCab = value; }
    }

    /// <summary>
    /// Is this vehicle made of fiberglass?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Fiberglass
    {
      get { return m_fiberglass; }
      set { m_fiberglass = value; }
    }

    /// <summary>
    /// Is this vehicle four wheel drive?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FourWheelDrive
    {
      get { return m_fourWheelDrive; }
      set { m_fourWheelDrive = value; }
    }

    /// <summary>
    /// Does this vehicle have four wheel steering?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FourWheelSteering
    {
      get { return m_fourWheelSteering; }
      set { m_fourWheelSteering = value; }
    }

    /// <summary>
    /// Is this vehicle front wheel drive?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FrontWD
    {
      get { return m_frontWD; }
      set { m_frontWD = value; }
    }

    /// <summary>
    /// The fuel type of the vehicle.
    /// </summary>
    /// <seealso cref="FuelType">FuelType</seealso>
    /// <seealso cref="AUConstants.FuelTypeNames">AUConstants.FuelTypeNames</seealso>
    /// <seealso cref="AUConstants.FuelTypeChars">AUConstants.FuelTypeChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string FuelType
    {
      get { return m_fuelType; }
      set { m_fuelType = value; }
    }

    /// <summary>
    /// Is this vehicle a hatchback?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Hatchback
    {
      get { return m_hatchback; }
      set { m_hatchback = value; }
    }

    /// <summary>
    /// Does the vehicle have a homing device?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool HomingDevice
    {
      get { return m_homingDevice; }
      set { m_homingDevice = value; }
    }

    /// <summary>
    /// Does this vehicle have a hood lock?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool HoodLock
    {
      get { return m_hoodLock; }
      set { m_hoodLock = value; }
    }

    /// <summary>
    /// The ISO symbol for the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ISOSymbol
    {
      get { return m_isoSymbol; }
      set { m_isoSymbol = value; }
    }

    /// <summary>
    /// the ISO territory for the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ISOTerritory
    {
      get { return m_isoTerritory; }
      set { m_isoTerritory = value; }
    }

    /// <summary>
    /// The vehicle's ISO VSR (Vehicle symbol rating)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string ISOVSR
    {
      get { return m_isoVSR; }
      set { m_isoVSR = value; }
    }

    /// <summary>
    /// Is liab coverage turned on for the vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Liab
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_liab;
      }
      set { m_liab = value; }
    }

    /// <summary>
    /// Is liab Bodily Injury coverage turned on for the vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LiabBI
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_liabBI;
      }
      set { m_liabBI = value; }
    }

    /// <summary>
    /// The vehicle's liability BI premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double LiabBIPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_liabBIPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_liabBIPremium = value;
        }
        else
          m_liabBIPremium = value;
      }
    }

    /// <summary>
    /// Is liab Physical Damage coverage turned on for the vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LiabPD
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_liabPD;
      }
      set { m_liabPD = value; }
    }

    /// <summary>
    /// The vehicle's liab PD premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double LiabPDPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_liabPDPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_liabPDPremium = value;
        }
        else
          m_liabPDPremium = value;
      }
    }

    /// <summary>
    /// Does this vehicle hav a lojack device?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LoJack
    {
      get { return m_loJack; }
      set { m_loJack = value; }
    }

    /// <summary>
    /// The maker code for the vehicle. This links back
    /// into our lovely symbol data files.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MakerCode
    {
      get { return m_makerCode; }
      set { m_makerCode = value; }
    }

    /// <summary>
    /// Is medical payments coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool MedPay
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_medPay;
      }
      set { m_medPay = value; }
    }

    /// <summary>
    /// the medical payments limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MedPayLimit
    {
      get { return m_medPayLimit; }
      set { m_medPayLimit = value; }
    }

    /// <summary>
    /// The medical payments premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double MedPayPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_medPayPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_medPayPremium = value;
        }
        else
          m_medPayPremium = value;
      }
    }

    /// <summary>
    /// Does this vehicle have mexico coverage turned on?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool MexicoCoverage
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_mexicoCoverage;
      }
      set { m_mexicoCoverage = value; }
    }

    /// <summary>
    /// The mexico coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double MexicoPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_mexicoPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_mexicoPremium = value;
        }
        else
          m_mexicoPremium = value;
      }
    }

    /// <summary>
    /// The number of miles this vehicle drives for its work commute
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int Miles
    {
      get { return m_miles; }
      set { m_miles = value; }
    }

    /// <summary>
    /// The model code for the vehicle. This links back into our
    /// lovely symbol data files.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ModelCode
    {
      get { return m_modelCode; }
      set { m_modelCode = value; }
    }

    /// <summary>
    /// The model group code for the vehicle. This links back into 
    /// our lovely symbol data files.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ModelGroupCode
    {
      get { return m_modelGroupCode; }
      set { m_modelGroupCode = value; }
    }

    /// <summary>
    /// The vehicle's Manufacturer's Suggested Retail Price
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MSRP
    {
      get { return m_msrp; }
      set { m_msrp = value; }
    }

    /// <summary>
    /// Vehicle's number of cylinders
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int NumOfCyl
    {
      get { return m_numOfCyl; }
      set { m_numOfCyl = value; }
    }

    /// <summary>
    /// Vehicle's number of doors
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int NumOfDoors
    {
      get { return m_numOfDoors; }
      set { m_numOfDoors = value; }
    }

    /// <summary>
    /// The current odometer reading of the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int Odometer
    {
      get { return m_odometer; }
      set { m_odometer = value; }
    }

    /// <summary>
    /// The type of passive seat restraint that this vehicle has.
    /// </summary>
    /// <seealso cref="PassiveRestraints">PassiveRestraints</seealso>
    /// <seealso cref="AUConstants.PassiveRestraintsNames">AUConstants.PassiveRestraintsNames</seealso>
    /// <seealso cref="AUConstants.PassiveRestraintsChars">AUConstants.PassiveRestraintsChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string PassSeatRestraint
    {
      get { return m_passSeatRestraint; }
      set { m_passSeatRestraint = value; }
    }

    /// <summary>
    /// The percentage of this vehicle's driving amount that is spent
    /// driving to work.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PercentToWork
    {
      get { return m_percentToWork; }
      set { m_percentToWork = value; }
    }

    /// <summary>
    /// Is personal injury protection coverage turned on for this 
    /// vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PIP
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_pip;
      }
      set { m_pip = value; }
    }

    /// <summary>
    /// Personal injury protection limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PIPLimit
    {
      get { return m_pipLimit; }
      set { m_pipLimit = value; }
    }

    /// <summary>
    /// PIP premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PIPPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_pipPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_pipPremium = value;
        }
        else
          m_pipPremium = value;
      }
    }

    /// <summary>
    /// The number of points assigned to this vehicle. This value
    /// is dependent on the driver assigned to the vehicle, if any.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int Points
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return m_secondaryPoints;
        }
        return m_points;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
          {
            m_secondaryPoints = value;
            return;
          }
        }
        m_points = value;
      }
    }

    /// <summary>
    /// Which driver is the primary operator of this vehicle? Note
    /// that this is a 1-based value, whereas the drivers array is
    /// 0-based. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PrimaryOperator
    {
      get { return m_primaryOperator; }
      set { m_primaryOperator = value; }
    }

    /// <summary>
    /// The region in which this vehicle is located. Used for
    /// territory lookup.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 40)]
    public virtual string Region
    {
      get { return m_region; }
      set { m_region = value; }
    }

    /// <summary>
    /// Is rental coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Rental
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_rental;
      }
      set { m_rental = value; }
    }

    /// <summary>
    /// Rental coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int RentalLimit
    {
      get { return m_rentalLimit; }
      set { m_rentalLimit = value; }
    }

    /// <summary>
    /// Rental coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double RentalPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_rentalPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_rentalPremium = value;
        }
        else
          m_rentalPremium = value;
      }
    }

    /// <summary>
    /// Does this vehicle have running lights?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool RunningLights
    {
      get { return m_runningLights; }
      set { m_runningLights = value; }
    }

    /// <summary>
    /// Does the vehicle have a sun roof?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SunRoof
    {
      get { return m_sunRoof; }
      set { m_sunRoof = value; }
    }

    /// <summary>
    /// The TAISO symbol of the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int TAISOSymbol
    {
      get { return m_taisoSymbol; }
      set { m_taisoSymbol = value; }
    }

    /// <summary>
    /// The vehicle's TAISO territory
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int TAISOTerritory
    {
      get { return m_taisoTerritory; }
      set { m_taisoTerritory = value; }
    }

    /// <summary>
    /// Is towing coverage turned on for the vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Towing
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_towing;
      }
      set { m_towing = value; }
    }

    /// <summary>
    /// Towing coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int TowingLimit
    {
      get { return m_towingLimit; }
      set { m_towingLimit = value; }
    }

    /// <summary>
    /// Towing coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double TowingPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_towingPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_towingPremium = value;
        }
        else
          m_towingPremium = value;
      }
    }

    /// <summary>
    /// Assuming the vehicle is a truck, this tells what size
    /// of truck it is. 1-ton, 1/2ton, etc.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string TruckSize
    {
      get { return m_truckSize; }
      set { m_truckSize = value; }
    }

    /// <summary>
    /// Is this vehicle a T-Top?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool TTops
    {
      get { return m_ttops; }
      set { m_ttops = value; }
    }

    /// <summary>
    /// Is this vehicle turbo charged?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Turbo
    {
      get { return m_turbo; }
      set { m_turbo = value; }
    }

    /// <summary>
    /// Is this vehicle a two-seater?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool TwoSeater
    {
      get { return m_twoSeater; }
      set { m_twoSeater = value; }
    }

    /// <summary>
    /// Is under insured motorists bodily injury coverage
    /// turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool UIMBI
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_uimbi;
      }
      set { m_uimbi = value; }
    }

    /// <summary>
    /// under insured motorists bodily injury premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double UIMBIPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_uimbiPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_uimbiPremium = value;
        }
        else
          m_uimbiPremium = value;
      }
    }

    /// <summary>
    /// Is under insured motorists physical damage coverage
    /// turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool UIMPD
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_uimpd;
      }
      set { m_uimpd = value; }
    }

    /// <summary>
    /// under insured motorists physical damage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UIMPDLimit
    {
      get { return m_uimpdLimit; }
      set { m_uimpdLimit = value; }
    }

    /// <summary>
    /// under insured motorists physical damage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double UIMPDPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_uimpdPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_uimpdPremium = value;
        }
        else
          m_uimpdPremium = value;
      }
    }

    /// <summary>
    /// Is uninsured motorists bodily injury coverage turned
    /// on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool UninsBI
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_uninsBI;
      }
      set { m_uninsBI = value; }
    }

    /// <summary>
    /// uninsured motorists bodily injury premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double UninsBIPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_uninsBIPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_uninsBIPremium = value;
        }
        else
          m_uninsBIPremium = value;
      }
    }

    /// <summary>
    /// Is uninsured motorists physical damage coverage 
    /// turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool UninsPD
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_uninsPD;
      }
      set { m_uninsPD = value; }
    }

    /// <summary>
    /// uninsured motorists physical damage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UninsPDLimit
    {
      get { return m_uninsPDLimit; }
      set { m_uninsPDLimit = value; }
    }

    /// <summary>
    /// uninsured motorists physical damage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double UninsPDPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_uninsPDPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_uninsPDPremium = value;
        }
        else
          m_uninsPDPremium = value;
      }
    }

    /// <summary>
    /// Unique symbol code for this vehicle. This is used to link
    /// back into our symbol data files.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UniqueSymCode
    {
      get { return m_uniqueSymCode; }
      set { m_uniqueSymCode = value; }
    }

    /// <summary>
    /// Unique territory code for this vehicle. This is used to link
    /// back into our symbol data files.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UniqueTerrCode
    {
      get { return m_uniqueTerrCode; }
      set { m_uniqueTerrCode = value; }
    }

    /// <summary>
    /// How is this vehicle used?
    /// </summary>
    /// <seealso cref="VehicleUsage">VehicleUsage</seealso>
    /// <seealso cref="AUConstants.VehicleUsageNames">AUConstants.VehicleUsageNames</seealso>
    /// <seealso cref="AUConstants.VehicleUsageChars">AUConstants.VehicleUsageChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string Usage
    {
      get { return m_usage; }
      set { m_usage = value; }
    }

    /// <summary>
    /// The type of vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string VehicleType
    {
      get { return m_vehicleType; }
      set { m_vehicleType = value; }
    }

    /// <summary>
    /// Does this vehicle have VIN etching?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool VINEtching
    {
      get { return m_vinEtching; }
      set { m_vinEtching = value; }
    }

    /// <summary>
    /// Does this vehicle have a window ID?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool WindowID
    {
      get { return m_windowID; }
      set { m_windowID = value; }
    }

    /// <summary>
    /// Zip code in which this vehicle is located. This is
    /// the rated zip code.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ZipCode
    {
      get { return m_zipCode; }
      set { m_zipCode = value; }
    }

    /// <summary>
    /// Underinsured motorist PD Deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UIMPDDed
    {
      get { return m_UIMPDDed; }
      set { m_UIMPDDed = value; }
    }

    /// <summary>
    /// Company assigned underinsured motorist PD Deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoUIMPDDed
    {
      get { return m_coUIMPDDed; }
      set { m_coUIMPDDed = value; }
    }

    /// <summary>
    /// Personal injury protection limit 2
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PIPLimit2
    {
      get { return m_pipLimit2; }
      set { m_pipLimit2 = value; }
    }

    /// <summary>
    /// Company-assigned PIP limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoPIPLimit2
    {
      get { return m_coPIPLimit2; }
      set { m_coPIPLimit2 = value; }
    }

    /// <summary>
    /// is tort coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Tort
    {
      get { return m_tort; }
      set { m_tort = value; }
    }

    /// <summary>
    /// Tort premium.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public double TortPremium
    {
      get { return m_tortPremium; }
      set { m_tortPremium = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int TortLimit
    {
      get { return m_tortLimit; }
      set { m_tortLimit = value; }
    }

    /// <summary>
    /// Company assigned tort limit.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoTortLimit
    {
      get { return m_coTortLimit; }
      set { m_coTortLimit = value; }
    }

    /// <summary>
    /// Collision waiver.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CollWaiver
    {
      get { return m_collWaiver; }
      set { m_collWaiver = value; }
    }



    /// <summary>
    /// Death benefit premium associated with PIP.
    /// PIP is required on all FL policies by law.  A $5000 death benefit is a required part of
    /// PIP coverage in that state.  As of Jan 1, 2013 FL companies are allowed to charge an extra
    /// premium for the death benefit.  Possible scenarios:
    /// 1. The company charges a separate premium for the death benefit (Gainsco)
    /// 2. The company offers death benefit coverages, but does not charge a separate premium for it (Progressive, AIPSO)
    /// 3. The company does not provide coverage for the death benefit (United Auto)          
    /// Account for it here and add it to the PIP premium since it 
    /// won't be displayed as a separate line item in the interface.  There currently is no
    /// ACORD code for this coverage.
    /// 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PIPDeathBenefitPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_pipDeathBenefitPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_pipDeathBenefitPremium = value;
        }
        else
          m_pipDeathBenefitPremium = value;
      }
    }

    /// <summary>
    /// This function removes included premium and blank limit constants
    /// from the calculation of subtotal premium. 
    /// </summary>
    protected double CheckForIncludedPremium(double covgPremium)
    {
      if ((covgPremium < 2000000000) && (covgPremium > -2000000000))
        return covgPremium;
      return 0;
    }

    /// <summary>
    /// Subtotal premium for the vehicle. This is a calculated
    /// read-only value that is the sum of the individual vehicle
    /// premiums. If you add any more premiums, be sure to add those
    /// premiums to this subtotal.
    /// 10/3/14 - Does not add PIP death benefit premium to the 
    /// total.  It should already be added to the PIP premium.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double SubTotalPremium
    {
      get
      {
        return (CheckForIncludedPremium(LiabBIPremium) +
          CheckForIncludedPremium(LiabPDPremium) +
          CheckForIncludedPremium(CollPremium) +
          CheckForIncludedPremium(CompPremium) +
          CheckForIncludedPremium(UIMBIPremium) +
          CheckForIncludedPremium(UIMPDPremium) +
          CheckForIncludedPremium(UninsBIPremium) +
          CheckForIncludedPremium(UninsPDPremium) +
          CheckForIncludedPremium(PIPPremium) +
          CheckForIncludedPremium(MedPayPremium) +
          CheckForIncludedPremium(RentalPremium) +
          CheckForIncludedPremium(TowingPremium) +
          CheckForIncludedPremium(AccDeathPremium) +
          CheckForIncludedPremium(IncomeLossPremium) +
          CheckForIncludedPremium(CustomEquipPremium) +
          CheckForIncludedPremium(MexicoPremium) +
          CheckForIncludedPremium(AddtlPIPPremium) +
          CheckForIncludedPremium(OutStatePIPPremium) +
          CheckForIncludedPremium(CombineBenPremium) +
          CheckForIncludedPremium(ExtraMedPremium) +
          CheckForIncludedPremium(FuneralPremium) +
          CheckForIncludedPremium(LimitedLiabPDPremium) +
          CheckForIncludedPremium(LoanLeasePremium) +
          CheckForIncludedPremium(OBELPremium) +
          CheckForIncludedPremium(PPIPremium) +
          CheckForIncludedPremium(SUMPremium) +
          CheckForIncludedPremium(LienHolderPremium) +
          CheckForIncludedPremium(GapPremium) +
          CheckForIncludedPremium(FullGlassPremium) +
          CheckForIncludedPremium(TripInterruptionPremium) +
          CheckForIncludedPremium(ReplacementCostPremium) +
          CheckForIncludedPremium(TransportTrailerPremium) +
          CheckForIncludedPremium(TortPremium) +
          CheckForIncludedPremium(LegalExpensePremium) +
          CheckForIncludedPremium(PipAttendantCareOptionPremium)
          );
      }
    }

    /// <summary>
    /// Part 1 of liab BI limits
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int LiabLimits1
    {
      get { return m_liabLimits1; }
      set { m_liabLimits1 = value; }
    }

    /// <summary>
    /// Part 2 of liab BI limits
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int LiabLimits2
    {
      get { return m_liabLimits2; }
      set { m_liabLimits2 = value; }
    }

    /// <summary>
    /// Part 3 of liab limits (the liab PD limit)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int LiabLimits3
    {
      get { return m_liabLimits3; }
      set { m_liabLimits3 = value; }
    }

    /// <summary>
    /// company-assigned part 1 of liab BI limits
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoLiabLimits1
    {
      get { return m_coLiabLimits1; }
      set { m_coLiabLimits1 = value; }
    }

    /// <summary>
    /// Company-assigned Part 2 of liab BI limits
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoLiabLimits2
    {
      get { return m_coLiabLimits2; }
      set { m_coLiabLimits2 = value; }
    }

    /// <summary>
    /// Company-assigned Part 3 of liab limits (the liab PD limit)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoLiabLimits3
    {
      get { return m_coLiabLimits3; }
      set { m_coLiabLimits3 = value; }
    }

    /// <summary>
    /// Company-assigned collision deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoCollDed
    {
      get { return m_coCollDed; }
      set { m_coCollDed = value; }
    }

    /// <summary>
    /// Company-assigned comprehensive deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoCompDed
    {
      get { return m_coCompDed; }
      set { m_coCompDed = value; }
    }

    /// <summary>
    /// Company-assigned custom equipment value
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoCustomEquipValue
    {
      get { return m_coCustomEquipValue; }
      set { m_coCustomEquipValue = value; }
    }

    /// <summary>
    /// company-assigned PIP limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoPIPLimit
    {
      get { return m_coPIPLimit; }
      set { m_coPIPLimit = value; }
    }

    /// <summary>
    /// Company-assigned Med Pay limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoMedPayLimit
    {
      get { return m_coMedPayLimit; }
      set { m_coMedPayLimit = value; }
    }

    /// <summary>
    /// Company-assigned part 1 of underinsured motorists
    /// bi limits
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoUIMBILimits1
    {
      get { return m_coUIMBILimits1; }
      set { m_coUIMBILimits1 = value; }
    }

    /// <summary>
    /// Company-assigned part 2 of underinsured motorists
    /// bi limits
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoUIMBILimits2
    {
      get { return m_coUIMBILimits2; }
      set { m_coUIMBILimits2 = value; }
    }

    /// <summary>
    /// Company-assigned towing limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoTowingLimit
    {
      get { return m_coTowingLimit; }
      set { m_coTowingLimit = value; }
    }

    /// <summary>
    /// Company-assigned underinsured motorists physical
    /// damage limit.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoUIMPDLimit
    {
      get { return m_coUIMPDLimit; }
      set { m_coUIMPDLimit = value; }
    }

    /// <summary>
    /// Company-assigned part 1 of uninsured motorists bi limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoUninsBILimits1
    {
      get { return m_coUninsBILimits1; }
      set { m_coUninsBILimits1 = value; }
    }

    /// <summary>
    /// Company-assigned part 2 of uninsured motorists bi limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoUninsBILimits2
    {
      get { return m_coUninsBILimits2; }
      set { m_coUninsBILimits2 = value; }
    }

    /// <summary>
    /// Company-assigned uninsured motorists physical damage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoUninsPDLimit
    {
      get { return m_coUninsPDLimit; }
      set { m_coUninsPDLimit = value; }
    }

    /// <summary>
    /// Company-assigned rental limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoRentalLimit
    {
      get { return m_coRentalLimit; }
      set { m_coRentalLimit = value; }
    }

    /// <summary>
    /// Uninsured motorists physical damage coverage deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UninsPDDed
    {
      get { return m_uninsPDDed; }
      set { m_uninsPDDed = value; }
    }

    /// <summary>
    /// Company-assigned Uninsured motorists physical 
    /// damage coverage deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoUninsPDDed
    {
      get { return m_coUninsPDDed; }
      set { m_coUninsPDDed = value; }
    }

    /// <summary>
    /// Part 1 of Uninsured motorists bodily injury coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UninsBILimits1
    {
      get { return m_uninsBILimits1; }
      set { m_uninsBILimits1 = value; }
    }

    /// <summary>
    /// Part 2 of Uninsured motorists bodily injury coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UninsBILimits2
    {
      get { return m_uninsBILimits2; }
      set { m_uninsBILimits2 = value; }
    }

    /// <summary>
    /// Is this vehicle a conversion van?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ConversionVan
    {
      get { return m_conversionVan; }
      set { m_conversionVan = value; }
    }

    /// <summary>
    /// Is this vehicle garaged?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Garaged
    {
      get { return m_garaged; }
      set { m_garaged = value; }
    }

    /// <summary>
    /// The garaging zip of the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string GaragingZipCode
    {
      get { return m_garagingZipCode; }
      set { m_garagingZipCode = value; }
    }

    /// <summary>
    /// The vehicle's garaging city
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.CityLength)]
    public virtual string GaragingCity
    {
      get { return m_garagingCity; }
      set { m_garagingCity = value; }
    }

    /// <summary>
    /// The vehicle's garaging address 1
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 100)]
    public virtual string GaragingAddr1
    {
      get { return m_garagingAddr1; }
      set { m_garagingAddr1 = value; }
    }

    /// <summary>
    /// The vehicle's garaging address 2
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 100)]
    public virtual string GaragingAddr2
    {
      get { return m_garagingAddr2; }
      set { m_garagingAddr2 = value; }
    }

    /// <summary>
    /// The vehicle's garaging state
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(USState))]
    public virtual USState GaragingState
    {
      get { return m_garagingState; }
      set { m_garagingState = value; }
    }

    /// <summary>
    /// The purchase type of the vehicle
    /// </summary>
    /// <seealso cref="PurchaseType">PurchaseType</seealso>
    /// <seealso cref="AUConstants.PurchaseTypeNames">AUConstants.PurchaseTypeNames</seealso>
    /// <seealso cref="AUConstants.PurchaseTypeChars">AUConstants.PurchaseTypeChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string PurchaseType
    {
      get { return m_purchaseType; }
      set { m_purchaseType = value; }
    }

    /// <summary>
    /// Is this vehicle leased?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LeasedVehicle
    {
      get { return m_leasedVehicle; }
      set { m_leasedVehicle = value; }
    }

    /// <summary>
    /// Vehicle's license plate#
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 256, IsEncrypted = true)]
    public virtual string LicensePlateNumber
    {
      get { return m_licensePlateNumber; }
      set { m_licensePlateNumber = value; }
    }

    /// <summary>
    /// Date the owner purchased the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime PurchaseDate
    {
      get { return m_purchaseDate; }
      set { m_purchaseDate = value; }
    }

    /// <summary>
    /// Has this vehicle been inspected by the agent?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Inspected
    {
      get { return m_inspected; }
      set { m_inspected = value; }
    }

    /// <summary>
    /// Is this vehicle being rated by the stated amount, instead
    /// of by symbol?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool RatedStatedAmount
    {
      get { return m_ratedStatedAmount; }
      set { m_ratedStatedAmount = value; }
    }

    /// <summary>
    /// Type of collision coverage on the vehicle
    /// </summary>
    /// <seealso cref="MICollType">MICollType</seealso>
    /// <seealso cref="AUConstants.MICollTypeNames">AUConstants.MICollTypeNames</seealso>
    /// <seealso cref="AUConstants.MICollTypeChars">AUConstants.MICollTypeChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string CollType
    {
      get { return m_collType; }
      set { m_collType = value; }
    }

    /// <summary>
    /// Company-assigned Type of collision coverage on the vehicle
    /// </summary>
    /// <seealso cref="MICollType">MICollType</seealso>
    /// <seealso cref="AUConstants.MICollTypeNames">AUConstants.MICollTypeNames</seealso>
    /// <seealso cref="AUConstants.MICollTypeChars">AUConstants.MICollTypeChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string CoCollType
    {
      get { return m_coCollType; }
      set { m_coCollType = value; }
    }

    /// <summary>
    /// PIP deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PIPDed
    {
      get { return m_pIPDed; }
      set { m_pIPDed = value; }
    }

    /// <summary>
    /// Company-assigned PIP deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoPIPDed
    {
      get { return m_coPIPDed; }
      set { m_coPIPDed = value; }
    }

    /// <summary>
    /// Type of PIP coverage. This is not applicable in most
    /// states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string PIPType
    {
      get { return m_pIPType; }
      set { m_pIPType = value; }
    }

    /// <summary>
    /// Company-assigned Type of PIP coverage. This is not 
    /// applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string CoPIPType
    {
      get { return m_coPIPType; }
      set { m_coPIPType = value; }
    }

    /// <summary>
    /// Is the PIP coverage stacked PIP?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool StackedPIP
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_stackedPIP;
      }
      set { m_stackedPIP = value; }
    }

    /// <summary>
    /// Company-assigned: Is the PIP coverage stacked PIP?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoStackedPIP
    {
      get { return m_coStackedPIP; }
      set { m_coStackedPIP = value; }
    }

    /// <summary>
    /// Is the pip coverage guest PIP?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool GuestPIP
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_guestPIP;
      }
      set { m_guestPIP = value; }
    }

    /// <summary>
    /// Is the pip coverage military pip?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool MilitaryPIP
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_militaryPIP;
      }
      set { m_militaryPIP = value; }
    }

    /// <summary>
    /// Is there a co-pay on the PIP coverage?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PIPCoPay
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_pIPCoPay;
      }
      set { m_pIPCoPay = value; }
    }

    /// <summary>
    /// PIP co-pay percent
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PIPCoPayPercent
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return ITCConstants.InvalidNum;
        }
        return m_pIPCoPayPercent;
      }
      set { m_pIPCoPayPercent = value; }
    }

    /// <summary>
    /// Is the PIP PPO?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PIPPPO
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_pIPPPO;
      }
      set { m_pIPPPO = value; }
    }

    /// <summary>
    /// Is the PIP buy-back PIP?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool BuyBackPIP
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_buyBackPIP;
      }
      set { m_buyBackPIP = value; }
    }

    /// <summary>
    /// Is the PIP waived PIP?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool WaivedPIP
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_waivedPIP;
      }
      set { m_waivedPIP = value; }
    }

    /// <summary>
    /// Is Full Additional PIP coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FullAddtlPIP
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_fullAddtlPIP;
      }
      set { m_fullAddtlPIP = value; }
    }

    /// <summary>
    /// Additional PIP premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double AddtlPIPPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_addtlPIPPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_addtlPIPPremium = value;
        }
        else
          m_addtlPIPPremium = value;
      }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int AddtlPIPLimit1
    {
      get { return m_addtlPIPLimit1; }
      set { m_addtlPIPLimit1 = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int CoAddtlPIPLimit1
    {
      get { return m_coAddtlPIPLimit1; }
      set { m_coAddtlPIPLimit1 = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int AddtlPIPLimit2
    {
      get { return m_addtlPIPLimit2; }
      set { m_addtlPIPLimit2 = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int CoAddtlPIPLimit2
    {
      get { return m_coAddtlPIPLimit2; }
      set { m_coAddtlPIPLimit2 = value; }
    }

    /// <summary>
    /// Limited collision flag.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool LimitedColl
    {
      get { return m_limitedColl; }
      set { m_limitedColl = value; }
    }

    /// <summary>
    /// Limited collision deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int LimitedCollDed
    {
      get { return m_limitedCollDed; }
      set { m_limitedCollDed = value; }
    }

    /// <summary>
    /// Company assigned limited collision deductible.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int CoLimitedCollDed
    {
      get { return m_coLimitedCollDed; }
      set { m_coLimitedCollDed = value; }
    }

    /// <summary>
    /// Is out of state PIP coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool OutStatePIP
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_outStatePIP;
      }
      set { m_outStatePIP = value; }
    }

    /// <summary>
    /// Out of state PIP premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double OutStatePIPPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_outStatePIPPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_outStatePIPPremium = value;
        }
        else
          m_outStatePIPPremium = value;
      }
    }

    /// <summary>
    /// Is accidental death coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool AccDeath
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_accDeath;
      }
      set { m_accDeath = value; }
    }

    /// <summary>
    /// Accidental death coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int AccDeathLimit
    {
      get { return m_accDeathLimit; }
      set { m_accDeathLimit = value; }
    }

    /// <summary>
    /// Company-assigned Accidental death coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoAccDeathLimit
    {
      get { return m_coAccDeathLimit; }
      set { m_coAccDeathLimit = value; }
    }

    /// <summary>
    /// Accidental death coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double AccDeathPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_accDeathPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_accDeathPremium = value;
        }
        else
          m_accDeathPremium = value;
      }
    }

    /// <summary>
    /// Is combined benefits coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CombineBen
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_combineBen;
      }
      set { m_combineBen = value; }
    }

    /// <summary>
    /// Combined benefits coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CombineBenLimit
    {
      get { return m_combineBenLimit; }
      set { m_combineBenLimit = value; }
    }

    /// <summary>
    /// Company-assigned Combined benefits coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoCombineBenLimit
    {
      get { return m_coCombineBenLimit; }
      set { m_coCombineBenLimit = value; }
    }

    /// <summary>
    /// Combined benefits coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double CombineBenPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_combineBenPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_combineBenPremium = value;
        }
        else
          m_combineBenPremium = value;
      }
    }

    /// <summary>
    /// Does the vehicle have full glass coverage?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FullGlass
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_fullGlass;
      }
      set { m_fullGlass = value; }
    }

    /// <summary>
    /// Company-assigned Does the vehicle have full glass coverage?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoFullGlass
    {
      get { return m_coFullGlass; }
      set { m_coFullGlass = value; }
    }

    /// <summary>
    /// Premium charge for Full/Safety Glass
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double FullGlassPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_fullGlassPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_fullGlassPremium = value;
        }
        else
          m_fullGlassPremium = value;
      }
    }

    /// <summary>
    /// Is extra medical coverage turned on for the vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ExtraMed
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_extraMed;
      }
      set { m_extraMed = value; }
    }

    /// <summary>
    /// Extra medical coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ExtraMedLimit
    {
      get { return m_extraMedLimit; }
      set { m_extraMedLimit = value; }
    }

    /// <summary>
    /// Company-assigned Extra medical coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoExtraMedLimit
    {
      get { return m_coExtraMedLimit; }
      set { m_coExtraMedLimit = value; }
    }

    /// <summary>
    /// Extra medical coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double ExtraMedPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_extraMedPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_extraMedPremium = value;
        }
        else
          m_extraMedPremium = value;
      }
    }

    /// <summary>
    /// Is funeral coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Funeral
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_funeral;
      }
      set { m_funeral = value; }
    }

    /// <summary>
    /// Funeral coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int FuneralLimit
    {
      get { return m_funeralLimit; }
      set { m_funeralLimit = value; }
    }

    /// <summary>
    /// Company-assigned Funeral coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoFuneralLimit
    {
      get { return m_coFuneralLimit; }
      set { m_coFuneralLimit = value; }
    }

    /// <summary>
    /// Funeral coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double FuneralPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_funeralPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_funeralPremium = value;
        }
        else
          m_funeralPremium = value;
      }
    }

    /// <summary>
    /// Is income loss coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool IncomeLoss
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_incomeLoss;
      }
      set { m_incomeLoss = value; }
    }

    /// <summary>
    /// Income loss coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int IncomeLossLimit
    {
      get { return m_incomeLossLimit; }
      set { m_incomeLossLimit = value; }
    }

    /// <summary>
    /// Income loss coverage limit2
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int IncomeLossLimit2
    {
      get { return m_incomeLossLimit2; }
      set { m_incomeLossLimit2 = value; }
    }

    /// <summary>
    /// Company-assigned Income loss coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoIncomeLossLimit
    {
      get { return m_coIncomeLossLimit; }
      set { m_coIncomeLossLimit = value; }
    }

    /// <summary>
    /// Company-assigned Income loss coverage limit2
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoIncomeLossLimit2
    {
      get { return m_coIncomeLossLimit2; }
      set { m_coIncomeLossLimit2 = value; }
    }

    /// <summary>
    /// Income loss coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double IncomeLossPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_incomeLossPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_incomeLossPremium = value;
        }
        else
          m_incomeLossPremium = value;
      }
    }

    /// <summary>
    /// Is limited liability PD coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LimitedLiabPD
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_limitedLiabPD;
      }
      set { m_limitedLiabPD = value; }
    }

    /// <summary>
    /// Limited liability PD limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int LimitedLiabPDLimit
    {
      get { return m_limitedLiabPDLimit; }
      set { m_limitedLiabPDLimit = value; }
    }

    /// <summary>
    /// Company-assigned Limited liability PD limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoLimitedLiabPDLimit
    {
      get { return m_coLimitedLiabPDLimit; }
      set { m_coLimitedLiabPDLimit = value; }
    }

    /// <summary>
    /// Limited liability PD premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double LimitedLiabPDPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_limitedLiabPDPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_limitedLiabPDPremium = value;
        }
        else
          m_limitedLiabPDPremium = value;
      }
    }

    /// <summary>
    /// Is loan-lease coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LoanLease
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_loanLease;
      }
      set { m_loanLease = value; }
    }

    /// <summary>
    /// Company-assigned Is loan-lease coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoLoanLease
    {
      get { return m_coLoanLease; }
      set { m_coLoanLease = value; }
    }

    /// <summary>
    /// Loan lease coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double LoanLeasePremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_loanLeasePremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_loanLeasePremium = value;
        }
        else
          m_loanLeasePremium = value;
      }
    }

    /// <summary>
    /// the level of medical expense coverage on the vehicle.
    /// </summary>
    /// <seealso cref="MedicalExpenseLevel">MedicalExpenseLevel</seealso>
    /// <seealso cref="AUConstants.MedicalExpenseLevelNames">AUConstants.MedicalExpenseLevelNames</seealso>
    /// <seealso cref="AUConstants.MedicalExpenseLevelChars">AUConstants.MedicalExpenseLevelChars</seealso>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string MedExpense
    {
      get { return m_medExpense; }
      set { m_medExpense = value; }
    }

    /// <summary>
    /// Medical payments coverage deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MedPayDed
    {
      get { return m_medPayDed; }
      set { m_medPayDed = value; }
    }

    /// <summary>
    /// Company-assigned Medical payments coverage deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoMedPayDed
    {
      get { return m_coMedPayDed; }
      set { m_coMedPayDed = value; }
    }

    /// <summary>
    /// Is Optional Benefits Life coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool OBEL
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_oBEL;
      }
      set { m_oBEL = value; }
    }

    /// <summary>
    /// Optional Benefits life coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int OBELLimit
    {
      get { return m_oBELLimit; }
      set { m_oBELLimit = value; }
    }

    /// <summary>
    /// Company-assigned Optional Benefits life coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoOBELLimit
    {
      get { return m_coOBELLimit; }
      set { m_coOBELLimit = value; }
    }

    /// <summary>
    /// Optional Benefits life coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double OBELPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_oBELPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_oBELPremium = value;
        }
        else
          m_oBELPremium = value;
      }
    }

    /// <summary>
    /// Is PPI coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PPI
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_pPI;
      }
      set { m_pPI = value; }
    }

    /// <summary>
    /// PPI coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PPILimit
    {
      get { return m_pPILimit; }
      set { m_pPILimit = value; }
    }

    /// <summary>
    /// Company-assigned PPI coverage limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoPPILimit
    {
      get { return m_coPPILimit; }
      set { m_coPPILimit = value; }
    }

    /// <summary>
    /// PPI coverage premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PPIPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_pPIPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_pPIPremium = value;
        }
        else
          m_pPIPremium = value;
      }
    }

    /// <summary>
    /// Is stacked uninsured motorists coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool StackedUM
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_stackedUM;
      }
      set { m_stackedUM = value; }
    }

    /// <summary>
    /// Company-assigned Is stacked uninsured motorists 
    /// coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoStackedUM
    {
      get { return m_coStackedUM; }
      set { m_coStackedUM = value; }
    }

    /// <summary>
    /// Is Uninsured motorists conversion coverage turned on
    /// for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool UMConversion
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_uMConversion;
      }
      set { m_uMConversion = value; }
    }

    /// <summary>
    /// Company assigned-Is Uninsured motorists conversion 
    /// coverage turned on for this vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoUMConversion
    {
      get { return m_coUMConversion; }
      set { m_coUMConversion = value; }
    }

    /// <summary>
    /// Is the UIM stacked?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool StackedUIM
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_stackedUIM;
      }
      set { m_stackedUIM = value; }
    }

    /// <summary>
    /// Company-assigned Is the UIM stacked?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoStackedUIM
    {
      get { return m_coStackedUIM; }
      set { m_coStackedUIM = value; }
    }

    /// <summary>
    /// Is Supplemental uninsured motorists coverage turned on
    /// for the vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SUM
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_sUM;
      }
      set { m_sUM = value; }
    }

    /// <summary>
    /// Supplemental unisnured motorists limit 1
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int SUMLimits1
    {
      get { return m_sUMLimits1; }
      set { m_sUMLimits1 = value; }
    }

    /// <summary>
    /// Supplemental unisnured motorists limit 2
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int SUMLimits2
    {
      get { return m_sUMLimits2; }
      set { m_sUMLimits2 = value; }
    }

    /// <summary>
    /// Company-assigned Supplemental unisnured motorists limit 1
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoSUMLimits1
    {
      get { return m_coSUMLimits1; }
      set { m_coSUMLimits1 = value; }
    }

    /// <summary>
    /// Company-assigned Supplemental unisnured motorists limit 2
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoSUMLimits2
    {
      get { return m_coSUMLimits2; }
      set { m_coSUMLimits2 = value; }
    }

    /// <summary>
    /// Supplemental unisnured motorists premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double SUMPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return 0.0;
        }
        return m_sUMPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PALiabilityRestricted)
            m_sUMPremium = value;
        }
        else
          m_sUMPremium = value;
      }
    }

    /// <summary>
    /// Does this vehicle have work loss coverage?
    /// Use this property if work loss can be handled
    /// by a boolean and/or can be sent as a separate
    /// XML aggregate.  Use PIP work loss rejection when 
    /// a boolean cannot be used or when work loss needs to
    /// be sent as an option under the PIP aggregate.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool WorkLoss
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_workLoss;
      }
      set { m_workLoss = value; }
    }

    /// <summary>
    /// The allocation fee on the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double AllocationFee
    {
      get { return m_allocationFee; }
      set { m_allocationFee = value; }
    }

    /// <summary>
    /// Does the vehicle have a car phone?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CarPhone
    {
      get { return m_carPhone; }
      set { m_carPhone = value; }
    }

    /// <summary>
    /// /recoupment fee on the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double RecoupmentFee
    {
      get { return m_recoupmentFee; }
      set { m_recoupmentFee = value; }
    }

    /// <summary>
    /// Underinsured motorists bodily injury coverage limit 1
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UIMBILimits1
    {
      get { return m_UIMBILimits1; }
      set { m_UIMBILimits1 = value; }
    }

    /// <summary>
    /// Underinsured motorists bodily injury coverage limit 2
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UIMBILimits2
    {
      get { return m_UIMBILimits2; }
      set { m_UIMBILimits2 = value; }
    }

    /// <summary>
    /// The company-specific rated car tier
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 30)]
    public virtual string CoCarTierStr
    {
      get { return m_coCarTierStr; }
      set { m_coCarTierStr = value; }
    }

    /// <summary>
    /// The company-specific lienholder collision deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoLienHolderCollDed
    {
      get { return m_coLienHolderCollDed; }
      set { m_coLienHolderCollDed = value; }
    }

    /// <summary>
    /// The company-specific lienholder comprehensive coverage deductible
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoLienHolderCompDed
    {
      get { return m_coLienHolderCompDed; }
      set { m_coLienHolderCompDed = value; }
    }

    /// <summary>
    /// The company-specific lienholder coverage deductible, yes/no
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoLienHolderDed
    {
      get { return m_coLienHolderDed; }
      set { m_coLienHolderDed = value; }
    }

    /// <summary>
    /// The color of the car's exterior
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string Color
    {
      get { return m_color; }
      set { m_color = value; }
    }

    /// <summary>
    /// Does co-pip apply for the selected company?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoPIPCoPay
    {
      get { return m_coPIPCoPay; }
      set { m_coPIPCoPay = value; }
    }

    /// <summary>
    /// Company specific PIP Co-pay percentage
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoPIPCoPayPercent
    {
      get { return m_coPIPCoPayPercent; }
      set { m_coPIPCoPayPercent = value; }
    }

    /// <summary>
    /// Does co-pip PPO coverage apply for the selected company?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoPIPPPO
    {
      get { return m_coPIPPPO; }
      set { m_coPIPPPO = value; }
    }

    /// <summary>
    /// Does work loss coverage apply for the selected company?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoWorkLoss
    {
      get { return m_coWorkLoss; }
      set { m_coWorkLoss = value; }
    }

    /// <summary>
    /// Is this car a foreign-manufactured vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ForeignCar
    {
      get { return m_foreignCar; }
      set { m_foreignCar = value; }
    }

    /// <summary>
    /// Is this a gray market car? 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool GrayMarket
    {
      get { return m_grayMarket; }
      set { m_grayMarket = value; }
    }

    /// <summary>
    /// Does this vehicle have guardian interlock?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool GuardianInterlock
    {
      get { return m_guardianInterlock; }
      set { m_guardianInterlock = value; }
    }

    /// <summary>
    /// Address part 1 of the first lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.SmallAddressLength)]
    public virtual string LienHolderAddress1
    {
      get { return m_lienHolderAddress1; }
      set { m_lienHolderAddress1 = value; }
    }

    /// <summary>
    /// Address part 1 of the second lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.SmallAddressLength)]
    public virtual string LienHolderAddress12
    {
      get { return m_lienHolderAddress12; }
      set { m_lienHolderAddress12 = value; }
    }

    /// <summary>
    /// Address part 2 of the first lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.SmallAddressLength)]
    public virtual string LienHolderAddress2
    {
      get { return m_lienHolderAddress2; }
      set { m_lienHolderAddress2 = value; }
    }

    /// <summary>
    /// Address part 2 of the second lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.SmallAddressLength)]
    public virtual string LienHolderAddress22
    {
      get { return m_lienHolderAddress22; }
      set { m_lienHolderAddress22 = value; }
    }

    /// <summary>
    /// City of the first lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.CityLength)]
    public virtual string LienHolderCity
    {
      get { return m_lienHolderCity; }
      set { m_lienHolderCity = value; }
    }

    /// <summary>
    /// City of the second lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.CityLength)]
    public virtual string LienHolderCity2
    {
      get { return m_lienHolderCity2; }
      set { m_lienHolderCity2 = value; }
    }

    /// <summary>
    /// Collision deductible for the lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int LienHolderCollDed
    {
      get { return m_lienHolderCollDed; }
      set { m_lienHolderCollDed = value; }
    }

    /// <summary>
    /// Comprehensive deductible for the lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int LienHolderCompDed
    {
      get { return m_lienHolderCompDed; }
      set { m_lienHolderCompDed = value; }
    }

    /// <summary>
    /// Deductible yes/no for the lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LienHolderDed
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_lienHolderDed;
      }
      set { m_lienHolderDed = value; }
    }

    /// <summary>
    /// The fax# for the vehicle's first lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string LienHolderFaxNum
    {
      get { return m_lienHolderFaxNum; }
      set { m_lienHolderFaxNum = value; }
    }

    /// <summary>
    /// The fax# for the vehicle's second lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string LienHolderFaxNum2
    {
      get { return m_lienHolderFaxNum2; }
      set { m_lienHolderFaxNum2 = value; }
    }

    /// <summary>
    /// The id# for the first lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string LienHolderID
    {
      get { return m_lienHolderID; }
      set { m_lienHolderID = value; }
    }

    /// <summary>
    /// The id# for the second lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string LienHolderID2
    {
      get { return m_lienHolderID2; }
      set { m_lienHolderID2 = value; }
    }

    /// <summary>
    /// The name of the first lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 35)]
    public virtual string LienHolderName
    {
      get { return m_lienHolderName; }
      set { m_lienHolderName = value; }
    }

    /// <summary>
    /// The name of the second lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 35)]
    public virtual string LienHolderName2
    {
      get { return m_lienHolderName2; }
      set { m_lienHolderName2 = value; }
    }

    /// <summary>
    /// The phone# of the first lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string LienHolderPhone
    {
      get { return m_lienHolderPhone; }
      set { m_lienHolderPhone = value; }
    }

    /// <summary>
    /// The phone# of the second lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string LienHolderPhone2
    {
      get { return m_lienHolderPhone2; }
      set { m_lienHolderPhone2 = value; }
    }

    /// <summary>
    /// The premium charged for the lienholder
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double LienHolderPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_lienHolderPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_lienHolderPremium = value;
        }
        else
          m_lienHolderPremium = value;
      }
    }

    /// <summary>
    /// The first lienholder's state
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = StorageConstants.StateLength, EnumerationType = typeof(USState))]
    public virtual USState LienHolderState
    {
      get { return m_lienHolderState; }
      set { m_lienHolderState = value; }
    }

    /// <summary>
    /// The second lienholder's state
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = StorageConstants.StateLength, EnumerationType = typeof(USState))]
    public virtual USState LienHolderState2
    {
      get { return m_lienHolderState2; }
      set { m_lienHolderState2 = value; }
    }

    /// <summary>
    /// The first lienholder's type (lease, loan, none, etc)
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 1, EnumerationType = typeof(LienHolderType),
       EnumerationConstHolderType = typeof(AUConstants), EnumerationValues = "LienHolderTypeChars")]
    public virtual LienHolderType LienHolderType
    {
      get { return m_lienHolderType; }
      set { m_lienHolderType = value; }
    }

    /// <summary>
    /// The 2nd lienholder's type (lease, loan, none, etc)
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 1, EnumerationType = typeof(LienHolderType),
       EnumerationConstHolderType = typeof(AUConstants), EnumerationValues = "LienHolderTypeChars")]
    public virtual LienHolderType LienHolderType2
    {
      get { return m_lienHolderType2; }
      set { m_lienHolderType2 = value; }
    }

    /// <summary>
    /// The first lienholder's zip code
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string LienHolderZip
    {
      get { return m_lienHolderZip; }
      set { m_lienHolderZip = value; }
    }

    /// <summary>
    /// The 2nd lienholder's zip code
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string LienHolderZip2
    {
      get { return m_lienHolderZip2; }
      set { m_lienHolderZip2 = value; }
    }

    /// <summary>
    /// The first lienholder's vehicle loan #
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string LoanNum
    {
      get { return m_loanNum; }
      set { m_loanNum = value; }
    }

    /// <summary>
    /// The 2nd lienholder's vehicle loan #
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string LoanNum2
    {
      get { return m_loanNum2; }
      set { m_loanNum2 = value; }
    }

    /// <summary>
    /// Is medicare coverage on the car?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Medicare
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PALiabilityRestricted)
            return false;
        }
        return m_medicare;
      }
      set { m_medicare = value; }
    }

    /// <summary>
    /// Does the vehicle have outsized tires? 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool OutsizedTires
    {
      get { return m_outsizedTires; }
      set { m_outsizedTires = value; }
    }

    /// <summary>
    /// The ID of the primary operator (driver of the vehicle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PrimaryOperatorID
    {
      get { return m_primaryOperatorID; }
      set { m_primaryOperatorID = value; }
    }

    /// <summary>
    /// The amount of money that the vehicle was purchased for
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PurchaseCost
    {
      get { return m_purchaseCost; }
      set { m_purchaseCost = value; }
    }

    /// <summary>
    /// Used by Winders to determine if the DB table needs restructuring
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool RestructureField
    {
      get { return m_restructureField; }
      set { m_restructureField = value; }
    }

    /// <summary>
    /// The secondary company-specific symbol for the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string SecondaryCoSym
    {
      get { return m_secondaryCoSym; }
      set { m_secondaryCoSym = value; }
    }

    /// <summary>
    /// The secondary company-specific territory for the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string SecondaryCoTerr
    {
      get { return m_secondaryCoTerr; }
      set { m_secondaryCoTerr = value; }
    }

    /// <summary>
    /// The secondary company-specific driver assigned to the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int SecondaryCoWhichDrv
    {
      get { return m_secondaryCoWhichDrv; }
      set { m_secondaryCoWhichDrv = value; }
    }

    /// <summary>
    /// The secondary company's points assigned to the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int SecondaryPoints
    {
      get { return m_secondaryPoints; }
      set { m_secondaryPoints = value; }
    }

    /// <summary>
    /// The mode of symbol rating (value, etc)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int SymRateMode
    {
      get { return m_symRateMode; }
      set { m_symRateMode = value; }
    }

    /// <summary>
    /// The territory in which this vehicle is rated
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string Territory
    {
      get { return m_territory; }
      set { m_territory = value; }
    }

    /// <summary>
    /// The iso liability symbol for the vehicle. includes liab and med/pip
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ISOLiabSymbol
    {
      get { return m_isoLiabSymbol; }
      set { m_isoLiabSymbol = value; }
    }

    /// <summary>
    /// The iso liability symbol for the vehicle, from 2008 ISO data
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ISOLiabSymbol2008
    {
      get { return m_isoLiabSymbol2008; }
      set { m_isoLiabSymbol2008 = value; }
    }

    /// <summary>
    /// The iso liability symbol for the vehicle, from 2010 ISO data
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ISOLiabSymbol2010
    {
      get { return m_isoLiabSymbol2010; }
      set { m_isoLiabSymbol2010 = value; }
    }

    /// <summary>
    /// The iso liability symbol for the vehicle, from 2012 ISO data
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ISOLiabSymbol2012
    {
      get { return m_isoLiabSymbol2012; }
      set { m_isoLiabSymbol2012 = value; }
    }

    /// <summary>
    /// The iso liability symbol for the vehicle, from 2014 ISO data
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ISOLiabSymbol2014
    {
      get { return m_isoLiabSymbol2014; }
      set { m_isoLiabSymbol2014 = value; }
    }

    /// <summary>
    /// Is gap coverage on the vehicle? 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool GapCoverage
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_gapCoverage;
      }
      set { m_gapCoverage = value; }
    }

    /// <summary>
    /// gap coverage premium for the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double GapPremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_gapPremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_gapPremium = value;
        }
        else
          m_gapPremium = value;
      }
    }

    /// <summary>
    /// reference to the parent policy that owns this object
    /// </summary>
    public virtual InsPolicy ParentPolicy
    {
      get { return m_parentPolicy; }
      set { m_parentPolicy = value; }
    }

    /// <summary>
    /// Points by coverage.
    /// </summary>
    public List<int> CoveragePoints
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCoveragePoints;
        else
          return m_coveragePoints;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCoveragePoints = value;
        else
          m_coveragePoints = value;
      }
    }

    /// <summary>
    /// Points by coverage for secondary company.
    /// </summary>
    public List<int> SecondaryCoveragePoints
    {
      get { return m_secondaryCoveragePoints; }
      set { m_secondaryCoveragePoints = value; }
    }

    /// <summary>
    /// Has this vehicle been salvaged?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool Salvaged
    {
      get { return m_salvaged; }
      set { m_salvaged = value; }
    }

    /// <summary>
    /// Is this vehicle licensed for road use?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool LicensedForRoadUse
    {
      get { return m_licensedForRoadUse; }
      set { m_licensedForRoadUse = value; }
    }

    /// <summary>
    /// Body type of this motorcycle pulled from POLK data.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 30, EnumerationType = typeof(MotorcycleBody))]
    public MotorcycleBody MotorcycleBodyType
    {
      get { return m_motorcycleBodyType; }
      set { m_motorcycleBodyType = value; }
    }

    /// <summary>
    /// Engine displacement for this vehicle.  (originally added for motorcycle so cubic centimeters)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int Displacement
    {
      get { return m_displacement; }
      set { m_displacement = value; }
    }

    /// <summary>
    /// Has this vehicle had any modifications made to it?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool Modifications
    {
      get { return m_modifications; }
      set { m_modifications = value; }
    }

    /// <summary>
    /// Has this vehicle's engine had any external changes?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool EngineChangesExternal
    {
      get { return m_engineChangesExternal; }
      set { m_engineChangesExternal = value; }
    }

    /// <summary>
    /// Has this vehicle's engine had any internal engine changes?  (replacement camshafts - originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool EngineChangesInternal
    {
      get { return m_engineChangesInternal; }
      set { m_engineChangesInternal = value; }
    }

    /// <summary>
    /// Has this vehicle's engine had any other internal engine changes?  (replacement/modified head(s) stroker kit including bored/stroked cylinder - originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool EngineChangesOtherInternal
    {
      get { return m_engineChangesOtherInternal; }
      set { m_engineChangesOtherInternal = value; }
    }

    /// <summary>
    /// How is this motorcycle used?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20, EnumerationType = typeof(MotorcycleVehicleUsage))]
    public MotorcycleVehicleUsage MotorcycleUsage
    {
      get { return m_motorcycleUsage; }
      set { m_motorcycleUsage = value; }
    }

    /// <summary>
    /// Is Trip Interruption coverage in effect?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool TripInterruption
    {
      get { return m_tripInterruption; }
      set { m_tripInterruption = value; }
    }

    /// <summary>
    /// The value of Trip Interruption coverage.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int TripInterruptionLimit
    {
      get { return m_tripInterruptionLimit; }
      set { m_tripInterruptionLimit = value; }
    }

    /// <summary>
    /// Trip Interruption Premium.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double TripInterruptionPremium
    {
      get { return m_tripInterruptionPremium; }
      set { m_tripInterruptionPremium = value; }
    }

    /// <summary>
    /// Company-assigned Trip Interruption Limit
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoTripInterruptionLimit
    {
      get { return m_coTripInterruptionLimit; }
      set { m_coTripInterruptionLimit = value; }
    }

    /// <summary>
    /// Is Replacement Cost coverage in effect?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ReplacementCost
    {
      get { return m_replacementCost; }
      set { m_replacementCost = value; }
    }

    /// <summary>
    /// Replacement cost coverage can be 
    /// toggled on or off by the company.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoReplacementCost
    {
      get { return m_coReplacementCost; }
      set { m_coReplacementCost = value; }
    }

    /// <summary>
    /// Replacement Cost Premium.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double ReplacementCostPremium
    {
      get { return m_replacementCostPremium; }
      set { m_replacementCostPremium = value; }
    }

    /// <summary>
    /// Is Trailer Coverage in effect?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool TransportTrailer
    {
      get { return m_transportTrailer; }
      set { m_transportTrailer = value; }
    }

    /// <summary>
    /// Trailer Premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double TransportTrailerPremium
    {
      get { return m_transportTrailerPremium; }
      set { m_transportTrailerPremium = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int TransportTrailerValue
    {
      get { return m_transportTrailerValue; }
      set { m_transportTrailerValue = value; }
    }

    /// <summary>
    /// Company-assigned trailer value
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoTransportTrailerValue
    {
      get { return m_coTransportTrailerValue; }
      set { m_coTransportTrailerValue = value; }
    }

    /// <summary>
    /// PIP Deductible Option, who this PIP Deductible Applies to.
    /// This is not applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public string PIPDedOption
    {
      get { return m_pIPDedOption; }
      set { m_pIPDedOption = value; }
    }

    /// <summary>
    /// Company-assigned PIP Deductible Option, who this PIP Deductible Applies to.
    /// This is not applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public string CoPIPDedOption
    {
      get { return m_coPIPDedOption; }
      set { m_coPIPDedOption = value; }
    }

    /// <summary>
    /// PIP Medical Deductible.
    /// This is not applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int PIPMedicalDed
    {
      get { return m_pIPMedicalDed; }
      set { m_pIPMedicalDed = value; }
    }

    /// <summary>
    /// Company-assigned PIP Medical Deductible.
    /// This is not applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int CoPIPMedicalDed
    {
      get { return m_coPIPMedicalDed; }
      set { m_coPIPMedicalDed = value; }
    }

    /// <summary>
    /// PIP Work Loss Deductible.
    /// This is not applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20, EnumerationType = typeof(PIPWorkLossDeductible))]
    public PIPWorkLossDeductible PIPWorkLossDed
    {
      get { return m_pIPWorkLossDed; }
      set { m_pIPWorkLossDed = value; }
    }

    /// <summary>
    /// Company-assigned PIP Work Loss Deductible.
    /// This is not applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20, EnumerationType = typeof(PIPWorkLossDeductible))]
    public PIPWorkLossDeductible CoPIPWorkLossDed
    {
      get { return m_coPIPWorkLossDed; }
      set { m_coPIPWorkLossDed = value; }
    }

    /// <summary>
    /// Denotes the type of Uninsured Motorist coverage
    /// This is not applicable in most states
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20, EnumerationType = typeof(UninsType))]
    public UninsType UninsType
    {
      get { return m_uninsType; }
      set { m_uninsType = value; }
    }

    /// <summary>
    /// Non-stored company symbol.
    /// </summary>
    public string Symbol
    {
      get { return m_symbol; }
      set { m_symbol = value; }
    }

    /// <summary>
    /// Non-stored company high risk symbol.
    /// </summary>
    public string HighRisk
    {
      get { return m_highRisk; }
      set { m_highRisk = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 10)]
    public string ISOBodyType
    {
      get { return m_isoBodyType; }
      set { m_isoBodyType = value; }
    }

    /// <summary>
    /// PIP work loss rejection. This property was added
    /// to handle the situation where the work loss
    /// coverage boolean cannot be used.  Use this property
    /// on states that require work loss rejection to
    /// be sent as an option under the PIP aggregate or on.
    /// states where work loss cannot be handled by a boolean.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 10)]
    public virtual string PIPWorkLossRejection
    {
      get { return m_pIPWorkLossRejection; }
      set { m_pIPWorkLossRejection = value; }
    }

    /// <summary>
    /// PIP work loss rejection. This property was added
    /// to handle the situation where the work loss
    /// coverage boolean cannot be used.  Use this property
    /// on states that require work loss rejection to
    /// be sent as an option under the PIP aggregate or on.
    /// states where work loss cannot be handled by a boolean.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 10)]
    public virtual string CoPIPWorkLossRejection
    {
      get { return m_coPIPWorkLossRejection; }
      set { m_coPIPWorkLossRejection = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool OptionalBI
    {
      get { return this.m_optionalBI; }
      set { this.m_optionalBI = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double OptionalBIPremium
    {
      get { return this.m_optionalBIPremium; }
      set { this.m_optionalBIPremium = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int OptionalBILimit1
    {
      get { return this.m_optionalBILimit1; }
      set { this.m_optionalBILimit1 = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int OptionalBILimit2
    {
      get { return this.m_optionalBILimit2; }
      set { this.m_optionalBILimit2 = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoOptionalBILimit1
    {
      get { return this.m_coOptionalBILimit1; }
      set { this.m_coOptionalBILimit1 = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoOptionalBILimit2
    {
      get { return this.m_coOptionalBILimit2; }
      set { this.m_coOptionalBILimit2 = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool TotalDisability
    {
      get { return this.m_totalDisability; }
      set { this.m_totalDisability = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int TotalDisabilityLimit
    {
      get { return this.m_totalDisabilityLimit; }
      set { this.m_totalDisabilityLimit = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20, EnumerationType = typeof(TotalDisabilityType))]
    public virtual TotalDisabilityType TotalDisabilityType
    {
      get { return this.m_totalDisabilityType; }
      set { this.m_totalDisabilityType = value; }
    }

    /// <summary>
    /// The RAPA liability symbol for the vehicle for all states except Georgia
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 10)]
    public virtual string RAPALiabilitySymbol
    {
      get { return this.m_rapaLiabilitySymbol; }
      set { this.m_rapaLiabilitySymbol = value; }
    }

    /// <summary>
    /// The RAPA liability symbol for the vehicle for Georgia
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 10)]
    public virtual string RAPAGALiabilitySymbol
    {
      get { return this.m_rapaGALiabilitySymbol; }
      set { this.m_rapaGALiabilitySymbol = value; }
    }

    /// <summary>
    /// The RAPA symbol for the vehicle for all states except Georgia
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 4)]
    public virtual string RAPASymbol
    {
      get { return this.m_rapaSymbol; }
      set { this.m_rapaSymbol = value; }
    }

    /// <summary>
    /// The RAPA symbol for the vehicle for Georgia
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 4)]
    public virtual string RAPAGASymbol
    {
      get { return this.m_rapaGASymbol; }
      set { this.m_rapaGASymbol = value; }
    }

    /// <summary>
    /// Legal expense coverage?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LegalExpense
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return false;
        }
        return m_legalExpense;
      }
      set { m_legalExpense = value; }
    }

    /// <summary>
    /// Premium charge for legal expense.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double LegalExpensePremium
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return 0.0;
        }
        return m_legalExpensePremium;
      }
      set
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode != ExclusionCodes.PAPDRestricted)
            m_legalExpensePremium = value;
        }
        else
          m_legalExpensePremium = value;
      }
    }

    /// <summary>
    /// The RAPA anti-lock indicator for the vehicle
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 4)]
    public virtual string RAPAAntiLockIndicator
    {
      get { return this.m_rapaAntiLockIndicator; }
      set { this.m_rapaAntiLockIndicator = value; }
    }

    /// <summary>
    /// The RAPA anti-lock indicator for the vehicle for Georgia
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 4)]
    public virtual string GRAPAAntiLockIndicator
    {
      get { return this.m_grapaAntiLockIndicator; }
      set { this.m_grapaAntiLockIndicator = value; }
    }

    /// <summary>
    /// Is UIMPD rejection selected for this vehicle in the interface?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool RejectUIMPD
    {
      get { return m_rejectUIMPD; }
      set { m_rejectUIMPD = value; }
    }

    /// <summary>
    /// Is UIMPD rejection selected for this vehicle by the carrier?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoRejectUIMPD
    {
      get { return m_coRejectUIMPD; }
      set { m_coRejectUIMPD = value; }
    }

    /// <summary>
    /// Indicator that this vehicie is garaged at the Insured's mailing address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool GarageAddressSameAsMailing
    {
      get { return m_garageAddressSameAsMailing; }
      set { m_garageAddressSameAsMailing = value; }
    }

    /// <summary>
    /// Indicator that this vehicle is used for ride sharing
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool RideShare
    {
      get { return m_rideshare; }
      set { m_rideshare = value; }
    }

    /// <summary>
    /// Is this vehicle used for commuting
    /// across state lines
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(USState))]
    public virtual USState CommutesOutOfState
    {
      get { return m_commutesOutOfState; }
      set { m_commutesOutOfState = value; }
    }

    /// <summary>
    /// The client agrees to use a device or an app to monitor vehicle's usage
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool UsageBased
    {
      get { return m_usageBased; }
      set { m_usageBased = value; }
    }

    /// <summary>
    /// Additional PIP option
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 4)]
    public virtual string AdditionalPIPOption
    {
      get { return this.m_addPIPOption; }
      set { this.m_addPIPOption = value; }
    }

    /// <summary>
    /// Company additional PIP option
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 4)]
    public virtual string CoAdditionalPIPOption
    {
      get { return this.m_coAddPIPOption; }
      set { this.m_coAddPIPOption = value; }
    }


    /// <summary>
    /// Medical expense only.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool MedicalExpenseOnly
    {
      get { return this.m_medicalExpenseOnly; }
      set { this.m_medicalExpenseOnly = value; }
    }

    /// <summary>
    /// Company medical expense only.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoMedicalExpenseOnly
    {
      get { return this.m_coMedicalExpenseOnly; }
      set { this.m_coMedicalExpenseOnly = value; }
    }

    /// <summary>
    /// Medical Expense Only premium. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double MedicalExpenseOnlyPremium
    {
      get { return this.m_medicalExpenseOnlyPremium; }
      set { this.m_medicalExpenseOnlyPremium = value; }
    }

    /// <summary>
    /// Extended medical. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ExtendedMedical
    {
      get { return this.m_extendedMedical; }
      set { this.m_extendedMedical = value; }
    }

    /// <summary>
    /// Extended medical amount. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ExtendedMedicalLimit
    {
      get { return this.m_extendedMedicalLimit; }
      set { this.m_extendedMedicalLimit = value; }
    }

    /// <summary>
    /// Company extended medical amount. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoExtendedMedicalLimit
    {
      get { return this.m_coExtendedMedicalLimit; }
      set { this.m_coExtendedMedicalLimit = value; }
    }

    /// <summary>
    /// Extended medical premium. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double ExtendedMedicalPremium
    {
      get { return this.m_extendedMedicalPremium; }
      set { this.m_extendedMedicalPremium = value; }
    }

    /// <summary>
    /// Spousal liability coverage
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SpousalLiability
    {
      get { return m_spousalLiability; }
      set { m_spousalLiability = value; }
    }

    /// <summary>
    /// Spousal liability premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double SpousalLiabilityPremium
    {
      get { return this.m_spousalLiabilityPremium; }
      set { this.m_spousalLiabilityPremium = value; }
    }

    /// <summary>
    /// Flag to identify if MSRP was entered because no ISO symbol existed
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool MSRPForSymbol { get; set; } = false;

    private int CoveragePointsUpperBound { get; set; }

    /// <summary>
    /// PIP attendant care premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PipAttendantCareOptionPremium
    {
      get { return m_pipAttendantCareOptionPremium; }
      set { m_pipAttendantCareOptionPremium = value; }
    }

    /// <summary>
    /// PIP attendant care limit. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PIPAttendantCareOptionLimit
    {
      get { return m_pipAttendantCareOptionLimit; }
      set { m_pipAttendantCareOptionLimit = value; }
    }

    /// <summary>
    /// Company rated PIP attendant care limit. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoPIPAttendantCareOptionLimit
    {
      get { return m_coPipAttendantCareOptionLimit; }
      set { m_coPipAttendantCareOptionLimit = value; }
    }

    /// <summary>
    /// PIP attendant care coverage
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PIPAttendantCareOption
    {
      get { return m_pipAttendantCareOption; }
      set { m_pipAttendantCareOption = value; }
    }

    #endregion Public Properties

    #region Constructors
    public AUCar()
    {
      for (CoverageType ct = CoverageType.Liab; ct <= CoverageType.Gap; ct++)
      {
        m_coveragePoints.Add(0);
        m_secondaryCoveragePoints.Add(0);
      }
    }
    #endregion Constructors

    #region Helper Methods
    /// <summary>
    /// Validates all 17 characters of the VIN
    /// </summary>
    /// <param name="vin">The VIN to be validated</param>
    /// <returns>True if all 17 characters validate; false otherwise</returns>
    public bool ValidVIN(string vin)
    {
      int[] LetterCodes = { 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 0, 7, 0, 9, 2, 3, 4, 5, 6, 7, 8, 9 };
      int[] MultiplyCodes = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
      bool result = true;
      char[] AVIN = vin.ToUpper().ToCharArray();

      bool validString = vin.Length > 0;
      int index = AVIN.GetLowerBound(0);
      while ((index <= AVIN.GetUpperBound(0)) && validString)
      {
        validString = ((((int)AVIN[index]) >= ((int)'A')) && (((int)AVIN[index]) <= ((int)'Z'))) ||
                      ((((int)AVIN[index]) >= ((int)'0')) && (((int)AVIN[index]) <= ((int)'9')));
        index++;
      }     // while

      if ((vin.Length == 17) && validString)
      {
        if ((vin == "11111111111111111") || (vin == "00000000000000000"))
          return result;
        int sumOfDigits = 0;
        for (index = AVIN.GetLowerBound(0); index <= AVIN.GetUpperBound(0); index++)
        {
          if ((AVIN[index] == 'I') || (AVIN[index] == 'O') || (AVIN[index] == 'Q'))
            return result;
          int assignedValue;
          if ((((int)AVIN[index]) >= ((int)'A')) && (((int)AVIN[index]) <= ((int)'Z')))
            assignedValue = LetterCodes[(((int)AVIN[index]) - 64) - 1];  // -1 to account for 0 based array
          else
            assignedValue = ITCConvert.ToInt32(AVIN[index], 0);
          assignedValue *= MultiplyCodes[index];
          sumOfDigits += assignedValue;
        }     // for
        int remainder = sumOfDigits % 11;
        int checkDigit;
        // This is the check for the 9th character of the VIN
        // using an index of 8 because the array is 0 based
        if (AVIN[8] == 'X')
          checkDigit = 10;
        else
          checkDigit = ITCConvert.ToInt32(AVIN[8], -1);
        result = (remainder == checkDigit);
      }     // if (vin.Length == 17)
      return result;
    }

    /// <summary>
    /// Sets all the premiums on the vehicle to 0
    /// </summary>
    public void ZeroPremiums()
    {
      Type t = this.GetType();
      PropertyInfo[] pinfos = t.GetProperties();
      foreach (PropertyInfo pinfo in pinfos)
      {
        if ((pinfo.PropertyType == typeof(double)) && (pinfo.Name.EndsWith("PREMIUM", StringComparison.OrdinalIgnoreCase)))
          if (pinfo.GetSetMethod() != null)
            pinfo.SetValue(this, 0.0, null);
      }     // foreach
    }     // ZeroPremiums

    /// <summary>
    /// Turns off all coverage types for all cars except those contained in the "Leave Alone" list. 
    /// This is especially useful for turning off coverage types that don't apply to specific states.
    /// </summary>
    /// <param name="coverageTypesToLeaveAlone">Array of coverage types you want to leave at defaulted or imported value.</param>
    public virtual void RemoveAllCoverageTypesExceptX(CoverageType[] coverageTypesToLeaveAlone)
    {
      Type type = this.GetType();
      PropertyInfo[] properties = type.GetProperties();
      foreach (CoverageType coverage in Enum.GetValues(typeof(CoverageType)))
      {
        if (Array.IndexOf(coverageTypesToLeaveAlone, coverage) == -1)
        {
          foreach (PropertyInfo property in properties)
          {
            // IncLoss' property is called IncomeLoss.
            if (((coverage.ToString().Equals("IncLoss", StringComparison.OrdinalIgnoreCase)) && (property.Name.Equals("IncomeLoss", StringComparison.OrdinalIgnoreCase)))
              // CombFirstParty's property is called CombineBen.
            || ((coverage.ToString().Equals("CombFirstParty", StringComparison.OrdinalIgnoreCase)) && (property.Name.Equals("CombineBen", StringComparison.OrdinalIgnoreCase)))
              // Mexico's property is called MexicoCoverage.
            || ((coverage.ToString().Equals("Mexico", StringComparison.OrdinalIgnoreCase)) && (property.Name.Equals("MexicoCoverage", StringComparison.OrdinalIgnoreCase)))
              // Gap's property is called GapCoverage.
            || ((coverage.ToString().Equals("Gap", StringComparison.OrdinalIgnoreCase)) && (property.Name.Equals("GapCoverage", StringComparison.OrdinalIgnoreCase))))
            {
              property.SetValue(this, false, null);
              break;
            }

            if (property.Name.Equals(coverage.ToString(), StringComparison.OrdinalIgnoreCase))
            {
              // MedExpense is a string.
              if (property.Name.Equals("MedExpense", StringComparison.OrdinalIgnoreCase))
                property.SetValue(this, "", null);
              else if (property.PropertyType == typeof(bool))
                property.SetValue(this, false, null);

              break;
            }
          }
        }
      }
    }

    /// <summary>
    /// Used by the ObjectSqlDbPersistence class. This method is here
    /// so that we can perform some pre-save operations on the object.
    /// </summary>
    public virtual void PreSave()
    {
      CompanyDataStorage = CompanyQuestions.GenerateBlobField(CompanyQuestionCategory.CompanyData);
      NonStoredDataStorage = CompanyQuestions.GenerateBlobField(CompanyQuestionCategory.NonStoredData);
      CompanyModuleContentsDataStorage = CompanyQuestions.GenerateBlobField(CompanyQuestionCategory.CompanyModuleContents);
    }

    /// <summary>
    /// Used by the ObjectSqlDbPersistence class. This method is here
    /// so that we can perform some post-load operations on the object.
    /// </summary>
    public virtual void PostLoad()
    {
      CompanyQuestions.ParseBlobField(CompanyDataStorage, CompanyQuestionCategory.CompanyData);
      CompanyQuestions.ParseBlobField(NonStoredDataStorage, CompanyQuestionCategory.NonStoredData);
      CompanyQuestions.ParseBlobField(CompanyModuleContentsDataStorage, CompanyQuestionCategory.CompanyModuleContents);
    }

    /// <summary>
    /// Gets the applicable CoTerr of the car based on the policy's exclusion code
    /// </summary>
    /// <returns>The applicable CoTerr of the car</returns>
    public virtual string GetCoTerritory
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return this.SecondaryCoTerr;
        }

        return this.CoTerr;
      }
    }

    /// <summary>
    /// Gets the applicable CoSym of the car based on the policy's exclusion code
    /// </summary>
    /// <returns>The applicable CoSy of the car</returns>
    public virtual string GetCoSymbol
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return this.SecondaryCoSym;
        }
        return this.CoSym;
      }
    }

    /// <summary>
    /// Gets the applicable driver assigned by the company to this car based on
    /// the policy's exclusion code
    /// </summary>
    /// <returns>The applicable company-assigned driver</returns>
    public virtual int GetCoWhichDriver
    {
      get
      {
        if (this.ParentPolicy != null)
        {
          if ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted)
            return this.SecondaryCoWhichDrv;
        }
        return this.CoWhichDrv;
      }
    }

    #endregion Helper Methods
  }
}
