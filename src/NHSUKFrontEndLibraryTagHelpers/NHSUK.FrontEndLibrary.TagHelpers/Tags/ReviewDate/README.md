# Review date

## Guidance

Find out more about the review date component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/review-date).

## Quick start example

[Preview the review date component]()

### HTML markup

```html
<div class="nhsuk-review-date">
  <p class="nhsuk-body-s">
    Page last reviewed: 12 February 2016<br>
    Next review due: 1 February 2019
  </p>
</div>
```

### Taghelper markup

```

```

### Taghelper attributes

The review date taghelper markup takes the following attributes:

| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **lastReview**      | string   | No        | The value of the last review date |
| **nextReview**      | string   | No        | The value of the next review date |
| **classes**         | string   | No        | Optional additional classes to add to the review date. Separate each class with a space. |
