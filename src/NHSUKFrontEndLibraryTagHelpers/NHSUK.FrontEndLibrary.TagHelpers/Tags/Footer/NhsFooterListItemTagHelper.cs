using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Footer
{
  [HtmlTargetElement(TagHelperNames.NhsFooterListItemTag, ParentTag = TagHelperNames.NhsFooterTag)]
  public class NhsFooterListItemTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Li;
      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      SetClassAttribute(output, CssClasses.NhsUkFooterItem );

      var footerLink = new TagBuilder(HtmlElements.A);
      footerLink.AddCssClass(CssClasses.NhsUkFooterItemLink);

      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        var href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
        footerLink.Attributes.Add(HtmlAttributes.HRef, href);
      }

      footerLink.InnerHtml.Append(content);
      output.Content.SetHtmlContent(footerLink);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
