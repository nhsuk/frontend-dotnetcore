using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Hero;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit.TagHelpers
{
  public class NhsHeroTagHelperTests
  {
    private TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private string title = "We’re here for you";
    private string url= "https://assets.nhs.uk/prod/images/S_0818_homepage_hero_1_F0147446.width-1000.jpg";
    private const string Text = "Helping you take control of your health and wellbeing.";
    private NhsHeroTagHelper _tagHelper;
    public NhsHeroTagHelperTests()
    {
      _tagHelper = new NhsHeroTagHelper ();
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
      Assert.Equal(HtmlElements.Section, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_ImageOnly_Class_Attribute()
    {
      _tagHelper.ImageUrl = url;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkHeroImage, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Hero_Class_Attribute()
    {
      _tagHelper.TitleText = title;
      _tagHelperOutput = new TagHelperOutput(string.Empty,
        new TagHelperAttributeList(),
        (useCachedResult, encoder) =>
        {
          var tagHelperContent = new DefaultTagHelperContent();
          return Task.FromResult(tagHelperContent.SetHtmlContent(Text));
        });
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkHero, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_HeroContentImage_Class_Attribute()
    {
      _tagHelper.TitleText = title;
      _tagHelper.ImageUrl = url;
      _tagHelperOutput = new TagHelperOutput(string.Empty,
        new TagHelperAttributeList(),
        (useCachedResult, encoder) =>
        {
          var tagHelperContent = new DefaultTagHelperContent();
          return Task.FromResult(tagHelperContent.SetHtmlContent(Text));
        });
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkHeroImageContent, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }


    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_ImageOnly_Content()
    {
      _tagHelper.ImageUrl = url;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("<div class=\"nhsuk-hero__overlay\"></div>", _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Image_StyleAttribute()
    {
      _tagHelper.ImageUrl = url;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("background-image: url('{0}');", url), _tagHelperOutput.Attributes["style"].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Hero_Content()
    {
      _tagHelper.TitleText = title;
      _tagHelperOutput = new TagHelperOutput(string.Empty,
        new TagHelperAttributeList(),
        (useCachedResult, encoder) =>
        {
          var tagHelperContent = new DefaultTagHelperContent();
          return Task.FromResult(tagHelperContent.SetHtmlContent(Text));
        });

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format(
        "<div class=\"nhsuk-width-container nhsuk-hero--border\"><div class=\"nhsuk-grid-row\"><div class=\"nhsuk-grid-column-two-thirds\">" +
        "<div class=\"nhsuk-hero__wrapper\"><h1 class=\"nhsuk-u-margin-bottom-3\">{0}</h1><p class=\"nhsuk-body-l nhsuk-u-margin-bottom-0\">" +
        "{1}</p></div></div></div></div>", title, Text), _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public async void ProcessAsync_Should_Set_HeroImageContent_Content()
    {
      _tagHelper.TitleText = title;
      _tagHelper.ImageUrl = url;
      _tagHelperOutput = new TagHelperOutput(string.Empty,
        new TagHelperAttributeList(),
        (useCachedResult, encoder) =>
        {
          var tagHelperContent = new DefaultTagHelperContent();
          return Task.FromResult(tagHelperContent.SetHtmlContent(Text));
        });

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format(
        "<div class=\"nhsuk-hero__overlay\"><div class=\"nhsuk-width-container\"><div class=\"nhsuk-grid-row\">" +
        "<div class=\"nhsuk-grid-column-two-thirds\"><div class=\"nhsuk-hero-content\"><h1 class=\"nhsuk-u-margin-bottom-3\">" +
        "{0}</h1><p class=\"nhsuk-body-l nhsuk-u-margin-bottom-0\">{1}</p><span class=\"nhsuk-hero__arrow\" aria-hidden=\"true\"></span>" +
        "</div></div></div></div></div>", title, Text), _tagHelperOutput.Content.GetContent());
    }



  }
}
