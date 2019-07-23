using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Anchor
{
  [HtmlTargetElement("a", Attributes = NhsUkTagHelperAttributes.AnchorType)]
  public class NhsAnchorTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.AnchorType)]
    public AnchorType AnchorType { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);

      switch (AnchorType)
      {
        case AnchorType.Button:
          ClassesToPrepend.Add(CssClasses.NhsUkButton);
          SetAttribute(output, HtmlAttributes.Role, HtmlElements.Button);
          SetAttribute(output, HtmlAttributes.Draggable, HtmlAttributes.AttributeValues.False);
          ProcessDisabled(output, context);
          break;
        case AnchorType.SkipLink:
        ClassesToPrepend.Add(CssClasses.NhsUkSkipLink);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkSkipLink);
          break;
      }

      UpdateClasses(output);
      
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
