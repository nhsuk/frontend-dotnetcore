# FormGroup

### HTML markup

```html
<div class="nhsuk-form-group">
  <label class="nhsuk-label" for="input-example">
    National Insurance number
  </label>
  <input class="nhsuk-input" id="input-example" name="test-name" type="text">
</div>
```

### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Standard">
  <label nhs-label-type="Standard" for="input-example">National insurance number</label>
  <input nhs-input-type="Standard" id="input-example" name="test-name"/>
</nhs-form-group>
```
### Taghelper attributes

| Name                      | Type     | Required  | Description             |
| --------------------------|----------|-----------|-------------------------|
| **nhs-label-type**             | string   | Yes        |  choose from standard or error. |
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |
