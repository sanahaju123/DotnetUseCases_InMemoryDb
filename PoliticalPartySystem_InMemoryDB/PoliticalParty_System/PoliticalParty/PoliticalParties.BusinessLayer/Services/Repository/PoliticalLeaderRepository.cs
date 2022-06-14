using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.DataLayer;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.Services.Repository
{
    public class PoliticalLeaderRepository : IPoliticalLeaderRepository
    {
        private readonly PoliticalPartiesDbContext _politicalPartiesDbContext;
        public PoliticalLeaderRepository(PoliticalPartiesDbContext politicalPartiesDbContext)
        {
            _politicalPartiesDbContext = politicalPartiesDbContext;
        }

        public async Task<PoliticalLeader> FindPoliticalLeaderById(long politicalLeaderId)
        {
            try
            {
                return await _politicalPartiesDbContext.PoliticalLeaders.FindAsync(politicalLeaderId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<PoliticalLeader>> ListAllPoliticalLeader()
        {
            try
            {
                var result = _politicalPartiesDbContext.PoliticalLeaders.
                OrderByDescending(x => x.PoliticalLeaderId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<PoliticalLeader>> PoliticalLeadersByPoliticalPartyId(long politicalPartyId)
        {
            try
            {
                var result = _politicalPartiesDbContext.PoliticalLeaders.
                Where(x => x.PoliticalPartyId== politicalPartyId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<PoliticalLeader> Register(PoliticalLeader politicalLeader)
        {
            try
            {
                var result = await _politicalPartiesDbContext.PoliticalLeaders.AddAsync(politicalLeader);
                await _politicalPartiesDbContext.SaveChangesAsync();
                return politicalLeader;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<PoliticalLeader> UpdatePoliticalLeader(RegisterPoliticalLeaderViewModel model)
        {
            var politicalLeader = await _politicalPartiesDbContext.PoliticalLeaders.FindAsync(model.PoliticalLeaderId);
            try
            {

                politicalLeader.CandidateName = model.CandidateName;
                politicalLeader.StateName = model.StateName;
                politicalLeader.PoliticalPartyId = model.PoliticalPartyId;
                politicalLeader.IsDeleted = model.IsDeleted;


                _politicalPartiesDbContext.PoliticalLeaders.Update(politicalLeader);
                await _politicalPartiesDbContext.SaveChangesAsync();
                return politicalLeader;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
