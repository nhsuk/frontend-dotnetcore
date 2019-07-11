# Review date

## Guidance

Find out more about the review date component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/review-date).

## Quick start example

[Preview the review date component](https://dotnetcorefelpoc.azurewebsites.net/components/review-date)

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
<nhs-review-date last-review="12 February 2016" next-review="1 February 2019"></nhs-review-date>
```

### Taghelper attributes

The review date taghelper markup takes the following attributes:

| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **last-review**      | string   | No        | The value of the last review date |
| **next-review**      | string   | No        | The value of the next review date |
| **classes**         | string   | No        | Optional additional classes to add to the review date. Separate each class with a space. |
