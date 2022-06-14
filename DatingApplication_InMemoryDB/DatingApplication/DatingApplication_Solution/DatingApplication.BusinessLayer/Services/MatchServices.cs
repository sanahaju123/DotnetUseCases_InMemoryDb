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
            return await _matchRepository.ListAllMatchesByFilter(userId, user);
        }

        public async Task<IEnumerable<Match>> ListAllMatchesByUserId(long userId)
        {
            return await _matchRepository.ListAllMatchesByUserId(userId);
        }

        public async Task<Match> Register(Match match)
        {
            return await _matchRepository.Register(match);
        }
    }
}
