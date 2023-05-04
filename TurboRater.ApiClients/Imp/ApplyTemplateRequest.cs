using System.ComponentModel.DataAnnotations;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Request object for applying a Template 
  /// </summary>
  public class ApplyTemplateRequest
  {
    /// <summary>
    /// The template ID requested to be applied 
    /// </summary>
    [Required]
    public int TemplateId { get; set; }

    /// <summary>
    /// the serialized policy data 
    /// </summary>
    [Required]
    public string PolicyData { get; set; }

  }
}
