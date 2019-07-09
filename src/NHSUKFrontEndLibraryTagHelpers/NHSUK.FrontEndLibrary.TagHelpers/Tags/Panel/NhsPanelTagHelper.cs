using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Panel
{
  [HtmlTargetElement(TagHelperNames.NhsPanelTag, Attributes = NhsUkTagHelperAttributes.PanelType)]
  public class NhsPanelTagHelper : NhsBaseTagHelper
  {
    private TagHelperContext _context;
    private TagHelperOutput _output;

    [HtmlAttributeName(NhsUkTagHelperAttributes.Label)]
    public string Label { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.PanelType)]
    public PanelType PanelType { get; set; }
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      _output = output;
      _context = context;
      _output.TagName = HtmlElements.Div;

      switch (PanelType)
      {
        case PanelType.Standard:
          ClassesToPrepend.Add(CssClasses.NhsUkPanel);
          break;
        case PanelType.Grey:
          ClassesToPrepend.Add(CssClasses.NhsUkPanelGrey);
          break;
        case PanelType.WithLabel:
          ClassesToPrepend.Add(CssClasses.NhsUkPanelLabel);
          _output.PreContent.SetHtmlContent(string.Format("<h3 class=\"nhsuk-panel-with-label__label\">{0}</h3>", Label));
          break;
        default:
          ClassesToPrepend.Add(CssClasses.NhsUkPanel);
          break;
      }

      UpdateClasses(output);

      if (_context.Items.ContainsKey("ParentColumnWidth"))
      {
        SetPrePostElementHtmlContent();
      }

      var htmlContent = (await output.GetChildContentAsync()).GetContent();
      output.Content.SetHtmlContent(htmlContent);

    }

    private void SetPrePostElementHtmlContent()
    {
      var parentColumnWidth = (GridColumnWidth)_context.Items["ParentColumnWidth"];
      string width;
      switch (parentColumnWidth)
      {
        case GridColumnWidth.OneThird:
          width = CssClasses.NhsUkGridOneThird;
          break;
        case GridColumnWidth.OneQuarter:
          width = CssClasses.NhsUkGridOneQuarter;
          break;
        case GridColumnWidth.OneHalf:
          width = CssClasses.NhsUkGridOneHalf;
          break;
        case GridColumnWidth.TwoThirds:
          width = CssClasses.NhsUkGridTwoThirds;
          break;
        case GridColumnWidth.ThreeQuarters:
          width = CssClasses.NhsUkGridThreeQuarters;
          break;
        case GridColumnWidth.Full:
          width = CssClasses.NhsUkGridFull;
          break;
        default:
          width = CssClasses.NhsUkGridFull;
          break;
      }

      _output.PreElement.SetHtmlContent(string.Format("<div class=\"{0} nhsuk-panel-group__item\">", width));
      _output.PostElement.SetHtmlContent("</div>");

    }

  }
}