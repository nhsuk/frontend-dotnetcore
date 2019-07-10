using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.InsetText
{
  [HtmlTargetElement(TagHelperNames.NhsInsetTextTag)]
  public class NhsInsetTextTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Div;
      ClassesToPrepend.Add(CssClasses.NhsUkInsetText);

      var visuallyHidden = new TagBuilder(HtmlElements.Span);
      visuallyHidden.Attributes.Add(HtmlAttributes.ClassAttribute, CssClasses.NhsUkuVisuallyHidden);
      visuallyHidden.InnerHtml.Append("Information: ");
      output.PreContent.AppendHtml(visuallyHidden);

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);

      UpdateClasses(output);
    }
  }
}