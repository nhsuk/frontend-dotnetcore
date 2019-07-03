using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.FormGroup;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit.TagHelpers
{
  public class NhsFormGroupTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly NhsFormGroupTagHelper _tagHelper;
    private readonly TagHelperContext _tagHelperContext;
    public NhsFormGroupTagHelperTests()
    {
      _tagHelper = new NhsFormGroupTagHelper();
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
    public void Process_Should_Set_Error_Type_ClassAttribute()
    {
      _tagHelper.FormGroupType = FormGroupType.Error;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkFormGroupError, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_UpdateClasses()
    {
      var passedByUser= "nhs-margin nhs-hidden";
      _tagHelper.Classes = passedByUser;
      _tagHelper.FormGroupType = FormGroupType.Standard;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkFormGroup + " " + passedByUser, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Theory]
    [InlineData(FormGroupType.Standard)]
    [InlineData((FormGroupType)(-1))]
    public void Process_Should_Set_Normal_Type_ClassAttribute(FormGroupType type)
    {
      _tagHelper.FormGroupType = type;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkFormGroup, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }


    [Fact]
    public void Process_Should_Set_TagMode()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }
  }
}
