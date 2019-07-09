using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Pagination
{
  [HtmlTargetElement(TagHelperNames.NhsPaginationTag)]
  public class NhsPaginationTagHelper : NhsBaseTagHelper
  {
    private TagHelperOutput _output;
    private string _prevContent;
    private string _nextContent;

    [HtmlAttributeName(NhsUkTagHelperAttributes.PreviousUrl)]
    public string PreviousUrl { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.PreviousLinkText)]
    public string PreviousLinkText { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.NextUrl)]
    public string NextUrl { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.NextLinkText)]
    public string NextLinkText { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      _output = output;
      _output.TagName = HtmlElements.Nav;
      ClassesToPrepend.Add(CssClasses.NhsUkPagination);
      SetAttribute(output, HtmlAttributes.Role, HtmlAttributes.AttributeValues.Navigation);
      SetAttribute(output, HtmlAttributes.AriaLabelAttribute, "Pagination");
      _output.PreContent.SetHtmlContent("<ul class=\"nhsuk-list nhsuk-pagination__list\">");

      BuildPreviousPageContent();
      BuildNextPageContent();

      UpdateClasses(output);

      _output.Content.AppendHtml(_prevContent);
      _output.Content.AppendHtml(_nextContent);
      _output.PostContent.SetHtmlContent("</ul>");
      _output.TagMode = TagMode.StartTagAndEndTag;

    }

    private void BuildPreviousPageContent()
    {
      if (!string.IsNullOrWhiteSpace(PreviousUrl))
      {
        _prevContent = string.Format("<li class=\"nhsuk-pagination-item--previous\"><a class=\"nhsuk-pagination__link nhsuk-pagination__link--prev\"" +
                                     " href=\"{0}\"><span class=\"nhsuk-pagination__title\">Previous</span><span class=\"nhsuk-u-visually-hidden\">:</span>" +
                                     "<span class=\"nhsuk-pagination__page\">{1}</span><svg class=\"nhsuk-icon nhsuk-icon__arrow-left\" " +
                                     "xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M4.1 12.3l2.7 3c.2.2.5.2.7 0" +
                                     " .1-.1.1-.2.1-.3v-2h11c.6 0 1-.4 1-1s-.4-1-1-1h-11V9c0-.2-.1-.4-.3-.5h-.2c-.1 0-.3.1-.4.2l-2.7 3c0 .2 0 .4.1.6z\">" +
                                     "</path></svg></a></li>", PreviousUrl, PreviousLinkText);
      }
    }

    private void BuildNextPageContent()
    {
      if (!string.IsNullOrWhiteSpace(NextUrl))
      {
        _nextContent = string.Format("<li class=\"nhsuk-pagination-item--next\"><a class=\"nhsuk-pagination__link nhsuk-pagination__link--next\"" +
                                     " href=\"{0}\"><span class=\"nhsuk-pagination__title\">Next</span><span class=\"nhsuk-u-visually-hidden\">:</span>" +
                                     "<span class=\"nhsuk-pagination__page\">{1}</span><svg class=\"nhsuk-icon nhsuk-icon__arrow-right\" xmlns=\"http://www.w3.org/2000/svg\"" +
                                     " viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path d=\"M19.6 11.66l-2.73-3A.51.51 0 0 0 16 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0" +
                                     " 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z\"></path></svg></a></li>", NextUrl, NextLinkText);
      }
    }

  }
}
