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
            var politicalPartyExists = await _politicalPartyServices.FindPoliticalPartyById(model.PoliticalPartyId);
            if (politicalPartyExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Political Party already exists!" });
            //New object and value for user
            PoliticalParty politicalParty = new PoliticalParty()
            {

                Name = model.Name,
                Founder = model.Founder,
                IsDeleted = false
            };
            var result = await _politicalPartyServices.Register(politicalParty);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Political Party creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Political Party created successfully!" });

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
            var politicalParty = await _politicalPartyServices.FindPoliticalPartyById(model.PoliticalPartyId);
            if (politicalParty == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"political Party With Id = {model.PoliticalPartyId} cannot be found" });
            }
            else
            {
                var result = await _politicalPartyServices.UpdatePoliticalParty(model);
                return Ok(new Response { Status = "Success", Message = "Political Party Edited successfully!" });
            }
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
            var politicalParty = await _politicalPartyServices.FindPoliticalPartyById(politicalPartyId);
            if (politicalParty == null || politicalParty.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Political Party With Id = {politicalParty} cannot be found" });
            }
            else
            {
                RegisterPoliticalPartyViewModel register = new RegisterPoliticalPartyViewModel();
                register.PoliticalPartyId = politicalParty.PoliticalPartyId;
                register.Name = politicalParty.Name;
                register.Founder = politicalParty.Founder;
                register.IsDeleted = true;
                var result = await _politicalPartyServices.UpdatePoliticalParty(register);
                return Ok(new Response { Status = "Success", Message = "Political Party deleted successfully!" });
            }
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
            var politicalParty = await _politicalPartyServices.FindPoliticalPartyById(politicalPartyId);
            if (politicalParty == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Political Party With Id = {politicalPartyId} cannot be found" });
            }
            else
            {
                return Ok(politicalParty);
            }
        }

        /// <summary>
        /// List All political Parties
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("parties")]
        public async Task<IEnumerable<PoliticalParty>> ListAllPoliticalParties()
        {
            return await _politicalPartyServices.ListAllPoliticalParty();
        }
        #endregion
    }
}
