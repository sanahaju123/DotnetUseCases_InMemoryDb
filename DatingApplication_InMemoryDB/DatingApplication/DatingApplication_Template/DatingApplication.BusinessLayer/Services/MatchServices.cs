using DatingApplication.BusinessLayer.Interfaces;
using DatingApplication.BusinessLayer.Services.Repository;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services
{
    public class MatchServices : IMatchServices
    {
        private readonly IMatchRepository _matchRepository;
        public MatchServices(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<Match>> ListAllMatchesByFilter(long userId, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Match>> ListAllMatchesByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Match> Register(Match match)
        {
            throw new NotImplementedException();
        }
    }
}
