using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Button;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsButtonTagHelperTests
  {
    private readonly NhsButtonTagHelper _tagHelper;
    private const string Text = "Save and continue";
    private TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsButtonTagHelperTests()
    {

      _tagHelper = new NhsButtonTagHelper { ButtonType = ButtonType.Standard };
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
    
    [Fact]
    public async void ProcessAsync_Should_Set_Standard_Button_Type_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkButton, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Reverse_Button_Type_ClassAttribute()
    {
      _tagHelper.ButtonType = ButtonType.Reverse;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkButtonReverse, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Secondary_Button_Type_ClassAttribute()
    {
      _tagHelper.ButtonType = ButtonType.Secondary;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkButtonSecondary, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Default_Button_Type_ClassAttribute()
    {
      _tagHelper.ButtonType = (ButtonType)(-1);
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkButton, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);

    }

   
    [Fact]
    public async void ProcessAsync_Should_Set_Disabled_Button_Type_AriaDisabledAttribute()
    {
      _tagHelper.ButtonType = ButtonType.Secondary;
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("disabled", new HtmlString("disabled"))
        },
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));


      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlAttributes.AttributeValues.True, _tagHelperOutput.Attributes[HtmlAttributes.AriaDisabled].Value);
    }

   [Fact]
    public async void ProcessAsync_Should_Set_DisabledAttributes()
    {
      _tagHelper.ButtonType = ButtonType.Secondary;
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("disabled", new HtmlString("disabled"))
        },
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));
        
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("{0} {1}", CssClasses.NhsUkButtonSecondary, CssClasses.NhsUkButtonDisabled), _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Theory]
    [InlineData(ButtonType.Standard)]
    [InlineData(ButtonType.Reverse)]
    [InlineData(ButtonType.Secondary)]
    public async void ProcessAsync_Should_Set_TypeAttribute(ButtonType buttonType)
    {
      _tagHelper.ButtonType = buttonType;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlAttributes.AttributeValues.Submit, _tagHelperOutput.Attributes[HtmlAttributes.Type].Value);
    }

  }
}
