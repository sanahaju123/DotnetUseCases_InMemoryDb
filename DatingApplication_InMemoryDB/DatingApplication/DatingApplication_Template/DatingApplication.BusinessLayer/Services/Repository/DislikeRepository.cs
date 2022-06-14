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

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Dislike>> ListAllDislikesByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Dislike> Register(Dislike dislike)
        {
            throw new NotImplementedException();
        }
    }
}
