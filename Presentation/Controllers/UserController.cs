using Api.Domain.Entities.Exceptions;
using Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUserService userService;
        public UserController(ILogger<ProductController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await userService.GetUserByIdAsync(id, trackChanges: false);
            return Ok(user);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsersAsync(trackChanges: false);

            return Ok(users);
        }
    }
}
