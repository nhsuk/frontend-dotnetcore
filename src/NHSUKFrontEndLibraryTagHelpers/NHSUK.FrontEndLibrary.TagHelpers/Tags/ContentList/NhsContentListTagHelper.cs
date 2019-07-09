using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.ContentList
{
  [HtmlTargetElement(TagHelperNames.NhsContentListTag)]
  [RestrictChildren(TagHelperNames.NhsContentListItemTag)]
  public class NhsContentListTagHelper : NhsBaseTagHelper
  {
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Nav;
      var content = (await output.GetChildContentAsync()).GetContent();

      ClassesToPrepend.Add(CssClasses.NhsUkContentList);
      SetAttribute(output,HtmlAttributes.Role, HtmlAttributes.AttributeValues.Navigation);
      SetAttribute(output,HtmlAttributes.AriaLabelAttribute, "Pages in this guide");
      var visuallyHidden = new TagBuilder(HtmlElements.H2);
      visuallyHidden.Attributes.Add(HtmlAttributes.ClassAttribute, CssClasses.NhsUkuVisuallyHidden);
      visuallyHidden.InnerHtml.Append(ContentText.Contents);

      var contentsList = new TagBuilder(HtmlElements.Ol);
      contentsList.AddCssClass(CssClasses.NhsUkContentListList);
      contentsList.InnerHtml.AppendHtml(content);

      output.PreContent.SetHtmlContent(visuallyHidden);
      output.Content.SetHtmlContent(contentsList);
      output.TagMode = TagMode.StartTagAndEndTag;

      UpdateClasses(output);
    }
  }
}
