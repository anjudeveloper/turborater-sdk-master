using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurboRater.Insurance;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Results of a quote load operation
  /// </summary>
  public class QuoteLoadResult
  {
    /// <summary>
    /// Gets or sets The quote/policy as <c>acord</c> xml
    /// </summary>
    public string QuoteData { get; set; }

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

    /// <summary>
    /// Gets or sets The most recent rating results for this policy (only applicable for AU policies currently, 2/4/2015)
    /// </summary>
    public IList<RateAnalysisResult> RateAnalysisResults { get; set; }
  }
}
