using System.Collections.Generic;

namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// Visually distinct group in the section
  /// </summary>
  public class Group
  {
    /// <summary>
    /// Wether or not the group is visible 
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// The groups zero based ordinal value on the page 
    /// </summary>
    public int Ordinal { get; set; }

    /// <summary>
    /// The Panels ID 
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Title of the group 
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Additional Remark 
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// Non-zero based number of times this group can be repeated 
    /// </summary>
    public int Length { get; set; }

    /// <summary>
    /// Applies to driver or car option 
    /// </summary>
    public string AppliesTo { get; set; }

    /// <summary>
    /// List of fields in the group 
    /// </summary>
    public List<Field> Inputs { get; set; }

    /// <summary>
    /// Constructor 
    /// </summary>
    public Group()
    {
      Inputs = new List<Field>();
    }
  }
}
