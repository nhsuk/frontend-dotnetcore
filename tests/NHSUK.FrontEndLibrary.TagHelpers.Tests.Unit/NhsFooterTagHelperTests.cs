using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Footer;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsFooterTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly TagHelperContext _tagHelperContext;
    private readonly NhsFooterTagHelper _tagHelper;

    public NhsFooterTagHelperTests()
    {
       _tagHelper = new NhsFooterTagHelper();
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

      Assert.Equal(HtmlElements.Footer, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_RoleAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(HtmlAttributes.AttributeValues.ContentInfo, _tagHelperOutput.Attributes[HtmlAttributes.Role].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content_Is_List_Column()
    {
      _tagHelper.IsListColumn = true;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Format("<div class=\"nhsuk-footer\" id=\"nhsuk-footer\"><div class=\"nhsuk-width-container\"><h2 class=\"nhsuk-u-visually-hidden\">Support links</h2><ul class=\"{0}\"></ul>" +
                                 "<p class=\"nhsuk-footer__copyright\">&copy; Crown copyright</p></div></div>", CssClasses.NhsUkFooterListColumn),
        _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      _tagHelper.IsListColumn = false;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Format("<div class=\"nhsuk-footer\" id=\"nhsuk-footer\"><div class=\"nhsuk-width-container\"><h2 class=\"nhsuk-u-visually-hidden\">Support links</h2><ul class=\"{0}\"></ul>" +
                                 "<p class=\"nhsuk-footer__copyright\">&copy; Crown copyright</p></div></div>", CssClasses.NhsUkFooterList),
        _tagHelperOutput.Content.GetContent());
    }

  }
}
