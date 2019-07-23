using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Anchor;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsAnchorTagHelperTests
  {
    private readonly NhsAnchorTagHelper _tagHelper;
    private const string Text = "Save and continue";
    private TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsAnchorTagHelperTests()
    {

      _tagHelper = new NhsAnchorTagHelper ();
      _tagHelperContext = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
          new TagHelperAttributeList(),
          (result, encoder) =>
          {
            var tagHelperContent = new DefaultTagHelperContent();

            return Task.FromResult(tagHelperContent.SetHtmlContent(Text));
          });
    }

    [Theory]
    [InlineData(AnchorType.Button)]
    [InlineData((AnchorType)(-1))]
    public async void ProcessAsync_Should_Set_Default_Anchor_Type_ClassAttribute(AnchorType type)
    {
      _tagHelper.AnchorType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkButton, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_SkipLink_ClassAttribute()
    {
      _tagHelper.AnchorType = AnchorType.SkipLink;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkSkipLink, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }


    [Fact]
    public async void ProcessAsync_Should_Set_Link_Button_Type_DraggableAttribute()
    {
      _tagHelper.AnchorType = AnchorType.Button;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlAttributes.AttributeValues.False, _tagHelperOutput.Attributes[HtmlAttributes.Draggable].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Link_Button_Type_RoleAttribute()
    {
      _tagHelper.AnchorType = AnchorType.Button;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Button, _tagHelperOutput.Attributes[HtmlAttributes.Role].Value);
    }
    [Fact]
    public async void ProcessAsync_Should_Set_Disabled_Button_Type_AriaDisabledAttribute()
    {
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("disabled", new HtmlString("disabled"))
        },
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));

      _tagHelper.AnchorType = AnchorType.Button;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlAttributes.AttributeValues.True, _tagHelperOutput.Attributes[HtmlAttributes.AriaDisabled].Value);
    }

  }
}
