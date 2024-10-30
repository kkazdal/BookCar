using CarBook.Application.Features.Mediator.Commands.PriceCommands;
using CarBook.Application.Features.Mediator.Queries.PriceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPriceList")]
        public async Task<IActionResult> GetPriceList()
        {
            var response = await _mediator.Send(new GetPriceQuery());
            return Ok(response);
        }

        [HttpGet("GetPriceById")]
        public async Task<IActionResult> GetPriceById(int id)
        {
            var response = await _mediator.Send(new GetPriceByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreatePrice")]
        public async Task<IActionResult> CreatePrice(CreatePriceCommand createPriceCommand)
        {
            await _mediator.Send(createPriceCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut("UpdatePrice")]
        public async Task<IActionResult> UpdatePrice(UpdatePriceCommand updatePriceCommand)
        {
            await _mediator.Send(updatePriceCommand);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete("RemovePrice")]
        public async Task<IActionResult> RemovePrice(int id)
        {
            await _mediator.Send(new RemovePriceCommand(id));
            return Ok("Kayıt Silindi.");
        }
    }
}
