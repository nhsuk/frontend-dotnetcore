using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.ContentList
{
  [HtmlTargetElement(TagHelperNames.NhsContentListItemTag, ParentTag = TagHelperNames.NhsContentListTag)]
  public class NhsContentListItemTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.Current)]
    public bool Current { get; set; }

    private TagBuilder _contentlistItem;
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      var content = (await output.GetChildContentAsync()).GetContent();

      output.TagName = HtmlElements.Li;
      output.Attributes.RemoveAll(HtmlAttributes.HRef);
      SetClassAttribute(output, CssClasses.NhsUkContentListItem);

      if (Current)
      {
        SetAttribute(output, "aria-current", "page");
        _contentlistItem = new TagBuilder(HtmlElements.Span);
        _contentlistItem.AddCssClass(CssClasses.NhsUkContentListCurrent);
      }
      else
      {
        _contentlistItem = new TagBuilder(HtmlElements.A);
        _contentlistItem.AddCssClass(CssClasses.NhsUkContentListLink);
        if (context.AllAttributes.ContainsName(HtmlAttributes.HRef))
        {
          var href = context.AllAttributes[HtmlAttributes.HRef].Value.ToString();
          _contentlistItem.Attributes.Add(HtmlAttributes.HRef, href);
        }
      }

      _contentlistItem.InnerHtml.Append(content);
      output.Content.SetHtmlContent(_contentlistItem);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
