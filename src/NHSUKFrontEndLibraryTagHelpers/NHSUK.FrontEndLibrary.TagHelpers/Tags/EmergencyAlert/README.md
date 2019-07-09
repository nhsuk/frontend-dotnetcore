# Emergency alert

## Quick start example

[Preview the emergency alert component](https://dotnetcorefelpoc.azurewebsites.net/components/emergency-alert)

### HTML markup

```html
<div class="nhsuk-global-alert" id="nhsuk-global-alert">
  <div class="nhsuk-width-container">
    <div class="nhsuk-grid-row">
      <div class="nhsuk-grid-column-full">
        <div class="nhsuk-global-alert__content">
          <h2 class="nhsuk-global-alert__heading"><span class="nhsuk-u-visually-hidden">Alert: </span>National flu outbreak</h2>
          <p class="nhsuk-global-alert__message">There has been a national flu outbreak. <a class="nhsuk-u-nowrap" href="https://www.nhs.uk" >How does it affect me</a></p>
          <p class="nhsuk-global-alert__updated">Updated 23 mins ago</p>
        </div>
      </div>
    </div>
  </div>
</div>
```

### Taghelper markup

```
<nhs-emergency-alert title-text="National flu outbreak" last-updated="Updated 23 mins ago" href="https://www.nhs.uk"
                     link-label="How does it affect me">There has been a national flu outbreak.</nhs-emergency-alert>


```

### Taghelper attributes

The emergency alert taghelper takes the following attributes:

| Name              | Type     | Required  | Description |
| ------------------|----------|-----------|-------------|
| **title-text**         | string   | Yes       | Title to be displayed in the emergency alert component. |
| **link-label**         | string   | No        | Optional text to be displayed within the link at the end of the content |
| **href**          | string   | No        | Optional value of the link href attribute at the end of the content |
| **last-updated**   | string   | No        | Optional text displayed below the main content to show last updated message |
| **classes**       | string   | No        | Optional additional classes to add to the emergency alert container. Separate each class with a space. |
