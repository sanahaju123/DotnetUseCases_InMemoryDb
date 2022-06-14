using DatingApplication.BusinessLayer.ViewModels;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Interfaces
{
    public interface IDislikeServices
    {
        Task<Dislike> Register(Dislike dislike);
        Task<IEnumerable<Dislike>> ListAllDislikesByUserId(long userId);
        Task<Dislike> FindDislikeById(long userId);
    }
}
