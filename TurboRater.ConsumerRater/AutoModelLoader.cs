using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurboRater.Insurance.AU;

namespace TurboRater.ConsumerRater
{
	/// <summary>
	/// class used to populate UI fields in Consumer Rater (TurboRater for Websites)
	/// </summary>
	public class AutoModelLoader
	{
		// policy info

		/// <summary>
		/// Effective date of policy/quote
		/// </summary>
		public DateTime EffectiveDate { get; set; }
		/// <summary>
		/// Named Insured's Email address
		/// </summary>
		public string EmailAddress { get; set; }
		/// <summary>
		///  Named Insured's Phone number
		/// </summary>
		public string PhoneNumber { get; set; }
		/// <summary>
		/// Lead Source / How did you hear about us? - Value if provided must match the values you configured in the TurboRater for Websites admin console
		/// </summary>
		public string LeadSource { get; set; }
		/// <summary>
		/// Does the Named Insured currently have auto insurance or has been insured within the last 30 days?
		/// </summary>
		public bool CurrentlyInsured { get; set; }
		/// <summary>
		///  If the Named Insured hasn't been insured in the last 30 days, why?
		/// </summary>
		/// <seealso cref="TurboRater.Insurance.AU.ReasonForNoInsurance."/>
		public ReasonForNoInsurance ReasonNoInsurance { get; set; }
		/// <summary>
		/// The carrier of the current insurance - see list in TurborRater.Insurance.InsConstants - PriorCompanyIDs
		/// </summary>
		public string PriorCarrier { get; set; }
		/// <summary>
		/// Number of years of prior insurnce
		/// </summary>
		public int? PriorInsYears { get; set; }
		/// <summary>
		/// Number of months in addition to years of prior insurance(2 years 6 months, or 0 years 6 months for example - value would be 6)
		/// </summary>
		public int? PriorInsMonths { get; set; }
		/// <summary>
		/// Expiration date of current insurance	
		/// </summary>
		public DateTime? PriorInsExpiry { get; set; }
		/// <summary>
		/// Does the insured have/need an SR22
		/// </summary>
		public bool SR22 { get; set; }
		/// <summary>
		/// Do you own or rent?  Please note Leased is not available in TurboRater for Websites
		/// </summary>
		/// <seealso cref="TurboRater.Insurance.AU.AUConstants.ResidencyStatusChars"/> 
		public string ResidenceStatus { get; set; }
		/// <summary>
		/// Type of residence (home, apartment, etc).  
		/// </summary>
		/// <seealso cref="TurboRater.Insurance.AU.AUConstants.ResidencyTypeChars"/>
		public string ResidenceType { get; set; }

		// address info

		/// <summary>
		/// Named Insured's location street address
		/// </summary>
		public string StreetAddress { get; set; }
		/// <summary>
		///  Unit or Apartment number or additional street info
		/// </summary>
		public string StreetAddress2 { get; set; }
		/// <summary>
		/// City		
		/// </summary>
		public string City { get; set; }
		/// <summary>
		/// County
		/// </summary>
		public string County { get; set; }
		/// <summary>
		/// State - See TurboRater ITCConstants for Enum list
		/// </summary>
		/// <seealso cref="TurboRater.USState"/>
		public USState StateCd { get; set; }
		/// <summary>
		/// The ZIP Code
		/// </summary>
		public string ZipCd { get; set; }

		/// <summary>
		/// Vehicles list
		/// </summary>
		public List<AutoLoaderVehicle> Vehicles { get; set; }
		/// <summary>
		/// Drivers list
		/// </summary>
		public List<AutoLoaderDriver> Drivers { get; set; }


		/// <summary>
		/// default constructor
		/// </summary>
		public AutoModelLoader()
		{
			Vehicles = new List<AutoLoaderVehicle>();
			Drivers = new List<AutoLoaderDriver>();
			ReasonNoInsurance = ReasonForNoInsurance.NoReasonGiven;
		}
	}

	/// <summary>
	/// class for a vehicle that is to be rated
	/// </summary>
	public class AutoLoaderVehicle
	{
		/// <summary>
		/// Car fields 
		/// </summary>

		/// <summary>
		/// The 10 or 17 digit VIN of the vehicle - if this is supplied then the remaining Car fields are not needed
		/// </summary>
		public string VehVIN { get; set; }
		/// <summary>
		/// The vehicle's year model.
		/// </summary>
		public int VehYear { get; set; }
		/// <summary>
		/// Vehicle's maker. Ex: Toyota
		/// </summary>
		public string VehMake { get; set; }
		/// <summary>
		/// Vehicle's model. Ex: F150
		/// </summary>
		public string VehModel { get; set; }
		/// <summary>
		/// the vehicle's body type
		/// </summary>
		/// <seealso cref="CarBody">CarBody</seealso>
		/// <seealso cref="AUConstants.CarBodyNames">AUConstants.CarBodyNames</seealso>
		public string VehBodyType { get; set; }
		/// <summary>
		/// The vehicle's fuel type. Ex: Diesel
		/// </summary>
		public string VehFuelType { get; set; }
		/// <summary>
		/// The vehicle's number of cylinders. Ex: 4
		/// </summary>
		public int? VehCylinders { get; set; }
		/// <summary>
		/// The vehicle's displacement or CID. Ex: 221 for a 2.0 liter engine
		/// </summary>
		public int? VehDisplacement { get; set; }
		/// <summary>
		/// Does the vehicle have four wheel drive?
		/// </summary>
		public bool VehFourWD { get; set; }
		/// <summary>
		/// Does the vehicle have front wheel drive?
		/// </summary>
		public bool VehFrontWD { get; set; }


