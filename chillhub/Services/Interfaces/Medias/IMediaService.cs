using chillhub.Models.Dtos.Requests;
using Microsoft.AspNetCore.Http;

namespace chillhub.Services.Interfaces.Medias
{
    public interface IMediaService
    {
        Task<IResult> CreateMediasBatchAsync(List<MediaCreateRequest> requests);
        Task<IResult> UpdateMediasBatchAsync(List<MediaUpdateRequest> requests);
        Task<IResult> SearchMediasAsync(MediaFilterRequest request);
        Task<IResult> BatchReactionAsync(List<MediaReactionRequest> requests);
        Task<IResult> GetReactionCursorAsync(MediaReactionFilterRequest request);
    }
}