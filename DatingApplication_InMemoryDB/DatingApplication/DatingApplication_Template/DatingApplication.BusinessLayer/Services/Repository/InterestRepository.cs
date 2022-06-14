using DatingApplication.BusinessLayer.ViewModels;
using DatingApplication.DataLayer;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Services.Repository
{
    public class InterestRepository : IInterestRepository
    {
        private readonly DatingAppDbContext _datingAppDbContext;
        public InterestRepository(DatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext = datingAppDbContext;
        }

        public async Task<Interests> FindInterestById(long interestId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Interests>> FindInterestByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Interests> Register(Interests interests)
        {
            throw new NotImplementedException();
        }

        public async Task<Interests> UpdateInterest(InterestViewModel model)
        {
            throw new NotImplementedException(); ;
            }
        }
    }

