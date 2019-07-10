using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.DateInput
{
  [HtmlTargetElement(TagHelperNames.NhsDateInputItemTag, ParentTag = TagHelperNames.NhsDateInputTag)]
  public class NhsDateInputItemTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      SetClassAttribute(output, CssClasses.NhsUkDateInputItem);
      output.TagMode = TagMode.StartTagAndEndTag;

    }
  }
}
