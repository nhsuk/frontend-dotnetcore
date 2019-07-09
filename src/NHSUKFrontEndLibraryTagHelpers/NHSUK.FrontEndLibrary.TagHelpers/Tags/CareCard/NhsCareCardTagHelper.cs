using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.CareCard
{
  [HtmlTargetElement(TagHelperNames.NhsCareCardTag, 
    Attributes = NhsUkTagHelperAttributes.CareCardType + "," + NhsUkTagHelperAttributes.CareCardHeading)]
  public class NhsCareCardTagHelper : NhsBaseTagHelper
  {
    private string _visuallyHiddenText;

    [HtmlAttributeName(NhsUkTagHelperAttributes.CareCardType)]
    public CareCardType CareCardType { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.CareCardHeading)]
    public string CareCardHeading { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Div;

      switch (CareCardType)
      {
        case CareCardType.NonUrgent:
          ClassesToPrepend.Add(CssClasses.NhsUkCareCardNonUrgent);
          _visuallyHiddenText = ContentText.CareCardNonUrgentHiddenText;
          break;
        case CareCardType.Urgent:
          ClassesToPrepend.Add(CssClasses.NhsUkCareCardUrgent);
          _visuallyHiddenText = ContentText.CareCardUrgentHiddenText;
          break;
        case CareCardType.Immediate:
          ClassesToPrepend.Add(CssClasses.NhsUkCareCardImmediate);
          _visuallyHiddenText = ContentText.CareCardImmediateHiddenText ;
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkCareCardNonUrgent);
          _visuallyHiddenText = ContentText.CareCardNonUrgentHiddenText;
          break;
      }

      output.PreContent.SetHtmlContent(
        string.Format("<div class=\"nhsuk-care-card__heading-container\"><h3 class=\"nhsuk-care-card__heading\">" +
                      "<span role =\"text\"><span class=\"nhsuk-u-visually-hidden\">{0}:</span>{1}:</span></h3>" +
                      "<span class=\"nhsuk-care-card__arrow\" aria-hidden=\"true\"></span></div>" +
                      "<div class=\"nhsuk-care-card__content\">", _visuallyHiddenText, CareCardHeading));

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);
      output.PostContent.SetHtmlContent("</div>");
      UpdateClasses(output);
    }
  }
}