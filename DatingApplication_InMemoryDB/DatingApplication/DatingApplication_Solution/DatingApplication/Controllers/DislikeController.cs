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
    public class DislikeController : ControllerBase
    {
        private readonly IDislikeServices _dislikeServices;

        public DislikeController(IDislikeServices dislikeServices)
        {
            _dislikeServices = dislikeServices;
        }


        /// <summary>
        /// Add a new Dislike
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("dislikes")]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody] DislikeViewModel model)
        {
            var dislikeExists = await _dislikeServices.FindDislikeById(model.DislikeId);
            if (dislikeExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Dislike already exists!" });
            //New object and value for user
            Dislike dislike = new Dislike()
            {

                UserId = model.UserId,
                IsDeleted = false
            };
            var result = await _dislikeServices.Register(dislike);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Dislike creation failed! Please check dislike details and try again." });

            return Ok(new Response { Status = "Success", Message = "Dislike created successfully!" });

        }

        /// <summary>
        /// Get Dislikes by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("dislikes/{userId}")]
        public async Task<IActionResult> GetDislikesByUserId(long userId)
        {
            var dislikes = await _dislikeServices.ListAllDislikesByUserId(userId);
            if (dislikes == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Dislikes With Id = {userId} cannot be found" });
            }
            else
            {
                return Ok(dislikes);
            }
        }
    }
}
