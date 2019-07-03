using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Layout;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit.TagHelpers
{
    public class NhsGridRowTagHelperTests
    {
        private readonly TagHelperOutput _tagHelperOutput;
        public NhsGridRowTagHelperTests()
        {
            var tagHelper = new NhsGridRowTagHelper();
            var tagHelperContext = new TagHelperContext(
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

            tagHelper.Process(tagHelperContext, _tagHelperOutput);
        }

        [Fact]
        public void Process_Should_Set_TagName()
        {
            Assert.Equal(HtmlElements.Div, _tagHelperOutput.TagName);
        }

        [Fact]
        public void Process_Should_Set_ClassAttribute()
        {
            Assert.Equal(CssClasses.NhsUkGridRow, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
        }

        [Fact]
        public void Process_Should_Set_TagMode()
        {
            Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
        }
    }
}
