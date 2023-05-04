// -----------------------------------------------------------------------
// <copyright file="CompanyQuestion.cs" company="ITC">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
// Class that contains information for company question.
// </summary>

namespace TurboRater.ApiClients.RateEngineApi
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  /// <summary>
  /// Class that contains information for company question.
  /// </summary>
  public class CompanyQuestion
  {
    /// <summary>
    /// Gets or sets The ID of the company question.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets The prompt text for the question.
    /// </summary>
    public string Prompt { get; set; }

    /// <summary>
    /// Gets or sets The hint bubble text for the question.
    /// </summary>
    public string Hint { get; set; }

    /// <summary>
    /// Gets or sets The default answer value for the question.
    /// </summary>
    public string Default { get; set; }

    /// <summary>
    /// Gets or sets The edit mask to use for the question if needed.
    /// </summary>
    public string EditMask { get; set; }

    /// <summary>
    /// Gets or sets The Scope of the question. Policy, Driver, Car, Violation etc.
    /// </summary>
    public string Scope { get; set; }

    /// <summary>
    /// Gets or sets The fieldname of the question to use when constructing the TT2 tags.
    /// </summary>
    public string FieldName { get; set; }

    /// <summary>
    /// Gets or sets The maximum length the answer to the question can be if specified.
    /// </summary>
    public int MaxLength { get; set; }

    /// <summary>
    /// Gets or sets Possible correct answers to validate against or offer as choices for selection.
    /// </summary>
    public string AnswerValidation { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether Boolean. If true, the question is hidden in the interface.
    /// </summary>
    public bool Hidden { get; set; }
  }
}
