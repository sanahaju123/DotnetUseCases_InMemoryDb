using DatingApplication.DataLayer;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly DatingAppDbContext _datingAppDbContext;
        public LikeRepository(DatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext = datingAppDbContext;
        }

        public async Task<Like> FindLikeById(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Like>> ListAllLikesByUserId(long likeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Like> Register(Like like)
        {
            throw new NotImplementedException();
        }
    }
}
