using TurboRater;
using System;
using TurboRater.Insurance.AU;
using TurboRater.Insurance.HO;

namespace TurboRater.Insurance.DataTransformation
{
  /// <summary>
  /// Provides helper methods for dealing with policy transformations.
  /// </summary>
  public static class TransformationHelper
  {
    /// <summary>
    /// Exports a policy to a string.
    /// </summary>
    /// <param name="policy">The policy to export.</param>
    /// <returns>The exported policy as a string.</returns>
    public static string SerializePolicy(InsPolicy policy)
    {
      if (policy is AUPolicy)
      {
        TT2AUBridge bridge = new TT2AUBridge();
        bridge.Policy = (AUPolicy)policy;
        return bridge.ExportPolicyInfo();
      }
      else if (policy is HOPolicy)
      {
        return Serializer.SerializeToXMLString((HOPolicy)policy, new Type[] { typeof(PropertyPerson) });
      }
      else
      {
        throw new Exception("Insurance line not supported.");
      }
    }

    /// <summary>
    /// Imports a policy from string and returns a policy object.
    /// </summary>
    /// <param name="policyData">The serialized policy data (TT2, xml, etc).</param>
    /// <param name="line">The line of insurance.</param>
    /// <returns>An object created from the policy data string.</returns>
    public static InsPolicy DeserializePolicy(string policyData, InsuranceLine line)
    {
      switch (line)
      {
        case InsuranceLine.PersonalAuto:
        case InsuranceLine.Motorcycle:
          AUPolicy auPolicy = new AUPolicy();
          auPolicy.Insured = new AUDriver(TypeOfPerson.NamedInsured) { ParentPolicy = auPolicy };
          auPolicy.Insured.Policy = auPolicy;
          /*
           -- ACORD XML: Future
          if (policyData.IndexOf("<acord", StringComparison.OrdinalIgnoreCase) > -1) //import as acord xml
          {
            AcordXmlAUBridge xmlBridge = new AcordXmlAUBridge();
            xmlBridge.PassIndustryOccupationValues = true; //Import industry/occupation

            auPolicy = new AUPolicy(InsuranceLine.PersonalAuto);
            AUDriver insured = new AUDriver(TypeOfPerson.NamedInsured);
            auPolicy.Insured = insured;
            insured.Policy = auPolicy;
            AUCar car = new AUCar();
            AUDriver driver = new AUDriver();

            //Don't ask...requires we add the first car and driver on our own.
            auPolicy.Cars.Add(car);
            auPolicy.Drivers.Add(driver);
            xmlBridge.Policy = auPolicy;

            xmlBridge.XmlImportData = policyData.Replace("utf-16", "utf-8").Replace("Rs>", "Rq>").Replace("Rs/>", "Rq/>").Replace("Rs />", "Rq />").Replace("<Rs", "<Rq").Replace("</Rs", "</Rq");
            xmlBridge.ImportPolicyRequestInfo();
          }
          else*/ if (policyData.IndexOf("<?xml", StringComparison.OrdinalIgnoreCase) > -1) //import as serialized xml object
          {
            auPolicy = (AUPolicy)Serializer.DeserializeFromXMLString<AUPolicy>(policyData, new Type[] { typeof(AUDriver) });
          }
          else //import as tt2
          {
            TT2AUBridge bridge = new TT2AUBridge(policyData, auPolicy);
            bridge.Tags.Items.Sort();
            bridge.Tags.Sorted = true;
            bridge.ImportPolicyInfo();
          }
          return auPolicy;
      case InsuranceLine.Homeowners:
      case InsuranceLine.DwellingFire: 
        HOPolicy hoPolicy = new HOPolicy();
        hoPolicy = Serializer.DeserializeFromXMLString<HOPolicy>(policyData, new Type[] { typeof(PropertyPerson) });
        return hoPolicy;
        default:
          throw new Exception("Insurance line not supported.");
      }
    }

    /// <summary>
    /// Deserializes a policy from an XML or TT2 string.
    /// </summary>
    /// <typeparam name="TPolicy">The type of policy to deserialize.</typeparam>
    /// <param name="policyData">The policy data to deserialize.</param>
    /// <returns>The deserialized policy.</returns>
    public static TPolicy DeserializePolicy<TPolicy>(string policyData) where TPolicy : InsPolicy, new()
    {
      Type policyType = typeof(TPolicy);
      switch (policyType.Name)
      {
        case "AUPolicy": return (TPolicy)DeserializePolicy(policyData, InsuranceLine.PersonalAuto);
        case "HOPolicy": return (TPolicy)DeserializePolicy(policyData, InsuranceLine.Homeowners);
        default:
          throw new ArgumentException("Insurance line not supported.");
      }
    }

    /// <summary>
    /// Creates a copy of an Auto policy.
    /// </summary>
    /// <param name="policy">Policy to copy</param>
    /// <returns>Cloned policy</returns>
    public static AUPolicy ClonePolicy(AUPolicy policy)
    {
      TT2AUBridge cloningBridge;
      TT2AUBridge bridge = new TT2AUBridge("", policy);
      AUPolicy clonedPolicy;
      clonedPolicy = new AUPolicy();
      clonedPolicy.Insured = new AUDriver() { ParentPolicy = clonedPolicy };
      cloningBridge = new TT2AUBridge(bridge.ExportPolicyInfo(), clonedPolicy);
      cloningBridge.ImportPolicyInfo();
      return clonedPolicy;
    }

  }
}
