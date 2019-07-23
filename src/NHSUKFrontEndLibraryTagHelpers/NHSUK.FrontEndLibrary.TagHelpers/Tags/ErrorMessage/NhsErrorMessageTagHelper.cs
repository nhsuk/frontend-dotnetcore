using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.ErrorMessage
{
  [HtmlTargetElement("span", Attributes = NhsUkTagHelperAttributes.SpanType)]
  public class NhsErrorMessageTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.SpanType)]
    public SpanType SpanType { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);

      switch (SpanType)
      {
        case SpanType.ErrorMessage:
          ClassesToPrepend.Add(CssClasses.NhsUkErrorMessage);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkErrorMessage);
          break;
      }
    
      var visuallyHidden = new TagBuilder(HtmlElements.Span);
      visuallyHidden.Attributes.Add(HtmlAttributes.ClassAttribute, CssClasses.NhsUkuVisuallyHidden);
      visuallyHidden.InnerHtml.Append(ContentText.Error);
      output.PreContent.AppendHtml(visuallyHidden);

      context.AllAttributes.TryGetAttribute("asp-validation-for", out var entry);
    
      var content = (await output.GetChildContentAsync()).GetContent();
      if (entry == null)
      {
        output.Content.SetHtmlContent(content);
      }
     
      UpdateClasses(output);
    }
  }
}