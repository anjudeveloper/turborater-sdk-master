using System;

namespace TurboRater.Insurance
{
  /// <summary>
  /// Base clasee for comparison units (cars, drivers, etc).
  /// </summary>
  [Serializable]
  public abstract class ComparisonUnit
  {
    /// <summary>
    /// The scope of this unit.
    /// </summary>
    public abstract ItemScope UnitScope { get; }
  }
}
