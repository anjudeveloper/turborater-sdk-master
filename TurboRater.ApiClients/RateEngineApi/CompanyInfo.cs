// -----------------------------------------------------------------------
// <copyright file="CompanyInfo.cs" company="ITC">
// Copyright ITC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
// Company information CRUD class.
// </summary>

namespace TurboRater.ApiClients.RateEngineApi
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using TurboRater.Insurance;
  using TurboRater.Insurance.DataTransformation;
  using TurboRater;

  /// <summary>
  /// Company information CRUD class.
  /// </summary>
  public class CompanyInfo
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyInfo" /> class.
    /// </summary>
    public CompanyInfo()
    {
      this.CompanyQuestions = new List<CompanyQuestion>();
    }

    /// <summary>
    /// Gets or sets The recordID of the company record.
    /// </summary>
    public long RecordID { get; set; }

    /// <summary>
    /// Gets or sets The companyID of the company.
    /// </summary>
    public long CompanyID { get; set; }

    /// <summary>
    /// Gets or sets The product number of the company. Used for real time rating
    /// </summary>
    public int ProductID { get; set; }

    /// <summary>
    /// Gets or sets The name of the company.
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// Gets or sets The programID
    /// </summary>
    public int ProgramID { get; set; }

    /// <summary>
    /// Gets or sets The name of the program.
    /// </summary>
    public string ProgramName { get; set; }

    /// <summary>
    /// Gets or sets The module name.
    /// </summary>
    public string ModuleName { get; set; }

    /// <summary>
    /// Gets or sets The effective date of the rates.
    /// </summary>
    public DateTime RateEffectiveDate { get; set; }

    /// <summary>
    /// Gets or sets Real time or Manufactured.
    /// </summary>
    public string RateType { get; set; }

    /// <summary>
    /// Gets or sets The line of insurance the rates are for.
    /// </summary>
    public string LineOfInsurance { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether Is credit required to be allowed to rate?
    /// </summary>
    public bool CreditRequired { get; set; }

    /// <summary>
    /// Gets or sets The DOC companyID. Internal value.
    /// </summary>
    public int DOSCompanyID { get; set; }

    /// <summary>
    /// Gets or sets The state abbreviation the rates are for.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Gets or sets A list of company question objects if company questions were requested.
    /// </summary>
    public List<CompanyQuestion> CompanyQuestions { get; set; }

    /// <summary>
    /// A list of HO company endorsements.
    /// </summary>
    public List<HOCompanyEndorsement> HOCompanyEndorsements { get; set; }

    /// <summary>
    /// A list of HO company credits.
    /// </summary>
    public List<HOCustomEntry> HOCompanyCredits { get; set; }

    /// <summary>
    /// A list of HO company questions.
    /// </summary>
    public List<HOCustomEntry> HOCompanyQuestions { get; set; }

    /// <summary>
    /// Is this product active in the agency's Rating API profile? Defaults to false.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Use this to add company question objects to the company information object.
    /// </summary>
    /// <param name="dataString">TT2 policy data.</param>
    public void AddCompanyQuestions(string dataString)
    {
      try
      {
        TT2AUBridge bridge = new TT2AUBridge(dataString, null);
        bridge.Tags.Items.Sort();
        bridge.Tags.Sorted = true;

        ////Create records
        TT2TagList recordTags = bridge.FindMatchingTagsByName("product_recordid");

        int index = 0;
        foreach (TT2Tag recordTag in recordTags)
        {
          this.CompanyQuestions.Add(new CompanyQuestion());
          int recordNum = recordTag.ScopeNum;
          TT2TagList infoTags = bridge.FindMatchingTagsByScope(ItemScope.Record, recordNum);

          foreach (TT2Tag infoTag in infoTags)
          {
            switch (infoTag.TagName)
            {
              case "id":
                this.CompanyQuestions[index].ID = ITCConvert.ToInt32(infoTag.Values[0], -1);
                break;
              case "prompt":
                this.CompanyQuestions[index].Prompt = infoTag.Values[0].ToString();
                break;
              case "hint":
                this.CompanyQuestions[index].Hint = infoTag.Values[0].ToString();
                break;
              case "defaultvalue":
                this.CompanyQuestions[index].Default = infoTag.Values[0].ToString();
                break;
              case "editmask":
                this.CompanyQuestions[index].EditMask = infoTag.Values[0].ToString();
                break;
              case "scope":
                this.CompanyQuestions[index].Scope = infoTag.Values[0].ToString();
                break;
              case "fieldname":
                this.CompanyQuestions[index].FieldName = infoTag.Values[0].ToString();
                break;
              case "maxlength":
                this.CompanyQuestions[index].MaxLength = ITCConvert.ToInt32(infoTag.Values[0], -1);
                break;
              case "answer_validation":
                this.CompanyQuestions[index].AnswerValidation = infoTag.Values[0].ToString();
                break;
              case "hidden":
                this.CompanyQuestions[index].Hidden = ITCConvert.ToBoolean(infoTag.Values[0], false);
                break;
            }
          }

          index++;
        }
      }
      catch (Exception)
      {
      }
    }
  }
}
