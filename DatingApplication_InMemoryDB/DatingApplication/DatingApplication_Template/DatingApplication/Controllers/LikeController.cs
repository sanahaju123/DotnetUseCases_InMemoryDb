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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
