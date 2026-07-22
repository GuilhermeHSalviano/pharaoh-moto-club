using pharaoh_moto_club.Models;
using Factories;
using pharaoh_moto_club.Dtos;
using Microsoft.EntityFrameworkCore;
using My.Exceptions;

namespace Services {
    public class TypeOfEventServices{
        private readonly AppDbContext _context;
        public TypeOfEventServices(AppDbContext context) {
            _context = context;
        }

        public async Task SaveNewTypeOfEventOnDb(TypeOfEventDto model) {
            var checkIfDescriptionAlreadyExists = await _context.TypeOfEvents.FirstOrDefaultAsync(x => x.Description == model.Description);
            if(checkIfDescriptionAlreadyExists != null) throw new MemberNotAllowed("Não é possível inserir uma descrição já existente");
            var newTypeOfEvent = TypeOfEventFactory.CreateTypeOfEvent(model);
            _context.TypeOfEvents.Add(newTypeOfEvent);
            await _context.SaveChangesAsync();
        }

         public List<TypeOfEvent> GetTypesOfEvents() {
            var typeOfEventList = _context.TypeOfEvents.ToList();
            if(typeOfEventList.Count == 0) throw new EntityNotFound("Não há tipos de eventos registrados");
            return typeOfEventList;
        }
    }
}