namespace front_end_Stack.Models;

public static class ApiUserDtoMapper
{
    private const string FallbackImage = "images/burger.jpg";

    public static string ResolveDisplayName(ApiUserDto u)
    {
        if (!string.IsNullOrWhiteSpace(u.Name))
        {
            return u.Name.Trim();
        }

        if (!string.IsNullOrWhiteSpace(u.Username))
        {
            return u.Username.Trim();
        }

        if (!string.IsNullOrWhiteSpace(u.Email))
        {
            return u.Email.Trim();
        }

        return u.Id != 0 ? $"User {u.Id}" : "Anonymous";
    }

    public static string ResolveImageUrl(ApiUserDto u)
    {
        foreach (var candidate in new[]
                 {
                     u.ProfileImageUrl,
                     u.ProfilePicture,
                     u.AvatarUrl,
                     u.ImageUrl,
                     u.PhotoUrl,
                     u.Picture,
                     u.Avatar,
                     u.Image,
                 })
        {
            if (!string.IsNullOrWhiteSpace(candidate))
            {
                return candidate.Trim();
            }
        }

        return FallbackImage;
    }
}
