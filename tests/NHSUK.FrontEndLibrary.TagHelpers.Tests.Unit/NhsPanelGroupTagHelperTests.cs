using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Panel;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsPanelGroupTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly TagHelperContext _tagHelperContext;
    private readonly NhsPanelGroupTagHelper _tagHelper;

    public NhsPanelGroupTagHelperTests()
    {
      _tagHelper = new NhsPanelGroupTagHelper();
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
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
    }

    [Fact]
    public void Process_Should_Set_TagName()
    {
      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_ClassAttribute()
    {
      Assert.Equal(CssClasses.NhsUkPanelGroup, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public void Process_Should_Set_ParentType_Context()
    {
      Assert.Equal(_tagHelperContext.Items["Parent"], TagHelperNames.NhsPanelGroupTag);
    }

  }
}
