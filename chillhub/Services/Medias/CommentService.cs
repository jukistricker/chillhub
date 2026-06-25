using chillhub.Entities.Media;
using chillhub.Mapping; // Giả định bạn có CommentMapping tương tự
using chillhub.Models.Dtos.Requests; // Chứa CommentCreateRequest, CommentUpdateRequest, CommentFilterRequest
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Models.Enums;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using chillhub.Utils;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chillhub.Services.Medias
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMediaRepository _mediaRepository; // Sử dụng để validate EntityId (MediaId)
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommentService(
            ICommentRepository commentRepository,
            IMediaRepository mediaRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _commentRepository = commentRepository;
            _mediaRepository = mediaRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Tạo hàng loạt Comment (Batch) và validate EntityId (MediaId) cùng ReferenceCommentId (nếu có)
        /// </summary>
        public async Task<IResult> CreateCommentsBatchAsync(List<CommentCreateRequest> requests)
        {
            if (requests == null || !requests.Any())
                return ResponseDto.Create(ResponseCatalog.BadRequest, "comment.batch_empty");

            // 1. Validate Media (Giữ nguyên)
            var mediaIds = requests.Select(r => r.EntityId).Distinct().ToList();
            var existingMediaIds = await _mediaRepository.GetExistingIdsAsync(mediaIds);
            var existingMediaSet = new HashSet<Guid>(existingMediaIds);

            // 2. Gom các bản tin cha (ReferenceCommentId)
            var parentCommentIds = requests
                .Where(r => r.ReferenceCommentId.HasValue)
                .Select(r => r.ReferenceCommentId!.Value)
                .Distinct()
                .ToList();

            var existingParentSet = new HashSet<Guid>();
            List<Comment> parentCommentsFromDb = new List<Comment>();

            if (parentCommentIds.Any())
            {
                // Thay vì chỉ lấy Ids, lấy hẳn Object ra để cập nhật trạng thái HasChildren
                parentCommentsFromDb = await _commentRepository.GetByIdsAsync(parentCommentIds);
                existingParentSet = new HashSet<Guid>(parentCommentsFromDb.Select(p => p.Id));
            }

            var newComments = new List<Comment>();
            var newCommentsDict = new Dictionary<Guid, Comment>(); // Dùng để tra cứu nhanh các comment cha nằm trong CHÍNH BATCH NÀY
            int failedCount = 0;

            // 3. Tiến hành map và xử lý
            foreach (var req in requests)
            {
                if (!existingMediaSet.Contains(req.EntityId))
                {
                    failedCount++;
                    continue;
                }

                // Tạo Id trước để có thể liên kết nếu có phân cấp chéo trong cùng một Batch request
                var commentId = Guid.CreateVersion7();

                var comment = new Comment
                {
                    Id = commentId,
                    Description = req.Description,
                    UserId = req.UserId,
                    EntityId = req.EntityId,
                    ReferenceCommentId = req.ReferenceCommentId,
                    HasChildren = false, 
                    CreatedBy = req.UserId,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                };

                newComments.Add(comment);
                newCommentsDict[commentId] = comment;
            }

            // 4. Cập nhật cờ HasChildren cho các comment cha
            var updatedParents = new HashSet<Comment>();

            foreach (var comment in newComments)
            {
                if (comment.ReferenceCommentId.HasValue)
                {
                    var parentId = comment.ReferenceCommentId.Value;

                    // TH1: Comment cha nằm trong DB
                    var dbParent = parentCommentsFromDb.FirstOrDefault(p => p.Id == parentId);
                    if (dbParent != null)
                    {
                        dbParent.HasChildren = true;
                        updatedParents.Add(dbParent);
                        continue;
                    }

                    // TH2: Comment cha cũng vừa được tạo trong chính lượt Batch này
                    if (newCommentsDict.TryGetValue(parentId, out var batchParent))
                    {
                        batchParent.HasChildren = true;
                    }
                    else
                    {
                        // Nếu không tìm thấy cha ở cả DB lẫn nội bộ batch -> Request lỗi liên kết cội nguồn
                        comment.ReferenceCommentId = Guid.Parse("00000000-0000-0000-0000-000000000000"); // Trở thành comment gốc hoặc xử lý fail tùy business
                    }
                }
            }

            // 5. Lưu dữ liệu
            if (newComments.Any())
            {
                await _commentRepository.AddRangeAsync(newComments);
            }

            if (updatedParents.Any())
            {
                // Sử dụng BulkUpdate tương tự Media để sync nhanh trạng thái của comment cha trong DB
                await _commentRepository.BulkUpdateAsync(updatedParents.ToList());
            }

            await _commentRepository.SaveChangesAsync();

            return ResponseDto.Create(ResponseCatalog.Created, "comment.batch_processed", new
            {
                Total = requests.Count,
                SuccessCount = newComments.Count,
                FailedCount = failedCount
            });
        }

        /// <summary>
        /// Cập nhật hàng loạt Comment (Batch)
        /// </summary>
        public async Task<IResult> UpdateCommentsBatchAsync(List<CommentUpdateRequest> requests)
        {
            if (requests == null || !requests.Any())
                return ResponseDto.Create(ResponseCatalog.BadRequest, "comment.batch_empty");

            var commentIds = requests.Select(x => x.Id).Distinct().ToList();
            var existingComments = await _commentRepository.GetByIdsAsync(commentIds);

            var updatedComments = new List<Comment>();

            foreach (var req in requests)
            {
                var comment = existingComments.FirstOrDefault(x => x.Id == req.Id);
                if (comment != null)
                {

                    comment.Description = req.Description;
                    comment.UpdatedAt = DateTimeOffset.UtcNow;
                    comment.UpdatedBy = comment.UserId; 

                    _commentRepository.Update(comment);
                    updatedComments.Add(comment);
                }
            }

            if (updatedComments.Any())
            {
                await _commentRepository.SaveChangesAsync();
            }

            return ResponseDto.Create(ResponseCatalog.Success, "comment.batch_updated", updatedComments);
        }

        /// <summary>
        /// Tìm kiếm/Lấy danh sách comment của một Media dựa trên Cursor (Tránh load chậm dữ liệu lớn)
        /// </summary>
        public async Task<IResult> SearchCommentsAsync(CommentFilterRequest request)
        {
            CursorResponse<Comment> pagedResult = await _commentRepository.GetCommentsAsync(request);

            var commentListDto = CommentMapping.ToCursorResponse(pagedResult);

            return ResponseDto.Create(ResponseCatalog.Success, "comment.list", commentListDto);
        }
    }
}