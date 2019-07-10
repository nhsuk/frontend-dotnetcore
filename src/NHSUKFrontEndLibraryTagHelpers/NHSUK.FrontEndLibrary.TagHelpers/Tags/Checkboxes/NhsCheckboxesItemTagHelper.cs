using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Checkboxes
{
  [HtmlTargetElement(TagHelperNames.NhsCheckboxesItemTag, ParentTag = TagHelperNames.NhsCheckboxesTag)]
  public class NhsCheckboxesItemTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      SetClassAttribute(output, CssClasses.NhsUkCheckboxesItem);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
