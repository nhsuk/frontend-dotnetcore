using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Actionlink;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsActionLinkTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private const string Text = "Find a minor injuries unit";
    private const string Href = "https://www.nhs.uk/news/";
    private NhsActionLinkTagHelper _tagHelper;
    public NhsActionLinkTagHelperTests()
    {
      _tagHelper = new NhsActionLinkTagHelper();
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList
        {
          new TagHelperAttribute("href", new HtmlString(Href))
        },
          new Dictionary<object, object>(),
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
      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_ClassAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkActionLink, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TargetAttribute_If_OpenInNewWindow_True()
    {
      _tagHelper.OpenInNewWindow = true;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("_blank", _tagHelperOutput.Attributes["target"].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Not_Set_TargetAttribute_If_OpenInNewWindow_False()
    {
      _tagHelper.OpenInNewWindow = false;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.False(_tagHelperOutput.Attributes.ContainsName("target"));
    }


    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Content()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<a class=\"nhsuk-action-link__link\" href=\"{0}\">" +
                                 "<svg class=\"nhsuk-icon nhsuk-icon__arrow-right-circle\" " +
                                 "xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" " +
                                 "aria-hidden=\"true\"><path d=\"M0 0h24v24H0z\" fill=\"none\">" +
                                 "</path><path d=\"M12 2a10 10 0 0 0-9.95 9h11.64L9.74 7.05a1 1 0" +
                                 " 0 1 1.41-1.41l5.66 5.65a1 1 0 0 1 0 1.42l-5.66 5.65a1 1 0 0 " +
                                 "1-1.41 0 1 1 0 0 1 0-1.41L13.69 13H2.05A10 10 0 1 0 12 2z\" >" +
                                 "</path ></svg ><span class=\"nhsuk-action-link__text\">{1}</span></a>",
        Href, Text), _tagHelperOutput.Content.GetContent());
    }
    
  }
}
