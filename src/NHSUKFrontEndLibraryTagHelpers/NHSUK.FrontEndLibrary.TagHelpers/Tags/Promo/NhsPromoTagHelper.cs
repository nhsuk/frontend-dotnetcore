using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Promo
{
  [HtmlTargetElement(TagHelperNames.NhsPromoTag, Attributes = NhsUkTagHelperAttributes.PromoSize)]
  public class NhsPromoTagHelper : NhsBaseTagHelper
  {
    private string _href;
    private string _imageElement;
    private string _descriptionElement;
    private TagHelperContext _context;
    private TagHelperOutput _output;

    [HtmlAttributeName(NhsUkTagHelperAttributes.TitleText)]
    public string TitleText { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.DescriptionText)]
    public string DescriptionText { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.ImageUrl)]
    public string ImageUrl { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.PromoSize)]
    public PromoSize PromoSize { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      _output = output;
      _context = context;
      _output.TagName = HtmlElements.Div;
      _output.Attributes.RemoveAll(HtmlAttributes.HRef);
      if (_context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        _href = _context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
      }

      switch (PromoSize)
      {
        case PromoSize.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkPromo);
          break;
        case PromoSize.Small:
          ClassesToPrepend.Add(CssClasses.NhsUkPromoSmall);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkPromo);
          break;
      }

      UpdateClasses(_output);

      if (context.Items.ContainsKey("ParentColumnWidth"))
      {
        SetPrePostElementHtmlContent();
      }

      if (!string.IsNullOrWhiteSpace(ImageUrl))
      {
        _imageElement = string.Format("<img class=\"nhsuk-promo__img\" src=\"{0}\" alt=\"\">", ImageUrl);
      }

      if (!string.IsNullOrWhiteSpace(DescriptionText))
      {
        _descriptionElement = string.Format("<p class=\"nhsuk-promo__description\">{0}</p>", DescriptionText);
      }

      _output.Content.SetHtmlContent(string.Format("<a class=\"nhsuk-promo__link-wrapper\" href=\"{0}\">" + "{1}" +
                                                  "<div class=\"nhsuk-promo__content\"><h3 class=\"nhsuk-promo__heading\">" +
                                                  "{2}</h3>{3}" +
                                                  "</div></a>", _href, _imageElement, TitleText, _descriptionElement));

    }

    private void SetPrePostElementHtmlContent()
    {
      var parentColumnWidth = (GridColumnWidth)_context.Items["ParentColumnWidth"];
      string width;
      switch (parentColumnWidth)
      {
        case GridColumnWidth.OneThird:
          width = CssClasses.NhsUkGridOneThird;
          break;
        case GridColumnWidth.OneQuarter:
          width = CssClasses.NhsUkGridOneQuarter;
          break;
        case GridColumnWidth.OneHalf:
          width = CssClasses.NhsUkGridOneHalf;
          break;
        case GridColumnWidth.TwoThirds:
          width = CssClasses.NhsUkGridTwoThirds;
          break;
        case GridColumnWidth.ThreeQuarters:
          width = CssClasses.NhsUkGridThreeQuarters;
          break;
        case GridColumnWidth.Full:
          width = CssClasses.NhsUkGridFull;
          break;
        default:
          width = CssClasses.NhsUkGridFull;
          break;
      }

      _output.PreElement.SetHtmlContent(string.Format("<div class=\"{0} nhsuk-promo-group__item\">", width));
      _output.PostElement.SetHtmlContent("</div>");
    }
  }
}