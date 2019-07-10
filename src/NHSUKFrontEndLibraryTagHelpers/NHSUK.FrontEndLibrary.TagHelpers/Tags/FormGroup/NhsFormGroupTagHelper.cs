using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.FormGroup
{
  [HtmlTargetElement(TagHelperNames.NhsFormGroupTag, Attributes = NhsUkTagHelperAttributes.FormGroupType)]
  public class NhsFormGroupTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.FormGroupType)]
    public FormGroupType FormGroupType { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;

      switch (FormGroupType)
      {
        case FormGroupType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkFormGroup);
          break;
        case FormGroupType.Error:
          ClassesToPrepend.Add(CssClasses.NhsUkFormGroupError);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkFormGroup);
          break;
      }

      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
