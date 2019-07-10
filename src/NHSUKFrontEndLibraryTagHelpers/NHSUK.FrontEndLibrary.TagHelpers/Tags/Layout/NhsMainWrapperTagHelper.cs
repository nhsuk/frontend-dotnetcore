using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Layout
{
  [HtmlTargetElement(TagHelperNames.NhsMainWrapperTag)]
  public class NhsMainWrapperTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    { 
      base.Process(context, output);
    output.TagName = HtmlElements.Main;

      ClassesToPrepend.Add(CssClasses.NhsUkMainWrapper);
      SetAttribute(output, HtmlAttributes.IdAttribute, HtmlAttributes.AttributeValues.MainContent);
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
