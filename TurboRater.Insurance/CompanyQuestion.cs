
namespace TurboRater.Insurance
{
  /// <summary>
  /// Represents a company-specific question
  /// </summary>
  public class CompanyQuestion
  {

    /// <summary>
    /// The value of the company question for the policy
    /// </summary>
    public virtual string Value
    {
      get { return m_value; }
      set { m_value = value; }
    }

    /// <summary>
    /// Name of the question. This is used for programmer reference only, it is not displayed 
    /// for the user.
    /// </summary>
    public virtual string Name
    {
      get { return m_name; }
      set { m_name = value; }
    }

    /// <summary>
    /// This is displayed as the "Label" for the company question.
    /// </summary>
    public virtual string Text
    {
      get { return m_text; }
      set { m_text = value; }
    }

    /// <summary>
    /// The ToolTip displayed for the company question.
    /// </summary>
    public virtual string ToolTip
    {
      get { return m_toolTip; }
      set { m_toolTip = value; }
    }

    /// <summary>
    /// Can be used to tell the interface on which screen to place the company question. 
    /// For example, you could use "Coverage" to place it on the coverage screen, 
    /// "Endorsements" to place it on the endorsements screen, etc.
    /// </summary>
    public virtual string Screen
    {
      get { return m_screen; }
      set { m_screen = value; }
    }

    /// <summary>
    /// The scope of the question. This would be driver, car, policy, etc.
    /// </summary>
    public virtual ItemScope Scope
    {
      get { return m_scope; }
      set { m_scope = value; }
    }

    /// <summary>
    /// Max length for the question entry, assuming it is a text entry field.
    /// </summary>
    public virtual int MaxLength
    {
      get { return m_maxLength; }
      set { m_maxLength = value; }
    }

    /// <summary>
    /// Is the question hidden in comparative products?
    /// </summary>
    public virtual bool HiddenCMP
    {
      get { return m_hiddenCMP; }
      set { m_hiddenCMP = value; }
    }

    /// <summary>
    /// Is the qustion hidden in POS products?
    /// </summary>
    public virtual bool HiddenPOS
    {
      get { return m_hiddenPOS; }
      set { m_hiddenPOS = value; }
    }

    /// <summary>
    /// Semi-colon separated list of items to populate the DropDownList for the
    /// question, if it is a DropDownList.
    /// </summary>
    public virtual string DropDownListItems
    {
      get { return m_dropDownListItems; }
      set { m_dropDownListItems = value; }
    }

    /// <summary>
    /// Regular expression used to validate the question entry value.
    /// </summary>
    public virtual string RegularExpression
    {
      get { return m_regularExpression; }
      set { m_regularExpression = value; }
    }

    /// <summary>
    /// If the question is a numeric entry, the minimum value allowed to
    /// be entered.
    /// </summary>
    public virtual double MinValue
    {
      get { return m_minValue; }
      set { m_minValue = value; }
    }

    /// <summary>
    /// If the question is a numeric entry, the maximum value allowed to
    /// be entered.
    /// </summary>
    public virtual double MaxValue
    {
      get { return m_maxValue; }
      set { m_maxValue = value; }
    }

    /// <summary>
    /// The date type of the entry value. This would be an integral type,
    /// double type, boolean type, etc.
    /// </summary>
    public virtual QuestionType QuestionType
    {
      get { return m_questionType; }
      set { m_questionType = value; }
    }

    /// <summary>
    /// The category of company question. company data, non stored data,
    /// company module contents, etc.
    /// </summary>
    public virtual CompanyQuestionCategory CompanyQuestionCategory
    {
      get { return m_questionCategory; }
      set { m_questionCategory = value; }
    }
    /// <summary>
    /// The ID associated with the company questions.  connect the company ID to this to know which
    /// company question is associated with which company.
    /// </summary>
    public virtual string ID
    {
      get { return m_ID; }
      set { m_ID = value; }
    }

    private string m_name = "";
    private string m_text = "";
    private string m_toolTip = "";
    private string m_screen = "";
    private ItemScope m_scope = ItemScope.Policy;
    private int m_maxLength;
    private bool m_hiddenCMP;
    private bool m_hiddenPOS;
    private string m_dropDownListItems = "";
    private string m_regularExpression = "";
    private double m_minValue;
    private double m_maxValue;
    private string m_value = "";
    private string m_ID = "";
    private QuestionType m_questionType = QuestionType.String;
    private CompanyQuestionCategory m_questionCategory = CompanyQuestionCategory.CompanyData;
  }

}
