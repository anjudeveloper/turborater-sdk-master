using System;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A pay plan consisting of a list of payments and 
  /// a few other properties. 
  /// </summary>
  [Serializable]
  public class PayPlan
  {
    private string m_description = "";
    private double m_downPaymentPercent;
    private double m_downPaymentAmount;
    private int m_numOfPayments = 1;
    private double m_paymentAmount;
    private bool m_isDefault;
    private double m_totalServiceFee;
    private bool m_isSelected;
    private double m_totalPremium;
    private double m_amountFinanced;
    private double m_totalOfPayments;
    private double m_apr;
    private double m_financeCharge;

    /// <summary>
    /// Description of the pay plan
    /// </summary>
    public virtual string Description
    {
      get { return m_description; }
      set { m_description = value; }
    }


    /// <summary>
    /// Down payment percent for the pay plan
    /// </summary>
    public virtual double DownPaymentPercent
    {
      get { return m_downPaymentPercent; }
      set { m_downPaymentPercent = value; }
    }


    /// <summary>
    /// Down payment amount for the pay plan
    /// </summary>
    public virtual double DownPaymentAmount
    {
      get { return m_downPaymentAmount; }
      set { m_downPaymentAmount = value; }
    }


    /// <summary>
    /// The number of payments in this pay plan
    /// </summary>
    public virtual int NumOfPayments
    {
      get { return m_numOfPayments; }
      set { m_numOfPayments = value; }
    }


    /// <summary>
    /// Assuming all payments are the same amount (other than the down pay),
    /// this is the amount of each payment.
    /// </summary>
    public virtual double PaymentAmount
    {
      get { return m_paymentAmount; }
      set { m_paymentAmount = value; }
    }


    /// <summary>
    /// Is this the default payment plan?
    /// </summary>
    public virtual bool IsDefault
    {
      get { return m_isDefault; }
      set { m_isDefault = value; }
    }


    /// <summary>
    /// The total of all service fees for all payments on this pay plan
    /// </summary>
    public virtual double TotalServiceFee
    {
      get { return m_totalServiceFee; }
      set { m_totalServiceFee = value; }
    }


    /// <summary>
    /// True if this pay plan was selected by the user, false otherwise.
    /// Note that if the user has not yet chosen a pay plan, this will be
    /// false for all pay plans. You can still check IsDefault in that case.
    /// </summary>
    public virtual bool IsSelected
    {
      get { return m_isSelected; }
      set { m_isSelected = value; }
    }


    /// <summary>
    /// Total premium for this pay plan. Note that we have a TotalPremium field
    /// in here because a pay plan can have discounts/surcharges, and thus may be 
    /// different from pay plan to pay plan.
    /// </summary>
    public virtual double TotalPremium
    {
      get { return m_totalPremium; }
      set { m_totalPremium = value; }
    }


    /// <summary>
    /// Total amount financed after calculating the down payment.
    /// </summary>
    public virtual double AmountFinanced
    {
      get { return m_amountFinanced; }
      set { m_amountFinanced = value; }
    }


    /// <summary>
    /// Total of all payments.
    /// </summary>
    public virtual double TotalOfPayments
    {
      get { return m_totalOfPayments; }
      set { m_totalOfPayments = value; }
    }


    /// <summary>
    /// APR of this pay plan.
    /// </summary>
    public virtual double Apr
    {
      get { return m_apr; }
      set { m_apr = value; }
    }

    /// <summary>
    /// Finance Charge for this pay plan.
    /// </summary>
    public virtual double FinanceCharge
    {
      get { return m_financeCharge; }
      set { m_financeCharge = value; }
    }
  }
}
