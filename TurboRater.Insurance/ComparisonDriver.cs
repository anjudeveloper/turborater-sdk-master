using System;

namespace TurboRater.Insurance
{
  /// <summary>
  /// Stores additional comparison information about a driver.
  /// </summary>
  [Serializable]
  public class ComparisonDriver : ComparisonUnit
  {
#pragma warning disable 1591 //dont' really need warnings about xml comments for the properties of this class

    public string DriverClass { get; set; }
    public int Points { get; set; }
    public override ItemScope UnitScope { get { return ItemScope.Driver; } }
  }
}
