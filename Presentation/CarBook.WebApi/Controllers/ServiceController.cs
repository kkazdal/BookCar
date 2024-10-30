using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetServiceList")]
        public async Task<IActionResult> GetServiceList()
        {
            var response = await _mediator.Send(new GetServiceQuery());
            return Ok(response);
        }

        [HttpGet("GetServiceById")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var response = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceCommand createServiceCommand)
        {
            await _mediator.Send(createServiceCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand updateServiceCommand)
        {
            await _mediator.Send(updateServiceCommand);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete("RemoveService")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Kayıt Silindi.");
        }
    }
}
