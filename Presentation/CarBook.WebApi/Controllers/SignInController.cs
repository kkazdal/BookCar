using CarBook.Application.Features.Mediator.Queries.UserQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtService _jwtService;

        public SignInController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(GetCheckUserQuery query)
        {
            var values = await _mediator.Send(query);

            if (values.IsExist)
            {
                return Ok(_jwtService.GenerateToken(values));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }
    }
}
