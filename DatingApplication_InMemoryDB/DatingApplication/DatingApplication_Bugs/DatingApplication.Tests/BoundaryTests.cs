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
    public class BoundaryTests
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


        private static string type = "Boundary";
        public BoundaryTests(ITestOutputHelper output)
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
        ///  Testfor_ValidEmail to test email id is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidEmail()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Act
            try
            {

                //Assert
                userservice.Setup(repo => repo.Register(_user)).ReturnsAsync(_user);
                var result = await _userServices.Register(_user);
                var actualLength = _user.Email.ToString().Length;
                if (result.Email.ToString().Length == actualLength)
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
        /// Testfor_ValidateMobileNumber is used for test mobile number is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateMobileNumber()
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
                var actualLength = _user.Phone.ToString().Length;
                if (result.Phone.ToString().Length == actualLength)
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
        /// Test to validate User Name connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Name_NotEmpty()
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
                var actualLength = _user.Name.ToString().Length;
                if (result.Name.ToString().Length == actualLength)
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
        /// Test to validate User City connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_City_NotEmpty()
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
                var actualLength = _user.City.ToString().Length;
                if (result.City.ToString().Length == actualLength)
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
        /// Test to validate User Country connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Country_NotEmpty()
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
                var actualLength = _user.Country.ToString().Length;
                if (result.Country.ToString().Length == actualLength)
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
        /// Test to validate User Age connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Age_NotEmpty()
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
                var actualLength = _user.Age.ToString().Length;
                if (result.Age.ToString().Length == actualLength)
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
        /// Test to validate User Gender connaot be blanks.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Gender_NotEmpty()
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
                var actualLength = _user.Gender.ToString().Length;
                if (result.Gender.ToString().Length == actualLength)
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

