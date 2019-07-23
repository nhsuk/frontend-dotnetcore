using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Button
{
  [HtmlTargetElement("button", Attributes = NhsUkTagHelperAttributes.ButtonType)]
  public class NhsButtonTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.ButtonType)]
    public ButtonType ButtonType { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);

      switch (ButtonType)
      {
        case ButtonType.Secondary:
          ProcessButtonTypeSecondary(output);
          break;
        case ButtonType.Reverse:
          ProcessButtonTypeReverse(output);
          break;
        case ButtonType.Standard:
          ProcessButtonTypeStandard(output);
          break;
        default:
          ProcessButtonTypeStandard(output);
          break;
      }

      ProcessDisabled(output, context);

      UpdateClasses(output);
      
    }

    private void ProcessButtonTypeSecondary(TagHelperOutput output)
    {
      ClassesToPrepend.Add(CssClasses.NhsUkButtonSecondary);
      SetAttribute(output, HtmlAttributes.Type, HtmlAttributes.AttributeValues.Submit);
    }

    private void ProcessButtonTypeReverse(TagHelperOutput output)
    {
      ClassesToPrepend.Add(CssClasses.NhsUkButtonReverse);
      SetAttribute(output, HtmlAttributes.Type, HtmlAttributes.AttributeValues.Submit);
    }

    private void ProcessButtonTypeStandard(TagHelperOutput output)
    {
      ClassesToPrepend.Add(CssClasses.NhsUkButton);
      SetAttribute(output, HtmlAttributes.Type, HtmlAttributes.AttributeValues.Submit);
    }

    private void ProcessDisabled(TagHelperOutput output, TagHelperContext context)
    {
      if (context.AllAttributes.ContainsName(HtmlAttributes.Disabled))
      {
        ClassesToPrepend.Add(CssClasses.NhsUkButtonDisabled);
        SetAttribute(output, HtmlAttributes.Disabled, HtmlAttributes.AttributeValues.Disabled);
        SetAttribute(output, HtmlAttributes.AriaDisabled, HtmlAttributes.AttributeValues.True);
      }
    }
  }
}
