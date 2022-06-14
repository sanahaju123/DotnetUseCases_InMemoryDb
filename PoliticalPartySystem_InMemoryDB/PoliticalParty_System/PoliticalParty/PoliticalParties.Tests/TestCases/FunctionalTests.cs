using Moq;
using PoliticalParties.BusinessLayer.Interfaces;
using PoliticalParties.BusinessLayer.Services;
using PoliticalParties.BusinessLayer.Services.Repository;
using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.DataLayer;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PoliticalParties.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly PoliticalPartiesDbContext _politicalPartiesDbContext;

        private readonly IPoliticalPartyServices _politicalPartyServices;
        private readonly IPoliticalLeaderServices _politicalLeaderServices;
        private readonly IDevelopmentServices _developmentServices;

        public readonly Mock<IPoliticalPartyRepository> politicalPartyservice = new Mock<IPoliticalPartyRepository>();
        public readonly Mock<IPoliticalLeaderRepository> politicalLeaderservice = new Mock<IPoliticalLeaderRepository>();
        public readonly Mock<IDevelopmentRepository> developmentservice = new Mock<IDevelopmentRepository>();

        private PoliticalParty _politicalParty;
        private PoliticalLeader _politicalLeader;
        private Development _development;

        private readonly RegisterPoliticalPartyViewModel _registerPoliticalPartyViewModel;
        private readonly RegisterPoliticalLeaderViewModel _registerPoliticalLeaderViewModel;
        private readonly RegisterDevelopmentViewModel _registerDevelopmentViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _politicalPartyServices = new PoliticalPartyServices(politicalPartyservice.Object,_politicalPartiesDbContext);
            _politicalLeaderServices = new PoliticalLeaderServices(politicalLeaderservice.Object, _politicalPartiesDbContext);
            _developmentServices = new DevelopmentServices(developmentservice.Object, _politicalPartiesDbContext);

            _output = output;

            _politicalParty = new PoliticalParty
            {
                PoliticalPartyId = 9,
                Name = "Party1",
                Founder = "abc",
                IsDeleted = false
            };
            _politicalLeader = new PoliticalLeader
            {
                PoliticalLeaderId = 8,
                CandidateName = "Leader1",
                StateName = "Goa",
                PoliticalPartyId = 1,
                IsDeleted = false,
            };
            _development = new Development
            {
                DevelopmentId = 8,
                Title = "Dev1",
                Activity = "s1@gmail.com",
                ActivityMonth = 3,
                ActivityYear = 2032,
                Budget = 1,
                IsDeleted = false,
            };

            _registerPoliticalPartyViewModel = new RegisterPoliticalPartyViewModel
            {
                PoliticalPartyId = 1,
                Name = "Party1",
                Founder = "abc",
                IsDeleted = false
            };
            _registerPoliticalLeaderViewModel = new RegisterPoliticalLeaderViewModel
            {
                PoliticalLeaderId = 8,
                CandidateName = "Leader1",
                StateName = "Goa",
                PoliticalPartyId = 1,
                IsDeleted = false,
            };
            _registerDevelopmentViewModel = new RegisterDevelopmentViewModel
            {
                DevelopmentId = 8,
                Title = "Dev1",
                Activity = "s1@gmail.com",
                ActivityMonth = 3,
                ActivityYear = 2032,
                Budget = 1,
                IsDeleted = false,
            };
        }

        #region PoliticalParty
        /// <summary>
        /// Test to register new PoliticalParty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Register_PoliticalParty()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                politicalPartyservice.Setup(repos => repos.Register(_politicalParty)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.Register(_politicalParty);
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
        /// Using the below test method Update Political Party by using Political Party Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_PoliticalParty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updatePoliticalParty = new RegisterPoliticalPartyViewModel()
            {
                PoliticalPartyId = 1,
                Name = "product1",
                IsDeleted = false
            };
            //Act
            try
            {
                politicalPartyservice.Setup(repos => repos.UpdatePoliticalParty(_updatePoliticalParty)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.UpdatePoliticalParty(_updatePoliticalParty);
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
        /// Test to list all PoliticalParty 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_PoliticalParties()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                politicalPartyservice.Setup(repos => repos.ListAllPoliticalParty());
                var result = await _politicalPartyServices.ListAllPoliticalParty();
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
        /// Test to find Political Party by Political Party Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindPoliticalPartyById()
        {
            //Arrange
            var res = false;
            int politicalPartyId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                politicalPartyservice.Setup(repos => repos.FindPoliticalPartyById(politicalPartyId)).ReturnsAsync(_politicalParty); ;
                var result = await _politicalPartyServices.FindPoliticalPartyById(politicalPartyId);
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

        #region PoliticalLeader
        /// <summary>
        /// Test to register new PoliticalLeader
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Register_PoliticalLeader()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                politicalLeaderservice.Setup(repos => repos.Register(_politicalLeader)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.Register(_politicalLeader);
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
        /// Using the below test method Update Political Leader by using Political Leader Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_PoliticalLeader()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updatePoliticalLeader = new RegisterPoliticalLeaderViewModel()
            {
                PoliticalLeaderId = 1,
                CandidateName = "Candidate1",
                StateName="Maharashtra",
                PoliticalPartyId=2,
                IsDeleted = false
            };
            //Act
            try
            {
                politicalLeaderservice.Setup(repos => repos.UpdatePoliticalLeader(_updatePoliticalLeader)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.UpdatePoliticalLeader(_updatePoliticalLeader);
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
        /// Test to list all PoliticalLeader 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_PoliticalLeader()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                politicalLeaderservice.Setup(repos => repos.ListAllPoliticalLeader());
                var result = await _politicalLeaderServices.ListAllPoliticalLeader();
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
        /// Test to find Political Leader by Political Leader Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindPoliticalLeaderById()
        {
            //Arrange
            var res = false;
            int politicalLeaderId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                politicalLeaderservice.Setup(repos => repos.FindPoliticalLeaderById(politicalLeaderId)).ReturnsAsync(_politicalLeader); ;
                var result = await _politicalLeaderServices.FindPoliticalLeaderById(politicalLeaderId);
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

        #region Development
        /// <summary>
        /// Test to register new Development Plan
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Register_DevelopmentPlan()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                developmentservice.Setup(repos => repos.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
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
        /// Using the below test method Update development by using development Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_development()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateDevelopment = new RegisterDevelopmentViewModel()
            {
                DevelopmentId = 1,
                Title = "Plan1",
                Activity = "Act1",
                ActivityMonth = 2,
                ActivityYear=2021,
                PoliticalLeaderId=1,
                IsDeleted = false
            };
            //Act
            try
            {
                developmentservice.Setup(repos => repos.UpdateDevelopment(_updateDevelopment)).ReturnsAsync(_development);
                var result = await _developmentServices.UpdateDevelopment(_updateDevelopment);
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
        /// Test to list all Development 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Development()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                developmentservice.Setup(repos => repos.ListAllDevelopment());
                var result = await _developmentServices.ListAllDevelopment();
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
        /// Test to find Development by development Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindDevelopmentById()
        {
            //Arrange
            var res = false;
            int developmentId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                developmentservice.Setup(repos => repos.FindDevelopmentById(developmentId)).ReturnsAsync(_development);
                var result = await _developmentServices.FindDevelopmentById(developmentId);
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


