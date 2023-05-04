using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TurboRater.ApiClients.Imp;
using TurboRater.Insurance.AU;
using TurboRater.Insurance;
using TurboRater.InterfaceSpecifications;
using TurboRater.ApiClients.Imp.Itc.EFContexts;
using System.Net;
using TurboRater;
using TurboRater.ApiClients.RateEngineApi;
using TurboRater.Insurance.DataTransformation;
using Microsoft.OData.Core;
using Microsoft.OData.Edm;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web;
using System.Threading;

using SdkRater.RateUtilityLib;

namespace SdkRater
{
  public partial class MainForm : Form
  {
    /// <summary>
    /// stored user data record
    /// </summary>
    private ApiUserData aPIUserData { get; set; }

    /// <summary>
    /// A library unit that does the bulk of the work.
    /// </summary>
    private CommonLib CommonLibrary;

    /// <summary>
    /// Load stored user data from an encrypted file based on profile
    /// </summary>
    private void LoadCredentials()
    {
      aPIUserData = ApiLocalStorage.Load();
      ImpAccountIDEntry.Text = aPIUserData.ImpAccountID;
      TestAccountNameEntry.Text = aPIUserData.TestAccountName;
      TestAgencyIDEntry.Text = aPIUserData.TestAgencyID;
      TestImpIntegrationKeyEntry.Text = aPIUserData.ImpIntegrationKey;
      LiveImpAccountIDEntry.Text = aPIUserData.LiveImpAccountID;
      ItcRatingServiceAccountIDEntry.Text = aPIUserData.ItcRateEngineAccountID;
      LiveItcRatingServiceAccountIDEntry.Text = aPIUserData.LiveItcRateEngineAccountID;
      LiveAccountNameEntry.Text = aPIUserData.LiveAccountName;
      LiveAgencyIDEntry.Text = aPIUserData.LiveAgencyID;
      LiveImpIntegrationKeyEntry.Text = aPIUserData.LiveImpIntegrationKey;
      TokenComboBox.Text = aPIUserData.AuthenticationType;
      QuotesComboBox.Text = aPIUserData.LiveSite ? "Live" : "Test";
    }

    /// <summary>
    /// Store user data to an encrypted file based on profile
    /// </summary>
    private void StoreCredentials()
    {
      aPIUserData.ImpAccountID = ImpAccountIDEntry.Text;
      aPIUserData.LiveImpAccountID = LiveImpAccountIDEntry.Text;
      aPIUserData.ItcRateEngineAccountID = ItcRatingServiceAccountIDEntry.Text;
      aPIUserData.TestAccountName = TestAccountNameEntry.Text;
      aPIUserData.TestAgencyID = TestAgencyIDEntry.Text;
      aPIUserData.ImpIntegrationKey = TestImpIntegrationKeyEntry.Text;
      aPIUserData.LiveItcRateEngineAccountID = LiveItcRatingServiceAccountIDEntry.Text;
      aPIUserData.AuthenticationType = String.IsNullOrWhiteSpace(TokenComboBox.Text) ? "Basic" : TokenComboBox.Text;
      aPIUserData.LiveAccountName = LiveAccountNameEntry.Text;
      aPIUserData.LiveAgencyID = LiveAgencyIDEntry.Text;
      aPIUserData.LiveImpIntegrationKey = LiveImpIntegrationKeyEntry.Text;
      aPIUserData.LiveSite = QuotesComboBox.Text.Equals("live", StringComparison.OrdinalIgnoreCase);
      aPIUserData.ValidCredentials = true;
      ApiLocalStorage.Save(aPIUserData);
    }

