using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Represents an API HO entry.
  /// </summary>
  public class HOCustomEntry
  {
    /// <summary>
    /// The type of data for this entry.
    /// </summary>
    public string DataType { get; set; }

    /// <summary>
    /// The list of items if the entry is a dropdown.
    /// </summary>
    public List<ApiListItem> ListItems { get; set; }

    /// <summary>
    /// The name used to identify this entry.
    /// </summary>
    public string Identifier { get; set; }

    /// <summary>
    /// The caption text for this entry.
    /// </summary>
    public string CaptionText { get; set; }

    /// <summary>
    /// The default value of the entry.
    /// </summary>
    public string DefaultValue { get; set; }
  }
}
