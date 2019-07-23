# Checkboxes

## Guidance

Find out more about the checkboxes component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/checkboxes).

## Quick start examples

### Checkboxes

[Preview the checkboxes component](https://dotnetcorefelpoc.azurewebsites.net/components/checkboxes)

#### HTML markup

```html
<div class="nhsuk-form-group">
  <fieldset class="nhsuk-fieldset" aria-describedby="nationality-hint">
    <legend class="nhsuk-fieldset__legend">
      What is your nationality?
    </legend>
    <span class="nhsuk-hint" id="nationality-hint">
    If you have more than 1 nationality, select all options that are relevant to you.
    </span>
    <div class="nhsuk-checkboxes">
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="nationality-1" name="nationality" type="checkbox" value="british">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="nationality-1">
        British
        </label>
      </div>
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="nationality-2" name="nationality" type="checkbox" value="irish">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="nationality-2">
        Irish
        </label>
      </div>
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="nationality-3" name="nationality" type="checkbox" value="other">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="nationality-3">
        citizen of another country
        </label>
      </div>
    </div>
  </fieldset>
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Standard">
  <nhs-fieldset aria-describedby="nationality-hint">
    <nhs-fieldset-legend nhs-legend-size="Standard">What is your nationality?</nhs-fieldset-legend>
    <nhs-hint nhs-hint-type="Standard" id="nationality-hint"> If you have more than 1 nationality, select all options that are relevant to you.</nhs-hint>
    <nhs-checkboxes>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="nationality-1" name="nationality" value="british"/>
        <label nhs-label-type="Checkboxes" for="nationality-1">British</label>
      </nhs-checkboxes-item>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="nationality-2" name="nationality" value="irish"/>
        <label nhs-label-type="Checkboxes" for="nationality-2">Irish</label>
      </nhs-checkboxes-item>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes"  id="nationality-3" name="nationality" value="other"/>
        <label nhs-label-type="Checkboxes" for="nationality-3">citizen of another country</label>
      </nhs-checkboxes-item>
    </nhs-checkboxes>
  </nhs-fieldset>
</nhs-form-group>

```

---

### Checkboxes with hint text

[Preview the checkboxes with hint text component](https://dotnetcorefelpoc.azurewebsites.net/components/checkboxes-with-hint)

#### HTML markup

```html
<div class="nhsuk-form-group">
  <fieldset class="nhsuk-fieldset">
    <legend class="nhsuk-fieldset__legend">
      <h1 class="nhsuk-fieldset__heading">
        How do you want to sign in?
      </h1>
    </legend>
    <div class="nhsuk-checkboxes">
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="government-gateway" name="gateway" type="checkbox" value="gov-gateway" aria-describedby="government-gateway-item-hint">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="government-gateway">
        Sign in with Government Gateway
        </label>
        <span class="nhsuk-hint nhsuk-checkboxes__hint" id="government-gateway-item-hint">
        You’ll have a user ID if you’ve registered for Self Assessment or filed a tax return online before.
        </span>
      </div>
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="nhsuk-login" name="verify" type="checkbox" value="nhsuk-verify" aria-describedby="nhsuk-login-item-hint">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="nhsuk-login">
        Sign in with NHS.UK login
        </label>
        <span class="nhsuk-hint nhsuk-checkboxes__hint" id="nhsuk-login-item-hint">
        You’ll have an account if you’ve already proved your identity with either Barclays, CitizenSafe, Digidentity, Experian, Post Office, Royal Mail or SecureIdentity.
        </span>
      </div>
    </div>
  </fieldset>
</div>
```

#### Taghelper markup

```

<nhs-form-group nhs-form-group-type="Standard">
  <nhs-fieldset>
    <nhs-fieldset-legend nhs-legend-size="Standard" is-page-heading="true">
      How do you want to sign in?
    </nhs-fieldset-legend>
    <nhs-checkboxes>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="government-gateway" name="gateway" value="gov-gateway" aria-describedby="government-gateway-item-hint"/>
        <label nhs-label-type="Checkboxes" for="government-gateway">Sign in with Government Gateway</label>
        <nhs-hint nhs-hint-type="Checkboxes" id="government-gateway-item-hint">You’ll have a user ID if you’ve registered for Self Assessment or filed a tax return online before.</nhs-hint>
      </nhs-checkboxes-item>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="nhsuk-login" name="verify" value="nhsuk-verify" aria-describedby="nhsuk-login-item-hint"/>
        <label nhs-label-type="Checkboxes" for="nhsuk-login">Sign in with NHS.UK login</label>
        <nhs-hint nhs-hint-type="Checkboxes" id="nhsuk-login-item-hint">You’ll have an account if you’ve already proved your identity with either Barclays, CitizenSafe, Digidentity, Experian, Post Office, Royal Mail or SecureIdentity.</nhs-hint>
      </nhs-checkboxes-item>
    </nhs-checkboxes>
  </nhs-fieldset>
</nhs-form-group>

```
---

### Checkboxes with disabled item

[Preview the checkboxes with disabled item component](https://dotnetcorefelpoc.azurewebsites.net/components/checkboxes-disabled)

#### HTML markup

```html
<div class="nhsuk-form-group">
  <div class="nhsuk-checkboxes">
    <div class="nhsuk-checkboxes__item">
      <input class="nhsuk-checkboxes__input" id="colours-1" name="colours" type="checkbox" value="red">
      <label class="nhsuk-label nhsuk-checkboxes__label" for="colours-1">
      Red
      </label>
    </div>
    <div class="nhsuk-checkboxes__item">
      <input class="nhsuk-checkboxes__input" id="colours-2" name="colours" type="checkbox" value="green">
      <label class="nhsuk-label nhsuk-checkboxes__label" for="colours-2">
      Green
      </label>
    </div>
    <div class="nhsuk-checkboxes__item">
      <input class="nhsuk-checkboxes__input" id="colours-3" name="colours" type="checkbox" value="blue" disabled>
      <label class="nhsuk-label nhsuk-checkboxes__label" for="colours-3">
      Blue
      </label>
    </div>
  </div>
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Standard">
  <nhs-checkboxes>
    <nhs-checkboxes-item>
      <input nhs-input-type="Checkboxes" id="colours-1" name="colours" value="red"/>
      <label nhs-label-type="Checkboxes" for="colours-1">Red</label>
    </nhs-checkboxes-item>
    <nhs-checkboxes-item>
      <input nhs-input-type="Checkboxes" id="colours-2" name="colours" value="green"/>
      <label nhs-label-type="Checkboxes" for="colours-2">Green</label>
    </nhs-checkboxes-item>
    <nhs-checkboxes-item>
      <input nhs-input-type="Checkboxes" id="colours-3" name="colours" value="blue" disabled/>
      <label nhs-label-type="Checkboxes" for="colours-3">Blue</label>
    </nhs-checkboxes-item>
  </nhs-checkboxes>
</nhs-form-group>
```
---

### Checkboxes with legend as page heading

[Preview the checkboxes with legend as page heading component](https://dotnetcorefelpoc.azurewebsites.net/components/checkboxes-page-heading)

#### HTML markup

```html
<div class="nhsuk-form-group">
  <fieldset class="nhsuk-fieldset" aria-describedby="waste-hint">
    <legend class="nhsuk-fieldset__legend nhsuk-fieldset__legend--l">
      <h1 class="nhsuk-fieldset__heading">
        Which types of waste do you transport regularly?
      </h1>
    </legend>
    <span class="nhsuk-hint" id="waste-hint">
    Select all that apply
    </span>
    <div class="nhsuk-checkboxes">
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="waste-1" name="waste" type="checkbox" value="animal">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="waste-1">
        Waste from animal carcasses
        </label>
      </div>
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="waste-2" name="waste" type="checkbox" value="mines">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="waste-2">
        Waste from mines or quarries
        </label>
      </div>
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="waste-3" name="waste" type="checkbox" value="farm">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="waste-3">
        Farm or agricultural waste
        </label>
      </div>
    </div>
  </fieldset>
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Standard">
  <nhs-fieldset aria-describedby="waste-hint">
    <nhs-fieldset-legend nhs-legend-size="Large" is-page-heading="true">
      Which types of waste do you transport regularly?
    </nhs-fieldset-legend>
    <nhs-hint nhs-hint-type="Standard" id="waste-hint">Select all that apply</nhs-hint>
    <nhs-checkboxes>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="waste-1" name="waste" value="animal"/>
        <label nhs-label-type="Checkboxes" for="waste-1">Waste from animal carcasses</label>
      </nhs-checkboxes-item>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="waste-2" name="waste" value="mines"/>
        <label nhs-label-type="Checkboxes" for="waste-2">Waste from mines or quarries</label>
      </nhs-checkboxes-item>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="waste-3" name="waste" value="farm"/>
        <label nhs-label-type="Checkboxes" for="waste-3">Farm or agricultural waste</label>
      </nhs-checkboxes-item>
    </nhs-checkboxes>
  </nhs-fieldset>
</nhs-form-group>

```
---

### Checkboxes with error message

[Preview the checkboxes with error message component](https://dotnetcorefelpoc.azurewebsites.net/components/checkboxes-error-message)

#### HTML markup

```html
<div class="nhsuk-form-group nhsuk-form-group--error">
  <fieldset class="nhsuk-fieldset" aria-describedby="waste-error">
    <legend class="nhsuk-fieldset__legend">
      Which types of waste do you transport regularly?
    </legend>
    <span id="waste-error" class="nhsuk-error-message">
    Please select an option
    </span>
    <div class="nhsuk-checkboxes">
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="waste-1" name="waste" type="checkbox" value="animal">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="waste-1">
        Waste from animal carcasses
        </label>
      </div>
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="waste-2" name="waste" type="checkbox" value="mines">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="waste-2">
        Waste from mines or quarries
        </label>
      </div>
      <div class="nhsuk-checkboxes__item">
        <input class="nhsuk-checkboxes__input" id="waste-3" name="waste" type="checkbox" value="farm">
        <label class="nhsuk-label nhsuk-checkboxes__label" for="waste-3">
        Farm or agricultural waste
        </label>
      </div>
    </div>
  </fieldset>
</div>
```

#### Taghelper markup

```
<nhs-form-group nhs-form-group-type="Error"> 
  <nhs-fieldset aria-describedby="waste-error">
    <nhs-fieldset-legend nhs-legend-size="Standard">Which types of waste do you transport regularly?</nhs-fieldset-legend>
    <span nhs-span-type="ErrorMessage" id="waste-error">Please select an option</span>
    <nhs-checkboxes>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="waste-1" name="waste" value="animal" />
        <label nhs-label-type="Checkboxes" for="waste-1">Waste from animal carcasses</label>
      </nhs-checkboxes-item>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="waste-2" name="waste" value="mines" />
        <label nhs-label-type="Checkboxes" for="waste-2">Waste from mines or quarries</label>
      </nhs-checkboxes-item>
      <nhs-checkboxes-item>
        <input nhs-input-type="Checkboxes" id="waste-3" name="waste" value="farm" />
        <label nhs-label-type="Checkboxes" for="waste-3">Farm or agricultural waste</label>
      </nhs-checkboxes-item>
    </nhs-checkboxes>
  </nhs-fieldset>
</nhs-form-group>

```
### Taghelper attributes

| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **nhs-form-group**           | Taghelper   | Yes        | The formgroup wrapper taghelper.|
| **nhs-fieldset**        | Taghelper   | No        | taghelper for the fieldset component. |
| **nhs-checkboxes**                | taghelper   | Yes       | Taghelper wrapper for checkboxes items.|
| **nhs-checkboxes-item**                | taghelper   | Yes       | Taghelper representing a checkboxes item.|
| **input**                | taghelper   | Yes       | Taghelper representing a input.|
| **label**                | taghelper   | Yes       | Taghelper representing a label.|
| **nhs-hint**            | Taghelper   | No        | Hint taghelper|
| **span nhs-span-type ="ErrorMessage"**    | Taghelper   | No        |Error message taghelper. |
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |

---

This component and documentation has been taken from [NHS.UK Frontend - Checkboxes component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/checkboxes) .
