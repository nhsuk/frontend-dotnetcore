using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.ListPanel
{
  [HtmlTargetElement(TagHelperNames.NhsListPanelItemTag, ParentTag = TagHelperNames.NhsListPanelTag)]
  public class NhsListPanelItemTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Li;
      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      SetClassAttribute(output, CssClasses.NhsUkListPanelItem);

      var panelItemLink = new TagBuilder(HtmlElements.A);
      panelItemLink.AddCssClass(CssClasses.NhsUkListPanelItemLink);
      if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
      {
        var href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
        panelItemLink.Attributes.Add(HtmlAttributes.HRef, href);
      }

      panelItemLink.InnerHtml.Append(content);
      output.Content.SetHtmlContent(panelItemLink);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
