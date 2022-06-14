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
    public class InterestsController : ControllerBase
    {
        private readonly IInterestServices _interestServices;

        public InterestsController(IInterestServices interestServices)
        {
            _interestServices = interestServices;
        }

        #region InterestRegion
        /// <summary>
        /// Register a new interest
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("interests")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] InterestViewModel model)
        {
            var interestExists = await _interestServices.FindInterestById(model.InterestId);
            if (interestExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Interest already exists!" });
            //New object and value for user
            Interests interests = new Interests()
            {

                InterestedIn = model.InterestedIn,
                NotInterestedIn = model.NotInterestedIn,
                About = model.About,
                Hobbies = model.Hobbies,
                ProfileUrl = model.ProfileUrl,
                UserId = model.UserId,
                IsDeleted = false
            };
            var result = await _interestServices.Register(interests);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Interest creation failed! Please check interest details and try again." });

            return Ok(new Response { Status = "Success", Message = "Interest created successfully!" });

        }

        /// <summary>
        /// Update a existing Interest
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("interests")]
        public async Task<IActionResult> UpdateInterest([FromBody] InterestViewModel model)
        {
            var interest = await _interestServices.FindInterestById(model.InterestId);
            if (interest == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Interest With Id = {model.InterestId} cannot be found" });
            }
            else
            {
                var result = await _interestServices.UpdateInterest(model);
                return Ok(new Response { Status = "Success", Message = "Interest Edited successfully!" });
            }
        }


        /// <summary>
        /// Delete a existing Interest
        /// </summary>
        /// <param name="interestId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("interests/{interestId}")]
        public async Task<IActionResult> DeleteInterest(long interestId)
        {
            var interest = await _interestServices.FindInterestById(interestId);
            if (interest == null || interest.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Interest With Id = {interest} cannot be found" });
            }
            else
            {
                InterestViewModel register = new InterestViewModel();
                register.UserId = interest.UserId;
                register.InterestId = interest.InterestId;
                register.InterestedIn = interest.InterestedIn;
                register.NotInterestedIn = interest.NotInterestedIn;
                register.About = interest.About;
                register.ProfileUrl = interest.ProfileUrl;
                register.Hobbies = interest.Hobbies;
                register.IsDeleted = true;
                var result = await _interestServices.UpdateInterest(register);
                return Ok(new Response { Status = "Success", Message = "Interest deleted successfully!" });
            }
        }

        /// <summary>
        /// Get interest by Id
        /// </summary>
        /// <param name="interestId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("interest/{interestId}")]
        public async Task<IActionResult> GetInterestById(long interestId)
        {
            var interest = await _interestServices.FindInterestById(interestId);
            if (interest == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Interest With Id = {interestId} cannot be found" });
            }
            else
            {
                return Ok(interest);
            }
        }

        /// <summary>
        /// Get interest by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("interest/by-user-id/{userId}")]
        public async Task<IActionResult> GetInterestByUserId(long userId)
        {
            var interest = await _interestServices.FindInterestByUserId(userId);
            if (interest == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Interest With Id = {userId} cannot be found" });
            }
            else
            {
                return Ok(interest);
            }
        }



        #endregion

    }
}
