using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.Interfaces
{
    public interface IPoliticalLeaderServices
    {
        Task<PoliticalLeader> Register(PoliticalLeader politicalLeader);
        Task<PoliticalLeader> FindPoliticalLeaderById(long politicalLeaderId);
        Task<PoliticalLeader> UpdatePoliticalLeader(RegisterPoliticalLeaderViewModel model);
        Task<IEnumerable<PoliticalLeader>> ListAllPoliticalLeader();
        Task<IEnumerable<PoliticalLeader>> PoliticalLeadersByPoliticalPartyId(long politicalPartyId);
    }
}
