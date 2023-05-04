using System;
using System.ComponentModel;
using System.Reflection;
using System.Resources;

namespace TurboRater
{
  /// <summary>
  /// Defines languages and their browser ids.
  /// </summary>
  public enum Language
  {
    /// <summary>
    /// English - United States.
    /// </summary>
    [Description("English"), Language("English", "English", "en-US", 1033)]
    English,
    /// <summary>
    /// Spanish - Mexico.
    /// </summary>
    [Description("Español"), Language("Español", "Spanish", "es-MX", 2058)]
    Spanish,
    /// <summary>
    /// German - Germany.
    /// </summary>
    [Description("Deutsch"), Language("Deutsch", "German", "de-DE", 1031)]
    German,
    /// <summary>
    /// Korean.
    /// </summary>
    [Description("한국의"), Language("한국의", "Korean", "ko-KR", 1042)]
    Korean,
    /// <summary>
    /// Polish.
    /// </summary>
    [Description("Polski"), Language("Polski", "Polish", "pl-PL", 1045)]
    Polish,
    /// <summary>
    /// French - Canada.
    /// </summary>
    [Description("Français"), Language("Français", "French", "fr-ca", 3084)]
    French
  }

  /// <summary>
  /// Contains methods for working with languages and globalization.
  /// </summary>
  public sealed class GlobalizationLib
  {
    /// <summary>
    /// The name of the language resource file being used.
    /// </summary>
    public static string LanguageResourceName = "Lang";

    /// <summary>
    /// Gets the language attrbibute for a language enum.
    /// </summary>
    /// <param name="language">The language to retrieve.</param>
    /// <returns>The LanguageAttribute attached to the language enum.</returns>
    public static LanguageAttribute GetLanguageAttribute(Language language)
    {
      FieldInfo fieldInfo = language.GetType().GetField(language.ToString());
      LanguageAttribute[] attributes = (LanguageAttribute[])fieldInfo.GetCustomAttributes(typeof(LanguageAttribute), false);
      return (attributes.Length > 0) ? attributes[0] : null;
    }


    /// <summary>
    /// Translates a language resource id into its actual string translation.
    /// </summary>
    /// <param name="assembly">The assembly that contains the resource.</param>
    /// <param name="resourceName">The name of the language resource.</param>
    /// <param name="resourceId">The id of the string translation in the language resource.</param>
    /// <param name="language">The language to use.  The language id (for example "-en") is attached to the resource name for lookup.</param>
    /// <param name="defaultTranslation">The translation to use if the resource is not found.</param>
    /// <returns>The translated string.</returns>
    public static string Translate(string resourceName, Assembly assembly, Language language, string resourceId, string defaultTranslation)
    {
      string languageId = StringLib.SubString(GetLanguageAttribute(language).LanguageId, 0, 2);
      ResourceManager rm = new ResourceManager(resourceName + "-" + languageId, assembly);
      object resource = rm.GetString(resourceId);
      return resource == null ? defaultTranslation : resource.ToString();
    }

    /// <summary>
    /// Creates and returns a ResourceManager linked to a specific resource in an assembly.
    /// </summary>
    /// <param name="resourceName">The name of the resource.  The resource should be named in the format ResourceName-languageCode.resx; for example MyResource-en.resx.</param>
    /// <param name="assembly">The assembly containing the resource.</param>
    /// <param name="language">The language of the resource to use.  The language's languageId is added to the name of the resource when loading it.</param>
    /// <returns>A resource manager linked to the resource and language.</returns>
    public static ResourceManager GetLanguageResourceManager(string resourceName, Assembly assembly, Language language)
    {
      string languageId = StringLib.SubString(GetLanguageAttribute(language).LanguageId, 0, 2);
      return new ResourceManager(resourceName + "-" + languageId, assembly);
    }

    /// <summary>
    /// Translates a language resource id into its actual string translation, using a pre-cached resource manager.
    /// </summary>
    /// <param name="manager">The resource manager to use for the translation.</param>
    /// <param name="defaultTranslation">The translation to use if the resource is not found.</param>
    /// <param name="resourceId">The id of the string translation in the language resource.</param>
    /// <returns>The translated string.</returns>
    public static string Translate(ResourceManager manager, string resourceId, string defaultTranslation)
    {
      object resource = manager.GetString(resourceId);
      return resource == null ? defaultTranslation : resource.ToString();
    }

    /// <summary>
    /// Given a language id, returns a Language enumeration.  For example, "en-US" returns Language.English.
    /// If an exact match cannot be found, it attempts to match by language only. For example, "en" will return
    /// Language.English, "es-US" will return Language.Spanish.
    /// </summary>
    /// <param name="languageId">The language id to find.</param>
    /// <returns>The language Enum corresponding to the language id.</returns>
    public static Language GetLanguageFromLanguageId(string languageId)
    {
      foreach (Language lang in Enum.GetValues(typeof(Language)))
        if (languageId.ToLower().Trim().StartsWith(GlobalizationLib.GetLanguageAttribute(lang).LanguageId.ToLower()))
          return lang;

      foreach (Language lang in Enum.GetValues(typeof(Language)))
      {
        string[] langParts = GlobalizationLib.GetLanguageAttribute(lang).LanguageId.Split('-');
        string[] paramParts = languageId.Split('-');
        if (paramParts.Length > 0 && paramParts[0].ToLower().Trim().StartsWith(langParts[1].ToLower()))
          return lang;
      }
      throw new GlobalizationException("Language id not recognized.");
    }

    private GlobalizationLib()
    {
    }
  }
}
