using System.Text.Json.Serialization;

namespace Demo.Web.Models;

/// <summary>
/// Item model that matches the API response structure
/// </summary>
public class Item
{
    /// <summary>
    /// Unique identifier for the item
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Display name of the item
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Category classification of the item
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// When the item was created (UTC)
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the item was last updated (UTC)
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Formatted creation date for display
    /// </summary>
    [JsonIgnore]
    public string FormattedCreatedAt => CreatedAt.ToString("yyyy-MM-dd HH:mm");

    /// <summary>
    /// Formatted update date for display
    /// </summary>
    [JsonIgnore]
    public string FormattedUpdatedAt => UpdatedAt.ToString("yyyy-MM-dd HH:mm");

    /// <summary>
    /// Display-friendly category name with proper casing
    /// </summary>
    [JsonIgnore]
    public string DisplayCategory => string.IsNullOrEmpty(Category) 
        ? "Uncategorized" 
        : char.ToUpper(Category[0]) + Category[1..].ToLower();
}