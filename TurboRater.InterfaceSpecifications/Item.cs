
namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// Items to fill a field 
  /// </summary>
  public class Item
  {
    /// <summary>
    /// the text diplayed for this item
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// The item value posted back 
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Uri of the Api that can send this information dynamically.
    /// </summary>
    public string UriApi { get; set; }
  }
}
