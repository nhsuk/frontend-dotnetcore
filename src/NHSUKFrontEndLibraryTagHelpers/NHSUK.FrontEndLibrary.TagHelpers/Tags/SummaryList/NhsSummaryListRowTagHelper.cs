using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.SummaryList
{
  [HtmlTargetElement(TagHelperNames.NhsSummaryListRowTag, ParentTag = TagHelperNames.NhsSummaryListTag)]
  [RestrictChildren(TagHelperNames.NhsSummaryListRowActionsTag, TagHelperNames.NhsSummaryListRowKeyTag,
    TagHelperNames.NhsSummaryListRowValueTag)]
  public class NhsSummaryListRowTagHelper : NhsBaseTagHelper
  {
   public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      SetClassAttribute(output, CssClasses.NhsUkSummaryListRow);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
