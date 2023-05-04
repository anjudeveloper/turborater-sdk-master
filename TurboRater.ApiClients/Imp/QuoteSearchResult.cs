using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Represents a quote coming back from an online storage quote search.
  /// </summary>
  public class QuoteSearchResult
  {
    /// <summary>
    /// Gets or sets Identifier for this record.
    /// </summary>
    public int RecordId { get; set; }

    /// <summary>
    /// Gets or sets Date/time the quote was created
    /// </summary>
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// Gets or sets Date/time the quote was last modified
    /// </summary>
    public DateTime LastModified { get; set; }

    /// <summary>
    /// Gets or sets Line of insurance
    /// </summary>
    public string InsuranceLine { get; set; }
  }
}
