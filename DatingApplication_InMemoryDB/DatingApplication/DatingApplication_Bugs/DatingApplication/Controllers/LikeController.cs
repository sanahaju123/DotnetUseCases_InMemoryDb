using DatingApplication.BusinessLayer.Interfaces;
using DatingApplication.BusinessLayer.ViewModels;
using DatingApplication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeServices _likeServices;

        public LikeController(ILikeServices likeServices)
        {
            _likeServices = likeServices;
        }


        /// <summary>
        /// Add a new Like
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("likes")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] LikeViewModel model)
        {
            var likeExists = await _likeServices.FindLikeById(model.LikeId);
            if (likeExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Like already exists!" });
            //New object and value for user
            Like like = new Like()
            {

                UserId = model.UserId,
                IsDeleted = false
            };
            var result = await _likeServices.Register(like);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Like creation failed! Please check like details and try again." });

            return Ok(new Response { Status = "Success", Message = "Like created successfully!" });

        }

        /// <summary>
        /// Get Likes by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("likes/{userId}")]
        public async Task<IActionResult> GetLikesByUserId(long userId)
        {
            var likes = await _likeServices.ListAllLikesByUserId(userId);
            if (likes == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Likes With Id = {userId} cannot be found" });
            }
            else
            {
                return Ok(likes);
            }
        }
    }
}
