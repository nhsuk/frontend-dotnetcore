using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Panel;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsPanelTagHelperrTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private readonly NhsPanelTagHelper _tagHelper;
    private string label = "Exercise";
    private string content = "<p>wash your hands</p>";
    public NhsPanelTagHelperrTests()
    {
      _tagHelper = new NhsPanelTagHelper();
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList(),
        new Dictionary<object, object>(),
       Guid.NewGuid().ToString("N"));

      _tagHelperOutput = new TagHelperOutput(string.Empty,
         new TagHelperAttributeList(),
         (useCachedResult, encoder) =>
         {
           var tagHelperContent = new DefaultTagHelperContent();
           return Task.FromResult(tagHelperContent.SetHtmlContent(content));
         });
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Theory]
    [InlineData(PanelType.Standard)]
    [InlineData((PanelType)(-1))]
    public async void ProcessAsync_Should_Set_Standard_ClassAttribute(PanelType type)
    {
      _tagHelper.PanelType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(CssClasses.NhsUkPanel, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Grey_ClassAttribute()
      {
      _tagHelper.PanelType = PanelType.Grey;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(CssClasses.NhsUkPanelGrey, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_WithLabel_ClassAttribute()
    {
      _tagHelper.PanelType = PanelType.WithLabel;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(CssClasses.NhsUkPanelLabel, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_WithLabel_Precontent()
    {
      _tagHelper.PanelType = PanelType.WithLabel;
      _tagHelper.Label = label;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Format("<h3 class=\"nhsuk-panel-with-label__label\">{0}</h3>", label), _tagHelperOutput.PreContent.GetContent());
    }

    [Theory]
    [InlineData(GridColumnWidth.Full, CssClasses.NhsUkGridFull)]
    [InlineData(GridColumnWidth.OneHalf, CssClasses.NhsUkGridOneHalf)]
    [InlineData(GridColumnWidth.OneQuarter, CssClasses.NhsUkGridOneQuarter)]
    [InlineData(GridColumnWidth.OneThird, CssClasses.NhsUkGridOneThird)]
    [InlineData(GridColumnWidth.TwoThirds, CssClasses.NhsUkGridTwoThirds)]
    [InlineData(GridColumnWidth.ThreeQuarters, CssClasses.NhsUkGridThreeQuarters)]
    [InlineData((GridColumnWidth)(-1), CssClasses.NhsUkGridFull)]
    public async void ProcessAsync_Should_Set_PanelGroup_PreElement(GridColumnWidth width, string classAttribute)
    {
      _tagHelperContext.Items["ParentColumnWidth"] = width;

      var expected = string.Format("<div class=\"{0} nhsuk-panel-group__item\">", classAttribute);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.PreElement.GetContent());
    }
    
    [Fact]
    public async void ProcessAsync_Should_Not_Set_PreElement_If_No_PanelGroup()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Empty, _tagHelperOutput.PreElement.GetContent());
    }


    [Theory]
    [InlineData(GridColumnWidth.Full)]
    [InlineData(GridColumnWidth.OneHalf)]
    [InlineData(GridColumnWidth.OneQuarter)]
    [InlineData(GridColumnWidth.OneThird)]
    [InlineData(GridColumnWidth.TwoThirds)]
    [InlineData(GridColumnWidth.ThreeQuarters)]
    public async void ProcessAsync_Should_Set_PanelGroup_PostElement(GridColumnWidth width)
    {
      _tagHelperContext.Items["ParentColumnWidth"] = width;

      var expected = "</div>";

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.PostElement.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Not_Set_PostElement_If_No_PanelGroup()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Empty, _tagHelperOutput.PostElement.GetContent());
    }

  }
}
