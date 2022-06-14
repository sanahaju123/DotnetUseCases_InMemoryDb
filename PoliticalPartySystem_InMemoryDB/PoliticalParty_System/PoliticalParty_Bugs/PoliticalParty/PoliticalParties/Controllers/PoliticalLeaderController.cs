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
            var politicalLeaderExists = await _politicalLeaderServices.FindPoliticalLeaderById(model.PoliticalLeaderId);
            if (politicalLeaderExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Political Leader already exists!" });
            //New object and value for user
            PoliticalLeader politicalLeader = new PoliticalLeader()
            {

                CandidateName = model.CandidateName,
                StateName = model.StateName,
                PoliticalPartyId=model.PoliticalPartyId,
                IsDeleted = false
            };
            var result = await _politicalLeaderServices.Register(politicalLeader);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Political Leader creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Political Leader created successfully!" });

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
            var politicalLeader = await _politicalLeaderServices.FindPoliticalLeaderById(model.PoliticalLeaderId);
            if (politicalLeader == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"political Leader With Id = {model.PoliticalLeaderId} cannot be found" });
            }
            else
            {
                var result = await _politicalLeaderServices.UpdatePoliticalLeader(model);
                return Ok(new Response { Status = "Success", Message = "Political Leader Edited successfully!" });
            }
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
            var politicalLeader = await _politicalLeaderServices.FindPoliticalLeaderById(politicalLeaderId);
            if (politicalLeader == null || politicalLeader.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Political Leader With Id = {politicalLeader} cannot be found" });
            }
            else
            {
                RegisterPoliticalLeaderViewModel register = new RegisterPoliticalLeaderViewModel();
                register.PoliticalLeaderId = politicalLeader.PoliticalLeaderId;
                register.CandidateName = politicalLeader.CandidateName;
                register.StateName = politicalLeader.StateName;
                register.PoliticalPartyId = politicalLeader.PoliticalPartyId;
                register.IsDeleted = true;
                var result = await _politicalLeaderServices.UpdatePoliticalLeader(register);
                return Ok(new Response { Status = "Success", Message = "Political Leader deleted successfully!" });
            }
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
            var politicalLeader = await _politicalLeaderServices.FindPoliticalLeaderById(politicalLeaderId);
            if (politicalLeader == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Political Leader With Id = {politicalLeaderId} cannot be found" });
            }
            else
            {
                return Ok(politicalLeader);
            }
        }

        /// <summary>
        /// List All political Leaders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("leaders")]
        public async Task<IEnumerable<PoliticalLeader>> ListAllPoliticalLeaders()
        {
            return await _politicalLeaderServices.ListAllPoliticalLeader();
        }

        /// <summary>
        /// Fetches the details of all the political leaders belongs to a party
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("leaders/by-party-id/{politicalPartyId}")]
        public async Task<IEnumerable<PoliticalLeader>> GetPoliticalLeaderByPoliticalPartyId(long politicalPartyId)
        {
            return await _politicalLeaderServices.PoliticalLeadersByPoliticalPartyId(politicalPartyId);
        }
        #endregion
    }
}
