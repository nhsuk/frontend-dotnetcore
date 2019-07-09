# Nav A-Z

## Quick start example

[Preview the nav a-z component](https://dotnetcorefelpoc.azurewebsites.net/components/nav-a-z)

### HTML markup

```html
<nav class="nhsuk-nav-a-z" id="nhsuk-nav-a-z" role="navigation" aria-label="A to Z Navigation">
  <ol class="nhsuk-nav-a-z__list" role="list">
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#A">A</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <span class="nhsuk-nav-a-z__link--disabled">B</span>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#C">C</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#D">D</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#E">E</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#F">F</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#G">G</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#H">H</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#I">I</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#J">J</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#K">K</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#L">L</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#M">M</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#N">N</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#O">O</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#P">P</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#Q">Q</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#R">R</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#S">S</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#T">T</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#U">U</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#V">V</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#W">W</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#X">X</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#Y">Y</a>
    </li>
    <li class="nhsuk-nav-a-z__item">
      <a class="nhsuk-nav-a-z__link" href="#Z">Z</a>
    </li>
  </ol>
</nav>
```

### Taghelper markup

```
<nhs-nav-a-z>
  <nhs-nav-a-z-item>A</nhs-nav-a-z-item>
  <nhs-nav-a-z-item disabled="true">B</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>C</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>D</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>E</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>F</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>G</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>H</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>I</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>J</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>K</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>L</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>M</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>N</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>O</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>P</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>Q</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>R</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>S</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>T</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>U</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>V</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>W</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>X</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>Y</nhs-nav-a-z-item>
  <nhs-nav-a-z-item>Z</nhs-nav-a-z-item>
</nhs-nav-a-z>

```

### Taghelper attributes

The nav a-z taghelper takes the following attributes:

| Name                  | Type     | Required  | Description  |
| ----------------------|----------|-----------|--------------|
| **nav-a-z-item**             | Taghelper    | Yes       | taghelper representing a navigation item. |
| **nav-a-z-item.disabled**  | boolean  | No        | If set to true, then the navigation item will not be within an anchor element. |
| **classes**           | string   | No        | Optional additional classes to add to the nav a-z. Separate each class with a space. |
