# Input

## Guidance

Find out more about the input component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/text-input).

## Quick start examples

### Input

[Preview the input component](https://dotnetcorefelpoc.azurewebsites.net/components/input)

#### HTML markup

```html
<div class="nhsuk-form-group">
  <label class="nhsuk-label" for="input-example">
    National Insurance number
  </label>
  <input class="nhsuk-input" id="input-example" name="test-name" type="text">
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Standard">
  <label nhs-label-type="Standard" for="input-example">National insurance number</label>
  <input nhs-input-type="Standard" id="input-example" name="test-name"/>
</nhs-form-group>
```
---

### Input with autocomplete attribute

[Preview the input with autocomplete attribute component](https://dotnetcorefelpoc.azurewebsites.net/components/input-autocomplete)

#### Guidance

See [Autofilling form controls: the autocomplete attribute](https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofill) for the full list of attributes that can be used.

#### HTML markup

```html
<div class="nhsuk-form-group">
  <label class="nhsuk-label" for="input-with-autocomplete-attribute">
  Postcode
  </label>
  <input class="nhsuk-input" id="input-with-autocomplete-attribute" name="postcode" type="text" autocomplete="postal-code">
</div>
```
#### Taghelper markup
```
<nhs-form-group nhs-form-group-type="Standard">
  <label nhs-label-type="Standard" for="input-with-autocomplete-attribute">Postcode</label>
  <input nhs-input-type="Standard" id="input-with-autocomplete-attribute" name="postcode" autocomplete="postal-code"/>
</nhs-form-group>
```
---

### Input with hint text

[Preview the input with hint text component](https://dotnetcorefelpoc.azurewebsites.net/components/input-with-hint)

#### HTML markup

```html
<div class="nhsuk-form-group">
  <label class="nhsuk-label" for="input-with-hint-text">
  National insurance number
  </label>
  <span class="nhsuk-hint" id="input-with-hint-text-hint">
  It’s on your National Insurance card, benefit letter, payslip or P60. For example, ‘QQ 12 34 56 C’.
  </span>
  <input class="nhsuk-input" id="input-with-hint-text" name="test-name-2" type="text" aria-describedby="input-with-hint-text-hint">
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Standard">
  <label nhs-label-type="Standard" for="input-with-hint-text">National insurance number</label>
  <nhs-hint nhs-hint-type="Standard" id="input-with-hint-text-hint">It’s on your National Insurance card, benefit letter, payslip or P60. For example, ‘QQ 12 34 56 C’.</nhs-hint>
  <input nhs-input-type="Standard" id="input-with-hint-text" name="test-name-2" aria-describedby="input-with-hint-text-hint"/>
</nhs-form-group>

```
---

### Input with error message

[Preview the input with error message component](https://dotnetcorefelpoc.azurewebsites.net/components/input-with-error)

#### HTML markup

```html
<div class="nhsuk-form-group nhsuk-form-group--error">
  <label class="nhsuk-label" for="input-with-error-message">
  National Insurance number
  </label>
  <span class="nhsuk-hint" id="input-with-error-message-hint">
  It’s on your National Insurance card, benefit letter, payslip or P60. For example, ‘QQ 12 34 56 C’.
  </span>
  <span id="input-with-error-message-error" class="nhsuk-error-message">
  Error message goes here
  </span>
  <input class="nhsuk-input nhsuk-input--error" id="input-with-error-message" name="test-name-3" type="text" aria-describedby="input-with-error-message-hint input-with-error-message-error">
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Error">
  <label nhs-label-type="Standard" for="input-with-error-message">National insurance number</label>
  <nhs-hint nhs-hint-type="Standard" id="input-with-error-message-hint">It’s on your National Insurance card, benefit letter, payslip or P60. For example, ‘QQ 12 34 56 C’.</nhs-hint>
  <span nhs-span-type="ErrorMessage" id="input-with-error-message-error">Error message goes here</span>
  <input nhs-input-type="Standard" is-error-input="true" id="input-with-error-message" name="test-name-3" aria-describedby="input-with-error-message-hint input-with-error-message-error" />
</nhs-form-group>

```
---

### Input with width modifier

[Preview the input with width modifier component](https://dotnetcorefelpoc.azurewebsites.net/components/input-custom-width)

#### HTML markup

```html
<div class="nhsuk-form-group">
  <label class="nhsuk-label" for="input-width-10">
  National insurance number
  </label>
  <span class="nhsuk-hint" id="input-width-10-hint">
  It’s on your National Insurance card, benefit letter, payslip or P60. For example, ‘QQ 12 34 56 C’.
  </span>
  <input class="nhsuk-input nhsuk-input--width-10" id="input-width-10" name="test-width-10" type="text" aria-describedby="input-width-10-hint">
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Standard">
  <label nhs-label-type="Standard" for="input-width-10">National insurance number</label>
  <nhs-hint nhs-hint-type="Standard" id="input-width-10-hint">It’s on your National Insurance card, benefit letter, payslip or P60. For example, ‘QQ 12 34 56 C’.</nhs-hint>
  <input nhs-input-type="Standard" fixed-width="Ten" id="input-width-10" name="test-width-10" aria-describedby="input-width-10-hint"/>
</nhs-form-group>
```

---
### Taghelper attributes

| Name                | Type     | Required  | Description             |
| --------------------|----------|-----------|-------------------------|
| **id**              | string   | Yes       | The id of the input. |
| **name**            | string   | Yes       | The name of the input, which is submitted with the form data. |
| **fixed-width**            | string   | No        | For fixed width input.|
| **nhs-form-group**           | Taghelper   | Yes        | the formgroup wrapper for the input component.|
| **is-error-input**           | boolean   | No        | error input if set to true |
| **input**           | Taghelper   | Yes        | representing for the input control.|
| **nhs-input-type**           | string   | Yes        | input type e.g Radios, Checkboxes, Date|
| **label**           | Taghelper   | Yes        | The label taghelper.|
| **nhs-hint**            | Taghelper   | No        | The hint taghelper. |
| **span nhs-span-type="ErrorMessage"**    | Taghelper   | No        | The error message taghelper.|
| **classes**         | string   | No        | Optional additional classes add to the input taghelper. Separate each class with a space. |
| **autocomplete**    | string   | No        | Attribute to [identify input purpose](https://www.w3.org/WAI/WCAG21/Understanding/identify-input-purpose.html), for instance "postal-code" or "username". See [Autofilling form controls: the autocomplete attribute](https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofill) for the full list of attributes that can be used. |

This component and documentation has been taken from [NHS.UK Frontend - Input component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/input) .
