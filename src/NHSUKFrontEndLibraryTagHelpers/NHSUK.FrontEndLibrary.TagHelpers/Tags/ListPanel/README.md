# List panel

## Quick start example

[Preview the list panel component](https://dotnetcorefelpoc.azurewebsites.net/components/list-panel)

### HTML markup

```html
<ol class="nhsuk-list">
  <li>
    <div class="nhsuk-list-panel">
      <h2 class="nhsuk-list-panel__label" id="A">A</h2>
      <ul class="nhsuk-list-panel__list nhsuk-list-panel__list--with-label">
        <li class="nhsuk-list-panel__item">
          <a class="nhsuk-list-panel__link" href="/conditions/abdominal-aortic-aneurysm/">AAA</a>
        </li>
        <li class="nhsuk-list-panel__item">
          <a class="nhsuk-list-panel__link" href="/conditions/abdominal-aortic-aneurysm/">Abdominal aortic aneurysm</a>
        </li>
        <li class="nhsuk-list-panel__item">
          <a class="nhsuk-list-panel__link" href="/conditions/abscess/">Abscess</a>
        </li>
      </ul>
      <div class="nhsuk-back-to-top">
        <a class="nhsuk-back-to-top__link" href="#nhsuk-nav-a-z">
          <svg class="nhsuk-icon nhsuk-icon__arrow-right" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" aria-hidden="true">
            <path d="M19.6 11.66l-2.73-3A.51.51 0 0 0 16 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z"></path>
          </svg>
          Back to top
        </a>
      </div>
    </div>
  </li>
  <li>
    <div class="nhsuk-list-panel">
      <h2 class="nhsuk-list-panel__label" id="B">B</h2>
      <div class="nhsuk-list-panel__box nhsuk-list-panel__box--with-label">
        <p class="nhsuk-list-panel--results-items__no-results">There are currently no conditions listed</p>
      </div>
      <div class="nhsuk-back-to-top">
        <a class="nhsuk-back-to-top__link" href="#nhsuk-nav-a-z">
          <svg class="nhsuk-icon nhsuk-icon__arrow-right" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" aria-hidden="true">
            <path d="M19.6 11.66l-2.73-3A.51.51 0 0 0 16 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z"></path>
          </svg>
          Back to top
        </a>
      </div>
    </div>
  </li>
  <li>
    <div class="nhsuk-list-panel">
      <h2 class="nhsuk-list-panel__label" id="C">C</h2>
      <ul class="nhsuk-list-panel__list nhsuk-list-panel__list--with-label">
        <li class="nhsuk-list-panel__item">
          <a class="nhsuk-list-panel__link" href="/conditions/chest-pain/">Chest pain</a>
        </li>
        <li class="nhsuk-list-panel__item">
          <a class="nhsuk-list-panel__link" href="/conditions/cold-sores/">Cold sore</a>
        </li>
      </ul>
      <div class="nhsuk-back-to-top">
        <a class="nhsuk-back-to-top__link" href="#nhsuk-nav-a-z">
          <svg class="nhsuk-icon nhsuk-icon__arrow-right" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" aria-hidden="true">
            <path d="M19.6 11.66l-2.73-3A.51.51 0 0 0 16 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z"></path>
          </svg>
          Back to top
        </a>
      </div>
    </div>
  </li>
  <li>
    <div class="nhsuk-list-panel">
      <h2 class="nhsuk-list-panel__label" id="D">D</h2>
      <ul class="nhsuk-list-panel__list nhsuk-list-panel__list--with-label">
        <li class="nhsuk-list-panel__item">
          <a class="nhsuk-list-panel__link" href="/conditions/dandruff/">Dandruff</a>
        </li>
        <li class="nhsuk-list-panel__item">
          <a class="nhsuk-list-panel__link" href="/conditions/dementia/">Dementia</a>
        </li>
        <li class="nhsuk-list-panel__item">
          <a class="nhsuk-list-panel__link" href="/conditions/toothache/">Dental pain</a>
        </li>
      </ul>
      <div class="nhsuk-back-to-top">
        <a class="nhsuk-back-to-top__link" href="#nhsuk-nav-a-z">
          <svg class="nhsuk-icon nhsuk-icon__arrow-right" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" aria-hidden="true">
            <path d="M19.6 11.66l-2.73-3A.51.51 0 0 0 16 9v2H5a1 1 0 0 0 0 2h11v2a.5.5 0 0 0 .32.46.39.39 0 0 0 .18 0 .52.52 0 0 0 .37-.16l2.73-3a.5.5 0 0 0 0-.64z"></path>
          </svg>
          Back to top
        </a>
      </div>
    </div>
  </li>
</ol>
```

### Taghelper markup

```
<nhs-list is-ordered="true">
  <nhs-list-panel label="A" id="A" back-to-top-link="#nhsuk-nav-a-z">
    <nhs-list-panel-item href="/conditions/abdominal-aortic-aneurysm/">AAA</nhs-list-panel-item>
    <nhs-list-panel-item href="/conditions/abdominal-aortic-aneurysm/">Abdominal aortic aneurysm</nhs-list-panel-item>
    <nhs-list-panel-item href="/conditions/abscess/">Abscess</nhs-list-panel-item>
  </nhs-list-panel>
  <nhs-list-panel label="B" id="B" disabled="true" back-to-top-link="#nhsuk-nav-a-z">
    There are currently no conditions listed
  </nhs-list-panel>
  <nhs-list-panel label="C" id="C" back-to-top-link="#nhsuk-nav-a-z">
    <nhs-list-panel-item href="/conditions/chest-pain/">Chest pain</nhs-list-panel-item>
    <nhs-list-panel-item href="/conditions/cold-sores/">Cold sore</nhs-list-panel-item>
  </nhs-list-panel>
  <nhs-list-panel label="D" id="D" back-to-top-link="#nhsuk-nav-a-z">
    <nhs-list-panel-item href="/conditions/dandruff/">Dandruff</nhs-list-panel-item>
    <nhs-list-panel-item href="/conditions/dementia/">Dementia</nhs-list-panel-item>
    <nhs-list-panel-item href="/conditions/toothache/">Dental pain</nhs-list-panel-item>
  </nhs-list-panel>
</nhs-list>

```

### Taghelper attributes

| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **label**           | string   | No        | The text label of the list panel. |
| **id**              | string   | No        | The ID of the label heading. |
| **back-to-top-link**   | string   | No        | The href value of the back to top link. |
| **disabled**         | boolean  | No        | If set to true, this indicates there are no items in the list panel. |
| **nhs-list-panel-item**           | Taghelper    | No        | Taghelper representing a panel item. |
| **nhs-list-panel-item.href**     | string   | No        | The href value of an item in the list panel. |
| **classes**         | string   | No        | Optional additional classes to add to the list panel. Separate each class with a space. |
