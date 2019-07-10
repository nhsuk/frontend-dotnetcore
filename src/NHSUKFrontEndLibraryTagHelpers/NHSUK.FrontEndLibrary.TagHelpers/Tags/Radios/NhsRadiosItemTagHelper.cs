using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Radios
{
  [HtmlTargetElement(TagHelperNames.NhsRadiosItemTag, 
    ParentTag = TagHelperNames.NhsRadiosTag)]
  public class NhsRadiosItemTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      SetClassAttribute(output, CssClasses.NhsUkRadiosItem);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
