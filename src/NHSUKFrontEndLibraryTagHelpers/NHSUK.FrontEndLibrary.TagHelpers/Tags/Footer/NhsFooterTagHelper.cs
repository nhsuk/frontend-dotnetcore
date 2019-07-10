using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.Footer
{
  [HtmlTargetElement(TagHelperNames.NhsFooterTag)]
  [RestrictChildren(TagHelperNames.NhsFooterListItemTag)]
  public class NhsFooterTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.IsListColumns)]
    public bool IsListColumn { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Footer;
      var content = (await output.GetChildContentAsync()).GetContent();

      SetAttribute(output, HtmlAttributes.Role, HtmlAttributes.AttributeValues.ContentInfo);

      var footer = new TagBuilder(HtmlElements.Div);
      footer.AddCssClass(CssClasses.NhsUkFooter);
      footer.Attributes.Add(HtmlAttributes.IdAttribute, CssClasses.NhsUkFooter);

      var widthContainer = new TagBuilder(HtmlElements.Div);
      widthContainer.AddCssClass(CssClasses.NhsUkWidthContainer);

      var visuallyHidden = new TagBuilder(HtmlElements.H2);
      visuallyHidden.Attributes.Add(HtmlAttributes.ClassAttribute, CssClasses.NhsUkuVisuallyHidden);
      visuallyHidden.InnerHtml.Append(ContentText.SupportLinks);

      var footerList = new TagBuilder(HtmlElements.Ul);
      footerList.AddCssClass(IsListColumn ? CssClasses.NhsUkFooterListColumn : CssClasses.NhsUkFooterList);

      footerList.InnerHtml.AppendHtml(content);

      var footerCopyright = new TagBuilder(HtmlElements.P);
      footerCopyright.Attributes.Add(HtmlAttributes.ClassAttribute, CssClasses.NhsUkFooterCopyright);
      footerCopyright.InnerHtml.AppendHtml(ContentText.CrownCopyright);

      widthContainer.InnerHtml.AppendHtml(visuallyHidden);
      widthContainer.InnerHtml.AppendHtml(footerList);
      widthContainer.InnerHtml.AppendHtml(footerCopyright);

      footer.InnerHtml.AppendHtml(widthContainer);

      UpdateClasses(output);
      output.Content.SetHtmlContent(footer);
      output.TagMode = TagMode.StartTagAndEndTag;
    }
  }
}
