using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Represents the results of searching for quotes within Online Storage.
  /// </summary>
  public class StorageSearchResult
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StorageSearchResult" /> class.
    /// </summary>
    public StorageSearchResult()
    {
      Insureds = new List<InsuredSearchResult>();
    }

    /// <summary>
    /// Gets or sets A collection of insured's as a result of filter criteria.
    /// </summary>
    public ICollection<InsuredSearchResult> Insureds { get; set; }
  }
}
