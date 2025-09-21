using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberDto model) {
            Member newMember = new Member(model.Name, model.NickName, model.Cpf, model.City, model.State, model.Password) {
                Name = model.Name,
                NickName = model.NickName,
                Cpf = model.Cpf,
                City = model.City,
                State = model.State,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            };

            _context.Members.Add(newMember);

            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
