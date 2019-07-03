using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.ErrorSummary;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit.TagHelpers
{
  public class NhsErrorSummaryTagHelperTests
  {
    private readonly NhsErrorSummaryTagHelper _tagHelper;
    private readonly TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly string _titleId = "testId";
    private readonly string _titleText = "There is a problem";
    private readonly string _descriptionText = "Please fix the below";
    private static readonly string ListItems =
      "<li><a href=\"\">Click here</a></li>";
    public NhsErrorSummaryTagHelperTests()
    {
      _tagHelper = new NhsErrorSummaryTagHelper { TitleId = _titleId, TitleText = _titleText, DescriptionText = _descriptionText };
      _tagHelperContext = new TagHelperContext(
          new TagHelperAttributeList(),
          new Dictionary<object, object>(),
          Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
          new TagHelperAttributeList(),
          (result, encoder) =>
          {
            var tagHelperContent = new DefaultTagHelperContent();
            return Task.FromResult(tagHelperContent.SetHtmlContent(ListItems));
          });
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      var expected = string.Format("<div class=\"nhsuk-error-summary__body\"><p>{0}</p><ul class=\"nhsuk-list nhsuk-error-summary__list\">{1}</ul></div>", _descriptionText, ListItems);
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PreContent()
    {
      var expected = string.Format("<h2 class=\"nhsuk-error-summary__title\" id=\"{0}\">{1}</h2>", _titleId, _titleText);
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
      Assert.Equal(CssClasses.NhsUkErrorSummary, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_AriaLabelByAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(_titleId, _tagHelperOutput.Attributes[HtmlAttributes.AriaLabelByAttribute].Value);
    }
  }
}
