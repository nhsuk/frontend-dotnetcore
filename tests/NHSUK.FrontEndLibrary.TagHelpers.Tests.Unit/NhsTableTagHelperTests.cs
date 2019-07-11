using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Table;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsTableTagHelperTests
  {
    private readonly TagHelperOutput _tagHelperOutput;
    private readonly NhsTableTagHelper _tagHelper;
    private readonly TagHelperContext _tagHelperContext;
    private string titleText = "panel heading";

    public NhsTableTagHelperTests()
    {
      _tagHelper = new NhsTableTagHelper();
      _tagHelperContext = new TagHelperContext(
          new TagHelperAttributeList(),
          new Dictionary<object, object>(),
          Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
         new TagHelperAttributeList(),
         (useCachedResult, encoder) =>
         {
           var tagHelperContent = new DefaultTagHelperContent();
           return Task.FromResult<TagHelperContent>(tagHelperContent);
         });

    }

    [Fact]
    public void Process_Should_Set_TagName()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Table, _tagHelperOutput.TagName);
    }

    [Fact]
    public void Process_Should_Set_Caption_PreContent()
    {
      _tagHelper.Caption = "symptoms and treatment";
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("<caption class=\"nhsuk-table__caption\">symptoms and treatment</caption>", _tagHelperOutput.PreContent.GetContent());
    }

    [Fact]
    public void Process_Should_Set_WithPanel_PreElement()
    {
      _tagHelper.IsWithPanel = true;
      _tagHelper.TitleText = titleText;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("<div class=\"nhsuk-table__panel-with-heading-tab\">" +
                                 "<h3 class=\"nhsuk-table__heading-tab\">panel heading</h3><div class=\"nhsuk-table-responsive\">",
                                 _tagHelperOutput.PreElement.GetContent());
    }

    [Fact]
    public void Process_Should_Set_WithPanel_PostElement()
    {
      _tagHelper.IsWithPanel = true;
      _tagHelper.TitleText = titleText;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("</div></div>", _tagHelperOutput.PostElement.GetContent());
    }

    [Fact]
    public void Process_Should_Set_NoPanel_PreElement()
    {
      _tagHelper.IsWithPanel = false;
      _tagHelper.TitleText = titleText;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("<div class=\"nhsuk-table-responsive\">", _tagHelperOutput.PreElement.GetContent());
    }

    [Fact]
    public void Process_Should_Set_NoPanel_PostElement()
    {
      _tagHelper.IsWithPanel = false;
      _tagHelper.TitleText = titleText;
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal("</div>", _tagHelperOutput.PostElement.GetContent());
    }

 
    [Fact]
    public void Process_Should_Set_ClassAttribute()
    {
      _tagHelper.Process(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkTable, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public void Process_Should_Set_TagMode()
    {
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }
  }
}
