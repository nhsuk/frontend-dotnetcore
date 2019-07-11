using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Table
{
  [HtmlTargetElement(TagHelperNames.NhsTableTag)]
  [RestrictChildren(TagHelperNames.NhsTableHeadTag, TagHelperNames.NhsTableBodyTag)]
  public class NhsTableTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.Caption)]
    public string Caption { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.TitleText)]
    public string TitleText { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.IsWithPanel)]
    public bool IsWithPanel { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Table;

      ClassesToPrepend.Add(CssClasses.NhsUkTable);

      UpdateClasses(output);

      if (!string.IsNullOrWhiteSpace(Caption))
      {
        output.PreContent.SetHtmlContent(string.Format("<caption class=\"nhsuk-table__caption\">{0}</caption>", Caption));
      }

      if (IsWithPanel)
      {
        output.PreElement.AppendHtml(string.Format("<div class=\"nhsuk-table__panel-with-heading-tab\">" +
                                     "<h3 class=\"nhsuk-table__heading-tab\">{0}</h3>", TitleText));
        output.PostElement.AppendHtml("</div>");
      }
     
        output.PreElement.AppendHtml("<div class=\"nhsuk-table-responsive\">");
        output.PostElement.AppendHtml("</div>");
      

    }

  }
}