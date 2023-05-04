using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace SdkRater.RateUtilityLib
{
  /// <summary>
  /// Utility class, deals with storage of local user data. Ecrypts/decrypts all locally stored data using built-in windows API calls and their .Net wrappers.
  /// </summary>
  public static class ApiLocalStorage
  {
    /// <summary>
    /// The directory in which we'll store all this information.
    /// </summary>
    private static string DataDirectory
    {
      get
      {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "APILocalStorage");
      }
    }

    /// <summary>
    /// The file name in which we'll store all this information.
    /// </summary>
    private static string DataFileName
    {
      get
      {
        return Path.Combine(DataDirectory, "apiuserdata.bin");
      }
    }

    /// <summary>
    /// The name of the log file.
    /// </summary>
    private static string LogFileName
    {
      get
      {
        return Path.Combine(DataDirectory, "apilog.txt");
      }
    }

    /// <summary>
    /// Saves the specified UserData object to local storage.
    /// </summary>
    /// <param name="userData">The UserData object to store.</param>
    public static void Save(ApiUserData userData)
    {
      var serializer = new JavaScriptSerializer();
      var serializedData = serializer.Serialize(userData);
      var bytes = ASCIIEncoding.ASCII.GetBytes(serializedData);
      var encryptedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);
      if (!Directory.Exists(DataDirectory))
        Directory.CreateDirectory(DataDirectory);
      File.WriteAllBytes(DataFileName, encryptedBytes);
    }

    /// <summary>
    /// Loads UserData from local storage.
    /// </summary>
    /// <returns>The loaded UserData object.</returns>
    public static ApiUserData Load()
    {
      var result = new ApiUserData();
      if (File.Exists(DataFileName))
      {
        var encryptedBytes = File.ReadAllBytes(DataFileName);
        var bytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser);
        var serializedData = ASCIIEncoding.ASCII.GetString(bytes);
        var serializer = new JavaScriptSerializer();
        result = serializer.Deserialize<ApiUserData>(serializedData);
      }
      return result;
    }

    /// <summary>
    /// Logs an exception.
    /// </summary>
    /// <param name="ex">The exception to log.</param>
    public static void LogException(Exception ex)
    {
      try
      {
        if (!Directory.Exists(DataDirectory))
          Directory.CreateDirectory(DataDirectory);
        string logFileContents = string.Empty;
        if (!File.Exists(LogFileName))
          File.WriteAllText(LogFileName, String.Empty);
        else
          logFileContents = File.ReadAllText(LogFileName);
        logFileContents += String.Format("{0} ERROR-{1}::{2}::{3}\r\n", DateTime.Now.ToString("G"), ex.GetType().ToString(), ex.Message, ex.StackTrace);
        File.WriteAllText(LogFileName, logFileContents);
        if (ex.GetBaseException() != null)
          LogException(ex.GetBaseException());

        
      }
      catch
      {
        //eat it.
      }
    }
  }

}
