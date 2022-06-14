using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.Services.Repository
{
    public interface IPoliticalPartyRepository
    {
        Task<PoliticalParty> Register(PoliticalParty politicalParty);
        Task<PoliticalParty> FindPoliticalPartyById(long politicalPartyId);
        Task<PoliticalParty> UpdatePoliticalParty(RegisterPoliticalPartyViewModel model);
        Task<IEnumerable<PoliticalParty>> ListAllPoliticalParty();
    }
}
