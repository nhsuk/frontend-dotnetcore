# Images

## Guidance

Find out more about the images component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/images).

## Quick start example

[Preview the images component](https://dotnetcorefelpoc.azurewebsites.net/components/images)

### HTML markup

```html
<figure class="nhsuk-image">
  <img class="nhsuk-image__img" src="https://assets.nhs.uk/prod/images/S_1017_allergic-conjunctivitis_M15.2e16d0ba.fill-320x213.jpg" alt="Picture of allergic conjunctivitis">
  <figcaption class="nhsuk-image__caption">
    Itchy, red, watering eyes
  </figcaption>
</figure>

<figure class="nhsuk-image">
  <img class="nhsuk-image__img" src="https://assets.nhs.uk/prod/images/S_1017_allergic-conjunctivitis_M15.2e16d0ba.fill-320x213.jpg" alt="Picture of allergic conjunctivitis">
</figure>
```

### Taghelper markup

```
<nhs-images caption="Itchy, red, watering eyes" src="https://assets.nhs.uk/prod/images/S_1017_allergic-conjunctivitis_M15.2e16d0ba.fill-320x213.jpg"
            alt="Picture of allergic conjunctivitis"></nhs-images>

<nhs-images src="https://assets.nhs.uk/prod/images/S_1017_allergic-conjunctivitis_M15.2e16d0ba.fill-320x213.jpg"
            alt="Picture of allergic conjunctivitis"></nhs-images>
```

### Taghelper attributes

The images taghelper takes the following attributes:

| Name                    | Type     | Required  | Description             |
| ------------------------|----------|-----------|-------------------------|
| **src**                 | string   | Yes       | The source location of the image. |
| **alt**                 | string   | Yes       | The alt text of the image. |
| **caption**             | string   | No        | Optional caption text for the image. |
| **classes**             | string   | No        | Optional additional classes to add to the image container. Separate each class with a space. |
