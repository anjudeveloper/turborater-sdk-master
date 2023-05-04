using System.Collections.Generic;
using System.ComponentModel;

namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// Tabs on the interface
  /// Corresponds to differnt pages in the interface. 
  /// </summary>
  public class Tab
  {
    /// <summary>
    /// Tab ID 
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Title of the tab. 
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Zero based Order of the tabs
    /// </summary>
    [DefaultValue(-1)]
    public int Ordinal { get; set; }

    /// <summary>
    /// List of sections on the tab 
    /// </summary>
    public List<Section> Sections { get; set; }

    /// <summary>
    /// Constructor 
    /// </summary>
    public Tab()
    {
      Sections = new List<Section>();
    }
  }
}
