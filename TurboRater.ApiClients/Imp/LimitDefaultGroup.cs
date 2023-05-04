using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// A group of default limits.
  /// </summary>
  public class LimitDefaultGroup
  {
    /// <summary>
    /// Default Liability BI limit.
    /// </summary>
    public int[] LiabilityBILimits { get; set; }

    /// <summary>
    /// Default liability PD limit.
    /// </summary>
    public int? LiabilityPDLimits { get; set; }

    /// <summary>
    /// Default PIP Limits. 
    /// </summary>
    public int? PIPLimits { get; set; }

    /// <summary>
    /// Default med pay limit.
    /// </summary>
    public int? MedPayLimits { get; set; }

    /// <summary>
    /// Default uninsured BI limit.
    /// </summary>
    public int[] UninsuredBILimits { get; set; }

    /// <summary>
    /// Default uninsured PD limit.
    /// </summary>
    public int? UninsuredPDLimits { get; set; }

    /// <summary>
    /// Default underinsured BI limit.
    /// </summary>
    public int[] UnderinsuredBILimits { get; set; }

    /// <summary>
    /// Default rental limit.
    /// </summary>
    public int? RentalLimits { get; set; }

    /// <summary>
    /// Default towing limit.
    /// </summary>
    public int? TowingLimits { get; set; }

  }
}
