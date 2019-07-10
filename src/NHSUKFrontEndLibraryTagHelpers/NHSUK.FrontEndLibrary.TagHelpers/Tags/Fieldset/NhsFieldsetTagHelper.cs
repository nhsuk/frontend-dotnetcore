using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Fieldset
{
  [HtmlTargetElement(TagHelperNames.NhsFieldsetTag)]
  public class NhsFieldsetTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Fieldset;
      ClassesToPrepend.Add(CssClasses.NhsUkFieldset);
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
