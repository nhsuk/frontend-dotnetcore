using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Pagination;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsPaginationTagHelperTests
  {
    private TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private NhsPaginationTagHelper _tagHelper;
    private string prevUrl = "/prev";
    private string nextUrl = "/next";
    private string prevLinkText = "Causes";
    private string nextLinkText = "Symptoms";
    public NhsPaginationTagHelperTests()
    {
      _tagHelper = new NhsPaginationTagHelper();
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
    public void Process_Should_Set_TagName()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Nav, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_Class_Attribute()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkPagination, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_Role_Attribute()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlAttributes.AttributeValues.Navigation, _tagHelperOutput.Attributes[HtmlAttributes.Role].Value);
    }

    [Fact]
    public void Process_Should_Set_AriaLabel_Attribute()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("Pagination", _tagHelperOutput.Attributes[HtmlAttributes.AriaLabelAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public void Process_Should_Set_PreContent()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("<ul class=\"nhsuk-list nhsuk-pagination__list\">", _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public void Process_Should_Set_NextPageContent()
    {
      _tagHelper.NextUrl = nextUrl;
      _tagHelper.NextLinkText = nextLinkText;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<li class=\"nhsuk-pagination-item--next\"><a class=\"nhsuk-pagination__link nhsuk-pagination__link--next\"" +
                                 " href=\"{0}\"><span class=\"nhsuk-pagination__title\">Next</span><span class=\"nhsuk-u-visually-hidden\">:</span>" +
                                 "<span class=\"nhsuk-pagination__page\">{1}</span><svg class=\"nhsuk-icon nhsuk-icon__arrow-right\" xmlns=\"http://www.w3.org/2000/svg\"" +
                                 " viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M19.6 11.66l-2.73-3A.51.51 0 0 0 16 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0" +
                                 " 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z\"></path></svg></a></li>", nextUrl, nextLinkText), _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public void Process_Should_Set_PreviousPageContent()
    {
      _tagHelper.PreviousLinkText = prevLinkText;
      _tagHelper.PreviousUrl = prevUrl;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<li class=\"nhsuk-pagination-item--previous\"><a class=\"nhsuk-pagination__link nhsuk-pagination__link--prev\"" +
                                 " href=\"{0}\"><span class=\"nhsuk-pagination__title\">Previous</span><span class=\"nhsuk-u-visually-hidden\">:</span>" +
                                 "<span class=\"nhsuk-pagination__page\">{1}</span><svg class=\"nhsuk-icon nhsuk-icon__arrow-left\" " +
                                 "xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M4.1 12.3l2.7 3c.2.2.5.2.7 0" +
                                 " .1-.1.1-.2.1-.3v-2h11c.6 0 1-.4 1-1s-.4-1-1-1h-11V9c0-.2-.1-.4-.3-.5h-.2c-.1 0-.3.1-.4.2l-2.7 3c0 .2 0 .4.1.6z\">" +
                                 "</path></svg></a></li>", prevUrl, prevLinkText), _tagHelperOutput.Content.GetContent());
    }


    [Fact]
    public void Process_Should_Set_Content()
    {
      _tagHelper.NextUrl = nextUrl;
      _tagHelper.NextLinkText = nextLinkText;
      _tagHelper.PreviousLinkText = prevLinkText;
      _tagHelper.PreviousUrl = prevUrl;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<li class=\"nhsuk-pagination-item--previous\"><a class=\"nhsuk-pagination__link nhsuk-pagination__link--prev\"" +
        " href=\"{0}\"><span class=\"nhsuk-pagination__title\">Previous</span><span class=\"nhsuk-u-visually-hidden\">:</span>" +
        "<span class=\"nhsuk-pagination__page\">{1}</span><svg class=\"nhsuk-icon nhsuk-icon__arrow-left\" " +
        "xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M4.1 12.3l2.7 3c.2.2.5.2.7 0" +
        " .1-.1.1-.2.1-.3v-2h11c.6 0 1-.4 1-1s-.4-1-1-1h-11V9c0-.2-.1-.4-.3-.5h-.2c-.1 0-.3.1-.4.2l-2.7 3c0 .2 0 .4.1.6z\">" +
        "</path></svg></a></li><li class=\"nhsuk-pagination-item--next\"><a class=\"nhsuk-pagination__link nhsuk-pagination__link--next\"" +
        " href=\"{2}\"><span class=\"nhsuk-pagination__title\">Next</span><span class=\"nhsuk-u-visually-hidden\">:</span>" +
        "<span class=\"nhsuk-pagination__page\">{3}</span><svg class=\"nhsuk-icon nhsuk-icon__arrow-right\" xmlns=\"http://www.w3.org/2000/svg\"" +
        " viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M19.6 11.66l-2.73-3A.51.51 0 0 0 16 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0" +
        " 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z\"></path></svg></a></li>", prevUrl, prevLinkText, nextUrl, nextLinkText), _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public void Process_Should_Set_PostContent()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("</ul>", _tagHelperOutput.PostContent.GetContent());
    }


  }
}
