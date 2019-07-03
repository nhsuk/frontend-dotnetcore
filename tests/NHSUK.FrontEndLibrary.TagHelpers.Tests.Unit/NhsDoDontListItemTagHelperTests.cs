using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.DoDontList;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit.TagHelpers
{
  public class NhsDoDontListItemTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private readonly NhsDoDontListItemTagHelper _tagHelper;
    private const string Text = "wash your hands";
    public NhsDoDontListItemTagHelperTests()
    {
      _tagHelper = new NhsDoDontListItemTagHelper();
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList(),
        new Dictionary<object, object>
        {
          {"ParentType", DoDontListType.Do}
        },
        Guid.NewGuid().ToString("N"));

      _tagHelperOutput = new TagHelperOutput(string.Empty,
         new TagHelperAttributeList(),
         (useCachedResult, encoder) =>
         {
           var tagHelperContent = new DefaultTagHelperContent();
           return Task.FromResult(tagHelperContent.SetHtmlContent(Text));
         });
     }

    [Fact]
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(HtmlElements.Li, _tagHelperOutput.TagName);
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
    public async void ProcessAsync_Should_Set_Do_Content(DoDontListType type)
    {
      _tagHelperContext.Items["ParentType"] = type;

      var expected = "<svg class=\"nhsuk-icon nhsuk-icon__tick\" xmlns=\"http://www.w3.org/2000/svg\"" +
                     " viewBox=\"0 0 24 24\" fill=\"none\" aria-hidden=\"true\"><path stroke-width=\"4\"" +
                     " stroke-linecap=\"round\" d=\"M18.4 7.8l-8.5 8.4L5.6 12\"></path></svg>" + Text;

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Dont_Content()
    {
      _tagHelperContext.Items["ParentType"] = DoDontListType.Dont;

      var expected = "<svg class=\"nhsuk-icon nhsuk-icon__cross\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\"" +
                     " aria-hidden=\"true\"><path d=\"M17 18.5c-.4 0-.8-.1-1.1-.4l-10-10c-.6-.6-.6-1.6 0-2.1.6-.6 1.5-.6 2.1 0l10 10c.6.6.6 1.5 0 2.1-.3.3-.6.4-1 .4z\">" +
                     "</path><path d=\"M7 18.5c-.4 0-.8-.1-1.1-.4-.6-.6-.6-1.5 0-2.1l10-10c.6-.6 1.5-.6 2.1 0 .6.6.6 1.5 0 2.1l-10 10c-.3.3-.6.4-1 .4z\"></path></svg>" + Text;

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }


  }
}
