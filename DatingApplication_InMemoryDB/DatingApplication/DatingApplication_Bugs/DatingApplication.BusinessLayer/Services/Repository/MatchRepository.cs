using DatingApplication.DataLayer;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services.Repository
{
    public class MatchRepository : IMatchRepository
    {

        private readonly DatingAppDbContext _datingAppDbContext;
        public MatchRepository(DatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext = datingAppDbContext;
        }

        public async Task<IEnumerable<Match>> ListAllMatchesByFilter(long userId, User user)
        {
            try
            {
                var result = _datingAppDbContext.Users.
                OrderByDescending(x =>x.City==user.City && x.Country==user.Country && x.Gender==user.Gender && (x.Gender==user.Gender && x.UserId==userId) ).Take(10).ToList();
                return (IEnumerable<Match>)result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Match>> ListAllMatchesByUserId(long userId)
        {
            try
            {
                var result = _datingAppDbContext.Matches.
                OrderByDescending(x => x.UserId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Match> Register(Match match)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
