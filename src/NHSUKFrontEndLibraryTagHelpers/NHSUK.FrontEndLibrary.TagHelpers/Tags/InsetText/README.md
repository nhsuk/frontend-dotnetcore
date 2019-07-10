# Inset text

## Guidance

Find out more about the inset text component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/inset-text).

## Quick start example

[Preview the inset text component](https://dotnetcorefelpoc.azurewebsites.net/components/inset-text)

### HTML markup

```html
<div class="nhsuk-inset-text">
  <span class="nhsuk-u-visually-hidden">Information: </span>
  <p>You can report any suspected side effect to the <a href="https://yellowcard.mhra.gov.uk/" title="External website">UK safety scheme</a>.</p>
</div>
```

### Taghelper markup

```

```

### Taghelper attributes

The inset text taghelper takes the following attributes:

| Name                    | Type     | Required  | Description  |
| ------------------------|----------|-----------|--------------|
| **HTML**                | string   | Yes       | HTML content to be used within the inset text component. |
| **classes**             | string   | No        | Optional additional classes to add to the inset text container. Separate each class with a space. |
