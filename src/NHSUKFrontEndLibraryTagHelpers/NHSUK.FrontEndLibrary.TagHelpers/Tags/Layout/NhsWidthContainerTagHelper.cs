using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Layout
{
  [HtmlTargetElement(
    TagHelperNames.NhsContainerTag, 
    Attributes = NhsUkTagHelperAttributes.ContainerWidth)]
  public class NhsWidthContainerTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.ContainerWidth)]
    public ContainerWidth ContainerWidth { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      output.TagName = HtmlElements.Div;

      switch (ContainerWidth)
      {
        case ContainerWidth.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkWidthContainer);
          break;
        case ContainerWidth.Fluid:
          ClassesToPrepend.Add(CssClasses.NhsUkWidthContainerFluid);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkWidthContainer);
          break;
      }
      
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
