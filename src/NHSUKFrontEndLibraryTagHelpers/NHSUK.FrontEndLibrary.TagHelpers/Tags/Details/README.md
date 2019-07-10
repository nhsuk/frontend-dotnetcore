# Details

## Guidance

Find out more about the details component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/details).

## Dependencies

For this component to be accessible and compatible with older browsers, include the required polyfill JavaScript. You can either include the compiled JavaScript for all components or just the polyfill JavaScript `details.polyfill.js`.

## Quick start examples

### Details

[Preview the details component](https://dotnetcorefelpoc.azurewebsites.net/components/details)

#### HTML markup

```html
<details class="nhsuk-details">
  <summary class="nhsuk-details__summary">
    <span class="nhsuk-details__summary-text">
    Where can I find my NHS number?
    </span>
  </summary>
  <div class="nhsuk-details__text">
    <p>An NHS number is a 10 digit number, like 485 777 3456.</p>
    <p>You can find your NHS number on any document sent to you by the NHS. This may include:</p>
    <ul>
      <li>prescriptions</li>
      <li>test results</li>
      <li>hospital referral letters</li>
      <li>appointment letters</li>
      <li>your NHS medical card</li>
    </ul>
    <p>Ask your GP practice for help if you can't find your NHS number.</p>
  </div>
</details>
```

#### Taghelper markup

```
<nhs-details display-text="Where can I find my NHS number?" nhs-details-type="Standard">
  <p>An NHS number is a 10 digit number, like 485 777 3456.</p>
  <p>You can find your NHS number on any document sent to you by the NHS. This may include:</p>
  <ul>
    <li>prescriptions</li>
    <li>test results</li>
    <li>hospital referral letters</li>
    <li>appointment letters</li>
    <li>your NHS medical card</li>
  </ul>
  <p>Ask your GP practice for help if you can't find your NHS number.</p>
</nhs-details>

```
---

### Expander

[Preview the expander component](https://dotnetcorefelpoc.azurewebsites.net/components/expander)

#### Guidance

Find out more about the expander component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/expander).

#### HTML markup

```html
<details class="nhsuk-details nhsuk-expander">
  <summary class="nhsuk-details__summary">
    <span class="nhsuk-details__summary-text">
    Opening times
    </span>
  </summary>
  <div class="nhsuk-details__text">
    <table>
      <tbody>
        <tr>
          <th><strong>Day of the week</strong></th>
          <th><strong>Opening hours</strong></th>
        </tr>
        <tr>
          <th>Monday</th>
          <td>9am to 6pm</td>
        </tr>
        <tr>
          <th>Tuesday</th>
          <td>9am to 6pm</td>
        </tr>
        <tr>
          <th>Wednesday</th>
          <td>9am to 6pm</td>
        </tr>
        <tr>
          <th>Thursday</th>
          <td>9am to 6pm</td>
        </tr>
        <tr>
          <th>Friday</th>
          <td>9am to 6pm</td>
        </tr>
        <tr>
          <th>Saturday</th>
          <td>9am to 1pm</td>
        </tr>
        <tr>
          <th>Sunday</th>
          <td>Closed</td>
        </tr>
      </tbody>
    </table>
  </div>
</details>
```

#### Taghelper markup

```
<nhs-details display-text="Opening times" nhs-details-type="Expander">
  <table>
    <tbody>
    <tr>
      <th><strong>Day of the week</strong></th>
      <th><strong>Opening hours</strong></th>
    </tr>
    <tr>
      <th>Monday</th>
      <td>9am to 6pm</td>
    </tr>
    <tr>
      <th>Tuesday</th>
      <td>9am to 6pm</td>
    </tr>
    <tr>
      <th>Wednesday</th>
      <td>9am to 6pm</td>
    </tr>
    <tr>
      <th>Thursday</th>
      <td>9am to 6pm</td>
    </tr>
    <tr>
      <th>Friday</th>
      <td>9am to 6pm</td>
    </tr>
    <tr>
      <th>Saturday</th>
      <td>9am to 1pm</td>
    </tr>
    <tr>
      <th>Sunday</th>
      <td>Closed</td>
    </tr>
    </tbody>
  </table>
</nhs-details>

```

---

### Expander group

[Preview the expander group component](https://dotnetcorefelpoc.azurewebsites.net/components/expander-group)

#### HTML markup

```html
<div class="nhsuk-expander-group">
  <details class="nhsuk-details nhsuk-expander">
    <summary class="nhsuk-details__summary">
      <span class="nhsuk-details__summary-text">
      How to measure your blood glucose levels
      </span>
    </summary>
    <div class="nhsuk-details__text">
      <p>Testing your blood at home is quick and easy, although it can be uncomfortable. It does get better.</p>
      <p>You would have been given:</p>
      <ul>
        <li>a blood glucose metre</li>
        <li>small needles called lancets</li>
        <li>a plastic pen to hold the lancest</li>
        <li>small test strips</li>
      </ul>
    </div>
  </details>
  <details class="nhsuk-details nhsuk-expander">
    <summary class="nhsuk-details__summary">
      <span class="nhsuk-details__summary-text">
      When to check your blood glucose level
      </span>
    </summary>
    <div class="nhsuk-details__text">
      <p>Try to check your blood:</p>
      <ul>
        <li>before meals</li>
        <li>2 to 3 hours after meals</li>
        <li>before, during (take a break) and after exercise</li>
      </ul>
      <p>This helps you understand your blood glucose levels and how they’re affected by meals and exercise. It should help you have more stable blood glucose levels.</p>
    </div>
  </details>
</div>
```

#### Taghelper markup

```
<nhs-expander-group>
  <nhs-details display-text="How to measure your blood glucose levels" nhs-details-type="Expander">
    <p>Testing your blood at home is quick and easy, although it can be uncomfortable. It does get better.</p>
    <p>You would have been given:</p>
    <ul>
      <li>a blood glucose metre</li>
      <li>small needles called lancets</li>
      <li>a plastic pen to hold the lancest</li>
      <li>small test strips</li>
    </ul>
  </nhs-details>
  <nhs-details display-text="When to check your blood glucose level" nhs-details-type="Expander">
    <p>Try to check your blood:</p>
    <ul>
      <li>before meals</li>
      <li>2 to 3 hours after meals</li>
      <li>before, during (take a break) and after exercise</li>
    </ul>
    <p>This helps you understand your blood glucose levels and how they’re affected by meals and exercise. It should help you have more stable blood glucose levels.</p>
  </nhs-details>
</nhs-expander-group>
```

---

### Taghelper attributes

The details taghelper takes the following attributes:

| Name         | Type     | Required  | Description |
| -------------|----------|-----------|-------------|
| **display-text**         | string   | Yes       | Text to be displayed on the details or expander component. |
| **nhs-details-type**         | string   | Yes       | standard or expander|
| **classes**      | string   | No        | Optional additional classes to add to the anchor tag. Separate each class with a space. |
