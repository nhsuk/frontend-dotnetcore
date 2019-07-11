# Breadcrumb

## Guidance

Find out more about the breadcrumb component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/breadcrumbs).

## Quick start example

[Preview the breadcrumb component](https://dotnetcorefelpoc.azurewebsites.net/components/breadcrumb)

### HTML markup

```html
<nav class="nhsuk-breadcrumb" aria-label="Breadcrumb">
  <div class="nhsuk-width-container">
    <ol class="nhsuk-breadcrumb__list">
      <li class="nhsuk-breadcrumb__item"><a class="nhsuk-breadcrumb__link" href="/level-one">Level one</a></li>
      <li class="nhsuk-breadcrumb__item"><a class="nhsuk-breadcrumb__link" href="/level-one/level-two">Level two</a></li>
      <li class="nhsuk-breadcrumb__item"><a class="nhsuk-breadcrumb__link" href="/level-one/level-two/level-three">Level three</a></li>
    </ol>
    <p class="nhsuk-breadcrumb__back"><a class="nhsuk-breadcrumb__backlink" href="/level-one/level-two/level-three">Back to Level three</a></p>
  </div>
</nav>
```

### Taghelper markup

```
<nhs-breadcrumb>
  <nhs-breadcrumb-list>
    <nhs-breadcrumb-item href="/level-one">Level one</nhs-breadcrumb-item>
    <nhs-breadcrumb-item href="/level-one/level-two">Level two</nhs-breadcrumb-item>
    <nhs-breadcrumb-item href="/level-one/level-two/level-three">Level three</nhs-breadcrumb-item>
  </nhs-breadcrumb-list>
 <nhs-breadcrumb-backlink href="/level-one/level-two/level-three">Back to Level three</nhs-breadcrumb-backlink>
</nhs-breadcrumb>

```

### Taghelper attributes


| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **nhs-breadcrumb-list**              | taghelper    | Yes       | Taghelper wrapper for breadcrumb list items. |
| **nhs-breadcrumb-item**              | taghelper    | Yes       | Taghelper representing a breadcrumb item. |
| **nhs-breadcrumb-item.href**              | string    | Yes       | Link for the breadcrumbs item. |
| **nhs-breadcrumb-backlink**              | taghelper    | Yes       | Taghelper representing a breadcrumb backlist. |
| **nhs-breadcrumb-backlink.href**              | string    | Yes       | Link of the current page. |
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Breadcrumb component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/breadcrumb) .