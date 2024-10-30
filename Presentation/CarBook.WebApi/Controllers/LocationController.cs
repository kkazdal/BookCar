using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetLocationList")]
        public async Task<IActionResult> GetLocationList()
        {
            var response = await _mediator.Send(new GetLocationQuery());
            return Ok(response);
        }

        [HttpGet("GetLocationById")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var response = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand createLocationCommand)
        {
            await _mediator.Send(createLocationCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand updateLocationCommand)
        {
            await _mediator.Send(updateLocationCommand);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete("RemoveLocation")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Kayıt Silindi.");
        }
    }
}
