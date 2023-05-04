using System;
using System.Collections.Generic;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A list holder for miscellaneous premium items
  /// </summary>
  [Serializable]
  public class MiscPremiumList : List<MiscPremium>
  {

    /// <summary>
    /// Constructor. Allows you to associate a policy with the misc premium list.
    /// </summary>
    /// <param name="forPolicy">The policy that owns this list of misc premiums</param>
    public MiscPremiumList(InsPolicy forPolicy)
    {
      this.Policy = forPolicy;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public MiscPremiumList()
    {
    }

    /// <summary>
    /// The policy that owns this message list
    /// </summary>
    public virtual InsPolicy Policy
    {
      get { return m_policy; }
      set { m_policy = value; }
    }

    private InsPolicy m_policy;

  }//end class MiscPremiumList

}
