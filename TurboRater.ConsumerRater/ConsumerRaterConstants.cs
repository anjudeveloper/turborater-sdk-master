namespace TurboRater.ConsumerRater
{
	public sealed class ConsumerRaterConstants
	{

		/// <summary>
		/// License descriptions.
		/// </summary>
		public static readonly string[] LicenseOriginStrings =
		{
			"SelectOne",
			"NotLicensed",
			"USLicense",
			"MexicoLicense",
			"CanadaLicense",
			"InternationalLicense",
			"PolandLicense",
			"Matricula"
		};

		/// <summary>
		/// License status
		/// </summary>
		public static readonly string[] LicenseStatusChars =
		{
			"V", // valid
			"E", // expired
			"S", // suspended
			"R"  // revoked
		};
	}
}