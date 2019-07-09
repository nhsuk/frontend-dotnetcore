using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Label
{
  [HtmlTargetElement(TagHelperNames.NhsLabelTag,
    Attributes = NhsUkTagHelperAttributes.LabelType)]
  public class NhsLabelTagHelper : LabelTagHelper
  {
    [HtmlAttributeName("classes")]
    public string Classes { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.LabelType)]
    public LabelType LabelType { get; set; }
    public NhsLabelTagHelper(IHtmlGenerator generator) : base(generator)
    {
    }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      //await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Label;

      var labelWrapperOpening = string.Format("<{0} class=\"{1}\">", HtmlElements.H1, CssClasses.NhsLabelWrapper);
      var labelWrapperClosing = string.Format("</{0}", HtmlElements.H1);

      switch (LabelType)
      {
        case LabelType.Bold:
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabelBold);
          break;
        case LabelType.Medium:
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabelMedium);
          break;
        case LabelType.Large:
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabelLarge);
          break;
        case LabelType.Checkboxes:
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabelCheckboxes);
          break;
        case LabelType.Radios:
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabelRadios);
          break;
        case LabelType.PageHeading:
          output.PreElement.SetHtmlContent(labelWrapperOpening);
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabelPageHeader);
          output.PostElement.SetHtmlContent(labelWrapperClosing);
          break;
        case LabelType.Standard:
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabel);
          break;
        case LabelType.Date:
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabelDate);
          break;
        default:
          Helper.ClassesToPrepend.Add(CssClasses.NhsUkLabel);
          break;
      }

      var content = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(content);
      Helper.UpdateClasses(output, Classes);
    }
  }
}
