# Fieldset

## Guidance

Find out more about the fieldset component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/fieldset).

## Quick start examples

### Fieldset

[Preview the fieldset component](https://dotnetcorefelpoc.azurewebsites.net/components/fieldset)

#### HTML markup

```html
<fieldset class="nhsuk-fieldset">
  <legend class="nhsuk-fieldset__legend">
    What is your address?
  </legend>
</fieldset>
```

#### Taghelper markup

```
<nhs-fieldset>
  <nhs-fieldset-legend nhs-legend-size="Standard">What is your address?</nhs-fieldset-legend>
</nhs-fieldset>
```

---

### Fieldset as page heading

[Preview the fieldset as page heading component](https://dotnetcorefelpoc.azurewebsites.net/components/fieldset-page-heading)

#### HTML markup

```html
<fieldset class="nhsuk-fieldset">
  <legend class="nhsuk-fieldset__legend nhsuk-fieldset__legend--xl">
    <h1 class="nhsuk-fieldset__heading">
      What is your address?
    </h1>
  </legend>
</fieldset>
```

#### Taghelper markup

```
<nhs-fieldset>
  <nhs-fieldset-legend nhs-legend-size="XLarge" is-page-heading="true">
    What is your address?
  </nhs-fieldset-legend>
</nhs-fieldset>
```

---

### Fieldset with input fields

[Preview the fieldset component with input fields](https://dotnetcorefelpoc.azurewebsites.net/components/fieldset-with-inputs)


#### HTML markup

```html
<fieldset class="nhsuk-fieldset">
  <legend class="nhsuk-fieldset__legend nhsuk-fieldset__legend--xl">
    <h1 class="nhsuk-fieldset__heading">
      What is your address?
    </h1>
  </legend>
  <div class="nhsuk-form-group">
    <label class="nhsuk-label" for="input-address1">
      Address line 1
    </label>
    <input class="nhsuk-input" id="input-address1" name="address1" type="text">
  </div>
  <div class="nhsuk-form-group">
    <label class="nhsuk-label" for="input-address2">
      Address line 2
    </label>
    <input class="nhsuk-input" id="input-address2" name="address2" type="text">
  </div>
  <div class="nhsuk-form-group">
    <label class="nhsuk-label" for="input-town-city">
      Town or city
    </label>
    <input class="nhsuk-input" id="input-town-city" name="town" type="text">
  </div>
  <div class="nhsuk-form-group">
    <label class="nhsuk-label" for="input-county">
      County
    </label>
    <input class="nhsuk-input" id="input-county" name="county" type="text">
  </div>
</fieldset>

```

#### Taghelper markup

```
<nhs-fieldset>
  <nhs-fieldset-legend nhs-legend-size="XLarge" is-page-heading="true">
    What is your address?
  </nhs-fieldset-legend>
  <nhs-form-group nhs-form-group-type="Standard">
    <label nhs-label-type="Standard" for="input-address1">Address line 1</label>
    <input nhs-input-type="Standard" id="input-address1" name="address1" type="text"/>
  </nhs-form-group>
  <nhs-form-group nhs-form-group-type="Standard">
    <label nhs-label-type="Standard" for="input-address2">Address line 2</label>
    <input nhs-input-type="Standard" id="input-address2" name="address2" type="text"/>
  </nhs-form-group>
  <nhs-form-group nhs-form-group-type="Standard">
    <label nhs-label-type="Standard" for="input-town-city">Town or city</label>
    <input nhs-input-type="Standard" id="input-town-city" name="town" type="text"/>
  </nhs-form-group>
  <nhs-form-group nhs-form-group-type="Standard">
    <label nhs-label-type="Standard" for="input-county">County</label>
    <input nhs-input-type="Standard" id="input-county" name="county" type="text"/>
  </nhs-form-group>
</nhs-fieldset>



```
### Taghelper attributes

| Name                      | Type     | Required  | Description             |
| --------------------------|----------|-----------|-------------------------|
| **nhs-form-group**           | Taghelper   | Yes        | The formgroup wrapper for input.|
| **nhs-fieldset-legend**             | Taghelper   | Yes        | Taghelper representing a fieldset legend. |
| **nhs-fieldset-legend nhs-legend-type**             | string   | Yes        | Fieldset heading type attribute e.g Standard, pageheading, large. |
| **nhs-fieldset-heading**             | Taghelper   | No        |  H1 wrapper for the fieldset legend text. |
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |

---

This component and documentation has been taken from [NHS.UK Frontend - Fieldset component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/fieldset) .
