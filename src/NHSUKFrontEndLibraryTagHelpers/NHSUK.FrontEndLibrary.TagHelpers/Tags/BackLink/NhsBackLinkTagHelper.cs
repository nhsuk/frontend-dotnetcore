using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.BackLink
{
  [HtmlTargetElement(TagHelperNames.NhsBackLinkTag)]
  public class NhsBackLinkTagHelper : NhsBaseTagHelper
  {
    private string _href;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Div;

      var content = (await output.GetChildContentAsync()).GetContent();

      output.Attributes.RemoveAll(HtmlAttributes.HRef);

      ClassesToPrepend.Add(CssClasses.NhsUkBackLink);

      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        _href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
      }

      output.Content.SetHtmlContent(string.Format("<a class=\"nhsuk-back-link__link\" href=\"{0}\">" +
                                                  "<svg class=\"nhsuk-icon nhsuk-icon__chevron-left\" xmlns=\"http://www.w3.org/2000/svg\"" +
                                                  " viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M8.5 12c0-.3.1-.5.3-.7l5-5c.4-.4 1-.4" +
                                                  " 1.4 0s.4 1 0 1.4L10.9 12l4.3 4.3c.4.4.4 1 0 1.4s-1 .4-1.4 0l-5-5c-.2-.2-.3-.4-.3-.7z\"></path>" +
                                                  "</svg>{1}</a>", _href, content));
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
