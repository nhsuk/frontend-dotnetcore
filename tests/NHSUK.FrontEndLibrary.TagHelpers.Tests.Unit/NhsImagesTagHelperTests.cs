using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Images;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsImagesTagHelperTests
  {
    private TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private string caption = "Itchy, red, watering eyes";
    private string alt = "Picture of allergic conjunctivitis";
    private string src= "https://assets.nhs.uk/prod/images/S_1017_allergic-conjunctivitis_M15.2e16d0ba.fill-320x213.jpg";
    private NhsImagesTagHelper _tagHelper;
    public NhsImagesTagHelperTests()
    {
      _tagHelper = new NhsImagesTagHelper();
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList {
          new TagHelperAttribute("src", src),
          new TagHelperAttribute("alt", alt)
        },
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
      Assert.Equal(HtmlElements.Figure, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_Class_Attribute()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkImages, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

   [Fact]
    public void Process_Should_Set_Caption_Content()
    {
      _tagHelper.Caption = caption;
      var captionHtml = string.Format("<figcaption class=\"nhsuk-image__caption\">{0}</figcaption>", caption);
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<img class=\"nhsuk-image__img\"" +
                                 " src=\"{0}\" alt=\"{1}\">{2}", src, alt, captionHtml), _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public void Process_Should_Set_Content()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(string.Format("<img class=\"nhsuk-image__img\"" +
                                 " src=\"{0}\" alt=\"{1}\">", src, alt), _tagHelperOutput.Content.GetContent());
    }

  }
}
