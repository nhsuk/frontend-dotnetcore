using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.DateInput
{
  [HtmlTargetElement(TagHelperNames.NhsDateInputTag)]
  [RestrictChildren(TagHelperNames.NhsDateInputItemTag)]
  public class NhsDateInputTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      ClassesToPrepend.Add(CssClasses.NhsUkDateInput);

      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }

  }
}
