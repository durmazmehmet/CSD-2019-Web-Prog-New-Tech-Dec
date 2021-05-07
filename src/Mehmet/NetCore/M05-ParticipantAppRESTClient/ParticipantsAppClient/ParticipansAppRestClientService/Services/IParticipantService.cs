using CSD.ParticipansAppRestClientService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.ParticipantsAppRestClient.Services
{
    public interface IParticipantService
    {
        Task<List<ParticipantModel>> FindAllAsync();
        Task<ParticipantModel> FindByIdAsync(string id);
        Task<ParticipantModel> SaveParticipant(ParticipantModel participant);
        Task<ParticipantModel> UpdateParticipant(ParticipantModel participant);
        Task<List<ParticipantModel>> FindNotParticipateds();
        Task<List<ParticipantModel>> FindParticipateds();
        Task<ParticipantModel> DeleteParticipant(ParticipantModel participant);
    }
}
