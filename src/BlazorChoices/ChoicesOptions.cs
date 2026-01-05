namespace BlazorChoices;

/// <summary>
/// Configuration options for Choices.js component
/// </summary>
public class ChoicesOptions
{
    /// <summary>
    /// Enable search functionality
    /// </summary>
    public bool SearchEnabled { get; set; } = true;

    /// <summary>
    /// Show remove button for selected items
    /// </summary>
    public bool RemoveItemButton { get; set; } = false;

    /// <summary>
    /// Sort choices alphabetically
    /// </summary>
    public bool ShouldSort { get; set; } = true;

    /// <summary>
    /// Placeholder text
    /// </summary>
    public string? PlaceholderValue { get; set; }

    /// <summary>
    /// Maximum number of items that can be selected
    /// </summary>
    public int MaxItemCount { get; set; } = -1;

    /// <summary>
    /// Allow duplicate items
    /// </summary>
    public bool DuplicateItemsAllowed { get; set; } = true;

    /// <summary>
    /// Position of dropdown (auto, top, bottom)
    /// </summary>
    public string Position { get; set; } = "auto";

    /// <summary>
    /// Allow adding custom items
    /// </summary>
    public bool AddItems { get; set; } = true;

    /// <summary>
    /// Allow removal of items
    /// </summary>
    public bool RemoveItems { get; set; } = true;

    /// <summary>
    /// Text to show when there are no results
    /// </summary>
    public string NoResultsText { get; set; } = "No results found";

    /// <summary>
    /// Text to show when there are no choices
    /// </summary>
    public string NoChoicesText { get; set; } = "No choices to choose from";
}
