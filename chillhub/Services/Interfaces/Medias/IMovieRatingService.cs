using chillhub.Models.Dtos.Requests;

namespace chillhub.Services.Interfaces.Medias
{
    public interface IMovieRatingService
    {
        Task<IResult> CreateRatingAsync(MovieRatingCreateRequest request);
        Task<IResult> GetRatingByMovieIdAsync(Guid movieId);
        Task<IResult> UpdateRatingAsync(MovieRatingUpdateRequest request);
    }
}
