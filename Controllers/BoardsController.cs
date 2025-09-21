using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase {
        private readonly AppDbContext _context;

        public BoardsController(AppDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard(Board model) {
            _context.Boards.Add(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{BoardId}")]
        public async Task<IActionResult> GetMembersOfBoard(int boardId) {
            var membersOfTheBoard = await _context.Members
                .Where(c => c.BoardId == boardId)
                .ToListAsync();
            return Ok(membersOfTheBoard);
        }

        [HttpPut("{BoartId}/member/{MemberId}")]
        public async Task<IActionResult> RemoveMemberFromBoard(int boardId, int memberId) {
            var memberOfTheBoard = await _context.Members.FindAsync(memberId);
            if (memberOfTheBoard == null) return NotFound();
            memberOfTheBoard.BoardId = null;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
