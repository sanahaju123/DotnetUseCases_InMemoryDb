using DatingApplication.BusinessLayer.Interfaces;
using DatingApplication.BusinessLayer.ViewModels;
using DatingApplication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        #region UserRegion
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("users")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] UserViewModel model)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Update a existing User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("users")]
        public async Task<IActionResult> UpdateUser([FromBody] UserViewModel model)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete a existing user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("users/{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("users/{userId}")]
        public async Task<IActionResult> GetUserById(long userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("users")]
        public async Task<IEnumerable<User>> ListAllUsers()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
