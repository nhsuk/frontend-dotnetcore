using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Promo;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsPromoTagHelperrTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private readonly NhsPromoTagHelper _tagHelper;
    private string titleText = "Give blood";
    private static string description = "please register";
    private string href = "www.nhs.uk";
    private static string imageUrl = "https://assets.nhs.uk/prod/images/S_1017_allergic-conjunctivitis_M15.2e16d0ba.fill-320x213.jpg";
    private readonly string _imageElement = string.Format("<img class=\"nhsuk-promo__img\" src=\"{0}\" alt=\"\">", imageUrl);
    private readonly string _descriptionElement = string.Format("<p class=\"nhsuk-promo__description\">{0}</p>", description);
    public NhsPromoTagHelperrTests()
    {
      _tagHelper = new NhsPromoTagHelper { TitleText = titleText };
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList {
          new TagHelperAttribute("href", new HtmlString(href))
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

      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Theory]
    [InlineData(PromoSize.Standard)]
    [InlineData((PromoSize)(-1))]
    public void Process_Should_Set_Standard_ClassAttribute(PromoSize size)
    {
      _tagHelper.PromoSize = size;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(CssClasses.NhsUkPromo, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_Small_ClassAttribute()
    {
      _tagHelper.PromoSize = PromoSize.Small;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(CssClasses.NhsUkPromoSmall, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Theory]
    [InlineData(GridColumnWidth.Full, CssClasses.NhsUkGridFull)]
    [InlineData(GridColumnWidth.OneHalf, CssClasses.NhsUkGridOneHalf)]
    [InlineData(GridColumnWidth.OneQuarter, CssClasses.NhsUkGridOneQuarter)]
    [InlineData(GridColumnWidth.OneThird, CssClasses.NhsUkGridOneThird)]
    [InlineData(GridColumnWidth.TwoThirds, CssClasses.NhsUkGridTwoThirds)]
    [InlineData(GridColumnWidth.ThreeQuarters, CssClasses.NhsUkGridThreeQuarters)]
    [InlineData((GridColumnWidth)(-1), CssClasses.NhsUkGridFull)]
    public void Process_Should_Set_PromoGroup_PreElement(GridColumnWidth width, string classAttribute)
    {
      _tagHelperContext.Items["ParentColumnWidth"] = width;

      var expected = string.Format("<div class=\"{0} nhsuk-promo-group__item\">", classAttribute);

      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.PreElement.GetContent());
    }

    [Fact]
    public void Process_Should_Not_Set_PreElement_If_No_PromoGroup()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Empty, _tagHelperOutput.PreElement.GetContent());
    }


    [Theory]
    [InlineData(GridColumnWidth.Full)]
    [InlineData(GridColumnWidth.OneHalf)]
    [InlineData(GridColumnWidth.OneQuarter)]
    [InlineData(GridColumnWidth.OneThird)]
    [InlineData(GridColumnWidth.TwoThirds)]
    [InlineData(GridColumnWidth.ThreeQuarters)]
    public void Process_Should_Set_PromoGroup_PostElement(GridColumnWidth width)
    {
      _tagHelperContext.Items["ParentColumnWidth"] = width;

      var expected = "</div>";

      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.PostElement.GetContent());
    }

    [Fact]
    public void Process_Should_Not_Set_PostElement_If_No_PromoGroup()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(string.Empty, _tagHelperOutput.PostElement.GetContent());
    }

    [Fact]
    public void Process_Should_Not_Set_Content_No_Description()
    {
      _tagHelper.ImageUrl = imageUrl;
      var expected = string.Format("<a class=\"nhsuk-promo__link-wrapper\" href=\"{0}\">" + "{1}" +
                                   "<div class=\"nhsuk-promo__content\"><h3 class=\"nhsuk-promo__heading\">" +
                                   "{2}</h3>" +
                                   "</div></a>", href, _imageElement, titleText);
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public void Process_Should_Not_Set_Content_No_Image()
    {
      _tagHelper.DescriptionText = description;
      var expected = string.Format("<a class=\"nhsuk-promo__link-wrapper\" href=\"{0}\">" +
                                   "<div class=\"nhsuk-promo__content\"><h3 class=\"nhsuk-promo__heading\">" +
                                   "{1}</h3>{2}" +
                                   "</div></a>", href, titleText, _descriptionElement);
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

    [Fact]
    public void Process_Should_Not_Set_Content()
    {
      _tagHelper.DescriptionText = description;
      _tagHelper.ImageUrl = imageUrl;
      var expected = string.Format("<a class=\"nhsuk-promo__link-wrapper\" href=\"{0}\">" + "{1}" +
                                   "<div class=\"nhsuk-promo__content\"><h3 class=\"nhsuk-promo__heading\">" +
                                   "{2}</h3>{3}" +
                                   "</div></a>", href, _imageElement, titleText, _descriptionElement);
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

  }
}
