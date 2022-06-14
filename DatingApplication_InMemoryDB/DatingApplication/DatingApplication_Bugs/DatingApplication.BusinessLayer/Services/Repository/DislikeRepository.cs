using DatingApplication.DataLayer;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services.Repository
{
    public class DislikeRepository : IDislikeRepository
    {
        private readonly DatingAppDbContext _datingAppDbContext;
        public DislikeRepository(DatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext =datingAppDbContext;
        }

        public async Task<Dislike> FindDislikeById(long userId)
        {

            try
            {
                return await _datingAppDbContext.Dislikes.FindAsync(userId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Dislike>> ListAllDislikesByUserId(long userId)
        {
            try
            {
                var result = _datingAppDbContext.Dislikes.
                OrderByDescending(x => x.UserId).Take(10).ToList();
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Dislike> Register(Dislike dislike)
        {
            try
            {
                var result = await _datingAppDbContext.Dislikes.AddAsync(dislike);
                await _datingAppDbContext.SaveChangesAsync();
                return dislike;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
