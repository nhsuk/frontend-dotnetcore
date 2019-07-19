using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.TextArea;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsTextAreaTagHelperTests
  {
    private readonly NhsTextAreaTagHelper _tagHelper;
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly TagHelperContext _tagHelperContext;
    public NhsTextAreaTagHelperTests()
    {
      _tagHelper = new NhsTextAreaTagHelper { TextAreaType = TextAreaType.Standard};
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
    [InlineData(TextAreaType.Standard)]
    [InlineData((TextAreaType)(-1))]
    public void Process_Should_Set_Standard_TextArea_Type_ClassAttribute(TextAreaType type)
    {
      _tagHelper.TextAreaType = type;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkTextArea, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_Error_TextArea_Type_ClassAttribute()
    {
      _tagHelper.TextAreaType = TextAreaType.Error;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkTextAreaError, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

  }
}
