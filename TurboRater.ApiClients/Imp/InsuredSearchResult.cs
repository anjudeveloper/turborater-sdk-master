using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Represents an insured coming back from an online storage quote search.
  /// </summary>
  public class InsuredSearchResult
  {
    /// <summary>
    /// Gets or sets Identifier for this record
    /// </summary>
    public int RecordId { get; set; }

    /// <summary>
    /// Gets or sets Insured's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets Insured's middle name
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// Gets or sets Insured's last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets quotes from filters.
    /// </summary>
    public ICollection<QuoteSearchResult> Quotes { get; set; }
  }
}
