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
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
