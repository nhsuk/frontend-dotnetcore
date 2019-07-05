using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.List;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsListTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private NhsListTagHelper _tagHelper;
    private TagHelperContext _tagHelperContext;
    public NhsListTagHelperTests()
    {
      _tagHelper = new NhsListTagHelper();
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
    public void Process_Should_Set_Ordered_TagName()
    {
      _tagHelper.IsOrdered = true;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Ol, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_UnOrdered_TagName()
    {
      _tagHelper.IsOrdered = false;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Ul, _tagHelperOutput.TagName);
    }


    [Fact]
    public void Process_Should_Set_ClassAttribute()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkList, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

  }
}
