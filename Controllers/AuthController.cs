using FluentValidationExample.Models;
using FluentValidationExample.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FluentValidationExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            var validator = new LoginValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMessage = string.Join(" - ", validationResult.Errors) });
            }

            return Ok(request);
        }
    }
}
