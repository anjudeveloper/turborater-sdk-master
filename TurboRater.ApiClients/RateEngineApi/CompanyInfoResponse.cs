// -----------------------------------------------------------------------
// <copyright file="CompanyInfoResponse.cs" company="ITC">
// Copyright ITC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
// Response containing company information from rate engine.
// </summary>

namespace TurboRater.ApiClients.RateEngineApi
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using TurboRater.Insurance;
  using TurboRater.Insurance.AU;
  using TurboRater.Insurance.DataTransformation;
  using TurboRater;

  /// <summary>
  /// Response containing company information from rate engine.
  /// </summary>
  public class CompanyInfoResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyInfoResponse" /> class.
    /// </summary>
    public CompanyInfoResponse()
    {
      this.CompanyInfoList = new List<CompanyInfo>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyInfoResponse" /> class. 
    /// Builds a company information list from a passed in data string. Uses TT2 format.
    /// </summary>
    /// <param name="companyInfoString">TT2 file string.</param>
    public CompanyInfoResponse(string companyInfoString)
    {
      this.CompanyInfoList = new List<CompanyInfo>();

      AUPolicy policy = new AUPolicy();
      TT2AUBridge bridge = new TT2AUBridge(companyInfoString, policy);
      bridge.Tags.Items.Sort();
      bridge.Tags.Sorted = true;

      ////Create records
      TT2TagList recordTags = bridge.FindMatchingTagsByName("recordid");

      int index = 0;
      foreach (TT2Tag recordTag in recordTags)
      {
        CompanyInfoList.Add(new CompanyInfo());
        int recordNum = recordTag.ScopeNum;
        TT2TagList infoTags = bridge.FindMatchingTagsByScope(ItemScope.Record, recordNum);

        foreach (TT2Tag infoTag in infoTags)
        {
          switch (infoTag.TagName)
          {
            case "recordid": CompanyInfoList[index].RecordID = Convert.ToInt64(infoTag.Values[0]);
              break;
            case "state": CompanyInfoList[index].State = infoTag.Values[0].ToString();
              break;
            case "companyname": CompanyInfoList[index].CompanyName = infoTag.Values[0].ToString();
              break;
            case "companyid": CompanyInfoList[index].CompanyID = Convert.ToInt64(infoTag.Values[0]);
              break;
            case "productid": CompanyInfoList[index].ProductID = ITCConvert.ToInt32(infoTag.Values[0], -1);
              break;
            case "programid": CompanyInfoList[index].ProgramID = ITCConvert.ToInt32(infoTag.Values[0], -1);
              break;
            case "programname": CompanyInfoList[index].ProgramName = infoTag.Values[0].ToString();
              break;
            case "ratemodule": CompanyInfoList[index].ModuleName = infoTag.Values[0].ToString();
              break;
            case "rate_effective_date": CompanyInfoList[index].RateEffectiveDate = DateTime.Parse(infoTag.Values[0].ToString());
              break;
            case "lineofinsurance": CompanyInfoList[index].LineOfInsurance = infoTag.Values[0].ToString();
              break;
            case "rate_type": CompanyInfoList[index].RateType = infoTag.Values[0].ToString();
              break;
            case "iscreditrequired": CompanyInfoList[index].CreditRequired = Convert.ToBoolean(infoTag.Values[0]);
              break;
            case "doscompanyid": CompanyInfoList[index].DOSCompanyID = ITCConvert.ToInt32(infoTag.Values[0], -1);
              break;
          }
        }

        index++;
      }
    }

    /// <summary>
    /// Gets or sets Used to relay messages if there is a problem with the request.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets A list of CompanyInfo objects.
    /// </summary>
    public List<CompanyInfo> CompanyInfoList { get; set; }
  }
}
