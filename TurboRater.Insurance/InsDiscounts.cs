using System;
using System.Reflection;

namespace TurboRater.Insurance
{
  /// <summary>
  /// Base class for handling discounts 
  /// </summary>
  [Serializable]
  public class InsDiscounts : BaseStoredRecord
  {
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
    /// Foreign key link back to the policy
    /// </summary>
    public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// Total premium of all discounts encompassed by the object
    /// </summary>
    public virtual double TotalPremium
    {
      get { return m_totalPremium; }
      set { m_totalPremium = value; }
    }

    private int m_policyLinkID = ITCConstants.InvalidNum;
    private double m_totalPremium;
  }
}
