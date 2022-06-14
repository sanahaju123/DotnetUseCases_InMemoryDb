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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// List All Componies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("compony/getAllCompanies")]
        public async Task<IEnumerable<ComponyInfo>> ListAllComponies()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
