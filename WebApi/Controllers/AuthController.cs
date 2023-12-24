using Application.Features.Authentication.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    // [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserRequest registerUserRequest)
        {
            var result = _mediator.Send(registerUserRequest);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserRequest loginUserRequest)
        {
            var result = _mediator.Send(loginUserRequest);
            return Ok(result);
        }
    }
}
