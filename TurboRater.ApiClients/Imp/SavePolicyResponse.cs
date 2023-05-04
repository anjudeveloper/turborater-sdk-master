using TurboRater.InterfaceSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Response to a save policy request.
  /// </summary>
  public class SavePolicyResponse
  {
    /// <summary>
    /// Gets or sets the record id for the policy.
    /// </summary>
    public int PolicyId { get; set; }

    /// <summary>
    /// Gets or sets a list of the errors.
    /// </summary>
    public List<TT2ValidationError> ValidationErrors { get; set; }
    /// <summary>
    /// Gets or sets The url to the quote.
    /// </summary>
    public string QuoteUrl { get; set; }

    /// <summary>
    /// Gets or sets The url to the summary.
    /// </summary>
    public string BreakdownUrl { get; set; }

    /// <summary>
    /// Gets or sets The url to the Compare.
    /// </summary>
    public string CompareUrl { get; set; }
  }
}
