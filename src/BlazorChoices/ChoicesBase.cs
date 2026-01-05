using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;

namespace BlazorChoices;

/// <summary>
/// Base class for Choices components
/// </summary>
public abstract class ChoicesBase : ComponentBase, IAsyncDisposable
{
    [Inject]
    protected IJSRuntime JSRuntime { get; set; } = null!;

    /// <summary>
    /// Configuration options for Choices.js
    /// </summary>
    [Parameter]
    public ChoicesOptions Options { get; set; } = new();

    /// <summary>
    /// HTML id attribute for the element
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

    /// <summary>
    /// CSS class for the element
    /// </summary>
    [Parameter]
    public string? Class { get; set; }

    /// <summary>
    /// Additional HTML attributes
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    protected string ElementId { get; private set; } = string.Empty;
    protected DotNetObjectReference<ChoicesBase>? DotNetReference;
    private IJSObjectReference? _module;
    private bool _initialized;

    protected override void OnInitialized()
    {
        ElementId = Id ?? $"choices-{Guid.NewGuid():N}";
    }

    /// <summary>
    /// Initialize the Choices.js instance
    /// </summary>
    public async Task InitAsync()
    {
        if (_initialized)
            return;

        try
        {
            _module = await JSRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorChoices/blazorChoices.js");

            DotNetReference = DotNetObjectReference.Create(this);

            var options = JsonSerializer.Serialize(Options, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });

            var result = await _module.InvokeAsync<bool>(
                "init",
                ElementId,
                JsonSerializer.Deserialize<JsonElement>(options),
                DotNetReference,
                nameof(OnChangeInternal));

            _initialized = result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error initializing Choices: {ex.Message}");
        }
    }

    /// <summary>
    /// Destroy the Choices.js instance
    /// </summary>
    public async Task DestroyAsync()
    {
        if (!_initialized || _module == null)
            return;

        try
        {
            await _module.InvokeVoidAsync("destroy", ElementId);
            _initialized = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error destroying Choices: {ex.Message}");
        }
    }

    /// <summary>
    /// Set the value of the component
    /// </summary>
    public async Task SetValueAsync(object value)
    {
        if (!_initialized || _module == null)
            return;

        try
        {
            await _module.InvokeVoidAsync("setValue", ElementId, value);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error setting value: {ex.Message}");
        }
    }

    /// <summary>
    /// Get the current value of the component
    /// </summary>
    public async Task<object?> GetValueAsync()
    {
        if (!_initialized || _module == null)
            return null;

        try
        {
            return await _module.InvokeAsync<object>("getValue", ElementId);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting value: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Internal callback for change events
    /// </summary>
    [JSInvokable]
    public abstract Task OnChangeInternal(JsonElement value);

    public async ValueTask DisposeAsync()
    {
        await DestroyAsync();

        DotNetReference?.Dispose();

        if (_module != null)
        {
            try
            {
                await _module.DisposeAsync();
            }
            catch
            {
                // Ignore disposal errors
            }
        }

        GC.SuppressFinalize(this);
    }
}
