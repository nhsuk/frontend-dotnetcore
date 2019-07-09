using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Details
{
  [HtmlTargetElement(TagHelperNames.NhsExpanderGroupTag)]
  [RestrictChildren(TagHelperNames.NhsDetailsTag)]
  public class NhsExpanderGroupTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      SetClassAttribute(output, CssClasses.NhsUkExpanderGroup);

      output.TagMode = TagMode.StartTagAndEndTag;
    }

  }
}
