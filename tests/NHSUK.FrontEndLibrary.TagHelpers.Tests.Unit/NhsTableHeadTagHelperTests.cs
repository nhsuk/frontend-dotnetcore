using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Table;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsTableHeadTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly NhsTableHeadTagHelper _tagHelper;
    private readonly TagHelperContext _tagHelperContext;

    public NhsTableHeadTagHelperTests()
    {
      _tagHelper = new NhsTableHeadTagHelper();
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
      Assert.Equal(HtmlElements.Thead, _tagHelperOutput.TagName);
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_PreContent()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("<tr class=\"nhsuk-table__row\">", _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_PostContent()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("</tr>", _tagHelperOutput.PostContent.GetContent());
    }

    [Fact]
    public async Task ProcessAsync_Should_Set_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkTableHead, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
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

      Assert.Equal(_tagHelperContext.Items["ParentType"], TagHelperNames.NhsTableHeadTag);
    }
  }
}
