
namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// Settings object for fields 
  /// denotes attributes of the field. 
  /// </summary>
  public class Settings
  {
    /// <summary>
    /// Minimum length 
    /// Note: If minimum length and maximum length are both 0
    /// validation will not run against these 2 fields
    /// </summary>
    public int MinimumLength { get; set; }

    /// <summary>
    /// Maximum length 
    /// Note: If minimum length and maximum length are both 0
    /// validation will not run against these 2 fields
    /// </summary>
    public int MaximumLength { get; set; }

    /// <summary>
    /// Is the field required? 
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// Is the field visible? 
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// Is the Field enabled/disabled? 
    /// </summary>
    public bool Disabled { get; set; }

    /// <summary>
    /// Default value of the field. 
    /// </summary>
    public string Default { get; set; }

    /// <summary>
    /// Edit mask for the field. 
    /// </summary>
    public string Mask { get; set; }
  }
}
