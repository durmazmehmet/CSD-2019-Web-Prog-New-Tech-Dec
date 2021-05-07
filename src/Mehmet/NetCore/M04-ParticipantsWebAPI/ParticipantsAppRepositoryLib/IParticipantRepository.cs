using CSD.ParticipantsApp.Repository.Entities;
using CSD.Util.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSD.ParticipantsApp.Repository
{
    public interface IParticipantRepository : ICrudRepository<Participant, string>
    {
        //IEnumerable<Participant> FindByParticipate(bool isParticipate = true);
        Task<IEnumerable<Participant>> FindByParticipateAsync(bool isParticipate = true);
        Task<Participant> FindParticipantByEmailAndParticipate(string email, bool isParticipate);
    }
}
