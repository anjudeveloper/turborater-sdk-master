using System.ComponentModel;
using System.Linq;

namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// Object to manage mapping TT2 fields to interface fields 
  /// </summary>
  public class Tt2Mapping
  {
    private string m_scopePrefix = string.Empty;
    private int m_scopeNumber;

    /// <summary>
    ///  Initializes a new instance of the <see cref="Tt2Mapping"/> class.
    /// </summary>
    public Tt2Mapping()
    {
      FullEnforcement = false;
    }

    /// <summary>
    /// Gets or sets a value which indicates verbose validation will occur.
    /// </summary>
    public bool FullEnforcement { get; set; }

    /// <summary>
    /// Tag Name
    /// </summary>
    public string[] TagNames { get; set; }

    /// <summary>
    /// Prefix for the scope 
    /// pol : policy 
    /// car : car 
    /// drv : driver 
    /// mpr : misc premium 
    /// quo : quote 
    /// vio : violation 
    /// </summary>
    public string ScopePrefix
    {
      get { return m_scopePrefix; }
      set
      {
        m_scopePrefix = value;
      }
    }

    /// <summary>
    /// Identifies the specific object at the current scope 
    /// Example // if the scope is Car it would represent the car number. 
    /// </summary>
    [DefaultValue(-1)]
    public int ScopeNumber
    {
      get { return m_scopeNumber; }
      set
      {
        m_scopeNumber = value;
      }
    }

    /// <summary>
    /// Is the field required? 
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// Demiliter character for a field 
    /// </summary>
    public string Delimiter { get; set; }
  }
}
