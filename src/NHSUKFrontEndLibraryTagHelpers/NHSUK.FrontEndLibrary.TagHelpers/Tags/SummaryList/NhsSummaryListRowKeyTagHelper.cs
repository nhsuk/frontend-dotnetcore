using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.SummaryList
{
  [HtmlTargetElement(TagHelperNames.NhsSummaryListRowKeyTag, ParentTag = TagHelperNames.NhsSummaryListRowTag)]
  public class NhsSummaryListRowKeyTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Dt;
      ClassesToPrepend.Add(CssClasses.NhsUkSummaryListRowKey);
      UpdateClasses(output);

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);

      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
