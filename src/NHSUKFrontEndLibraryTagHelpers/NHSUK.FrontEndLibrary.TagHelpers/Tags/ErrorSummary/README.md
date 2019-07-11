# Error summary

## Guidance
Find out more about the error summary component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/error-summary).

## Quick start example

[Preview the error summary component](https://dotnetcorefelpoc.azurewebsites.net/components/error-summary)

### HTML markup

```html
<div class="nhsuk-error-summary" aria-labelledby="error-summary-title" role="alert" tabindex="-1" data-module="error-summary">
  <h2 class="nhsuk-error-summary__title" id="error-summary-title">
    There is a problem
  </h2>
  <div class="nhsuk-error-summary__body">
    <p>
      Optional description of the errors and how to correct them
    </p>
    <ul class="nhsuk-list nhsuk-error-summary__list">
      <li>
        <a href="#example-error-1">Link to error with explanation</a>
      </li>
      <li>
        <a href="#example-error-1">Link to error with explanation</a>
      </li>
    </ul>
  </div>
</div>
```

### Taghelper markup

```
<nhs-error-summary title-text="There is a problem" title-id="error-summary-title" description-text="Optional description of the errors and how to correct them" 
role="alert" tabindex="-1" data-module="error-summary">
  <li>
    <a href="#example-error-1">Link to error with explanation</a>
  </li>
  <li>
    <a href="#example-error-1">Link to error with explanation</a>
  </li>
</nhs-error-summary>
```

### Taghelper attributes

| Name                           | Type     | Required  | Description             |
| ------------------------------|----------|-----------|-------------------------|
| **title-id**  | string   | Yes       | id to use for the heading of the error summary block. |
|**title-text**  | string   | Yes       | Text to use for the heading of the error summary block. |
| **description-text**                       | string   | No       | Optional text description of the errors. |
| **li**                       | html   | Yes       | html list element representing an error summary list item. |
| **classes**                   | string   | No        | Optional additional classes to add to the error-summary container. Separate each class with a space. |


This component and documentation has been taken from [NHS.UK Frontend - Error summary component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/error-summary) .
