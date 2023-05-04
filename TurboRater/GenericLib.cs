using System;
using System.IO;

namespace TurboRater
{
  /// <summary>
  /// Utility class for generic operations.
  /// </summary>
  public sealed class GenericLib
  {
    /// <summary>
    /// Hiding the default constructor
    /// </summary>
    private GenericLib()
    {
    }

    /// <summary>
    /// Adds a duration to a date/time.
    /// </summary>
    /// <param name="theDate">the date we're going to add to.</param>
    /// <param name="theDuration">the duration type (moths, days, years, etc).</param>
    /// <param name="value">The actual duration we're adding to the date.</param>
    /// <returns>The newly modified date/time value.</returns>
    public static DateTime AddDateDuration(DateTime theDate, Duration theDuration, double value)
    {
      switch (theDuration)
      {
        case Duration.Days:
          return theDate.AddDays(value);
        case Duration.Hours:
          return theDate.AddHours(value);
        case Duration.Milliseconds:
          return theDate.AddMilliseconds(value);
        case Duration.Minutes:
          return theDate.AddMinutes(value);
        case Duration.Months:
          return theDate.AddMonths((int)value);
        case Duration.Seconds:
          return theDate.AddSeconds(value);
        case Duration.Years:
          return theDate.AddYears((int)value);
      }
      return theDate;
    }

    /// <summary>
    /// Given a text file name fileName, returns the # of lines of 
    /// text in the file.
    /// </summary>
    /// <param name="fileName">full path and name of the file to check</param>
    /// <returns>The # of lines in the file</returns>
    public static int TextFileNumLines(string fileName)
    {
      TextReader textReader = File.OpenText(fileName);
      try
      {
        int numLines = 0;
        while (textReader.ReadLine() != null)
          numLines++;
        return numLines;
      }
      finally
      {
        textReader.Close();
        textReader = null;
      }
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
    [Obsolete("This method is obsolete.  Use StringLib.SubString instead.")]
    public static string SubString(string sourceString, int startIndex, int length)
    {
      if (sourceString.Length > startIndex)
        return sourceString.Substring(startIndex, Math.Min(length, sourceString.Length - startIndex));
      return "";
    }

    /// <summary>
    /// Replaces the specified chars badChars from the string sourceString with the
    /// chars specified by replacementString
    /// </summary>
    /// <param name="sourceString">The string you wish to modify</param>
    /// <param name="badChars">A list of bad characters that will be replaced</param>
    /// <param name="replacementString">The string that will be used
    /// in place of any of the badChars found</param>
    /// <returns>The modified string</returns>
    public static string ReplaceChars(string sourceString, string badChars, string replacementString)
    {
      string tempResult = sourceString;
      if ((badChars != null) && (badChars.Length > 0))
      {
        foreach (char ch in badChars)
          tempResult = tempResult.Replace(ch.ToString(), replacementString);
      }
      return tempResult;
    }

    /// <summary>
    /// Given a big blob string in the form "#fieldname1=value1#fieldname=value2"
    /// this function will find a field with a specified name and return its
    /// value as a string.
    /// </summary>
    /// <param name="source">The big fat blob source string that you
    /// want to parse for your value</param>
    /// <param name="fieldName">The name of the field you're looking for</param>
    /// <returns>The value for that particular field</returns>
    public static string GetTaggedField(string source, string fieldName)
    {
      fieldName = fieldName.ToLower();
      source = source.ToLower();
      int fieldStartPos = source.IndexOf("#" + fieldName + "=", StringComparison.OrdinalIgnoreCase);
      string tempResult = "";
      if (fieldStartPos != -1)
      {
        tempResult = StringLib.SubString(source, fieldStartPos, source.Length);
        tempResult = tempResult.Remove(0, tempResult.IndexOf("=", StringComparison.Ordinal));
        fieldStartPos = tempResult.IndexOf("#", StringComparison.Ordinal);
        // Maybe #fieldname1=#fieldname2=... for null strings
        // in which case extractword returns the first word to
        // the left of the delimter.                           
        if (fieldStartPos > 0)
          tempResult = StringLib.SubString(tempResult, 0, fieldStartPos);
        else if (fieldStartPos == 0)
          tempResult = "";
      }
      else
        tempResult = "";
      return tempResult;
    }

    /// <summary>
    /// Given the specified term and duration, this returns a string (English)
    /// to represent that term.
    /// </summary>
    /// <param name="term">the term value.</param>
    /// <param name="aDuration">the duration of the term (months, years, etc)</param>
    /// <returns>A string representing the given term.</returns>
    public static string GetTermString(int term, Duration aDuration)
    {
      switch (aDuration)
      {
        case Duration.Years:
          {
            if (term == 1)
              return "Annual";
            else
              return term.ToString() + " Year";
          }
        case Duration.Months:
          {
            switch (term)
            {
              case 1: return "Monthly";
              case 3: return "Quarterly";
              case 6: return "Semi-Annual";
              case 12: return "Annual";
              default: return term.ToString() + " Month";
            }
          }
        case Duration.Days:
          {
            return term.ToString() + " Day";
          }
        default: return "";
      }
    }

  }
}
