using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.BackLink;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsBackLinkTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private const string Text = "Go back";
    private const string Href = "#";
    private NhsBackLinkTagHelper _tagHelper;
    public NhsBackLinkTagHelperTests()
    {
      _tagHelper = new NhsBackLinkTagHelper();
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

    [Fact]
    public async void ProcessAsync_Should_Set_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkBackLink, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
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
      Assert.Equal(string.Format("<a class=\"nhsuk-back-link__link\" href=\"{0}\">" +
                                 "<svg class=\"nhsuk-icon nhsuk-icon__chevron-left\" xmlns=\"http://www.w3.org/2000/svg\"" +
                                 " viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M8.5 12c0-.3.1-.5.3-.7l5-5c.4-.4 1-.4" +
                                 " 1.4 0s.4 1 0 1.4L10.9 12l4.3 4.3c.4.4.4 1 0 1.4s-1 .4-1.4 0l-5-5c-.2-.2-.3-.4-.3-.7z\"></path>" +
                                 "</svg>{1}</a>", Href, Text), _tagHelperOutput.Content.GetContent());
    }

  }
}
