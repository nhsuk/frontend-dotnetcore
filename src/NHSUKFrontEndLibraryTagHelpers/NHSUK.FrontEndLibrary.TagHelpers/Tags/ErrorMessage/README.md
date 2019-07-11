# Error message

## Guidance
Find out more about the error message component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/error-message).

## Quick start example

[Preview the error message component](https://dotnetcorefelpoc.azurewebsites.net/components/error-message)

### HTML markup

```html
<span class="nhsuk-error-message">
  <span class="nhsuk-u-visually-hidden">Error:</span> 
  Error message about full name goes here
</span>
```

### Taghelper markup

```
<nhs-error-message>Error message about full name goes here</nhs-error-message>
```
### Taghelper attributes

The error message taghelper takes the following attributes:

| Name                      | Type     | Required  | Description             |
| --------------------------|----------|-----------|-------------------------|
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Error message component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/error-message) .
