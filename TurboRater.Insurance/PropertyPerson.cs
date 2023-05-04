using System;

namespace TurboRater.Insurance
{
  /// <summary>
  /// Represents a person (named insured mostly) for an HO policy.
  /// </summary>
  [Serializable]
  public class PropertyPerson : Person
  {
    /// <summary>
    /// Default constructor
    /// </summary>
    public PropertyPerson() : base()
    {
      PolicyType = InsuranceLine.Homeowners;
    }

    /// <summary>
    /// constructor that lets you specify the type of person
    /// </summary>
    /// <param name="aPersonType">The type of person that this is</param>
    public PropertyPerson(TypeOfPerson aPersonType) : base(aPersonType)
    {
      PolicyType = InsuranceLine.Homeowners;
    }

    /// <summary>
    /// Constructor that allows you to specify the type of person and the policy type.
    /// </summary>
    /// <param name="aPersonType">the type of person</param>
    /// <param name="aPolicyType">The type of policy this user is being created for.</param>
    public PropertyPerson(TypeOfPerson aPersonType, InsuranceLine aPolicyType)
      : base(aPersonType, aPolicyType)
    {
    }
  }
}
