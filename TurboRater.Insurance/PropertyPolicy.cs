using System;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A base class for handling property policies such as HO and DF.
  /// </summary>
  [Serializable]
  public class PropertyPolicy : InsPolicy
  {
    /// <summary>
    /// Constructor. Allows you to pass in an initalization delegate.
    /// </summary>
    /// <param name="initializeMethod">An initialization delegate that gets
    /// called at the end of the constructor.</param>
    public PropertyPolicy(PolicyInitializeCallback initializeMethod) : base(initializeMethod)
    {
      InitializePolicy();
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public PropertyPolicy() : base()
    {
      InitializePolicy();
    }

    /// <summary>
    /// Initializes local objects and variables
    /// </summary>
    public override void InitializePolicy()
    {
      base.InitializePolicy();
    }

    /// <summary>
    /// The form associated with the policy
    /// </summary>
    public virtual string Form
    {
      get { return m_form; }
      set { m_form = value; }
    }

    /// <summary>
    /// The territory that the policy is rated in
    /// </summary>
    public virtual string Territory
    {
      get { return m_territory; }
      set { m_territory = value; }
    }

    /// <summary>
    /// The company-specific territory (if any) that the policy is rated in
    /// </summary>
    public virtual string CompanyTerritory
    {
      get { return m_companyTerritory; }
      set { m_companyTerritory = value; }
    }

    /// <summary>
    /// County that the policy is rated in
    /// </summary>
    public virtual string County
    {
      get { return m_county; }
      set { m_county = value; }
    }

    /// <summary>
    /// Type of construction for the dwelling
    /// </summary>
    public virtual string Construction
    {
      get { return m_construction; }
      set { m_construction = value; }
    }

    /// <summary>
    /// Fire district of the dwelling
    /// </summary>

    public virtual string FireDistrict
    {
      get { return m_fireDistrict; }
      set { m_fireDistrict = value; }
    }

    /// <summary>
    /// Protection class of the dwelling
    /// </summary>
    public virtual string ProtectionClass
    {
      get { return m_protectionClass; }
      set { m_protectionClass = value; }
    }

    /// <summary>
    /// Fire Protection Area for the dwelling
    /// </summary>
    public virtual string FireProtectionArea
    {
      get { return m_fireProtectionArea; }
      set { m_fireProtectionArea = value; }
    }

    /// <summary>
		/// Amount of dwelling coverage
		/// </summary>
    public virtual int DwellingAmt
    {
      get { return m_dwellingAmt; }
      set { m_dwellingAmt = value; }
    }

    /// <summary>
    /// Amount of contents coverage
    /// </summary>
    public virtual int ContentsAmt
    {
      get { return m_contentsAmt; }
      set { m_contentsAmt = value; }
    }

    /// <summary>
    /// Usage type for the policy. Primary Residence or Secondary Residence.
    /// </summary>
    public virtual UsageType UsageType
    {
      get { return m_usageType; }
      set { m_usageType = value; }
    }

    /// <summary>
    /// Roof composition of the dwelling
    /// </summary>
    public virtual string RoofComposition
    {
      get { return m_roofComposition; }
      set { m_roofComposition = value; }
    }

    /// <summary>
    /// Year of construction of the dwelling
    /// </summary>
    public virtual int YearOfConstruction
    {
      get { return m_yearOfConstruction; }
      set { m_yearOfConstruction = value; }
    }

    /// <summary>
    /// Is this a surplus lines policy?
    /// </summary>
    public virtual bool Surplus
    {
      get { return m_surplus; }
      set { m_surplus = value; }
    }

    /// <summary>
    /// Flex band value for the policy
    /// </summary>
    public virtual double FlexBand
    {
      get { return m_flexBand; }
      set { m_flexBand = value; }
    }

    /// <summary>
    /// Base premium rated for the policy
    /// </summary>
    public virtual double BasePremium
    {
      get { return m_basePremium; }
      set { m_basePremium = value; }
    }

    /// <summary>
    /// Endorsements premium rated for the policy
    /// </summary>
    public virtual double EndorsementsPremium
    {
      get { return m_endorsementsPremium; }
      set { m_endorsementsPremium = value; }
    }

    /// <summary>
    /// Credits (discounts) premium rated for the policy
    /// </summary>
    public virtual double CreditsPremium
    {
      get { return m_creditsPremium; }
      set { m_creditsPremium = value; }
    }

    /// <summary>
    /// How does the named insured use the dwelling?
    /// </summary>
    public virtual string DwellingUse
    {
      get { return m_dwellingUse; }
      set { m_dwellingUse = value; }
    }

    /// <summary>
    /// How does the named insured use the construction style?
    /// </summary>
    public virtual string ConstructionStyle
    {
      get { return m_constructionStyle; }
      set { m_constructionStyle = value; }
    }

    /// <summary>
    /// Other insured person for the policy
    /// </summary>
    public virtual Person OtherInsured
    {
      get { return m_otherInsured; }
      set { m_otherInsured = value; }
    }

    /// <summary>
    /// The property that is being insured
    /// </summary>
    public virtual Residence InsuredProperty
    {
      get { return m_insuredProperty; }
      set { m_insuredProperty = value; }
    }

    /// <summary>
    /// Policy number reference for Marshall-Swift
    /// </summary>
    public virtual Guid MSBValuationID
    {
      get { return m_msbValuationID; }
      set { m_msbValuationID = value; }
    }

    /// <summary>
    /// Has replacement cost valuation been ordered from MSB
    /// </summary>
    public virtual bool MSBValuationOrdered
    {
      get { return m_msbValuationOrdered; }
      set { m_msbValuationOrdered = value; }
    }

    /// <summary>
    /// Has MSB valuation been accepted
    /// </summary>
    public virtual bool MSBValuationAccepted
    {
      get { return m_msbValuationAccepted; }
      set { m_msbValuationAccepted = value; }
    }

    private string m_form = "C";
    private string m_territory = "";
    private string m_companyTerritory = "";
    private string m_county = "";
    private string m_construction = "";
    private string m_fireDistrict = "";
    private string m_protectionClass = "10";
    private int m_dwellingAmt;
    private int m_contentsAmt;
    private UsageType m_usageType = UsageType.Primary;
    private string m_roofComposition = "";
    private int m_yearOfConstruction;
    private bool m_surplus;
    private double m_flexBand;
    private double m_basePremium;
    private double m_endorsementsPremium;
    private double m_creditsPremium;
    private string m_dwellingUse = "";
    private string m_constructionStyle = "";    
    private Person m_otherInsured = new Person(TypeOfPerson.OtherInsured);
    private Residence m_insuredProperty = new Residence(TypeOfResidence.InsuredProperty);
    private string m_fireProtectionArea = "";
    private Guid m_msbValuationID = Guid.NewGuid();
    private bool m_msbValuationOrdered;
    private bool m_msbValuationAccepted;
  }
}
