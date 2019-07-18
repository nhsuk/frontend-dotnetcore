using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Input
{
  [HtmlTargetElement("input", Attributes = NhsUkTagHelperAttributes.InputType)]
  public class NhsInputTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.InputType)]
    public InputType InputType { get; set; }
    
    [HtmlAttributeName(NhsUkTagHelperAttributes.InputWidth)]
    public InputWidth InputWidth { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.IsErrorInput)]
    public bool IsErrorInput { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
     
      switch (InputType)
      {
       case InputType.Checkboxes:
         ClassesToPrepend.Add(CssClasses.NhsUkInputCheckboxes);
         SetAttribute(output, HtmlAttributes.Type, HtmlAttributes.AttributeValues.Checkbox);
          break;
        case InputType.Radios:
          ClassesToPrepend.Add(CssClasses.NhsUkInputRadios);
          SetAttribute(output, HtmlAttributes.Type, HtmlAttributes.AttributeValues.Radio);
          break;
        case InputType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkInput);
          SetAttribute(output, HtmlAttributes.Type, HtmlAttributes.AttributeValues.Text);
          break;
        case InputType.Date:
          ClassesToPrepend.Add(CssClasses.NhsUkInputDate);
          SetAttribute(output, HtmlAttributes.Type, HtmlAttributes.AttributeValues.Number);
          SetAttribute(output, "pattern", "[0-9]*");
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkInput);
          SetAttribute(output, HtmlAttributes.Type, HtmlAttributes.AttributeValues.Text);
          break;
      }

      if (IsErrorInput)
      {
        ClassesToPrepend.Add(CssClasses.NhsUkInputErrorMessage);
      }

      AddWidthClasses();
      UpdateClasses(output);
    }

    private void AddWidthClasses()
    {
      if (InputWidth != InputWidth.None)
      {
        switch (InputWidth)
        {
          case InputWidth.Two:
            ClassesToPrepend.Add(CssClasses.NhsUkInputWidth2);
            break;
          case InputWidth.Ten:
            ClassesToPrepend.Add(CssClasses.NhsUkInputWidth10);
            break;
          case InputWidth.Twenty:
            ClassesToPrepend.Add(CssClasses.NhsUkInputWidth20);
            break;
          case InputWidth.Three:
            ClassesToPrepend.Add( CssClasses.NhsUkInputWidth3);
            break;
          case InputWidth.Four:
            ClassesToPrepend.Add(CssClasses.NhsUkInputWidth4);
            break;
          case InputWidth.Five:
            ClassesToPrepend.Add(CssClasses.NhsUkInputWidth5);
            break;
        }
      }     
    }
  }
}
