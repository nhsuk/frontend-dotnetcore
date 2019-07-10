using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Actionlink
{
  [HtmlTargetElement(TagHelperNames.NhsActionLinkTag)]
  public class NhsActionLinkTagHelper : NhsBaseTagHelper
  {
    private string _href;

    [HtmlAttributeName(NhsUkTagHelperAttributes.OpenInNewWindow)]
    public bool OpenInNewWindow { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Div;

      var content = (await output.GetChildContentAsync()).GetContent();

      output.Attributes.RemoveAll(HtmlAttributes.HRef);

      ClassesToPrepend.Add(CssClasses.NhsUkActionLink);

      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        _href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
      }

      if (OpenInNewWindow)
      {
        SetAttribute(output, HtmlAttributes.Target, HtmlAttributes.AttributeValues.Blank);
      }

      output.Content.SetHtmlContent(string.Format("<a class=\"nhsuk-action-link__link\" href=\"{0}\">" +
                                                  "<svg class=\"nhsuk-icon nhsuk-icon__arrow-right-circle\" " +
                                                  "xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" " +
                                                  "aria-hidden=\"true\"><path d=\"M0 0h24v24H0z\" fill=\"none\">" +
                                                  "</path><path d=\"M12 2a10 10 0 0 0-9.95 9h11.64L9.74 7.05a1 1 0" +
                                                  " 0 1 1.41-1.41l5.66 5.65a1 1 0 0 1 0 1.42l-5.66 5.65a1 1 0 0 " +
                                                  "1-1.41 0 1 1 0 0 1 0-1.41L13.69 13H2.05A10 10 0 1 0 12 2z\" >" +
                                                  "</path ></svg ><span class=\"nhsuk-action-link__text\">{1}</span></a>",
                                                  _href, content));

      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
