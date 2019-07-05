using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.DoDontList;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsDoDontListTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly TagHelperContext _tagHelperContext;
    private readonly NhsDoDontListTagHelper _tagHelper;

    public NhsDoDontListTagHelperTests()
    {
      _tagHelper = new NhsDoDontListTagHelper();
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

      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(CssClasses.NhsUkDoDontList, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Theory]
    [InlineData(DoDontListType.Do)]
    [InlineData((DoDontListType)(-1))]
    public async void ProcessAsync_Should_Set_Do_PreContent(DoDontListType type)
    {
      _tagHelper.DoDontListType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Format("<h3 class=\"nhsuk-do-dont-list__label\">Do</h3>" +
                   "<ul class=\"{0}\">", CssClasses.NhsUkListTick), _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Dont_PreContent()
    {
      _tagHelper.DoDontListType = DoDontListType.Dont;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Format("<h3 class=\"nhsuk-do-dont-list__label\">Don't</h3>" +
                                 "<ul class=\"{0}\">", CssClasses.NhsUkListCross), _tagHelperOutput.PreContent.GetContent());
    }

    [Theory]
    [InlineData(DoDontListType.Do)]
    [InlineData(DoDontListType.Dont)]
    public async void ProcessAsync_Should_Set_ParentType_Context(DoDontListType type)
    {
      _tagHelper.DoDontListType = type;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(_tagHelperContext.Items["ParentType"], _tagHelper.DoDontListType);
    }


    [Fact]
    public async void ProcessAsync_Should_Set_PostContent()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal("</ul>", _tagHelperOutput.PostContent.GetContent());
    }

  }
}
