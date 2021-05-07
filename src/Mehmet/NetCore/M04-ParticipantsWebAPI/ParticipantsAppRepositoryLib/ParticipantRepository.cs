using CSD.ParticipantsApp.Repository.Data;
using CSD.ParticipantsApp.Repository.Entities;
using CSD.Util.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static CSD.Util.DbUtil;

namespace CSD.ParticipantsApp.Repository
{
    public class ParticipantRepository : CrudRepositoryEx<Participant, string, ParticipantsAppDbContext>, IParticipantRepository
    {
        public ParticipantRepository() : base(new ParticipantsAppDbContext()) { }
       
        public async Task<IEnumerable<Participant>> FindByParticipateAsync(bool isParticipate)             
            => await DoWorkForRepositoryAsync(() => Ctx.Set<Participant>().Where(p => p.IsParticipate == isParticipate).ToList(), "ParticipantRepository.FindByParticipateAsync");

        public async Task<Participant> FindParticipantByEmailAndParticipate(string email, bool isParticipate)
        {
            return await DoWorkForRepositoryAsync(
                () => Ctx
                    .Set<Participant>()
                    .FirstOrDefault(pp => pp.Id == email && pp.IsParticipate == isParticipate), 
                "ParticipantRepository.FindParticipantByEmailAndParticipate");
        }
    }
}

        //Corner of İbret
        /*
         * 
        public IEnumerable<Participant> FindByParticipate(bool isParticipate)
        {
            return DoWorkForRepository(
                () => Ctx.Set<Participant>().Where(p => p.IsPartipicate == isParticipate).ToList(),
                "ParticipantRepository.FindByParticipate"
                );
        }

        public async Task<IEnumerable<Participant>> FindByParticipateAsync2(bool isParticipate)
        {
            return await DoWorkForRepositoryAsync(() => FindByAsync(p => p.IsPartipicate == isParticipate),
                "ParticipantRepository.FindByParticipateAsync"
                );
        }

        public Task<IEnumerable<Participant>> FindByParticipateAsync3(bool isParticipate)
        {
            return DoWorkForRepositoryAsync(() => FindByAsync(p => p.IsPartipicate == isParticipate),
                "ParticipantRepository.FindByParticipateAsync"
                );
        }

        public Task<IEnumerable<Participant>> FindByParticipateAsync(bool isParticipate) {
            var task = WrapNStart(new Task<IEnumerable<Participant>>(() => ;
            return DoWorkForRepositoryAsync(() => task, "hede" );
        }  
 */
