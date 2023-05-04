using System.Collections.Generic;
using System;
using System.Xml.Serialization;
using System.ComponentModel;
using static TurboRater.Insurance.HO.HOConstants;

namespace TurboRater.Insurance.HO
{
  /// <summary>
  /// Mortgagee Suffixes.
  /// </summary>
  public enum MortgageeSuffixes
  {
    [Description("None")]
    None,
    [Description("ISAOA")]
    ISAOA,
    [Description("ISAOAATIMA")]
    ISAOAATIMA,
    [Description("ATIMA")]
    ATIMA
  }

  /// <summary>
  /// Heating type.
  /// </summary>
  public enum HeatingType
  {
    [Description("None")]
    None,
    [Description("Baseboard Heater")]
    BaseboardHeater,
    [Description("Ceiling Heater")]
    CeilingHeater,
    [Description("Central Electric")]
    CentralElectric,
    [Description("Central Gas")]
    CentralGas,
    [Description("Open Flame Source")]
    OpenFlameSource,
    [Description("Permanent Space Heater")]
    PermanentSpaceHeater,
    [Description("Portable Space Heater")]
    PortableSpaceHeater,
    [Description("Wood Burning Stove")]
    WoodBurningStove,
    [Description("Other")]
    Other
  }

  /// <summary>
  /// Secondary heating type.
  /// </summary>
  public enum SecondaryHeatingType
  {
    [Description("None")]
    None,
    [Description("Permanent Space Heater")]
    PermanentSpaceHeater,
    [Description("Portable Space Heater")]
    PortableSpaceHeater,
    [Description("Wood Burning Stove")]
    WoodBurningStove
  }

  /// <summary>
  /// Swimminh pool type.
  /// </summary>
  public enum SwimmingPoolType
  {
    [Description("Above Ground")]
    AboveGround,
    [Description("In Ground")]
    InGround
  }

  public enum CityLimitType
  {
    [Description("Inside")]
    Inside,
    [Description("Outside")]
    Outside
  }
  /// current quality of home
  /// </summary>
  public enum HomeQuality
  {
    /// <summary>
    /// poor quality
    /// </summary>
    Poor,
    /// <summary>
    /// good quality
    /// </summary>
    Good,
    /// <summary>
    /// excellent quality
    /// </summary>
    Excellent
  };

  /// <summary>
  /// A homeowners policy. This links to endorsements, discounts, insured, etc.
  /// </summary>
  [Serializable]
  public class HOPolicy : PropertyPolicy
  {

