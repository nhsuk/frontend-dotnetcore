# Layout

### HTML markup

```html
<div class="nhsuk-width-container">
  <main class="nhsuk-main-wrapper" id="maincontent">
    <div class="nhsuk-grid-row">
      <div class="nhsuk-grid-column-two-thirds">
      </div>
    </div>
    <div class="nhsuk-grid-row">
      <div class="nhsuk-grid-column-full">
      </div>
    </div>
    <div class="nhsuk-grid-row">
      <div class="nhsuk-grid-column-two-thirds">
        @RenderBody()
      </div>
    </div>
  </main>
</div>
```

### Taghelper markup

```
 <nhs-width-container container-width="Standard">
    <nhs-main-wrapper>
      <nhs-grid-row>
        <nhs-grid-column grid-column-width="TwoThirds"></nhs-grid-column>
      </nhs-grid-row>
      <nhs-grid-row>
      <nhs-grid-column grid-column-width="Full"></nhs-grid-column>
      </nhs-grid-row>
      <nhs-grid-row>
        <nhs-grid-column grid-column-width="TwoThirds">
          @RenderBody()
        </nhs-grid-column>
      </nhs-grid-row>
    </nhs-main-wrapper>
  </nhs-width-container>


```
### Taghelper attributes

| Name                      | Type     | Required  | Description             |
| --------------------------|----------|-----------|-------------------------|
| **container-width**             | string   | Yes        | choose from standard or fluid. |
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |
