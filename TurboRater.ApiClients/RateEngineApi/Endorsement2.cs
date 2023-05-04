using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A property rating endorsement.
  /// </summary>
  public class Endorsement2
  {
    /// <summary>
    /// The name of the coverage.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The premium for the coverage.
    /// </summary>
    public double Premium { get; set; }

    /// <summary>
    /// The limits.
    /// </summary>
    public List<EndorsementLimit> Limits { get; set; }

    /// <summary>
    /// Additional scheduled items and premiums.
    /// </summary>
    public List<Coverage> ScheduledItems { get; set; }

    /// <summary>
    /// List of additional data items.
    /// </summary>
    public List<EndorsementAdditionalData> AdditionalData { get; set; }

    /// <summary>
    /// Identifier (variable name) of the endorsement.
    /// </summary>
    public string Identifier { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public Endorsement2()
    {
      Name = String.Empty;
    }
  }
}
