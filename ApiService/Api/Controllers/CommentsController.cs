using Microsoft.AspNetCore.Mvc;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using Services;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase {
        private readonly CommentServices _commentServices;

        public CommentsController(CommentServices commentServices) {
            _commentServices = commentServices;
        }

        [HttpPost("create/{eventId}/{authorId}")]
        public async Task<IActionResult> CreateComment(CommentDto model, int eventId, int authorId) {
            try {
                await _commentServices.SaveCommentOnDb(model, eventId, authorId);
                return NoContent();
            }
            catch (EntityNotFound error) {
                return NotFound(error.Message);
            }
        }
    }
}