using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurboRater.Insurance;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Quote load result from imp with auto-desrialized policy.
  /// </summary>
  public class QuoteLoadWrapper
  {
    /// <summary>
    /// The policy returned by the quote load request.
    /// </summary>
    public InsPolicy Policy { get; set; }

    /// <summary>
    /// The full response information about the quote from IMP.
    /// </summary>
    public QuoteLoadResult QuoteLoadInfo { get; set; }
  }
}
