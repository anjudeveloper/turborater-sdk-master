namespace TurboRater.Insurance.HO
{

  /// <summary>
  /// Represents a watercraft item for homeowners policies, as used
  /// by endorsement HO-215; a boat or jet-ski in other words.
  /// </summary>
  public class Watercraft : BaseStoredRecord
  {
    /// <summary>
    /// Foreign key link to the policy
    /// </summary>
		public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// Horsepower
    /// </summary>
    public virtual int Horsepower
    {
      get { return m_horsepower; }
      set { m_horsepower = value; }
    }

    /// <summary>
    /// Deductible applicable to the hull of the watercraft.
    /// </summary>
    public virtual string HullDeductible
    {
      get { return m_hullDeductible; }
      set { m_hullDeductible = value; }
    }

    /// <summary>
    /// The value of the hull
    /// </summary>
    public virtual int HullValue
    {
      get { return m_hullValue; }
      set { m_hullValue = value; }
    }

    /// <summary>
    /// Deductible applicable to the motor of the boat
    /// </summary>
    public virtual string MotorDeductible
    {
      get { return m_motorDeductible; }
      set { m_motorDeductible = value; }
    }

    /// <summary>
    /// Value of the motor
    /// </summary>
    public virtual int MotorValue
    {
      get { return m_motorValue; }
      set { m_motorValue = value; }
    }

    /// <summary>
    /// Deductible for the boat's trailer
    /// </summary>
    public virtual string TrailerDeductible
    {
      get { return m_trailerDeductible; }
      set { m_trailerDeductible = value; }
    }

    /// <summary>
    /// Value of the boat's trailer
    /// </summary>
    public virtual int TrailerValue
    {
      get { return m_trailerValue; }
      set { m_trailerValue = value; }
    }

    /// <summary>
    /// Description of the watercraft
    /// </summary>
    public virtual string Description
    {
      get { return m_description; }
      set { m_description = value; }
    }

    /// <summary>
    /// Length of the watercraft
    /// </summary>
    public virtual int Length
    {
      get { return m_length; }
      set { m_length = value; }
    }

    /// <summary>
    /// Top speed of the watercraft
    /// </summary>
    public virtual int Speed
    {
      get { return m_speed; }
      set { m_speed = value; }
    }

    /// <summary>
    /// Liability limit for the watercraft
    /// </summary>
    public virtual int LiabLimit
    {
      get { return m_liabLimit; }
      set { m_liabLimit = value; }
    }

    /// <summary>
    /// Physical damage limit for the watercraft
    /// </summary>
    public virtual int PDLimit
    {
      get { return m_pDLimit; }
      set { m_pDLimit = value; }
    }

    /// <summary>
    /// The type of watercraft
    /// </summary>
    public virtual string TypeOfWatercraft
    {
      get { return m_typeOfWatercraft; }
      set { m_typeOfWatercraft = value; }
    }

    private int m_policyLinkID = ITCConstants.InvalidNum;
    private int m_horsepower;
    private string m_hullDeductible = "";
    private int m_hullValue;
    private string m_motorDeductible = "";
    private int m_motorValue;
    private string m_trailerDeductible = "";
    private int m_trailerValue;
    private string m_description = "";
    private int m_length;
    private int m_speed;
    private int m_liabLimit;
    private int m_pDLimit;
    private string m_typeOfWatercraft = "";

  }

}
