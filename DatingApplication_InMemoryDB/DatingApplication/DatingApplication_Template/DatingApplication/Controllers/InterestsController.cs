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
            throw new NotImplementedException();

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }



        #endregion

    }
}
