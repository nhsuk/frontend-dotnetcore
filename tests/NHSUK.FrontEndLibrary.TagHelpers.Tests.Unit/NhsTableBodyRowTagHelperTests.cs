using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Table;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsTableBodyRowTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly NhsTableBodyRowTagHelper _tagHelper;
    private readonly TagHelperContext _tagHelperContext;

    public NhsTableBodyRowTagHelperTests()
    {
      _tagHelper = new NhsTableBodyRowTagHelper();
      _tagHelperContext = new TagHelperContext(
          new TagHelperAttributeList(),
          new Dictionary<object, object>(),
          Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
         new TagHelperAttributeList(),
         (useCachedResult, encoder) =>
         {
           var tagHelperContent = new DefaultTagHelperContent();
           return Task.FromResult<TagHelperContent>(tagHelperContent);
         });

    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Tr, _tagHelperOutput.TagName);
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkTableRow, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async Task Process_Should_Set_ParentType_Context()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(_tagHelperContext.Items["ParentType"], TagHelperNames.NhsTableBodyRowTag);
    }
  }
}
