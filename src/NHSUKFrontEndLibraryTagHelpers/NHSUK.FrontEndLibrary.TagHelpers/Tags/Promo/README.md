# Promo

## Quick start examples

### Promo

[Preview the promo component](https://dotnetcorefelpoc.azurewebsites.net/components/promo)

#### HTML markup

```html
<div class="nhsuk-promo">
  <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
    <div class="nhsuk-promo__content">
      <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
      <p class="nhsuk-promo__description">Please register today. Donating blood is easy, and saves lives.</p>
    </div>
  </a>
</div>
```

#### Taghelper markup

```
<nhs-promo nhs-promo-size="Standard" href="https://www.nhs.uk"
           title-text="Save a life: give blood" description-text="Please register today. Donating blood is easy, and saves lives."></nhs-promo>
```

---

### Promo with image

[Preview the promo with image component](https://dotnetcorefelpoc.azurewebsites.net/components/promo-image)

#### HTML markup

```html
<div class="nhsuk-promo">
  <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
    <img class="nhsuk-promo__img" src="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg" alt="">
    <div class="nhsuk-promo__content">
      <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
      <p class="nhsuk-promo__description">Please register today. Donating blood is easy, and saves lives.</p>
    </div>
  </a>
</div>
```

#### Taghelper markup

```
<nhs-promo nhs-promo-size="Standard" href="https://www.nhs.uk" image-url="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg"
           title-text="Save a life: give blood" description-text="Please register today. Donating blood is easy, and saves lives."></nhs-promo>

```

---

### Promo with no description

[Preview the promo with no description component](https://dotnetcorefelpoc.azurewebsites.net/components/promo-no-description)

#### HTML markup

```html
<div class="nhsuk-promo">
  <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
    <div class="nhsuk-promo__content">
      <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
    </div>
  </a>
</div>
```

#### Taghelper markup

```
<nhs-promo nhs-promo-size="Standard" href="https://www.nhs.uk"
           title-text="Save a life: give blood"></nhs-promo>
```

---

### Small promo

[Preview the small promo component](https://dotnetcorefelpoc.azurewebsites.net/components/promo-small)

#### HTML markup

```html
<div class="nhsuk-promo nhsuk-promo--small">
  <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
    <div class="nhsuk-promo__content">
      <h3 class="nhsuk-promo__heading">Access your GP record</h3>
      <p class="nhsuk-promo__description">Please register today. Donating blood is easy, and saves lives.</p>
    </div>
  </a>
</div>
```

#### Taghelper markup

```
<nhs-promo nhs-promo-size="Small" href="https://www.nhs.uk"
           title-text="Access your GP record" description-text="Please register today. Donating blood is easy, and saves lives."></nhs-promo>

```

---

### Promo group

[Preview the promo group component](https://dotnetcorefelpoc.azurewebsites.net/components/promo-group)

#### HTML markup

```html
<div class="nhsuk-grid-row nhsuk-promo-group">
  <div class="nhsuk-grid-column-one-half nhsuk-promo-group__item">
    <div class="nhsuk-promo">
      <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
        <img class="nhsuk-promo__img" src="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg" alt="">
        <div class="nhsuk-promo__content">
          <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
          <p class="nhsuk-promo__description">Please register today. Donating blood is easy, and saves lives.</p>
        </div>
      </a>
    </div>
  </div>
  <div class="nhsuk-grid-column-one-half nhsuk-promo-group__item">
    <div class="nhsuk-promo">
      <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
        <img class="nhsuk-promo__img" src="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg" alt="">
        <div class="nhsuk-promo__content">
          <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
          <p class="nhsuk-promo__description">Please register today. Donating blood is easy, and saves lives.</p>
        </div>
      </a>
    </div>
  </div>
</div>
<div class="nhsuk-grid-row nhsuk-promo-group">
  <div class="nhsuk-grid-column-one-third nhsuk-promo-group__item">
    <div class="nhsuk-promo">
      <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
        <img class="nhsuk-promo__img" src="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg" alt="">
        <div class="nhsuk-promo__content">
          <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
          <p class="nhsuk-promo__description">Please register today. Donating blood is easy, and saves lives.</p>
        </div>
      </a>
    </div>
  </div>
  <div class="nhsuk-grid-column-one-third nhsuk-promo-group__item">
    <div class="nhsuk-promo">
      <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
        <img class="nhsuk-promo__img" src="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg" alt="">
        <div class="nhsuk-promo__content">
          <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
          <p class="nhsuk-promo__description">Please register today. Donating blood is easy, and saves lives.</p>
        </div>
      </a>
    </div>
  </div>
  <div class="nhsuk-grid-column-one-third nhsuk-promo-group__item">
    <div class="nhsuk-promo">
      <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
        <img class="nhsuk-promo__img" src="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg" alt="">
        <div class="nhsuk-promo__content">
          <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
          <p class="nhsuk-promo__description">Please register today. Donating blood is easy, and saves lives.</p>
        </div>
      </a>
    </div>
  </div>
</div>
<div class="nhsuk-grid-row nhsuk-promo-group">
  <div class="nhsuk-grid-column-one-half nhsuk-promo-group__item">
    <div class="nhsuk-promo nhsuk-promo--small">
      <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
        <div class="nhsuk-promo__content">
          <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
        </div>
      </a>
    </div>
  </div>
  <div class="nhsuk-grid-column-one-half nhsuk-promo-group__item">
    <div class="nhsuk-promo nhsuk-promo--small">
      <a class="nhsuk-promo__link-wrapper" href="https://www.nhs.uk">
        <div class="nhsuk-promo__content">
          <h3 class="nhsuk-promo__heading">Save a life: give blood</h3>
        </div>
      </a>
    </div>
  </div>
</div>
```

#### Taghelper markup

```
 <nhs-promo-group grid-column-width="OneHalf">
    <nhs-promo nhs-promo-size="Standard" href="https://www.nhs.uk" image-url="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg"
               title-text="Save a life: give blood" description-text="Please register today. Donating blood is easy, and saves lives."></nhs-promo>
    <nhs-promo nhs-promo-size="Standard" href="https://www.nhs.uk" image-url="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg"
               title-text="Save a life: give blood" description-text="Please register today. Donating blood is easy, and saves lives."></nhs-promo>
  </nhs-promo-group>
  <nhs-promo-group grid-column-width="OneThird">
    <nhs-promo nhs-promo-size="Standard" href="https://www.nhs.uk" image-url="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg"
               title-text="Save a life: give blood" description-text="Please register today. Donating blood is easy, and saves lives."></nhs-promo>
    <nhs-promo nhs-promo-size="Standard" href="https://www.nhs.uk" image-url="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg"
               title-text="Save a life: give blood" description-text="Please register today. Donating blood is easy, and saves lives."></nhs-promo>
    <nhs-promo nhs-promo-size="Standard" href="https://www.nhs.uk" image-url="https://assets.nhs.uk/prod/images/MS_1018_give_blood.2e16d0ba.fill-2400x1350.jpg"
               title-text="Save a life: give blood" description-text="Please register today. Donating blood is easy, and saves lives."></nhs-promo>
  </nhs-promo-group>
  <nhs-promo-group grid-column-width="OneHalf">
    <nhs-promo nhs-promo-size="Small" href="https://www.nhs.uk"
               title-text="Save a life: give blood"></nhs-promo>
    <nhs-promo nhs-promo-size="Small" href="https://www.nhs.uk"
               title-text="Save a life: give blood"></nhs-promo>
  </nhs-promo-group>
```

---

### Taghelper attributes

The promo taghelper takes the following attributes:

| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **href**            | string   | Yes       | The value of the promo href attribute |
| **title-text**         | string   | Yes       | The text heading of the promo |
| **imgage-url**          | string   | No        | The URL of the image in the promo |
| **description-text**     | string   | No        | The text description of the promo |
| **classes**         | string   | No        | Optional additional classes to add to the promo. Separate each class with a space. For the small promo, use `nhsuk-promo--small` |
