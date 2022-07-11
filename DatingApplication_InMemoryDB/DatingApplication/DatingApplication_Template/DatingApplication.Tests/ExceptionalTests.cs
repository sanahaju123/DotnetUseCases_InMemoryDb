using DatingApplication.BusinessLayer.Interfaces;
using DatingApplication.BusinessLayer.Services;
using DatingApplication.BusinessLayer.Services.Repository;
using DatingApplication.BusinessLayer.ViewModels;
using DatingApplication.DataLayer;
using DatingApplication.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DatingApplication.Tests
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly DatingAppDbContext _datingAppDbContext;

        private readonly IUserServices _userServices;
        private readonly IInterestServices _interestServices;
        private readonly IMatchServices _matchServices;
        private readonly ILikeServices _likeServices;
        private readonly IDislikeServices _dislikeServices;

        public readonly Mock<IUserRepository> userservice = new Mock<IUserRepository>();
        public readonly Mock<IInterestRepository> interestservice = new Mock<IInterestRepository>();
        public readonly Mock<IMatchRepository> matchservice = new Mock<IMatchRepository>();
        public readonly Mock<ILikeRepository> likeservice = new Mock<ILikeRepository>();
        public readonly Mock<IDislikeRepository> dislikeservice = new Mock<IDislikeRepository>();

        private User _user;
        private Interests _interests;
        private Entities.Match _match;
        private Like _like;
        private Dislike _dislike;

        private readonly UserViewModel _userViewModel;
        private readonly InterestViewModel _interestViewModel;
        private readonly MatchViewModel _matchViewModel;
        private readonly LikeViewModel _likeViewModel;
        private readonly DislikeViewModel _dislikeViewModel;


        private static string type = "Exception";
        public ExceptionalTests(ITestOutputHelper output)
        {
            _userServices = new UserServices(userservice.Object);
            _interestServices = new InterestServices(interestservice.Object);
            _matchServices = new MatchServices(matchservice.Object);
            _likeServices = new LikeServices(likeservice.Object);
            _dislikeServices = new DislikeServices(dislikeservice.Object);



            _output = output;

            _user = new User
            {
                UserId = 1,
                Name = "product1",
                Age = 28,
                City = "Goa",
                Country = "India",
                Email = "A@gmail.com",
                Gender = "female",
                Phone = "8745329875",
                IsDeleted = false
            };
            _interests = new Interests
            {
                InterestId = 8,
                InterestedIn = "Customer1",
                NotInterestedIn = "Pass123",
                About = "C1@gmail.com",
                Hobbies = "Pune,Maharashtra",
                ProfileUrl = "9435231423",
                UserId = 2,
                IsDeleted = false,
            };
            _match = new Entities.Match
            {
                MatchId = 8,
                UserId = 2,
                IsDeleted = false,
            };

            _like = new Like
            {
                LikeId = 1,
                UserId = 2,
                IsDeleted = false
            };
            _dislike = new Dislike
            {
                DislikeId = 8,
                UserId = 1,
                IsDeleted = false,
            };
            _userViewModel = new UserViewModel
            {
                UserId = 1,
                Name = "product1",
                Age = 28,
                City = "Goa",
                Country = "India",
                Email = "A@gmail.com",
                Gender = "female",
                Phone = "8745329875",
                IsDeleted = false
            };
            _interestViewModel = new InterestViewModel
            {
                InterestId = 8,
                InterestedIn = "Customer1",
                NotInterestedIn = "Pass123",
                About = "C1@gmail.com",
                Hobbies = "Pune,Maharashtra",
                ProfileUrl = "9435231423",
                UserId = 2,
                IsDeleted = false,
            };
            _matchViewModel = new MatchViewModel
            {
                MatchId = 8,
                UserId = 2,
                IsDeleted = false,
            };
            _likeViewModel = new LikeViewModel
            {
                LikeId = 1,
                UserId = 2,
                IsDeleted = false
            };
            _dislikeViewModel = new DislikeViewModel
            {
                DislikeId = 8,
                UserId = 1,
                IsDeleted = false,
            };
        }



        /// <summary>
        /// Test to validate if User name must be greater then 3 charactor and less than 100 charactor
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UserNameMinThreeCharactor()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                userservice.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
                var result = await _userServices.Register(_user);
                if (result != null && result.Name.Length > 3 && result.Name.Length < 100)
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
        /// Test to validate if User id must be greater then 0 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidUserIdIsPassed()
        {
            //Arrange
            bool res = false;
            var userId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                likeservice.Setup(repo => repo.FindLikeById(userId));
                var result = await _likeServices.FindLikeById(userId);
                if (result != null || result.UserId > 0)
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
        /// Test to validate if User Age must be greater then 18 and less than 60 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UserAgeMin18()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {
                userservice.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
                var result = await _userServices.Register(_user);
                if (result != null && result.Age > 18 && result.Age < 60)
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

