using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Represents and endorsement limit.
  /// </summary>
  public class EndorsementLimit
  {
    /// <summary>
    /// The limit description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The limit value.
    /// </summary>
    public int Value { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    public EndorsementLimit()
    {
      Description = "Limit";
    }
  }
}
