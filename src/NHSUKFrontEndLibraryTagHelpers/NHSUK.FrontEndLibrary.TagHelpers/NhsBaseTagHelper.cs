using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers
{
  public class NhsBaseTagHelper : TagHelper
  {
    protected List<string> ClassesToPrepend = new List<string>();

    [HtmlAttributeName("classes")]
    public string Classes { get; set; }

    protected void SetAttribute(TagHelperOutput output, string attribute, string attributeValue)
    {
      output.Attributes.SetAttribute(attribute, attributeValue);
    }

    protected void SetClassAttribute(TagHelperOutput output, string attributeValue)
    {
      output.Attributes.SetAttribute(HtmlAttributes.ClassAttribute, attributeValue);
    }

    protected void UpdateClasses(TagHelperOutput output)
    {
      var space = " ";
      var prepended = "";
      var classesFromUser = string.IsNullOrWhiteSpace(Classes) ? "" : Classes;

      foreach (var item in ClassesToPrepend)
      {
        prepended += item + space;
      }

      var classes = prepended.Trim()
                    + (string.IsNullOrWhiteSpace(classesFromUser) ? "" : space + classesFromUser); 

      SetClassAttribute(output, classes);
    }
  }
}
