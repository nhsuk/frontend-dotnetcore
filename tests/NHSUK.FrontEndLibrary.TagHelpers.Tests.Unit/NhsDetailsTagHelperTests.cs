using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Details;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit.TagHelpers
{
  public class NhsDetailsTagHelperTests
  {
    private readonly NhsDetailsTagHelper _tagHelper;
    private string _text = "Opening Times";
    private string _htmlContent = "<table><tbody><tr><th>Day of the week/th>" +
                                       "<th>Opening hours</th></tr></tbody></table>" +
                                       "<p>Ask your GP practice for help if you can't find your NHS number..</p>";
    private readonly TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsDetailsTagHelperTests()
    {

      _tagHelper = new NhsDetailsTagHelper { DetailsType = DetailsType.Standard, DisplayText = _text};
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
    public async void ProcessAsync_Should_Set_PreContent()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<summary class=\"nhsuk-details__summary\">" +
                                 "<span class=\"nhsuk-details__summary-text\">" +
                                 "{0}</span></summary><div class=\"nhsuk-details__text\">", _text), _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PostContent()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("</div>", _tagHelperOutput.PostContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(_htmlContent, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Details, _tagHelperOutput.TagName);
    }

    [Theory]
    [InlineData(DetailsType.Standard)]
    [InlineData((DetailsType)(-1))]
    public async void ProcessAsync_Should_Set_Standard_Details_Type_ClassAttribute(DetailsType type)
    {
      _tagHelper.DetailsType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkDetails, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Expander_Type_ClassAttribute()
    {
      _tagHelper.DetailsType = DetailsType.Expander;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkExpander, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
  }
}
