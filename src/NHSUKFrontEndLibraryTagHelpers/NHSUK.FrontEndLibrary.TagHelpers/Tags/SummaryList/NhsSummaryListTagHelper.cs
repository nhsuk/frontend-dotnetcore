using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.SummaryList
{
  [HtmlTargetElement(TagHelperNames.NhsSummaryListTag)]
  [RestrictChildren(TagHelperNames.NhsSummaryListRowTag)]
  public class NhsSummaryListTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.IsWithBorder)]
    public bool IsWithoutBorder { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Dl;

      ClassesToPrepend.Add(IsWithoutBorder ? CssClasses.NhsUkSummaryListWithoutBorder : CssClasses.NhsUkSummaryList);

      UpdateClasses(output);

    }

  }
}