using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A homeowner deductible.
  /// </summary>
  public class HODeductible
  {
    /// <summary>
    /// The deductible value.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// The deductible type.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// The deductible premium.
    /// </summary>
    public double Premium { get; set; }

    /// <summary>
    /// The deductible name.
    /// </summary>
    public string DeductibleName { get; set; }
  }
}
