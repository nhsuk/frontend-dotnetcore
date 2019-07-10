using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Layout
{
  [HtmlTargetElement(TagHelperNames.NhsGridRowTag)]
  public class NhsGridRowTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;
      ClassesToPrepend.Add(CssClasses.NhsUkGridRow);
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
