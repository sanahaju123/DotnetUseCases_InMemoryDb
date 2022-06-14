using E_StockMarket.BusinessLayer.Interfaces;
using E_StockMarket.BusinessLayer.Services;
using E_StockMarket.BusinessLayer.Services.Repository;
using E_StockMarket.BusinessLayer.ViewModels;
using E_StockMarket.DataLayer;
using E_StockMarket.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace E_StockMarket.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly StockMarketDbContext _stockMarketDbContext;

        private readonly IComponyInfoServices _componyInfoServices;
        private readonly IStockPriceServices _stockPriceServices;

        public readonly Mock<IComponyInfoRepository> componyInfoServices = new Mock<IComponyInfoRepository>();
        public readonly Mock<IStockPriceRepository> stockPriceServices = new Mock<IStockPriceRepository>();

        private ComponyInfo _componyInfo;
        private StockPrice _stockPrice;

        private readonly RegisterComponyInfoViewModel _registerComponyInfoViewModel;
        private readonly RegisterStockPriceViewModel _registerStockPriceViewModel;

        private static string type = "Exceptional";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _componyInfoServices = new ComponyInfoServices(componyInfoServices.Object, _stockMarketDbContext);
            _stockPriceServices = new StockPriceServices(stockPriceServices.Object, _stockMarketDbContext);


            _output = output;

            _componyInfo = new ComponyInfo
            {
                ComponyCode = 9,
                Name = "Party1",
                BoardOfDirectors = "abc",
                IsDeleted = false,
                Profile = "ppppp",
                CEO = "asdf",
                StockExchange = "stock",
                Turnover = 1234
            };
            _stockPrice = new StockPrice
            {
                Id = 8,
                StockPriceDate = DateTime.Now,
                StockPriceTime = DateTime.Now,
                CurrentStockPrice = 1,
                IsDeleted = false,
            };
            _registerComponyInfoViewModel = new RegisterComponyInfoViewModel
            {
                ComponyCode = 9,
                Name = "Party1",
                BoardOfDirectors = "abc",
                IsDeleted = false,
                Profile = "ppppp",
                CEO = "asdf",
                StockExchange = "stock",
                Turnover = 1234
            };
            _registerStockPriceViewModel = new RegisterStockPriceViewModel
            {
                Id = 8,
                StockPriceDate = DateTime.Now,
                StockPriceTime = DateTime.Now,
                CurrentStockPrice = 1,
                IsDeleted = false,
            };
        }

        /// <summary>
        /// Test to validate if stock price id must be greater then 0 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidStockPriceIdIsPassed()
        {
            //Arrange
            bool res = false;
            var stockPriceId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                stockPriceServices.Setup(repo => repo.FindStockPriceById(stockPriceId)).ReturnsAsync(_stockPrice);
                var result = await _stockPriceServices.FindStockPriceById(stockPriceId);
                if (result != null || result.Id > 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to validate if compony code must be greater then 0 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidComponyCodeIsPassed()
        {
            //Arrange
            bool res = false;
            var componyCode = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                stockPriceServices.Setup(repo => repo.FindStockPriceById(componyCode)).ReturnsAsync(_stockPrice);
                var result = await _stockPriceServices.FindStockPriceById(componyCode);
                if (result != null || result.Id > 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                //final result save in text file if exception raised
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            //final result save in text file, Call rest API to save test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}
