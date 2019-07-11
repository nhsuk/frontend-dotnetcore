# Back link

## Guidance

Find out more about the back link component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/back-link).

## Quick start example

[Preview the back link component](https://dotnetcorefelpoc.azurewebsites.net/components/back-link)

### HTML markup

```html
<div class="nhsuk-back-link">
  <a class="nhsuk-back-link__link" href="#">
    <svg class="nhsuk-icon nhsuk-icon__chevron-left" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" aria-hidden="true">
      <path d="M8.5 12c0-.3.1-.5.3-.7l5-5c.4-.4 1-.4 1.4 0s.4 1 0 1.4L10.9 12l4.3 4.3c.4.4.4 1 0 1.4s-1 .4-1.4 0l-5-5c-.2-.2-.3-.4-.3-.7z"></path>
    </svg>
    Go back
  </a>
</div>
```

### Taghelper markup

```
<nhs-back-link href="#">Go back</nhs-back-link>
```

### Taghelper attributes

The back link taghelper takes the following attributes:

| Name                | Type     | Required  | Description             |
| --------------------|----------|-----------|-------------------------|
| **href**            | string   | Yes       | The value of the link href attribute. |
| **classes**         | string   | No        | Optional additional classes to add to the button element. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Back link component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/back-link) .