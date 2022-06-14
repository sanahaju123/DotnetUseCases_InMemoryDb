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
            var userExists = await _userServices.FindUserById(model.UserId);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            //New object and value for user
            User user = new User()
            {

                Name = model.Name,
                Age = model.Age,
                City = model.City,
                Email = model.Email,
                Country=model.Country,
                Gender=model.Gender,
                UserId=model.UserId,
                Phone = model.Phone,
                IsDeleted = false
            };
            var result = await _userServices.Register(user);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });

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
            var user = await _userServices.FindUserById(model.UserId);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"User With Id = {model.UserId} cannot be found" });
            }
            else
            {
                var result = await _userServices.UpdateUser(model);
                return Ok(new Response { Status = "Success", Message = "User Edited successfully!" });
            }
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
            var user = await _userServices.FindUserById(userId);
            if (user == null || user.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"User With Id = {userId} cannot be found" });
            }
            else
            {
                UserViewModel register = new UserViewModel();
                register.UserId = user.UserId;
                register.Phone = user.Phone;
                register.Age = user.Age;
                register.City = user.City;
                register.Country = user.Country;
                register.Gender = user.Gender;
                register.Email = user.Email;
                register.IsDeleted = true;
                var result = await _userServices.UpdateUser(register);
                return Ok(new Response { Status = "Success", Message = "User deleted successfully!" });
            }
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
            var user = await _userServices.FindUserById(userId);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"User With Id = {userId} cannot be found" });
            }
            else
            {
                return Ok(user);
            }
        }

        /// <summary>
        /// List All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("users")]
        public async Task<IEnumerable<User>> ListAllUsers()
        {
            return await _userServices.ListAllUsers();
        }

        #endregion
    }
}
