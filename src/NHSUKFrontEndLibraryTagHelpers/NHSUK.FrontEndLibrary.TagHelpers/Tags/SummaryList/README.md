# Summary list

## Quick start examples

### Summary list

[Preview the summary list component](https://dotnetcorefelpoc.azurewebsites.net/components/summary-list)

#### HTML markup

```html
<dl class="nhsuk-summary-list">
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Name
    </dt>
    <dd class="nhsuk-summary-list__value">
      Sarah Philips
    </dd>
    <dd class="nhsuk-summary-list__actions">
      <a href="#">
        Change
        <span class="nhsuk-u-visually-hidden"> name</span>
      </a>
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Date of birth
    </dt>
    <dd class="nhsuk-summary-list__value">
      5 January 1978
    </dd>
    <dd class="nhsuk-summary-list__actions">
      <a href="#">
        Change
        <span class="nhsuk-u-visually-hidden"> date of birth</span>
      </a>
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Contact information
    </dt>
    <dd class="nhsuk-summary-list__value">
      72 Guild Street
      <br>London
      <br>SE23 6FH
    </dd>
    <dd class="nhsuk-summary-list__actions">
      <a href="#">
        Change
        <span class="nhsuk-u-visually-hidden"> contact information</span>
      </a>
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Contact details
    </dt>
    <dd class="nhsuk-summary-list__value">
      <p class="nhsuk-body">07700 900457</p>
      <p class="nhsuk-body">sarah.phillips@example.com</p>
    </dd>
    <dd class="nhsuk-summary-list__actions">
      <a href="#">
        Change
        <span class="nhsuk-u-visually-hidden"> contact details</span>
      </a>
    </dd>
  </div>
</dl>
```

#### Taghelper markup

```
<nhs-summary-list>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Name</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>Sarah Philips</nhs-summary-list-row-value>
    <nhs-summary-list-row-actions href="#" visually-hidden-text="name">Change</nhs-summary-list-row-actions>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Date of birth</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>5 January 1978</nhs-summary-list-row-value>
    <nhs-summary-list-row-actions href="#" visually-hidden-text="date of birth">Change</nhs-summary-list-row-actions>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Contact information</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>
      72 Guild Street
      <br>London
      <br>SE23 6FH
    </nhs-summary-list-row-value>
    <nhs-summary-list-row-actions href="#" visually-hidden-text="contact information">Change</nhs-summary-list-row-actions>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Contact details</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>
      <p>07700 900457</p>
      <p>sarah.philips@example.com</p>
    </nhs-summary-list-row-value>
    <nhs-summary-list-row-actions href="#" visually-hidden-text="contact details">Change</nhs-summary-list-row-actions>
  </nhs-summary-list-row>
</nhs-summary-list>
```

---

### Summary list without actions

[Preview the summary list without actions component](https://dotnetcorefelpoc.azurewebsites.net/components/summary-list-without-actions)

#### HTML markup

```html
<dl class="nhsuk-summary-list">
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Name
    </dt>
    <dd class="nhsuk-summary-list__value">
      Sarah Philips
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Date of birth
    </dt>
    <dd class="nhsuk-summary-list__value">
      5 January 1978
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Contact information
    </dt>
    <dd class="nhsuk-summary-list__value">
      72 Guild Street
      <br>London
      <br>SE23 6FH
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Contact details
    </dt>
    <dd class="nhsuk-summary-list__value">
      <p class="nhsuk-body">07700 900457</p>
      <p class="nhsuk-body">sarah.phillips@example.com</p>
    </dd>
  </div>
</dl>
```

#### Taghelper markup

```
<nhs-summary-list>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Name</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>Sarah Philips</nhs-summary-list-row-value>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Date of birth</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>5 January 1978</nhs-summary-list-row-value>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Contact information</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>
      72 Guild Street
      <br>London
      <br>SE23 6FH
    </nhs-summary-list-row-value>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Contact details</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>
      <p>07700 900457</p>
      <p>sarah.philips@example.com</p>
    </nhs-summary-list-row-value>
  </nhs-summary-list-row>
</nhs-summary-list>

```

---

### Summary list without border

[Preview the summary list without border component](https://dotnetcorefelpoc.azurewebsites.net/components/summary-list-without-border)

#### HTML markup

```html
<dl class="nhsuk-summary-list nhsuk-summary-list--no-border">
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Name
    </dt>
    <dd class="nhsuk-summary-list__value">
      Sarah Philips
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Date of birth
    </dt>
    <dd class="nhsuk-summary-list__value">
      5 January 1978
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Contact information
    </dt>
    <dd class="nhsuk-summary-list__value">
      72 Guild Street
      <br>London
      <br>SE23 6FH
    </dd>
  </div>
  <div class="nhsuk-summary-list__row">
    <dt class="nhsuk-summary-list__key">
      Contact details
    </dt>
    <dd class="nhsuk-summary-list__value">
      <p class="nhsuk-body">07700 900457</p>
      <p class="nhsuk-body">sarah.phillips@example.com</p>
    </dd>
  </div>
</dl>
```

#### Taghelper markup

```
<nhs-summary-list is-without-border="true">
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Name</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>Sarah Philips</nhs-summary-list-row-value>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Date of birth</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>5 January 1978</nhs-summary-list-row-value>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Contact information</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>
      72 Guild Street
      <br>London
      <br>SE23 6FH
    </nhs-summary-list-row-value>
  </nhs-summary-list-row>
  <nhs-summary-list-row>
    <nhs-summary-list-row-key>Contact details</nhs-summary-list-row-key>
    <nhs-summary-list-row-value>
      <p>07700 900457</p>
      <p>sarah.philips@example.com</p>
    </nhs-summary-list-row-value>
  </nhs-summary-list-row>
</nhs-summary-list>
```

---

### Taghelper attributes

The summary list taghelper markup takes the following attributes:

| Name             | Type     | Required  | Description |
| -----------------|----------|-----------|-------------|
| classes          | string   | No        | Classes to add to the container. |
| nhs-summary-list.is-without-border | boolean   | No        | summary list without border. |
| nhs-summary-list-row             | Taghelper    | Yes       | Taghelper representing a row item. |
| nhs-summary-list-row.key    | Taghelper   | Yes       | Taghelper representing a row key item |
| nhs-summary-list-row.key.classes | string   | No        | Classes to add to the key wrapper. |
| nhs-summary-list-row.value.classes | string   | No         | Classes to add to the value wrapper. |
| nhs-summary-list-row.actions | Taghelper   | No        | Taghelper for the action item. |
| action.items.classes | string   | No     | Classes to add to the actions wrapper. |
| action.items.href | string   | Yes     | The value of the link href attribute for an action item. |
| action.items.visuallyHiddenText	 | string   | Yes     | Actions rely on context from the surrounding content so may require additional accessible text, text supplied to this option is appended to the end, use html for more complicated scenarios. |

This component and documentation has been taken from [NHS.UK Frontend - Summary list component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/summary-list) .