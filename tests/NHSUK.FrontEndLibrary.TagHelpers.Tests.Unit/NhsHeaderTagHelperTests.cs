using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NHSUK.FrontEndLibrary.TagHelpers.Constants;
using NHSUK.FrontEndLibrary.TagHelpers.Tags.Header;
using Xunit;

namespace NHSUK.FrontEndLibrary.TagHelpers.Tests.Unit
{
  public class NhsHeaderTagHelperTests
  {
    private TagHelperOutput _tagHelperOutput;
    private TagHelperContext _tagHelperContext;
    private readonly NhsHeaderTagHelper _tagHelper;
    private string _serviceName = "Gp Practice";
    private string taghelperNavContent = "<nhs-header-navigation>< nhs-header-nav-item " +
                                      "href=\"https://www.nhs.uk/conditions\">" +
                                      "Health A-Z</nhs-header-nav-item></nhs-header-navigation>";
    public NhsHeaderTagHelperTests()
    {
      _tagHelper = new NhsHeaderTagHelper();
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
    public async void ProcessAsync_Should_Set_TagName()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlElements.Header, _tagHelperOutput.TagName);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Standard_HeaderType_ClassAttribute()
    {
      _tagHelper.HeaderType = HeaderType.Standard;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkHeader, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_IdAttribute()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(HtmlAttributes.AttributeValues.Banner, _tagHelperOutput.Attributes[HtmlAttributes.Role].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_Transactional_HeaderType_ClassAttribute()
    {
      _tagHelper.HeaderType = HeaderType.Transactional;
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(CssClasses.NhsUkHeaderTransactional, _tagHelperOutput.Attributes[HtmlAttributes.ClassAttribute].Value);
    }

    [Fact]
    public async void ProcessAsync_Should_Set_TagMode()
    {
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      Assert.Equal(TagMode.StartTagAndEndTag, _tagHelperOutput.TagMode);
    }

    [Theory]
    [InlineData(HeaderType.Standard)]
    [InlineData((HeaderType)(-1))]
    public async void Standard_HeaderType_ServiceName_Should_Set_Logo_ServiceNameElement(HeaderType headerType)
    {
      _tagHelper.ServiceName = _serviceName;
      _tagHelper.HeaderType = headerType;
      var expected = string.Format(
        "<div class=\"nhsuk-width-container nhsuk-header__container\"><div class=\"nhsuk-header__logo\">" +
        "<a class=\"{0}\" href=\"/\"aria-label=\"NHS homepage\"> " +
        "<svg class=\"nhsuk-logo nhsuk-logo--white\"xmlns=\"http://www.w3.org/2000/svg\" role=\"presentation\" focusable=\"false\" " +
        "viewBox=\"0 0 40 16\"> <path fill =\"#fff\" d=\"M0 0h40v16H0z\"></path> <path fill =\"#005eb8\" " +
        "d=\"M3.9 1.5h4.4l2.6 9h.1l1.8-9h3.3l-2.8 13H9l-2.7-9h-.1l-1.8 9H1.1M17.3 1.5h3.6l-1 4.9h4L25 1.5h3.5l-2.7 13h-3.5l1.1-5.6h-4.1l-1.2 5.6h-3.4M37.7 4.4c-.7-.3-1.6-.6-2.9-.6-1.4 0-2.5.2-2.5 1.3 0 1.8 5.1 1.2 5.1 5.1 0 3.6-3.3 4.5-6.4 4.5-1.3 0-2.9-.3-4-.7l.8-2.7c.7.4 2.1.7 3.2.7s2.8-.2 2.8-1.5c0-2.1-5.1-1.3-5.1-5 0-3.4 2.9-4.4 5.8-4.4 1.6 0 3.1.2 4 .6\">" +
        "</path> <image src =\"https://assets.nhs.uk/images/nhs-logo.png\" xlink:href=\"\"></image></svg><span class=\"nhsuk-header__service-name\">" +
        "{1}</span></a></div></div>", CssClasses.NhsUkHeaderLinkService, _serviceName);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      var actual = _tagHelperOutput.PreContent.GetContent();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public async void Transactional_HeaderType_ServiceName_Should_Set_TransactionaServiceElement()
    {
      _tagHelper.ServiceName = _serviceName;
      _tagHelper.ServiceHref = "www.gp.com";
      _tagHelper.ShowSearch = false;
      _tagHelper.HeaderType = HeaderType.Transactional;
      var expected = string.Format(
        "<div class=\"nhsuk-width-container nhsuk-header__container\"><div class=\"nhsuk-header__logo\">" +
        "<a class=\"nhsuk-header__link\" href=\"/\"aria-label=\"NHS homepage\"> <svg class=\"nhsuk-logo nhsuk-logo--white\"" +
        "xmlns=\"http://www.w3.org/2000/svg\" role=\"presentation\" focusable=\"false\" viewBox=\"0 0 40 16\"> <path fill =\"#fff\" d=\"M0 0h40v16H0z\"></path> <path fill =\"#005eb8\" " +
        "d=\"M3.9 1.5h4.4l2.6 9h.1l1.8-9h3.3l-2.8 13H9l-2.7-9h-.1l-1.8 9H1.1M17.3 1.5h3.6l-1 4.9h4L25 1.5h3.5l-2.7 13h-3.5l1.1-5.6h-4.1l-1.2 5.6h-3.4M37.7 4.4c-.7-.3-1.6-.6-2.9-.6-1.4 0-2.5.2-2.5 1.3 0 1.8 5.1 1.2 5.1 5.1 0 3.6-3.3 4.5-6.4 4.5-1.3 0-2.9-.3-4-.7l.8-2.7c.7.4 2.1.7 3.2.7s2.8-.2 2.8-1.5c0-2.1-5.1-1.3-5.1-5 0-3.4 2.9-4.4 5.8-4.4 1.6 0 3.1.2 4 .6\"></path>" +
        " <image src =\"https://assets.nhs.uk/images/nhs-logo.png\" xlink:href=\"\"></image></svg></a></div><div class=\"{0}\"><a class=\"nhsuk-header__transactional-service-name--link\" " +
        "href=\"{1}\">{2}</a></div></div>", CssClasses.NhsUkTransactionalServiceName, "www.gp.com", _serviceName);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      var actual = _tagHelperOutput.PreContent.GetContent();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public async void Transactional_HeaderType_ShowSearch_Should_Set_Logo_Only()
    {
      _tagHelper.ServiceName = _serviceName;
      _tagHelper.ShowSearch = true;
      _tagHelper.HeaderType = HeaderType.Transactional;
      var expected = string.Format(
        "<div class=\"nhsuk-width-container nhsuk-header__container\"><div class=\"nhsuk-header__logo\">" +
        "<a class=\"{0}\" href=\"/\"aria-label=\"NHS homepage\"> <svg class=\"nhsuk-logo nhsuk-logo--white\"" +
        "xmlns=\"http://www.w3.org/2000/svg\" role=\"presentation\" focusable=\"false\" viewBox=\"0 0 40 16\"> <path fill =\"#fff\" " +
        "d=\"M0 0h40v16H0z\"></path> <path fill =\"#005eb8\" d=\"M3.9 1.5h4.4l2.6 9h.1l1.8-9h3.3l-2.8 13H9l-2.7-9h-.1l-1.8 9H1.1M17.3 1.5h3.6l-1 4.9h4L25" +
        " 1.5h3.5l-2.7 13h-3.5l1.1-5.6h-4.1l-1.2 5.6h-3.4M37.7 4.4c-.7-.3-1.6-.6-2.9-.6-1.4 0-2.5.2-2.5 1.3 0 1.8 5.1 1.2 5.1 5.1 0 3.6-3.3 4.5-6.4 4.5-1.3" +
        " 0-2.9-.3-4-.7l.8-2.7c.7.4 2.1.7 3.2.7s2.8-.2 2.8-1.5c0-2.1-5.1-1.3-5.1-5 0-3.4 2.9-4.4 5.8-4.4 1.6 0 3.1.2 4 .6\"></path>" +
        " <image src =\"https://assets.nhs.uk/images/nhs-logo.png\" xlink:href=\"\"></image></svg></a></div></div>", 
         CssClasses.NhsUkHeaderLink);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      var actual = _tagHelperOutput.PreContent.GetContent();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public async void Transactional_HeaderType_NavItem_ShowSearch_Should_Set_Logo_Only()
    {
      _tagHelper.ServiceName = _serviceName;
      _tagHelper.ShowSearch = true;
      _tagHelper.HeaderType = HeaderType.Transactional;
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList(),
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
        new TagHelperAttributeList(),
        (useCachedResult, encoder) =>
        {
          var tagHelperContent = new DefaultTagHelperContent();
          return Task.FromResult(tagHelperContent.SetHtmlContent(taghelperNavContent));
        });

      var expected = string.Format(
        "<div class=\"nhsuk-width-container nhsuk-header__container\"><div class=\"nhsuk-header__logo\">" +
        "<a class=\"{0}\" href=\"/\"aria-label=\"NHS homepage\"> <svg class=\"nhsuk-logo nhsuk-logo--white\"" +
        "xmlns=\"http://www.w3.org/2000/svg\" role=\"presentation\" focusable=\"false\" viewBox=\"0 0 40 16\"> <path fill =\"#fff\" " +
        "d=\"M0 0h40v16H0z\"></path> <path fill =\"#005eb8\" d=\"M3.9 1.5h4.4l2.6 9h.1l1.8-9h3.3l-2.8 13H9l-2.7-9h-.1l-1.8 9H1.1M17.3 1.5h3.6l-1 4.9h4L25" +
        " 1.5h3.5l-2.7 13h-3.5l1.1-5.6h-4.1l-1.2 5.6h-3.4M37.7 4.4c-.7-.3-1.6-.6-2.9-.6-1.4 0-2.5.2-2.5 1.3 0 1.8 5.1 1.2 5.1 5.1 0 3.6-3.3 4.5-6.4 4.5-1.3" +
        " 0-2.9-.3-4-.7l.8-2.7c.7.4 2.1.7 3.2.7s2.8-.2 2.8-1.5c0-2.1-5.1-1.3-5.1-5 0-3.4 2.9-4.4 5.8-4.4 1.6 0 3.1.2 4 .6\"></path>" +
        " <image src =\"https://assets.nhs.uk/images/nhs-logo.png\" xlink:href=\"\"></image></svg></a></div></div>",
        CssClasses.NhsUkHeaderLink);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      var actual = _tagHelperOutput.PreContent.GetContent();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public async void Transactional_HeaderType_LongServiceName_Should_Set_TransactionaServiceElement()
    {
      _tagHelper.ServiceName = "Find out why your NHS data matters";
      _tagHelper.ShowSearch = false;
      _tagHelper.ServiceHref = "www.gp.com";
      _tagHelper.HeaderType = HeaderType.Transactional;
      var expected = string.Format(
        "<div class=\"nhsuk-width-container nhsuk-header__container\"><div class=\"nhsuk-header__logo\"><a class=\"nhsuk-header__link\" href=\"/\"" +
        "aria-label=\"NHS homepage\"> <svg class=\"nhsuk-logo nhsuk-logo--white\"xmlns=\"http://www.w3.org/2000/svg\" role=\"presentation\" focusable=\"false\"" +
        " viewBox=\"0 0 40 16\"> <path fill =\"#fff\" d=\"M0 0h40v16H0z\"></path> <path fill =\"#005eb8\" d=\"M3.9 1.5h4.4l2.6 9h.1l1.8-9h3.3l-2.8 13H9l-2.7-9h-.1l-1.8" +
        " 9H1.1M17.3 1.5h3.6l-1 4.9h4L25 1.5h3.5l-2.7 13h-3.5l1.1-5.6h-4.1l-1.2 5.6h-3.4M37.7 4.4c-.7-.3-1.6-.6-2.9-.6-1.4 0-2.5.2-2.5 1.3 0 1.8 5.1 1.2 5.1 5.1 0 3.6-3.3 4.5-6.4" +
        " 4.5-1.3 0-2.9-.3-4-.7l.8-2.7c.7.4 2.1.7 3.2.7s2.8-.2 2.8-1.5c0-2.1-5.1-1.3-5.1-5 0-3.4 2.9-4.4 5.8-4.4 1.6 0 3.1.2 4 .6\"></path> <image src =\"https://assets.nhs.uk/images/nhs-logo.png\"" +
        " xlink:href=\"\"></image></svg></a></div><div class=\"{0}\">" +
        "<a class=\"nhsuk-header__transactional-service-name--link\" href=\"www.gp.com\">Find out why your NHS data matters</a></div></div>", CssClasses.NhsUkTransactionalServiceNameLong);

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      var actual = _tagHelperOutput.PreContent.GetContent();
      Assert.Equal(expected, actual);
    }


    [Fact]
    public async void NavItem_And_ShowSearch_False_Should_Set_ContentMenuOnly_Toggle()
    {
      _tagHelper.HeaderType = HeaderType.Standard;
      _tagHelper.ShowSearch = false;
      _tagHelper.ShowNav = true;
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList(),
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
        new TagHelperAttributeList(),
        (useCachedResult, encoder) =>
        {
          var tagHelperContent = new DefaultTagHelperContent();
          return Task.FromResult(tagHelperContent.SetHtmlContent(taghelperNavContent));
        });

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      var expected = string.Format("<div class=\"nhsuk-width-container nhsuk-header__container\">" +
                     "<div class=\"nhsuk-header__logo\"><a class=\"nhsuk-header__link\" href=\"/\"aria-label=\"NHS homepage\"> <svg class=\"nhsuk-logo nhsuk-logo--white\"xmlns=\"http://www.w3.org/2000/svg\" role=\"presentation\" focusable=\"false\" viewBox=\"0 0 40 16\">" +
                     " <path fill =\"#fff\" d=\"M0 0h40v16H0z\"></path> <path fill =\"#005eb8\" d=\"M3.9 1.5h4.4l2.6 9h.1l1.8-9h3.3l-2.8 13H9l-2.7-9h-.1l-1.8 9H1.1M17.3 1.5h3.6l-1 4.9h4L25 1.5h3.5l-2.7 13h-3.5l1.1-5.6h-4.1l-1.2 5.6h-3.4M37.7 4.4c-.7-.3-1.6-.6-2.9-.6-1.4 0-2.5.2-2.5 1.3 0 1.8 5.1 1.2 5.1 5.1 0 3.6-3.3 4.5-6.4 4.5-1.3 0-2.9-.3-4-.7l.8-2.7c.7.4 2.1.7 3.2.7s2.8-.2 2.8-1.5c0-2.1-5.1-1.3-5.1-5 0-3.4 2.9-4.4 5.8-4.4 1.6 0 3.1.2 4 .6\"></path>" +
                     " <image src =\"https://assets.nhs.uk/images/nhs-logo.png\" xlink:href=\"\"></image></svg></a></div><div class=\"nhsuk-header__content\" id=\"content-header\"><div class=\"{0}\"><button class=\"nhsuk-header__menu-toggle\"" +
                     " id=\"toggle-menu\" aria-controls=\"header-navigation\" aria-label=\"Open menu\">Menu</button></div></div></div>", CssClasses.NhsUkHeaderMenuOnly);
      var actual = _tagHelperOutput.PreContent.GetContent();
      Assert.Equal(expected, actual);
    }


    [Fact]
    public async void NavItem_And_ShowSearch_True_Should_Set_ContentMenu_Toggle()
    {
      var href = "www.nhs.uk";
     var ariaLabel = "the NHS";
      _tagHelper.HeaderType = HeaderType.Standard;
      _tagHelper.ShowSearch = true;
      _tagHelper.ShowNav = true;
      _tagHelper.LogoHref = href;
      _tagHelper.LogoAriaLabel = ariaLabel;
      _tagHelperContext = new TagHelperContext(
        new TagHelperAttributeList(),
        new Dictionary<object, object>(),
        Guid.NewGuid().ToString("N"));
      _tagHelperOutput = new TagHelperOutput(string.Empty,
        new TagHelperAttributeList(),
        (useCachedResult, encoder) =>
        {
          var tagHelperContent = new DefaultTagHelperContent();
          return Task.FromResult(tagHelperContent.SetHtmlContent(taghelperNavContent));
        });

      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      var expected = string.Format("<div class=\"nhsuk-width-container nhsuk-header__container\"><div class=\"nhsuk-header__logo\">" +
        "<a class=\"nhsuk-header__link\" href=\"{0}\"aria-label=\"{1}\"> <svg class=\"nhsuk-logo nhsuk-logo--white\"xmlns=\"http://www.w3.org/2000/svg\"" +
        " role=\"presentation\" focusable=\"false\" viewBox=\"0 0 40 16\"> <path fill =\"#fff\" d=\"M0 0h40v16H0z\">" +
        "</path> <path fill =\"#005eb8\" d=\"M3.9 1.5h4.4l2.6 9h.1l1.8-9h3.3l-2.8 13H9l-2.7-9h-.1l-1.8 9H1.1M17.3 1.5h3.6l-1 4.9h4L25 1.5h3.5l-2.7 13h-3.5l1.1-5.6h-4.1l-1.2 5.6h-3.4M37.7 4.4c-.7-.3-1.6-.6-2.9-.6-1.4 0-2.5.2-2.5 1.3 0 1.8 5.1 1.2 5.1 5.1 0 3.6-3.3 4.5-6.4 4.5-1.3 0-2.9-.3-4-.7l.8-2.7c.7.4 2.1.7 3.2.7s2.8-.2 2.8-1.5c0-2.1-5.1-1.3-5.1-5 0-3.4 2.9-4.4 5.8-4.4 1.6 0 3.1.2 4 .6\">" +
        "</path> <image src =\"https://assets.nhs.uk/images/nhs-logo.png\" xlink:href=\"\"></image></svg></a></div><div class=\"nhsuk-header__content\" id=\"content-header\">" +
        "<div class=\"{2}\"><button class=\"nhsuk-header__menu-toggle\" id=\"toggle-menu\" aria-controls=\"header-navigation\" " +
        "aria-label=\"Open menu\">Menu</button></div><div class=\"nhsuk-header__search\"><button class=\"nhsuk-header__search-toggle\" id=\"toggle-search\" aria-controls=\"search\" " +
        "aria-label=\"Open search\"><svg class=\"nhsuk-icon nhsuk-icon__search\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" aria-hidden=\"true\" focusable=\"false\"><path d=\"M19.71 18.29l-4.11-4.1a7 7 0 1 0-1.41 1.41l4.1 4.11a1 1 0 0 0 1.42 0 1 1 0 0 0 0-1.42zM5 10a5 5 0 1 1 5 5 5 5 0 0 1-5-5z\" >" +
        "</path></svg><span class=\"nhsuk-u-visually-hidden\">Search</span></button><div class=\"nhsuk-header__search-wrap\" id=\"wrap-search\"><form class=\"nhsuk-header__search-form\" id=\"search\" " +
        "action=\"/search/\" method=\"get\" role=\"search\"><label class=\"nhsuk-u-visually-hidden\" for=\"search-field\">Search the NHS website</label><div class=\"autocomplete-container\"" +
         " id=\"autocomplete-container\"></div><input class=\"nhsuk-search__input\" id=\"search-field\" name=\"search-field\" type=\"search\" placeholder=\"Search\" autocomplete=\"off\">" +
         "<button class=\"nhsuk-search__submit\" type=\"submit\"><svg class=\"nhsuk-icon nhsuk-icon__search\" xmlns=\"http://www.w3.org/2000/svg\" " +
         "viewBox=\"0 0 24 24\" aria-hidden=\"true\" focusable=\"false\"><path d=\"M19.71 18.29l-4.11-4.1a7 7 0 1 0-1.41 1.41l4.1 4.11a1 1 0 0 0 1.42 0 1 1 0 0 0 0-1.42zM5 10a5 5 0 1 1 5 5 5 5 0 0 1-5-5z\" >" +
         "</path></svg><span class=\"nhsuk-u-visually-hidden\">Search</span></button><button class=\"nhsuk-search__close\" id=\"close-search\"><svg class=\"nhsuk-icon nhsuk-icon__close\" " +
         "xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" aria-hidden=\"true\" focusable=\"false\"><path d= \"M13.41 12l5.3-5.29a1 1 0 1 0-1.42-1.42L12 10.59l-5.29-5.3a1 1 0 0 0-1.42 1.42l5.3 5.29-5.3 5.29a1 1 0 0 0 0 1.42 1 1 0 0 0 1.42 0l5.29-5.3 5.29 5.3a1 1 0 0 0 1.42 0 1 1 0 0 0 0-1.42z\" >" +
         "</path></svg><span class=\"nhsuk-u-visually-hidden\">Close search</span></button></form></div></div></div></div>",
         href, ariaLabel, CssClasses.NhsUkHeaderMenu);
      var actual = _tagHelperOutput.PreContent.GetContent();
      Assert.Equal(expected, actual);
    }

    [Fact]
    public async void ShowSearch_Only_Should_Set_ContentMenu_Search_Only()
    {
      var href = "www.nhs.uk";
      var ariaLabel = "the NHS";
      _tagHelper.HeaderType = HeaderType.Standard;
      _tagHelper.ShowSearch = true;
      _tagHelper.LogoHref = href;
      _tagHelper.LogoAriaLabel = ariaLabel;
     
      await _tagHelper.ProcessAsync(_tagHelperContext, _tagHelperOutput);
      var expected = 
        "<div class=\"nhsuk-width-container nhsuk-header__container\">" +
        "<div class=\"nhsuk-header__logo\"><a class=\"nhsuk-header__link\" href=\"www.nhs.uk\"aria-label=\"the NHS\">" +
        " <svg class=\"nhsuk-logo nhsuk-logo--white\"xmlns=\"http://www.w3.org/2000/svg\" role=\"presentation\" focusable=\"false\" " +
        "viewBox=\"0 0 40 16\"> <path fill =\"#fff\" d=\"M0 0h40v16H0z\"></path> <path fill =\"#005eb8\" " +
        "d=\"M3.9 1.5h4.4l2.6 9h.1l1.8-9h3.3l-2.8 13H9l-2.7-9h-.1l-1.8 9H1.1M17.3 1.5h3.6l-1 4.9h4L25 1.5h3.5l-2.7" +
        " 13h-3.5l1.1-5.6h-4.1l-1.2 5.6h-3.4M37.7 4.4c-.7-.3-1.6-.6-2.9-.6-1.4 0-2.5.2-2.5 1.3 0 1.8 5.1 1.2 5.1 5.1 " +
        "0 3.6-3.3 4.5-6.4 4.5-1.3 0-2.9-.3-4-.7l.8-2.7c.7.4 2.1.7 3.2.7s2.8-.2 2.8-1.5c0-2.1-5.1-1.3-5.1-5 0-3.4 2.9-4.4 5.8-4.4 1.6 0 3.1.2 4 .6\">" +
        "</path> <image src =\"https://assets.nhs.uk/images/nhs-logo.png\" xlink:href=\"\"></image></svg></a></div><div class=\"nhsuk-header__content\" " +
        "id=\"content-header\"><div class=\"nhsuk-header__search\"><button class=\"nhsuk-header__search-toggle\" id=\"toggle-search\" aria-controls=\"search\" " +
        "aria-label=\"Open search\"><svg class=\"nhsuk-icon nhsuk-icon__search\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" aria-hidden=\"true\" " +
        "focusable=\"false\"><path d=\"M19.71 18.29l-4.11-4.1a7 7 0 1 0-1.41 1.41l4.1 4.11a1 1 0 0 0 1.42 0 1 1 0 0 0 0-1.42zM5 10a5 5 0 1 1 5 5 5 5 0 0 1-5-5z\" >" +
        "</path></svg><span class=\"nhsuk-u-visually-hidden\">Search</span></button><div class=\"nhsuk-header__search-wrap\" id=\"wrap-search\"><form class=\"nhsuk-header__search-form\"" +
        " id=\"search\" action=\"/search/\" method=\"get\" role=\"search\"><label class=\"nhsuk-u-visually-hidden\" for=\"search-field\">Search the NHS website</label><div class=\"autocomplete-container\"" +
        " id=\"autocomplete-container\"></div><input class=\"nhsuk-search__input\" id=\"search-field\" name=\"search-field\" type=\"search\" placeholder=\"Search\" autocomplete=\"off\">" +
        "<button class=\"nhsuk-search__submit\" type=\"submit\"><svg class=\"nhsuk-icon nhsuk-icon__search\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" aria-hidden=\"true\" " +
        "focusable=\"false\"><path d=\"M19.71 18.29l-4.11-4.1a7 7 0 1 0-1.41 1.41l4.1 4.11a1 1 0 0 0 1.42 0 1 1 0 0 0 0-1.42zM5 10a5 5 0 1 1 5 5 5 5 0 0 1-5-5z\" ></path></svg><span " +
        "class=\"nhsuk-u-visually-hidden\">Search</span></button><button class=\"nhsuk-search__close\" id=\"close-search\"><svg class=\"nhsuk-icon nhsuk-icon__close\" " +
        "xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 24 24\" aria-hidden=\"true\" focusable=\"false\"><path d= \"M13.41 12l5.3-5.29a1 1 0 1 0-1.42-1.42L12 10.59l-5.29-5.3a1 1 " +
        "0 0 0-1.42 1.42l5.3 5.29-5.3 5.29a1 1 0 0 0 0 1.42 1 1 0 0 0 1.42 0l5.29-5.3 5.29 5.3a1 1 0 0 0 1.42 0 1 1 0 0 0 0-1.42z\" ></path></svg><span class=\"nhsuk-u-visually-hidden\">" +
        "Close search</span></button></form></div></div></div></div>";
      var actual = _tagHelperOutput.PreContent.GetContent();
      Assert.Equal(expected, actual);
    }

  }
}
