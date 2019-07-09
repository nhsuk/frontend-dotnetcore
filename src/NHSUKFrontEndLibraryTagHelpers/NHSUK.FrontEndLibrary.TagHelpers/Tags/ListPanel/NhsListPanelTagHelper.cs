using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.ListPanel
{
  [HtmlTargetElement(TagHelperNames.NhsListPanelTag)]
  public class NhsListPanelTagHelper : NhsBaseTagHelper
  {
    private string _id;
    private TagHelperOutput _output;

    [HtmlAttributeName(NhsUkTagHelperAttributes.BackToTopLink)]
    public string BackToTopLink { get; set; }

    [HtmlAttributeName(HtmlAttributes.Disabled)]
    public bool Disabled { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.Label)]
    public string Label { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      _output = output;

      _output.TagName = HtmlElements.Div;
      var content = (await output.GetChildContentAsync()).GetContent();
      _output.Attributes.RemoveAll(HtmlAttributes.IdAttribute);

      if (context.AllAttributes.ContainsName(HtmlAttributes.IdAttribute))
      {
        _id = context.AllAttributes[HtmlAttributes.IdAttribute].Value.ToString();
      }

      ClassesToPrepend.Add(CssClasses.NhsUkListPanel);

      _output.PreElement.SetHtmlContent("<li>");

      AppendContent(content);

      AppendBackToTopElement();
      output.PostElement.SetHtmlContent("</li>");
      output.TagMode = TagMode.StartTagAndEndTag;

      UpdateClasses(output);
    }

    private void AppendContent(string content)
    {
      if (Disabled)
      {
        _output.Content.SetHtmlContent(string.Format(
          "<h2 class=\"nhsuk-list-panel__label\" id=\"{0}\">{1}</h2>" +
          "<div class=\"nhsuk-list-panel__box nhsuk-list-panel__box--with-label\">" +
          "<p class=\"nhsuk-list-panel--results-items__no-results\">{2}</p></div>", _id, Label, content));
      }
      else
      {
        _output.PreContent.SetHtmlContent(string.Format(
          "<h2 class=\"nhsuk-list-panel__label\" id=\"{0}\">{1}</h2>" +
          "<ul class=\"nhsuk-list-panel__list nhsuk-list-panel__list--with-label\">", _id, Label));

        _output.Content.SetHtmlContent(content);
        _output.PostContent.AppendHtml("</ul>");
      }
    }

    private void AppendBackToTopElement()
    {
      if (!string.IsNullOrWhiteSpace(BackToTopLink))
      {
        _output.PostContent.AppendHtml(string.Format(
          "<div class=\"nhsuk-back-to-top\"><a class=\"nhsuk-back-to-top__link\"" +
          " href=\"{0}\"><svg class=\"nhsuk-icon nhsuk-icon__arrow-right\" xmlns=\"http://www.w3.org/2000/svg\" " +
          "viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M19.6 11.66l-2.73-3A.51.51 0 0 0 16" +
          " 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z\">" +
          "</path></svg>Back to top</a></div>", BackToTopLink));
      }
    }
  }
}
