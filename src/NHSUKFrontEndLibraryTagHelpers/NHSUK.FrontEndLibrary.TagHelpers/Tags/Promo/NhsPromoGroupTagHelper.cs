using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Promo
{
  [HtmlTargetElement(TagHelperNames.NhsPromoGroupTag, Attributes = NhsUkTagHelperAttributes.GridColumnWidth)]
  [RestrictChildren(TagHelperNames.NhsPromoTag)]
  public class NhsPromoGroupTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.GridColumnWidth)]
    public GridColumnWidth GridColumnWidth { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      SetClassAttribute(output, CssClasses.NhsUkPromoGroup);

      output.TagMode = TagMode.StartTagAndEndTag;

      context.Items["ParentColumnWidth"] = GridColumnWidth;
    }

  }
}
