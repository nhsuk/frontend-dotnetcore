using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.NavAZ;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsNavAzTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly TagHelperContext _tagHelperContext;
    private readonly NhsNavAzTagHelper _tagHelper;
    public NhsNavAzTagHelperTests()
    {
      _tagHelper = new NhsNavAzTagHelper();
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
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Nav, _tagHelperOutput.TagName);
    }

    [Theory]
    [InlineData(HtmlAttributes.ClassAttribute)]
    [InlineData(HtmlAttributes.IdAttribute)]
    public async void ProcessAsync_Should_Set_Attribute(string attribute)
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkNavAz, _tagHelperOutput.Attributes[attribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_RoleAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlAttributes.AttributeValues.Navigation, _tagHelperOutput.Attributes[HtmlAttributes.Role].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_AriaLabelAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("A to Z Navigation", _tagHelperOutput.Attributes[HtmlAttributes.AriaLabelAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PreContent()
    {
      var expected = "<ol class=\"nhsuk-nav-a-z__list\" role=\"list\">";
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_PostContent()
    {
      var expected = "</ol>";
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(expected, _tagHelperOutput.PostContent.GetContent());
    }

  }
}
