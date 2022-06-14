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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> ListAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUser(UserViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
