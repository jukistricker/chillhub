using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Mapping;

public static class UserMapping
{
    public static UserResponse? ToResponse(User? user)
    {
        if (user == null) return null;

        return new UserResponse
        {
            Id = user.Id,
            CreatedAt = user.CreatedAt,
            CreatedBy = user.CreatedBy,
            UpdatedAt = user.UpdatedAt,
            UpdatedBy = user.UpdatedBy,

            Username = user.Username,
            Email = user.Email,
            FullName = user.FullName,
            AvatarUrl = user.AvatarUrl,
            Provider = user.Provider
        };
    }

    public static CursorResponse<UserResponse> ToCursorResponse(CursorResponse<User> source)
    {
        var targetItems = new List<UserResponse>(source.Items.Count);

        foreach (var item in source.Items)
        {
            var mapped = ToResponse(item);
            if (mapped != null)
            {
                targetItems.Add(mapped);
            }
        }

        return new CursorResponse<UserResponse>
        {
            Items = targetItems,
            NextCursor = source.NextCursor,
            HasNextPage = source.HasNextPage
        };
    }
}
