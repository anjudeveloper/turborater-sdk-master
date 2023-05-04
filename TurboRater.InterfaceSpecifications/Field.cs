using System.Collections.Generic;
using System.ComponentModel;

namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// Generic Field object for all form fields in the interface 
  /// </summary>
  public class Field
  {
    /// <summary>
    /// Minimum value if applicable
    /// Note: If minimum value and maximum value are both 0
    /// validation will not run against these 2 fields
    /// </summary>
    public int? MinimumValue { get; set; }

    /// <summary>
    /// Maximum value if applicable
    /// Note: If minimum value and maximum value are both 0
    /// validation will not run against these 2 fields
    /// </summary>
    public int? MaximumValue { get; set; }

    /// <summary>
    /// Begin
    /// </summary>
    public int Begin { get; set; }

    /// <summary>
    /// End
    /// </summary>
    public int End { get; set; }

    /// <summary>
    /// Step
    /// </summary>
    public int Step { get; set; }

    /// <summary>
    /// Zero based Ordinal value to denote field position in section
    /// </summary>
    [DefaultValue(-1)]
    public int Ordinal { get; set; }

    /// <summary>
    /// Field ID 
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Type of field 
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Field Default Value
    /// </summary>
    public string DefaultValue { get; set; }

    /// <summary>
    /// Value field
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Pattern
    /// </summary>
    public string Pattern { get; set; }

    /// <summary>
    /// If the field requires or is dependant on other fields. 
    /// </summary>
    public string Dependency { get; set; }

    /// <summary>
    /// Validation Message
    /// </summary>
    public string ValidationMessage { get; set; }

    /// <summary>
    /// Uri of the Api that can send this information dynamically.
    /// </summary>
    public string UriApi { get; set; }

    /// <summary>
    /// List of items to fill the field if applicable. 
    /// </summary>
    public List<Item> Items { get; set; }

    /// <summary>
    /// Placeholder
    /// </summary>
    public Text Placeholder { get; set; }

    /// <summary>
    /// Field Label 
    /// </summary>
    public Text Label { get; set; }

    /// <summary>
    /// Help text for the field 
    /// </summary>
    public Text HelpText { get; set; }

    /// <summary>
    /// Settings to be applied to the field
    /// </summary>
    public Settings Settings { get; set; }

    /// <summary>
    /// Mappings for communicating the information 
    /// </summary>
    public Mappings Mappings { get; set; }

    /// <summary>
    /// Constructor 
    /// </summary>
    public Field()
    {
      Mappings = new Mappings();
      Settings = new Settings();
      Placeholder = new Text();
      Items = new List<Item>();
      Label = new Text();
      HelpText = new Text();
      Value = "";
    }
  }
}