		/// <summary>
		/// Other info fields 
		/// </summary>

		/// <summary>
		/// Is the vehicle parked in a garage at night?
		/// </summary>
		public bool Garaged { get; set; }
		/// <summary>
		/// Is the vehicle parked at night at the same location as the Insured's address above?
		/// </summary>
		public bool? GaragedSameAsLocation { get; set; }
		/// <summary>
		/// If parked at a different location, the street address
		/// </summary>
		public string AltGaragingStreet { get; set; }
		/// <summary>
		/// If parked at a different location, the city
		/// </summary>
		public string AltGaragingCity { get; set; }
		/// <summary>
		/// If parked at a different location, the street county
		/// </summary>
		public string AltGaragingCounty { get; set; }
		/// <summary>
		/// If parked at a different location, the state
		/// </summary>
		/// <seealso cref="TurboRater.USState"/>
		public USState AltGaragingState { get; set; }
		/// <summary>
		/// If parked at a different location, the ZIP code
		/// </summary>
		public string AltGaragingZip { get; set; }
		/// <summary>
		/// Is the vehicle owned, owned with a loan, or leased? - N (None) means owned without a loan or lease
		/// </summary>
		/// <seealso cref="TurboRater.Insurance.AU.AUConstants.LienHolderTypeChars"/>
		public string VehOwnership { get; set; }
		/// <summary>
		/// How is the vehicle used?
		/// </summary>
		/// <seealso cref="TurboRater.Insurance.AU.AUConstants.VehicleUsageChars"/>
		public string VehUsage { get; set; }
		/// <summary>
		/// default constructor
		/// </summary>
		public AutoLoaderVehicle()
		{

		}
	}

	/// <summary>
	/// class for a driver that is to be rated
	/// </summary>
	public class AutoLoaderDriver
	{
		/// <summary>
		/// Driver's first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Driver's last name
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// The driver's Date of birth
		/// </summary>
		public DateTime DOB { get; set; }

		/// <summary>
		/// The driver's relation to the insured 
		/// </summary>
		/// <seealso cref="TurboRater.Insurance.AU.AUConstants.RelationChar"/>
		public string Relation { get; set; }

		/// <summary>
		/// the driver's gender
		/// </summary>
		/// <seealso cref="TurboRater.ITCConstants.GenderChars"/>
		public string Gender { get; set; }
		/// <summary>
		/// the driver's marital status
		/// </summary>
		/// <seealso cref="TurboRater.ITCConstants.MaritalChars"/>
		public string MaritalStatus { get; set; }
		/// <summary>
		/// the driver's highest level of education achieved
		/// </summary>
		/// <seealso cref="TurboRater.ITCConstants.EducationLevelChars"/>
		public string EducationLevel { get; set; }
		/// <summary>
		/// the industry in which the driver works 
		/// </summary>
		/// <seealso cref="TurboRater.ITCConstants.IndustryChars"/>
		public string Industry { get; set; }
		/// <summary>
		/// the driver's occupation
		/// </summary>
		/// <seealso cref="TurboRater.ITCConstants.OccupationChars"/>
		public string Occupation { get; set; }
		/// <summary>
		/// Does the driver have a valid driver's license?
		/// </summary>
		public bool Licensed { get; set; }
		/// <summary>
		/// Where is the license from
		/// </summary>
		/// <seealso cref="ConsumerRaterConstants.LicenseOriginStrings"/>
		public string LicenseOrigin { get; set; }
		/// <summary>
		/// What US state is the driver licensed - this is the 2 character state abbreviation - Ex: TX
		/// </summary>
		public string StateLicensed { get; set; }
		/// <summary>
		/// What is the status of this license?
		/// </summary>
		/// <seealso cref="ConsumerRaterConstants.LicenseStatusChars"/>
		public string LicenseValidStatus { get; set; }
		/// <summary>
		/// List of violations
		/// </summary>
		/// <seealso cref="TurboRater.Insurance.AU.AUConstants"/>
		/// <seealso cref="TurboRater.Insurance.AU.AUViolation"/>
		public List<AUViolation> Violations { get; set; }
		/// <summary>
		///  default constructor
		/// </summary>
		public AutoLoaderDriver()
		{
			Violations = new List<AUViolation>();
		}
	}
}
