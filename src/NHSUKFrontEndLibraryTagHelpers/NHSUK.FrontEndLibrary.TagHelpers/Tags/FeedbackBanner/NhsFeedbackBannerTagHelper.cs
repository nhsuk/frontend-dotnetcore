using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.FeedbackBanner
{
  [HtmlTargetElement(TagHelperNames.NhsFeedbackBannerTag,
    Attributes = NhsUkTagHelperAttributes.TitleText)]
  public class NhsFeedbackBannerTagHelper : NhsBaseTagHelper
  {
    private string _href;

    [HtmlAttributeName(NhsUkTagHelperAttributes.TitleText)]
    public string TitleText { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.LinkLabel)]
    public string LinkLabel { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Div;
      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      ClassesToPrepend.Add(CssClasses.NhsUkFeedbackBanner);

      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
       _href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
      }

      SetAttribute(output, HtmlAttributes.IdAttribute, CssClasses.NhsUkFeedbackBanner);
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
      output.Content.SetHtmlContent(string.Format(
        "<div class=\"nhsuk-width-container\"><div class=\"nhsuk-grid-row\"><div class=\"nhsuk-grid-column-full\">" +
        "<div class=\"nhsuk-feedback-banner__content\"><h2 class=\"nhsuk-feedback-banner__heading\">{0}</h2>" +
        "<p class=\"nhsuk-feedback-banner__message\">{1} <a href=\"{2}\"" +
        " class=\"nhsuk-u-nowrap\">{3}</a></p><button class=\"nhsuk-feedback-banner__close\" id=\"nhsuk-feedback-banner-close\"" +
        " type=\"button\">Close<span class=\"nhsuk-u-visually-hidden\"> feedback invite</span></button></div></div>" +
        "</div></div>",TitleText, content, _href, LinkLabel));
    }
  }
}
