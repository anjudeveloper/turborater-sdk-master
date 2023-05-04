using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Represents an Imp Limit.
  /// </summary>
  [Serializable]
  public class ImpLimit
  {
    /// <summary>
    /// The first limit value.
    /// </summary>
    public int Val1 { get; set; }

    /// <summary>
    /// The second limit value.
    /// </summary>
    public int Val2 { get; set; }

    /// <summary>
    /// The third limit value.
    /// </summary>
    public int Val3 { get; set; }
  }
}
