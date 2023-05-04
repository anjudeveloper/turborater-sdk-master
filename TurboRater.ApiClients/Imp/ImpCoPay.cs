using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Represents an IMP co-pay.
  /// </summary>
  public class ImpCoPay
  {
    /// <summary>
    /// The first co-pay value.
    /// </summary>
    public int Val1 { get; set; }

    /// <summary>
    /// The second co-pay value.
    /// </summary>
    public int Val2 { get; set; }
  }
}
