using DatingApplication.BusinessLayer.Interfaces;
using DatingApplication.Entities;
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
    public class MatchController : ControllerBase
    {
        private readonly IMatchServices _matchServices;

        public MatchController(IMatchServices matchServices)
        {
            _matchServices = matchServices;
        }

        /// <summary>
        /// Get Match by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("match/{userId}")]
        public async Task<IActionResult> GetMatchByUserId(long userId)
        {
            var match = await _matchServices.ListAllMatchesByUserId(userId);
            if (match == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Match With Id = {userId} cannot be found" });
            }
            else
            {
                return Ok(match);
            }
        }

        /// <summary>
        /// Fetches all the users based on the potential matches like based on Age, Gender, City or Country.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("match/{userId}")]
        public async Task<IActionResult> GetMatchByFilter(long userId)
        {
            User user = new User();
            user.Age = 20;
            user.Gender = "male";
            user.City = "Goa";
            user.Country = "India";
            var match = await _matchServices.ListAllMatchesByFilter(userId,user);
            if (match == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"User With Id = {userId} and filter {user} cannot be found" });
            }
            else
            {
                return Ok(match);
            }
        }
    }
}
