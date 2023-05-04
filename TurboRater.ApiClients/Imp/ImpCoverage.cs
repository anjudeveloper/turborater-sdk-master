using System;
using System.Collections.Generic;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Represents an Imp Coverage.
  /// </summary>
  [Serializable]
  public class ImpCoverage
  {
    /// <summary>
    /// The coverage code.
    /// </summary>
    public string CoverageCd { get; set; }

    /// <summary>
    /// Is the coverage required?
    /// </summary>
    public bool IsRequired { get; set; }

    /// <summary>
    /// Is the limit free form entry?
    /// </summary>
    public bool IsFreeEntry { get; set; }

    /// <summary>
    /// The scope of the coverage.
    /// </summary>
    public string Scope { get; set; }

    /// <summary>
    /// The list of limits.
    /// </summary>
    public List<ImpLimit> Limits { get; set; }

    /// <summary>
    /// The list of limits.
    /// </summary>
    public List<ImpDed> Deductibles { get; set; }

    /// <summary>
    /// List of co-pays.
    /// </summary>
    public List<ImpCoPay> CoPays { get; set; }

    /// <summary>
    /// The extra codes.
    /// </summary>
    public string ExtraCodes { get; set; }
  }
}
