using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurboRater.ConsumerRater;
using System.Collections.Generic;

namespace TurboRater.Samples
{
	[TestClass]
	public class ConsumerRaterSamples
	{
		[TestMethod]
		public void TestAutoModelLoader()
		{
			var mdlLoader = new AutoModelLoader
			{
				EffectiveDate = DateTime.Today,
				EmailAddress = "test@getitc.com",
				PhoneNumber = "2223334444",
				CurrentlyInsured = true,
				PriorCarrier = "-2147483646",
				PriorInsYears = 3,
				PriorInsExpiry = DateTime.Today,
				SR22 = false,
				ResidenceStatus = "0",
				ResidenceType = "H",
				StreetAddress = "921 E 49th St",
				City = "Austin",
				StateCd = USState.Texas,
				ZipCd = "78751"
			};
			Assert.IsNotNull(mdlLoader);
			Assert.IsInstanceOfType(mdlLoader, typeof(AutoModelLoader));

			var drivers = new List<AutoLoaderDriver>();
			var cars = new List<AutoLoaderVehicle>();
			var driver = new AutoLoaderDriver
			{
				FirstName = "Fred",
				LastName = "Testing",
				DOB = new DateTime(1985, 4, 17),
				Relation = "I",
				Gender = "M",
				MaritalStatus = "S",
				EducationLevel = "B",
				Industry = "AK",
				Occupation = "AKG",
				Licensed = true,
				LicenseOrigin = "US",
				StateLicensed = "TX",
				LicenseValidStatus = "V",
			};
			Assert.IsNotNull(driver);
			Assert.IsInstanceOfType(driver, typeof(AutoLoaderDriver));
			drivers.Add(driver);
			Assert.IsNotNull(drivers);
			Assert.IsInstanceOfType(drivers, typeof(List<AutoLoaderDriver>));
			Assert.AreEqual(drivers.Count, 1);

			var car = new AutoLoaderVehicle
			{
				VehVIN = "1HGFB2F50F",
				VehYear = 2015,
				VehMake = "HONDA",
				VehModel = "CIVIC LX",
				VehBodyType = "Sedan 4dr"
			};
			Assert.IsNotNull(car);
			Assert.IsInstanceOfType(car, typeof(AutoLoaderVehicle));
			cars.Add(car);
			Assert.IsNotNull(cars);
			Assert.IsInstanceOfType(cars, typeof(List<AutoLoaderVehicle>));
			Assert.AreEqual(cars.Count, 1);
			Assert.AreEqual(car.VehYear, 2015);
		}
	}
}
