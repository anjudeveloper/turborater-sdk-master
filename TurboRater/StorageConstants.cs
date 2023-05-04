
namespace TurboRater
{
  /// <summary>
  /// Constants used by the ITC .Net storage system. Contains things
  /// such as the lengths of various types of strings like phone#'s, as
  /// well as other useful constants.
  /// </summary>
  public sealed class StorageConstants
  {
    /// <summary>
    /// Hiding the default constructor
    /// </summary>
    private StorageConstants()
    {
    }

    public const int PhoneLength = 25;
    public const int MakerLength = 25;
    public const int ModelLength = 25;
    public const int VINLength = 17;
    public const int CityLength = 50;
    public const int AddressLength = 100;
    public const int SmallAddressLength = 50;
    public const int ZipCodeLength = 10;
    public const int StateLength = 25;
    public const int PIPCoverageLength = 50;
  }

}
