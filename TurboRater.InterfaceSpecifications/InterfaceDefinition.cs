using System;
using System.Collections.Generic;

namespace TurboRater.InterfaceSpecifications
{
  /// <summary>
  /// the top level document for the entire interface. 
  /// </summary>
  public class InterfaceDefinition
  {
    /// <summary>
    /// Interface name
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Copyright information 
    /// </summary>
    public string Copyright { get; set; }

    /// <summary>
    /// Special remarks 
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// Interface version 
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Tabs/pages on the site
    /// </summary>
    public List<Tab> Tabs { get; set; }

    /// <summary>
    /// Constructor 
    /// </summary>
    public InterfaceDefinition()
    {
      Tabs = new List<Tab>();
      Title = "TurboRater Automobile Rating Interface";
      Copyright = "Insurance Technologies Corporation, 1983 - " + DateTime.Now.Year;
    }
  }
}
