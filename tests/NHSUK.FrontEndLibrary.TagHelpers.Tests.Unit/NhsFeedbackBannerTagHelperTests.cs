using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.FeedbackBanner;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsFeedbackBannerTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private string title = "Help us make the NHS website better";
    private string linkText = "Take our short survey";
    private const string Text = "Your feedback";
    private const string Href = "www.nhs.uk";
    private NhsFeedbackBannerTagHelper _tagHelper;
    public NhsFeedbackBannerTagHelperTests()
    {
      _tagHelper = new NhsFeedbackBannerTagHelper { TitleText = title, LinkLabel = linkText};
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
      Assert.Equal(CssClasses.NhsUkFeedbackBanner, _tagHelperOutput.Attributes[attribute].Value);
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
      Assert.Equal(string.Format("<div class=\"nhsuk-width-container\"><div class=\"nhsuk-grid-row\"><div class=\"nhsuk-grid-column-full\">" +
                                 "<div class=\"nhsuk-feedback-banner__content\"><h2 class=\"nhsuk-feedback-banner__heading\">{0}</h2>" +
                                 "<p class=\"nhsuk-feedback-banner__message\">{1} <a href=\"{2}\"" +
                                 " class=\"nhsuk-u-nowrap\">{3}</a></p><button class=\"nhsuk-feedback-banner__close\" id=\"nhsuk-feedback-banner-close\"" +
                                 " type=\"button\">Close<span class=\"nhsuk-u-visually-hidden\"> feedback invite</span></button></div></div>" +
                                 "</div></div>", title, Text, Href, linkText), _tagHelperOutput.Content.GetContent());
    }

  }
}
