using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Images
{
  [HtmlTargetElement(TagHelperNames.NhsImagesTag)]
  public class NhsImagesTagHelper : NhsBaseTagHelper
  {
    private string _captionHtml;
    private string _contentHtml;
    private TagHelperOutput _output;
    private string _src;
    private string _alt;

    [HtmlAttributeName(NhsUkTagHelperAttributes.Caption)]
    public string Caption { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      _output = output;
      _output.TagName = HtmlElements.Figure;
      ClassesToPrepend.Add(CssClasses.NhsUkImages);
      output.Attributes.RemoveAll("src");
      output.Attributes.RemoveAll("alt");

      if (context.AllAttributes.ContainsName("src"))
      {
        _src = context.AllAttributes["src"].Value.ToString();
      }

      if (context.AllAttributes.ContainsName("alt"))
      {
        _alt = context.AllAttributes["alt"].Value.ToString();
      }
    
      if (!string.IsNullOrWhiteSpace(Caption))
      {
        _captionHtml = string.Format("<figcaption class=\"nhsuk-image__caption\">{0}</figcaption>", Caption);
      }

      BuildHtmlContent();

      UpdateClasses(output);

      _output.TagMode = TagMode.StartTagAndEndTag;
      _output.Content.SetHtmlContent(_contentHtml);
    }

    private void BuildHtmlContent()
    {
      _contentHtml = string.Format("<img class=\"nhsuk-image__img\"" +
                                   " src=\"{0}\" alt=\"{1}\">{2}", _src, _alt, _captionHtml);

    }
  }
}
