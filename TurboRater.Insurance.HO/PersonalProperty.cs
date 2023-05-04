using System;

namespace TurboRater.Insurance.HO
{

  /// <summary>
  /// Represents a personal property item for homeowners policies, as used
  /// by endorsement HO-160.
  /// </summary>
  /// <seealso cref="HOStateEndorsements.HO160">HOStateEndorsements.HO160</seealso>
  [Serializable]
  public class PersonalProperty : BaseStoredRecord
  {

    /// <summary>
    /// Default constructor. 
    /// properly.
    /// </summary>
    public PersonalProperty()
    {
    }

    /// <summary>
    /// Constructor. Allows specification of the type of personal property that this will be.
    /// </summary>
    /// <param name="type"></param>
    public PersonalProperty(string type) : this()
    {
      TypeOfPersonalProperty = type;
    }

    /// <summary>
    /// Foreign key link to the policy
    /// </summary>
    public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// Type of personal property. Could be jewelry, bicycles, etc.
    /// </summary>
    public virtual string TypeOfPersonalProperty
    {
      get { return m_typeOfPersonalProperty; }
      set { m_typeOfPersonalProperty = value; }
    }

    /// <summary>
    /// Description of the property
    /// </summary>
    public virtual string Description
    {
      get { return m_description; }
      set { m_description = value; }
    }

    /// <summary>
    /// Limit of coverage for the property
    /// </summary>
    public virtual int Limit
    {
      get { return m_limit; }
      set { m_limit = value; }
    }

    /// <summary>
    /// Apply breakage coverage to the property?
    /// </summary>
    public virtual bool Breakage
    {
      get { return m_breakage; }
      set { m_breakage = value; }
    }

    /// <summary>
    /// Amount of breakage coverage to apply to the property
    /// </summary>
    public virtual double BreakageAmount
    {
      get { return m_breakageAmount; }
      set { m_breakageAmount = value; }
    }

    /// <summary>
    /// Premium rated for the property
    /// </summary>
    public virtual double Premium
    {
      get { return m_Premium; }
      set { m_Premium = value; }
    }

    private int m_policyLinkID = ITCConstants.InvalidNum;
    private string m_typeOfPersonalProperty = "";
    private string m_description = "";
    private int m_limit;
    private bool m_breakage;
    private double m_breakageAmount;
    private double m_Premium;
  }

}
