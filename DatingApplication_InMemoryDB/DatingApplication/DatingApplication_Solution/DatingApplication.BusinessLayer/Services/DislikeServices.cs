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
            return await _dislikeRepository.FindDislikeById(userId);
        }

        public async Task<IEnumerable<Dislike>> ListAllDislikesByUserId(long userId)
        {
            return await _dislikeRepository.ListAllDislikesByUserId(userId);
        }

        public async Task<Dislike> Register(Dislike dislike)
        {
            return await _dislikeRepository.Register(dislike);
        }
    }
}
