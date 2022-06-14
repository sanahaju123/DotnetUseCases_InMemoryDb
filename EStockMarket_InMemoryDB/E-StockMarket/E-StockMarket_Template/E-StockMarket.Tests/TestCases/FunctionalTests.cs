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
    public class FunctionalTests
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

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
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
                Profile="ppppp",
                CEO="asdf",
                StockExchange="stock",
                Turnover=1234
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

        #region ComponyInfo
        /// <summary>
        /// Test to register new Compony Info
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Register_ComponyInfo()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                componyInfoServices.Setup(repos => repos.Register(_componyInfo)).ReturnsAsync(_componyInfo);
                var result = await _componyInfoServices.Register(_componyInfo);
                //Assertion
                if (result != null)
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
        /// Using the below test method Delete Compony Info by using Compony Code.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Delete_ComponyInfo()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _deleteComponyInfo = new RegisterComponyInfoViewModel()
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
            //Act
            try
            {
                componyInfoServices.Setup(repos => repos.UpdateComponyInfo(_deleteComponyInfo)).ReturnsAsync(_componyInfo);
                var result = await _componyInfoServices.UpdateComponyInfo(_deleteComponyInfo);
                if (result != null)
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
        /// Test to list all Componies 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Componies()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                componyInfoServices.Setup(repos => repos.ListAllComponyInfos());
                var result = await _componyInfoServices.ListAllComponyInfos();
                //Assertion
                if (result != null)
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
        /// Test to find Compony Info by Compony Code
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindComponyInfoById()
        {
            //Arrange
            var res = false;
            int componyInfoId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                componyInfoServices.Setup(repos => repos.FindComponyInfoById(componyInfoId)).ReturnsAsync(_componyInfo); ;
                var result = await _componyInfoServices.FindComponyInfoById(componyInfoId);
                //Assertion
                if (result != null)
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
        #endregion

        #region StockPrice
        /// <summary>
        /// Test to register new Stock Price
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Register_StockPrice()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                stockPriceServices.Setup(repos => repos.Register(_stockPrice)).ReturnsAsync(_stockPrice);
                var result = await _stockPriceServices.Register(_stockPrice);
                //Assertion
                if (result != null)
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
        /// Using the below test method Delete Stock Price by using Compony Code.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Delete_StockPrice()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _deleteStockPrice = new RegisterStockPriceViewModel()
            {
                Id = 8,
                StockPriceDate = DateTime.Now,
                StockPriceTime = DateTime.Now,
                CurrentStockPrice = 1,
                IsDeleted = false,
            };
            //Act
            try
            {
                stockPriceServices.Setup(repos => repos.UpdateStockPrice(_deleteStockPrice)).ReturnsAsync(_stockPrice);
                var result = await _stockPriceServices.UpdateStockPrice(_deleteStockPrice);
                if (result != null)
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
        /// Test to list all Stock Prices 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_StockPrices()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                stockPriceServices.Setup(repos => repos.ListAllStockPrices());
                var result = await _stockPriceServices.ListAllStockPrices();
                //Assertion
                if (result != null)
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
        /// Test to find Stock Price by Compony Code
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindStockPriceById()
        {
            //Arrange
            var res = false;
            int componyCode = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                stockPriceServices.Setup(repos => repos.FindStockPriceById(componyCode)).ReturnsAsync(_stockPrice); ;
                var result = await _stockPriceServices.FindStockPriceById(componyCode);
                //Assertion
                if (result != null)
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
        /// Fetches Stock Price Index with companyCode and duration
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindStockPriceIndex()
        {
            //Arrange
            var res = false;
            int componyCode = 1;
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                stockPriceServices.Setup(repos => repos.GetStockPriceIndex(componyCode,startDate,endDate));
                var result = await _stockPriceServices.GetStockPriceIndex(componyCode, startDate, endDate);
                //Assertion
                if (result != null)
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
        #endregion

    }
}
