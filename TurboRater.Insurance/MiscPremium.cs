using System;
using System.Xml.Serialization;

namespace TurboRater.Insurance
{

  /// <summary>
  /// Represents a miscellaneous premium. Frequently used by agencies
  /// to tack extra fees onto policies.
  /// </summary>
  public class MiscPremium : BaseStoredRecord
  {
    private int m_policyLinkID = ITCConstants.InvalidNum;
    private double m_amount;
    private bool m_applyToDownPayment = true;
    private bool m_applyToDriver;
    private bool m_applyToPolicy = true;
    private bool m_applyToVehicle;
    private int m_customAddInCode;
    private int m_customMethodCode;
    private int m_customProviderID;
    private string m_description = "";
    private bool m_percentOfTotal;
    private double m_percentOfTotalAmount;
    private double m_premiumAmount;
    private int m_units = 1;
    private Guid m_identifier = Guid.NewGuid();

    /// <summary>
    /// Non-stored description of the "applied to" field built from the bool values.
    /// </summary>
    [XmlIgnore]
    public string AppliedToDescription
    {
      get
      {
        string appliedTo = "Financed";
        if (ApplyToDownPayment)
          appliedTo = "Down Payment";
        if (ApplyToPolicy)
          appliedTo += " - Policy";
        if (ApplyToDriver)
          appliedTo += " - Driver";
        if (ApplyToVehicle)
          appliedTo += " - Vehicle";
        if (PercentOfTotal)
          appliedTo += " - % Total";
        return appliedTo;
      }
    }

    /// <summary>
    /// Currency formated amount, non-stored
    /// </summary>
    [XmlIgnore]
    public string FormattedAmount
    {
      get
      {
        return Amount.ToString("c");
      }
    }

    /// <summary>
    /// Non-stored identifier to find prems in an unsorted list.
    /// </summary>
    [XmlIgnore]
    public Guid Identifier
    {
      get { return m_identifier; }
      set { m_identifier = value; }
    }

    /// <summary>
    /// Foreign key link to the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int, ForeignKeyClassType = typeof(InsPolicy))]
    public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// Will this misc premium be applied to the down payment?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ApplyToDownPayment
    {
      get { return this.m_applyToDownPayment; }
      set { this.m_applyToDownPayment = value; }
    }

    /// <summary>
    /// The scope of the misc premium...apply it per driver?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ApplyToDriver
    {
      get { return this.m_applyToDriver; }
      set { this.m_applyToDriver = value; }
    }

    /// <summary>
    /// The scope of the misc premium...apply it to the policy?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ApplyToPolicy
    {
      get { return this.m_applyToPolicy; }
      set { this.m_applyToPolicy = value; }
    }

    /// <summary>
    /// The scope of the misc premium...apply it per vehicle?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool ApplyToVehicle
    {
      get { return this.m_applyToVehicle; }
      set { this.m_applyToVehicle = value; }
    }

    /// <summary>
    /// The custom add-in code for the misc premium. Not sure what
    /// this is used for.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CustomAddInCode
    {
      get { return this.m_customAddInCode; }
      set { this.m_customAddInCode = value; }
    }

    /// <summary>
    /// The custom method code for the misc premium. Not sure what this
    /// is used for.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CustomMethodCode
    {
      get { return this.m_customMethodCode; }
      set { this.m_customMethodCode = value; }
    }

    /// <summary>
    /// The custom provider ID for this misc premium. Not sure what 
    /// this is used for.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CustomProviderID
    {
      get { return this.m_customProviderID; }
      set { this.m_customProviderID = value; }
    }

    /// <summary>
    /// The description for the misc premium.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string Description
    {
      get { return this.m_description; }
      set { this.m_description = value; }
    }

    /// <summary>
    /// Is this misc premium just a percent of the total premium?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PercentOfTotal
    {
      get { return this.m_percentOfTotal; }
      set { this.m_percentOfTotal = value; }
    }

    /// <summary>
    /// If this misc premium is just a percent of the total premium,
    /// (PercentOfTotal==true), then this is the amount of the percentage.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PercentOfTotalAmount
    {
      get { return this.m_percentOfTotalAmount; }
      set { this.m_percentOfTotalAmount = value; }
    }

    /// <summary>
    /// The amount of the misc premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PremiumAmount
    {
      get { return this.m_premiumAmount; }
      set { this.m_premiumAmount = value; }
    }

    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int Units
    {
      get { return this.m_units; }
      set { this.m_units = value; }
    }

    /// <summary>
    /// The amount of the misc premium
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double Amount
    {
      get { return m_amount; }
      set { m_amount = value; }
    }
  }

}
