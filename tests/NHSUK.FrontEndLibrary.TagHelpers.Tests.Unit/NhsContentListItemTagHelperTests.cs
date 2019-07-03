using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.ContentList;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsContentListItemTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private readonly NhsContentListItemTagHelper _tagHelper;
    private const string Text = "Level one";
    private const string Href = "https://www.nhs.uk/contact-us/";


    public NhsContentListItemTagHelperTests()
    {
       _tagHelper = new NhsContentListItemTagHelper();
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList(),
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

      Assert.Equal(HtmlElements.Li, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(CssClasses.NhsUkContentListItem, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
    
    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_CurrentPage_Content()
    {
      _tagHelper.Current = true;
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("href", new HtmlString(Href))
        },
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));

      var expected = string.Format("<span class=\"nhsuk-contents-list__current\">{0}</span>", Text);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }


    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("href", new HtmlString(Href))
        },
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));

      var expected = string.Format("<a class=\"nhsuk-contents-list__link\" href=\"{0}\">" +
                                   "{1}</a>", Href, Text);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

  }
}
