using System;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// notes/highlights on a single carrier rating response
  /// </summary>
  public sealed class SummaryItem
  {
    #region Public Properties
    /// <summary>
    /// 40 Character feature highlight.
    /// </summary>
    public string Highlight { get; set; }
    /// <summary>
    /// 80 character description of highlight.
    /// </summary>
    public string Descripton { get; set; }
    #endregion

    /// <summary>
    /// The default constructor.
    /// </summary>
    public SummaryItem()
    {
      Highlight = String.Empty;
      Descripton = String.Empty;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="highlight">feature highlight</param>
    /// <param name="description">description of highlight</param>
    public SummaryItem(string highlight, string description)
    {
      Highlight = highlight;
      Descripton = description;
    }
  }
}
