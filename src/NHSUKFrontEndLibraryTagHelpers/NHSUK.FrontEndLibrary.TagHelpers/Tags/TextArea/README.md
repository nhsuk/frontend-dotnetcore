# Textarea

To discuss or contribute to this component, visit the [GitHub issue for this component]().

## Guidance

Find out more about the textarea component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/textarea).

## Quick start examples

### Textarea

[Preview the textarea component]()

#### HTML markup

```html
<div class="nhsuk-form-group">
  <label class="nhsuk-label" for="more-detail">
  Can you provide more detail?
  </label>
  <span class="nhsuk-hint" id="more-detail-hint">
  Don&#39;t include personal or financial information, eg your National Insurance number or credit card details.
  </span>
  <textarea class="nhsuk-textarea" id="more-detail" name="more-detail" rows="5" aria-describedby="more-detail-hint"></textarea>
</div>
```

#### Taghelper

```
<nhs-form-group nhs-form-group-type="Standard">
  <nhs-label nhs-label-type="Standard" for="more-detail">Can you provide more detail?</nhs-label>
  <nhs-hint nhs-hint-type="Standard" id="more-detail-hint">Don't include personal or financial information, eg your National Insurance number or credit card details.</nhs-hint>
  <nhs-text-area nhs-textarea-type="Standard" id="more-detail" name="more-detail" rows="5" aria-describedby="more-detail-hint"></nhs-text-area>
</nhs-form-group>
```

---

### Textarea with autocomplete attribute

[Preview the textarea with autocomplete attribute component]()

#### Guidance

See [Autofilling form controls: the autocomplete attribute](https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofill) for the full list of attributes that can be used.

#### HTML markup

```html
<div class="nhsuk-form-group">
  <label class="nhsuk-label" for="textarea-with-autocomplete-attribute">
  Full address
  </label>
  <textarea class="nhsuk-textarea" id="textarea-with-autocomplete-attribute" name="address" rows="5" autocomplete="street-address"></textarea>
</div>
```

#### Taghelper

```
<nhs-form-group nhs-form-group-type="Standard">
  <nhs-label nhs-label-type="Standard" for="textarea-with-autocomplete-attribute">Full address</nhs-label>
  <nhs-text-area nhs-textarea-type="Standard" id="textarea-with-autocomplete-attribute" name="address" rows="5" autocomplete="street-address"></nhs-text-area>
</nhs-form-group>
```
---

### Textarea with error message

[Preview the textarea with error message component]()

#### HTML markup

```html
<div class="nhsuk-form-group nhsuk-form-group--error">
  <label class="nhsuk-label" for="no-ni-reason">
    Why can&#39;t you provide a National Insurance number?
  </label>
  <span id="no-ni-reason-error" class="nhsuk-error-message">
    You must provide an explanation
  </span>
  <textarea class="nhsuk-textarea nhsuk-textarea--error" id="no-ni-reason" name="no-ni-reason" rows="5" aria-describedby="no-ni-reason-error"></textarea>
</div>
```

#### Taghelper

```
<nhs-form-group nhs-form-group-type="Error">
  <nhs-label nhs-label-type="Standard" for="no-ni-reason">Why can't you provide a National Insurance number?</nhs-label>
  <nhs-error-message id="no-ni-reason-error"> You must provide an explanation</nhs-error-message>
  <nhs-text-area nhs-textarea-type="Error" id="no-ni-reason" name="no-ni-reason" rows="5" aria-describedby="no-ni-reason-error"></nhs-text-area>
</nhs-form-group>
```
---
### Taghelper

| Name                    | Type     | Required  | Description             |
| ------------------------|----------|-----------|-------------------------|
| **id**              | string   | Yes       | The id of the textarea. |
| **name**            | string   | Yes       | The name of the textarea, which is submitted with the form data. |
| **rows**            | string   | No        | Optional number of textarea rows. |
| **nhs-label**           | Taghelper   | Yes        | The label taghelper.|
| **nhs-hint**            | Taghelper   | No        | The hint taghelper. |
| **nhs-errorMessage**    | Taghelper   | No        |The error message taghelper. |
| **nhs-form-group**           | Taghelper   | Yes        | The formgroup taghelper wrapper for the radios component.|
| **classes**         | string   | No        | Optional additional classes add to the input taghelper. Separate each class with a space. |
| **autocomplete**    | string   | No        | Attribute to [identify input purpose](https://www.w3.org/WAI/WCAG21/Understanding/identify-input-purpose.html), for instance "postal-code" or "username". See [Autofilling form controls: the autocomplete attribute](https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofill) for the full list of attributes that can be used. |
| **nhs-text-area**           | Taghelper   | Yes        | representing the textarea control.|
| **nhs-textarea-type**           | string   | Yes        | text area type e.g Standard, Error.|

This component and documentation has been taken from [NHS.UK Frontend - Textarea component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/textarea) with a few minor adaptations.