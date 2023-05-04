using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TurboRater.Insurance;
using TurboRater.Insurance.AU;
using TurboRater.Insurance.DataTransformation;

namespace TurboRater.Samples
{
  [TestClass]
  public class AUSamples
  {
    /// <summary>
    /// Creates an AU-based policy of the specified LOB. 
    /// (note: both automobile and motorcycle policies are of the AUPolicy type.)
    /// </summary>
    /// <param name="lob">Line of Business.</param>
    /// <returns>the newly minted policy.</returns>
    public AUPolicy CreatePolicy(InsuranceLine lob)
    {
      var policy = new AUPolicy(lob);
      var insured = new AUDriver(TypeOfPerson.NamedInsured, lob);
      policy.Insured = insured;
      insured.Policy = policy;
      policy.MailingAddress.State = USState.Texas;
      return policy;
    }

    /// <summary>
    /// Test: add a spouse of the insured as a 2nd driver.
    /// This is just a sample illustrating how to add a spouse, so we are
    /// only making sure no exceptions are thrown.
    /// </summary>
    [TestMethod]
    public void AddSpouseOfInsuredDriver()
    {
      //setup insured as married male
      var policy = CreatePolicy(InsuranceLine.PersonalAuto);
      policy.Drivers.Add(new AUDriver() { Sex = ITCConstants.GenderChars[(int)Gender.Male], Gender = ITCConstants.GenderChars[(int)Gender.Male], Marital = ITCConstants.MaritalChars[(int)Maritals.Married], Relation = ITCConstants.RelationChars[(int)Relation.Insured] });

      //add spouse
      var spouseDriver = new AUDriver()
      {
        Sex = ITCConstants.GenderChars[(int)Gender.Female],
        Gender = ITCConstants.GenderChars[(int)Gender.Female],
        Marital = ITCConstants.MaritalChars[(int)Maritals.Married],
        Relation = ITCConstants.RelationChars[(int)Relation.Spouse],
      };
      policy.Drivers.Add(spouseDriver);
    }

    /// <summary>
    /// Test: Add a violation to a driver.
    /// This is just a sample illustrating how to add a violation, so we are
    /// only making sure no exceptions are thrown.
    /// </summary>
    [TestMethod]
    public void AddViolation()
    {
      var policy = CreatePolicy(InsuranceLine.PersonalAuto);
      policy.Drivers.Add(new AUDriver());
      var violation = new AUViolation() { ViolCode = AUConstants.vcSpeeding, ViolDate = DateTime.Now };
      policy.Drivers[0].Violation.Add(violation);
    }

    /// <summary>
    /// Test: A simple export of a 1-car 1-driver policy.
    /// </summary>
    [TestMethod]
    public void TT2Export_1C1D()
    {
      var bridge = new TT2AUBridge();
      bridge.Policy = CreatePolicy(InsuranceLine.PersonalAuto);
      bridge.Policy.Cars.Add(new AUCar() { Year = 2015, Maker = "Toyota", Model = "Camry" });
      bridge.Policy.Drivers.Add(new AUDriver() { FirstName = "TestFirst", LastName = "TestLast", DOB = DateTime.Parse("01/01/1980") });
      var tt2 = bridge.ExportPolicyInfo();
      Assert.IsFalse(String.IsNullOrWhiteSpace(tt2), "tt2 data should not be null or empty");
    }

    /// <summary>
    /// Test: A simple import of a 1-car 1-driver policy.
    /// </summary>
    [TestMethod]
    public void TT2Import_1C1D()
    {
      var tt2 = System.Text.ASCIIEncoding.ASCII.GetString(Properties.Resources._1c1d_simple);
      var policy = CreatePolicy(InsuranceLine.PersonalAuto);
      var bridge = new TT2AUBridge(tt2, policy);
      
      //sorting speeds up tt2 imports greatly, though it's not necessary for an import to function
      bridge.Tags.Items.Sort();
      bridge.Tags.Sorted = true;

      bridge.ImportPolicyInfo();
      Assert.AreEqual("TestFirst", policy.Drivers[0].FirstName);
      Assert.AreEqual("Toyota", policy.Cars[0].Maker);
    }

    [TestMethod]
    public void XMLSerializeExport_1C1D()
    {
      var policy = CreatePolicy(InsuranceLine.PersonalAuto);
      policy.Insured.FirstName = "TestFirst";
      policy.Insured.MiddleName = "TestMiddle";
      policy.Insured.LastName = "TestLast";
      policy.Insured.DOB = DateTime.Parse("01/01/1980");
      policy.Cars.Add(new AUCar() { Year = 2015, Maker = "Toyota", Model = "Camry Hybrid", VIN = "4T1BD1FK0F" });
      policy.Drivers.Add(new AUDriver());
      policy.CopyInsuredInfoToInsuredDriver();
      policy.Drivers[0].DrvLicenseNumber = "12345678";
      policy.Drivers[0].Violation.Add(new AUViolation() { ViolCode = AUConstants.vcAccAtFault, AtFault = true, ViolDate = DateTime.Parse("01/01/2018") });
      policy.Term = 6;
      policy.PaymentMethod = PaymentMethod.PIF;
      if (policy.CompanyQuestions["ManualCreditScore"] == null)
      {
        CompanyQuestion question = new CompanyQuestion();
        question.Name = "ManualCreditScore";
        policy.CompanyQuestions.Add(question);
      }
      policy.CompanyQuestions["ManualCreditScore"].Value = "3";
      policy.Quote.LeadSource = "Internet";
      policy.Drivers[0].MonthsLicensed = 100;
      policy.Drivers[0].MonthsLicensedState = 100;
      policy.Drivers[0].MonthsMVRExper = 100;
      var xml = Serializer.SerializeToXMLString(policy, new Type[] { typeof(AUDriver), typeof(AUCar) });
    }

    /// <summary>
    /// Test: Copying of insured driver (the 1st driver on the policy) information to the actual insured (property of the policy object).
    /// </summary>
    [TestMethod]
    public void CopyInsuredDriverInfoToInsured()
    {
      var policy = CreatePolicy(InsuranceLine.PersonalAuto);
      policy.Drivers.Add(new AUDriver() { FirstName = "TestFirst", LastName = "TestLast", DOB = DateTime.Parse("01/01/1980") });
      policy.CopyInsuredDriverInfoToInsured();
      Assert.AreEqual(policy.Drivers[0].FirstName, policy.Insured.FirstName);
      Assert.AreEqual(policy.Drivers[0].LastName, policy.Insured.LastName);
      Assert.AreEqual(policy.Drivers[0].DOB, policy.Insured.DOB);
    }

    /// <summary>
    /// Test: Copying of insured information (property of the policy object) to the insured driver (1st driver on the policy).
    /// </summary>
    [TestMethod]
    public void CopyInsuredInfoToInsuredDriver()
    {
      var policy = CreatePolicy(InsuranceLine.PersonalAuto);
      policy.Drivers.Add(new AUDriver());
      policy.Insured.FirstName = "InsuredFirst";
      policy.Insured.LastName = "InsuredLast";
      policy.Insured.DOB = DateTime.Parse("01/01/1970");
      policy.CopyInsuredInfoToInsuredDriver();
      Assert.AreEqual(policy.Drivers[0].FirstName, policy.Insured.FirstName);
      Assert.AreEqual(policy.Drivers[0].LastName, policy.Insured.LastName);
      Assert.AreEqual(policy.Drivers[0].DOB, policy.Insured.DOB);
    }

  }
}
