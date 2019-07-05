using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Panel
{
  [HtmlTargetElement(TagHelperNames.NhsPanelTag, Attributes = NhsUkTagHelperAttributes.PanelType)]
  public class NhsPanelTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.Label)]
    public string Label { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.PanelType)]
    public PanelType PanelType { get; set; }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      output.TagName = HtmlElements.Div;

      switch (PanelType)
      {
        case PanelType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkPanel);
          break;
        case PanelType.Grey:
          ClassesToPrepend.Add(CssClasses.NhsUkPanelGrey);
          break;
        case PanelType.WithLabel:
          ClassesToPrepend.Add(CssClasses.NhsUkPanelLabel);
          output.PreContent.SetHtmlContent(string.Format("<h3 class=\"nhsuk-panel-with-label__label\">{0}</h3>", Label));
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkPanel);
          break;
      }

      UpdateClasses(output);

      if (context.Items.ContainsKey("Parent"))
      {
         if (context.Items["Parent"].ToString() == TagHelperNames.NhsPanelGroupTag)
        {
          output.PreElement.SetHtmlContent("<div class=\"nhsuk-grid-column-one-half nhsuk-panel-group__item\">");
          output.PostElement.SetHtmlContent("</div>");
        }
      }

      var htmlContent = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(htmlContent);

    }
  }
}