    /// <summary>
    /// Search quote data for user based on entered criteria such as Insured Last Name/Insured First Name/Insured Phone Number
    /// </summary>
    private bool SearchQuotes()
    {
      if (CommonLibrary.AcquireToken())
      {
        Constants.SearchLastName = LastNameSearchEntry.Text;
        Constants.SearchFirstName = FirstNameSearchEntry.Text;
        Constants.SearchPhoneNumber = PhoneNumberSearchEntry.Text;
        Constants.SearchProductState = StateListComboBox.Text;
        if (CommonLibrary.SearchQuotes(QuotesGridView))
        {
          SelectAllQuotesButton.Visible = true;
          DeSelectAllQuotesButton.Visible = true;
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// Create/Rate/Export the rate results based on entered information by the user
    /// </summary>
    private void RateQuotes()
    {
      if (CommonLibrary.ValidateCredentials())
      {
        CommonLibrary.BuildRatingRequest(QuotesGridView, RealTimeCompaniesGridView);
        CommonLibrary.RateQuotes(QuotesGridView, RealTimeCompaniesGridView);
        CommonLibrary.ExportResults();
      }
    }

    /// <summary>
    /// Validate the user's entered credentials
    /// </summary>
    /// <returns>Returns true if imp client id and ITCRateEngineId are valid, false if not</returns>
    private bool ValidateCredentials()
    {
      return CommonLibrary.ValidateCredentials();
    }

    public MainForm()
    {
      InitializeComponent();
      CommonLibrary = new CommonLib();
      LoadCredentials();
      LoadConstants();

      CommonLibrary.rateEngineApiClient = new RateEngineApiClient() { AuthId = aPIUserData?.ItcRateEngineAccountID, AuthPassword = aPIUserData?.ItcRateEngineAccountID };
      CommonLibrary.rateEngineApiClient.BaseUrl = Constants.LiveSite ? RateEngineApiConstants.BaseUrlLive :  RateEngineApiConstants.BaseUrlTest;
      CommonLibrary.ApiImpClient = new ImpClient() { BaseUrl = Constants.ImpConstantsUrl };
      RateQuotesButton.Enabled = false;

      if (!String.IsNullOrWhiteSpace(Constants.ImpAccountId))
      {
        StateListComboBox.DataSource = CommonLibrary.ApiImpClient.States(ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty));
        StateListComboBox.Text = StateListComboBox.Items.IndexOf("TX") != -1 ? "TX" : StateListComboBox.Items[0].ToString();
      }
      QuotesComboBox.Text = Constants.LiveSite ? "Live" : "Test";

      QuotesGridView.DataSource = null;
      QuotesGridView.ColumnHeadersVisible = false;
      RealTimeCompaniesGridView.DataSource = null;
      RealTimeCompaniesGridView.ColumnHeadersVisible = false;

      SelectAllQuotesButton.Visible = false;
      DeSelectAllQuotesButton.Visible = false;

      SelectAllRealtimeCompaniesButton.Visible = false;
      DeSelectAllRealtimeCompaniesButton.Visible = false;
    }

    private void LoadConstants()
    {
      Constants.LiveSite = QuotesComboBox.Text.Equals("live", StringComparison.OrdinalIgnoreCase);
      //Constants.LiveSite = false;
      Constants.TestImpAccountId = ImpAccountIDEntry.Text;
      Constants.LiveImpAccountId = LiveImpAccountIDEntry.Text;
      Constants.TestItcRatingServiceAccountId = ItcRatingServiceAccountIDEntry.Text;
      Constants.LiveItcRatingServiceAccountId = LiveItcRatingServiceAccountIDEntry.Text;
      Constants.TestAgencyAccountName = TestAccountNameEntry.Text;
      Constants.LiveAgencyAccountName = LiveAccountNameEntry.Text;
      Constants.TestAgencyId = TestAgencyIDEntry.Text;
      Constants.LiveAgencyId = LiveAgencyIDEntry.Text;
      Constants.TestImpIntegrationKey = TestImpIntegrationKeyEntry.Text;
      Constants.LiveImpIntegrationKey = LiveImpIntegrationKeyEntry.Text;
    }

    /// <summary>
    /// Store user data to an encrypted file based on profile
    /// </summary>
    /// <param name="sender">The object sending the EventArgs</param>
    /// <param name="e">The event arguments for the click event</param>
    private void SaveButton_Click(object sender, EventArgs e)
    {
      StoreCredentials();
      LoadConstants();
      QuotesComboBox.Text = Constants.LiveSite ? "Live" : "Test";
      TokenComboBox.Text = aPIUserData.AuthenticationType;
      if (!String.IsNullOrWhiteSpace(Constants.ImpAccountId))
      {
        StateListComboBox.DataSource = CommonLibrary.ApiImpClient.States(ITCConvert.ToGuid(Constants.ImpAccountId, Guid.Empty));
        StateListComboBox.Text = StateListComboBox.Items.IndexOf("TX") != -1 ? "TX" : StateListComboBox.Items[0].ToString();
      }
      MessageBox.Show("Credential storing complete");
    }

    /// <summary>
    /// Search the quotes for the agency based on criteria entered such as the Insured's Last Name/First Name/Phone Number
    /// </summary>
    /// <param name="sender">The object sending the EventArgs</param>
    /// <param name="e">The event arguments for the click event</param>
    private void SearchQuotesButton_Click(object sender, EventArgs e)
    {
      QuotesGridView.ColumnHeadersVisible = false;
      RealTimeCompaniesGridView.ColumnHeadersVisible = false;
      Constants.BearerAuthorization = TokenComboBox.Text.Equals("bearer", StringComparison.OrdinalIgnoreCase);
      if (SearchQuotes())
      {
        RealTimeCompaniesGridView.DataSource = null;
        CommonLibrary.AcquireCarriers(RealTimeCompaniesGridView);
        RealTimeCompaniesGridView.AutoGenerateColumns = false;
        RealTimeCompaniesGridView.ColumnHeadersVisible = true;
        RealTimeCompaniesGridView.DataSource = CommonLibrary.SelectedRealtimeCarriers.ToList();
        SelectAllRealtimeCompaniesButton.Visible = true;
        DeSelectAllRealtimeCompaniesButton.Visible = true;
        RateQuotesButton.Enabled = QuotesGridView.DataSource != null && RealTimeCompaniesGridView.DataSource != null;
      }
    }

    /// <summary>
    /// After validation of the customer's credentials allow them to create/rate/export requests
    /// </summary>
    /// <param name="sender">The object sending the EventArgs</param>
    /// <param name="e">The event arguments for the click event</param>
    private void RateQuotesButton_Click(object sender, EventArgs e)
    {
      if (CommonLibrary.ValidateCredentials())
      {
        CommonLibrary.BuildRatingRequest(QuotesGridView, RealTimeCompaniesGridView);
        CommonLibrary.OnQuoteProgress += new CommonLib.QuoteProgress(CommonLibrary.CommonLib_RateQuoteProgress);
        CommonLibrary.RateQuotes(QuotesGridView, RealTimeCompaniesGridView);
        CommonLibrary.OnQuoteProgress -= new CommonLib.QuoteProgress(CommonLibrary.CommonLib_RateQuoteProgress);
        CommonLibrary.ExportResults();
      }
    }

    /// <summary>
    /// turn on all quotes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SelectAllQuotesButton_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in QuotesGridView.Rows)
        row.Cells["Selected"].Value = true;
    }

    /// <summary>
    /// turn off all quotes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeSelectAllQuotesButton_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in QuotesGridView.Rows)
        row.Cells["Selected"].Value = false;
    }

    /// <summary>
    /// turn on all real-time carriers
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SelectAllRealtimeCompaniesButton_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in RealTimeCompaniesGridView.Rows)
        row.Cells["SelectedCarrier"].Value = true;
    }

    /// <summary>
    /// turn off all real-time carriers
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeSelectAllRealtimeCompaniesButton_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in RealTimeCompaniesGridView.Rows)
        row.Cells["SelectedCarrier"].Value = false;
    }
  }
}
