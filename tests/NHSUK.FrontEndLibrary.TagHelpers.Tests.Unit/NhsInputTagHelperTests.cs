using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Input;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsInputTagHelperTests
  {
    private readonly NhsInputTagHelper _tagHelper;
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly TagHelperContext _tagHelperContext;
    public NhsInputTagHelperTests()
    {
      _tagHelper = new NhsInputTagHelper {InputType = InputType.Standard};
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

    [Theory]
    [InlineData(InputType.Standard)]
    [InlineData((InputType)(-1))]
    public void Process_Should_Set_Standard_Input_Type_ClassAttribute(InputType type)
    {
      _tagHelper.InputType = type;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkInput, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_Checkboxes_Input_Type_ClassAttribute()
    {
      _tagHelper.InputType = InputType.Checkboxes;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkInputCheckboxes, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_Radios_Input_Type_ClassAttribute()
    {
      _tagHelper.InputType = InputType.Radios;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkInputRadios, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_Date_Input_Type_ClassAttribute()
    {
      _tagHelper.InputType = InputType.Date;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkInputDate, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_Date_Input_Type_Pattern()
    {
      _tagHelper.InputType = InputType.Date;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("[0-9]*", _tagHelperOutput.Attributes["pattern"].Value);
    }

    [Fact]
    public void Process_Should_Set_Date_Input_Type_Number_type()
    {
      _tagHelper.InputType = InputType.Date;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlAttributes.AttributeValues.Number, _tagHelperOutput.Attributes[HtmlAttributes.Type].Value);
    }


    [Fact]
    public void Process_Should_Set_IsError_ClassAttribute()
    {
      _tagHelper.IsErrorInput = true;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkInput + " " + CssClasses.NhsUkInputErrorMessage, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_Width2_Input_Type_ClassAttribute()
    {
      _tagHelper.InputWidth = InputWidth.Two;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("{0} {1}", CssClasses.NhsUkInput, CssClasses.NhsUkInputWidth2), _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);

    }

    [Fact]
    public void Process_Should_Set_Width3_Input_Type_ClassAttribute()
    {
      _tagHelper.InputWidth = InputWidth.Three;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("{0} {1}", CssClasses.NhsUkInput, CssClasses.NhsUkInputWidth3), _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);

    }

    [Fact]
    public void Process_Should_Set_Width4_Input_Type_ClassAttribute()
    {
      _tagHelper.InputWidth = InputWidth.Four;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("{0} {1}", CssClasses.NhsUkInput, CssClasses.NhsUkInputWidth4), _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);

    }

    [Fact]
    public void Process_Should_Set_Width5_Input_Type_ClassAttribute()
    {
      _tagHelper.InputWidth = InputWidth.Five;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("{0} {1}", CssClasses.NhsUkInput, CssClasses.NhsUkInputWidth5), _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);

    }

    [Fact]
    public void Process_Should_Set_Width10_Input_Type_ClassAttribute()
    {
      _tagHelper.InputWidth = InputWidth.Ten;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("{0} {1}", CssClasses.NhsUkInput, CssClasses.NhsUkInputWidth10), _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);

    }

    [Fact]
    public void Process_Should_Set_Width20_Input_Type_ClassAttribute()
    {
      _tagHelper.InputWidth = InputWidth.Twenty;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("{0} {1}", CssClasses.NhsUkInput, CssClasses.NhsUkInputWidth20), _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);

    }

  }
}
