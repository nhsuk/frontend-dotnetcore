using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.WarningCallout
{
  [HtmlTargetElement(TagHelperNames.NhsWarningCalloutTag, Attributes = NhsUkTagHelperAttributes.TitleText)]
  public class NhsWarningCalloutTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.TitleText)]
    public string TitleText { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Div;
      ClassesToPrepend.Add(CssClasses.NhsUkWarningCallout);

      output.PreContent.SetHtmlContent(string.Format("<h3 class=\"nhsuk-warning-callout__label\">{0}</h3>", TitleText));

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);

      UpdateClasses(output);
    }
  }
}