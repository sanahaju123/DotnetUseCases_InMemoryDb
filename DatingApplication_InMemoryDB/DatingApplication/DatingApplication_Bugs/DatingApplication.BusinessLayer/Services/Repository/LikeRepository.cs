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
            try
            {
                return await _datingAppDbContext.Likes.FindAsync(userId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Like>> ListAllLikesByUserId(long likeId)
        {
            try
            {
                var result = _datingAppDbContext.Likes.
                OrderByDescending(x => x.UserId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Like> Register(Like like)
        {
            try
            {
                var result = await _datingAppDbContext.Likes.AddAsync(like);
                await _datingAppDbContext.SaveChangesAsync();
                return like;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
