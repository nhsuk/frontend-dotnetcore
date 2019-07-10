# Hero

## Quick start examples

### Hero with heading and content

[Preview the hero with heading and content component](https://dotnetcorefelpoc.azurewebsites.net/components/hero)

#### HTML markup

```html
<section class="nhsuk-hero">
  <div class="nhsuk-width-container nhsuk-hero--border">
    <div class="nhsuk-grid-row">
      <div class="nhsuk-grid-column-two-thirds">
        <div class="nhsuk-hero__wrapper">
          <h1 class="nhsuk-u-margin-bottom-3">We’re here for you</h1>
          <p class="nhsuk-body-l nhsuk-u-margin-bottom-0">Helping you take control of your health and wellbeing.</p>
        </div>
      </div>
    </div>
  </div>
</section>
```

#### Taghelper markup

```
<nhs-hero title-text="We’re here for you">Helping you take control of your health and wellbeing.</nhs-hero>
```
---

### Hero with image, heading and content

[Preview the hero with image, heading and content component](https://dotnetcorefelpoc.azurewebsites.net/components/hero-image-content)

#### HTML markup

```html
<section class="nhsuk-hero nhsuk-hero--image nhsuk-hero--image-description" style="background-image: url('https://assets.nhs.uk/prod/images/S_0818_homepage_hero_1_F0147446.width-1000.jpg');">
  <div class="nhsuk-hero__overlay">
    <div class="nhsuk-width-container">
      <div class="nhsuk-grid-row">
        <div class="nhsuk-grid-column-two-thirds">
          <div class="nhsuk-hero-content">
            <h1 class="nhsuk-u-margin-bottom-3">We’re here for you</h1>
            <p class="nhsuk-body-l nhsuk-u-margin-bottom-0">Helping you take control of your health and wellbeing.</p>
            <span class="nhsuk-hero__arrow" aria-hidden="true"></span>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
```

#### Taghelper markup 

```
<nhs-hero title-text="We’re here for you" 
image-url="https://assets.nhs.uk/prod/images/S_0818_homepage_hero_1_F0147446.width-1000.jpg">Helping you take control of your health and wellbeing.</nhs-hero>
```

---

### Hero with image only

[Preview the hero with image only component](https://dotnetcorefelpoc.azurewebsites.net/components/hero-image)

#### HTML markup

```html
<section class="nhsuk-hero nhsuk-hero--image" style="background-image: url('https://assets.nhs.uk/prod/images/S_0818_homepage_hero_1_F0147446.width-1000.jpg');">
  <div class="nhsuk-hero__overlay">
  </div>
</section>
```

#### Taghelper markup 

```
<nhs-hero image-url="https://assets.nhs.uk/prod/images/S_0818_homepage_hero_1_F0147446.width-1000.jpg"></nhs-hero>
```
---

### Taghelper attributes

The hero taghelper takes the following attributes:

| Name                       | Type     | Required  | Description  |
| ---------------------------|----------|-----------|--------------|
| **title-text**                | string   | No        | Text heading of the hero component. |
| **image-url**               | string   | No        | URL of the image of the hero component. |
| **classes**                | string   | No        | Optional additional classes to add to the hero container. Separate each class with a space. |
