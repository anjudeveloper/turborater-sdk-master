using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Additional information about an endorsement.
  /// </summary>
  public class EndorsementAdditionalData
  {
    /// <summary>
    /// Description of the additional data.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The value of the data.
    /// </summary>
    public string Value { get; set; }
  }
}
