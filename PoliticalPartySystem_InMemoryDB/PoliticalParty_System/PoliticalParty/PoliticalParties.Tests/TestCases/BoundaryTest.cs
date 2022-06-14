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
    public class BoundaryTest
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

        private static string type = "Boundary";

        public BoundaryTest(ITestOutputHelper output)
        {
            _politicalPartyServices = new PoliticalPartyServices(politicalPartyservice.Object,_politicalPartiesDbContext);
            _politicalLeaderServices = new PoliticalLeaderServices(politicalLeaderservice.Object, _politicalPartiesDbContext);
            _developmentServices = new DevelopmentServices(developmentservice.Object, _politicalPartiesDbContext);

            _output = output;

            _politicalParty = new PoliticalParty
            {
                PoliticalPartyId = 1,
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

        /// <summary>
        /// Test to validate Political Party Name connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_PoliticalParty_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalPartyservice.Setup(repo => repo.Register(_politicalParty)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.Register(_politicalParty);
                var actualLength = _politicalParty.Name.ToString().Length;
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
        /// Test to validate if Political Party name must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_PartyNameMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalPartyservice.Setup(repo => repo.Register(_politicalParty)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.Register(_politicalParty);
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
        /// Test to validate if Political Party name must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_PartyNameMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalPartyservice.Setup(repo => repo.Register(_politicalParty)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.Register(_politicalParty);
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
        /// Test to validate Party founder Name connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_PartyFounder_Name_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalPartyservice.Setup(repo => repo.Register(_politicalParty)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.Register(_politicalParty);
                var actualLength = _politicalParty.Founder.ToString().Length;
                if (result.Founder.ToString().Length == actualLength)
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
        /// Test to validate if Party founder name must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_PartyFounderNameMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalPartyservice.Setup(repo => repo.Register(_politicalParty)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.Register(_politicalParty);
                if (result != null && result.Founder.Length > 3)
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
        /// Test to validate if  Party Founder name must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_FounderNameMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalPartyservice.Setup(repo => repo.Register(_politicalParty)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.Register(_politicalParty);
                if (result != null && result.Founder.Length < 100)
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
        /// Test to validate Political Leader Party Id connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_PoliticalLeader_PartyId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalLeaderservice.Setup(repo => repo.Register(_politicalLeader)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.Register(_politicalLeader);
                var actualLength = _politicalLeader.PoliticalPartyId.ToString().Length;
                if (result.PoliticalPartyId.ToString().Length == actualLength)
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
        /// Test to validate if Political Leader Candidate name must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_CandidateNameMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalLeaderservice.Setup(repo => repo.Register(_politicalLeader)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.Register(_politicalLeader);
                if (result != null && result.CandidateName.Length > 3)
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
        /// Test to validate if Political Leader Candidate name must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_CandidateNameMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalLeaderservice.Setup(repo => repo.Register(_politicalLeader)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.Register(_politicalLeader);
                if (result != null && result.CandidateName.Length < 100)
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
        /// Test to validate Political Leader Candidate State connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_PoliticalLeader_CandidateState_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalLeaderservice.Setup(repo => repo.Register(_politicalLeader)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.Register(_politicalLeader);
                var actualLength = _politicalLeader.StateName.ToString().Length;
                if (result.StateName.ToString().Length == actualLength)
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
        /// Test to validate if Political Leader Candidate state must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_CandidateStateMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalLeaderservice.Setup(repo => repo.Register(_politicalLeader)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.Register(_politicalLeader);
                if (result != null && result.StateName.Length > 3)
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
        /// Test to validate if Political Leader Candidate state must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_CandidateStateMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalLeaderservice.Setup(repo => repo.Register(_politicalLeader)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.Register(_politicalLeader);
                if (result != null && result.StateName.Length < 100)
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
        /// Test to validate development political leader Id connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Development_PoliticalLeaderId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                var actualLength = _development.PoliticalLeaderId.ToString().Length;
                if (result.PoliticalLeaderId.ToString().Length == actualLength)
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
        /// Test to validate development title connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_DevelopmentTitle_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                var actualLength = _development.Title.ToString().Length;
                if (result.Title.ToString().Length == actualLength)
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
        /// Test to validate if development title must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentTitleMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.Title.Length > 3)
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
        /// Test to validate if development title must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentTitleMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.Title.Length < 100)
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
        /// Test to validate development Activity connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Development_Activity_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                var actualLength = _development.Activity.ToString().Length;
                if (result.Activity.ToString().Length == actualLength)
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
        /// Test to validate if development activity must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentActivityMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.Activity.Length > 3)
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
        /// Test to validate if development activity must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentActivityMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.Activity.Length < 100)
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
        /// Test to validate development Budget connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Development_Budget_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                var actualLength = _development.Budget.ToString().Length;
                if (result.Budget.ToString().Length == actualLength)
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
        /// Test to validate if development budget must be greater then 3 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentBudgetMinThreeCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.Budget.ToString().Length > 3)
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
        /// Test to validate if development budget must be less then 100 Character 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentBudgetMaxHundredCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.Budget.ToString().Length < 100)
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
        /// Test to validate Development Activity Month connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Development_ActivityMonth_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                var actualLength = _development.ActivityMonth.ToString().Length;
                if (result.ActivityMonth.ToString().Length == actualLength)
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
        /// Test to validate if development activity month must be greater then 1 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentACtivityMonthMinOneCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.ActivityMonth > 0)
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
        /// Test to validate if development activity month must be less then 12  
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentActivityMonthMaxTwelveCharacter()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.ActivityMonth < 13)
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
        /// Test to validate Development Activity Year connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Development_ActivityYear_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                var actualLength = _development.ActivityYear.ToString().Length;
                if (result.ActivityYear.ToString().Length == actualLength)
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
        /// Test to validate if development activity month must be greater then 2021 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentActivityYearMin2021()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.ActivityYear > 2020)
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
        /// Test to validate if development activity year must be less then 2040 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_DevelopmentActivityYearMax2040()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.Register(_development)).ReturnsAsync(_development);
                var result = await _developmentServices.Register(_development);
                if (result != null && result.ActivityYear < 2041)
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
   