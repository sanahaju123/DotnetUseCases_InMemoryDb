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
    public class UserRepository : IUserRepository
    {
        private readonly DatingAppDbContext _datingAppDbContext;
        public UserRepository(DatingAppDbContext datingAppDbContext)
        {
            _datingAppDbContext = datingAppDbContext;
        }

        public async Task<User> FindUserById(long userId)
        {
            try
            {
                return await _datingAppDbContext.Users.FindAsync(userId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<User>> ListAllUsers()
        {
            try
            {
                var result = _datingAppDbContext.Users.
                OrderByDescending(x => x.UserId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<User> Register(User user)
        {
            try
            {
                var result = await _datingAppDbContext.Users.AddAsync(user);
                await _datingAppDbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<User> UpdateUser(UserViewModel model)
        {
            var user = await _datingAppDbContext.Users.FindAsync(model.UserId);
            try
            {

                user.Name = model.Name;
                user.Phone = model.Phone;
                user.Email = model.Email;
                user.Age = model.Age;
                user.City = model.City;
                user.Country = model.Country;
                user.Gender = model.Gender;
                user.IsDeleted = model.IsDeleted;


                _datingAppDbContext.Users.Update(user);
                await _datingAppDbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
