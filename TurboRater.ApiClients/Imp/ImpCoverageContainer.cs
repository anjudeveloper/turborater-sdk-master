using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Contains a list of coverages for a state.  Used to determine liability limits to match to prior limits in the
  /// free form entry.
  /// </summary>
  [Serializable]
  public class ImpCoverageContainer
  {
    /// <summary>
    /// State code.
    /// </summary>
    public string StateProvCd { get; set; }

    /// <summary>
    /// Line of Business.
    /// </summary>
    public string LOBCd { get; set; }

    /// <summary>
    /// The valid coverages.
    /// </summary>
    public List<ImpCoverage> Coverages { get; set; }
  }
}
