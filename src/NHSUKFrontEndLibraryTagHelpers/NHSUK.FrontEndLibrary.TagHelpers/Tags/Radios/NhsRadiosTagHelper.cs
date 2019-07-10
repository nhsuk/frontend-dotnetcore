using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Radios
{
  [HtmlTargetElement(TagHelperNames.NhsRadiosTag, Attributes = NhsUkTagHelperAttributes.RadiosType)]
  [RestrictChildren(TagHelperNames.NhsRadiosItemTag, TagHelperNames.NhsRadiosDividerTag)]
  public class NhsRadiosTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.RadiosType)]
    public RadiosType RadiosType { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;

      switch (RadiosType)
      {
       case RadiosType.Inline:
         ClassesToPrepend.Add(CssClasses.NhsUkRadiosInline);
          break;
        case RadiosType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkRadios);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkRadios);
          break;
      }

      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
