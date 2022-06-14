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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
