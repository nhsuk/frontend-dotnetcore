using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.InsetText;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsInsetTextTagHelperTests
  {
    private readonly NhsInsetTextTagHelper _tagHelper;
    private string _htmlContent = "<p>national insurance number </p>";
    private readonly TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsInsetTextTagHelperTests()
    {

      _tagHelper = new NhsInsetTextTagHelper();
      _tagHelperContext = new TagHelperContext(
          new TagHelperAttributeList(),
          new Dictionary<object, object>(),
          Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
          new TagHelperAttributeList(),
          (result, encoder) =>
          {
            var tagHelperContent = new DefaultTagHelperContent();
            return Task.FromResult(tagHelperContent.SetHtmlContent(_htmlContent));
          });
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(_htmlContent, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PreContent()
    {
      var expected = "<span class=\"nhsuk-u-visually-hidden\">Information: </span>";
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.PreContent.GetContent());
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
      Assert.Equal(CssClasses.NhsUkInsetText, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
  }
}
