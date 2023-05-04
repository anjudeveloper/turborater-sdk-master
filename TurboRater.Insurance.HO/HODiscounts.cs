using System;

namespace TurboRater.Insurance.HO
{

  /// <summary>
  /// Base class for handling discounts at the homeowners level
  /// </summary>
  [Serializable]
  public class HODiscounts : InsDiscounts
  {

    /// <summary>
    /// Is alarm system credit applicable?
    /// </summary>
    public virtual bool AlarmSystem
    {
      get { return m_alarmSystem; }
      set { m_alarmSystem = value; }
    }

    /// <summary>
    /// Alarm system discount percent
    /// </summary>
    public virtual double AlarmSystemPercent
    {
      get { return m_alarmSystemPercent; }
      set { m_alarmSystemPercent = value; }
    }

    /// <summary>
    /// Alarm System premium calculated in rating
    /// </summary>
    public virtual double AlarmSystemPremium
    {
      get { return m_alarmSystemPremium; }
      set { m_alarmSystemPremium = value; }
    }

    /// <summary>
    /// Is new home credit applicable?
    /// </summary>
    public virtual bool NewHome
    {
      get { return m_newHome; }
      set { m_newHome = value; }
    }

    /// <summary>
    /// New home discount percent
    /// </summary>
    public virtual double NewHomePercent
    {
      get { return m_newHomePercent; }
      set { m_newHomePercent = value; }
    }

    /// <summary>
    /// New home premium calculated in rating
    /// </summary>
    public virtual double NewHomePremium
    {
      get { return m_newHomePremium; }
      set { m_newHomePremium = value; }
    }

    /// <summary>
    /// Is sprinkler system credit applicable?
    /// </summary>
    public virtual bool SprinklerSystem
    {
      get { return m_sprinklerSystem; }
      set { m_sprinklerSystem = value; }
    }

    /// <summary>
    /// Sprinkler system discount percent
    /// </summary>
    public virtual double SprinklerSystemPercent
    {
      get { return m_sprinklerSystemPercent; }
      set { m_sprinklerSystemPercent = value; }
    }

    /// <summary>
    /// Sprinkler system premium calculated in rating
    /// </summary>
    public virtual double SprinklerSystemPremium
    {
      get { return m_sprinklerSystemPremium; }
      set { m_sprinklerSystemPremium = value; }
    }

    /// <summary>
    /// Is fire extinguisher credit applicable?
    /// </summary>
    public virtual bool FireExtinguisher
    {
      get { return m_fireExtinguisher; }
      set { m_fireExtinguisher = value; }
    }

    /// <summary>
    /// Fire extinguisher discount percent
    /// </summary>
    public virtual double FireExtinguisherPercent
    {
      get { return m_fireExtinguisherPercent; }
      set { m_fireExtinguisherPercent = value; }
    }

    /// <summary>
    /// Fire extinguisher premium calculated in rating
    /// </summary>
    public virtual double FireExtinguisherPremium
    {
      get { return m_fireExtinguisherPremium; }
      set { m_fireExtinguisherPremium = value; }
    }

    /// <summary>
    /// Is claim free credit applicable?
    /// </summary>
    public virtual bool ClaimFree
    {
      get { return m_claimFree; }
      set { m_claimFree = value; }
    }

    /// <summary>
    /// Claim free discount percent
    /// </summary>
    public virtual double ClaimFreePercent
    {
      get { return m_claimFreePercent; }
      set { m_claimFreePercent = value; }
    }

    /// <summary>
    /// Claim free premium calculated in rating
    /// </summary>
    public virtual double ClaimFreePremium
    {
      get { return m_claimFreePremium; }
      set { m_claimFreePremium = value; }
    }

    /// <summary>
    /// Is companion policy credit applicable?
    /// </summary>
    public virtual bool CompanionPolicy
    {
      get { return m_companionPolicy; }
      set { m_companionPolicy = value; }
    }

    /// <summary>
    /// Companion policy discount percent
    /// </summary>
    public virtual double CompanionPolicyPercent
    {
      get { return m_companionPolicyPercent; }
      set { m_companionPolicyPercent = value; }
    }

    /// <summary>
    /// Companion policy premium calculated in rating
    /// </summary>
    public virtual double CompanionPolicyPremium
    {
      get { return m_companionPolicyPremium; }
      set { m_companionPolicyPremium = value; }
    }

    /// <summary>
    /// Is mature homeowner credit applicable?
    /// </summary>
    public virtual bool MatureHomeowner
    {
      get { return m_matureHomeowner; }
      set { m_matureHomeowner = value; }
    }

