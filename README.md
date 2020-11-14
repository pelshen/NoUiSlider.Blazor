# NoUiSlider.Blazor

A Blazor wrapper for [noUiSlider](https://refreshless.com/nouislider/).

![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/NoUiSlider.Blazor)

## Installation

The package is vailable from [Nuget](https://nuget.org/packages/NoUiSlider.Blazor).
Once you've installed the package in your project:
1. In your index.html (WebAssembly) or _Host.cshtml (Server):
    1. Add `<link rel="stylesheet" href="_content/NoUiSlider.Blazor/dist/styles.css" />` to your `<head>
    2. Add `<script src="_content/NoUiSlider.Blazor/dist/bundle.js"></script>` to the bottom of your body
2. To use the slider anywhere, in your _Imports.razor add `@using PELshen.NoUiSider.Blazor`
3. Alternatively you can just add the using in the file you are using the slider.

There is no need to include the noUiSlider code directly, it is bundled in with this package.
