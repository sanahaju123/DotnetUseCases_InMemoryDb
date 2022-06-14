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
    public class DislikeServices : IDislikeServices
    {
        private readonly IDislikeRepository _dislikeRepository;
        public DislikeServices(IDislikeRepository dislikeRepository)
        {
            _dislikeRepository = dislikeRepository;
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
