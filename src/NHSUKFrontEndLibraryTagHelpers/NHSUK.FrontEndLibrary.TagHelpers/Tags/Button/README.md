# Button

## Guidance

Find out more about the button component and when to use it in the [NHS digital service manual](https://beta.nhs.uk/service-manual/styles-components-patterns/buttons).

## Quick start examples

### Button

[Preview the button component](https://dotnetcorefelpoc.azurewebsites.net/components/button)

#### HTML markup

```html
<button class="nhsuk-button" type="submit">
  Save and continue
</button>
```

#### Taghelper markup

```
<button nhs-button-type="Standard">Save and continue</button>
```
---

### Button as a link

[Preview the button as a link component](https://dotnetcorefelpoc.azurewebsites.net/components/button-link)

#### HTML markup

```html
<a href="/" role="button" draggable="false" class="nhsuk-button">
  Link button
</a>
```

#### Taghelper markup

```
<a nhs-anchor-type="Button" href="/" aria-disabled="True">Link button</a>
```
---

### Button disabled

[Preview the button disabled component](https://dotnetcorefelpoc.azurewebsites.net/components/button-disabled)

#### HTML markup

```html
<button class="nhsuk-button nhsuk-button--disabled" type="submit" disabled="disabled" aria-disabled="true">
  Disabled button
</button>
```

#### Taghelper markup

```
<button nhs-button-type="Standard" disabled>Disabled button</button>
```

---

### Button secondary

[Preview the button secondary component](https://dotnetcorefelpoc.azurewebsites.net/components/button-secondary)

#### HTML markup

```html
<button class="nhsuk-button nhsuk-button--secondary" type="submit">
  Save and continue
</button>
```

#### Taghelper markup

```
<button nhs-button-type="Secondary">Find my location</button>
```

---

### Button reverse

[Preview the button reverse component](https://dotnetcorefelpoc.azurewebsites.net/components/button-reverse)

#### HTML markup

```html
<button class="nhsuk-button nhsuk-button--reverse" type="submit">
  Save and continue
</button>
```

#### Taghelper markup

```
<button nhs-button-type="Reverse">Save and continue</button>
```

### Taghelper attributes
The button taghelper takes the following attributes:


| Name                | Type     | Required  | Description  |
| --------------------|----------|-----------|--------------|
| **nhs-button-type**                | string   | Yes       | specifies the type of button e.g reverse, secondary, link, Standard  |
| **classes**             | string   | No        | Optional additional classes to add to the breadcrumbs container. Separate each class with a space. |

This component and documentation has been taken from [NHS.UK Frontend - Button component](https://github.com/nhsuk/nhsuk-frontend/tree/master/packages/components/button) .
