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
    public class FunctionalTests
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


        private static string type = "Functional";
        public FunctionalTests(ITestOutputHelper output)
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
                UserId=2,
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

        #region RegionUser
        /// <summary>
        /// Test to register new User for Dating Application
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Register_User()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                userservice.Setup(repos => repos.Register(_user)).ReturnsAsync(_user);
                var result = await _userServices.Register(_user);
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
        /// Using the below test method Update User by using User Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_User()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateUser = new UserViewModel()
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
            //Act
            try
            {
                userservice.Setup(repos => repos.UpdateUser(_updateUser)).ReturnsAsync(_user); ;
                var result = await _userServices.UpdateUser(_updateUser);
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
        /// Test to list all Users 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Users()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                userservice.Setup(repos => repos.ListAllUsers());
                var result = await _userServices.ListAllUsers();
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
        /// Test to find User by User Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindUserById()
        {
            //Arrange
            var res = false;
            int userId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                userservice.Setup(repos => repos.FindUserById(userId)).ReturnsAsync(_user); ;
                var result = await _userServices.FindUserById(userId);
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

        #region RegionInterest
        /// <summary>
        /// Test to register new Interest for Dating Application
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Interest()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                interestservice.Setup(repos => repos.Register(_interests)).ReturnsAsync(_interests);
                var result = await _interestServices.Register(_interests);
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
        /// Using the below test method Update Interest by using Interest Id.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Update_Interest()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            var _updateInterest = new InterestViewModel()
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
            //Act
            try
            {
                interestservice.Setup(repos => repos.UpdateInterest(_updateInterest)).ReturnsAsync(_interests); ;
                var result = await _interestServices.UpdateInterest(_updateInterest);
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
        /// Test to find Interest by User Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindInterest_ByUserId()
        {
            //Arrange
            var res = false;
            int userId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                interestservice.Setup(repos => repos.FindInterestByUserId(userId));
                var result = await _interestServices.FindInterestByUserId(userId);
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
        /// Test to find Interest by Interest Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindInterest_ByInterestId()
        {
            //Arrange
            var res = false;
            int interestId = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                interestservice.Setup(repos => repos.FindInterestByUserId(interestId));
                var result = await _interestServices.FindInterestByUserId(interestId);
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

        #region RegionMatch
        /// <summary>
        /// Test to Add new Match for Dating Application
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Match()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                matchservice.Setup(repos => repos.Register(_match)).ReturnsAsync(_match);
                var result = await _matchServices.Register(_match);
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
        /// Test to list all Matches 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Matches()
        {
            //Arrange
            var res = false;
            string testName; string status;
            int userId = 1;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                matchservice.Setup(repos => repos.ListAllMatchesByUserId(userId));
                var result = await _matchServices.ListAllMatchesByUserId(userId);
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
        /// Test to list all Matches using filter
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_MatchesByFilter()
        {
            //Arrange
            var res = false;
            string testName; string status;
            int userId = 1;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                matchservice.Setup(repos => repos.ListAllMatchesByFilter(userId,_user));
                var result = await _matchServices.ListAllMatchesByFilter(userId,_user);
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

        #region RegionLike
        /// <summary>
        /// Test to Add new Like for Dating Application
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Like()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                likeservice.Setup(repos => repos.Register(_like)).ReturnsAsync(_like);
                var result = await _likeServices.Register(_like);
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
        /// Test to list all Likes 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Likes()
        {
            //Arrange
            var res = false;
            string testName; string status;
            int userId = 1;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                likeservice.Setup(repos => repos.ListAllLikesByUserId(userId));
                var result = await _likeServices.ListAllLikesByUserId(userId);
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

        #region RegionDislike
        /// <summary>
        /// Test to Add new dislike for Dating Application
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Add_Dislike()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                dislikeservice.Setup(repos => repos.Register(_dislike)).ReturnsAsync(_dislike);
                var result = await _dislikeServices.Register(_dislike);
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
        /// Test to list all Dislikes 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ListAll_Dislikes()
        {
            //Arrange
            var res = false;
            string testName; string status;
            int userId = 1;
            testName = CallAPI.GetCurrentMethodName();
            //Action
            try
            {
                dislikeservice.Setup(repos => repos.ListAllDislikesByUserId(userId));
                var result = await _dislikeServices.ListAllDislikesByUserId(userId);
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
