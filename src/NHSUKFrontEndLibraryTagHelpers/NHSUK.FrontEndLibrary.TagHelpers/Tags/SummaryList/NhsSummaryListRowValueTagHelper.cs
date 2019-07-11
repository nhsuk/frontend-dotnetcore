using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.SummaryList
{
  [HtmlTargetElement(TagHelperNames.NhsSummaryListRowValueTag, ParentTag = TagHelperNames.NhsSummaryListRowTag)]
  public class NhsSummaryListRowValueTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Dd;
      ClassesToPrepend.Add(CssClasses.NhsUkSummaryListRowValue);
      UpdateClasses(output);

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);

      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
