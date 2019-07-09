# Contents list

## Guidance

Find out more about the contents list component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/contents-list).

## Quick start example

[Preview the contents list component](https://dotnetcorefelpoc.azurewebsites.net/components/content-list)

### HTML markup

```html
<nav class="nhsuk-contents-list" role="navigation" aria-label="Pages in this guide">
  <h2 class="nhsuk-u-visually-hidden">Contents</h2>
  <ol class="nhsuk-contents-list__list">
    <li class="nhsuk-contents-list__item" aria-current="page">
      <span class="nhsuk-contents-list__current">What is AMD?</span>
    </li>
    <li class="nhsuk-contents-list__item">
      <a class="nhsuk-contents-list__link" href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/symptoms/">Symptoms</a>
    </li>
    <li class="nhsuk-contents-list__item">
      <a class="nhsuk-contents-list__link" href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/getting-diagnosed/">Getting diagnosed</a>
    </li>
    <li class="nhsuk-contents-list__item">
      <a class="nhsuk-contents-list__link" href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/treatment/">Treatments</a>
    </li>
    <li class="nhsuk-contents-list__item">
      <a class="nhsuk-contents-list__link" href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/living-with-amd/">Living with AMD</a>
    </li>
  </ol>
</nav>
```

### Taghelper markup

```
<nhs-contents-list>
  <nhs-contents-list-item current-active-page="true" href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/">What is AMD?
  </nhs-contents-list-item>
  <nhs-contents-list-item href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/symptoms/">Symptoms
  </nhs-contents-list-item>
  <nhs-contents-list-item href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/getting-diagnosed/">Getting diagnosed
  </nhs-contents-list-item>
  <nhs-contents-list-item href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/treatment/">Treatments
  </nhs-contents-list-item>
  <nhs-contents-list-item href="https://www.nhs.uk/conditions/age-related-macular-degeneration-amd/living-with-amd/">Living with AMD
  </nhs-contents-list-item>
</nhs-contents-list>

```

### Taghelper attributes

| Name                    | Type     | Required  | Description  |
| ------------------------|----------|-----------|--------------|
| **nhs-contents-list-item**               | Taghelper    | Yes       | taghelper representing an item in the contents list. |
| **nhs-contents-list-item.href**       | string   | Yes       | Href value of an item in the contents list. |
| **current-active-page**             | boolean  | No        | Current active page in the contents list. |
| **classes**             | string   | No        | Optional additional classes content list container. Separate each class with a space. |
