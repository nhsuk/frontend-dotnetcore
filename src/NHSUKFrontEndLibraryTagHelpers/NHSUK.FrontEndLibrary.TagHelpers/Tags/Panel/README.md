# Panel

## Quick start examples

### Panel

[Preview the panel component](https://dotnetcorefelpoc.azurewebsites.net/components/panel)

#### HTML markup

```html
<div class="nhsuk-panel">
  <h3>Live well</h3>
  <p>Advice, tips and tools to help you make the best choices about your health and wellbeing</p>
</div>
```

#### Taghelper markup

```
<nhs-panel nhs-panel-type="Standard">
  <h3>Live well</h3>
  <p>Advice, tips and tools to help you make the best choices about your health and wellbeing</p>
</nhs-panel>
```

---

### Panel with a label

[Preview the panel with a label component](https://dotnetcorefelpoc.azurewebsites.net/components/panel-with-label)

#### HTML markup

```html
<div class="nhsuk-panel-with-label">
  <h3 class="nhsuk-panel-with-label__label">Live well</h3>
  <p>Advice, tips and tools to help you make the best choices about your health and wellbeing</p>
</div>
```

#### Taghelper markup

```
<nhs-panel nhs-panel-type="WithLabel" label="Live well">
  <p>Advice, tips and tools to help you make the best choices about your health and wellbeing</p>
</nhs-panel>
```

---

### Grey panel

[Preview the grey panel component](https://dotnetcorefelpoc.azurewebsites.net/components/panel-grey)

#### HTML markup

```html
<div class="nhsuk-panel nhsuk-panel--grey">
  <p>Advice, tips and tools to help you make the best choices about your health and wellbeing</p>
</div>
```

#### Taghelper markup

```
<nhs-panel nhs-panel-type="Grey">
  <p>Advice, tips and tools to help you make the best choices about your health and wellbeing</p>
</nhs-panel>
```

---

### Panel group

[Preview the panel group component](https://dotnetcorefelpoc.azurewebsites.net/components/panel-group)

#### HTML markup

```html
<div class="nhsuk-grid-row nhsuk-panel-group">
  <div class="nhsuk-grid-column-one-half nhsuk-panel-group__item">
    <div class="nhsuk-panel">
      <h3>Eat well</h3>
      <p>All you need to know about the major food groups and a healthy, balanced diet</p>
    </div>
  </div>
  <div class="nhsuk-grid-column-one-half nhsuk-panel-group__item">
    <div class="nhsuk-panel">
      <h3>Healthy weight</h3>
      <p>Check your BMI using our healthy weight calculator and find out if you're a healthy weight</p>
    </div>
  </div>
</div>
<div class="nhsuk-grid-row nhsuk-panel-group">
  <div class="nhsuk-grid-column-one-half nhsuk-panel-group__item">
    <div class="nhsuk-panel">
      <h3>Excercise</h3>
      <p>Programmes, workouts and tips to get you moving and improve your fitness and wellbeing</p>
    </div>
  </div>
  <div class="nhsuk-grid-column-one-half nhsuk-panel-group__item">
    <div class="nhsuk-panel">
      <h3>Sleep and tiredness</h3>
      <p>Find out how to sleep well and the common lifestyle factors that are making you tired</p>
    </div>
  </div>
</div>
```

#### Taghelper markup

```
<nhs-panel-group grid-column-width="OneHalf">
  <nhs-panel nhs-panel-type="Standard">
    <h3>Eat well</h3>
    <p>All you need to know about the major food groups and a healthy, balanced diet</p>
  </nhs-panel>
  <nhs-panel nhs-panel-type="Standard">
    <h3>Healthy weight</h3>
    <p>Check your BMI using our healthy weight calculator and find out if you're a healthy weight</p>
  </nhs-panel>
</nhs-panel-group>
<nhs-panel-group grid-column-width="OneHalf">
  <nhs-panel nhs-panel-type="Standard">
    <h3>Excercise</h3>
    <p>Programmes, workouts and tips to get you moving and improve your fitness and wellbeing</p>
  </nhs-panel>
  <nhs-panel nhs-panel-type="Standard">
    <h3>Sleep and tiredness</h3>
    <p>Find out how to sleep well and the common lifestyle factors that are making you tired</p>
  </nhs-panel>
</nhs-panel-group>


```

---

### Taghelper attributes

The panel taghelper takes the following attribures:

| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **nhs-panel-type**            | string   | Yes       |panel type : Standard, With Label or Grey. |
| **label**           | string   | No        | The label of the panel component. |
| **classes**         | string   | No        | Optional additional classes to add to the panel. Separate each class with a space. |
