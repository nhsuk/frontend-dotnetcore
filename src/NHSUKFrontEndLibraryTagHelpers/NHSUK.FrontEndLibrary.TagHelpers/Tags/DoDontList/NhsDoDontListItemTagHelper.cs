using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.DoDontList
{
  [HtmlTargetElement(TagHelperNames.NhsDoDontListItemTag, ParentTag = TagHelperNames.NhsDoDontListTag)]
  public class NhsDoDontListItemTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var parentType = (DoDontListType)context.Items["ParentType"];

      var content = (await output.GetChildContentAsync()).GetContent();
      string tickIcon = "<svg class=\"nhsuk-icon nhsuk-icon__tick\" xmlns=\"http://www.w3.org/2000/svg\"" +
                              " viewBox=\"0 0 24 24\" fill=\"none\" aria-hidden=\"true\"><path stroke-width=\"4\"" +
                              " stroke-linecap=\"round\" d=\"M18.4 7.8l-8.5 8.4L5.6 12\"></path></svg>";

      string crossIcon = "<svg class=\"nhsuk-icon nhsuk-icon__cross\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\"" +
                         " aria-hidden=\"true\"><path d=\"M17 18.5c-.4 0-.8-.1-1.1-.4l-10-10c-.6-.6-.6-1.6 0-2.1.6-.6 1.5-.6 2.1 0l10 10c.6.6.6 1.5 0 2.1-.3.3-.6.4-1 .4z\">" +
                         "</path><path d=\"M7 18.5c-.4 0-.8-.1-1.1-.4-.6-.6-.6-1.5 0-2.1l10-10c.6-.6 1.5-.6 2.1 0 .6.6.6 1.5 0 2.1l-10 10c-.3.3-.6.4-1 .4z\"></path></svg>";

      output.TagName = HtmlElements.Li;
      string icon;
      switch (parentType)
      {
        case DoDontListType.Do:
          icon = tickIcon;
          break;
        case DoDontListType.Dont:
          icon = crossIcon;
          break;
        default:
          icon = tickIcon;
          break;
      }

      output.Content.SetHtmlContent(icon + content);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
