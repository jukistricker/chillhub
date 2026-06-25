using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Models.Enums;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using chillhub.Utils;
using System;
using System.Threading.Tasks;

namespace chillhub.Services.Medias
{
    public class MovieRatingService : IMovieRatingService
    {
        private readonly IMovieRatingRepository _ratingRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieRatingService(IMovieRatingRepository ratingRepository, IMediaRepository mediaRepository, IHttpContextAccessor httpContextAccessor)
        {
            _ratingRepository = ratingRepository;
            _mediaRepository = mediaRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Tạo mới Rating (C)
        /// </summary>
        public async Task<IResult> CreateRatingAsync(MovieRatingCreateRequest request)
        {
            Guid? userId = HttpContextUtil.GetUserId(_httpContextAccessor.HttpContext.User);
            // 1. Validate phim có tồn tại hay không
            var movieExists = await _mediaRepository.AnyAsync(r => r.Id == request.MovieId);
            if (!movieExists)
                return ResponseDto.Create(ResponseCatalog.NotFound, "movie.not_found");

            // 2. Kiểm tra xem user này đã rate phim này chưa để tránh gửi lặp
            var isRated = await _ratingRepository.AnyAsync(r => r.MovieId == request.MovieId && r.UserId == userId.Value);
            if (isRated)
                return ResponseDto.Create(ResponseCatalog.BadRequest, "movie.already_rated");

            // 3. Khởi tạo bản ghi rating đầu tiên
            var rating = new MovieRating
            {
                Id = Guid.CreateVersion7(),
                MovieId = request.MovieId,
                UserId = userId.Value,
                Rating = request.Rating,
                RatingCount = 1,
                CreatedBy = userId.Value,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };

            await _ratingRepository.AddAsync(rating);
            await _ratingRepository.SaveChangesAsync();

            return ResponseDto.Create(ResponseCatalog.Created, "movie.rating_created", rating);
        }

        /// <summary>
        /// Lấy chi tiết Rating (R)
        /// </summary>
        public async Task<IResult> GetRatingByMovieIdAsync(Guid movieId)
        {
            Guid? userId = HttpContextUtil.GetUserId(_httpContextAccessor.HttpContext.User);
            var rating = await _ratingRepository.GetByMovieIdAsync(movieId,userId.Value);
            if (rating == null)
                return ResponseDto.Create(ResponseCatalog.NotFound, "movie.rating_not_found");

            return ResponseDto.Create(ResponseCatalog.Success, "movie.rating_detail", rating);
        }

        /// <summary>
        /// Cập nhật Rating - CHỈ CHO PHÉP UPDATE 1 LẦN (U)
        /// </summary>
        public async Task<IResult> UpdateRatingAsync(MovieRatingUpdateRequest request)
        {
            Guid? userId = HttpContextUtil.GetUserId(_httpContextAccessor.HttpContext.User);
            var rating = await _ratingRepository.GetByIdAsync(request.Id,userId.Value);
            if (rating == null)
                return ResponseDto.Create(ResponseCatalog.NotFound, "movie.rating_not_found");

            // Chặn: Nếu RatingCount >= 2 nghĩa là đã từng cập nhật một lần trước đó rồi
            if (rating.RatingCount >= 2)
            {
                return ResponseDto.Create(ResponseCatalog.BadRequest, "movie.rating.update_limit_exceeded");
            }

            // Tiến hành cập nhật điểm số và nâng counter lên
            rating.Rating = request.Rating;
            rating.RatingCount += 1; // Tăng lên 2, khóa quyền sửa đổi ở các lượt sau
            rating.UpdatedAt = DateTimeOffset.UtcNow;
            rating.UpdatedBy = rating.UserId;

            _ratingRepository.Update(rating);
            await _ratingRepository.SaveChangesAsync();

            return ResponseDto.Create(ResponseCatalog.Success, "movie.rating_updated", rating);
        }
    }
}