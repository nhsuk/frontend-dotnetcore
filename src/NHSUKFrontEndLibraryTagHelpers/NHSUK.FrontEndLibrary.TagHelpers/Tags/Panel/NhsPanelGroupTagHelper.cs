using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Panel
{
  [HtmlTargetElement(TagHelperNames.NhsPanelGroupTag)]
  [RestrictChildren(TagHelperNames.NhsPanelTag)]
  public class NhsPanelGroupTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.TagName = HtmlElements.Div;
      SetClassAttribute(output, CssClasses.NhsUkPanelGroup);

      output.TagMode = TagMode.StartTagAndEndTag;

      context.Items["Parent"] = TagHelperNames.NhsPanelGroupTag;
    }

  }
}
