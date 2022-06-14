using E_StockMarket.BusinessLayer.Interfaces;
using E_StockMarket.BusinessLayer.ViewModels;
using E_StockMarket.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_StockMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponyInfoController : ControllerBase
    {
        private readonly IComponyInfoServices _componyInfoServices;

        public ComponyInfoController(IComponyInfoServices componyInfoServices)
        {
            _componyInfoServices = componyInfoServices;
        }

        #region ComponyInfoRegion
        /// <summary>
        /// Register a new compony details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("compony/addCompony")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterComponyInfoViewModel model)
        {
            var componyExists = await _componyInfoServices.FindComponyInfoById(model.ComponyCode);
            if (componyExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Compony already exists!" });
            //New object and value for user
            ComponyInfo componyInfo = new ComponyInfo()
            {

                Name = model.Name,
                CEO = model.CEO,
                BoardOfDirectors = model.BoardOfDirectors,
                Profile = model.Profile,
                StockExchange = model.StockExchange,
                Turnover = model.Turnover,
                IsDeleted = false
            };
            var result = await _componyInfoServices.Register(componyInfo);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Compony creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Compony created successfully!" });

        }


        /// <summary>
        /// Delete a existing Compony
        /// </summary>
        /// <param name="componyCode"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("compony/deleteCompony/{componyCode}")]
        public async Task<IActionResult> DeleteComponyInfo(long componyCode)
        {
            var componyExists = await _componyInfoServices.FindComponyInfoById(componyCode);
            if (componyExists == null || componyExists.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Compony With Id = {componyCode} cannot be found" });
            }
            else
            {
                RegisterComponyInfoViewModel register = new RegisterComponyInfoViewModel();
                register.ComponyCode = componyExists.ComponyCode;
                register.Name = componyExists.Name;
                register.CEO = componyExists.CEO;
                register.BoardOfDirectors = componyExists.BoardOfDirectors;
                register.StockExchange = componyExists.StockExchange;
                register.Turnover = componyExists.Turnover;
                register.Profile = componyExists.Profile;
                register.IsDeleted = true;
                var result = await _componyInfoServices.UpdateComponyInfo(register);
                return Ok(new Response { Status = "Success", Message = "Compony deleted successfully!" });
            }
        }

        /// <summary>
        /// Get Compony by compony code
        /// </summary>
        /// <param name="componyCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("compony/getComponyInfoById/{componyCode}")]
        public async Task<IActionResult> GetComponyInfoById(long componyCode)
        {
            var componyExists = await _componyInfoServices.FindComponyInfoById(componyCode);
            if (componyExists == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Compony With Id = {componyCode} cannot be found" });
            }
            else
            {
                return Ok(componyExists);
            }
        }

        /// <summary>
        /// List All Componies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("compony/getAllCompanies")]
        public async Task<IEnumerable<ComponyInfo>> ListAllComponies()
        {
            return await _componyInfoServices.ListAllComponyInfos();
        }
        #endregion
    }
}
