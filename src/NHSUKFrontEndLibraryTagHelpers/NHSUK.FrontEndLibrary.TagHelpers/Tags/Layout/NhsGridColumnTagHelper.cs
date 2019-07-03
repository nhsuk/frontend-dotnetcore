using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Layout
{
  [HtmlTargetElement(TagHelperNames.NhsGridColumnTag, Attributes = NhsUkTagHelperAttributes.GridColumnType)]
  public class NhsGridColumnTagHelper : NhsBaseTagHelper
  {
    private TagHelperOutput _tagHelperOutput;
    [HtmlAttributeName(NhsUkTagHelperAttributes.GridColumnType)]
    public GridColumnWidth GridColumnType { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      _tagHelperOutput = output;
      _tagHelperOutput.TagName = HtmlElements.Div;

      switch (GridColumnType)
      {
        case GridColumnWidth.OneThird:
          ClassesToPrepend.Add(CssClasses.NhsUkGridOneThird);
          break;
        case GridColumnWidth.OneQuarter:
          ClassesToPrepend.Add(CssClasses.NhsUkGridOneQuarter);
          break;
        case GridColumnWidth.OneHalf:
          ClassesToPrepend.Add(CssClasses.NhsUkGridOneHalf);
          break;
        case GridColumnWidth.TwoThirds:
          ClassesToPrepend.Add(CssClasses.NhsUkGridTwoThirds);
          break;
        case GridColumnWidth.ThreeQuarters:
          ClassesToPrepend.Add(CssClasses.NhsUkGridThreeQuarters);
          break;
        case GridColumnWidth.Full:
          ClassesToPrepend.Add(CssClasses.NhsUkGridFull);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkGridFull);
          break;
      }
     
      _tagHelperOutput.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
