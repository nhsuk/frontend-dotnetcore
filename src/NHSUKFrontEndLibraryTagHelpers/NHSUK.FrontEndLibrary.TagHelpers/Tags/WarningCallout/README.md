# Warning callout

## Guidance

Find out more about the warning callout component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/warning-callout).

## Quick start example

[Preview the warning callout component](https://dotnetcorefelpoc.azurewebsites.net/components/warning-callout)

### HTML markup

```html
<div class="nhsuk-warning-callout">
  <h3 class="nhsuk-warning-callout__label">School, nursery or work</h3>
  <p>Stay away from school, nursery or work until all the spots have crusted over. This is usually 5 days after the spots first appeared.</p>
</div>
```

### Taghelper markup

```
<nhs-warning-callout title-text="School, nursery or work">
  <p>Stay away from school, nursery or work until all the spots have crusted over. This is usually 5 days after the spots first appeared.</p>
</nhs-warning-callout>
```

### Taghelper attributes

The warning callout taghelper markup takes the following attributes:

| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **title-text**             | string   | Yes       | Heading to be used within the warning callout component. |
| **classes**             | string   | No        | Optional additional classes to add to the warning callout. Separate each class with a space. |
