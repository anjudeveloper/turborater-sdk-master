using System;
using System.Collections.Generic;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// Represents an automobile driver for the purpose of automobile
  /// insurance. 
  /// </summary>
  public class AUDriver : Person
  {
    #region Private Vars and Such
    private bool m_creditCard;
    private DateTime m_dateLicensed = ITCConstants.InvalidDate;
    private DateTime m_dateLicensedState = ITCConstants.InvalidDate;
    private bool m_defensiveDriving;
    private DateTime m_defensiveDrivingCourseDate = ITCConstants.InvalidDate;
    private DateTime m_seniorDriverCourseDate = ITCConstants.InvalidDate;
    private string m_driverClass = "";
    private bool m_driversTraining;
    private bool m_drugAwareness;
    private string m_drvLicenseNumber = "";
    private bool m_excluded;
    private bool m_ignored;
    private bool m_foreignNatl;
    private bool m_goodCredit = true;
    private bool m_goodStudent;
    private bool m_internatDL;
    private bool m_isPrimaryOperator;
    private bool m_learnersPermit;
    private bool m_licensed = true;
    private bool m_licensedState = true;
    private bool m_civilUnion;
    private int m_milesToWork;
    private int m_monthsLicensed = 60;
    private int m_monthsLicensedState = 60;
    private int m_monthsMVRExper = 60;
    private int m_monthsNoBillCollector = 120;
    private int m_monthsNoPastDue = 120;
    private int m_monthsSuspended = 60;
    private bool m_nonSmoker;
    private bool m_occasionalOperator;
    private int m_primaryCar;
    private int m_priorCompId = ITCConstants.InvalidNum;
    private int m_secondaryPriorCompId = ITCConstants.InvalidNum;
    private int m_priorDaysLapse;
    private bool m_priorInsurance;
    private string m_priorLicenseNum = "";
    private string m_priorLicenseState = "";
    private int m_priorMonthsCovg = 12;
    private string m_priorTransferLevel = "N";
    private bool m_proofOfOwnership;
    private bool m_propertyInsurance;
    private bool m_rankE5OrHigher;
    private string m_residencyStatus = "R";
    private string m_residencyType = "A";
    private int m_resideTime;
    private bool m_seniorDrvDisc;
    private bool m_singleParent;
    private bool m_sr22;
    private bool m_sr22A;
    private bool m_sr50;
    private bool m_sr1P;
    private string m_sr22CaseNum = "";
    private DateTime m_sr22Date = ITCConstants.InvalidDate;
    private string m_sr22Reason = "O";
    private string m_sr22State = "";
    private string m_stateLicensed = "";
    private string m_suffix = "";
    private bool m_suspendedLic;
    private bool m_expiredLicense;
    private string m_title = "";
    private AUViolationList m_violations;
    private int m_priorLiabLim1 = 20;
    private int m_priorLiabLim2 = 40;
    private int m_priorLiabLim3 = 15;
    private int m_violPoints;
    private bool m_multiPolicies;
    private int m_ageRated;
    private string m_coDrvTierStr = "";
    private int m_driverID = 1;
    private int m_groupCode;
    private int m_insPersonVersionRecord = 1;
    private string m_secondaryDriverClass = "";
    private bool m_securityVerification;
    private bool m_disabled;
    private bool m_fr44;
    private bool m_militaryDiscount;
    private string m_secondaryCoDrvTierStr = "";
    private InsPolicy m_parentPolicy;
    private bool m_motorcycleSafetyCourse;
    private DateTime m_motorcycleSafetyCourseDate = ITCConstants.InvalidDate;
    private bool m_awayAtSchool;
    private int m_yearsRidingExperience;
    private bool m_revokedLicense;
    private string m_motorcycleClub = AUConstants.MotorcycleClubNames[0];
    private bool m_motorcycleEndorsement = true;
    private DateTime m_motorcycleEndorsementDate = ITCConstants.InvalidDate;
    private int m_monthsForeignLicense;
    private string m_mvrReferenceID = "";
    private bool m_tvdl;
    private ReasonForNoInsurance m_reasonForNoInsurance = ReasonForNoInsurance.NoReasonGiven;
    private bool m_paperlessDiscount;
    private bool m_parentsPolicy;
    private bool m_withChildren;
    private List<DMVAction> m_dmvActions = new List<DMVAction>();
    private bool m_listOnly;
    private string m_listOnlyReason = string.Empty;
    private string m_distantStudent = "N";
    private InsConstants.MIHealthInsuranceCarrier m_healthInsuranceCarrier;
    private bool m_excludeFromPip;

    #endregion

    #region Public Properties

    /// <summary>
    /// The person's age, as of the effective date of the associated
    /// policy. If the DOB is an invalid date, 0 is returned. If there
    /// is no associated policy, then today's date is used.
    /// </summary>
    public override int Age
    {
      get
      {
        DateTime toDate = DateTime.Now;
        if (!ITCConstants.IsValidDate(DOB))
          return 0;
        else
        {
          if ((this.ParentPolicy != null) && (ITCConstants.IsValidDate(this.ParentPolicy.EffectiveDate)))
            toDate = this.ParentPolicy.EffectiveDate;
          int years = toDate.Year - DOB.Year;
          if (DOB.Date.AddYears(years) > toDate.Date)
            years--;
          return years;
        }
      }
    }

    /// <summary>
    /// List of DMV Actions for this driver
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(DMVAction))]
    public virtual List<DMVAction> DMVActions
    {
      get { return m_dmvActions; }
      set { m_dmvActions = value; }
    }

    /// <summary>
    /// Does the driver have a credit card?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CreditCard
    {
      get { return m_creditCard; }
      set { m_creditCard = value; }
    }

    /// <summary>
    /// Date/time the driver obtained their driver's license
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime DateLicensed
    {
      get { return m_dateLicensed; }
      set { m_dateLicensed = value; }
    }

    /// <summary>
    /// Date/time the driver obtained their driver's license in this state
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime DateLicensedState
    {
      get { return m_dateLicensedState; }
      set { m_dateLicensedState = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.NVarChar, Size = 1)]
    public virtual string DistantStudent
    {
      get { return m_distantStudent; }
      set { m_distantStudent = value; }
    }

    /// <summary>
    /// Rejection of PIP Income Loss Benefits
    /// Applicable in MN only
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool WaiveIncomeLoss { get; set; }

    /// <summary>
    /// Has the driver taken a defensive driving course?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool DefensiveDriving
    {
      get { return m_defensiveDriving; }
      set { m_defensiveDriving = value; }
    }

    /// <summary>
    /// Date the driver took a defensive driving course
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime DefensiveDrivingCourseDate
    {
      get { return m_defensiveDrivingCourseDate; }
      set { m_defensiveDrivingCourseDate = value; }
    }

    /// <summary>
    /// Date the driver took a senior driver course
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime SeniorDriverCourseDate
    {
      get { return m_seniorDriverCourseDate; }
      set { m_seniorDriverCourseDate = value; }
    }

    /// <summary>
    /// Rated driver class
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string DriverClass
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryDriverClass;
        else
          return m_driverClass;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryDriverClass = value;
        else
          m_driverClass = value;
      }
    }

    /// <summary>
    /// Has the driver taken a driver's training course?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool DriversTraining
    {
      get { return m_driversTraining; }
      set { m_driversTraining = value; }
    }

    /// <summary>
    /// Driver's license number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 256, IsEncrypted = true)]
    public virtual string DrvLicenseNumber
    {
      get { return m_drvLicenseNumber; }
      set { m_drvLicenseNumber = value; }
    }

    /// <summary>
    /// Is this driver excluded from the policy?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Excluded
    {
      get { return m_excluded; }
      set { m_excluded = value; }
    }

    /// <summary>
    /// Is this driver to be ignored for rating purposes
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Ignored
    {
      get { return m_ignored; }
      set { m_ignored = value; }
    }

    /// <summary>
    /// Is the driver a foreign national?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ForeignNatl
    {
      get { return m_foreignNatl; }
      set { m_foreignNatl = value; }
    }

    /// <summary>
    /// Does the driver have good credit?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool GoodCredit
    {
      get { return m_goodCredit; }
      set { m_goodCredit = value; }
    }

    /// <summary>
    /// Is the driver a good little student?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool GoodStudent
    {
      get { return m_goodStudent; }
      set { m_goodStudent = value; }
    }

    /// <summary>
    /// Does the driver have an international driver's license?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool InternatDL
    {
      get { return m_internatDL; }
      set { m_internatDL = value; }
    }

    /// <summary>
    /// Is the driver the primary operator of his/her vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool IsPrimaryOperator
    {
      get { return m_isPrimaryOperator; }
      set { m_isPrimaryOperator = value; }
    }

    /// <summary>
    /// Does the driver have a learner's permit?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LearnersPermit
    {
      get { return m_learnersPermit; }
      set { m_learnersPermit = value; }
    }

    /// <summary>
    /// Does the driver have a driver's license?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Licensed
    {
      get { return m_licensed; }
      set { m_licensed = value; }
    }

    /// <summary>
    /// Is the driver licensed to drive in this state?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool LicensedState
    {
      get { return m_licensedState; }
      set { m_licensedState = value; }
    }

    /// <summary>
    /// If driver's marital status is Married, indicates
    /// whether or not said marriage is a civil union
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CivilUnion
    {
      get { return m_civilUnion; }
      set { m_civilUnion = value; }
    }

    /// <summary>
    /// How many miles does the driver drive to work each day?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MilesToWork
    {
      get { return m_milesToWork; }
      set { m_milesToWork = value; }
    }

    /// <summary>
    /// How many months has the driver been licensed to drive?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MonthsLicensed
    {
      get { return m_monthsLicensed; }
      set { m_monthsLicensed = value; }
    }

    /// <summary>
    /// How many months has the driver been licensed to drive in this state?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MonthsLicensedState
    {
      get { return m_monthsLicensedState; }
      set { m_monthsLicensedState = value; }
    }

    /// <summary>
    /// How many months of motor vehicle record experience does
    /// this driver have?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MonthsMVRExper
    {
      get { return m_monthsMVRExper; }
      set { m_monthsMVRExper = value; }
    }

    /// <summary>
    /// How many months has it been since somebody sicked a bill
    /// collector on the driver?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MonthsNoBillCollector
    {
      get { return m_monthsNoBillCollector; }
      set { m_monthsNoBillCollector = value; }
    }

    /// <summary>
    /// How many months has it been since the driver had a past-due
    /// bill?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MonthsNoPastDue
    {
      get { return m_monthsNoPastDue; }
      set { m_monthsNoPastDue = value; }
    }

    /// <summary>
    /// How many months has it been since the driver had his/her
    /// license suspended?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MonthsSuspended
    {
      get { return m_monthsSuspended; }
      set { m_monthsSuspended = value; }
    }

    /// <summary>
    /// Is the driver a non-smoker?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool NonSmoker
    {
      get { return m_nonSmoker; }
      set { m_nonSmoker = value; }
    }

    /// <summary>
    /// Is the driver an occasional operator of his/her
    /// vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool OccasionalOperator
    {
      get { return m_occasionalOperator; }
      set { m_occasionalOperator = value; }
    }

    /// <summary>
    /// Which vehicle (1-based index) does the driver drive primarily?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PrimaryCar
    {
      get { return m_primaryCar; }
      set { m_primaryCar = value; }
    }

    /// <summary>
    /// The company ID of the driver's prior insurance company
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PriorCompId
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryPriorCompId;
        else
          return m_priorCompId;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryPriorCompId = value;
        else
          m_priorCompId = value;
      }
    }

    /// <summary>
    /// The company ID of the driver's prior insurance company for
    /// the secondary rated company
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int SecondaryPriorCompId
    {
      get { return m_secondaryPriorCompId; }
      set { m_secondaryPriorCompId = value; }
    }

    /// <summary>
    /// How many days lapsed between the driver's prior 2 policies?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PriorDaysLapse
    {
      get { return m_priorDaysLapse; }
      set { m_priorDaysLapse = value; }
    }

    /// <summary>
    /// Does the driver have prior insurance?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PriorInsurance
    {
      get { return m_priorInsurance; }
      set { m_priorInsurance = value; }
    }

    /// <summary>
    /// The driver's prior driver license number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 16)]
    public virtual string PriorLicenseNum
    {
      get { return m_priorLicenseNum; }
      set { m_priorLicenseNum = value; }
    }

    /// <summary>
    /// Driver's prior driver license state
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 2)]
    public virtual string PriorLicenseState
    {
      get { return m_priorLicenseState; }
      set { m_priorLicenseState = value; }
    }

    /// <summary>
    /// How many months of coverage did the prior policy provide?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PriorMonthsCovg
    {
      get { return m_priorMonthsCovg; }
      set { m_priorMonthsCovg = value; }
    }

    /// <summary>
    /// Prior policy's transfer level
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string PriorTransferLevel
    {
      get { return m_priorTransferLevel; }
      set { m_priorTransferLevel = value; }
    }

    /// <summary>
    /// Does the driver have proof of ownership of his/her vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ProofOfOwnership
    {
      get { return m_proofOfOwnership; }
      set { m_proofOfOwnership = value; }
    }

    /// <summary>
    /// Does the driver have property insurance?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PropertyInsurance
    {
      get { return m_propertyInsurance; }
      set { m_propertyInsurance = value; }
    }

    /// <summary>
    /// If in the military, is the driver rank E-5 or higher?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool RankE5OrHigher
    {
      get { return m_rankE5OrHigher; }
      set { m_rankE5OrHigher = value; }
    }

    /// <summary>
    /// The driver's residency status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string ResidencyStatus
    {
      get { return m_residencyStatus; }
      set { m_residencyStatus = value; }
    }

    /// <summary>
    /// Driver's residency type
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string ResidencyType
    {
      get { return m_residencyType; }
      set { m_residencyType = value; }
    }

    /// <summary>
    /// Length of time the driver has lived at current address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ResideTime
    {
      get { return m_resideTime; }
      set { m_resideTime = value; }
    }

    /// <summary>
    /// Is the driver eligible for a senior driver discount?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SeniorDrvDisc
    {
      get { return m_seniorDrvDisc; }
      set { m_seniorDrvDisc = value; }
    }

    /// <summary>
    /// Is the driver a single parent?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SingleParent
    {
      get { return m_singleParent; }
      set { m_singleParent = value; }
    }

    /// <summary>
    /// does the driver have an SR-22?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SR22
    {
      get { return m_sr22; }
      set { m_sr22 = value; }
    }

    /// <summary>
    /// does the driver have an SR-1P
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SR1P
    {
      get { return m_sr1P; }
      set { m_sr1P = value; }
    }

    /// <summary>
    /// does the driver have an SR-22A?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SR22A
    {
      get { return m_sr22A; }
      set { m_sr22A = value; }
    }

    /// <summary>
    /// does the driver have an SR-50?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SR50
    {
      get { return m_sr50; }
      set { m_sr50 = value; }
    }

    /// <summary>
    /// Driver's SR-22 case number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string SR22CaseNum
    {
      get { return m_sr22CaseNum; }
      set { m_sr22CaseNum = value; }
    }

    /// <summary>
    /// Driver's SR-22 date
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime SR22Date
    {
      get { return m_sr22Date; }
      set { m_sr22Date = value; }
    }

    /// <summary>
    /// Driver's SR-22 reason
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string SR22Reason
    {
      get { return m_sr22Reason; }
      set { m_sr22Reason = value; }
    }

    /// <summary>
    /// Driver's SR-22 state
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 2)]
    public virtual string SR22State
    {
      get { return m_sr22State; }
      set { m_sr22State = value; }
    }

    /// <summary>
    /// State in which the driver is licensed
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 2)]
    public virtual string StateLicensed
    {
      get { return m_stateLicensed; }
      set { m_stateLicensed = value; }
    }

    /// <summary>
    /// Driver's name suffix
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 12)]
    public virtual string Suffix
    {
      get { return m_suffix; }
      set { m_suffix = value; }
    }

    /// <summary>
    /// Is the driver's DL suspended?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SuspendedLic
    {
      get { return m_suspendedLic; }
      set { m_suspendedLic = value; }
    }

    /// <summary>
    /// Is the driver's DL expired?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ExpiredLicense
    {
      get { return m_expiredLicense; }
      set { m_expiredLicense = value; }
    }

    /// <summary>
    /// Driver's name title
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 12)]
    public virtual string Title
    {
      get { return m_title; }
      set { m_title = value; }
    }

    /// <summary>
    /// Violations the driver has
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant)]
    public virtual AUViolationList Violation
    {
      get { return m_violations; }
      set { m_violations = value; }
    }

    /// <summary>
    /// Returns the number of violations this driver has
    /// </summary>
    public virtual int NumOfViols
    {
      get { return Violation.Count; }
    }

    /// <summary>
    /// Returns the number of DMV Actions (suspensions) this driver has
    /// </summary>
    public virtual int NumOfSusps
    {
      get { return DMVActions.Count; }
    }

    /// <summary>
    /// Returns the # of points the driver has from violations
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ViolPoints
    {
      get { return m_violPoints; }
      set { m_violPoints = value; }
    }

    /// <summary>
    /// Prior policy's liability limits part 1
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PriorLiabLim1
    {
      get { return m_priorLiabLim1; }
      set { m_priorLiabLim1 = value; }
    }

    /// <summary>
    /// Prior policy's liability limits part 2
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PriorLiabLim2
    {
      get { return m_priorLiabLim2; }
      set { m_priorLiabLim2 = value; }
    }

    /// <summary>
    /// Prior policy's liability limits part 3
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int PriorLiabLim3
    {
      get { return m_priorLiabLim3; }
      set { m_priorLiabLim3 = value; }
    }

    /// <summary>
    /// Does the driver have multiple policies?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool MultiPolicies
    {
      get { return m_multiPolicies; }
      set { m_multiPolicies = value; }
    }

    /// <summary>
    /// The age at which the driver was rated
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int AgeRated
    {
      get { return m_ageRated; }
      set { m_ageRated = value; }
    }

    /// <summary>
    /// The company-specific tier name in which the driver was rated
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 30)]
    public virtual string CoDrvTierStr
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCoDrvTierStr;
        else
          return m_coDrvTierStr;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCoDrvTierStr = value;
        else
          m_coDrvTierStr = value;
      }
    }

    /// <summary>
    /// The id of the driver (1 is insured most likely)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int DriverID
    {
      get { return m_driverID; }
      set { m_driverID = value; }
    }

    /// <summary>
    /// Has the driver taken a drug awareness course?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool DrugAwareness
    {
      get { return m_drugAwareness; }
      set { m_drugAwareness = value; }
    }

    /// <summary>
    /// The code# of the driver's group (not a clue)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int GroupCode
    {
      get { return m_groupCode; }
      set { m_groupCode = value; }
    }

    /// <summary>
    /// The version of the insperson record used for this driver
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int InsPersonVersionRecord
    {
      get { return m_insPersonVersionRecord; }
      set { m_insPersonVersionRecord = value; }
    }

    /// <summary>
    /// The secondary rating company's driver class assigned to this driver
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string SecondaryDriverClass
    {
      get { return m_secondaryDriverClass; }
      set { m_secondaryDriverClass = value; }
    }

    /// <summary>
    /// Does this driver have security verification? Don't know what this means, oh well
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SecurityVerification
    {
      get { return m_securityVerification; }
      set { m_securityVerification = value; }
    }

    /// <summary>
    /// Is this driver disabled? (an employment question)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Disabled
    {
      get { return m_disabled; }
      set { m_disabled = value; }
    }

    /// <summary>
    /// Does this driver have an FR-44 filing? (yet another
    /// SR-22 wannabe)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FR44
    {
      get { return m_fr44; }
      set { m_fr44 = value; }
    }

    /// <summary>
    /// Does this driver qualify for a military discount?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool MilitaryDiscount
    {
      get { return m_militaryDiscount; }
      set { m_militaryDiscount = value; }
    }

    /// <summary>
    /// The company-specific tier name in which the driver was rated for the second company.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 30)]
    public virtual string SecondaryCoDrvTierStr
    {
      get { return m_secondaryCoDrvTierStr; }
      set { m_secondaryCoDrvTierStr = value; }
    }

    /// <summary>
    /// Reference back to policy that owns this object.
    /// </summary>
    public InsPolicy ParentPolicy
    {
      get { return m_parentPolicy; }
      set { m_parentPolicy = value; }
    }

    /// <summary>
    /// Has this operator taken a motorcycle safety course?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool MotorcycleSafetyCourse
    {
      get { return m_motorcycleSafetyCourse; }
      set { m_motorcycleSafetyCourse = value; }
    }

    /// <summary>
    /// If this operator has taken a motorcycle safety course what date was the course completed?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public DateTime MotorcycleSafetyCourseDate
    {
      get { return m_motorcycleSafetyCourseDate; }
      set { m_motorcycleSafetyCourseDate = value; }
    }

    /// <summary>
    /// Is this operator a student away at school?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool AwayAtSchool
    {
      get { return m_awayAtSchool; }
      set { m_awayAtSchool = value; }
    }

    /// <summary>
    /// How many years riding experience does this operator have?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int YearsRidingExperience
    {
      get { return m_yearsRidingExperience; }
      set { m_yearsRidingExperience = value; }
    }

    /// <summary>
    /// Does this operator have a revoked license? 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool RevokedLicense
    {
      get { return m_revokedLicense; }
      set { m_revokedLicense = value; }
    }

    /// <summary>
    /// What motorcycle club does this operator belong to?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public string MotorcycleClub
    {
      get { return m_motorcycleClub; }
      set { m_motorcycleClub = value; }
    }

    /// <summary>
    /// Does this operator have a motorcycle endorsement?  (originally added for motorcycle)
    /// </summary>
    /// 
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool MotorcycleEndorsement
    {
      get { return m_motorcycleEndorsement; }
      set { m_motorcycleEndorsement = value; }
    }

    /// <summary>
    /// If this operator has a motorcycle endorsement, what date was it issued?  (originally added for motorcycle)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public DateTime MotorcycleEndorsementDate
    {
      get { return m_motorcycleEndorsementDate; }
      set { m_motorcycleEndorsementDate = value; }
    }

    /// <summary>
    /// Number of months with a foreign drivers license
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int MonthsForeignLicense
    {
      get { return m_monthsForeignLicense; }
      set { m_monthsForeignLicense = value; }
    }

    /// <summary>
    /// Operator has a temporary visitor's license
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool TVDL
    {
      get { return m_tvdl; }
      set { m_tvdl = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public string MVRReferenceID
    {
      get { return m_mvrReferenceID; }
      set { m_mvrReferenceID = value; }
    }

    /// <summary>
    /// Reason the applicant currently does not have insurance.
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(ReasonForNoInsurance))]
    public virtual ReasonForNoInsurance ReasonForNoInsurance
    {
      get { return m_reasonForNoInsurance; }
      set { m_reasonForNoInsurance = value; }
    }

    /// <summary>
    /// Industry Occupation Code according to Acord.  This code is needed in TT2 bridges.
    /// This field is NON STORED and read-only on purpose.  We autocalculate it based on 
    /// the index of our own internal listing.  There is also no private property due to
    /// autocalculation.
    /// </summary>
    public string AcordIndustryOccupation
    {
      get
      {
        int occupationIndex = IndexLib.GetStringIndex(this.IndustryOccupation, ITCConstants.OccupationChars, -1);
        return (occupationIndex > -1) ? ITCConstants.AcordExportCodes[occupationIndex] : "";
      }
    }

    /// <summary>
    /// Do not use.
    /// This field is autoset by setting the policy level paperless discount.  Whatever
    /// value is set in the policy level field is automatically copied down to this field.
    /// There is no point to setting the value of this field.
    /// Use the policy level field instead.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]

    public bool PaperlessDiscount
    {
      get { return m_paperlessDiscount; }
      set { m_paperlessDiscount = value; }
    }

    /// <summary>
    /// Parent's policy?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool ParentsPolicy
    {
      get { return m_parentsPolicy; }
      set { m_parentsPolicy = value; }
    }

    /// <summary>
    /// Have resident custody of a child age 18 or under?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool WithChildren
    {
      get { return m_withChildren; }
      set { m_withChildren = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [list only].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [list only]; otherwise, <c>false</c>.
    /// </value>
    public bool ListOnly
    {
      get { return m_listOnly; }
      set { m_listOnly = value; }
    }

    /// <summary>
    /// Gets or sets the list only reason.
    /// </summary>
    /// <value>
    /// The list only reason.
    /// </value>
    public string ListOnlyReason
    {
      get { return m_listOnlyReason; }
      set { m_listOnlyReason = value; }
    }

    /// <summary>
    /// Should this driver be excluded from PIP coverage?
    /// Used in MI.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool ExcludeFromPip
    {
      get { return m_excludeFromPip; }
      set { m_excludeFromPip = value; }
    }

    /// <summary>
    /// The health insurance carrier.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20, EnumerationType = typeof(InsConstants.MIHealthInsuranceCarrier))]
    public InsConstants.MIHealthInsuranceCarrier HealthInsuranceCarrier
    {
      get { return m_healthInsuranceCarrier; }
      set { m_healthInsuranceCarrier = value; }
    }

    #endregion

    /// <summary>
    /// The fields to check against the conditional load value.
    /// </summary>
    /// <seealso>ConditionalLoadCheck</seealso>
    /// <returns>"PolicyType,Excluded"</returns>
    public override string ConditionalLoadFieldName()
    {
			return "PolicyType,Excluded,ListOnly";
    }

    /// <summary>
    /// Used by the ObjectSqlDbPersistence class to determine under what circumstances
    /// this object will be loaded from the database.
    /// </summary>
    /// <seealso>ConditionalLoadFieldName</seealso>
    /// <param name="checkValue1">The value to check the condition of</param>
    /// <param name="checkValue2">The 2nd value to check the condition of</param>
    /// <param name="checkValue3">The 3rd value to check the condition of</param>
    /// <param name="parentField">The parent object of this current object</param>
    /// <returns>True if the state of the object matches that passed in the checkValue,
    /// otherwise false</returns>
    public virtual bool ConditionalLoadCheck(object checkValue1, object checkValue2, object checkValue3, object parentField)
    {
      bool tempResult = false;
      if (checkValue2 == null || checkValue2.ToString().Length == 0)
        return true;
      if (checkValue3 == null || string.IsNullOrEmpty(checkValue3.ToString()))
        checkValue3 = "False";
        if (parentField.ToString().ToUpper() == "EXCLUSIONS")
          tempResult = Boolean.Parse(checkValue2.ToString());
      else if (parentField.ToString().ToUpper() == "LISTONLYDRIVERS")
        tempResult = Boolean.Parse(checkValue3.ToString());
        else
				tempResult = !Boolean.Parse(checkValue2.ToString()) && !Boolean.Parse(checkValue3.ToString());
      return tempResult;
    }

    /// <summary>
    /// Copies residency info from this driver to the target driver
    /// </summary>
    /// <param name="target">the target driver</param>
    public void CopyResidencyInfo(AUDriver target)
    {
      target.PropertyInsurance = this.PropertyInsurance;
      target.ResidencyStatus = this.ResidencyStatus;
      target.ResidencyType = this.ResidencyType;
    }

    /// <summary>
    /// Copies prior insurance info from this driver to the target driver
    /// </summary>
    /// <param name="target">the target driver</param>
    public void CopyPriorInsuranceInfo(AUDriver target)
    {
      target.PriorInsurance = this.PriorInsurance;
      target.ReasonForNoInsurance = this.ReasonForNoInsurance;
      target.PriorMonthsCovg = this.PriorMonthsCovg;
      target.PriorDaysLapse = this.PriorDaysLapse;
      target.PriorLiabLim1 = this.PriorLiabLim1;
      target.PriorLiabLim2 = this.PriorLiabLim2;
      target.PriorLiabLim3 = this.PriorLiabLim3;
      target.PriorCompId = this.PriorCompId;
      target.SecondaryPriorCompId = this.SecondaryPriorCompId;
      target.PriorTransferLevel = this.PriorTransferLevel;
    }

    /// <summary>
    /// Copies the paperless discount info from this driver to the target driver.
    /// </summary>
    /// <param name="target"></param>
    public void CopyPaperlessDiscountInfo(AUDriver target)
    {
      target.PaperlessDiscount = this.PaperlessDiscount;
    }
    #region Constructors

    /// <summary>
    /// Default constructor
    /// </summary>
    public AUDriver()
      : base()
    {
      Violation = new AUViolationList();
      PolicyType = InsuranceLine.PersonalAuto;
    }

    /// <summary>
    /// constructor that lets you specify the type of person
    /// </summary>
    /// <param name="aPersonType">The type of person that this is</param>
    public AUDriver(TypeOfPerson aPersonType)
      : base(aPersonType)
    {
      Violation = new AUViolationList();
      PolicyType = InsuranceLine.PersonalAuto;
    }

    /// <summary>
    /// Constructor that allows you to specify the type of person and the policy type.
    /// </summary>
    /// <param name="aPolicyType">The type of policy this user is being created for.</param>
    public AUDriver(InsuranceLine aPolicyType)
      : base(aPolicyType)
    {
      Violation = new AUViolationList();
    }

    /// <summary>
    /// Constructor that allows you to specify the type of person and the policy type.
    /// </summary>
    /// <param name="aPersonType">the type of person</param>
    /// <param name="aPolicyType">The type of policy this user is being created for.</param>
    public AUDriver(TypeOfPerson aPersonType, InsuranceLine aPolicyType)
      : base(aPersonType, aPolicyType)
    {
      Violation = new AUViolationList();
    }
    #endregion Constructors

  }
}
