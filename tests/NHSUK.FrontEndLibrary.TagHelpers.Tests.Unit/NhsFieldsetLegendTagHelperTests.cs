using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Fieldset;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsFieldsetLegendTagHelperTests
  {
    private readonly NhsFieldsetLegendTagHelper _tagHelper;
    private string _text = "What is your address?";
    private readonly TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsFieldsetLegendTagHelperTests()
    {
      _tagHelper = new NhsFieldsetLegendTagHelper { LegendSize = LegendSize.Standard };
      _tagHelperContext = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
          new TagHelperAttributeList(),
          (result, encoder) =>
          {
            var tagHelperContent = new DefaultTagHelperContent();

            return Task.FromResult(tagHelperContent.SetHtmlContent(_text));
          });
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(_text, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Wrap_Content_In_H1_If_PageHeading()
    {
     
      _tagHelper.IsPageHeading = true;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<h1 class=\"{0}\">{1}</h1>", CssClasses.NhsUkFieldsetHeading, _text), _tagHelperOutput.Content.GetContent());
    }

   [Fact]
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Legend, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Standard_Legend_Type_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkFieldsetLegend, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Large_Legend_Type_ClassAttribute()
    {
      _tagHelper.LegendSize = LegendSize.Large;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkFieldsetLegendLarge, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Page_Heading_Legend_Type_ClassAttribute()
    {
      _tagHelper.LegendSize = LegendSize.XLarge;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkFieldsetLegendPageHeading, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Default_Legend_Type_ClassAttribute()
    {
      _tagHelper.LegendSize = (LegendSize)(-1);
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkFieldsetLegend, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
  }
}
