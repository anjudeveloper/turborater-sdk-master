using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Text/Value pair for use with API.
  /// </summary>
  public class ApiListItem
  {
    /// <summary>
    /// The text of the item.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// The value of the item.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ApiListItem()
    {
    }
  }
}
