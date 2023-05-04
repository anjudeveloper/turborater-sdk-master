
namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// Mappings object for each field 
  /// </summary>
  public class Mappings
  {
    /// <summary>
    /// Corresponding TT2 value 
    /// </summary>
    public Tt2Mapping Tt2 { get; set; }

    /// <summary>
    /// Acord form value 
    /// </summary>
    public string HtmlAcord { get; set; }

    public Mappings()
    {
      Tt2 = new Tt2Mapping();
    }
  }
}
