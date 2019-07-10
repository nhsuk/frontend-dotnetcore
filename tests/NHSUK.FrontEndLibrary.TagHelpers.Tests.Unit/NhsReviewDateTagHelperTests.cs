using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.ReviewDate;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsReviewDateTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private readonly NhsReviewDateTagHelper _tagHelper;
    private string lastReview = "1 August 2018";
    private string nextReview = "20 October 2019";
    public NhsReviewDateTagHelperTests()
    {
      _tagHelper = new NhsReviewDateTagHelper { LastReview = lastReview, NextReview = nextReview };
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

      Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Fact]
    public void Process_Should_Set_ClassAttribute()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(CssClasses.NhsUkReviewDate, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }


    [Fact]
    public void Process_Should_Not_Set_Content()
    {
      var expected = string.Format("<p class=\"nhsuk-body-s\">Page last reviewed: {0} <br>" +
                                   "Next review due: {1}</p>", lastReview, nextReview);

      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);

      Assert.Equal(expected, _tagHelperOutput.Content.GetContent());
    }

  }
}
