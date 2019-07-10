using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.SkipLink
{
  [HtmlTargetElement(TagHelperNames.NhsSkipLinkTag)]
  public class NhsSkipLinkTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.A;

      var content = (await output.GetChildContentAsync()).GetContent();

      ClassesToPrepend.Add(CssClasses.NhsUkSkipLink);

      output.Content.SetHtmlContent(content);

      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
