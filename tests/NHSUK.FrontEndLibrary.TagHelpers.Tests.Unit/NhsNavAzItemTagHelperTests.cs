using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.NavAZ;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsNavAzItemTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly TagHelperContext _tagHelperContext;
    private readonly NhsNavAzItemTagHelper _tagHelper;
    private const string Text = "A";
    public NhsNavAzItemTagHelperTests()
    {
       _tagHelper = new NhsNavAzItemTagHelper();
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
      Assert.Equal(CssClasses.NhsUkNavAzItem, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Disabled_Content()
    {
      _tagHelper.Disabled = true;

      var expected = string.Format("<span class=\"nhsuk-nav-a-z__link--disabled\">{0}</span>", Text);
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      _tagHelper.Disabled = false;

      var expected = "<a class=\"nhsuk-nav-a-z__link\" href=\"#A\">A</a>";
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }
  }
}
