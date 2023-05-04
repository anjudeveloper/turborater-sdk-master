using System;

namespace TurboRater
{
  /// <summary>
  /// Marks an enumeration with a language name and id.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field)]
  public sealed class LanguageAttribute : Attribute
  {
    private string m_description = "English";
    private string m_languageId = "en-US";
    private string m_englishName = "English";
    private int m_languageCode = 1033;

    /// <summary>
    /// The language code number.
    /// </summary>
    public int LanguageCode
    {
      get { return m_languageCode; }
    }

    /// <summary>
    /// The translated English name of the language.
    /// </summary>
    public string EnglishName
    {
      get { return m_englishName; }
    }

    /// <summary>
    /// The descriptive name of the language.
    /// </summary>
    public string Description
    {
      get { return m_description; }
    }

    /// <summary>
    /// The browser id of the language (for example, en-US).
    /// </summary>
    public string LanguageId
    {
      get { return m_languageId; }
    }

    /// <summary>
    /// The language attribute constructor.
    /// </summary>
    /// <param name="description">The descriptive name of the language (for example, English).</param>
    /// <param name="englishName">The translated English name of the language.</param>
    /// <param name="languageCode">The language code.</param>
    /// <param name="languageId">The browser language id of the language (for example, en-US).</param>
    public LanguageAttribute(string description, string englishName, string languageId, int languageCode)
    {
      m_description = description;
      m_languageId = languageId;
      m_englishName = englishName;
      m_languageCode = languageCode;
    }
  }
}
