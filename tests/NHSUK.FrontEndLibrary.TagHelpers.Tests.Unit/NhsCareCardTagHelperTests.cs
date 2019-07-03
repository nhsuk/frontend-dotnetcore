using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.CareCard;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsCareCardTagHelperTests
  {
    private readonly NhsCareCardTagHelper _tagHelper;
    private string htmlContent = "<ul><li> spreads to your arms, back, neck or jaw</li>" +
                                       "</ul><p>Call 999 immediately.</p>";
    private readonly TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsCareCardTagHelperTests()
    {

      _tagHelper = new NhsCareCardTagHelper { CareCardType = CareCardType.NonUrgent, CareCardHeading = "See Gp If"};
      _tagHelperContext = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
          new TagHelperAttributeList(),
          (result, encoder) =>
          {
            var tagHelperContent = new DefaultTagHelperContent();

            return Task.FromResult(tagHelperContent.SetHtmlContent(htmlContent));
          });
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Urgent_PreContent()
    {
      _tagHelper.CareCardType = CareCardType.Urgent;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<div class=\"nhsuk-care-card__heading-container\"><h3 class=\"nhsuk-care-card__heading\">" +
                                 "<span role =\"text\"><span class=\"nhsuk-u-visually-hidden\">{0}:</span>{1}:</span></h3>" +
                                 "<span class=\"nhsuk-care-card__arrow\" aria-hidden=\"true\"></span></div>" +
                                 "<div class=\"nhsuk-care-card__content\">", ContentText.CareCardUrgentHiddenText, _tagHelper.CareCardHeading), _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_NonUrgent_PreContent()
    {
      _tagHelper.CareCardType = CareCardType.NonUrgent;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<div class=\"nhsuk-care-card__heading-container\"><h3 class=\"nhsuk-care-card__heading\">" +
                                 "<span role =\"text\"><span class=\"nhsuk-u-visually-hidden\">{0}:</span>{1}:</span></h3>" +
                                 "<span class=\"nhsuk-care-card__arrow\" aria-hidden=\"true\"></span></div>" +
                                 "<div class=\"nhsuk-care-card__content\">", ContentText.CareCardNonUrgentHiddenText, _tagHelper.CareCardHeading), _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Immediate_PreContent()
    {
      _tagHelper.CareCardType = CareCardType.Immediate;
      _tagHelper.CareCardHeading = "Call 999";
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<div class=\"nhsuk-care-card__heading-container\"><h3 class=\"nhsuk-care-card__heading\">" +
                                 "<span role =\"text\"><span class=\"nhsuk-u-visually-hidden\">{0}:</span>{1}:</span></h3>" +
                                 "<span class=\"nhsuk-care-card__arrow\" aria-hidden=\"true\"></span></div>" +
                                 "<div class=\"nhsuk-care-card__content\">", ContentText.CareCardImmediateHiddenText, "Call 999"), _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PostContent()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("</div>", _tagHelperOutput.PostContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(htmlContent, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Theory]
    [InlineData(CareCardType.NonUrgent)]
    [InlineData((CareCardType)(-1))]
    public async void ProcessAsync_Should_Set_Standard_Carecard_Type_ClassAttribute(CareCardType type)
    {
      _tagHelper.CareCardType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkCareCardNonUrgent, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Immediate_Carecard_Type_ClassAttribute()
    {
      _tagHelper.CareCardType = CareCardType.Immediate;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkCareCardImmediate, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Urgent_Carecard_Type_ClassAttribute()
    {
      _tagHelper.CareCardType = CareCardType.Urgent;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkCareCardUrgent, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
  }
}
