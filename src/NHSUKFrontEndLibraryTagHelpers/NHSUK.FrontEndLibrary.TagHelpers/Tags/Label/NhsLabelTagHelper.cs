using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Label
{
  [HtmlTargetElement("label",
    Attributes = NhsUkTagHelperAttributes.LabelType)]
  public class NhsLabelTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.LabelType)]
    public LabelType LabelType { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);

      var labelWrapperOpening = string.Format("<{0} class=\"{1}\">", HtmlElements.H1, CssClasses.NhsLabelWrapper);
      var labelWrapperClosing = string.Format("</{0}", HtmlElements.H1);

      switch (LabelType)
      {
        case LabelType.Bold:
          ClassesToPrepend.Add(CssClasses.NhsUkLabelBold);
          break;
        case LabelType.Medium:
          ClassesToPrepend.Add(CssClasses.NhsUkLabelMedium);
          break;
        case LabelType.Large:
          ClassesToPrepend.Add(CssClasses.NhsUkLabelLarge);
          break;
        case LabelType.Checkboxes:
          ClassesToPrepend.Add(CssClasses.NhsUkLabelCheckboxes);
          break;
        case LabelType.Radios:
          ClassesToPrepend.Add(CssClasses.NhsUkLabelRadios);
          break;
        case LabelType.PageHeading:
          output.PreElement.SetHtmlContent(labelWrapperOpening);
          ClassesToPrepend.Add(CssClasses.NhsUkLabelPageHeader);
          output.PostElement.SetHtmlContent(labelWrapperClosing);
          break;
        case LabelType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkLabel);
          break;
        case LabelType.Date:
          ClassesToPrepend.Add(CssClasses.NhsUkLabelDate);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkLabel);
          break;
      }

      UpdateClasses(output);
    }
  }
}