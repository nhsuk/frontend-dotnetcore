using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Header;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsHeaderNavTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsHeaderNavTagHelperTests()
    {
      var tagHelper = new NhsHeaderNavTagHelper();
      var tagHelperContext = new TagHelperContext(
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

      tagHelper.Process(tagHelperContext, _tagHelperOutput);
    }

    [Fact]
    public void Process_Should_Set_TagName()
    {
      Assert.Equal(HtmlElements.Nav, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_ClassAttribute()
    {
      Assert.Equal(CssClasses.NhsUkHeaderNavigation, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_AriaLabelAttribute()
    {
      Assert.Equal("Primary navigation", _tagHelperOutput.Attributes[HtmlAttributes.AriaLabelAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_IdAttribute()
    {
      Assert.Equal("header-navigation", _tagHelperOutput.Attributes[HtmlAttributes.IdAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_AriaLabelByAttribute()
    {
      Assert.Equal("label-navigation", _tagHelperOutput.Attributes[HtmlAttributes.AriaLabelByAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_RoleAttribute()
    {
      Assert.Equal("navigation", _tagHelperOutput.Attributes[HtmlAttributes.Role].Value);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public void Process_Should_Set_PreContent()
    {
      Assert.Equal(string.Format(
        "<p class=\"nhsuk-header__navigation-title\"><span id=\"label-navigation\">Menu</span> <button class=\"nhsuk-header__navigation-close\" id=\"close-menu\"> " +
        "<svg class=\"nhsuk-icon nhsuk-icon__close\" xmlns=\"http://www.w3.org/2000/svg\"" +
        " viewBox=\"0 0 24 24\" aria-hidden=\"true\" focusable=\"false\"> " +
        "<path d =\"M13.41 12l5.3-5.29a1 1 0 1 0-1.42-1.42L12 10.59l-5.29-5.3a1 1 0 0 0-1.42 1.42l5.3 5.29-5.3 5.29a1 1 0 0 0 0 1.42 1 1 0 0 0 1.42 0l5.29-5.3 5.29 5.3a1 1 0 0 0 1.42 0 1 1 0 0 0 0-1.42z\"> " +
        "</path></svg><span class=\"nhsuk-u-visually-hidden\">Close menu</span></button> </p>" +
        "<ul class=\"nhsuk-header__navigation-list\"> " +
        "<li class=\"nhsuk-header__navigation-item nhsuk-header__navigation-item--for-mobile\"> " +
        "<a class=\"nhsuk-header__navigation-link\" href=\"/\">Home " +
        "<svg class=\"nhsuk-icon nhsuk-icon__chevron-right\" xmlns=\"http://www.w3.org/2000/svg\" " +
        "viewBox=\"0 0 24 24\" aria-hidden=\"true\"> " +
        "<path d=\"M15.5 12a1 1 0 0 1-.29.71l-5 5a1 1 0 0 1-1.42-1.42l4.3-4.29-4.3-4.29a1 1 0 0 1 1.42-1.42l5 5a1 1 0 0 1 .29.71z\">" +
        "</path></svg></a></li>"), _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public void Process_Should_Set_PostContent()
    {
      Assert.Equal("</ul>", _tagHelperOutput.PostContent.GetContent());
    }
  }
}
