using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services.Repository
{
    public interface IMatchRepository
    {
        Task<Match> Register(Match match);
        Task<IEnumerable<Match>> ListAllMatchesByUserId(long userId);
        Task<IEnumerable<Match>> ListAllMatchesByFilter(long userId, User user);
    }
}
