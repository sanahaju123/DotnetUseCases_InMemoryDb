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
    public class StockPriceController : ControllerBase
    {
        private readonly IStockPriceServices _stockPriceServices;

        public StockPriceController(IStockPriceServices stockPriceServices)
        {
            _stockPriceServices = stockPriceServices;
        }

        #region StockPriceRegion
        /// <summary>
        /// Register a new stock price details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("stock/addStock")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] RegisterStockPriceViewModel model)
        {
            throw new NotImplementedException();

        }


        /// <summary>
        /// Delete a existing Stock Price
        /// </summary>
        /// <param name="componyCode"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("stock/deleteStock/{componyCode}")]
        public async Task<IActionResult> DeleteStockPrice(long componyCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Stock Price by compony code
        /// </summary>
        /// <param name="componyCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/stock/getStockByCompanyCode/{componyCode}")]
        public async Task<IActionResult> GetStockByCompanyCode(long componyCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List All Stock Prices
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("stock/getAllStock")]
        public async Task<IEnumerable<StockPrice>> ListAllStocks()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Fetches Stock Price Index with companyCode and duration
        /// </summary>
        /// <param name="componyCode"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("stock/getStockPriceIndex/{componyCode}/{startDate}/{endDate}")]
        public async Task<IEnumerable<StockPrice>> GetStockPriceIndex(long componyCode,DateTime startDate,DateTime endDate)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
