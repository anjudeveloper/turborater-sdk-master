
using System;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// An auto policy. Encompasses Personal Auto or any other Auto type policy.
  /// This links to drivers, vehicles, etc.
  /// </summary>
  public class AUPolicy : InsPolicy
  {
    #region Private Vars
    private AUCarList m_cars;
    private AUDriverList m_drivers;
    private AUDriverList m_exclusions;
    private AUDriverList m_listOnlyDrivers;
    private double m_sR22Fee;
    private bool m_nonOwner;
    private bool m_isOperator;
    private bool m_broadform;
    private bool m_fullTort;
    private double m_aTPAFee;
    private double m_collectionFee;
    private double m_lawEnforceFee;
    private double m_municipalTax;
    private double m_municipalTaxRate;
    private double m_securityVerificationFee;
    private double m_stampFee;
    private double m_stateTax;
    private double m_stateTaxRate;
    private double m_tax;
    private double m_uninsMotorFee;
    private bool m_autoRate;
    private bool m_coveragesByCar;
    private int m_deletedDriverCount;
    private int m_deletedExclusionCount;
    private int m_deletedMiscPremiumCount;
    private int m_deletedUnitCount;
    private int m_dOSCompanyID;
    private double m_fR44Fee;
    private PaymentMethod m_paymentMethod;
    private double m_totalPremium;
    private string m_priorPIPMedicalCarrierName = string.Empty;
    private string m_priorPIPWorkLossCarrierName = string.Empty;
    private bool m_paperlessDiscount;
    private int m_companionHOPolicyId = -1;
    private int m_totalResidentsInHousehold;
    private int m_numOfOtherResidentsExcludedFromPIP;

    #endregion Private Vars

    #region Public Properties

    /// <summary>
    /// Is this a non-owner policy?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool NonOwner
    {
      get { return m_nonOwner; }
      set { m_nonOwner = value; }
    }

    /// <summary>
    /// Is this an operator policy?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool IsOperator
    {
      get { return m_isOperator; }
      set { m_isOperator = value; }
    }

    /// <summary>
    /// Is this a broadform policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Broadform
    {
      get { return m_broadform; }
      set { m_broadform = value; }
    }

    /// <summary>
    /// Amount SR-22 fee on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double SR22Fee
    {
      get { return m_sR22Fee; }
      set { m_sR22Fee = value; }
    }

    /// <summary>
    /// List of excluded drivers on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant)]
    public virtual AUDriverList Exclusions
    {
      get { return m_exclusions; }
      set { m_exclusions = value; }
    }

    /// <summary>
    /// Gets or sets the list only drivers.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant)]
    public virtual AUDriverList ListOnlyDrivers
    {
      get { return m_listOnlyDrivers; }
      set { m_listOnlyDrivers = value; }
    }

    /// <summary>
    /// Gets drivers including list only.
    /// </summary>
    public virtual AUDriverList DriversWithListOnly
    {
      get
      {
        if (ListOnlyDrivers != null && ListOnlyDrivers.Items != null)
        {
          AUDriverList driverList = new AUDriverList();
          driverList.Items.AddRange(Drivers.Items);
          driverList.Items.AddRange(ListOnlyDrivers.Items);
          driverList.Items.Sort((x, y) => x.DriverID.CompareTo(y.DriverID));

          return driverList;
        }

        return Drivers;
      }
    }

    /// <summary>
    /// List of cars on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant)]
    public virtual AUCarList Cars
    {
      get { return m_cars; }
      set { m_cars = value; }
    }

    /// <summary>
    /// List of drivers on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant)]
    public virtual AUDriverList Drivers
    {
      get { return m_drivers; }
      set { m_drivers = value; }
    }

    /// <summary>
    /// Number of drivers on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int NumOfDrivers
    {
      get { return Drivers.Count; }
    }

    /// <summary>
    /// Number of excluded drivers on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int NumOfExclusions
    {
      get { return Exclusions.Count; }
    }

    /// <summary>
    /// Number of list only drivers on the policy
    /// </summary>
    public virtual int NumOfListOnlyDrivers
    {
      get { return (ListOnlyDrivers != null && ListOnlyDrivers.Items != null) ? ListOnlyDrivers.Count : 0; }
    }

    /// <summary>
    /// Number of cars on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int NumOfCars
    {
      get { return Cars.Count; }
    }

    /// <summary>
    /// Full tort coverage
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FullTort
    {
      get { return m_fullTort; }
      set { m_fullTort = value; }
    }

    /// <summary>
    /// Total ATPA fee on teh policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double ATPAFee
    {
      get { return m_aTPAFee; }
      set { m_aTPAFee = value; }
    }

    /// <summary>
    /// Collection fee
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double CollectionFee
    {
      get { return m_collectionFee; }
      set { m_collectionFee = value; }
    }

    /// <summary>
    /// Law enforcement fee
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double LawEnforceFee
    {
      get { return m_lawEnforceFee; }
      set { m_lawEnforceFee = value; }
    }

    /// <summary>
    /// Municipal tax amount
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double MunicipalTax
    {
      get { return m_municipalTax; }
      set { m_municipalTax = value; }
    }

    /// <summary>
    /// Municipal tax rate (percentage)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double MunicipalTaxRate
    {
      get { return m_municipalTaxRate; }
      set { m_municipalTaxRate = value; }
    }

    /// <summary>
    /// Sercurity verification fee
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double SecurityVerificationFee
    {
      get { return m_securityVerificationFee; }
      set { m_securityVerificationFee = value; }
    }

    /// <summary>
    /// Stamp fee
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double StampFee
    {
      get { return m_stampFee; }
      set { m_stampFee = value; }
    }

    /// <summary>
    /// State tax amount
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double StateTax
    {
      get { return m_stateTax; }
      set { m_stateTax = value; }
    }

    /// <summary>
    /// State tax rate (percentage)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double StateTaxRate
    {
      get { return m_stateTaxRate; }
      set { m_stateTaxRate = value; }
    }

    /// <summary>
    /// Tax amount on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double Tax
    {
      get { return m_tax; }
      set { m_tax = value; }
    }

    /// <summary>
    /// Uninsured motorists fee
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double UninsMotorFee
    {
      get { return m_uninsMotorFee; }
      set { m_uninsMotorFee = value; }
    }

    /// <summary>
    /// Used for testing purposes (the auto-rate utility)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool AutoRate
    {
      get { return m_autoRate; }
      set { m_autoRate = value; }
    }

    /// <summary>
    /// Are the coverages done per vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CoveragesByCar
    {
      get { return m_coveragesByCar; }
      set { m_coveragesByCar = value; }
    }

    /// <summary>
    /// How many drivers have been deleted off this policy? This variable
    /// is used for compatibility with the Winders storage system.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int DeletedDriverCount
    {
      get { return m_deletedDriverCount; }
      set { m_deletedDriverCount = value; }
    }

    /// <summary>
    /// How many excluded drivers have been deleted off this policy? This variable
    /// is used for compatibility with the Winders storage system.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int DeletedExclusionCount
    {
      get { return m_deletedExclusionCount; }
      set { m_deletedExclusionCount = value; }
    }

    /// <summary>
    /// How many miscellaneous premiums have been deleted off this policy? This variable
    /// is used for compatibility with the Winders storage system.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int DeletedMiscPremiumCount
    {
      get { return m_deletedMiscPremiumCount; }
      set { m_deletedMiscPremiumCount = value; }
    }

    /// <summary>
    /// Couldn't tell you what this variable does even if you paid me. This variable
    /// is used for compatibility with the Winders storage system.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int DeletedUnitCount
    {
      get { return m_deletedUnitCount; }
      set { m_deletedUnitCount = value; }
    }

    /// <summary>
    /// This variable is used for compatibility with the Winders storage system.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int DOSCompanyID
    {
      get { return m_dOSCompanyID; }
      set { m_dOSCompanyID = value; }
    }

    /// <summary>
    /// Amount FR-44 fee on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double FR44Fee
    {
      get { return m_fR44Fee; }
      set { m_fR44Fee = value; }
    }

    /// <summary>
    /// Payment method used; standard/pif/eft. Currently only used 
    /// in the LA TWE, as of Nov 2010.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20, EnumerationType = typeof(PaymentMethod))]
    public virtual PaymentMethod PaymentMethod
    {
      get { return m_paymentMethod; }
      set { m_paymentMethod = value; }
    }

    /// <summary>
    /// Apply paperless discount?  
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool PaperlessDiscount
    {
      get { return m_paperlessDiscount; }
      set
      {
        m_paperlessDiscount = value;
        foreach (AUDriver driver in Drivers)
          driver.PaperlessDiscount = value;
      }
    }

    /// <summary>
    /// The total number of non-rated residents living in the household.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int TotalResidentsInHousehold
    {
      get { return m_totalResidentsInHousehold; }
      set { m_totalResidentsInHousehold = value; }
    }

    /// <summary>
    /// The total number of non-rated residents living in the household
    /// that are excluded from PIP.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int NumOfOtherResidentsExcludedFromPIP
    {
      get { return m_numOfOtherResidentsExcludedFromPIP; }
      set { m_numOfOtherResidentsExcludedFromPIP = value; }
    }

    #endregion Public Properties

    #region Constructors and Destructors
    /// <summary>
    /// Constructor. Allows you to pass in an initalization delegate.
    /// </summary>
    /// <param name="initializeMethod">An initialization delegate that gets
    /// called at the end of the constructor.</param>
    public AUPolicy(PolicyInitializeCallback initializeMethod)
      : base(initializeMethod)
    {
      InitializePolicy();
    }

    /// <summary>
    /// Total premium applied to the policy during rating.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public override double TotalPremium
    {
      get
      {
        // If there is no exclusioncode we don't want to mess with the way this field works.  That way it is still
        // compatible with any other product that is currently using an AUPolicy and a totalpremium.
        if (this.ExclusionCode == (int)ExclusionCodes.None)
          return m_totalPremium;
        else
          return CalculateTotalPremiumWithExclusionCode();
      }
      set { m_totalPremium = value; }
    }

    /// <summary>
    /// The Prior Medical Carrier Name.  
    /// This is not applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public string PriorPIPMedicalCarrierName
    {
      get { return m_priorPIPMedicalCarrierName; }
      set { m_priorPIPMedicalCarrierName = value; }
    }

    /// <summary>
    /// The Prior Work Loss Carrier Name. 
    /// This is not applicable in most states.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public string PriorPIPWorkLossCarrierName
    {
      get { return m_priorPIPWorkLossCarrierName; }
      set { m_priorPIPWorkLossCarrierName = value; }
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public AUPolicy()
      : this(InsuranceLine.PersonalAuto)
    {
    }

    /// <summary>
    /// Overriden default constructor 
    /// </summary>
    /// <param name="insuranceLine">Line of insurance</param>
    public AUPolicy(InsuranceLine insuranceLine)
      : base()
    {
      InitializePolicy(insuranceLine);
    }
    #endregion Constructors and Destructors

    #region Helper Methods
    /// <summary>
    /// Initializes the sub-objects within the policy object
    /// </summary>
    public override void InitializePolicy()
    {
      InitializePolicy(InsuranceLine.PersonalAuto);
    }

    /// <summary>
    /// Companion HOPolicy RecordID
    /// Used to store the linked HO Policy 
    /// </summary>
    public int CompanionHOPolicyId
    {
      get { return m_companionHOPolicyId; }
      set { m_companionHOPolicyId = value; }
    }

    private Guid m_companionHOPolicyGuid;
    /// <summary>
    /// Companion HOPolicy PolicyUID
    /// Used to store the HOPolicy PolicyUID Record to identify 
    /// the Companion policy before it's been saved.
    /// Not saved in database; once its saved the RecordID can be used.
    /// </summary>
    public Guid CompanionHOPolicyGuid
    {
      get { return m_companionHOPolicyGuid; }
      set { m_companionHOPolicyGuid = value; }
    }

    /// <summary>
    /// Initialize sub-objects within the policy object.
    /// </summary>
    /// <param name="insuranceLine"></param>
    public void InitializePolicy(InsuranceLine insuranceLine)
    {
      base.InitializePolicy();
      Cars = new AUCarList();
      Drivers = new AUDriverList();
      Exclusions = new AUDriverList();
      ListOnlyDrivers = new AUDriverList();

      // these are required for the database to properly recognize which
      // residences and people go with the policy
      MailingAddress.PolicyType = insuranceLine;
      LineOfInsurance = insuranceLine;
    }

    /// <summary>
    /// Calculates and sets the individual misc premium amounts for the policy
    /// </summary>
    public virtual void CalculateTotalUnitMiscPremiums()
    {
      for (int count = 0; count < this.NumOfMiscPremiums; count++)
      {
        if (this.MiscPremiums[count].ApplyToVehicle)
        {
          this.MiscPremiums[count].PremiumAmount = 0;
          for (int unitCount = 0; unitCount < this.NumOfCars; unitCount++)
            this.MiscPremiums[count].PremiumAmount = this.MiscPremiums[count].PremiumAmount + this.MiscPremiums[count].Amount;
        }

        if (this.MiscPremiums[count].ApplyToDriver)
        {
          this.MiscPremiums[count].PremiumAmount = 0;
          for (int unitCount = 0; unitCount < this.NumOfDrivers; unitCount++)
            this.MiscPremiums[count].PremiumAmount = this.MiscPremiums[count].PremiumAmount + this.MiscPremiums[count].Amount;
        }
      }
    }

    /// <summary>
    /// Copies specific pieces of information from the driver whose relation is insured
    /// to the insured object of the policy
    /// </summary>
    public void CopyInsuredDriverInfoToInsured()
    {
      AURateLib rateLib = new AURateLib(this);
      AUDriver insuredDriver = rateLib.GetInsuredDriver();
      AUDriver insured = (AUDriver)Insured;
      if (insuredDriver != null)
      {
        insured.FirstName = insuredDriver.FirstName;
        insured.MiddleName = insuredDriver.MiddleName;
        insured.LastName = insuredDriver.LastName;
        insured.Address1 = insuredDriver.Address1;
        insured.Address2 = insuredDriver.Address2;
        insured.City = insuredDriver.City;
        insured.State = insuredDriver.State;
        insured.ZipCode = insuredDriver.ZipCode;
        insured.Suffix = insuredDriver.Suffix;
        insured.SSN = insuredDriver.SSN;
        insured.DOB = insuredDriver.DOB;
        insured.CellPhone = insuredDriver.CellPhone;
        insured.WorkPhone = insuredDriver.WorkPhone;
        insured.WorkPhoneExt = insuredDriver.WorkPhoneExt;
        insured.Phone = insuredDriver.Phone;
        insured.FaxNumber = insuredDriver.FaxNumber;
        insured.EmailAddress = insuredDriver.EmailAddress;
        insured.Marital = insuredDriver.Marital;
        insured.PriorStreetNumber = insuredDriver.PriorStreetNumber;
        insured.PriorStreetName = insuredDriver.PriorStreetName;
        insured.PriorStreetType = insuredDriver.PriorStreetType;
        insured.PriorApartmentNumber = insuredDriver.PriorApartmentNumber;
        insured.PriorCity = insuredDriver.PriorCity;
        insured.PriorState = insuredDriver.PriorState;
        insured.PriorZipCode = insuredDriver.PriorZipCode;
        //peh-put back in when i do the OS reporting work order, insured.ResidencyStatus = insuredDriver.ResidencyStatus;
        //insured.ResidencyType = insuredDriver.ResidencyType;
        insured.NativeLanguage = insuredDriver.NativeLanguage;
        insured.NoEmail = insuredDriver.NoEmail;
        insured.NoPhone = insuredDriver.NoPhone;
        insured.DeclinedEmail = insuredDriver.DeclinedEmail;
        insured.Sex = insuredDriver.Sex;
        insured.Gender = insuredDriver.Gender;
        insured.CoGender = insuredDriver.CoGender;
      }
    }

    /// <summary>
    /// Copies specific pieces of information from the insured object of the policy
    /// to the driver whose relation is insured
    /// </summary>
    public void CopyInsuredInfoToInsuredDriver()
    {
      AURateLib rateLib = new AURateLib(this);
      AUDriver insuredDriver = rateLib.GetInsuredDriver();
      AUDriver insured = (AUDriver)Insured;
      if (insuredDriver != null)
      {
        insuredDriver.FirstName = insured.FirstName;
        insuredDriver.MiddleName = insured.MiddleName;
        insuredDriver.LastName = insured.LastName;
        insuredDriver.Address1 = insured.Address1;
        insuredDriver.Address2 = insured.Address2;
        insuredDriver.City = insured.City;
        insuredDriver.State = insured.State;
        insuredDriver.ZipCode = insured.ZipCode;
        insuredDriver.Suffix = insured.Suffix;
        insuredDriver.SSN = insured.SSN;
        insuredDriver.DOB = insured.DOB;
        insuredDriver.CellPhone = insured.CellPhone;
        insuredDriver.WorkPhone = insured.WorkPhone;
        insuredDriver.WorkPhoneExt = insured.WorkPhoneExt;
        insuredDriver.Phone = insured.Phone;
        insuredDriver.FaxNumber = insured.FaxNumber;
        insuredDriver.EmailAddress = insured.EmailAddress;
        insuredDriver.Marital = insured.Marital;
        insuredDriver.PriorStreetNumber = insured.PriorStreetNumber;
        insuredDriver.PriorStreetName = insured.PriorStreetName;
        insuredDriver.PriorStreetType = insured.PriorStreetType;
        insuredDriver.PriorApartmentNumber = insured.PriorApartmentNumber;
        insuredDriver.PriorCity = insured.PriorCity;
        insuredDriver.PriorState = insured.PriorState;
        insuredDriver.PriorZipCode = insured.PriorZipCode;
        //left out on purpose because the insured is missing this info as of 1/2011, peh - insuredDriver.ResidencyStatus = insured.ResidencyStatus;
        //left out on purpose because the insured is missing this info as of 1/2011, peh - insuredDriver.ResidencyType = insured.ResidencyType;
        insuredDriver.NativeLanguage = insured.NativeLanguage;
        insuredDriver.NoEmail = insured.NoEmail;
        insuredDriver.NoPhone = insured.NoPhone;
        insuredDriver.DeclinedEmail = insured.DeclinedEmail;
        insuredDriver.Sex = insured.Sex;
      }
    }

    /// <summary>
    /// Finds any property of type double that ends with "PREMIUM", and sets
    /// it to 0.0. This overrides the base ZeroPremiums() from InsPolicy so that
    /// we can call the ZeroPremiums() method of the Discounts, StateEndorsements, 
    /// and ISOEndorsements objects.
    /// </summary>
    public override void ZeroPremiums()
    {
      base.ZeroPremiums();
      Cars.ZeroPremiums();
    }

    public override double CalculateFees()
    {
      double result = base.CalculateFees();
      result += SR22Fee + FR44Fee + CollectionFee + LawEnforceFee + MunicipalTax + ATPAFee + StampFee + Tax + StateTax + UninsMotorFee + SecurityVerificationFee;
      foreach (AUCar car in Cars)
      {
        result += car.RecoupmentFee + car.AllocationFee;
      }
      return result;
    }

    /// <summary>
    /// Loops through all the cars on a policy and combines their subtotal premiums to come up with a total policy premium.
    /// The premiums are set to look at exclusioncode already so all we have to do is get the subtotal for each car.
    /// Whether the premium is 0 or not should handle itself.
    /// </summary>
    /// <returns>Returns the total premium for this policy including considerations for excluded coverages.</returns>
    public virtual double CalculateTotalPremiumWithExclusionCode()
    {
      double result = 0.00;

      foreach (AUCar car in this.Cars)
      {
        result += car.SubTotalPremium;
      }

      return result;
    }

    #endregion Helper Methods
  }
}
