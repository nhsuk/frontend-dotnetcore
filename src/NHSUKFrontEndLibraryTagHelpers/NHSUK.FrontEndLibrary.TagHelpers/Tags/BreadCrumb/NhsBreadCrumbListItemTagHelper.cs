using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.BreadCrumb
{
  [HtmlTargetElement(TagHelperNames.NhsBreadcrumbListItemTag, ParentTag = TagHelperNames.NhsBreadcrumbListTag)]
  public class NhsBreadCrumbListItemTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Li;
      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      SetClassAttribute(output, CssClasses.NhsUkBreadcrumbItem);

      var breadcrumbLink = new TagBuilder(HtmlElements.A);
      breadcrumbLink.AddCssClass(CssClasses.NhsUkBreadcrumbLink);
      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        var href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
        breadcrumbLink.Attributes.Add(HtmlAttributes.HRef, href);
      }

      breadcrumbLink.InnerHtml.Append(content);
      output.Content.SetHtmlContent(breadcrumbLink);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
