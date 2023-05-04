using System;
using System.ComponentModel;

namespace TurboRater.Insurance.HO
{
  /// <summary>
  /// Types of losses
  /// </summary>
  public enum LossDescription
  {
    [Description("Damage to Property of Others")]
    DamageToPropertyOfOthers,
    [Description("Dog Bite (liability)")]
    DogBiteLiability,
    [Description("Fire")]
    Fire,
    [Description("Freezing Water")]
    FreezingWater,
    [Description("Liability (other than dog bite)")]
    OtherThanDogBiteLiability,
    [Description("Lightning")]
    Lightning,
    [Description("Mold - remediated")]
    RemediatedMold,
    [Description("Mold - not remediated")]
    UnremediatedMold,
    [Description("Smoke")]
    Smoke,
    [Description("Theft/Burglary")]
    TheftOrBurglary,
    [Description("Vandalism")]
    Vandalism,
    [Description("Water-related")]
    WaterRelated,
    [Description("Wind")]
    Wind
  }

  /// <summary>
  /// Represents a loss item for HO policy
  /// </summary>
  [Serializable]
  public class HOLoss : BaseStoredRecord
  {
    private int m_policyLinkID = ITCConstants.InvalidNum;
    private int m_monthsAgo;
    private DateTime m_dateOfLoss = ITCConstants.InvalidDate;
    private double m_amountOfLoss;
    private LossDescription m_description;
    private bool m_scheduledPersonalPropertyLoss;

    /// <summary>
    /// Foreign key link to the policy
    /// </summary>
    public int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// Number of months ago the loss occurred
    /// </summary>
    public int MonthsAgo
    {
      get { return m_monthsAgo; }
      set { m_monthsAgo = value; }
    }

    /// <summary>
    /// Date on which the loss occurred
    /// </summary>
    public DateTime DateOfLoss
    {
      get { return m_dateOfLoss; }
      set { m_dateOfLoss = value; }
    }

    /// <summary>
    /// Dollar amount of the loss
    /// </summary>
    public double AmountOfLoss
    {
      get { return m_amountOfLoss; }
      set { m_amountOfLoss = value; }
    }

    /// <summary>
    /// Description of the loss
    /// </summary>
    public LossDescription Description
    {
      get { return m_description; }
      set { m_description = value; }
    }

    /// <summary>
    /// Is this a loss of a Scheduled Personal Property Item
    /// </summary>
    public bool ScheduledPersonalPropertyLoss
    {
      get { return m_scheduledPersonalPropertyLoss; }
      set { m_scheduledPersonalPropertyLoss = value; }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public HOLoss()
    {
    }
  }
}
