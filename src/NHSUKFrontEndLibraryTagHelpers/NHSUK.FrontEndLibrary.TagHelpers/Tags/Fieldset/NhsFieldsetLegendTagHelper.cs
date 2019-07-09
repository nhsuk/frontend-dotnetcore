using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Fieldset
{
  [HtmlTargetElement(TagHelperNames.NhsFieldsetLegendTag, 
    Attributes = NhsUkTagHelperAttributes.LegendSize, ParentTag = TagHelperNames.NhsFieldsetTag)]
  public class NhsFieldsetLegendTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.LegendSize)]
    public LegendSize LegendSize { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.IsPageHeading)]
    public bool IsPageHeading { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();
      output.TagName = HtmlElements.Legend;

      switch (LegendSize)
      {
        case LegendSize.XLarge:
          ClassesToPrepend.Add(CssClasses.NhsUkFieldsetLegendPageHeading);
          break;
        case LegendSize.Large:
          ClassesToPrepend.Add(CssClasses.NhsUkFieldsetLegendLarge);
          break;
        case LegendSize.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkFieldsetLegend);
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkFieldsetLegend);
          break;
      }

      if (IsPageHeading)
      {
        var heading = new TagBuilder(HtmlElements.H1);
        heading.AddCssClass(CssClasses.NhsUkFieldsetHeading);
        heading.InnerHtml.AppendHtml(content);
        output.Content.SetHtmlContent(heading);
      }

      else
      {
         output.Content.SetHtmlContent(content);
      }
    
      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);
    }
  }
}
