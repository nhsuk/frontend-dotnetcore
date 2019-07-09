using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Header
{
  [HtmlTargetElement(TagHelperNames.NhsHeaderNavItemTag, ParentTag = TagHelperNames.NhsHeaderNavTag)]
  public class NhsHeaderNavItemTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Li;
      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      SetClassAttribute(output, CssClasses.NhsUkHeaderNavItem );

      var headerLink = new TagBuilder(HtmlElements.A);
      headerLink.AddCssClass(CssClasses.NhsUkHeaderNavItemLink);
      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        var href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
        headerLink.Attributes.Add(HtmlAttributes.HRef, href);
      }

      headerLink.InnerHtml.Append(content);
      headerLink.InnerHtml.AppendHtml("<svg class=\"nhsuk-icon nhsuk-icon__chevron-right\" " +
        "xmlns=\"http://www.w3.org/2000/svg\" " +
        "viewBox=\"0 0 24 24\" aria-hidden=\"true\">" +
        "<path d=\"M15.5 12a1 1 0 0 1-.29.71l-5 5a1 1 0 0 1-1.42-1.42l4.3-4.29-4.3-4.29a1 1 0 0 1 1.42-1.42l5 5a1 1 0 0 1 .29.71z\"></path></svg>");

      output.Content.SetHtmlContent(headerLink);
      output.TagMode = TagMode.StartTagAndEndTag;      
    }
  }
}
