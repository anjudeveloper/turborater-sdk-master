using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace TurboRater
{
  /// <summary>
  /// Generic string utility class.
  /// </summary>
  public sealed class StringLib
  {
    /// <summary>
    /// Encodes a tagged field data value so that special characters in the data don't cause problems.
    /// </summary>
    /// <param name="unEncodedValue">The string to encode.</param>
    /// <returns>The encoded version of the string.</returns>
    public static string TaggedFieldDataEncode(string unEncodedValue)
    {
      string result = unEncodedValue;
      result = result.Replace("%", "%37");
      result = result.Replace("\"", "%34");
      result = result.Replace("=", "%61");
      result = result.Replace(TaggedFieldDelimiter, EncodedTaggedFieldDelimiter);
      return result;
    }

    /// <summary>
    /// Decodes an encoded data value from a tagged field.
    /// </summary>
    /// <param name="encodedValue">The string to decode</param>
    /// <returns>The decoded string.</returns>
    public static string TaggedFieldDataDecode(string encodedValue)
    {
      string result = encodedValue;
      result = result.Replace(EncodedTaggedFieldDelimiter, TaggedFieldDelimiter);
      result = result.Replace("%34", "\"");
      result = result.Replace("%37", "%");
      result = result.Replace("%61", "=");
      return result;
    }

    private static int GetTagEndingPosition(string source, int startPos)
    {
      while (startPos < source.Length)
      {
        if (SubString(source, startPos, 1) == TaggedFieldDelimiter)
          break;
        startPos++;
      }
      return startPos;
    }

    /// <summary>
    /// Sets a tagged field value within a tagged field string.
    /// </summary>
    /// <param name="destination">The string to modify.</param>
    /// <param name="fieldName">The field name of the field to modify or add.</param>
    /// <param name="data">The data value for the field.</param>
    public static void SetTaggedField(ref string destination, string fieldName, object data)
    {
      fieldName = fieldName.Trim().ToLower();
      if (String.IsNullOrEmpty(fieldName))
        return;
      string fieldString = TaggedFieldDelimiter + fieldName + "=";
      int startPos = destination.IndexOf(fieldString, StringComparison.OrdinalIgnoreCase);
      if (startPos >= 0)
      {
        int endPos = GetTagEndingPosition(destination, startPos + fieldString.Length);
        destination = destination.Remove(startPos, endPos - startPos);
      }
      destination += fieldString + TaggedFieldDataEncode(data.ToString());
    }

    /// <summary>
    /// Returns a tagged field value as a string.  If the field is not found, a blank string is returned.
    /// </summary>
    /// <param name="source">The source string containing the tagged fields.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <returns>The value stored in the field.</returns>
    public static string GetTaggedFieldAsString(string source, string fieldName)
    {
      fieldName = fieldName.Trim().ToLower();
      if (String.IsNullOrEmpty(fieldName))
        return "";
      string fieldString = TaggedFieldDelimiter + fieldName + "=";
      int startPos = source.IndexOf(fieldString, StringComparison.OrdinalIgnoreCase);
      if (startPos >= 0)
      {
        startPos += fieldString.Length;
        int endPos = GetTagEndingPosition(source, startPos);
        return TaggedFieldDataDecode(SubString(source, startPos, endPos - startPos));
      }
      return "";
    }

    /// <summary>
    /// Returns a tagged field value as a string.  If the field is not found, a blank string is returned.  Returns null if the tag is not found.
    /// </summary>
    /// <param name="source">The source string containing the tagged fields.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <returns>The value stored in the field.</returns>
    public static string GetTaggedFieldAsString2(string source, string fieldName)
    {
      fieldName = fieldName.Trim().ToLower();
      if (String.IsNullOrEmpty(fieldName))
        return null;
      string fieldString = TaggedFieldDelimiter + fieldName + "=";
      int startPos = source.IndexOf(fieldString, StringComparison.OrdinalIgnoreCase);
      if (startPos >= 0)
      {
        startPos += fieldString.Length;
        int endPos = GetTagEndingPosition(source, startPos);
        return TaggedFieldDataDecode(SubString(source, startPos, endPos - startPos));
      }
      return null;
    }

    /// <summary>
    /// Returns a tagged field value as an integer.  If it doesn't exist or is not the proper format, the defaultValue is returned.
    /// </summary>
    /// <param name="source">The source string containing the tagged fields.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The value to return if the field is not found or the data is not a valid integer.</param>
    /// <returns>The integer data value stored in the field.</returns>
    public static int GetTaggedFieldAsInteger(string source, string fieldName, int defaultValue)
    {
      return ITCConvert.ToInt32(GetTaggedFieldAsString(source, fieldName), defaultValue);
    }

    /// <summary>
    /// Returns a tagged field value as a double.  If it doesn't exist or is not the proper format, the defaultValue is returned.
    /// </summary>
    /// <param name="source">the source string of fields+values.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The value to return if the field is not found or the data is not a valid double.</param>
    /// <returns>The double data value stored in the field.</returns>
    public static double GetTaggedFieldAsDouble(string source, string fieldName, double defaultValue)
    {
      return ITCConvert.ToDouble(GetTaggedFieldAsString(source, fieldName), defaultValue);
    }

    /// <summary>
    /// Returns a tagged field value as a boolean.  If it doesn't exist or is not the proper format, the defaultValue is returned.
    /// Accepts "true", "yes", "y" or integers greater than 0 as value "true" values.
    /// </summary>
    /// <param name="source">the source string of fields+values.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <returns>The boolean data value stored in the field.</returns>
    public static bool GetTaggedFieldAsBoolean(string source, string fieldName)
    {
      string value = GetTaggedFieldAsString(source, fieldName).Trim().ToLower();

      return (value == "true" || value == "yes" || value == "y" || ITCConvert.ToInt32(value, 0) > 0);
    }

    /// <summary>
    /// Returns a tagged field value as a boolean.  If it doesn't exist or is not the proper format, the defaultValue is returned.
    /// Accepts "true", "yes", "y" or integers greater than 0 as value "true" values.
    /// </summary>
    /// <param name="source">the source string of fields+values.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">default value to use if the field isn't found</param>
    /// <returns>The boolean data value stored in the field.</returns>
    public static bool GetTaggedFieldAsBoolean(string source, string fieldName, bool defaultValue)
    {
      string value = GetTaggedFieldAsString(source, fieldName).Trim().ToLower();
      if (String.IsNullOrEmpty(value))
        return defaultValue;

      return (value == "true" || value == "yes" || value == "y" || ITCConvert.ToInt32(value, 0) > 0);
    }

    /// <summary>
    /// Returns a tagged field value as a DateTime.  If it doesn't exist or is not the proper format, the defaultValue is returned.
    /// </summary>
    /// <param name="source">the source string of fields+values.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The value to return if the field is not found or the data is not a valid DateTime.</param>
    /// <returns>The DateTime data value stored in the field.</returns>
    public static DateTime GetTaggedFieldAsDateTime(string source, string fieldName, DateTime defaultValue)
    {
      return ITCConvert.ToDateTime(GetTaggedFieldAsString(source, fieldName), defaultValue);
    }

    /// <summary>
    /// Returns a tagged field value as a DateTime containing only Date data.  If it doesn't exist or is not the proper format, the defaultValue is returned.
    /// </summary>
    /// <param name="source">the source string of fields+values.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The value to return if the field is not found or the data is not a valid Date.</param>
    /// <returns>The Date data value stored in the field.</returns>
    public static DateTime GetTaggedFieldAsDate(string source, string fieldName, DateTime defaultValue)
    {
      return ITCConvert.ToDateTime(GetTaggedFieldAsString(source, fieldName), defaultValue).Date;
    }

    /// <summary>
    /// Returns each tagged field and its value from the source string
    /// </summary>
    /// <param name="source">The string containing the list of tagged fields</param>
    /// <returns>The list of tagged fields and values as a key/value pair dictionary</returns>
    public static IDictionary<string, string> GetTaggedFields(string source)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      string[] taggedFields = source.Split(new string[] { TaggedFieldDelimiter }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string taggedField in taggedFields)
      {
        string[] keyValue = taggedField.Split(new string[] { KeyValuePairDelimiter }, StringSplitOptions.RemoveEmptyEntries);
        if (keyValue.Length > 1)
          dictionary.Add(keyValue[0], keyValue[1]);
        else
          dictionary.Add(keyValue[0], String.Empty);
      }
      return dictionary;
    }

    /// <summary>
    /// Combines tagged field lists into a single list
    /// </summary>
    /// <param name="highPrecedenceList">Tagged field list whose values will override those in the low precedence list</param>
    /// <param name="lowPrecedenceList">Tagged field list containing base values; can be overriden by the high precedence list</param>
    /// <returns>Single tagged field list containing tags from both high and low precendence lists</returns>
    public static string MergedTaggedLists(string highPrecedenceList, string lowPrecedenceList)
    {
      string result = String.Empty;
      IDictionary<string, string> dictHighOrder = GetTaggedFields(highPrecedenceList);
      IDictionary<string, string> dictLowOrder = GetTaggedFields(lowPrecedenceList);
      foreach (KeyValuePair<string, string> kv in dictLowOrder)
        SetTaggedField(ref result, kv.Key, kv.Value);
      foreach (KeyValuePair<string, string> kv in dictHighOrder)
        SetTaggedField(ref result, kv.Key, kv.Value);
      return result;
    }

    /// <summary>
    /// Returns a substring of the source string. Starts at index 0.
    /// Note that this function will not throw an exception if you try to
    /// get a substring larger than the source string. If for example
    /// you call "SubString(someString, 0, 20);" and the string someString
    /// is only 7 characters long, this will just return to you the first
    /// 7 characters.
    /// </summary>
    /// <param name="sourceString">The source string</param>
    /// <param name="startIndex">Starting index for the call. 0-based.</param>
    /// <param name="length"># of characters to pull from the string</param>
    /// <returns>The substring value</returns>
    public static string SubString(string sourceString, int startIndex, int length)
    {
      if (sourceString.Length > startIndex)
        return sourceString.Substring(startIndex, Math.Min(length, sourceString.Length - startIndex));
      return "";
    }


    /// <summary>
    /// Returns a string in which the old substring in a whole string is replaced by a new
    /// substring.  This method requires the passing of a comparison type.
    /// </summary>
    /// <param name="wholeText">String to look for substring in.</param>
    /// <param name="oldSubstring">Substring you want to replace.</param>
    /// <param name="newSubstring">Replacement substring.</param>
    /// <param name="comparison">Comparison type to use.</param>
    /// <returns>Returns a string in which the old substring in a whole string is replaced by a new
    /// substring.</returns>
    [Obsolete("For case-insensitive search, please use the below ReplaceEx() function as it's much faster. For case-sensitive, use the normal String.Replace() method")]
    public static string Replace(string wholeText, string oldSubstring, string newSubstring, StringComparison comparison)
    {
      string resultString = wholeText;
      int locationOfOldSubstring = resultString.IndexOf(oldSubstring, comparison);

      while (locationOfOldSubstring >= 0)
      {
        resultString = resultString.Remove(locationOfOldSubstring, oldSubstring.Length);
        resultString = resultString.Insert(locationOfOldSubstring, newSubstring);
        locationOfOldSubstring = resultString.IndexOf(oldSubstring, comparison);
      }

      return resultString;
    }


    /// <summary>
    /// Returns a string in which the old substring in a whole string is replaced by a new
    /// substring.  This method works regardless of case.
    /// </summary>
    /// <param name="wholeText">String to look for substring in.</param>
    /// <param name="oldSubstring">Substring you want to replace.</param>
    /// <param name="newSubstring">Replacement substring.</param>
    /// <returns>Returns a string in which the old substring in a whole string is replaced by a new
    /// substring.</returns>
    [Obsolete("For case-insensitive search, please use the ReplaceEx() function as it's much faster. For case-sensitive, use the normal String.Replace() method")]
    public static string Replace(string wholeText, string oldSubstring, string newSubstring)
    {
      return Replace(wholeText, oldSubstring, newSubstring, StringComparison.OrdinalIgnoreCase);
    }


    /// <summary>
    /// Converts an integer to a string, then pads it with the specified number of zeros.
    /// </summary>
    /// <param name="value">The integer value to use.</param>
    /// <param name="digits">The number of digits the final string should be.</param>
    /// <returns>The zero padded string.</returns>
    public static string IntToZeroPad(int value, int digits)
    {
      string result = value.ToString();
      if (result.Length > 1 && SubString(result, 0, 1) == "-")
        while (result.Length < digits)
          result = result.Insert(1, "0");
      else
        while (result.Length < digits)
          result = result.Insert(0, "0");
      return result;
    }

    /// <summary>
    /// Returns the string value minus the picmask passed in.
    /// </summary>
    /// <param name="picMask">A valid PICMASK.</param>
    /// <param name="value">The string to filter.</param>
    /// <returns>The string with the mask removed.</returns>
    public static string StripPic(string picMask, string value)
    {
      string result = "";
      char[] Value = new char[picMask.Length];
      int index = 0;

      if (value.Length < picMask.Length) { value = value.PadRight(picMask.Length, ' '); }
      try
      {
        value.CopyTo(0, Value, 0, value.Length);

        foreach (char picChar in picMask)
        {
          foreach (char validChar in ValidPicChars)
          {
            if (picChar == validChar)
            {
              result += Value[index].ToString();
              break;
            }
          }
          index++;
        }
      }
      catch
      {
        result = value;
      }
      return result;
    }

    /// <summary>
    /// Pads the right side of the string with spaces out to the length specified.
    /// </summary>
    /// <param name="value">The string to pad.</param>
    /// <param name="length">The length to pad the string to.</param>
    /// <returns>The string right padded with space characters.</returns>
    public static string Pad(string value, int length)
    {
      StringBuilder result = new StringBuilder(value.Trim());

      if (result.Length > length)
      {
        //Trim the string down.
        result.Remove(length, (result.Length - length));
      }
      else
      {
        while (result.Length != length)
        {
          result.Append(' ');
        }
      }

      //return the result
      return result.ToString();
    }

    /// <summary>
    /// Left pads a string to X length with the character specified.
    /// </summary>
    /// <param name="value">The string to pad</param>
    /// <param name="padValue">The character to pad the string with</param>
    /// <param name="length">The length the string should be padded to</param>
    /// <returns>A String of a specified length left padded with the specified character.</returns>
    public static string LeftPadChL(string value, char padValue, int length)
    {
      StringBuilder result = new StringBuilder(value);

      if (value.Length > length)
      {
        //trim the string, it's too long
        result.Remove(0, (result.Length - length));
      }
      else
      {
        //Pad the string.
        while (result.Length < length)
        {
          result.Insert(0, padValue);
        }
      }

      return result.ToString();
    }

    /// <summary>
    /// Takes a string and returns a base-64 encoded, encrypted string.
    /// </summary>
    /// <param name="stringToEncrypt">The string to encrypt.</param>
    /// <param name="password">The password to use to generate the encryption key.</param>
    /// <returns>The base-64 encoded, encrypted string.</returns>
    public static string EncryptString(string stringToEncrypt, string password)
    {
      byte[] stringBytes = Encoding.Unicode.GetBytes(stringToEncrypt);
      byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());
      PasswordDeriveBytes key = new PasswordDeriveBytes(password, salt);
      RijndaelManaged cipher = new RijndaelManaged();
      cipher.Padding = PaddingMode.PKCS7;
      cipher.Mode = CipherMode.CBC;
      ICryptoTransform encryptor = cipher.CreateEncryptor(key.GetBytes(32), key.GetBytes(16));
      byte[] encryptedBytes = encryptor.TransformFinalBlock(stringBytes, 0, stringBytes.Length);
      return Convert.ToBase64String(encryptedBytes);
    }

    /// <summary>
    /// Takes base-64 encoded, encrypted string and returns the original decrypted string.
    /// </summary>
    /// <param name="stringToDecrypt">The encrypted, base-64 encoded string to decrypt.</param>
    /// <param name="password">The password to use to generate the encryption key.</param>
    /// <returns>The original decrypted string.  If a cryptographic error occurs (such as bad data or password), a null reference is returned.</returns>
    public static string DecryptString(string stringToDecrypt, string password)
    {
      try
      {
        byte[] data = Convert.FromBase64String(stringToDecrypt);
        byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());
        PasswordDeriveBytes key = new PasswordDeriveBytes(password, salt);
        RijndaelManaged cipher = new RijndaelManaged();
        cipher.Padding = PaddingMode.PKCS7;
        cipher.Mode = CipherMode.CBC;
        ICryptoTransform decryptor = cipher.CreateDecryptor(key.GetBytes(32), key.GetBytes(16));
        byte[] decryptedBytes = decryptor.TransformFinalBlock(data, 0, data.Length);
        return Encoding.Unicode.GetString(decryptedBytes);
      }
      catch (CryptographicException)
      {
        // return null if the decryption failed
        return null;
      }
      catch (FormatException)
      {
        // return null if the string was not correctly base-64 encoded
        return null;
      }
    }

    /// <summary>
    /// Case-insensitive string replace. Much faster than using ToUpper() or ToLower(). Also
    /// faster than the above Replace() method.
    /// http://www.codeproject.com/KB/string/fastestcscaseinsstringrep.aspx
    /// </summary>
    /// <param name="original">original string</param>
    /// <param name="pattern">text to search for</param>
    /// <param name="replacement">text that we'll use to replace the pattern</param>
    /// <returns>the new string</returns>
    public static string ReplaceEx(string original, string pattern, string replacement)
    {
      int count, position0, position1;
      count = position0 = position1 = 0;
      string upperString = original.ToUpper();
      string upperPattern = pattern.ToUpper();
      int inc = (original.Length / pattern.Length) *
                (replacement.Length - pattern.Length);
      char[] chars = new char[original.Length + Math.Max(0, inc)];
      while ((position1 = upperString.IndexOf(upperPattern,
                                        position0, StringComparison.OrdinalIgnoreCase)) != -1)
      {
        for (int i = position0; i < position1; ++i)
          chars[count++] = original[i];
        for (int i = 0; i < replacement.Length; ++i)
          chars[count++] = replacement[i];
        position0 = position1 + pattern.Length;
      }
      if (position0 == 0) return original;
      for (int i = position0; i < original.Length; ++i)
        chars[count++] = original[i];
      return new string(chars, 0, count);
    }

    /// <summary>
    /// Is the passed in email address a valid email address?
    /// </summary>
    /// <param name="emailAddress">the email addr in question</param>
    /// <returns>true if it is, otherwise false</returns>
    public static bool IsValidEmail(string emailAddress)
    {
      string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

      Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
      return regex.IsMatch(emailAddress);
    }

    /// <summary>
    /// Takes a string source and replaces every matching character with a new character.
    /// For example, ReplaceMultipleCharacters("Hello-There. Bob", "-. ", '') will return "HelloThereBob".
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="characters">A string containing the characters to replace.  Each character is matched individually.</param>
    /// <param name="newText">The new text used to replace matching characters.</param>
    /// <returns>A string with all matching characters replaced with the same new character.</returns>
    public static string ReplaceMultipleCharacters(string source, string characters, string newText)
    {
      string result = source;
      foreach (char ch in source)
        if (characters.Contains(ch.ToString()))
          result = result.Replace(ch.ToString(), newText);
      return result;
    }

    /// <summary>
    /// Computes the similarity between strings using the Levenshtein Distance algorithm. The lower the #,
    /// the more similar the values. See http://stackoverflow.com/questions/6944056/c-sharp-compare-string-similarity.
    /// </summary>
    /// <param name="value1">The first value to compare.</param>
    /// <param name="value2">The second value to compare.</param>
    /// <returns>The Levenshtein Distance value.</returns>
    public static int ComputeLevenshteinDistance(string value1, string value2)
    {
      if (string.IsNullOrEmpty(value1))
      {
        if (string.IsNullOrEmpty(value2))
          return 0;
        return value2.Length;
      }

      if (string.IsNullOrEmpty(value2))
        return value1.Length;

      int value1Length = value1.Length;
      int value2Length = value2.Length;
      int[,] distances = new int[value1Length + 1, value2Length + 1];

      // initialize the top and right of the table to 0, 1, 2, ...
      for (int value1Index = 0; value1Index <= value1Length; distances[value1Index, 0] = value1Index++) ;
      for (int value2Index = 1; value2Index <= value2Length; distances[0, value2Index] = value2Index++) ;

      for (int value1Index = 1; value1Index <= value1Length; value1Index++)
      {
        for (int value2Index = 1; value2Index <= value2Length; value2Index++)
        {
          int cost = (value2[value2Index - 1] == value1[value1Index - 1]) ? 0 : 1;
          int min1 = distances[value1Index - 1, value2Index] + 1;
          int min2 = distances[value1Index, value2Index - 1] + 1;
          int min3 = distances[value1Index - 1, value2Index - 1] + cost;
          distances[value1Index, value2Index] = Math.Min(Math.Min(min1, min2), min3);
        }
      }
      return distances[value1Length, value2Length];
    }

    /// <summary>
    /// hiding the constructor
    /// </summary>
    private StringLib()
    {
    }

    public const string PicPhoneMask = "(999) 999-9999";

    public const string PicSSNMask = "999-99-9999";

    public const string PicZipMask = "99999-9999";

    /// <summary>
    /// The delimiter used to separate tagged fields.
    /// </summary>
    public const string TaggedFieldDelimiter = "#";

    /// <summary>
    /// The delimiter used to separate a tagged field and its value
    /// </summary>
    public const string KeyValuePairDelimiter = "=";

    private static readonly string EncodedTaggedFieldDelimiter = "%" + ASCIIEncoding.ASCII.GetBytes(TaggedFieldDelimiter)[0];

    private static readonly char[] ValidPicChars = new char[] { '9', 'A', 'X' };
  }
}
