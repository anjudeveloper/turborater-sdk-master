using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Represents an API HO company endorsement.
  /// </summary>
  public class HOCompanyEndorsement
  {
    /// <summary>
    /// The name used to identify this endorsement.
    /// </summary>
    public string Identifier { get; set; }

    /// <summary>
    /// Additional sub-questions for this endorsement.
    /// </summary>
    public List<HOCustomEntry> Questions { get; set; }
  }
}
