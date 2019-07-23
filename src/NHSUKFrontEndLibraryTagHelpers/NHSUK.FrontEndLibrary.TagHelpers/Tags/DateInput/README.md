# Date input

## Guidance

Find out more about the date input component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/date-input).

Note: The `pattern` attribute is not valid HTML for inputs where the type attribute is number. It is added deliberately to [force numeric keypads on iOS devices](http://bradfrost.com/blog/post/better-numerical-inputs-for-mobile-forms/). See also [presenting iOS keyboards](https://stackoverflow.com/questions/25425181/iphone-ios-presenting-html-5-keyboard-for-postal-codes) for visual examples of iOS keyboards and attributes.

## Quick start examples

### Date input

[Preview the date input component](https://dotnetcorefelpoc.azurewebsites.net/components/date-input)

#### HTML markup

```html
<div class="nhsuk-form-group">
  <fieldset class="nhsuk-fieldset" aria-describedby="dob-hint" role="group">
    <legend class="nhsuk-fieldset__legend">
      What is your date of birth?
    </legend>
    <span class="nhsuk-hint" id="dob-hint">
    For example, 31 3 1980
    </span>
    <div class="nhsuk-date-input" id="dob">
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-day">
          Day
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-2" id="dob-day" name="dob-day" type="number" pattern="[0-9]*">
        </div>
      </div>
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-month">
          Month
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-2" id="dob-month" name="dob-month" type="number" pattern="[0-9]*">
        </div>
      </div>
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-year">
          Year
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-4" id="dob-year" name="dob-year" type="number" pattern="[0-9]*">
        </div>
      </div>
    </div>
  </fieldset>
</div>
```

#### Taghelper markup

```

<nhs-form-group nhs-form-group-type="Standard">
  <nhs-fieldset aria-describedby="dob-hint" role="group">
    <nhs-fieldset-legend nhs-legend-size="Standard">
      What is your date of birth?
    </nhs-fieldset-legend>
    <nhs-hint nhs-hint-type="Standard" id="dob-hint">For example, 31 3 1980</nhs-hint>
    <nhs-date-input id="dob">
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-day">Day</label>
          <input nhs-input-type="Date" fixed-width="Two" id="dob-day" name="dob-day"/>
        </nhs-form-group>
      </nhs-date-input-item>
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-month">Month</label>
          <input nhs-input-type="Date" fixed-width="Two" id="dob-month" name="dob-month"/>
        </nhs-form-group>
      </nhs-date-input-item>
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-year">Year</label>
          <input nhs-input-type="Date" fixed-width="Four" id="dob-year" name="dob-year"/>
        </nhs-form-group>
      </nhs-date-input-item>
    </nhs-date-input>
  </nhs-fieldset>
</nhs-form-group>


```

---

### Date input with autocomplete attribute

[Preview the date input with autocomplete attribute component](https://dotnetcorefelpoc.azurewebsites.net/components/date-input-autocomplete)

#### Guidance

See [Autofilling form controls: the autocomplete attribute](https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofill) for the full list of attributes that can be used.

#### HTML markup

```html
<div class="nhsuk-form-group">
  <fieldset class="nhsuk-fieldset" aria-describedby="dob-with-autocomplete-attribute-hint" role="group">
    <legend class="nhsuk-fieldset__legend">
      What is your date of birth?
    </legend>
    <span class="nhsuk-hint" id="dob-with-autocomplete-attribute-hint">
    For example, 31 3 1980
    </span>
    <div class="nhsuk-date-input" id="dob-with-autocomplete-attribute">
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-with-autocomplete-attribute-day">
          Day
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-2" id="dob-with-autocomplete-attribute-day" name="dob-with-autocomplete-day" type="number" autocomplete="bday-day" pattern="[0-9]*">
        </div>
      </div>
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-with-autocomplete-attribute-month">
          Month
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-2" id="dob-with-autocomplete-attribute-month" name="dob-with-autocomplete-month" type="number" autocomplete="bday-month" pattern="[0-9]*">
        </div>
      </div>
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-with-autocomplete-attribute-year">
          Year
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-4" id="dob-with-autocomplete-attribute-year" name="dob-with-autocomplete-year" type="number" autocomplete="bday-year" pattern="[0-9]*">
        </div>
      </div>
    </div>
  </fieldset>
</div>
```

#### Taghelper markup

```
 <nhs-form-group nhs-form-group-type="Standard">
  <nhs-fieldset aria-describedby="dob-with-autocomplete-attribute-hint" role="group">
    <nhs-fieldset-legend nhs-legend-size="Standard">
      What is your date of birth?
    </nhs-fieldset-legend>
    <nhs-hint nhs-hint-type="Standard" id="dob-with-autocomplete-attribute-hint">For example, 31 3 1980</nhs-hint>
    <nhs-date-input id="dob-with-autocomplete-attribute">
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-with-autocomplete-attribute-day">Day</label>
          <input nhs-input-type="Date" fixed-width="Two" id="dob-with-autocomplete-attribute-day" name="dob-with-autocomplete-day" autocomplete="bday-day"/>
        </nhs-form-group>
      </nhs-date-input-item>
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-with-autocomplete-attribute-month">Month</label>
          <input nhs-input-type="Date" fixed-width="Two" id="dob-month" name="dob-with-autocomplete-month" autocomplete="bday-month"/>
        </nhs-form-group>
      </nhs-date-input-item>
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-with-autocomplete-attribute-year">Year</label>
          <input nhs-input-type="Date" fixed-width="Four" id="dob-year" name="dob-with-autocomplete-year" autocomplete="bday-year"/>
        </nhs-form-group>
      </nhs-date-input-item>
    </nhs-date-input>
  </nhs-fieldset>
</nhs-form-group>
```

---

### Date input with errors

[Preview the date input with errors component](https://dotnetcorefelpoc.azurewebsites.net/components/date-input-mutiple-errors)

#### HTML markup

```html
<div class="nhsuk-form-group nhsuk-form-group--error">
  <fieldset class="nhsuk-fieldset" aria-describedby="dob-errors-hint dob-errors-error" role="group">
    <legend class="nhsuk-fieldset__legend">
      What is your date of birth?
    </legend>
    <span class="nhsuk-hint" id="dob-errors-hint">
    For example, 31 3 1980
    </span>
    <span id="dob-errors-error" class="nhsuk-error-message">
    Error message goes here
    </span>
    <div class="nhsuk-date-input" id="dob-errors">
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-errors-day">
          Day
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-2 nhsuk-input--error" id="dob-errors-day" name="day" type="number" pattern="[0-9]*">
        </div>
      </div>
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-errors-month">
          Month
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-2 nhsuk-input--error" id="dob-errors-month" name="month" type="number" pattern="[0-9]*">
        </div>
      </div>
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-errors-year">
          Year
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-4 nhsuk-input--error" id="dob-errors-year" name="year" type="number" pattern="[0-9]*">
        </div>
      </div>
    </div>
  </fieldset>
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Error">
  <nhs-fieldset aria-describedby="dob-errors-hint dob-errors-error" role="group">
    <nhs-fieldset-legend nhs-legend-size="Standard">
      What is your date of birth?
    </nhs-fieldset-legend>
    <nhs-hint nhs-hint-type="Standard" id="dob-errors-hint">For example, 31 3 1980</nhs-hint>
    <span nhs-span-type="ErrorMessage" id="dob-errors-error">Error message goes here</span>
    <nhs-date-input id="dob-errors">
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-errors-day">Day</label>
          <input nhs-input-type="Date" fixed-width="Two" is-error-input="true" id="dob-errors-day" name="day" />
        </nhs-form-group>
      </nhs-date-input-item>
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-errors-month">Month</label>
          <input nhs-input-type="Date" fixed-width="Two" is-error-input="true" id="dob-errors-month" name="month" />
        </nhs-form-group>
      </nhs-date-input-item>
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-errors-year">Year</label>
          <input nhs-input-type="Date" fixed-width="Four" is-error-input="true" id="dob-errors-year" name="year" />
        </nhs-form-group>
      </nhs-date-input-item>
    </nhs-date-input>
  </nhs-fieldset>
</nhs-form-group>
```

---

### Date input with error on single input

[Preview the date input with error on single input component](https://dotnetcorefelpoc.azurewebsites.net/components/date-input-error)

#### HTML markup

```html
<div class="nhsuk-form-group nhsuk-form-group--error">
  <fieldset class="nhsuk-fieldset" aria-describedby="dob-day-error-hint dob-day-error-error" role="group">
    <legend class="nhsuk-fieldset__legend">
      What is your date of birth?
    </legend>
    <span class="nhsuk-hint" id="dob-day-error-hint">
    For example, 31 3 1980
    </span>
    <span id="dob-day-error-error" class="nhsuk-error-message">
    Error message goes here
    </span>
    <div class="nhsuk-date-input" id="dob-day-error">
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-day-error-day">
          Day
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-2 nhsuk-input--error" id="dob-day-error-day" name="dob-day-error-day" type="number" pattern="[0-9]*">
        </div>
      </div>
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-day-error-month">
          Month
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-2" id="dob-day-error-month" name="dob-day-error-month" type="number" pattern="[0-9]*">
        </div>
      </div>
      <div class="nhsuk-date-input__item">
        <div class="nhsuk-form-group">
          <label class="nhsuk-label nhsuk-date-input__label" for="dob-day-error-year">
          Year
          </label>
          <input class="nhsuk-input nhsuk-date-input__input nhsuk-input--width-4" id="dob-day-error-year" name="dob-day-error-year" type="number" pattern="[0-9]*">
        </div>
      </div>
    </div>
  </fieldset>
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Error">
  <nhs-fieldset aria-describedby="dob-day-error-hint dob-day-error-error" role="group">
    <nhs-fieldset-legend nhs-legend-size="Standard">
      What is your date of birth?
    </nhs-fieldset-legend>
    <nhs-hint nhs-hint-type="Standard" id="dob-day-error-hint">For example, 31 3 1980</nhs-hint>
    <span nhs-span-type="ErrorMessage" id="dob-day-error-error">Error message goes here</span>
    <nhs-date-input id="dob-day-error">
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-day-error-day">Day</label>
          <input nhs-input-type="Date" fixed-width="Two" is-error-input="true" id="dob-day-error-day" name="dob-day-error-day" />
        </nhs-form-group>
      </nhs-date-input-item>
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-errors-month">Month</label>
          <input nhs-input-type="Date" fixed-width="Two" id="dob-day-error-month" name="dob-day-error-month" />
        </nhs-form-group>
      </nhs-date-input-item>
      <nhs-date-input-item>
        <nhs-form-group nhs-form-group-type="Standard">
          <label nhs-label-type="Date" for="dob-errors-year">Year</label>
          <input nhs-input-type="Date" fixed-width="Four" id="dob-day-error-year" name="dob-day-error-year" />
        </nhs-form-group>
      </nhs-date-input-item>
    </nhs-date-input>
  </nhs-fieldset>
</nhs-form-group>

```

---

### Taghelper attributes

| Name                      | Type     | Required  | Description             |
| --------------------------|----------|-----------|-------------------------|
| **id**                    | string   | No        | Optional id. This is used for the main component and to compose id attribute for each item. |
| **nhs-date-input-item**                 | Taghelper    | Yes       | A taghelper representing a date input item. |
| **nhs-form-group**           | Taghelper   | Yes        | the formgroup wrapper for the input component.|
| **input**           | Taghelper   | Yes        | representing for the input control.|
| **label**           | Taghelper   | Yes        | The label taghelper.|
| **nhs-hint**            | Taghelper   | No        | The hint taghelper. |
| **span nhs-span-type="ErrorMessage"**    | Taghelper   | No        | The error message taghelper.|
| **nhs-form-group**           | Taghelper   | Yes        | The formgroup wrapper taghelper.|
| **nhs-fieldset**        | Taghelper   | No        | taghelper for the fieldset component. |
| **autocomplete**          | string   | No        | Attribute to [identify input purpose](https://www.w3.org/WAI/WCAG21/Understanding/identify-input-purpose.html), for instance "postal-code" or "username". See [Autofilling form controls: the autocomplete attribute](https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofill) for the full list of attributes that can be used. |
| **pattern**               | string   | No        | Attribute to [provide a regular expression pattern](https://www.w3.org/TR/html51/sec-forms.html#the-pattern-attribute), used to match allowed character combinations for the input value. |
| **classes**               | string   | No        | Optional additional classes to add to the date-input container. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Date input component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/date-input) .
