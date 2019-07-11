using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.SummaryList;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsSummaryListRowActionsTagHelperTests
  {
    private readonly NhsSummaryListRowActionsTagHelper _tagHelper;
    private const string Text = "Change";
    private static string _href = "#";
    private static string _visuallyHiddenText = "contact name";
    private string content = string.Format("<a href=\"{0}\">{1}<span class=\"nhsuk-u-visually-hidden\">" +
                                           "{2}</span></a>", _href, Text, _visuallyHiddenText);

    private readonly TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsSummaryListRowActionsTagHelperTests()
    {

      _tagHelper = new NhsSummaryListRowActionsTagHelper();
      _tagHelperContext = new TagHelperContext(
            new TagHelperAttributeList  {
              new TagHelperAttribute("href", new HtmlString(_href))
            },
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
      _tagHelper.VisuallyHiddenText = _visuallyHiddenText;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(content, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Dd, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkSummaryListRowActions, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
    
  }
}
