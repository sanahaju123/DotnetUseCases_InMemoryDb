using DatingApplication.BusinessLayer.ViewModels;
using DatingApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApplication.BusinessLayer.Interfaces
{
    public interface IUserServices
    {
        Task<User> Register(User user);
        Task<User> FindUserById(long userId);
        Task<User> UpdateUser(UserViewModel model);
        Task<IEnumerable<User>> ListAllUsers();
    }
}
