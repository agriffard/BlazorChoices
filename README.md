# BlazorChoices

A Blazor component library that wraps [Choices.js](https://github.com/Choices-js/Choices) to provide enhanced select and input elements with search, tags, and more.

## Features

- ✅ Single and multiple select support
- ✅ Tags input with add/remove
- ✅ Built-in search functionality
- ✅ Configurable options
- ✅ Event callbacks for value changes
- ✅ Full Blazor interop support
- ✅ .NET 10 support
- ✅ Clean and intuitive API

## Demo

Check out the [live demo on GitHub Pages](https://agriffard.github.io/BlazorChoices/) to see all features in action.

## Installation

Add the BlazorChoices component library to your Blazor project:

```bash
dotnet add package BlazorChoices
```

Or add it directly to your `.csproj` file:

```xml
<PackageReference Include="BlazorChoices" Version="1.0.0" />
```

## Getting Started

### 1. Add using statement

Add the following to your `_Imports.razor`:

```razor
@using BlazorChoices
```

### 2. Include CSS and JavaScript

Add the following to your `index.html` (Blazor WebAssembly) or `_Host.cshtml` (Blazor Server):

```html
<!-- In the <head> section -->
<link href="_content/BlazorChoices/lib/choices/choices.min.css" rel="stylesheet" />

<!-- Before the closing </body> tag -->
<script src="_content/BlazorChoices/lib/choices/choices.min.js"></script>
```

## Usage Examples

### Simple Select

```razor
<ChoicesSelect OnChange="@OnSingleChange">
    <option value="">Select a fruit...</option>
    <option value="apple">Apple</option>
    <option value="banana">Banana</option>
    <option value="orange">Orange</option>
</ChoicesSelect>

@code {
    private string selectedValue = string.Empty;

    private void OnSingleChange(string value)
    {
        selectedValue = value;
    }
}
```

### Multiple Select

```razor
<ChoicesSelect Multiple="true" OnChangeMultiple="@OnMultipleChange" Options="@options">
    <option value="us">United States</option>
    <option value="uk">United Kingdom</option>
    <option value="fr">France</option>
    <option value="de">Germany</option>
</ChoicesSelect>

@code {
    private string[] selectedValues = Array.Empty<string>();
    
    private ChoicesOptions options = new()
    {
        RemoveItemButton = true,
        SearchEnabled = true,
        PlaceholderValue = "Choose countries..."
    };

    private void OnMultipleChange(string[] values)
    {
        selectedValues = values;
    }
}
```

### Tags Input

```razor
<ChoicesInput OnTagsChanged="@OnTagsChange" Options="@tagOptions" />

@code {
    private string[] tags = Array.Empty<string>();
    
    private ChoicesOptions tagOptions = new()
    {
        RemoveItemButton = true,
        AddItems = true,
        DuplicateItemsAllowed = false,
        MaxItemCount = 10
    };

    private void OnTagsChange(string[] values)
    {
        tags = values;
    }
}
```

## Configuration Options

The `ChoicesOptions` class provides the following configuration options:

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `SearchEnabled` | bool | true | Enable search functionality |
| `RemoveItemButton` | bool | false | Show remove button for selected items |
| `ShouldSort` | bool | true | Sort choices alphabetically |
| `PlaceholderValue` | string | null | Placeholder text |
| `MaxItemCount` | int | -1 | Maximum number of items that can be selected (-1 = unlimited) |
| `DuplicateItemsAllowed` | bool | true | Allow duplicate items |
| `Position` | string | "auto" | Position of dropdown (auto, top, bottom) |
| `AddItems` | bool | true | Allow adding custom items |
| `RemoveItems` | bool | true | Allow removal of items |
| `NoResultsText` | string | "No results found" | Text shown when there are no results |
| `NoChoicesText` | string | "No choices to choose from" | Text shown when there are no choices |

## API Reference

### ChoicesSelect Component

**Parameters:**
- `Multiple` (bool): Enable multiple selection mode
- `Options` (ChoicesOptions): Configuration options
- `OnChange` (EventCallback<string>): Event fired when a single value changes
- `OnChangeMultiple` (EventCallback<string[]>): Event fired when multiple values change
- `Id` (string): HTML id attribute
- `Class` (string): CSS class
- `ChildContent` (RenderFragment): Option elements

**Methods:**
- `InitAsync()`: Initialize the Choices.js instance
- `DestroyAsync()`: Destroy the Choices.js instance
- `SetValueAsync(object value)`: Set the selected value programmatically
- `GetValueAsync()`: Get the current selected value

### ChoicesInput Component

**Parameters:**
- `Options` (ChoicesOptions): Configuration options
- `OnTagsChanged` (EventCallback<string[]>): Event fired when tags change
- `Id` (string): HTML id attribute
- `Class` (string): CSS class

**Methods:**
- `InitAsync()`: Initialize the Choices.js instance
- `DestroyAsync()`: Destroy the Choices.js instance
- `SetValueAsync(object value)`: Set the tags programmatically
- `GetValueAsync()`: Get the current tags

## Building the Sample

To build and run the sample application:

```bash
git clone https://github.com/agriffard/BlazorChoices.git
cd BlazorChoices
dotnet build
cd samples/BlazorChoices.Sample
dotnet run
```

Then navigate to `http://localhost:5000` in your browser.

## Publishing to GitHub Pages

To publish the sample application to GitHub Pages:

```bash
cd samples/BlazorChoices.Sample
dotnet publish -c Release -o publish
# Configure base href for GitHub Pages
# Then deploy the publish/wwwroot folder to gh-pages branch
```

## Technology Stack

- .NET 10
- Blazor WebAssembly
- Choices.js v11.2.0
- JavaScript Interop

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is open source and available under the MIT License.

## Acknowledgments

- [Choices.js](https://github.com/Choices-js/Choices) - The excellent JavaScript library that powers this component
- Built with ❤️ for the Blazor community