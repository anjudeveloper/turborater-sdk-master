using System;
using System.Collections.Generic;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A list holder for CompanyQuestion items
  /// </summary>
  [Serializable]
  public class CompanyQuestionList : List<CompanyQuestion>
  {

    /// <summary>
    /// Default constructor
    /// </summary>
    public CompanyQuestionList()
    {
    }

    /// <summary>
    /// Indexer for this class. Returns an CompanyQuestion object
    /// from the list of items.
    /// </summary>
    public virtual CompanyQuestion this[string name]
    {
      get { return this.Find(item => item.Name.ToLower().Trim() == name.ToLower().Trim()); }
    }

    /// <summary>
    /// Given a big blob string field, this method parses out that big
    /// field into this lovely, easy to use list of objects. Must be in the 
    /// form "#fieldname1=value1#fieldname=value2"
    /// </summary>
    /// <param name="blobField">The big blob field you want to parse</param>
    /// <param name="companyQuestionCategory">The category that you want
    /// assigned to all the questions that get parsed outta the 
    /// blobField parameter</param>
    public virtual void ParseBlobField(string blobField, CompanyQuestionCategory companyQuestionCategory)
    {
      blobField = blobField.Replace("=#", "= #");
      string[] separateWords = blobField.Split(new char[] { '#', '=' });
      int actualWordCount = 0;
      CompanyQuestion newQuestion = new CompanyQuestion();
      foreach (string word in separateWords)
      {
        //else
        {
          if (actualWordCount % 2 == 1) //odd-numbered ones are field names
          {
            newQuestion.Name = word.Trim();
            newQuestion.CompanyQuestionCategory = companyQuestionCategory;
          }
          else //even-numbered ones are field values
          {
            newQuestion.Value = StringLib.TaggedFieldDataDecode(word.Trim());
            if (!String.IsNullOrEmpty(newQuestion.Name.Trim())) //if it's not an empty field, add it to the list
              this.Add(newQuestion);
            newQuestion = null;
            newQuestion = new CompanyQuestion();
          }
        }
        actualWordCount++;
      }
    }

    /// <summary>
    /// Generates the storable blob field value for the specified type of company
    /// questions. 
    /// </summary>
    /// <param name="companyQuestionCategory">The type of company questions
    /// you wish to export into the blob field</param>
    /// <returns>The generated blob field</returns>
    public virtual string GenerateBlobField(CompanyQuestionCategory companyQuestionCategory)
    {
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      foreach (CompanyQuestion question in this)
        if (question.CompanyQuestionCategory == companyQuestionCategory)
          sb.Append("#" + question.Name + "=" + StringLib.TaggedFieldDataEncode(question.Value));
      return sb.ToString();
    }
  }
}
