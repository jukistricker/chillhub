namespace chillhub.Controllers
{
    using global::chillhub.Models.Dtos.Requests;
    using global::chillhub.Services.Interfaces.Medias;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace chillhub.Controllers
    {
        [ApiController]
        [Route("comments")]
        public class CommentController : ControllerBase
        {
            private readonly ICommentService _commentService;

            public CommentController(ICommentService commentService)
            {
                _commentService = commentService;
            }

            [HttpPost("batch")]
            public async Task<IResult> CreateCommentsBatch([FromBody] List<CommentCreateRequest> requests)
            {
                return await _commentService.CreateCommentsBatchAsync(requests);

            }

            [HttpPut("batch")]
            public async Task<IResult> UpdateCommentsBatch([FromBody] List<CommentUpdateRequest> requests)
            {
                return await _commentService.UpdateCommentsBatchAsync(requests);
                
            }

            [HttpGet("search")]
            public async Task<IResult> SearchComments([FromQuery] CommentFilterRequest request)
            {
                return await _commentService.SearchCommentsAsync(request);
                
            }
        }
    }
}
