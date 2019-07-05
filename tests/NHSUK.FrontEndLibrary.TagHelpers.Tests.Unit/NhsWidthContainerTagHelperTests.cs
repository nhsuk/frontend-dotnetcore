using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Layout;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsWidthContainerTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly NhsWidthContainerTagHelper _tagHelper;
    private readonly TagHelperContext _tagHelperContext;
    public NhsWidthContainerTagHelperTests()
    {
      _tagHelper = new NhsWidthContainerTagHelper();
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
    public void Process_Should_Set_TagName()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_Fluid_Type_ClassAttribute()
    {
      _tagHelper.ContainerWidth = ContainerWidth.Fluid;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkWidthContainerFluid, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Theory]
    [InlineData(ContainerWidth.Standard)]
    [InlineData((ContainerWidth)(-1))]
    public void Process_Should_Set_Normal_Type_ClassAttribute(ContainerWidth width)
    {
      _tagHelper.ContainerWidth = width;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkWidthContainer, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }



    [Fact]
    public void Process_Should_Set_TagMode()
    {
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }
  }
}
