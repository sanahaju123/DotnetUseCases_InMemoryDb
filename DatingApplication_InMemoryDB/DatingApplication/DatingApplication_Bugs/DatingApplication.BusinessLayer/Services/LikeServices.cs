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
    public class LikeServices : ILikeServices
    {
        private readonly ILikeRepository _likeRepository;
        public LikeServices(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Like> FindLikeById(long userId)
        {
            return await _likeRepository.FindLikeById(userId);
        }

        public async Task<IEnumerable<Like>> ListAllLikesByUserId(long likeId)
        {
            return null;
        }

        public async Task<Like> Register(Like like)
        {
            return await _likeRepository.Register(like);
        }
    }
}
