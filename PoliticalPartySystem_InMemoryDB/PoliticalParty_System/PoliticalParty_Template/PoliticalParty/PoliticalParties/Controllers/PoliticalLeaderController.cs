using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliticalParties.BusinessLayer.Interfaces;
using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliticalParties.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliticalLeaderController : ControllerBase
    {
        private readonly IPoliticalLeaderServices _politicalLeaderServices;

        public PoliticalLeaderController(IPoliticalLeaderServices politicalLeaderServices)
        {
            _politicalLeaderServices = politicalLeaderServices;
        }

        #region PoliticalLeaderRegion
        /// <summary>
        /// Register a new Political Leader
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("leaders")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterPoliticalLeaderViewModel model)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Update a existing Political Leader
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("leaders")]
        public async Task<IActionResult> UpdatePoliticalLeader([FromBody] RegisterPoliticalLeaderViewModel model)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete a existing Political Leader
        /// </summary>
        /// <param name="politicalLeaderId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("leaders/{politicalLeaderId}")]
        public async Task<IActionResult> DeletePoliticalLeader(long politicalLeaderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Political Leader by Id
        /// </summary>
        /// <param name="politicalLeaderId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("leaders/{politicalLeaderId}")]
        public async Task<IActionResult> GetPoliticalLeaderById(long politicalLeaderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List All political Leaders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("leaders")]
        public async Task<IEnumerable<PoliticalLeader>> ListAllPoliticalLeaders()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches the details of all the political leaders belongs to a party
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("leaders/by-party-id/{politicalPartyId}")]
        public async Task<IEnumerable<PoliticalLeader>> GetPoliticalLeaderByPoliticalPartyId(long politicalPartyId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
