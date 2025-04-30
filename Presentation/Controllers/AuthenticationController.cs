using Api.Services.Contracts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Shared.DTOs;

namespace Ecommerce.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(IAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
        {
            this.authenticationService = authenticationService;
            _logger = logger;
        }
        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS, POST");
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            Console.WriteLine(userForRegistrationDto);
            var result =
            await authenticationService.RegisterUser(userForRegistrationDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(
            [FromBody] UserForAuthenticationDto user
            //[FromServices] IValidator<UserForAuthenticationDto> validator
            )
        {
            //ValidationResult validationResult = validator.Validate(user);
            //if (!validationResult.IsValid)
            //{
            //    var modelStateDictionary = new ModelStateDictionary();
            //    foreach (var error in validationResult.Errors)
            //    {
            //        modelStateDictionary.AddModelError(
            //            error.PropertyName,
            //            error.ErrorMessage
            //        );
            //    }
            //    return ValidationProblem(modelStateDictionary);
            //}

            if (!await authenticationService.ValidateUser(user))
                return Unauthorized();
            var tokenDto = await authenticationService.CreateToken(populateExp: true);


            _logger.LogInformation("We received {@user}", user);


            return Ok(tokenDto);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await
            authenticationService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }
    }
}
