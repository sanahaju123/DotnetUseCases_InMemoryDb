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
            var stockpriceExists = await _stockPriceServices.FindStockPriceById(model.Id);
            if (stockpriceExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Stock Price already exists!" });
            //New object and value for user
            StockPrice stockPrice = new StockPrice()
            {

                CurrentStockPrice = model.CurrentStockPrice,
                ComponyCode = model.ComponyCode,
                StockPriceDate = model.StockPriceDate,
                StockPriceTime = model.StockPriceTime,
                IsDeleted = false
            };
            var result = await _stockPriceServices.Register(stockPrice);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Stock Price creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Stock Price created successfully!" });

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
            var stockpriceExists = await _stockPriceServices.FindStockPriceById(componyCode);
            if (stockpriceExists == null || stockpriceExists.IsDeleted == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Stock Price With Id = {componyCode} cannot be found" });
            }
            else
            {
                RegisterStockPriceViewModel register = new RegisterStockPriceViewModel();
                register.ComponyCode = stockpriceExists.ComponyCode;
                register.CurrentStockPrice = stockpriceExists.CurrentStockPrice;
                register.StockPriceTime = stockpriceExists.StockPriceTime;
                register.StockPriceDate = stockpriceExists.StockPriceDate;
                register.IsDeleted = true;
                var result = await _stockPriceServices.UpdateStockPrice(register);
                return Ok(new Response { Status = "Success", Message = "Stock Price deleted successfully!" });
            }
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
            var stockpriceExists = await _stockPriceServices.FindStockPriceById(componyCode);
            if (stockpriceExists == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Stock Price With Id = {componyCode} cannot be found" });
            }
            else
            {
                return Ok(stockpriceExists);
            }
        }

        /// <summary>
        /// List All Stock Prices
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("stock/getAllStock")]
        public async Task<IEnumerable<StockPrice>> ListAllStocks()
        {
            return await _stockPriceServices.ListAllStockPrices();
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
            var stockpriceExists = await _stockPriceServices.FindStockPriceById(componyCode);
            if (stockpriceExists == null || stockpriceExists.IsDeleted == true)
            {
                return null;
            }
            else
            {
                var result = await _stockPriceServices.GetStockPriceIndex(componyCode, startDate, endDate);
                return result;
            }
        }
        #endregion

    }
}
