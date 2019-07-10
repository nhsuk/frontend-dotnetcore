using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Details
{
  [HtmlTargetElement(TagHelperNames.NhsDetailsTag,
    Attributes = NhsUkTagHelperAttributes.DetailsType + "," + NhsUkTagHelperAttributes.DisplayText)]
  public class NhsDetailsTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.DetailsType)]
    public DetailsType DetailsType { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.DisplayText)]
    public string DisplayText { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Details;

      switch (DetailsType)
      {
        case DetailsType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkDetails);
          break;
        case DetailsType.Expander:
          ClassesToPrepend.Add(CssClasses.NhsUkExpander);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkDetails);
          break;
      }

      output.PreContent.SetHtmlContent(
      string.Format("<summary class=\"nhsuk-details__summary\">" +
                    "<span class=\"nhsuk-details__summary-text\">" +
                    "{0}</span></summary><div class=\"nhsuk-details__text\">", DisplayText));

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);
      output.PostContent.SetHtmlContent("</div>");
      UpdateClasses(output);
    }
  }
}