using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberDto model) {
            Member newMember = new Member {
                Name = model.Name,
                NickName = model.NickName,
                Cpf = model.Cpf,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                City = model.City,
                State = model.State,
                StatesVisited = model.StatesVisited,
                EntryDate = model.EntryDate,
                Rank = model.Rank,
                Triennium = model.Triennium,
                HasBeenAbroad = model.HasBeenAbroad,
                BirthDate = model.BirthDate,
                IsFirst = model.IsFirst,
                WifeName = model.WifeName,
                WifeNickName = model.WifeNickName,
                CoatOfArms = model.CoatOfArms,
                OffBoarding = model.OffBoarding,
                ProfilePhoto = model.ProfilePhoto,
                MotorCycleSign = model.MotorCycleSign,
                MotorCycleBrand = model.MotorCycleBrand,
                MotorCycleName = model.MotorCycleName,
                MotorCycleNickName = model.MotorCycleNickName,
                IsActive = model.IsActive,
                IsSystemManager = model.IsSystemManager,
                BoardId = model.BoardId,
            };

            _context.Members.Add(newMember);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{MemberId}/board/{BoardId}")]
        public async Task<IActionResult> AssignMemberToBoard(int memberId, int boardId) {
            var memberToBeAssigned = await _context.Members.FindAsync(memberId);
            if (memberToBeAssigned == null) return NotFound();
            memberToBeAssigned.BoardId = boardId;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
