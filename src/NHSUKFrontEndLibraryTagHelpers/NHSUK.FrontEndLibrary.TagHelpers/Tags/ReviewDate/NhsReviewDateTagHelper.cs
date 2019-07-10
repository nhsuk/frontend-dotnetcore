using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.ReviewDate
{
  [HtmlTargetElement(TagHelperNames.NhsReviewDateTag)]
  public class NhsReviewDateTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.LastReview)]
    public string LastReview { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.NextReview)]
    public string NextReview { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);

      output.TagName = HtmlElements.Div;

      ClassesToPrepend.Add(CssClasses.NhsUkReviewDate);


      UpdateClasses(output);

      output.Content.SetHtmlContent(string.Format("<p class=\"nhsuk-body-s\">Page last reviewed: {0} <br>" +
                                                  "Next review due: {1}</p>", LastReview, NextReview));

    }

  }
}