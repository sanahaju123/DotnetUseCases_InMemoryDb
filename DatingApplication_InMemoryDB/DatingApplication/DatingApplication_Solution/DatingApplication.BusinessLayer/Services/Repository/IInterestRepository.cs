using DatingApplication.BusinessLayer.ViewModels;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services.Repository
{
    public interface IInterestRepository
    {
        Task<Interests> Register(Interests interests);
        Task<Interests> FindInterestById(long interestId);
        Task<Interests> UpdateInterest(InterestViewModel model);
        Task<IEnumerable<Interests>> FindInterestByUserId(long userId);
    }
}
