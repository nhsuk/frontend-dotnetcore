using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.NavAZ
{
  [HtmlTargetElement(TagHelperNames.NhsNavAzTag)]
  [RestrictChildren(TagHelperNames.NhsNavAzItemTag)]
  public class NhsNavAzTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Nav;
      var content = (await output.GetChildContentAsync()).GetContent();
      ClassesToPrepend.Add(CssClasses.NhsUkNavAz);
      UpdateClasses(output);
      SetAttribute(output, HtmlAttributes.Role, HtmlAttributes.AttributeValues.Navigation);
      SetAttribute(output, HtmlAttributes.AriaLabelAttribute, "A to Z Navigation");
      SetAttribute(output, HtmlAttributes.IdAttribute, CssClasses.NhsUkNavAz);

      output.PreContent.SetHtmlContent("<ol class=\"nhsuk-nav-a-z__list\" role=\"list\">");
      output.Content.SetHtmlContent(content);
      output.PostContent.SetHtmlContent("</ol>");
      output.TagMode = TagMode.StartTagAndEndTag;
    }

  }
}
