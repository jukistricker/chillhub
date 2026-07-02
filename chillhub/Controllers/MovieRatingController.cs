using chillhub.Models.Dtos.Requests;
using chillhub.Services.Interfaces.Medias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chillhub.Controllers
{
    [ApiController]
    [Route("movie-ratings")]
    [Authorize]
    public class MovieRatingController : ControllerBase
    {
        private readonly IMovieRatingService _ratingService;

        public MovieRatingController(IMovieRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// Gửi đánh giá mới cho bộ phim
        /// </summary>
        [HttpPost]
        public async Task<IResult> Create([FromBody] MovieRatingCreateRequest request)
        {
            return await _ratingService.CreateRatingAsync(request);
        }

        /// <summary>
        /// Lấy thông tin chi tiết một bản ghi đánh giá
        /// </summary>
        [HttpGet("{movieId:guid}")]
        public async Task<IResult> GetById(Guid movieId)
        {
            return await _ratingService.GetRatingByMovieIdAsync(movieId);
            
        }

        [HttpPut]
        public async Task<IResult> Update([FromBody] MovieRatingUpdateRequest request)
        {
            return await _ratingService.UpdateRatingAsync(request);
            
        }
    }
}