    /// <summary>
    /// Mature homeowner discount percent
    /// </summary>
    public virtual double MatureHomeownerPercent
    {
      get { return m_matureHomeownerPercent; }
      set { m_matureHomeownerPercent = value; }
    }

    /// <summary>
    /// Mature homeowner premium calculated in rating
    /// </summary>
    public virtual double MatureHomeownerPremium
    {
      get { return m_matureHomeownerPremium; }
      set { m_matureHomeownerPremium = value; }
    }

    /// <summary>
    /// Type of fire alarm
    /// </summary>
    public AlarmType FireAlarm
    {
      get { return m_fireAlarm; }
      set { m_fireAlarm = value; }
    }

    /// <summary>
    /// Calculated premium for Fire Alarm
    /// </summary>
    public double FireAlarmPremium
    {
      get { return m_fireAlarmPremium; }
      set { m_fireAlarmPremium = value; }
    }

    /// <summary>
    /// Type of burglar alarm
    /// </summary>
    public AlarmType BurglarAlarm
    {
      get { return m_burglarAlarm; }
      set { m_burglarAlarm = value; }
    }

    /// <summary>
    /// Calculated premium for Burglar Alarm
    /// </summary>
    public double BurglarAlarmPremium
    {
      get { return m_burglarAlarmPremium; }
      set { m_burglarAlarmPremium = value; }
    }

    /// <summary>
    /// Does the home have deadbolts?
    /// </summary>
    public bool Deadbolts
    {
      get { return m_deadbolts; }
      set { m_deadbolts = value; }
    }

    /// <summary>
    /// Calculated premium for Deadbolts
    /// </summary>
    public double DeadboltsPremium
    {
      get { return m_deadboltsPremium; }
      set { m_deadboltsPremium = value; }
    }

    /// <summary>
    /// Does the home have smoke detectors?
    /// </summary>
    public bool SmokeDetectors
    {
      get { return m_smokeDetectors; }
      set { m_smokeDetectors = value; }
    }

    /// <summary>
    /// Calculated premium for Smoke Detectors
    /// </summary>
    public double SmokeDetectorsPremium
    {
      get { return m_smokeDetectorsPremium; }
      set { m_smokeDetectorsPremium = value; }
    }

    /// <summary>
    /// Type of sprinklers
    /// </summary>
    public SprinklerType Sprinklers
    {
      get { return m_sprinklers; }
      set { m_sprinklers = value; }
    }

    /// <summary>
    /// Calculated premium for Automatic Sprinklers
    /// </summary>
    public double SprinklersPremium
    {
      get { return m_sprinklersPremium; }
      set { m_sprinklersPremium = value; }
    }

    /// <summary>
    /// Type of smoke alarm
    /// </summary>
    public AlarmType SmokeAlarm
    {
      get { return m_smokeAlarm; }
      set { m_smokeAlarm = value; }
    }

    /// <summary>
    /// Calculated premium for Smoke Alarm
    /// </summary>
    public double SmokeAlarmPremium
    {
      get { return m_smokeAlarmPremium; }
      set { m_smokeAlarmPremium = value; }
    }

    /// <summary>
    /// Brush Hazard
    /// </summary>
    public bool BrushHazard
    {
      get { return m_brushHazard; }
      set { m_brushHazard = value; }
    }

    /// <summary>
    /// Calculated premium for Brush Hazards
    /// </summary>
    public double BrushHazardPremium
    {
      get { return m_brushHazardPremium; }
      set { m_brushHazardPremium = value; }
    }

    /// <summary>
    /// Classification of UL Impact
    /// </summary>
    public ULImpactType ULImpactType
    {
      get { return m_ulImpactType; }
      set { m_ulImpactType = value; }
    }

    /// <summary>
    /// What auto policy does the insured have?
    /// </summary>
    public int AutoPolicy
    {
      get { return m_autoPolicy; }
      set { m_autoPolicy = value; }
    }

    /// <summary>
    /// Is there a device to protect against lightning
    /// </summary>
    public bool LightningProtection
    {
      get { return m_lightningProtection; }
      set { m_lightningProtection = value; }
    }

    /// <summary>
    /// Premium credit for Lightning Protection
    /// </summary>
    public double LightningProtectionPremium
    {
      get { return m_lightningProtectionPremium; }
      set { m_lightningProtectionPremium = value; }
    }

