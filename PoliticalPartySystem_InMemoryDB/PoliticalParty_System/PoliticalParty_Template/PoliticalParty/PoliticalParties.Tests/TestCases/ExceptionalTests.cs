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
    public class ExceptionalTests
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

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
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
        /// Test to validate if political party id must be greater then 0 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidPoliticalPartyIdIsPassed()
        {
            //Arrange
            bool res = false;
            var politicalPartyId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalPartyservice.Setup(repo => repo.FindPoliticalPartyById(politicalPartyId)).ReturnsAsync(_politicalParty);
                var result = await _politicalPartyServices.FindPoliticalPartyById(politicalPartyId);
                if (result != null || result.PoliticalPartyId > 0)
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
        /// Test to validate if political leader id must be greater then 0 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidPoliticalLeaderIdIsPassed()
        {
            //Arrange
            bool res = false;
            var politicalLeaderId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                politicalLeaderservice.Setup(repo => repo.FindPoliticalLeaderById(politicalLeaderId)).ReturnsAsync(_politicalLeader);
                var result = await _politicalLeaderServices.FindPoliticalLeaderById(politicalLeaderId);
                if (result != null || result.PoliticalLeaderId > 0)
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
        /// Test to validate if development id must be greater then 0 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidDevelopmentIdIsPassed()
        {
            //Arrange
            bool res = false;
            var developmentId = 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                developmentservice.Setup(repo => repo.FindDevelopmentById(developmentId)).ReturnsAsync(_development);
                var result = await _developmentServices.FindDevelopmentById(developmentId);
                if (result != null || result.DevelopmentId > 0)
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
