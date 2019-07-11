using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Table
{
  [HtmlTargetElement(TagHelperNames.NhsTableBodyRowTag, ParentTag = TagHelperNames.NhsTableBodyTag)]
  [RestrictChildren(TagHelperNames.NhsTableItemTag)]
  public class NhsTableBodyRowTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Tr;
      SetClassAttribute(output, CssClasses.NhsUkTableRow);
      
      output.TagMode = TagMode.StartTagAndEndTag;

      context.Items["ParentType"] = TagHelperNames.NhsTableBodyRowTag;
    }
  }
}