    /// <summary>
    /// constructor. Allows you to pass in an initalization delegate.
    /// </summary>
    /// <param name="initializeMethod">An initialization delegate that gets
    /// called at the end of the constructor.</param>
    public HOPolicy(PolicyInitializeCallback initializeMethod) : base(initializeMethod)
    {
      InitializePolicy();
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public HOPolicy() : base()
    {
      InitializePolicy();
    }

    /// <summary>
    /// Initializes the sub-objects within the policy object
    /// </summary>
    public override void InitializePolicy()
    {
      base.InitializePolicy();
      Discounts = new HODiscounts();
      ISOEndorsements = new HOISOEndorsements();
      PersonalProperty = new List<PersonalProperty>();
      TXEndorsements = new HOTXEndorsements();
      Watercraft = new List<Watercraft>();
      this.Quote = new HOQuote();

      MailingAddress.PolicyType = InsuranceLine.Homeowners;
      InsuredProperty.PolicyType = InsuranceLine.Homeowners;
      OtherInsured.PolicyType = InsuranceLine.Homeowners;
      LineOfInsurance = InsuranceLine.Homeowners;
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
      Discounts.ZeroPremiums();
      ISOEndorsements.ZeroPremiums();
    }


    /// <summary>
    /// Policy Form actually rated by the company
    /// </summary>
    public virtual string CoForm
    {
      get { return m_coForm; }
      set { m_coForm = value; }
    }

    /// <summary>
    /// Has the insured property's heating system been updated?
    /// </summary>
    public virtual bool HeatingUpdate
    {
      get { return m_heatingUpdate; }
      set { m_heatingUpdate = value; }
    }

    /// <summary>
    /// What level of update has been performed on
    /// the insured property's heating system?
    /// </summary>
    public virtual UpdateLevel HeatingUpdateLevel
    {
      get { return m_heatingUpdateLevel; }
      set { m_heatingUpdateLevel = value; }
    }

    /// <summary>
    /// Companion AUPolicy RecordID
    /// Used to store the linked HO Policy 
    /// </summary>
    public int CompanionAUPolicyId  
    {
      get { return m_companionAUPolicyId; }
      set { m_companionAUPolicyId = value; }
    }

    private Guid m_companionAUPolicyGuid;

    /// <summary>
    /// Companion AUPolicy PolicyUID
    /// Used to store the linked UID Record to identify 
    /// the Companion policy before it's been saved.
    /// Not saved in database; once its saved the RecordID can be used.
    /// </summary>
    public Guid CompanionAUPolicyGuid
    {
      get { return m_companionAUPolicyGuid; }
      set { m_companionAUPolicyGuid = value; }
    }

    /// <summary>
    /// Has the insured property's electrical system been update? 
    /// </summary>
    public virtual bool ElectricalUpdate
    {
      get { return m_electricalUpdate; }
      set { m_electricalUpdate = value; }
    }

    /// <summary>
    /// What level of update has been performed on
    /// the insured property's electrical system
    /// </summary>
    public virtual UpdateLevel ElectricalUpdateLevel
    {
      get { return m_electricalUpdateLevel; }
      set { m_electricalUpdateLevel = value; }
    }

    /// <summary>
    /// Has the insured property's roof been updated? 
    /// </summary>
    public virtual bool RoofingUpdate
    {
      get { return m_roofingUpdate; }
      set { m_roofingUpdate = value; }
    }

    /// <summary>
    /// What level of update has been performed on
    /// the insured property's roof?
    /// </summary>
    public virtual UpdateLevel RoofingUpdateLevel
    {
      get { return m_roofingUpdateLevel; }
      set { m_roofingUpdateLevel = value; }
    }

    /// <summary>
    /// Has the insured property's plumbing been updated?
    /// </summary>
    public virtual bool PlumbingUpdate
    {
      get { return m_plumbingUpdate; }
      set { m_plumbingUpdate = value; }
    }

    /// <summary>
    /// What level of update has been performed
    /// on the insured property's plumbing?
    /// </summary>
    public virtual UpdateLevel PlumbingUpdateLevel
    {
      get { return m_plumbingUpdateLevel; }
      set { m_plumbingUpdateLevel = value; }
    }

    /// <summary>
    /// What year was the heating system updated? 
    /// </summary>
    public virtual int HeatingUpdateYear
    {
      get { return m_heatingUpdateYear; }
      set { m_heatingUpdateYear = value; }
    }

    /// <summary>
    /// What year was the electrical system updated? 
    /// </summary>
    public virtual int ElectricalUpdateYear
    {
      get { return m_electricalUpdateYear; }
      set { m_electricalUpdateYear = value; }
    }

    /// <summary>
    /// What year was the roof updated? 
    /// </summary>
    public virtual int RoofingUpdateYear
    {
      get { return m_roofingUpdateYear; }
      set { m_roofingUpdateYear = value; }
    }

    /// <summary>
    /// What year was the plumbing updated? 
    /// </summary>
    public virtual int PlumbingUpdateYear
    {
      get { return m_plumbingUpdateYear; }
      set { m_plumbingUpdateYear = value; }
    }

    /// <summary>
    /// Does the insured property have a hail resistant roof?
    /// </summary>
    public virtual bool HailResistantRoof
    {
      get { return m_hailResistantRoof; }
      set { m_hailResistantRoof = value; }
    }

    /// <summary>
    /// Total square footage of the property. 
    /// </summary>
    public virtual int SquareFootage
    {
      get { return m_squareFootage; }
      set { m_squareFootage = value; }
    }

    /// <summary>
    /// The number of feet the insured property is to the closest fire hydrant. 
    /// </summary>
    public virtual int FeetToHydrant
    {
      get { return m_feetToHydrant; }
      set { m_feetToHydrant = value; }
    }

    /// <summary>
    /// The number of miles the insured property is to the closest fire station. 
    /// </summary>
    public virtual int MilesToFireStation
    {
      get { return m_milesToFireStation; }
      set { m_milesToFireStation = value; }
    }

    /// <summary>
    /// The original purchase price of the insured property.
    /// </summary>
    public virtual int PurchasePrice
    {
      get { return m_purchasePrice; }
      set { m_purchasePrice = value; }
    }

    /// <summary>
    /// The original purchase date of the insured property.
    /// </summary>
    public virtual DateTime PurchaseDate
    {
      get { return m_purchaseDate; }
      set { m_purchaseDate = value; }
    }

    /// <summary>
    /// The insured proerty's number of stories 
    /// </summary>
    public virtual int NumberOfStories
    {
      get { return m_numberOfStories; }
      set { m_numberOfStories = value; }
    }

    /// <summary>
    /// The number of stories in the insured building
    /// </summary>
	  public virtual StoryType StoryType
    {
      get { return m_storyType; }
      set { m_storyType = value; }
    }

    /// <summary>
    /// Number of families insured property is designed to accomodate
    /// </summary>
    public virtual int NumberOfFamilies
    {
      get { return m_numberOfFamilies; }
      set { m_numberOfFamilies = value; }
    }

    /// <summary>
    /// Number of full baths
    /// </summary>
    public virtual int NumberOfFullBaths
    {
      get { return m_numberOfFullBaths; }
      set { m_numberOfFullBaths = value; }
    }

    /// <summary>
    /// Number of 3/4 Baths
    /// </summary>
    public virtual int NumberOfThreeQuarterBaths
    {
      get { return m_numberOfThreeQuarterBaths; }
      set { m_numberOfThreeQuarterBaths = value; }
    }

    /// <summary>
    /// Number of half baths
    /// </summary>
    public virtual int NumberOfHalfBaths
    {
      get { return m_numberOfHalfBaths; }
      set { m_numberOfHalfBaths = value; }
    }

    /// <summary>
    /// Is the property address the same as the mailing address?
    /// </summary>
    public bool PropertyAddressSame
    {
      get { return m_propertyAddressSame; }
      set { m_propertyAddressSame = value; }
    }

    /// <summary>
    /// Amount of other structures coverage
    /// </summary>
    public virtual int OtherStructuresAmt
    {
      get { return m_otherStructuresAmt; }
      set { m_otherStructuresAmt = value; }
    }

    /// <summary>
    /// Premium rated for other structures coverage
    /// </summary>
    public virtual double OtherStructuresPremium
    {
      get { return m_otherStructuresPremium; }
      set { m_otherStructuresPremium = value; }
    }

    /// <summary>
    /// Deductible #1 (Wind/Hail)
    /// </summary>
    public virtual string Deductible1
    {
      get { return m_deductible1; }
      set { m_deductible1 = value; }
    }

    /// <summary>
    /// Premium rated for Deductible1
    /// </summary>
    public virtual double Deductible1Premium
    {
      get { return m_deductible1Premium; }
      set { m_deductible1Premium = value; }
    }

    /// <summary>
    /// Deductible #2 (All Other)
    /// </summary>
    public virtual string Deductible2
    {
      get { return m_deductible2; }
      set { m_deductible2 = value; }
    }

    /// <summary>
    /// Premium rated for Deductible2
    /// </summary>
    public virtual double Deductible2Premium
    {
      get { return m_deductible2Premium; }
      set { m_deductible2Premium = value; }
    }

    /// <summary>
    /// Deductible #3 
    /// </summary>
    public virtual string Deductible3
    {
      get { return m_deductible3; }
      set { m_deductible3 = value; }
    }

    /// <summary>
    /// Premium rated for deductible #3
    /// </summary>
    public virtual double Deductible3Premium
    {
      get { return m_deductible3Premium; }
      set { m_deductible3Premium = value; }
    }

    /// <summary>
    /// Company level deductible 1 variable.
    /// </summary>
    public virtual string CoDeductible1
    {
      get { return m_coDeductible1; }
      set { m_coDeductible1 = value; }
    }

    /// <summary>
    /// Company level deductible 1 type variable.
    /// </summary>
    public virtual string CoDeductible1Type
    {
      get { return m_coDeductible1Type; }
      set { m_coDeductible1Type = value; }
    }

    /// <summary>
    /// Company level deductible 2 variable.
    /// </summary>
    public virtual string CoDeductible2
    {
      get { return m_coDeductible2; }
      set { m_coDeductible2 = value; }
    }

    /// <summary>
    /// Company level deductible 2 type variable.
    /// </summary>
    public virtual string CoDeductible2Type
    {
      get { return m_coDeductible2Type; }
      set { m_coDeductible2Type = value; }
    }

    /// <summary>
    /// Company level deductible 3 variable.
    /// </summary>
    public virtual string CoDeductible3
    {
      get { return m_coDeductible3; }
      set { m_coDeductible3 = value; }
    }

    /// <summary>
    /// Company level deductible 3 type variable.
    /// </summary>
    public virtual string CoDeductible3Type
    {
      get { return m_coDeductible3Type; }
      set { m_coDeductible3Type = value; }
    }

    /// <summary>
    /// Number of additional residences owned by insured
    /// </summary>
    public virtual int NumAdditionalResidences
    {
      get { return m_numAdditionalResidences; }
      set { m_numAdditionalResidences = value; }
    }

    /// <summary>
    /// Premium rated for additional residences
    /// </summary>
    public virtual double AdditionalResidencesPremium
    {
      get { return m_additionalResidencesPremium; }
      set { m_additionalResidencesPremium = value; }
    }

    /// <summary>
    /// Liability limit for the policy
    /// </summary>
    public virtual int LiabLimit
    {
      get { return m_liabLimit; }
      set { m_liabLimit = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual int CoLiabLimit
    {
      get { return m_coLiabLimit; }
      set { m_coLiabLimit = value; }
    }

    /// <summary>
    /// Premium rated for liability coverage
    /// </summary>
    public virtual double LiabPremium
    {
      get { return m_liabPremium; }
      set { m_liabPremium = value; }
    }

    /// <summary>
    /// Medical payments limit for the policy
    /// </summary>
    public virtual int MedPayLimit
    {
      get { return m_medPayLimit; }
      set { m_medPayLimit = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual int CoMedPayLimit
    {
      get { return m_coMedPayLimit; }
      set { m_coMedPayLimit = value; }
    }

    /// <summary>
    /// The type of occupancy of the home. Can be owner, tenant, etc.
    /// </summary>
    public virtual string Occupancy
    {
      get { return m_occupancy; }
      set { m_occupancy = value; }
    }

    /// <summary>
    /// Is the dwelling fire resistive, semi-fire resistive, or sprinklered?
    /// </summary>
    public virtual bool FireResistive
    {
      get { return m_fireResistive; }
      set { m_fireResistive = value; }
    }

    /// <summary>
    /// Does the dwelling have a shared entrance?
    /// </summary>
    public virtual bool SharedEntrance
    {
      get { return m_sharedEntrance; }
      set { m_sharedEntrance = value; }
    }

    /// <summary>
    /// Amount of coverage for loss of use
    /// </summary>
    public virtual int LossOfUseAmt
    {
      get { return m_lossOfUseAmt; }
      set { m_lossOfUseAmt = value; }
    }

    /// <summary>
    /// Premium rated for loss of use coverage
    /// </summary>
    public virtual double LossOfUsePremium
    {
      get { return m_lossOfUsePremium; }
      set { m_lossOfUsePremium = value; }
    }

    /// <summary>
    /// Undeviated and unreduced base premium
    /// </summary>
    public virtual double UndeviatedUnreducedBase
    {
      get { return m_undeviatedUnreducedBase; }
      set { m_undeviatedUnreducedBase = value; }
    }

    /// <summary>
    /// Deviated and unreduced base premium
    /// </summary>
    public virtual double DeviatedUnreducedBase
    {
      get { return m_deviatedUnreducedBase; }
      set { m_deviatedUnreducedBase = value; }
    }

    /// <summary>
    /// Deviated and reduced base premium
    /// </summary>
    public virtual double DeviatedReducedBase
    {
      get { return m_deviatedReducedBase; }
      set { m_deviatedReducedBase = value; }
    }

    /// <summary>
    /// Is the dwelling an owner occupied duplex?
    /// </summary>
    public virtual bool OwnerOccupiedDuplex
    {
      get { return m_ownerOccupiedDuplex; }
      set { m_ownerOccupiedDuplex = value; }
    }

    /// <summary>
    /// Discounts object associated with the policy
    /// </summary>
    public virtual HODiscounts Discounts
    {
      get { return m_discounts; }
      set { m_discounts = value; }
    }

    /// <summary>
    /// ISO endorsements object associated with the policy
    /// </summary>
    public virtual HOISOEndorsements ISOEndorsements
    {
      get { return m_iSOEndorsements; }
      set { m_iSOEndorsements = value; }
    }

    /// <summary>
    /// Personal property list. Used by endorsement HO-160
    /// </summary>
    /// <seealso cref="HOStateEndorsements.HO160">HOStateEndorsements.HO160</seealso>
    public virtual List<PersonalProperty> PersonalProperty
    {
      get { return m_personalProperty; }
      set { m_personalProperty = value; }
    }

    /// <summary>
    /// Watercraft list. Used by endorsement HO-215
    /// </summary>
    public virtual List<Watercraft> Watercraft
    {
      get { return m_watercraft; }
      set { m_watercraft = value; }
    }

    /// <summary>
    /// Texas only state endorsements that aren't ISO
    /// </summary>
    public HOTXEndorsements TXEndorsements
    {
      get { return m_txEndorsements; }
      set { m_txEndorsements = value; }
    }

    /// <summary>
    /// Has MedPay coverage been requested? 
    /// </summary>
		public bool MedPay
    {
      get { return m_medPay; }
      set { m_medPay = value; }
    }

    /// <summary>
    /// Tagged field storage of company data.
    /// </summary>
    public string CompanyDataString
    {
      get { return m_companyData; }
      set { m_companyData = value; }
    }

    /// <summary>
    /// Tagged field storage of company endorsements.
    /// </summary>
    public string CompanyEndorsementData
    {
      get { return m_companyEndorsementData; }
      set { m_companyEndorsementData = value; }
    }

    /// <summary>
    /// Tagged field storage of company credits.
    /// </summary>
    public string CompanyCreditsData
    {
      get { return m_companyCreditsData; }
      set { m_companyCreditsData = value; }
    }

    /// <summary>
    /// List of pay plans returned by the realtime rating system.
    /// </summary>
    public List<PayPlan> PayPlans
    {
      get { return m_payPlans; }
      set { m_payPlans = value; }
    }

    /// <summary>
    /// Finds the selected pay plan in the list.  If there is no selected pay plan, it returns the default.
    /// If there is also no default, it returns the first plan in the list.  If there are no pay plans, it returns null.
    /// </summary>
    [XmlIgnore]
    public PayPlan SelectedPayPlan
    {
      get
      {
        PayPlan plan = PayPlans.Find(item => item.IsSelected);
        if (plan == null)
          plan = PayPlans.Find(item => item.IsDefault);
        if (plan == null && PayPlans.Count > 0)
          plan = PayPlans[0];
        return plan;
      }
    }

    /// <summary>
    /// Length of time the insured has lived at current address
    /// </summary>
    public virtual int InsuredResideTime
    {
      get { return m_insuredResideTime; }
      set { m_insuredResideTime = value; }
    }

    /// <summary>
    /// Returns company data as a specified type, if possible.
    /// </summary>
    /// <typeparam name="TData">The data type to return the value as.</typeparam>
    /// <param name="tagName">The tage name of the data to return.</param>
    /// <param name="defaultValue">The default value to return if the data is invalid for the selected type or if the tag is not found.</param>
    /// <returns>The company data value for the specified tag, converted to TData.</returns>
    public TData GetCompanyData<TData>(string tagName, TData defaultValue) where TData : IConvertible
    {
      string dataString = StringLib.GetTaggedFieldAsString2(CompanyDataString, tagName);
      if (dataString == null)
        return defaultValue;
      if (typeof(bool) == typeof(TData))
        return (TData)Convert.ChangeType(ITCConvert.ToBoolean(dataString, (bool)Convert.ChangeType(defaultValue, typeof(bool))), typeof(TData));
      if (typeof(string) == typeof(TData))
        return (TData)Convert.ChangeType(dataString, typeof(TData));
      if (typeof(DateTime) == typeof(TData))
        return (TData)Convert.ChangeType(ITCConvert.ToDateTime(dataString, (DateTime)Convert.ChangeType(defaultValue, typeof(DateTime))), typeof(TData));
      if (typeof(int) == typeof(TData))
        return (TData)Convert.ChangeType(ITCConvert.ToInt32(dataString, (int)Convert.ChangeType(defaultValue, typeof(int))), typeof(TData));
      if (typeof(double) == typeof(TData))
        return (TData)Convert.ChangeType(ITCConvert.ToDouble(dataString, (int)Convert.ChangeType(defaultValue, typeof(int))), typeof(TData));

      throw new Exception("GetCompanyData type not supported: " + typeof(TData).Name);
    }

    /// <summary>
    /// The quote
    /// </summary>
    public new HOQuote Quote
    {
      get { return base.Quote as HOQuote; }
      set { base.Quote = value; }
    }

    /// <summary>
    /// Warnings applied to the policy during rating
    /// </summary>
    public override MessageList Warnings
    {
      get { return base.Warnings; }
      set { base.Warnings = value; }
    }

    /// <summary>
    /// Errors applied to the policy during rating
    /// </summary>
    public override MessageList Errors
    {
      get { return base.Errors; }
      set { base.Errors = value; }
    }

    /// <summary>
    /// Discounts applied to the policy during rating. Includes all discounts 
    /// applied to the policy, regardless of scope.
    /// </summary>
    public override MessageList DiscountMessages
    {
      get { return base.DiscountMessages; }
      set { base.DiscountMessages = value; }
    }

    /// <summary>
    /// Surcharges applied to the policy during rating. Includes all surcharges
    /// applied to the policy, regardless of scope.
    /// </summary>
    public override MessageList SurchargeMessages
    {
      get { return base.SurchargeMessages; }
      set { base.SurchargeMessages = value; }
    }

    /// <summary>
    /// CoSurcharges applied to the policy during rating.
    /// </summary>
    public override MessageList CoSurchargeFees
    {
      get { return base.CoSurchargeFees; }
      set { base.CoSurchargeFees = value; }
    }

    /// <summary>
    /// The miscellaneous premiums associated with the policy
    /// </summary>
    public override MiscPremiumList MiscPremiums
    {
      get { return base.MiscPremiums; }
      set { base.MiscPremiums = value; }
    }

    /// <summary>
    /// The Mortgagee 1 suffix
    /// </summary>
		public MortgageeSuffixes MortgageeSuffix1
    {
      get { return m_mortgageeSuffix1; }
      set { m_mortgageeSuffix1 = value; }
    }

    /// <summary>
    /// The Mortgagee 2 suffix
    /// </summary>
		public MortgageeSuffixes MortgageeSuffix2
    {
      get { return m_mortgageeSuffix2; }
      set { m_mortgageeSuffix2 = value; }
    }

    /// <summary>
    /// Is mortgagee 1 the payor? 
    /// </summary>
		public bool BillMortgagee
    {
      get { return m_billMortgagee; }
      set { m_billMortgagee = value; }
    }

    /// <summary>
    /// Mortgagee 1 name
    /// </summary>
		public string MortgageeName1
    {
      get { return m_mortgageeName1; }
      set { m_mortgageeName1 = value; }
    }

    /// <summary>
    /// Mortgagee 2 name 
    /// </summary>
		public string MortgageeName2
    {
      get { return m_mortgageeName2; }
      set { m_mortgageeName2 = value; }
    }

    /// <summary>
    /// Mortgagee 1 address one 
    /// </summary>
		public string MortgageeAddressOne1
    {
      get { return m_mortgageeAddressOne1; }
      set { m_mortgageeAddressOne1 = value; }
    }

    /// <summary>
    /// Mortgagee 2 Address one
    /// </summary>
		public string MortgageeAddressOne2
    {
      get { return m_mortgageeAddressOne2; }
      set { m_mortgageeAddressOne2 = value; }
    }

    /// <summary>
    /// Mortgagee 1 address 2
    /// </summary>
		public string MortgageeAddressTwo1
    {
      get { return m_mortgageeAddressTwo1; }
      set { m_mortgageeAddressTwo1 = value; }
    }

    /// <summary>
    /// Mortgagee 2 address two
    /// </summary>
		public string MortgageeAddressTwo2
    {
      get { return m_mortgageeAddressTwo2; }
      set { m_mortgageeAddressTwo2 = value; }
    }

    /// <summary>
    /// Mortgagee 1 city
    /// </summary>
		public string MortgageeCity1
    {
      get { return m_mortgageeCity1; }
      set { m_mortgageeCity1 = value; }
    }

    /// <summary>
    /// Mortgagee 2 city
    /// </summary>
		public string MortgageeCity2
    {
      get { return m_mortgageeCity2; }
      set { m_mortgageeCity2 = value; }
    }

    /// <summary>
    /// Mortgagee 1 state
    /// </summary>
		public USState MortgageeState1
    {
      get { return m_mortgageeState1; }
      set { m_mortgageeState1 = value; }
    }

    /// <summary>
    /// Mortgagee 2 state
    /// </summary>
		public USState MortgageeState2
    {
      get { return m_mortgageeState2; }
      set { m_mortgageeState2 = value; }
    }

    /// <summary>
    /// Mortgagee 1 Zipcode
    /// </summary>
		public string MortgageeZip1
    {
      get { return m_mortgageeZip1; }
      set { m_mortgageeZip1 = value; }
    }

    /// <summary>
    /// Mortgagee 2 Zipcode
    /// </summary>
		public string MortgageeZip2
    {
      get { return m_mortgageeZip2; }
      set { m_mortgageeZip2 = value; }
    }

    /// <summary>
    /// Mortgagee 1 loan number
    /// </summary>
		public string MortgageeLoanNumber1
    {
      get { return m_mortgageeLoanNumber1; }
      set { m_mortgageeLoanNumber1 = value; }
    }

    /// <summary>
    /// Mortgagee 2 loan number
    /// </summary>
		public string MortgageeLoanNumber2
    {
      get { return m_mortgageeLoanNumber2; }
      set { m_mortgageeLoanNumber2 = value; }
    }

    /// <summary>
    /// The percentage of the dwelling amount that will be insured for contents. 
    /// </summary>
		public int ContentsPercent
    {
      get { return m_contentsPercent; }
      set { m_contentsPercent = value; }
    }

    /// <summary>
    /// The percentage of the dwelling amount that will be insured for loss of use. 
    /// </summary>
		public int LossOfUsePercent
    {
      get { return m_lossOfUsePercent; }
      set { m_lossOfUsePercent = value; }
    }

    /// <summary>
    /// The percentage of the dwelling amount that will be insured for other structures. 
    /// </summary>
    public int OtherStructuresPercent
    {
      get { return m_otherStructuresPercent; }
      set { m_otherStructuresPercent = value; }
    }
  
    /// <summary>
    /// The bridge Url returned by the company.  Should be set by the realtime modules.
    /// Ths property does not need to be saved.
    /// </summary>
    public string ThirdPartyQuoteUrl
    {
      get { return m_thirdPartyQuoteUrl; }
      set { m_thirdPartyQuoteUrl = value; }
    }

    /// <summary>
    /// The state this policy should be rated in.  Used for realtime rating, does not need to be stored.
    /// </summary>
    public USState RatingState
    {
      get { return m_ratingState; }
      set { m_ratingState = value; }
    }

    /// <summary>
    /// Indicates whether the quote needs to be re-rated for a pay plan change.  Set by the realtime module.
    /// This property does not need to be saved.
    /// </summary>
    public bool RequiresPayPlanRerate
    {
      get { return m_requiresPayPlanRerate; }
      set { m_requiresPayPlanRerate = value; }
    }

    /// <summary>
    /// Dwelling premium
    /// </summary>
    public double DwellingPremium
    {
      get { return m_dwellingPremium; }
      set { m_dwellingPremium = value; }
    }

    /// <summary>
    /// Contents Premium
    /// </summary>
    public double ContentsPremium
    {
      get { return m_contentsPremium; }
      set { m_contentsPremium = value; }
    }

    /// <summary>
    /// Med Pay Premium
    /// </summary>
    public double MedPayPremium
    {
      get { return m_medPayPremium; }
      set { m_medPayPremium = value; }
    }

    /// <summary>
    /// Inspection Fee
    /// </summary>
    public double InspectionFee
    {
      get { return m_inspectionFee; }
      set { m_inspectionFee = value; }
    }

    /// <summary>
    /// Managing General Agent Fee
    /// </summary>
    public double MGAFee
    {
      get { return m_mgaFee; }
      set { m_mgaFee = value; }
    }

    /// <summary>
    /// Emergency Management Preparedness and Assistance Trust Fund Fee
    /// </summary>
    public double EMPATFee
    {
      get { return m_empatFee; }
      set { m_empatFee = value; }
    }

    /// <summary>
    /// Florida Insurance Guaranty Association fee
    /// </summary>
    public double FIGAFee
    {
      get { return m_figaFee; }
      set { m_figaFee = value; }
    }

    /// <summary>
    /// Citizens Recoupment fee
    /// </summary>
    public double CitizensRecoupmentFee
    {
      get { return m_citizensRecoupmentFee; }
      set { m_citizensRecoupmentFee = value; }
    }

    /// <summary>
    /// Is this a bridge request? 
    /// </summary>
    public bool IsBridgeRequest
    {
      get { return m_isBridgeRequest; }
      set { m_isBridgeRequest = value; }
    }

    /// <summary>
    /// Property attribute for heating type
    /// </summary>
    public HeatingType HeatingType
    {
      get { return m_heatingType; }
      set { m_heatingType = value; }
    }

    /// <summary>
    /// Property attribute for secondary heating type
    /// </summary>
    public SecondaryHeatingType SecondaryHeatingType
    {
      get { return m_secondaryHeatingType; }
      set { m_secondaryHeatingType = value; }
    }

    /// <summary>
    /// Property attribute for foundation type
    /// </summary>
    public FoundationType FoundationType
    {
      get { return m_foundationType; }
      set { m_foundationType = value; }
    }

    /// <summary>
    /// Is there a vicious dog or history of dog bite at premises
    /// </summary>
    public bool ViciousDog
    {
      get { return m_viciousDog; }
      set { m_viciousDog = value; }
    }

    /// <summary>
    /// Specifies the specific form edition used for wind mitigation
    /// </summary>
    public WindMitigationForm WindMitigationForm
    {
      get { return m_windMitigationForm; }
      set { m_windMitigationForm = value; }
    }

    /// <summary>
    /// Denotes whether wind mitigation is applied
    /// </summary>
    public bool WindMitigation
    {
      get { return m_windMitigation; }
      set { m_windMitigation = value; }
    }

    /// <summary>
    /// Roof covering is compliant with FBC
    /// </summary>
    public RoofCovering RoofCovering
    {
      get { return m_roofCovering; }
      set { m_roofCovering = value; }
    }

    /// <summary>
    /// Type of attachment for the roof deck
    /// </summary>
    public RoofDeckAttachment RoofDeckAttachment
    {
      get { return m_roofDeckAttachment; }
      set { m_roofDeckAttachment = value; }
    }

    /// <summary>
    /// Type of roof-to=wall connection
    /// </summary>
    public RoofWallConnection RoofWallConnection
    {
      get { return m_roofWallConnection; }
      set { m_roofWallConnection = value; }
    }

    /// <summary>
    /// Secondary Water Resistance
    /// (Secondary layer to protect dwelling from water instrusion in
    /// the event of roof covering loss)
    /// </summary>
    public bool SecondaryWaterResistance
    {
      get { return m_secondaryWaterResistance; }
      set { m_secondaryWaterResistance = value; }
    }

    /// <summary>
    /// Type of protection on openings in exterior walls
    /// </summary>
    public OpeningProtection OpeningProtection
    {
      get { return m_openingProtection; }
      set { m_openingProtection = value; }
    }

    /// <summary>
    /// Class of terrain exposure
    /// </summary>
    public TerrainExposure TerrainExposure
    {
      get { return m_terrainExposure; }
      set { m_terrainExposure = value; }
    }

    /// <summary>
    /// Wind velocity per building code that structure should withstand
    /// </summary>
    public WindSpeed WindSpeed
    {
      get { return m_windSpeed; }
      set { m_windSpeed = value; }
    }

    /// <summary>
    /// Wind velocity per building code that structure is designed to withstand
    /// </summary>
    public WindDesign WindDesign
    {
      get { return m_windDesign; }
      set { m_windDesign = value; }
    }

    /// <summary>
    /// Type of internal pressure design
    /// </summary>
    public InternalPressureDesign InternalPressureDesign
    {
      get { return m_internalPressureDesign; }
      set { m_internalPressureDesign = value; }
    }

    /// <summary>
    /// Is property located in an area subject to wind-born debris
    /// </summary>
    public bool WindBornDebrisRegion
    {
      get { return m_windBornDebrisRegion; }
      set { m_windBornDebrisRegion = value; }
    }

    /// <summary>
    /// Property is located entirely over water
    /// </summary>
    public bool OverWater
    {
      get { return m_overWater; }
      set { m_overWater = value; }
    }

    /// <summary>
    /// Is the home currently undergoing construction?
    /// </summary>
    public bool UnderConstruction
    {
      get { return m_underConstruction; }
      set { m_underConstruction = value; }
    }

    /// <summary>
    /// Has any home policy been cancelled in the last 3 years?
    /// </summary>
    public bool HomePolicyCancelled
    {
      get { return m_homePolicyCancelled; }
      set { m_homePolicyCancelled = value; }
    }

    /// <summary>
    /// Does the property have a wood burning stove?
    /// </summary>
    public bool WoodBurningStove
    {
      get { return m_woodBurningStove; }
      set { m_woodBurningStove = value; }
    }

    /// <summary>
    /// Does the property have a swimming pool?
    /// </summary>
    public bool SwimmingPool
    {
      get { return m_swimmingPool; }
      set { m_swimmingPool = value; }
    }

    /// <summary>
    /// If the property has a swimming 
    /// pool, what type is it?
    /// </summary>
    public SwimmingPoolType SwimmingPoolType
    {
      get { return m_swimmingPoolType; }
      set { m_swimmingPoolType = value; }
    }

    /// <summary>
    /// Is the swimming pool fenced?
    /// </summary>
    public bool IsPoolFenced
    {
      get { return m_isPoolFenced; }
      set { m_isPoolFenced = value; }
    }

    /// <summary>
    /// Does the swimming pool have a diving 
    /// board or a slide?
    /// </summary>
    public bool DivingBoardOrSlide
    {
      get { return m_divingBoardOrSlide; }
      set { m_divingBoardOrSlide = value; }
    }

    /// <summary>
    /// Is there a trampoline on the premise?
    /// </summary>
    public bool TrampolineOnPremise
    {
      get { return m_trampolineOnPremise; }
      set { m_trampolineOnPremise = value; }
    }

    /// <summary>
    /// Is the property located inside or outside the city limits
    /// </summary>
    public CityLimitType CityLimit
    {
      get { return m_cityLimit; }
      set { m_cityLimit = value; }
    }

    /// <summary>
    /// Losses list.
    /// </summary>
    public virtual List<HOLoss> Losses
    {
      get { return m_losses; }
      set { m_losses = value; }
    }

    /// <summary>
    /// Does the insured have prior insurance
    /// </summary>
    public bool PriorInsurance
    {
      get { return m_priorInsurance; }
      set { m_priorInsurance = value; }
    }

    /// <summary>
    /// How many months of coverage did the prior policy provide?
    /// </summary>
    public int PriorMonthsCovg
    {
      get { return m_priorMonthsCovg; }
      set { m_priorMonthsCovg = value; }
    }

    /// <summary>
    /// The company ID of the prior insurance company
    /// </summary>
    public int PriorCompID
    {
      get { return m_priorCompID; }
      set { m_priorCompID = value; }
    }

    /// <summary>
    /// How many days lapsed between the prior 2 policies?
    /// </summary>
    public int PriorDaysLapse
    {
      get { return m_priorDaysLapse; }
      set { m_priorDaysLapse = value; }
    }

    /// <summary>
    /// The specific perils to be covered by a Dwelling Fire Policy Form 1
    /// </summary>
    public CoveredPerils CoveredPerils
    {
      get { return m_coveredPerils; }
      set { m_coveredPerils = value; }
    }

    /// <summary>
    /// Specifies whether the liability covered by a Dwelling Fire Policy
    /// is Personal Liability or Owners/Landlords/Tenants
    /// </summary>
    public LiabilityType LiabilityType
    {
      get { return m_liabilityType; }
      set { m_liabilityType = value; }
    }

    /// <summary>
    /// Amount of coverage for Fair Rental Value
    /// (Dwelling Fire Coverage D) 
    /// </summary>
    public int FairRentalAmt
    {
      get { return m_fairRentalAmt; }
      set { m_fairRentalAmt = value; }
    }

    /// <summary>
    /// Amount of coverage fro Additional Living Expense
    /// (Dwelling Fire Coverage E)
    /// </summary>
    public int AdditionalLivingExpenseAmt
    {
      get { return m_additionalLivingExpenseAmt; }
      set { m_additionalLivingExpenseAmt = value; }
    }

    /// <summary>
    /// Calculated Fire Premium for the Dwelling
    /// </summary>
    public double DwellingFirePremium
    {
      get { return m_dwellingFirePremium; }
      set { m_dwellingFirePremium = value; }
    }

    /// <summary>
    /// Calculated EC Premium for the Dwelling Form 1
    /// </summary>
    public double DwellingECPremium
    {
      get { return m_dwellingECPremium; }
      set { m_dwellingECPremium = value; }
    }

    /// <summary>
    /// Calculated Vandalism/Malicious Mischief Premium for the Dwelling Form 1
    /// </summary>
    public double DwellingVMMPremium
    {
      get { return m_dwellingVMMPremium; }
      set { m_dwellingVMMPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Dwelling Fire Form 2
    /// </summary>
    public double DwellingBroadPremium
    {
      get { return m_dwellingBroadPremium; }
      set { m_dwellingBroadPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Dwelling Fire Form 3
    /// </summary>
    public double DwellingSpecialPremium
    {
      get { return m_dwellingSpecialPremium; }
      set { m_dwellingSpecialPremium = value; }
    }

    /// <summary>
    /// Calculated Fire Premium for Other Structures
    /// </summary>
    public double OtherStructuresFirePremium
    {
      get { return m_otherStructuresFirePremium; }
      set { m_otherStructuresFirePremium = value; }
    }

    /// <summary>
    /// Calculated EC Premium for Other Structures Form 1
    /// </summary>
    public double OtherStructuresECPremium
    {
      get { return m_otherStructuresECPremium; }
      set { m_otherStructuresECPremium = value; }
    }

    /// <summary>
    /// Calculated Vandalism/Malicious Mischief Premium for Other Structures Form 1
    /// </summary>
    public double OtherStructuresVMMPremium
    {
      get { return m_otherStructuresVMMPremium; }
      set { m_otherStructuresVMMPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Other Structures Fire Form 2
    /// </summary>
    public double OtherStructuresBroadPremium
    {
      get { return m_otherStructuresBroadPremium; }
      set { m_otherStructuresBroadPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Other Structures Fire Form 3
    /// </summary>
    public double OtherStructuresSpecialPremium
    {
      get { return m_otherStructuresSpecialPremium; }
      set { m_otherStructuresSpecialPremium = value; }
    }

    /// <summary>
    /// Calculated Fire Premium for Contents/Personal Property
    /// </summary>
    public double ContentsFirePremium
    {
      get { return m_contentsFirePremium; }
      set { m_contentsFirePremium = value; }
    }

    /// <summary>
    /// Calculated EC Premium for Contents/Personal Property Form 1
    /// </summary>
    public double ContentsECPremium
    {
      get { return m_contentsECPremium; }
      set { m_contentsECPremium = value; }
    }

    /// <summary>
    /// Calculated Vandalism/Malicious Mischief Premium for Contents/Personal Property Form 1
    /// </summary>
    public double ContentsVMMPremium
    {
      get { return m_contentsVMMPremium; }
      set { m_contentsVMMPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Contents/Personal Property Fire Form 2
    /// </summary>
    public double ContentsBroadPremium
    {
      get { return m_contentsBroadPremium; }
      set { m_contentsBroadPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Contents/Personal Property Fire Form 3
    /// </summary>
    public double ContentsSpecialPremium
    {
      get { return m_contentsSpecialPremium; }
      set { m_contentsSpecialPremium = value; }
    }

    /// <summary>
    /// Calculated Fire Premium for Fair Rental Value
    /// </summary>
    public double FairRentalFirePremium
    {
      get { return m_fairRentalFirePremium; }
      set { m_fairRentalFirePremium = value; }
    }

    /// <summary>
    /// Calculated EC Premium for Fair Rental Value Form 1
    /// </summary>
    public double FairRentalECPremium
    {
      get { return m_fairRentalECPremium; }
      set { m_fairRentalECPremium = value; }
    }

    /// <summary>
    /// Calculated Vandalism/Malicious Mischief Premium for Fair Rental Value Form 1
    /// </summary>
    public double FairRentalVMMPremium
    {
      get { return m_fairRentalVMMPremium; }
      set { m_fairRentalVMMPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Fair Rental Value Fire Form 2
    /// </summary>
    public double FairRentalBroadPremium
    {
      get { return m_fairRentalBroadPremium; }
      set { m_fairRentalBroadPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Fair Rental Value Fire Form 3
    /// </summary>
    public double FairRentalSpecialPremium
    {
      get { return m_fairRentalSpecialPremium; }
      set { m_fairRentalSpecialPremium = value; }
    }

    /// <summary>
    /// Calculated total premium for Fair Rental Value
    /// </summary>
	  public double FairRentalPremium
    {
      get { return m_fairRentalPremium; }
      set { m_fairRentalPremium = value; }
    }

    /// <summary>
    /// Calculated Fire Premium for Additional Living Expense
    /// </summary>
    public double AdditionalLivingExpenseFirePremium
    {
      get { return m_additionalLivingExpenseFirePremium; }
      set { m_additionalLivingExpenseFirePremium = value; }
    }

    /// <summary>
    /// Calculated EC Premium for Additional Living Expense Form 1
    /// </summary>
    public double AdditionalLivingExpenseECPremium
    {
      get { return m_additionalLivingExpenseECPremium; }
      set { m_additionalLivingExpenseECPremium = value; }
    }

    /// <summary>
    /// Calculated Vandalism/Malicious Mischief Premium for Additional Living Expense Form 1
    /// </summary>
    public double AdditionalLivingExpenseVMMPremium
    {
      get { return m_additionalLivingExpenseVMMPremium; }
      set { m_additionalLivingExpenseVMMPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Additional Living Expense Fire Form 2
    /// </summary>
    public double AdditionalLivingExpenseBroadPremium
    {
      get { return m_additionalLivingExpenseBroadPremium; }
      set { m_additionalLivingExpenseBroadPremium = value; }
    }

    /// <summary>
    /// Calculated AOP Premium for Additional Living Expense Fire Form 3
    /// </summary>
    public double AdditionalLivingExpenseSpecialPremium
    {
      get { return m_additionalLivingExpenseSpecialPremium; }
      set { m_additionalLivingExpenseSpecialPremium = value; }
    }

    /// <summary>
    /// Calculated total Additional Living Expense Premium
    /// </summary>
    public double AdditionalLivingExpensePremium
    {
      get { return m_additionalLivingExpensePremium; }
      set { m_additionalLivingExpensePremium = value; }
    }

    /// <summary>
    /// The number of months occupied by the owner.
    /// </summary>
    public int MonthsOwnerOccupied
    {
      get { return m_monthsOwnerOccupied; }
      set { m_monthsOwnerOccupied = value; }
    }

    /// <summary>
    /// The exterior wall construction.
    /// </summary>
    public ExteriorWallMaterial ExteriorWallConstruction
    {
      get { return m_exteriorWallMaterial; }
      set { m_exteriorWallMaterial = value; }
    }

    /// <summary>
    /// The roof shape.
    /// </summary>
    public RoofShape RoofShape
    {
      get { return m_roofShape; }
      set { m_roofShape = value; }
    }

    /// <summary>
    /// Units within a fire division.
    /// </summary>
    public int UnitsInFireDivision
    {
      get { return m_unitsInFireDivision; }
      set { m_unitsInFireDivision = value; }
    }

    /// <summary>
    /// The number of related individuals, including the named insured/
    /// applicant, that reside in the insured/applicant's household
    /// </summary>
    public int NumberOfResidentsInHousehold
    {
      get { return m_numberOfResidentsInHousehold; }
      set { m_numberOfResidentsInHousehold = value; }
    }

    /// <summary>
    /// Flood zone code.
    /// </summary>
    public FloodZoneCode FloodZoneCode
    {
      get { return m_floodZoneCode; }
      set { m_floodZoneCode = value; }
    }

    /// <summary>
    /// Building code effectiveness grade.
    /// </summary>
    public BCEGS BCEGS
    {
      get { return m_bcegs; }
      set { m_bcegs = value; }
    }

    /// <summary>
    /// Miles to coast. 
    /// </summary>
    public int MilesToCoast
    {
      get { return m_milesToCoast; }
      set { m_milesToCoast = value; }
    }

    /// <summary>
    /// Wind coverage.
    /// </summary>
    public bool WindCoverage
    {
      get { return m_windCoverage; }
      set { m_windCoverage = value; }
    }

    /// <summary>
    /// Wind coverage.
    /// </summary>
    public double WindCoveragePremium
    {
      get { return m_windCoveragePremium; }
      set { m_windCoveragePremium = value; }
    }

    /// <summary>
    /// Roof grade.
    /// </summary>
    public RoofGrade RoofGrade
    {
      get { return m_roofGrade; }
      set { m_roofGrade = value; }
    }

    /// <summary>
    /// Does the property have a hot tub.
    /// </summary>
    public bool Spa
    {
      get { return m_spa; }
      set { m_spa = value; }
    }

    /// <summary>
    /// Any smokers in the house?
    /// </summary>
    public bool SmokersInHousehold
    {
      get { return m_smokersInHousehold; }
      set { m_smokersInHousehold = value; }
    }

    /// <summary>
    /// House occupied during the day?
    /// </summary>
    public bool OccupiedDuringDay
    {
      get { return m_occupiedDuringDay; }
      set { m_occupiedDuringDay = value; }
    }

    /// <summary>
    /// Type of Porch 
    /// </summary>
    public PorchTypeCd Porch
    {
      get { return m_porch; }
      set { m_porch = value; }
    }

    /// <summary>
    /// In or above ground spa.
    /// </summary>
    public SpaType SpaType
    {
      get { return m_spaType; }
      set { m_spaType = value; }
    }

    /// <summary>
    /// Number of townhouse units. 
    /// </summary>
    public int NumberOfTownhouseUnits
    {
      get { return m_numberOfTownhouseUnits; }
      set { m_numberOfTownhouseUnits = value; }
    }

    /// <summary>
    /// Type of animal on the property.
    /// </summary>
    public Animals Animals
    {
      get { return m_animals; }
      set { m_animals = value; }
    }

    /// <summary>
    /// Payment method used.
    /// </summary>
    public virtual PaymentMethod PaymentMethod
    {
      get { return m_paymentMethod; }
      set { m_paymentMethod = value; }
    }

    /// <summary>
    /// Has Extended Replacement Cost coverage been requested? 
    /// </summary>
    public bool ExReplacementCost
    {
      get { return m_exReplacementCost; }
      set { m_exReplacementCost = value; }
    }

    /// <summary>
    /// Extended Replacement Cost limit for the policy
    /// </summary>
    public virtual int ExReplacementCostLimit
    {
      get { return m_exReplacementCostLimit; }
      set { m_exReplacementCostLimit = value; }
    }

    /// <summary>
    /// Extended Replacement Cost Premium
    /// </summary>
    public double ExReplacementCostPremium
    {
      get { return m_exReplacementCostPremium; }
      set { m_exReplacementCostPremium = value; }
    }

    /// <summary>
    /// Company specific Extended replacement cost limit
    /// </summary>
	  public virtual int CoExReplacementCostLimit
    {
      get { return m_coExReplacementCostLimit; }
      set { m_coExReplacementCostLimit = value; }
    }

    /// <summary>
    /// Policy Key Premium
    /// </summary>
    public virtual double KeyPremium
    {
      get { return m_keyPremium; }
      set { m_keyPremium = value; }
    }

    /// <summary>
    /// Premium charge for Rowhouse/Townhouse
    /// </summary>
    public virtual double RowhouseTownhousePremium
    {
      get { return m_rowhouseTownhousePremium; }
      set { m_rowhouseTownhousePremium = value; }
    }

    /// <summary>
    /// Premium reduction for Secondary Residence
    /// </summary>
    public virtual double SecondaryResidencePremium
    {
      get { return m_secondaryResidencePremium; }
      set { m_secondaryResidencePremium = value; }
    }

    /// <summary>
    /// Vacant or Unoccupied status of the dwelling
    /// </summary>
    public virtual VacantUnoccupied VacantUnoccupied { get; set; } = VacantUnoccupied.NotVacantOrUnoccupied;

    /// <summary>
    /// This is used to determine if the mailing address was validated in Home/DF policies since they 
    /// can have a different property address from the mailing address. Didn't want to call it MailingAddressValidated 
    /// due to the fact that for most policy lines, the address is the mailing address. and that would cause naming confusion.
    /// </summary>
    public bool AlternateAddressValidated { get; set; }

    /// <summary>
    /// Gets the number of mortgages based on mortgagee names.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int NumberOfMortgages
    {
      get { return m_numberOfMortgages; }
      set { m_numberOfMortgages = value; }
    }

    /// <summary>
    /// Gets or sets the number of fireplaces in the dwelling
    /// </summary>
    public int NumOfFireplaces { get; set; }

    /// <summary>
    /// Type description of the fireplace(s)
    /// </summary>
    public FireplaceType FireplaceType { get; set; } = FireplaceType.Masonry;

    /// <summary>
    /// What type of garage is at the residence
    /// </summary>
    public GarageType GarageType { get; set; } = GarageType.None;

    /// <summary>
    /// How many stalls in the garage
    /// </summary>
    public GarageStalls GarageStalls { get; set; } = GarageStalls.None;

    /// <summary>
    /// Area of the garage in square feet
    /// </summary>
    public int GarageArea { get; set; }

    /// <summary>
    /// Number of consecutive months unoccupied
    /// </summary>
    public virtual int NumberOfMonthsUnoccupied
    {
      get { return m_numberOfMonthsUnoccupied; }
      set { m_numberOfMonthsUnoccupied = value; }
    }

    /// <summary>
    /// Home Quality - used for HomeValuation api. 
    /// </summary>
    public virtual HomeQuality HomeQuality { get; set; } = HomeQuality.Good;

    /// <summary>
    /// Sets company data for a specified object and tag name.
    /// </summary>
    /// <param name="tagName">The tag name of the value to store.</param>
    /// <param name="value">The object containing the data to store.</param>
    public void SetCompanyData(string tagName, object value)
    {
      StringLib.SetTaggedField(ref m_companyData, tagName, value);
    }

    /// <summary>
    /// Calculates the total amount of all fees on the policy
    /// </summary>
    /// <returns>The total amount of all fees on the policy</returns>
    public override double CalculateFees()
    {
      var baseFees = base.CalculateFees();
      return baseFees + InspectionFee + MGAFee + EMPATFee + FIGAFee + CitizensRecoupmentFee;
    }

    private string m_coForm;
    private int m_otherStructuresAmt;
    private double m_otherStructuresPremium;
    private string m_deductible1 = "";
    private double m_deductible1Premium;
    private string m_deductible2 = "";
    private double m_deductible2Premium;
    private string m_deductible3 = "";
    private double m_deductible3Premium;
    private string m_coDeductible1 = "";
    private string m_coDeductible1Type = "";
    private string m_coDeductible2 = "";
    private string m_coDeductible2Type = "";
    private string m_coDeductible3 = "";
    private string m_coDeductible3Type = "";
    private bool m_underConstruction;
    private bool m_homePolicyCancelled;
    private bool m_heatingUpdate;
    private bool m_electricalUpdate;
    private bool m_roofingUpdate;
    private bool m_plumbingUpdate;
    private UpdateLevel m_roofingUpdateLevel = UpdateLevel.None;
    private UpdateLevel m_plumbingUpdateLevel = UpdateLevel.None;
    private UpdateLevel m_electricalUpdateLevel = UpdateLevel.None;
    private UpdateLevel m_heatingUpdateLevel = UpdateLevel.None;
    private bool m_hailResistantRoof;
    private int m_heatingUpdateYear;
    private int m_electricalUpdateYear;
    private int m_roofingUpdateYear;
    private int m_plumbingUpdateYear;
    private int m_squareFootage;
    private int m_feetToHydrant;
    private CityLimitType m_cityLimit = CityLimitType.Inside;
    private int m_milesToFireStation;
    private int m_numAdditionalResidences;
    private double m_additionalResidencesPremium;
    private int m_liabLimit;
    private int m_coLiabLimit;
    private double m_liabPremium;
    private int m_medPayLimit;
    private int m_coMedPayLimit;
    private bool m_medPay = true;
    private string m_occupancy = "O";
    private bool m_fireResistive;
    private bool m_sharedEntrance;
    private int m_lossOfUseAmt;
    private double m_lossOfUsePremium;
    private double m_undeviatedUnreducedBase;
    private double m_deviatedUnreducedBase;
    private double m_deviatedReducedBase;
    private bool m_ownerOccupiedDuplex;
    private HODiscounts m_discounts;
    private HOISOEndorsements m_iSOEndorsements;
    private HOTXEndorsements m_txEndorsements;
    private List<PersonalProperty> m_personalProperty;
    private List<Watercraft> m_watercraft;
    private bool m_propertyAddressSame = true;
    private string m_companyData = string.Empty;
    private List<PayPlan> m_payPlans = new List<PayPlan>();
    private int m_insuredResideTime = 12;
    private string m_thirdPartyQuoteUrl = string.Empty;
    private bool m_requiresPayPlanRerate;
    private USState m_ratingState = USState.NoneSelected;
    private string m_companyEndorsementData = string.Empty;
    private string m_companyCreditsData = string.Empty;
    private double m_dwellingPremium;
    private double m_contentsPremium;
    private double m_medPayPremium;
    private double m_inspectionFee;
    private double m_mgaFee;
    private double m_empatFee;
    private double m_figaFee;
    private double m_citizensRecoupmentFee;
    private bool m_isBridgeRequest;
    private int m_contentsPercent = 60;
    private int m_lossOfUsePercent = 10;
    private int m_otherStructuresPercent = 10;
    private int m_purchasePrice;
    private int m_numberOfStories;
    private StoryType m_storyType = StoryType.OneStory;
    private int m_numberOfFamilies = 1;
    private DateTime m_purchaseDate = ITCConstants.InvalidDate;
    private int m_numberOfFullBaths = 1;
    private int m_numberOfThreeQuarterBaths;
    private int m_numberOfHalfBaths;
    private SecondaryHeatingType m_secondaryHeatingType = SecondaryHeatingType.None;
    private FoundationType m_foundationType = FoundationType.Slab;
    private bool m_viciousDog;
    private WindMitigationForm m_windMitigationForm = WindMitigationForm.wmf2012;
    private bool m_windMitigation;
    private RoofCovering m_roofCovering = RoofCovering.None;
    private RoofDeckAttachment m_roofDeckAttachment = RoofDeckAttachment.None;
    private RoofWallConnection m_roofWallConnection = RoofWallConnection.None;
    private bool m_secondaryWaterResistance;
    private OpeningProtection m_openingProtection = OpeningProtection.None;
    private TerrainExposure m_terrainExposure = TerrainExposure.None;
    private WindSpeed m_windSpeed = WindSpeed.None;
    private WindDesign m_windDesign = WindDesign.None;
    private InternalPressureDesign m_internalPressureDesign = InternalPressureDesign.None;
    private bool m_windBornDebrisRegion;
    private bool m_overWater;

    private MortgageeSuffixes m_mortgageeSuffix1 = MortgageeSuffixes.None;
    private MortgageeSuffixes m_mortgageeSuffix2 = MortgageeSuffixes.None;
    private bool m_billMortgagee;
    private string m_mortgageeName1 = string.Empty;
    private string m_mortgageeName2 = string.Empty;
    private string m_mortgageeAddressOne1 = string.Empty;
    private string m_mortgageeAddressOne2 = string.Empty;
    private string m_mortgageeAddressTwo1 = string.Empty;
    private string m_mortgageeAddressTwo2 = string.Empty;
    private string m_mortgageeCity1 = string.Empty;
    private string m_mortgageeCity2 = string.Empty;
    private USState m_mortgageeState1 = USState.NoneSelected;
    private USState m_mortgageeState2 = USState.NoneSelected;
    private string m_mortgageeZip1 = string.Empty;
    private string m_mortgageeZip2 = string.Empty;
    private string m_mortgageeLoanNumber1 = string.Empty;
    private string m_mortgageeLoanNumber2 = string.Empty;

    private HeatingType m_heatingType = HeatingType.CentralElectric;
    private bool m_woodBurningStove;
    private bool m_swimmingPool;
    private SwimmingPoolType m_swimmingPoolType = SwimmingPoolType.InGround;
    private bool m_isPoolFenced;
    private bool m_divingBoardOrSlide;
    private bool m_trampolineOnPremise;
    private List<HOLoss> m_losses = new List<HOLoss>();
    private bool m_priorInsurance;
    private int m_priorMonthsCovg = 12;
    private int m_priorDaysLapse;
    private int m_priorCompID = ITCConstants.InvalidNum;

    private CoveredPerils m_coveredPerils = CoveredPerils.FireOnly;
    private LiabilityType m_liabilityType = LiabilityType.CPL;
    private int m_fairRentalAmt;
    private int m_additionalLivingExpenseAmt;
    private double m_dwellingFirePremium;
    private double m_dwellingECPremium;
    private double m_dwellingVMMPremium;
    private double m_dwellingBroadPremium;
    private double m_dwellingSpecialPremium;
    private double m_otherStructuresFirePremium;
    private double m_otherStructuresECPremium;
    private double m_otherStructuresVMMPremium;
    private double m_otherStructuresBroadPremium;
    private double m_otherStructuresSpecialPremium;
    private double m_contentsFirePremium;
    private double m_contentsECPremium;
    private double m_contentsVMMPremium;
    private double m_contentsBroadPremium;
    private double m_contentsSpecialPremium;
    private double m_fairRentalFirePremium;
    private double m_fairRentalECPremium;
    private double m_fairRentalVMMPremium;
    private double m_fairRentalBroadPremium;
    private double m_fairRentalSpecialPremium;
    private double m_fairRentalPremium;
    private double m_additionalLivingExpenseFirePremium;
    private double m_additionalLivingExpenseECPremium;
    private double m_additionalLivingExpenseVMMPremium;
    private double m_additionalLivingExpenseBroadPremium;
    private double m_additionalLivingExpenseSpecialPremium;
    private double m_additionalLivingExpensePremium;
    private int m_monthsOwnerOccupied = 12;
    private ExteriorWallMaterial m_exteriorWallMaterial = ExteriorWallMaterial.SelectOne;
    private RoofShape m_roofShape = RoofShape.SelectOne;
    private int m_unitsInFireDivision = 1;
    private int m_numberOfResidentsInHousehold;
    private FloodZoneCode m_floodZoneCode = FloodZoneCode.Unknown;
    private BCEGS m_bcegs = HO.BCEGS.SelectOne;
    private int m_milesToCoast = ITCConstants.InvalidNum;
    private bool m_windCoverage = true;
    private double m_windCoveragePremium;
    private RoofGrade m_roofGrade = HO.RoofGrade.Standard;
    private bool m_spa;
    private bool m_smokersInHousehold;
    private bool m_occupiedDuringDay;
    private SpaType m_spaType = SpaType.InGround;
    private int m_numberOfTownhouseUnits = ITCConstants.InvalidNum;
    private PorchTypeCd m_porch = PorchTypeCd.None;
    private Animals m_animals = Animals.None;
    private PaymentMethod m_paymentMethod;

    private bool m_exReplacementCost;
    private int m_exReplacementCostLimit;
    private double m_exReplacementCostPremium;
    private int m_coExReplacementCostLimit = 0;
    private double m_keyPremium;
    private double m_rowhouseTownhousePremium;
    private double m_secondaryResidencePremium;
    private int m_numberOfMonthsUnoccupied;
    private int m_numberOfMortgages;
    private int m_companionAUPolicyId = -1;
  }
}
