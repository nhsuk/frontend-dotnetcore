using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Hint
{
  [HtmlTargetElement(TagHelperNames.NhsHintTag, 
    Attributes = NhsUkTagHelperAttributes.HintType)]
  public class NhsHintTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.HintType)]
    public HintType HintType { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Span;

      switch (HintType)
      {
        case HintType.Checkboxes:
          ClassesToPrepend.Add(CssClasses.NhsUkHintCheckboxes);
          break;
        case HintType.Radios:
          ClassesToPrepend.Add(CssClasses.NhsUkHintRadios);
          break;
        case HintType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkHint);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkHint);
          break;
      }

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);
      UpdateClasses(output);
    }
  }
}
