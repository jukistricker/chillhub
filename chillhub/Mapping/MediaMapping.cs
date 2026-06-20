using chillhub.Entities.Auth;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Mapping
{
    public static class MediaMapping
    {
        public static MediaResponse ToResponse(Media media)
        {
            return new MediaResponse
            {
                Id=media.Id,
                CreatedAt=media.CreatedAt,
                CreatedBy=media.CreatedBy,
                Title=media.Title,
                Description=media.Description,
                Thumbnail=media.Thumbnail,
                Duration=media.Duration,
                ViewCount=media.ViewCount,
                UserId=media.UserId,
                FolderId=media.FolderId,
                Type=media.Type,
                LikeCount=media.LikeCount,
                DislikeCount=media.DislikeCount,
                OverallRating=media.OverallRating,
                MediaStatus=media.MediaStatus,
                User= new UserDto
                {
                    Id = media.User.Id,
                    AvatarUrl= media.User.AvatarUrl,
                    CreatedAt=media.User.CreatedAt,
                    Username=media.User.Username,
                    FullName=media.User.FullName,
                }
            };
        }

        public static CursorResponse<MediaResponse> ToResponseList(CursorResponse<Media> source)
        {
            var targetItems = new List<MediaResponse>(source.Items.Count);

            foreach (var item in source.Items)
            {
                var mapped = ToResponse(item);
                if (mapped != null)
                {
                    targetItems.Add(mapped);
                }
            }

            return new CursorResponse<MediaResponse>
            {
                Items = targetItems,
                NextCursor = source.NextCursor,
                HasNextPage = source.HasNextPage
            };
        }
    }
}
