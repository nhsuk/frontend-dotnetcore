using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Table
{
  [HtmlTargetElement(TagHelperNames.NhsTableBodyTag, ParentTag = TagHelperNames.NhsTableTag)]
  [RestrictChildren(TagHelperNames.NhsTableBodyRowTag)]
  public class NhsTableBodyTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      output.TagName = HtmlElements.Tbody;
      SetClassAttribute(output, CssClasses.NhsUkTableBody);

      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
