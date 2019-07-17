# Label

## Quick start examples

### Label

[Preview the label component](https://dotnetcorefelpoc.azurewebsites.net/components/label)

#### HTML markup

```html
<label class="nhsuk-label">
  National Insurance number
</label>
```

#### Taghelper markup

```
<label nhs-label-type="Standard">National Insurance number</label>

```

---

### Label with bold text

[Preview the label with bold text component](https://dotnetcorefelpoc.azurewebsites.net/components/label-bold)

#### HTML markup

```html
<label class="nhsuk-label nhsuk-label--s">
  National Insurance number
</label>
```

#### Taghelper markup

```
<label nhs-label-type="Bold">National Insurance number</label>

```

---

### Label as page heading

[Preview the label as page heading component](https://dotnetcorefelpoc.azurewebsites.net/components/label-page-heading)

#### HTML markup

```html
<h1 class="nhsuk-label-wrapper">
  <label class="nhsuk-label nhsuk-label--xl">
    National Insurance number
  </label>
</h1>
```

#### Taghelper markup

```
<label nhs-label-type="PageHeading">National Insurance number</label>
```

---
### Taghelper attributes

The label taghelper takes the following attributes:

| Name                    | Type     | Required  | Description             |
| ------------------------|----------|-----------|-------------------------|
| **nhs-label-type**                | string   | Yes       | specifies the type of label e.g bold, large, medium, Standard etc  |
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Label component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/label) .
