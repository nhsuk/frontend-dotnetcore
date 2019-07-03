using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.EmergencyAlert;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsEmergencyAlertTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private string lastUpdated = "2hrs ago";
    private string title = "National flu outbreak";
    private string linkText = "how does this affect me";
    private const string Text = "There is a flu outbreak";
    private const string Href = "www.nhs.uk";
    private NhsEmergencyAlertTagHelper _tagHelper;
    public NhsEmergencyAlertTagHelperTests()
    {
      _tagHelper = new NhsEmergencyAlertTagHelper{ TitleText = title, LastUpdated = lastUpdated, LinkLabel = linkText};
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("href", new HtmlString(Href))
        },
          new Dictionary<object, object>(),
          Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
         new TagHelperAttributeList(),
         (useCachedResult, encoder) =>
         {
           var tagHelperContent = new DefaultTagHelperContent();
           return Task.FromResult(tagHelperContent.SetHtmlContent(Text));
         });
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Theory]
    [InlineData(HtmlAttributes.ClassAttribute)]
    [InlineData(HtmlAttributes.IdAttribute)]
    public async void ProcessAsync_Should_Set_Attribute(string attribute)
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkGlobalAlert, _tagHelperOutput.Attributes[attribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<div class=\"nhsuk-width-container\"><div class=\"nhsuk-grid-row\">" +
                                 "<div class=\"nhsuk-grid-column-full\"><div class=\"nhsuk-global-alert__content\">" +
                                 "<h2 class=\"nhsuk-global-alert__heading\"><span class=\"nhsuk-u-visually-hidden\">Alert: </span>" +
                                 "{0}</h2><p class=\"nhsuk-global-alert__message\">{1}" +
                                 " <a class=\"nhsuk-u-nowrap\" href=\"{2}\" >{3}</a></p>" +
                                 "<p class=\"nhsuk-global-alert__updated\">{4}</p></div></div></div></div>", title, Text, Href, linkText, lastUpdated), _tagHelperOutput.Content.GetContent());
    }

  }
}
