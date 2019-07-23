# Select

## Guidance

Find out more about the select component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/select).

## Quick start examples

### Select

[Preview the select component](https://dotnetcorefelpoc.azurewebsites.net/components/select)

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
<nhs-form-group nhs-form-group-type="Standard">
  <label nhs-label-type="Standard" for="select-1">Label text goes here</label>
  <select nhs-select-type="Standard" id="select-1" name="select-1">
    <option value="1">NHS.UK frontend option 1</option>
    <option value="2" selected>NHS.UK frontend option 2</option>
    <option value="3" disabled>NHS.UK frontend option 3</option>
  </select>
</nhs-form-group>

```

---

### Select with hint text and error message

[Preview the select with hint text and error message component](https://dotnetcorefelpoc.azurewebsites.net/components/select-hint-error)

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
<nhs-form-group nhs-form-group-type="Error">
  <label nhs-label-type="Standard" for="select-2">Label text goes here</label>
  <nhs-hint nhs-hint-type="Standard" id="select-2-hint">Hint text goes here</nhs-hint>
  <span nhs-span-type="ErrorMessage" id="select-2-error">Error message goes here</span>
  <select nhs-select-type="Error" id="select-2" name="select-2" aria-describedby="select-2-hint select-2-error">
    <option value="1">NHS.UK frontend option 1</option>
    <option value="2">NHS.UK frontend option 2</option>
    <option value="3">NHS.UK frontend option 3</option>
  </select>
</nhs-form-group>
```
---

### Taghelper attributes

The select taghelper markup takes the following attributes:

| Name                | Type     | Required  | Description                 |
| --------------------|----------|-----------|-----------------------------|
| **nhs-form-group**           | Taghelper   | Yes        | The formgroup taghelper wrapper for the radios component.|
| **id**              | string   | Yes       | The id for each select box. |
| **name**            | string   | Yes       | The name of the select, which is submitted with the form data. |
| **label**           | Taghelper   | No       | Optional label taghelper. See [label](https://github.com/nhsuk/frontend-dotnetcore/tree/master/src/NHSUKFrontEndLibraryTagHelpers/NHSUK.FrontEndLibrary.TagHelpers/Tags/Label) taghelper. |
| **nhs-hint**            | Taghelper   | No        | The hint taghelper. See [hint](https://github.com/nhsuk/frontend-dotnetcore/tree/master/src/NHSUKFrontEndLibraryTagHelpers/NHSUK.FrontEndLibrary.TagHelpers/Tags/Hint) taghelper. |
| **span nhs-span-type="ErrorMessage"**    | Tagheler   | No        | The errorMessage taghelper. See [error message](https://github.com/nhsuk/frontend-dotnetcore/tree/master/src/NHSUKFrontEndLibraryTagHelpers/NHSUK.FrontEndLibrary.TagHelpers/Tags/ErrorMessage) taghelper. |
| **classes**         | string   | No        | Optional additional classes to add to the select component. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Select component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/select) .
