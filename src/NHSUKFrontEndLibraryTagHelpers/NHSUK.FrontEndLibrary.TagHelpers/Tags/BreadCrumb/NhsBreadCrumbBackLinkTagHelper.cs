using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.BreadCrumb
{
  [HtmlTargetElement(TagHelperNames.NhsBreadCrumbBackLinkTag, ParentTag = TagHelperNames.NhsBreadCrumbTag)]
  public class NhsBreadCrumbBackLinkTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.P;
      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      SetClassAttribute(output, CssClasses.NhsUkBreadcrumbBack);

      var breadcrumbBackLink = new TagBuilder(HtmlElements.A);
      breadcrumbBackLink.AddCssClass(CssClasses.NhsUkBreadcrumbBackLink);

      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        var href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
        breadcrumbBackLink.Attributes.Add(HtmlAttributes.HRef, href);
      }

      breadcrumbBackLink.InnerHtml.Append(content);
      output.Content.SetHtmlContent(breadcrumbBackLink);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
