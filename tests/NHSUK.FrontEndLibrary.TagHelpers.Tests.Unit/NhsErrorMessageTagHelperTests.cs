using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.ErrorMessage;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsErrorMessageTagHelperTests
  {
    private readonly NhsErrorMessageTagHelper _tagHelper;
    private const string Text = "national insurance number";
    private TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsErrorMessageTagHelperTests()
    {

      _tagHelper = new NhsErrorMessageTagHelper();
      _tagHelperContext = new TagHelperContext(
          new TagHelperAttributeList(),
          new Dictionary<object, object>(),
          Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
          new TagHelperAttributeList(),
          (result, encoder) =>
          {
            var tagHelperContent = new DefaultTagHelperContent();
            return Task.FromResult(tagHelperContent.SetHtmlContent(Text));
          });
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("asp-validation-for", new HtmlString("error"))
        },
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Empty, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content_If_No_AspValidation()
    {
     await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(Text, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PreContent()
    {
      var expected = "<span class=\"nhsuk-u-visually-hidden\">Error:</span>";
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.PreContent.GetContent());
    }

    [Theory]
    [InlineData(SpanType.ErrorMessage)]
    [InlineData((SpanType)(-1))]
    public async void ProcessAsync_Should_Set_ClassAttribute(SpanType type)
    {
      _tagHelper.SpanType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkErrorMessage, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
  }
}
