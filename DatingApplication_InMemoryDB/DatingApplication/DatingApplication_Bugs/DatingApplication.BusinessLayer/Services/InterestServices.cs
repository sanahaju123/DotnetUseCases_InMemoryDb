using DatingApplication.BusinessLayer.Interfaces;
using DatingApplication.BusinessLayer.Services.Repository;
using DatingApplication.BusinessLayer.ViewModels;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services
{
    public class InterestServices : IInterestServices
    {
        private readonly IInterestRepository _interestRepository;
        public InterestServices(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }

        public async Task<Interests> FindInterestById(long interestId)
        {
            return null;
        }

        public async Task<IEnumerable<Interests>> FindInterestByUserId(long userId)
        {
            return await _interestRepository.FindInterestByUserId(userId);
        }

        public async Task<Interests> Register(Interests interests)
        {
            return null;
        }

        public async Task<Interests> UpdateInterest(InterestViewModel model)
        {
            return await _interestRepository.UpdateInterest(model);
        }
    }
}
