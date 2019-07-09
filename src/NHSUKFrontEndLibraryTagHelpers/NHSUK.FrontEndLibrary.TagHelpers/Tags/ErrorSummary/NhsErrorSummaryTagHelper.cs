using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tags.ErrorSummary
{
  [HtmlTargetElement(TagHelperNames.NhsErrorSummaryTag,
    Attributes = NhsUkTagHelperAttributes.TitleText + "," + NhsUkTagHelperAttributes.TitleId)]
  [RestrictChildren(HtmlElements.Li)]
  public class NhsErrorSummaryTagHelper : NhsBaseTagHelper
  {
    [HtmlAttributeName(NhsUkTagHelperAttributes.TitleText)]
    public string TitleText { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.TitleId)]
    public string TitleId { get; set; }

    [HtmlAttributeName(NhsUkTagHelperAttributes.DescriptionText)]
    public string DescriptionText { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      await base.ProcessAsync(context, output);
      output.TagName = HtmlElements.Div;
      var content = (await output.GetChildContentAsync()).GetContent();
      SetAttribute(output, HtmlAttributes.AriaLabelByAttribute, TitleId);
      ClassesToPrepend.Add(CssClasses.NhsUkErrorSummary);

      var errorSummaryTitle = new TagBuilder(HtmlElements.H2);
      errorSummaryTitle.AddCssClass(CssClasses.NhsUkErrorSummaryTitle);
      errorSummaryTitle.Attributes.Add(HtmlAttributes.IdAttribute, TitleId);
      errorSummaryTitle.InnerHtml.Append(TitleText);

      var errorSummaryBody = new TagBuilder(HtmlElements.Div);
      errorSummaryBody.AddCssClass(CssClasses.NhsUkErrorSummaryBody);

      var errorSummaryDescription = new TagBuilder(HtmlElements.P);
      errorSummaryDescription.InnerHtml.Append(DescriptionText);

      var errorSummaryList = new TagBuilder(HtmlElements.Ul);
      errorSummaryList.AddCssClass(CssClasses.NhsUkErrorSummaryList);
      errorSummaryList.InnerHtml.AppendHtml(content);

      errorSummaryBody.InnerHtml.AppendHtml(errorSummaryDescription);
      errorSummaryBody.InnerHtml.AppendHtml(errorSummaryList);

      output.PreContent.AppendHtml(errorSummaryTitle);
      output.Content.AppendHtml(errorSummaryBody);

      output.TagMode = TagMode.StartTagAndEndTag;
      UpdateClasses(output);

    }
  }
}
