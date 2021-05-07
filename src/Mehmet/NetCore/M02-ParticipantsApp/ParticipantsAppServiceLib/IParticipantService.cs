using CSD.ParticipantsApp.Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.ParticipantsApp.Service
{
    public interface IParticipantService
    {
        Task DeleteParticipant(Participant p);
        Task<IEnumerable<Participant>> FindNotParticipateds();
        Task<Participant> FindParticipantByEmail(string email);
        Task<IEnumerable<Participant>> FindParticipateds();
        Task<List<Participant>> GetAllParticipant();
        Task<Participant> SaveParticipant(Participant p);
    }
}