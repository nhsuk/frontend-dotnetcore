using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.BreadCrumb
{
  // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
  [HtmlTargetElement(TagHelperNames.NhsBreadCrumbTag)]
  [RestrictChildren(TagHelperNames.NhsBreadcrumbListTag, TagHelperNames.NhsBreadCrumbBackLinkTag)]
  public class NhsBreadCrumbTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Nav;
      ClassesToPrepend.Add(CssClasses.NhsUkBreadCrumb);
      SetAttribute(output, HtmlAttributes.AriaLabelAttribute, HtmlAttributes.AttributeValues.Breadcrumb);
      var widthContainer = new TagBuilder(HtmlElements.Div);
      widthContainer.AddCssClass(CssClasses.NhsUkWidthContainer);
      widthContainer.InnerHtml.AppendHtml(content);
      output.Content.SetHtmlContent(widthContainer);

      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);

    }
  }
}
