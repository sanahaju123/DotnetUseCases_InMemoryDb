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
    public class DevelopmentController : ControllerBase
    {
        private readonly IDevelopmentServices _developmentServices;

        public DevelopmentController(IDevelopmentServices developmentServices)
        {
            _developmentServices = developmentServices;
        }

        #region DevelopmentRegion
        /// <summary>
        /// Register a new Development
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("developments")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterDevelopmentViewModel model)
        {
            var developmentExists = await _developmentServices.FindDevelopmentById(model.DevelopmentId);
            if (developmentExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Development already exists!" });
            //New object and value for user
            Development development = new Development()
            {

                Title = model.Title,
                Activity = model.Activity,
                ActivityYear = model.ActivityYear,
                ActivityMonth=model.ActivityMonth,
                Budget=model.Budget,
                PoliticalLeaderId=model.PoliticalLeaderId,
                IsDeleted = false
            };
            var result = await _developmentServices.Register(development);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Development creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Development created successfully!" });

        }

        /// <summary>
        /// Update a existing Development
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("developments")]
        public async Task<IActionResult> UpdateDevelopment([FromBody] RegisterDevelopmentViewModel model)
        {
            var development = await _developmentServices.FindDevelopmentById(model.DevelopmentId);
            if (development == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Development With Id = {model.DevelopmentId} cannot be found" });
            }
            else
            {
                var result = await _developmentServices.UpdateDevelopment(model);
                return Ok(new Response { Status = "Success", Message = "Development Edited successfully!" });
            }
        }


        /// <summary>
        /// Delete a existing Development
        /// </summary>
        /// <param name="developmentId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("developments/{developmentId}")]
        public async Task<IActionResult> DeleteDevelopment(long developmentId)
        {
            var development = await _developmentServices.FindDevelopmentById(developmentId);
            if (development == null || development.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Development With Id = {development} cannot be found" });
            }
            else
            {
                RegisterDevelopmentViewModel register = new RegisterDevelopmentViewModel();
                register.DevelopmentId = development.DevelopmentId;
                register.Title = development.Title;
                register.Activity = development.Activity;
                register.ActivityMonth = development.ActivityMonth;
                register.ActivityYear = development.ActivityYear;
                register.Budget = development.Budget;
                register.PoliticalLeaderId = development.PoliticalLeaderId;
                register.IsDeleted = true;
                var result = await _developmentServices.UpdateDevelopment(register);
                return Ok(new Response { Status = "Success", Message = "Development deleted successfully!" });
            }
        }

        /// <summary>
        /// Get Development by Id
        /// </summary>
        /// <param name="developmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("developments/{developmentId}")]
        public async Task<IActionResult> GetDevelopmentById(long developmentId)
        {
            var development = await _developmentServices.FindDevelopmentById(developmentId);
            if (development == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Development With Id = {developmentId} cannot be found" });
            }
            else
            {
                return Ok(development);
            }
        }

        /// <summary>
        /// List All Developments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("developments")]
        public async Task<IEnumerable<Development>> ListAllDevelopments()
        {
            return await _developmentServices.ListAllDevelopment();
        }

        /// <summary>
        /// Fetches all the development plans created for a political leader
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("leaders/by-leader-id/{politicalLeaderId}")]
        public async Task<IEnumerable<Development>> DevelopmentPlansByPoliticalLeaderId(long politicalLeaderId)
        {
            return await _developmentServices.DevelopmentPlansByPoliticalLeaderId(politicalLeaderId);
        }
        #endregion

    }
}
