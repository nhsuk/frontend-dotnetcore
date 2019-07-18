using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.TextArea
{
  [HtmlTargetElement("textarea", 
    Attributes = NhsUkTagHelperAttributes.TextAreaType)]
  public class NhsTextAreaTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.TextAreaType)]
    public TextAreaType TextAreaType { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);

      switch (TextAreaType)
      {
       case TextAreaType.Error:
         ClassesToPrepend.Add(CssClasses.NhsUkTextAreaError);
          break;
        case TextAreaType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkTextArea);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkTextArea);
          break;
      }

      UpdateClasses(output);
    }
  }
}
