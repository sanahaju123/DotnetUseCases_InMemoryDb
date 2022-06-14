using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services.Repository
{
    public interface ILikeRepository
    {
        Task<Like> Register(Like like);
        Task<IEnumerable<Like>> ListAllLikesByUserId(long likeId);
        Task<Like> FindLikeById(long userId);
    }
}
