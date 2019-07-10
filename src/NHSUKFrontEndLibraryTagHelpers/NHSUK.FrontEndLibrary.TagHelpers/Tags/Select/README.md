# Select

## Guidance

Find out more about the select component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/select).

## Quick start examples

### Select

[Preview the select component]()

#### HTML markup

```html
<div class="nhsuk-form-group">
  <label class="nhsuk-label" for="select-1">
    Label text goes here
  </label>
  <select class="nhsuk-select" id="select-1" name="select-1">
    <option value="1">NHS.UK frontend option 1</option>
    <option value="2" selected>NHS.UK frontend option 2</option>
    <option value="3" disabled>NHS.UK frontend option 3</option>
  </select>
</div>
```

#### Taghelper markup

```

```

---

### Select with hint text and error message

[Preview the select with hint text and error message component]()

#### HTML markup

```html
<div class="nhsuk-form-group nhsuk-form-group--error">
  <label class="nhsuk-label" for="select-2">
  Label text goes here
  </label>
  <span class="nhsuk-hint" id="select-2-hint">
  Hint text goes here
  </span>
  <span id="select-2-error" class="nhsuk-error-message">
  Error message goes here
  </span>
  <select class="nhsuk-select nhsuk-select--error" id="select-2" name="select-2" aria-describedby="select-2-hint select-2-error">
    <option value="1">NHS.UK frontend option 1</option>
    <option value="2">NHS.UK frontend option 2</option>
    <option value="3">NHS.UK frontend option 3</option>
  </select>
</div>
```

#### Taghelper markup

```

```

---

### Taghelper attributes

The select taghelper markup takes the following attributes:

| Name                | Type     | Required  | Description                 |
| --------------------|----------|-----------|-----------------------------|
| **id**              | string   | Yes       | The id for each select box. |
| **name**            | string   | Yes       | The name of the select, which is submitted with the form data. |
| **items**           | array	   | Yes       | Array of option items for the select. |
| **item.value**      | string   | No        | Value for the option item. |
| **item.text**       | string   | No        | Text for the option item. |
| **item.selected**   | boolean  | No        | Sets the option as the selected. |
| **item.disabled**   | boolean  | No        | Sets the option item as disabled. |
| **item.attributes** | object   | No        | Any extra HTML attributes (for example data attributes) to the select option tag. |
| **label**           | object   | Yes       | Optional label text or HTML by specifying value for either text or html keys. See [label](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/label) component. |
| **hint**            | object   | No        | Arguments for the hint component (e.g. text). See [hint](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/hint) component. |
| **errorMessage**    | object   | No        | Arguments for the errorMessage component (e.g. text). See [error message](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/error-message) component. |
| **classes**         | string   | No        | Optional additional classes to add to the select component. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Select component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/select) with a few minor adaptations.