using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.ErrorMessage
{
  [HtmlTargetElement(TagHelperNames.NhsErrorMessageTag)]
  public class NhsErrorMessageTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      output.TagName = HtmlElements.Span;
      ClassesToPrepend.Add(CssClasses.NhsUkErrorMessage);

      var visuallyHidden = new TagBuilder(HtmlElements.Span);
      visuallyHidden.Attributes.Add(HtmlAttributes.ClassAttribute, CssClasses.NhsUkuVisuallyHidden);
      visuallyHidden.InnerHtml.Append(ContentText.Error);
      output.PreContent.AppendHtml(visuallyHidden);

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);

      UpdateClasses(output);
    }
  }
}