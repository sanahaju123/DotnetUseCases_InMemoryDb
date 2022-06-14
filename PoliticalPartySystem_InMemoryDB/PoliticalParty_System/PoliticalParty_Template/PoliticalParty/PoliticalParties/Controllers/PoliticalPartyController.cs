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
    public class PoliticalPartyController : ControllerBase
    {
        private readonly IPoliticalPartyServices _politicalPartyServices;

        public PoliticalPartyController(IPoliticalPartyServices politicalPartyServices)
        {
            _politicalPartyServices = politicalPartyServices;
        }

        #region PoliticalPartyRegion
        /// <summary>
        /// Register a new Political Party
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("parties")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterPoliticalPartyViewModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update a existing Political Party
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("parties")]
        public async Task<IActionResult> UpdatePoliticalParty([FromBody] RegisterPoliticalPartyViewModel model)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Delete a existing Political Party
        /// </summary>
        /// <param name="politicalPartyId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("parties/{politicalPartyId}")]
        public async Task<IActionResult> DeletePoliticalParty(long politicalPartyId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Political Party by Id
        /// </summary>
        /// <param name="politicalPartyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("parties/{politicalPartyId}")]
        public async Task<IActionResult> GetPoliticalPartyById(long politicalPartyId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List All political Parties
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("parties")]
        public async Task<IEnumerable<PoliticalParty>> ListAllPoliticalParties()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
