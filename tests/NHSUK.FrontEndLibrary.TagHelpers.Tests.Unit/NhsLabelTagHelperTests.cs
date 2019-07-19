using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Label;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsLabelTagHelperTests
  {
    private readonly NhsLabelTagHelper _tagHelper;
    private const string Text = "national insurance number";
    private readonly TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsLabelTagHelperTests()
    {
      _tagHelper = new NhsLabelTagHelper { LabelType = LabelType.Standard };
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

    [Theory]
    [InlineData(LabelType.Standard)]
    [InlineData((LabelType)(-1))]
    public async void ProcessAsync_Should_Set_Standard_Label_Type_ClassAttribute(LabelType type)
    {
      _tagHelper.LabelType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabel, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Bold_Label_Type_ClassAttribute()
    {
      _tagHelper.LabelType = LabelType.Bold;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabelBold, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Medium_Label_Type_ClassAttribute()
    {
      _tagHelper.LabelType = LabelType.Medium;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabelMedium, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Large_Label_Type_ClassAttribute()
    {
      _tagHelper.LabelType = LabelType.Large;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabelLarge, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Checkboxes_Label_Type_ClassAttribute()
    {
      _tagHelper.LabelType = LabelType.Checkboxes;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabelCheckboxes, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Date_Label_Type_ClassAttribute()
    {
      _tagHelper.LabelType = LabelType.Date;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabelDate, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Radios_Label_Type_ClassAttribute()
    {
      _tagHelper.LabelType = LabelType.Radios;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabelRadios, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Page_Heading_Label_Type_ClassAttribute()
    {
      _tagHelper.LabelType = LabelType.PageHeading;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabelPageHeader, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
  }
}