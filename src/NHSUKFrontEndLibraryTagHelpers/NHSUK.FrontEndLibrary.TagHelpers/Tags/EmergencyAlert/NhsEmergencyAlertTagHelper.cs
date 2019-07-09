using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.EmergencyAlert
{
  [HtmlTargetElement(TagHelperNames.NhsEmergencyAlertTag,
    Attributes = NhsUkTagHelperAttributes.TitleText)]
  public class NhsEmergencyAlertTagHelper : NhsBaseTagHelper
  {
    private string _href;

    [HtmlAttributeName(NhsUkTagHelperAttributes.TitleText)]
    public string TitleText { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.LastUpdated)]
    public string LastUpdated { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.LinkLabel)]
    public string LinkLabel { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Div;
      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      ClassesToPrepend.Add(CssClasses.NhsUkGlobalAlert);

      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
       _href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
      }

      SetAttribute(output, HtmlAttributes.IdAttribute, CssClasses.NhsUkGlobalAlert);
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
      output.Content.SetHtmlContent(string.Format(
        "<div class=\"nhsuk-width-container\"><div class=\"nhsuk-grid-row\">" +
        "<div class=\"nhsuk-grid-column-full\"><div class=\"nhsuk-global-alert__content\">" +
        "<h2 class=\"nhsuk-global-alert__heading\"><span class=\"nhsuk-u-visually-hidden\">Alert: </span>" +
        "{0}</h2><p class=\"nhsuk-global-alert__message\">{1}" +
        " <a class=\"nhsuk-u-nowrap\" href=\"{2}\" >{3}</a></p>" +
        "<p class=\"nhsuk-global-alert__updated\">{4}</p></div></div></div></div>", 
        TitleText, content, _href, LinkLabel, LastUpdated ));
    }
  }
}
