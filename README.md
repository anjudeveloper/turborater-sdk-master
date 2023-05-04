# turborater-sdk
## Synopsis

This library allows TurboRater clients to call into the Insurance Technologies Corporation TurboRater API. This can include quote storage operations, rating, and more.

This solution was created in Visual Studio 2013. All projects are currently targeting the .Net framework 4.0.

## API Documentation

The SDK uses the TurboRater API. For the latest API specification view the [TurboRater API Specification Documentation](https://github.com/getitc/turborater-sdk/wiki) and [TurboRater TurboTags Documentation](https://github.com/getitc/turbotags/wiki).

## Code Example - Create a Policy

For example, you can create a policy object that represents a TurboRater Insured, Policy (Quote), Drivers, Cars, etc.

```C#
public AUPolicy CreatePolicy(InsuranceLine lob)
    {
      var policy = new AUPolicy(lob);
      var insured = new AUDriver(TypeOfPerson.NamedInsured, lob);
      policy.Insured = insured;
      insured.Policy = policy;
      return policy;
    }
```

For further samples, please look in the dll named TurboRater.Samples contained within this solution.

## Installation

To use this library in your own project, all you have to do is reference the appropriate DLLs from this solution and add using statements for the appropriate namespaces. For example, with the above policy creation sample you would add references to the DLLs TurboRater.Insurance and TurboRater.Insurance.AU, then add the following using statements to your code:

```C#
using TurboRater.Insurance;
using TurboRater.Insurance.AU;
using TurboRater.Insurance.DataTransformation;
```

## Tests

There are a small but growing number of unit tests contained within the TurboRater.Samples project. These are short, concise unit tests (MSTest framework) that illustrate how to use our TurboRater objects.

## Updates

This SDK will be updated frequently. Please check back often to see the latest changes and additions.

## Want to help?

We are looking to port this library to PHP, Perl, Java, and Ruby on Rails. Feel free to contribute to the effort.

## Need help?

Please contact us using our [question and issue submission form](https://goo.gl/forms/rLKjrHg9oddGerAm1). 

