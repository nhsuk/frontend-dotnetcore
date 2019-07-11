using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.SummaryList
{
  [HtmlTargetElement(TagHelperNames.NhsSummaryListRowActionsTag, ParentTag = TagHelperNames.NhsSummaryListRowTag)]
  public class NhsSummaryListRowActionsTagHelper : NhsBaseTagHelper
  {
    private string _href;
    [HtmlAttributeName(NhsUkTagHelperAttributes.VisuallyHiddenText)]
    public string VisuallyHiddenText { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);

      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        _href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
      }

      output.TagName = HtmlElements.Dd;
      ClassesToPrepend.Add(CssClasses.NhsUkSummaryListRowActions);
      UpdateClasses(output);

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(string.Format("<a href=\"{0}\">{1}<span class=\"nhsuk-u-visually-hidden\">" +
                                                  "{2}</span></a>", _href, content, VisuallyHiddenText));


       output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
