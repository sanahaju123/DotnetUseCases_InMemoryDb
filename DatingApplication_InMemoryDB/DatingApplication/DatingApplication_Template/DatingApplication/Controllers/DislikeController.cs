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
            throw new NotImplementedException();

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
            throw new NotImplementedException();
        }
    }
}
