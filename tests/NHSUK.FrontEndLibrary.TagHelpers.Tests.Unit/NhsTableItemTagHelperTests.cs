using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Table;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsTableItemTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly NhsTableItemTagHelper _tagHelper;
    private readonly TagHelperContext _tagHelperContext;
    private string _text = "sore throat";

    public NhsTableItemTagHelperTests()
    {
      _tagHelper = new NhsTableItemTagHelper();
      _tagHelperContext = new TagHelperContext(
          new TagHelperAttributeList(),
          new Dictionary<object, object>(),
          Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
         new TagHelperAttributeList(),
         (useCachedResult, encoder) =>
         {
           var tagHelperContent = new DefaultTagHelperContent();
           return Task.FromResult(tagHelperContent.SetHtmlContent(_text));
         });

    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TableHeadItem_TagName()
    {
      _tagHelperContext.Items["ParentType"] = TagHelperNames.NhsTableHeadTag;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Th, _tagHelperOutput.TagName);
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TableBodyItem_TagName()
    {
      _tagHelperContext.Items["ParentType"] = TagHelperNames.NhsTableBodyRowTag;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Td, _tagHelperOutput.TagName);
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TableBodyItem_CellIsHeader_TagName()
    {
      _tagHelper.CellIsHeader = true;
      _tagHelperContext.Items["ParentType"] = TagHelperNames.NhsTableBodyRowTag;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Th, _tagHelperOutput.TagName);
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_Content()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(_text, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TableHeadItem_ClassAttribute()
    {
      _tagHelperContext.Items["ParentType"] = TagHelperNames.NhsTableHeadTag;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkTableHeader, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TableHeadItem_ScopeAttribute()
    {
      _tagHelperContext.Items["ParentType"] = TagHelperNames.NhsTableHeadTag;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("col", _tagHelperOutput.Attributes["scope"].Value);
    }


    [Fact]
    public async Task ProcessAsync_Should_Set_TableBodyItem_ClassAttribute()
    {
      _tagHelperContext.Items["ParentType"] = TagHelperNames.NhsTableBodyRowTag;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkTableCell, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

  }
}
