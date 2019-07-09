# Care cards

## Guidance

Find out more about the care card component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/care-cards).

## Quick start examples

### Care card non-urgent (blue)

[Preview the care card non-urgent (blue) component](https://dotnetcorefelpoc.azurewebsites.net/components/care-card-non-urgent)

#### HTML markup

```html
<div class="nhsuk-care-card nhsuk-care-card--non-urgent">
  <div class="nhsuk-care-card__heading-container">
    <h3 class="nhsuk-care-card__heading"><span role="text"><span class="nhsuk-u-visually-hidden">Non-urgent advice: </span>Speak to a GP if:</span></h3>
    <span class="nhsuk-care-card__arrow" aria-hidden="true"></span>
  </div>
  <div class="nhsuk-care-card__content">
    <ul>
      <li>you're not sure it's chickenpox</li>
      <li>the skin around the blisters is red, hot or painful (signs of infection)</li>
      <li>your child is <a href="https://www.nhs.uk/conditions/dehydration">dehydrated</a></li>
      <li>you're concerned about your child or they get worse</li>
    </ul>
    <p>Tell the receptionist you think it's chickenpox before going in. They may recommend a special appointment time if other patients are at risk.</p>
  </div>
</div>
```

#### Taghelper markup

```
<nhs-care-card heading-text="Speak to a GP if" nhs-care-card-type="NonUrgent">
  <ul>
    <li>you're not sure it's chickenpox</li>
    <li>the skin around the blisters is red, hot or painful (signs of infection)</li>
    <li>your child is <a href="https://www.nhs.uk/conditions/dehydration">dehydrated</a></li>
    <li>you're concerned about your child or they get worse</li>
  </ul>
  <p>Tell the receptionist you think it's chickenpox before going in. They may recommend a special appointment time if other patients are at risk.</p>
</nhs-care-card>
```

---

### Care card urgent (red)

[Preview care card urgent (red) component](https://dotnetcorefelpoc.azurewebsites.net/components/care-card-urgent)

#### HTML markup

```html
<div class="nhsuk-care-card nhsuk-care-card--urgent">
  <div class="nhsuk-care-card__heading-container">
    <h3 class="nhsuk-care-card__heading"><span role="text"><span class="nhsuk-u-visually-hidden">Urgent advice: </span>Ask for an urgent GP appointment if:</span></h3>
    <span class="nhsuk-care-card__arrow" aria-hidden="true"></span>
  </div>
  <div class="nhsuk-care-card__content">
    <ul>
      <li>you're an adult and have chickenpox</li>
      <li>you're pregnant and haven't had chickenpox before and you've been near someone with it </li>
      <li>you have a weakened immune system and you've been near someone with chickenpox</li>
      <li>you think your newborn baby has chickenpox</li>
    </ul>
    <p>In these situations, your GP can prescribe medicine to prevent complications. You need to take it within 24 hours of the spots coming out.</p>
  </div>
</div>
```

#### Taghelper markup

```
<nhs-care-card nhs-care-card-type="Urgent" heading-text="Ask for an urgent GP appointment if">
  <ul>
    <li>you're an adult and have chickenpox</li>
    <li>you're pregnant and haven't had chickenpox before and you've been near someone with it </li>
    <li>you have a weakened immune system and you've been near someone with chickenpox</li>
    <li>you think your newborn baby has chickenpox</li>
  </ul>
  <p>In these situations, your GP can prescribe medicine to prevent complications. You need to take it within 24 hours of the spots coming out.</p>
</nhs-care-card>
```

---

### Care card immediate (red and black)

[Preview care card immediate (red and black) component](https://dotnetcorefelpoc.azurewebsites.net/components/care-card-immediate)

#### HTML markup

```html
<div class="nhsuk-care-card nhsuk-care-card--immediate">
  <div class="nhsuk-care-card__heading-container">
    <h3 class="nhsuk-care-card__heading"><span role="text"><span class="nhsuk-u-visually-hidden">Immediate action required: </span>Call 999 if you have sudden chest pain that:</span></h3>
    <span class="nhsuk-care-card__arrow" aria-hidden="true"></span>
  </div>
  <div class="nhsuk-care-card__content">
    <ul>
      <li>spreads to your arms, back, neck or jaw</li>
      <li>makes your chest feel tight or heavy</li>
      <li>also started with shortness of breath, sweating and feeling or being sick</li>
    </ul>
    <p>You could be having a heart attack. Call 999 immediately as you need immediate treatment in hospital.</p>
  </div>
</div>
```

#### Taghelper markup

```
<nhs-care-card nhs-care-card-type="Immediate" heading-text="Call 999 if you have sudden chest pain that">
  <ul>
    <li>spreads to your arms, back, neck or jaw</li>
    <li>makes your chest feel tight or heavy</li>
    <li>also started with shortness of breath, sweating and feeling or being sick</li>
  </ul>
  <p>You could be having a heart attack. Call 999 immediately as you need immediate treatment in hospital.</p>
</nhs-care-card>
```

---

### Taghelper attributes

The care card taghelper takes the following attributes:

| Name                    | Type     | Required  | Description  |
| ------------------------|----------|-----------|--------------|
| **nhs-care-card-type**                | string   | Yes       | Care card component variant type - non-urgent, urgent or immediate |
| **heading-text**             | string   | Yes       | Heading to be used within the care card component |
| **classes**             | string   | No        | Optional additional classes to add to the care card. Separate each class with a space. |