    /// <summary>
    /// Classification of UL Fire
    /// </summary>
    public ULFireType ULFireType
    {
      get { return m_ulFireType; }
      set { m_ulFireType = value; }
    }

    /// <summary>
    /// Credit premium for Non-Combustible Roof
    /// </summary>
    public double NonCombustibleRoofPremium
    {
      get { return m_nonCombustibleRoofPremium; }
      set { m_nonCombustibleRoofPremium = value; }
    }

    /// <summary>
    /// Home built by an accredited builder?
    /// </summary>
    public bool AccreditedBuilder
    {
      get { return m_accreditedBuilder; }
      set { m_accreditedBuilder = value; }
    }

    /// <summary>
    /// Premium credit for Accredited Builder
    /// </summary>
    public double AccreditedBuilderPremium
    {
      get { return m_accreditedBuilderPremium; }
      set { m_accreditedBuilderPremium = value; }
    }

    /// <summary>
    /// Is the property required to subscribe to a fire department?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool FireDepartmentSubscription
    {
      get { return m_fireDepartmentSubscription; }
      set { m_fireDepartmentSubscription = value; }
    }

    /// <summary>
    /// Premium charge for Fire Department Subscription
    /// </summary>
    public double FireDepartmentSubscriptionPremium
    {
      get { return m_fireDepartmentSubscriptionPremium; }
      set { m_fireDepartmentSubscriptionPremium = value; }
    }

    /// <summary>
    /// Type of gated community in which the property is located
    /// </summary>
    public GatedCommunityType GatedCommunity
    {
      get { return m_gatedCommunity; }
      set { m_gatedCommunity = value; }
    }

    /// <summary>
    /// Premium credit for a gated community
    /// </summary>
    public double GatedCommunityPremium
    {
      get { return m_gatedCommunityPremium; }
      set { m_gatedCommunityPremium = value; }
    }

    /// <summary>
    /// Apply a paperless discount
    /// </summary>
    public bool PaperlessDiscount
    {
      get { return m_paperlessDiscount; }
      set { m_paperlessDiscount = value; }
    }

    /// <summary>
    /// Premium credit for Paperless Discount
    /// </summary>
    public double PaperlessDiscountPremium
    {
      get { return m_paperlessDiscountPremium; }
      set { m_paperlessDiscountPremium = value; }
    }

    private bool m_alarmSystem;
    private double m_alarmSystemPercent;
    private double m_alarmSystemPremium;
    private bool m_newHome;
    private double m_newHomePercent;
    private double m_newHomePremium;
    private bool m_sprinklerSystem;
    private double m_sprinklerSystemPercent;
    private double m_sprinklerSystemPremium;
    private bool m_fireExtinguisher;
    private double m_fireExtinguisherPercent;
    private double m_fireExtinguisherPremium;
    private bool m_claimFree;
    private double m_claimFreePercent;
    private double m_claimFreePremium;
    private bool m_companionPolicy;
    private double m_companionPolicyPercent;
    private double m_companionPolicyPremium;
    private bool m_matureHomeowner;
    private double m_matureHomeownerPercent;
    private double m_matureHomeownerPremium;
    private AlarmType m_fireAlarm = AlarmType.None;
    private double m_fireAlarmPremium;
    private AlarmType m_burglarAlarm = AlarmType.None;
    private double m_burglarAlarmPremium;
    private bool m_deadbolts;
    private double m_deadboltsPremium;
    private bool m_smokeDetectors;
    private double m_smokeDetectorsPremium;
    private int m_autoPolicy = ITCConstants.InvalidNum;
    private SprinklerType m_sprinklers = SprinklerType.None;
    private double m_sprinklersPremium;
    private AlarmType m_smokeAlarm = AlarmType.None;
    private double m_smokeAlarmPremium;
    private bool m_brushHazard;
    private double m_brushHazardPremium;
    private ULImpactType m_ulImpactType = ULImpactType.None;
    private bool m_lightningProtection;
    private double m_lightningProtectionPremium;
    private ULFireType m_ulFireType = ULFireType.None;
    private double m_nonCombustibleRoofPremium;
    private bool m_accreditedBuilder;
    private double m_accreditedBuilderPremium;
    private bool m_fireDepartmentSubscription;
    private double m_fireDepartmentSubscriptionPremium;
    private GatedCommunityType m_gatedCommunity = GatedCommunityType.None;
    private double m_gatedCommunityPremium;
    private bool m_paperlessDiscount;
    private double m_paperlessDiscountPremium;
  }

}
