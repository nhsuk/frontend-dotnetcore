# Table

## Guidance

Find out more about the table component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/table).

## Quick start examples

### Simple table

[Preview the table component](https://dotnetcorefelpoc.azurewebsites.net/components/tables)

#### HTML markup

```html
<div class="nhsuk-table-responsive">
  <table class="nhsuk-table">
    <caption class="nhsuk-table__caption">Skin symptoms and possible causes</caption>
    <thead class="nhsuk-table__head">
      <tr class="nhsuk-table__row">
        <th class="nhsuk-table__header" scope="col">Skin symptoms</th>
        <th class="nhsuk-table__header" scope="col">Possible cause</th>
      </tr>
    </thead>
    <tbody class="nhsuk-table__body">
      <tr class="nhsuk-table__row">
        <td class="nhsuk-table__cell">Blisters on lips or around the mouth</td>
        <td class="nhsuk-table__cell ">cold sores</td>
      </tr>
      <tr class="nhsuk-table__row">
        <td class="nhsuk-table__cell">Itchy, dry, cracked, sore</td>
        <td class="nhsuk-table__cell ">eczema</td>
      </tr>
      <tr class="nhsuk-table__row">
        <td class="nhsuk-table__cell">Itchy blisters</td>
        <td class="nhsuk-table__cell ">shingles, chickenpox</td>
      </tr>
    </tbody>
  </table>
</div>
```

#### Taghelper markup

```
<nhs-table caption="Skin symptoms and possible causes">
  <nhs-table-head>
    <nhs-table-item>Skin symptoms</nhs-table-item>
    <nhs-table-item>Possible cause</nhs-table-item>
  </nhs-table-head>
  <nhs-table-body>
    <nhs-table-body-row>
      <nhs-table-item>Blisters on lips or around the mouth</nhs-table-item>
      <nhs-table-item>cold sores</nhs-table-item>
    </nhs-table-body-row>
    <nhs-table-body-row>
      <nhs-table-item>Itchy, dry, cracked, sore</nhs-table-item>
      <nhs-table-item>eczema</nhs-table-item>
    </nhs-table-body-row>
    <nhs-table-body-row>
      <nhs-table-item>Itchy blisters</nhs-table-item>
      <nhs-table-item>shingles, chickenpox</nhs-table-item>
    </nhs-table-body-row>
  </nhs-table-body>
</nhs-table>
```

---

### Table panel

[Preview the table panel component](https://dotnetcorefelpoc.azurewebsites.net/components/tables-panel)

#### HTML markup

```html
<div class="nhsuk-table__panel-with-heading-tab">
  <h3 class="nhsuk-table__heading-tab">Conditions similar to impetigo</h3>
  <div class="nhsuk-table-responsive">
    <table class="nhsuk-table">
      <caption class="nhsuk-table__caption">Other possible causes of your symptoms</caption>
      <thead class="nhsuk-table__head">
        <tr class="nhsuk-table__row">
          <th class="nhsuk-table__header" scope="col">Symptoms</th>
          <th class="nhsuk-table__header" scope="col">Possible cause</th>
        </tr>
      </thead>
      <tbody class="nhsuk-table__body">
        <tr class="nhsuk-table__row">
          <td class="nhsuk-table__cell">Blisters on lips or around the mouth</td>
          <td class="nhsuk-table__cell ">cold sores</td>
        </tr>
        <tr class="nhsuk-table__row">
          <td class="nhsuk-table__cell">Itchy, dry, cracked, sore</td>
          <td class="nhsuk-table__cell ">eczema</td>
        </tr>
        <tr class="nhsuk-table__row">
          <td class="nhsuk-table__cell">Itchy blisters</td>
          <td class="nhsuk-table__cell ">shingles, chickenpox</td>
        </tr>
      </tbody>
    </table>
  </div>
</div>
```

#### Taghelper markup

```
<nhs-table is-with-panel="true" title-text="Conditions similar to impetigo" caption="Other possible causes of your symptoms">
  <nhs-table-head>
    <nhs-table-item>Symptoms</nhs-table-item>
    <nhs-table-item>Possible cause</nhs-table-item>
  </nhs-table-head>
  <nhs-table-body>
    <nhs-table-body-row>
      <nhs-table-item>Blisters on lips or around the mouth</nhs-table-item>
      <nhs-table-item>cold sores</nhs-table-item>
    </nhs-table-body-row>
    <nhs-table-body-row>
      <nhs-table-item>Itchy, dry, cracked, sore</nhs-table-item>
      <nhs-table-item>eczema</nhs-table-item>
    </nhs-table-body-row>
    <nhs-table-body-row>
      <nhs-table-item>Itchy blisters</nhs-table-item>
      <nhs-table-item>shingles, chickenpox</nhs-table-item>
    </nhs-table-body-row>
  </nhs-table-body>
</nhs-table>

```

---

### Taghelper attributes

The table taghelper markup takes the following attributes:

| Name                   | Type       | Required  | Description  |
| -----------------------|------------|-----------|--------------|
| **nhs-table-body-row**               | Taghelper      | Yes       | Taghelper representing a table body row. |
| **nhs-table-head**               | Taghelper      | No        | Optional table head. |
| **nhs-table-item**               | Taghelper      | Yes        | Taghelper representing a table row cell. |
| **nhs-table-body**               | Taghelper      | Yes        | Taghelper representing a table body. |
| **nhs-table-body-row**               | Taghelper      | Yes        | Taghelper representing a table body row. |
| **is-with-panel**              | boolean    | No        | If set to true, the table is rendered inside a panel with a label. |
| **title-text**            | string     | No        | Heading/label of the panel if the panel argument is set to true. |
| **caption**            | string     | No        | Optional caption for the table. |
| **nhs-table-item.cell-is-header**  | boolean    | No        | If set to true on nhs-table-item, first cell in table row will be a TH instead of a TD. |
