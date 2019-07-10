# Action link

## Guidance

Find out more about the action link component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/action-link).

## Quick start example

[Preview the action link component](https://dotnetcorefelpoc.azurewebsites.net/components/action-link)

### HTML markup

```html
<div class="nhsuk-action-link">
  <a class="nhsuk-action-link__link" href="https://www.nhs.uk/service-search/minor-injuries-unit/locationsearch/551">
    <svg class="nhsuk-icon nhsuk-icon__arrow-right-circle" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" aria-hidden="true">
      <path d="M0 0h24v24H0z" fill="none"></path>
      <path d="M12 2a10 10 0 0 0-9.95 9h11.64L9.74 7.05a1 1 0 0 1 1.41-1.41l5.66 5.65a1 1 0 0 1 0 1.42l-5.66 5.65a1 1 0 0 1-1.41 0 1 1 0 0 1 0-1.41L13.69 13H2.05A10 10 0 1 0 12 2z"></path>
    </svg>
    <span class="nhsuk-action-link__text">Find a minor injuries unit</span>
  </a>
</div>
```

### Taghelper markup

```
<nhs-action-link href="https://www.nhs.uk/service-search/minor-injuries-unit/locationsearch/551">
  Find a minor injuries unit
</nhs-action-link>
```

### Taghelper attributes

The action link taghelper takes the following attributes:

| Name             | Type     | Required  | Description |
| -----------------|----------|-----------|-------------|
| href             | string   | Yes       | The value of the link href attribute |
| open-in-new-window  | boolean  | No        | If set to true, then the link will open in a new window |
| classes          | string   | No        | Optional additional classes to add to the anchor tag. Separate each class with a space. |

