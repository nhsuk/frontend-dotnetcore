using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Radios
{
  [HtmlTargetElement(TagHelperNames.NhsRadiosDividerTag, 
    ParentTag = TagHelperNames.NhsRadiosTag)]
  public class NhsRadiosDividerTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.TagName = HtmlElements.Div;

      SetClassAttribute(output, CssClasses.NhsUkRadiosDivider);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
