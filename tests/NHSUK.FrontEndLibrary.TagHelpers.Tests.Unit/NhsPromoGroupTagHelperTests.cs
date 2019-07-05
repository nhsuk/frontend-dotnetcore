using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Promo;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsPromoGroupTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly TagHelperContext _tagHelperContext;
    private readonly NhsPromoGroupTagHelper _tagHelper;

    public NhsPromoGroupTagHelperTests()
    {
      _tagHelper = new NhsPromoGroupTagHelper();
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
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
    }

    [Fact]
    public void Process_Should_Set_TagName()
    {
      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_ClassAttribute()
    {
      Assert.Equal(CssClasses.NhsUkPromoGroup, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Theory]
    [InlineData(GridColumnWidth.Full)]
    [InlineData(GridColumnWidth.OneHalf)]
    [InlineData(GridColumnWidth.OneQuarter)]
    [InlineData(GridColumnWidth.OneThird)]
    [InlineData(GridColumnWidth.TwoThirds)]
    [InlineData(GridColumnWidth.ThreeQuarters)]
    public void Process_Should_Set_ParentType_Context(GridColumnWidth width)
    {
      _tagHelper.GridColumnWidth = width;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(_tagHelperContext.Items["ParentColumnWidth"], _tagHelper.GridColumnWidth);
    }


  }
}
