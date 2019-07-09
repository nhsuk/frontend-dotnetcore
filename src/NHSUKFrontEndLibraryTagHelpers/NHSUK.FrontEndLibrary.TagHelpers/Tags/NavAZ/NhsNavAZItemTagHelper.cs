using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.NavAZ
{
  [HtmlTargetElement(TagHelperNames.NhsNavAzItemTag, ParentTag = TagHelperNames.NhsNavAzTag)]
  public class NhsNavAzItemTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(HtmlAttributes.Disabled)]
    public bool Disabled { get; set; }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Li;
      SetClassAttribute(output, CssClasses.NhsUkNavAzItem);

      if (Disabled)
      {
        output.Content.SetHtmlContent(string.Format(
          "<span class=\"nhsuk-nav-a-z__link--disabled\">{0}</span>", content));
      }
      else
      {
        output.Content.SetHtmlContent(string.Format(
          "<a class=\"nhsuk-nav-a-z__link\" href=\"#{0}\">{0}</a>", content));
      }

      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
