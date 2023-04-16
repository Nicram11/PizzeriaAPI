using Application.Security.Commands;
using Application.Security.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            if (command.Password != command.ConfirmPassword)
                return BadRequest("The passwords you entered do not match. Please try again");


            var result = await mediator.Send(command);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserQuery query)
        {
            var result = await mediator.Send(query);

            if (result.Successed)
                return Ok(result.Token);
            else
                return Unauthorized();
        }
  
    }
}
