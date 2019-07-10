using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Checkboxes
{
  [HtmlTargetElement(TagHelperNames.NhsCheckboxesTag)]
  [RestrictChildren(TagHelperNames.NhsCheckboxesItemTag)]
  public class NhsCheckboxesTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      ClassesToPrepend.Add(CssClasses.NhsUkCheckboxes);
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
