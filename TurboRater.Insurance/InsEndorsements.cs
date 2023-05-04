using System;
using System.Reflection;

namespace TurboRater.Insurance
{
  /// <summary>
  /// Base class for handling endorsements
  /// </summary>
  public class InsEndorsements : BaseStoredRecord
  {
    /// <summary>
    /// Default constructor.
    /// </summary>
    public InsEndorsements()
    {
    }

    /// <summary>
    /// Finds any property of type double that ends with "PREMIUM", and sets
    /// it to 0.0.
    /// </summary>
    public virtual void ZeroPremiums()
    {
      Type t = this.GetType();
      PropertyInfo[] pinfos = t.GetProperties();
      foreach (PropertyInfo pinfo in pinfos)
      {
        if ((pinfo.PropertyType == typeof(double)) && (pinfo.Name.ToUpper().EndsWith("PREMIUM", StringComparison.OrdinalIgnoreCase)))
          pinfo.SetValue(this, 0.0, null);
      }
    }

    /// <summary>
    /// Foreign key link to the policy
    /// </summary>
    public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    private int m_policyLinkID = ITCConstants.InvalidNum;
  }
}
