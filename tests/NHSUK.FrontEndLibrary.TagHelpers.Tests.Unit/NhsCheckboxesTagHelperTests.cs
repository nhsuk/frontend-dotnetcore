using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Checkboxes;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsCheckboxesTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private NhsCheckboxesTagHelper _tagHelper;
    private TagHelperContext _tagHelperContext;
    public NhsCheckboxesTagHelperTests()
    {
      _tagHelper = new NhsCheckboxesTagHelper();
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
    public void Process_Should_Set_ClassAttribute()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkCheckboxes, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Can_Add_User_Defined_Classes()
    {
      var passedByUser = "nhs-margin nhs-hidden";
      _tagHelper.Classes = passedByUser;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkCheckboxes + " " + passedByUser, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }
  }
}
