using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Label;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsLabelTagHelperTests
  {
    private NhsLabelTagHelper _tagHelper;
    private const string Text = "national insurance number";
    private TagHelperContext _tagHelperContext;
    private TagHelperOutput _tagHelperOutput;
    private TestableHtmlGenerator _htmlGenerator;

    public NhsLabelTagHelperTests()
    {
      Init();
    }

    private void Init()
    {
      _htmlGenerator = new TestableHtmlGenerator(new EmptyModelMetadataProvider());

      _tagHelper = new NhsLabelTagHelper(_htmlGenerator)
      {
        LabelType = LabelType.Standard
      };
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


    //[Theory]
    //[InlineData(LabelType.Standard)]
    //[InlineData((LabelType)(-1))]
    //public async Task ProcessAsync_Should_Set_Standard_Label_Type_ClassAttribute(LabelType type)
    //{
    //  Init();
    //  _tagHelper.LabelType = type;
    //  await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
    //  Assert.Equal(CssClasses.NhsUkLabel, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    //}

    //[Fact]
    //public async Task ProcessAsync_Should_Set_Bold_Label_Type_ClassAttribute()
    //{
    //  Init();
    //  _tagHelper.LabelType = LabelType.Bold;
    //  await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
    //  Assert.Equal(CssClasses.NhsUkLabelBold, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    //}

    //[Fact]
    //public async Task ProcessAsync_Should_Set_Medium_Label_Type_ClassAttribute()
    //{
    //  Init();
    //  _tagHelper.LabelType = LabelType.Medium;
    //  await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
    //  Assert.Equal(CssClasses.NhsUkLabelMedium, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    //}

    //[Fact]
    //public async Task ProcessAsync_Should_Set_Large_Label_Type_ClassAttribute()
    //{
    //  Init();
    //  _tagHelper.LabelType = LabelType.Large;
    //  await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
    //  Assert.Equal(CssClasses.NhsUkLabelLarge, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    //}

    //[Fact]
    //public async Task ProcessAsync_Should_Set_Checkboxes_Label_Type_ClassAttribute()
    //{
    //  Init();
    //  _tagHelper.LabelType = LabelType.Checkboxes;
    //  await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
    //  Assert.Equal(CssClasses.NhsUkLabelCheckboxes, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    //}

    //[Fact]
    //public async Task ProcessAsync_Should_Set_Date_Label_Type_ClassAttribute()
    //{
    //  Init();
    //  _tagHelper.LabelType = LabelType.Date;
    //  await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
    //  Assert.Equal(CssClasses.NhsUkLabelDate, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    //}

    //[Fact]
    //public async Task ProcessAsync_Should_Set_Radios_Label_Type_ClassAttribute()
    //{
    //  Init();
    //  _tagHelper.LabelType = LabelType.Radios;
    //  await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
    //  Assert.Equal(CssClasses.NhsUkLabelRadios, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    //}

    [Fact]
    public async Task ProcessAsync_Should_Set_Page_Heading_Label_Type_ClassAttribute()
    {
      Init();
      _tagHelper.LabelType = LabelType.PageHeading;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkLabelPageHeader, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }


    [Fact]
    public async Task ProcessAsync_Should_Set_Content()
    {
      Init();
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(Text, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TagName()
    {
      Init();
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Label, _tagHelperOutput.TagName);
    }

  }
}
