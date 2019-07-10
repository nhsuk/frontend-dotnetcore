using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Hero
{
  [HtmlTargetElement(TagHelperNames.NhsHeroTag)]
  public class NhsHeroTagHelper : NhsBaseTagHelper
  {
   
    [HtmlAttributeName(NhsUkTagHelperAttributes.TitleText)]
    public string TitleText { get; set; }

    private bool _heroContentOnly;
    private bool _imageOnly;
    private bool _heroContentImage;
    private string _content;
    private TagHelperOutput _output;
    [HtmlAttributeName(NhsUkTagHelperAttributes.ImageUrl)]
    public string ImageUrl { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      _output = output;
      _output.TagName = HtmlElements.Section;

      string text = (await _output.GetChildContentAsync()).GetContent();

      _imageOnly = string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(ImageUrl) && string.IsNullOrWhiteSpace(TitleText);
      _heroContentOnly = !string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(ImageUrl) &&
                            !string.IsNullOrWhiteSpace(TitleText);
      _heroContentImage = !string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(ImageUrl) &&
                             !string.IsNullOrWhiteSpace(TitleText);

      BuildHeroHtmlContent(text);
      UpdateClasses(output);
      _output.TagMode = TagMode.StartTagAndEndTag;
      _output.Content.SetHtmlContent(_content);
    }

    private void BuildHeroHtmlContent(string text)
    {
      if (_heroContentOnly)
      {
        ClassesToPrepend.Add(CssClasses.NhsUkHero);
        _content = string.Format(
          "<div class=\"nhsuk-width-container nhsuk-hero--border\"><div class=\"nhsuk-grid-row\"><div class=\"nhsuk-grid-column-two-thirds\">" +
          "<div class=\"nhsuk-hero__wrapper\"><h1 class=\"nhsuk-u-margin-bottom-3\">{0}</h1><p class=\"nhsuk-body-l nhsuk-u-margin-bottom-0\">" +
          "{1}</p></div></div></div></div>", TitleText, text);
      }

      if (_imageOnly)
      {
        ClassesToPrepend.Add(CssClasses.NhsUkHeroImage);
        SetAttribute(_output, "style", string.Format("background-image: url('{0}');", ImageUrl));
        _content = "<div class=\"nhsuk-hero__overlay\"></div>";
      }

      if (_heroContentImage)
      {
        ClassesToPrepend.Add(CssClasses.NhsUkHeroImageContent);
        SetAttribute(_output, "style", string.Format("background-image: url('{0}');", ImageUrl));

        _content = string.Format(
          "<div class=\"nhsuk-hero__overlay\"><div class=\"nhsuk-width-container\"><div class=\"nhsuk-grid-row\">" +
          "<div class=\"nhsuk-grid-column-two-thirds\"><div class=\"nhsuk-hero-content\"><h1 class=\"nhsuk-u-margin-bottom-3\">" +
          "{0}</h1><p class=\"nhsuk-body-l nhsuk-u-margin-bottom-0\">{1}</p><span class=\"nhsuk-hero__arrow\" aria-hidden=\"true\"></span>" +
          "</div></div></div></div></div>", TitleText, text);
      }
    }
  }
}
