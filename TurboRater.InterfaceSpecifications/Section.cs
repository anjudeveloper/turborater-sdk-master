using System.Collections.Generic;

namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// Visually distinct section on the interface 
  /// </summary>
  public class Section
  {
    /// <summary>
    /// Wether or not the section is visible 
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// The sections zero based ordinal value on the page 
    /// </summary>
    public int Ordinal { get; set; }

    /// <summary>
    /// The Panels ID 
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Title of the section 
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Additional Remark 
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// Non-zero based number of times this section can be repeated 
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// List of groups in the section 
    /// </summary>
    public List<Group> Groups { get; set; }

    /// <summary>
    /// Constructor 
    /// </summary>
    public Section()
    {
      Groups = new List<Group>();
    }
  }
}
