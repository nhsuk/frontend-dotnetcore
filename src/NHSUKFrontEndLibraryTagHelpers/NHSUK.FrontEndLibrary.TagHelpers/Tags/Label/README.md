# Label

To discuss or contribute to this component, visit the [GitHub issue for this component](https://github.com/nhsuk/nhsuk-frontend/issues/223).

## Quick start examples

### Label

[Preview the label component]()

#### HTML markup

```html
<label class="nhsuk-label">
  National Insurance number
</label>
```

#### Taghelper

```
<nhs-label nhs-label-type="Standard">National Insurance number</nhs-label>

```

---

### Label with bold text

[Preview the label with bold text component]()

#### HTML markup

```html
<label class="nhsuk-label nhsuk-label--s">
  National Insurance number
</label>
```

#### Taghelper

```
<nhs-label nhs-label-type="Bold">National Insurance number</nhs-label>

```

---

### Label as page heading

[Preview the label as page heading component]()

#### HTML markup

```html
<h1 class="nhsuk-label-wrapper">
  <label class="nhsuk-label nhsuk-label--xl">
    National Insurance number
  </label>
</h1>
```

#### Taghelper

```
<nhs-label nhs-label-type="PageHeading">National Insurance number</nhs-label>
```

---
### Taghelper 

The label taghelper takes the following attributes:

| Name                    | Type     | Required  | Description             |
| ------------------------|----------|-----------|-------------------------|
| **nhs-label-type**                | string   | Yes       | specifies the type of label e.g bold, large, medium, Standard etc  |
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Label component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/label) with a few minor adaptations.