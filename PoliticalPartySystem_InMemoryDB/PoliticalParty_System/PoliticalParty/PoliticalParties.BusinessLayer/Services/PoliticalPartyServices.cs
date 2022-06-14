using PoliticalParties.BusinessLayer.Interfaces;
using PoliticalParties.BusinessLayer.Services.Repository;
using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.DataLayer;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.Services
{
    public class PoliticalPartyServices : IPoliticalPartyServices
    {
        private readonly IPoliticalPartyRepository _politicalPartyRepository;
        private readonly PoliticalPartiesDbContext _politicalPartiesDbContext;
        public PoliticalPartyServices(IPoliticalPartyRepository politicalPartyRepository,PoliticalPartiesDbContext politicalPartiesDbContext)
        {
            _politicalPartyRepository = politicalPartyRepository;
            _politicalPartiesDbContext = politicalPartiesDbContext;
        }

        public async Task<PoliticalParty> FindPoliticalPartyById(long politicalPartyId)
        {
            return await _politicalPartyRepository.FindPoliticalPartyById(politicalPartyId); 
        }

        public async Task<IEnumerable<PoliticalParty>> ListAllPoliticalParty()
        {
            return await _politicalPartyRepository.ListAllPoliticalParty();
        }

        public async Task<PoliticalParty> Register(PoliticalParty politicalParty)
        {
            return await _politicalPartyRepository.Register(politicalParty);
        }

        public async Task<PoliticalParty> UpdatePoliticalParty(RegisterPoliticalPartyViewModel model)
        {
            return await _politicalPartyRepository.UpdatePoliticalParty(model);
        }
    }
}
