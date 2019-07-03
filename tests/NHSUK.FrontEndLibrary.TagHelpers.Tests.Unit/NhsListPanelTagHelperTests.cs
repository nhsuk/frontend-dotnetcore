using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.ListPanel;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit.TagHelpers
{
  public class NhsListPanelTagHelperTests
  {
    private TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private readonly NhsListPanelTagHelper _tagHelper;
    private string content = "no content";
    private readonly string _text = "S";
    private readonly string link = "#nhsuk-nav-a-z";
    public NhsListPanelTagHelperTests()
    {
       _tagHelper = new NhsListPanelTagHelper{Label = _text};
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("id", "S")
        },
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
         new TagHelperAttributeList(),
         (useCachedResult, encoder) =>
         {
           var tagHelperContent = new DefaultTagHelperContent();
           return Task.FromResult<TagHelperContent>(tagHelperContent);
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
      Assert.Equal(CssClasses.NhsUkListPanel, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PreContent_BackToTop()
    {
      _tagHelper.BackToTopLink = link;
     var expected = string.Format(
        "<h2 class=\"nhsuk-list-panel__label\" id=\"{0}\">{1}</h2>" +
        "<ul class=\"nhsuk-list-panel__list nhsuk-list-panel__list--with-label\">", _text, _text); 
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PostContent_BackToTop()
    {
      _tagHelper.BackToTopLink = link;
      var expected = string.Format(
        "</ul><div class=\"nhsuk-back-to-top\"><a class=\"nhsuk-back-to-top__link\"" +
        " href=\"{0}\"><svg class=\"nhsuk-icon nhsuk-icon__arrow-right\" xmlns=\"http://www.w3.org/2000/svg\" " +
        "viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M19.6 11.66l-2.73-3A.51.51 0 0 0 16" +
        " 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z\">" +
        "</path></svg>Back to top</a></div>", link);
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.PostContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PostContent_NoBackToTop()
    {
      var expected = "</ul>";
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.PostContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PreElement()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("<li>", _tagHelperOutput.PreElement.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PostElement()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("</li>", _tagHelperOutput.PostElement.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Disabled_Content()
    {
      _tagHelper.Disabled = true;

      _tagHelperOutput = new TagHelperOutput(string.Empty,
        new TagHelperAttributeList(),
        (useCachedResult, encoder) =>
        {
          var tagHelperContent = new DefaultTagHelperContent();
          return Task.FromResult(tagHelperContent.SetHtmlContent(content));
        });

      var expected = string.Format(
        "<h2 class=\"nhsuk-list-panel__label\" id=\"{0}\">{1}</h2>" +
        "<div class=\"nhsuk-list-panel__box nhsuk-list-panel__box--with-label\">" +
        "<p class=\"nhsuk-list-panel--results-items__no-results\">{2}</p></div>", _text, _text, content);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

  }
}
