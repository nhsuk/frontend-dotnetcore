using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.DoDontList
{
  [HtmlTargetElement(TagHelperNames.NhsDoDontListTag, Attributes = NhsUkTagHelperAttributes.DoDontListType)]
  [RestrictChildren(TagHelperNames.NhsDoDontListItemTag)]
  public class NhsDoDontListTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.DoDontListType)]
    public DoDontListType DoDontListType { get; set; }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      string displayText;
      string listTickCross;
      context.Items["ParentType"] = DoDontListType;

      output.TagName = HtmlElements.Div;
      var content = (await output.GetChildContentAsync()).GetContent();

      ClassesToPrepend.Add(CssClasses.NhsUkDoDontList);

      switch (DoDontListType)
      {
        case DoDontListType.Do:
          displayText = "Do";
          listTickCross = CssClasses.NhsUkListTick;
          break;
        case DoDontListType.Dont:
          displayText = "Don't";
          listTickCross = CssClasses.NhsUkListCross;
          break;
        default:
          displayText = "Do";
          listTickCross = CssClasses.NhsUkListTick;
          break;
      }


      output.PreContent.SetHtmlContent(
        string.Format("<h3 class=\"nhsuk-do-dont-list__label\">{0}</h3>" +
                      "<ul class=\"{1}\">", displayText, listTickCross));

      output.Content.SetHtmlContent(content);
      output.PostContent.SetHtmlContent("</ul>");
      UpdateClasses(output);
    }
  }
}
