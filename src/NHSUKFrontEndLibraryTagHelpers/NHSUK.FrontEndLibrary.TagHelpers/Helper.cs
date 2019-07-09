using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;

namespace NHSUK.FrontEndLibrary.TagHelpers
{
  public static class Helper
  {
    internal static List<string> ClassesToPrepend = new List<string>();

    internal static void SetAttribute(TagHelperOutput output, string attribute, string attributeValue)
    {
      output.Attributes.SetAttribute(attribute, attributeValue);
    }

    internal static void SetClassAttribute(TagHelperOutput output, string attributeValue)
    {
      output.Attributes.SetAttribute(HtmlAttributes.ClassAttribute, attributeValue);
    }

    internal static void UpdateClasses(TagHelperOutput output, string classesFromUser)
    {
      var space = " ";
      var prepended = "";
      classesFromUser = string.IsNullOrWhiteSpace(classesFromUser) ? "" : classesFromUser;

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
