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
            try
            {
                return await _datingAppDbContext.Interests.FindAsync(interestId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Interests>> FindInterestByUserId(long userId)
        {
            try
            {
                var result = _datingAppDbContext.Interests.
                OrderByDescending(x => x.UserId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Interests> Register(Interests interests)
        {
            try
            {
                var result = await _datingAppDbContext.Interests.AddAsync(interests);
                await _datingAppDbContext.SaveChangesAsync();
                return interests;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Interests> UpdateInterest(InterestViewModel model)
        {
            var interest = await _datingAppDbContext.Interests.FindAsync(model.InterestId);
            try
            {

                interest.InterestedIn = model.InterestedIn;
                interest.NotInterestedIn = model.NotInterestedIn;
                interest.About = model.About;
                interest.Hobbies = model.Hobbies;
                interest.ProfileUrl = model.ProfileUrl;
                interest.UserId = model.UserId;
                interest.IsDeleted = model.IsDeleted;


                _datingAppDbContext.Interests.Update(interest);
                await _datingAppDbContext.SaveChangesAsync();
                return interest;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
