using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Select;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsSelectTagHelperTests
  {
    private readonly NhsSelectTagHelper _tagHelper;
    private readonly TagHelperContext _tagHelperContext;
    private readonly TagHelperOutput _tagHelperOutput;
    public NhsSelectTagHelperTests()
    {

      _tagHelper = new NhsSelectTagHelper { SelectType = SelectType.Standard };
      _tagHelperContext = new TagHelperContext(
            new TagHelperAttributeList(),
            new Dictionary<object, object>(),
            Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
          new TagHelperAttributeList(),
          (result, encoder) =>
          {
            var tagHelperContent = new DefaultTagHelperContent();

            return Task.FromResult<TagHelperContent>(tagHelperContent);
          });
    }

    [Theory]
    [InlineData(SelectType.Standard)]
    [InlineData((SelectType)(-1))]
    public async void ProcessAsync_Should_Set_Standard_Hint_Type_ClassAttribute(SelectType type)
    {
      _tagHelper.SelectType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkSelect, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Error_Select_Type_ClassAttribute()
    {
      _tagHelper.SelectType = SelectType.Error;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkSelectError, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }
    
  }
}
