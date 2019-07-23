# Skip link

## Guidance

Find out more about the skip link component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/skip-link).

## Dependencies

There is an [in-page link bug in VoiceOver on iOS](https://bugs.webkit.org/show_bug.cgi?id=179011) whereby focus remains on the skip link anchor rather than
the next focusable element of the jumped to content.

This can be fixed by either including the compiled JavaScript for all components `nhsuk.min.js` or the individual component JavaScript `skip-link.js`.

The fix focuses on the first `H1` on the page if one exists. If one does not exist, then the default action for in-page links will take place.

Ensure the correct `id` value has been added to your main content for the skip link to work.

## Quick start example

[Preview the skip link component](https://dotnetcorefelpoc.azurewebsites.net/components/skip-link)

### HTML markup

```html
<a class="nhsuk-skip-link" href="#maincontent">Skip to main content</a>
```

### Taghelper markup

```
<a nhs-anchor-type="SkipLink" href="#maincontent">Skip to main content</a>
```

### Taghelper attributes

The skip link taghelper markup takes the following attributes:

| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **href**            | string   | No        | The value of the skip link href attribute. Default: "#maincontent". |
| **classes**         | string   | No        | Optional additional classes to add to the skip link. Separate each class with a space. |
