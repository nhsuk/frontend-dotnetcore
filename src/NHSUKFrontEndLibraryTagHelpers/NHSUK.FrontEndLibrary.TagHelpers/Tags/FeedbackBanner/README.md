# Feedback banner

## Dependencies

For this component to work, you need to make sure you include the required JavaScript. You can either include the
compiled JavaScript for all components `nhsuk.min.js` or the individual component JavaScript `feedback-banner.js`.

The Feedback banner should be used below the footer component in templates for the sticky scroll JavaScript to work.

## Quick start example

[Preview the feedback banner component](https://dotnetcorefelpoc.azurewebsites.net/components/feedback-banner)

### HTML markup

```html
<div class="nhsuk-feedback-banner" id="nhsuk-feedback-banner">
  <div class="nhsuk-width-container">
    <div class="nhsuk-grid-row">
      <div class="nhsuk-grid-column-full">
        <div class="nhsuk-feedback-banner__content">
          <h2 class="nhsuk-feedback-banner__heading">Help us make the NHS website better</h2>
          <p class="nhsuk-feedback-banner__message">Your feedback helps us improve the NHS website. <a href="https://www.nhs.uk" class="nhsuk-u-nowrap">Take our short survey</a>.</p>
          <button class="nhsuk-feedback-banner__close" id="nhsuk-feedback-banner-close" type="button">Close<span class="nhsuk-u-visually-hidden"> feedback invite</span></button>
        </div>
      </div>
    </div>
  </div>
</div>
```

### Taghelper markup

```
<nhs-feedback-banner title-text="Help us make the NHS website better" href="https://www.nhs.uk"
 link-label="Take our short survey">Your feedback helps us improve the NHS website.</nhs-feedback-banner>

```

### Taghelper attributes

The feedback banner taghelper takes the following attributes:

| Name              | Type     | Required  | Description |
| ------------------|----------|-----------|-------------|
| **title-text**         | string   | Yes       | Title to be displayed in the feedback banner component. |
| **link-label**         | string   | No        | Optional text to be displayed within the link at the end of the content |
| **href**          | string   | No        | Optional value of the link href attribute at the end of the content |
| **classes**       | string   | No        | Optional additional classes to add to the feedback banner container. Separate each class with a space. |
