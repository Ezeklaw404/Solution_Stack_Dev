namespace front_end_Stack.Models;

/// <summary>
/// Deserialize your users API into this shape (or extend with <see cref="System.Text.Json.Serialization.JsonPropertyNameAttribute"/>).
/// Image URL is read from the first non-empty known property.
/// </summary>
public sealed class ApiUserDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Image { get; set; }

    public string? Avatar { get; set; }

    public string? AvatarUrl { get; set; }

    public string? ImageUrl { get; set; }

    public string? PhotoUrl { get; set; }

    public string? Picture { get; set; }

    public string? ProfileImageUrl { get; set; }

    public string? ProfilePicture { get; set; }
}
