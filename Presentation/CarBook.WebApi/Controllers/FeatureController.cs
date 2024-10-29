
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("FeatureList")]
        public async Task<IActionResult> FeatureList()
        {
            var response = await _mediator.Send(new GetFeaturesQuery());
            return Ok(response);
        }

        [HttpGet("GetFeature")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var response = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand createFeatureCommand)
        {
            await _mediator.Send(createFeatureCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpDelete("RemoveFeature")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Başarıyla Silindi");
        }

        [HttpPut("UpdateFeature")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand updateFeatureCommand)
        {
            await _mediator.Send(updateFeatureCommand);
            return Ok("Başarıyla güncellendi");
        }
    }
}
