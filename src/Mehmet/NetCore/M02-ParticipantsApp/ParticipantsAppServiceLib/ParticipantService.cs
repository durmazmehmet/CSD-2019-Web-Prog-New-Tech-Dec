using CSD.ParticipantsApp.Repository;
using CSD.ParticipantsApp.Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CSD.Util.DbUtil;

namespace CSD.ParticipantsApp.Service
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository m_participantRepository;
        public ParticipantService(IParticipantRepository participantRepository) => m_participantRepository = participantRepository;
        public async Task<List<Participant>> GetAllParticipant() => await DoWorkForServiceAsync(() => m_participantRepository.All.ToList(), "ParticipantAppService.GetAllParticipants");
        public async Task<Participant> SaveParticipant(Participant p) => await DoWorkForServiceAsync(() => m_participantRepository.SaveAsync(p), "ParticipantAppService.SaveParticipant");
        public async Task<Participant> FindParticipantByEmail(string email) => await DoWorkForServiceAsync(() => m_participantRepository.FindByIdAsync(email), "ParticipantAppService.FindParticipantByEmail");
        public async Task<IEnumerable<Participant>> FindParticipateds() => await DoWorkForServiceAsync(() => m_participantRepository.FindByParticipateAsync(), "ParticipantAppService.FindPartipicateds");
        public async Task<IEnumerable<Participant>> FindNotParticipateds() => await DoWorkForServiceAsync(() => m_participantRepository.FindByParticipateAsync(false), "ParticipantAppService.FindPartipicateds");
        public async Task DeleteParticipant(Participant p) => await DoWorkForServiceAsync(() => m_participantRepository.DeleteByAsync(p), "ParticipantAppService.DeleteParticipant");
    }
}
