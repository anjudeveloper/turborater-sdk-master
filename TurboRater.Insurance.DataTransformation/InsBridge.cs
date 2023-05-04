using System.IO;

namespace TurboRater.Insurance.DataTransformation
{
  /// <summary>
  /// Summary description for InsExport.
  /// </summary>
  public class InsBridge
  {

    private InsPolicy m_policy;
    private USState m_productState = USState.NoneSelected;

    /// <summary>
    /// The US state of the product that is performing the
    /// bridge.
    /// </summary>
    public virtual USState ProductState
    {
      get { return m_productState; }
      set { m_productState = value; }
    }

    /// <summary>
    /// The Insurance level Policy object associated with
    /// this bridge.
    /// </summary>
    public virtual InsPolicy Policy
    {
      get { return m_policy; }
      set { m_policy = value; }
    }

    /// <summary>
    /// If all you need to do is import premium information and pay plans and such, use this procedure.
    /// It assumes you already have cars populated with coverages, limits, deductibles, assumes
    /// you already have populated drivers, etc. This procedure is used by real-time rating to 
    /// import the premiums and such sent back from the company.
    /// </summary>
    public virtual void ImportCompanyQuote()
    {
    }

    /// <summary>
    /// Child classes will override me to import data into a policy object (and other objects)
    /// </summary>
    public virtual void ImportPolicyInfo()
    {
    }

    /// <summary>
    /// Child classes will override me to import data into a policy object (and other objects)
    /// </summary>
    public virtual void ImportPolicyRequestInfo()
    {
    }

    /// <summary>
    /// Child classes will override me to export data from a policy object (and other objects)
    /// </summary>
    public virtual string ExportPolicyInfo()
    {
      return "";
    }

    /// <summary>
    /// Child classes will override this method to toggle all flags we have that prevent us from 
    /// sending particular bridging information to default bridges so that we can send a more 
    /// complete bridge to customers that can handle the data.
    /// </summary>
    public virtual void TriggerAllBridgeOptions()
    {
    }

    /// <summary>
    /// Saves the bridge object to a file. Note that this uses the ToString() method
    /// of the bridge object in order to determine the contents that will go into
    /// the file. So, you must override the ToString() method in your descendant
    /// class if you wish to use this method properly.
    /// </summary>
    /// <param name="aFileName">The fully qualified path and name of the file
    /// you wish to save the bridge object to.</param>
    public void SaveToFile(string aFileName)
    {
      TextWriter writer = File.CreateText(aFileName);
      writer.Write(this.ToString());
      writer.Flush();
      writer.Close();
    }

    public InsBridge()
    {
    }
  }
}
