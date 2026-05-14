namespace front_end_Stack.Models;

public sealed class UserReviewViewModel
{
    public UserReviewViewModel(string displayName, string imageUrl, int stars)
    {
        DisplayName = displayName;
        ImageUrl = imageUrl;
        Stars = stars;
    }

    public string DisplayName { get; }

    public string ImageUrl { get; }

    /// <summary>Random 1–5 rating assigned when the user list is loaded.</summary>
    public int Stars { get; }
}
