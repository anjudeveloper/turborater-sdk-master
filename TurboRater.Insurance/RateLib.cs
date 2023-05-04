
namespace TurboRater.Insurance
{
  /// <summary>
  /// This class has some generic methods to help with rating type functions.
  /// </summary>
  public class RateLib
  {
    /// <summary>
    /// Compares two limits. Returns 0 if they are equal, less than 0 if limit2
    /// is greater, and greater than 0 if limit1 is greater
    /// </summary>
    /// <param name="limit1">The first limit to compare</param>
    /// <param name="limit2">The 2nd limit to compare</param>
    /// <param name="ignoreThousands">If set to true, then it treats 20 as the same as 20000</param>
    /// <returns>Returns 0 if they are equal, less than 0 if limit2
    /// is greater, and greater than 0 if limit1 is greater</returns>
    public static int CompareLimits(int limit1, int limit2, bool ignoreThousands)
    {
      if (limit1 <= 1000)
      {
        limit1 *= 1000;

        // this cuts off the "500" in limits like OH with 12500 and such
        if (limit2 >= 1000)
        {
          limit2 /= 1000;
          limit2 *= 1000;
        }
      }
      if (limit2 <= 1000)
        limit2 *= 1000;
      return limit1.CompareTo(limit2);
    }
  }
}
