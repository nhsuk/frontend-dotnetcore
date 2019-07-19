using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Select
{
  [HtmlTargetElement("select", Attributes = NhsUkTagHelperAttributes.SelectType)]
  [RestrictChildren(HtmlElements.Option)]
  public class NhsSelectTagHelper : NhsBaseTagHelper
  {

    [HtmlAttributeName(NhsUkTagHelperAttributes.SelectType)]
    public SelectType SelectType { get; set; }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);

      switch (SelectType)
      {
        case SelectType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkSelect);
          break;
        case SelectType.Error:
          ClassesToPrepend.Add(CssClasses.NhsUkSelectError);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkSelect);
          break;
      }

      UpdateClasses(output);
    }
  }
}
