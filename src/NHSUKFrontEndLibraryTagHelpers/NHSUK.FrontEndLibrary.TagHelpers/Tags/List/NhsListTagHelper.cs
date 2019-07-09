using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.List
{
  [HtmlTargetElement(TagHelperNames.NhsListTag)]
  [RestrictChildren(HtmlElements.Li, TagHelperNames.NhsListPanelTag)]
  public class NhsListTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.IsOrdered)]
    public bool IsOrdered { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = IsOrdered ? HtmlElements.Ol : HtmlElements.Ul;

      ClassesToPrepend.Add(CssClasses.NhsUkList);
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
