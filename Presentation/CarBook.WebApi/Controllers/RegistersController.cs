using CarBook.Application.Features.Mediator.Commands.RegisterCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateRegisterCommand createRegisterCommand)
        {
            await _mediator.Send(createRegisterCommand);
            return Ok("Başarılı ile oluşturuldu");
        }
    }
}
