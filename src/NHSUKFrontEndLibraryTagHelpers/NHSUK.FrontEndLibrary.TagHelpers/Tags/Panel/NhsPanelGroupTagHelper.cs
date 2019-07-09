using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Panel
{
  [HtmlTargetElement(TagHelperNames.NhsPanelGroupTag, Attributes = NhsUkTagHelperAttributes.GridColumnWidth)]
  [RestrictChildren(TagHelperNames.NhsPanelTag)]
  public class NhsPanelGroupTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.GridColumnWidth)]
    public GridColumnWidth GridColumnWidth { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      SetClassAttribute(output, CssClasses.NhsUkPanelGroup);

      output.TagMode = TagMode.StartTagAndEndTag;

      context.Items["ParentColumnWidth"] = GridColumnWidth;
    }

  }
}
