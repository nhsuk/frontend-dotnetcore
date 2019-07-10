using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.BreadCrumb
{
  [HtmlTargetElement(TagHelperNames.NhsBreadcrumbListTag, ParentTag = TagHelperNames.NhsBreadCrumbTag)]
  [RestrictChildren(TagHelperNames.NhsBreadcrumbListItemTag)]
  public class NhsBreadCrumbListTagHelper : NhsBaseTagHelper
  {
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Ol;
      SetClassAttribute(output, CssClasses.NhsUkBreadcrumbList);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
