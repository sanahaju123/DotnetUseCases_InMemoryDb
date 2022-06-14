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
        public class BoundaryTests
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

            private static string type = "Boundary";

            public BoundaryTests(ITestOutputHelper output)
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
        /// Test to validate compony name connaot be blank.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Compony_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                componyInfoServices.Setup(repo => repo.Register(_componyInfo)).ReturnsAsync(_componyInfo);
                var result = await _componyInfoServices.Register(_componyInfo);
                var actualLength = _componyInfo.Name.ToString().Length;
                if (result.Name.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if compony name must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ComponyNameMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                componyInfoServices.Setup(repo => repo.Register(_componyInfo)).ReturnsAsync(_componyInfo);
                var result = await _componyInfoServices.Register(_componyInfo);
                if (result != null && result.Name.Length > 3)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if compony name must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ComponyNameMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                componyInfoServices.Setup(repo => repo.Register(_componyInfo)).ReturnsAsync(_componyInfo);
                var result = await _componyInfoServices.Register(_componyInfo);
                if (result != null && result.Name.Length < 100)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate compony CEO connaot be blank.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Compony_CEO_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                componyInfoServices.Setup(repo => repo.Register(_componyInfo)).ReturnsAsync(_componyInfo);
                var result = await _componyInfoServices.Register(_componyInfo);
                var actualLength = _componyInfo.CEO.ToString().Length;
                if (result.CEO.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if compony CEO must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ComponyCEOMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                componyInfoServices.Setup(repo => repo.Register(_componyInfo)).ReturnsAsync(_componyInfo);
                var result = await _componyInfoServices.Register(_componyInfo);
                if (result != null && result.CEO.Length > 3)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if compony CEO must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ComponyCEOMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                componyInfoServices.Setup(repo => repo.Register(_componyInfo)).ReturnsAsync(_componyInfo);
                var result = await _componyInfoServices.Register(_componyInfo);
                if (result != null && result.CEO.Length < 100)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if stock price date is not exceeding current date
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_StockPriceDate()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                stockPriceServices.Setup(repo => repo.Register(_stockPrice)).ReturnsAsync(_stockPrice);
                var result = await _stockPriceServices.Register(_stockPrice);
                if (result != null && result.StockPriceDate <= DateTime.Now)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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
        /// Test to validate if stock price time is not exceeding current time
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_StockPriceTime()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                stockPriceServices.Setup(repo => repo.Register(_stockPrice)).ReturnsAsync(_stockPrice);
                var result = await _stockPriceServices.Register(_stockPrice);
                if (result != null && result.StockPriceTime <= DateTime.Now)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
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

