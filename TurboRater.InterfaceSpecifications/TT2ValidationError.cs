// -----------------------------------------------------------------------
// <copyright file="TT2ValidationError.cs" company="ITC">
//  Copyright ITC. All rights reserved.
// </copyright>
// <summary>This is the TT2ValidationError class.  Container class for validation errors.</summary>
// -----------------------------------------------------------------------

namespace TurboRater.InterfaceSpecifications
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  /// <summary>
  /// For validation errors 
  /// </summary>
  public enum ValidationErrorType
  {
    /// <summary>
    /// Maximum value violation.
    /// </summary>
    MaxValue = 0,

    /// <summary>
    /// Minimum value violation
    /// </summary>
    MinValue = 1,

    /// <summary>
    /// Minimum value violation
    /// </summary>
    MinLengthExceeded = 2,

    /// <summary>
    /// Maximum length violation.
    /// </summary>
    MaxLengthExceeded = 3,

    /// <summary>
    /// Minimum value violation.
    /// </summary>
    InvalidRegEx = 4,

    /// <summary>
    /// Minimum value violation.
    /// </summary>
    Required = 5,

    /// <summary>
    /// FieldMissing violation
    /// </summary>
    FieldMissing = 8,

    /// <summary>
    /// GeneralException violation.
    /// </summary>
    GeneralException = 9,

    /// <summary>
    /// GeneralException violation.
    /// </summary>
    InvalidTT2FileFormat = 10,

    /// <summary>
    /// Uri data invalid or value does not match data violation.
    /// </summary>
    InvalidUriData = 11,

    /// <summary>
    /// Date field with invalid date.
    /// </summary>
    InvalidDate = 12
  }

  /// <summary>
  /// Container class for validation errors.
  /// </summary>
  public class TT2ValidationError
  {
    /// <summary>
    /// Dictionary of error strings.
    /// </summary>
    private static Dictionary<ValidationErrorType, string> errorTypeToMessage;

    /// <summary>
    ///  Initializes a new instance of the <see cref="TT2ValidationError"/> class.
    /// </summary>
    public TT2ValidationError()
    {
      MessageType = "Error";
    }

    /// <summary>
    /// Gets or sets the <c>tagname</c> associated with the error.
    /// </summary>
    public string TagName { get; set; }

    /// <summary>
    /// Gets or sets the Scope associated with the error.
    /// </summary>
    public string Scope { get; set; }

    /// <summary>
    /// Gets or sets the <c>ScopeNum</c> associated with the error.
    /// </summary>
    public string ScopeNum { get; set; }

    /// <summary>
    /// Gets or sets the FieldValue associated with the error.
    /// </summary>
    public string FieldValue { get; set; }

    /// <summary>
    /// Gets or sets the FieldValue associated with the error.
    /// </summary>
    public string ExpectedValue { get; set; }

    /// <summary>
    /// Gets or sets the ErrorCode associated with the error.
    /// </summary>
    public ValidationErrorType ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets the MessageType associated with the error.
    /// </summary>
    public string MessageType { get; set; }

    /// <summary>
    /// Gets the Message associated with the error.
    /// </summary>
    public string Message
    {
      get
      {
        errorTypeToMessage = new Dictionary<ValidationErrorType, string>() 
        {
        { ValidationErrorType.MaxValue, "Max value of {0}, actual value: {1}." },
        { ValidationErrorType.MinValue, "Min value of {0}, actual value: {1}." },
        { ValidationErrorType.MinLengthExceeded, "Min Length of {0}, actual value: {1}." },
        { ValidationErrorType.MaxLengthExceeded, "Max Length of {0}, actual value: {1}." },
        { ValidationErrorType.InvalidRegEx, "Expression of {0}, actual value: {1}." },
        { ValidationErrorType.Required, "Required." },
        { ValidationErrorType.FieldMissing, "Field is missing." },
        { ValidationErrorType.GeneralException, "General Error {0}, actual value: {1}." },
        { ValidationErrorType.InvalidTT2FileFormat, "Invalid File Format." },
        { ValidationErrorType.InvalidUriData, "Uri data Error {0}, actual value: {1}." },
         { ValidationErrorType.InvalidDate, "Date data Error {0}, actual value: {1}." },
        };

        return string.Format(errorTypeToMessage[this.ErrorCode], this.ExpectedValue, this.FieldValue);
      }
    }

    /// <summary>
    /// Gets the Key associated with the error.
    /// </summary>
    public string Key
    {
      get { return this.Scope + this.ScopeNum + "." + this.TagName; }
    }
  }
}
