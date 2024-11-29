using CarBook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatures;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarFeaturesByCarId")]
        public async Task<IActionResult> GetCarFeaturesByCarId(int carId)
        {
            var response = await _mediator.Send(new GetCarFeaturesByCarIdQuery(carId));

            return Ok(response);
        }

        [HttpGet("ChangeCarFeatureAvailableToFalse")]
        public async Task<IActionResult> ChangeCarFeatureAvailableToFalse(int id)
        {
            _mediator.Send(new ChangeCarFeatureAvailableToFalseCommand(id));

            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("ChangeCarFeatureAvailableToTrue")]
        public async Task<IActionResult> ChangeCarFeatureAvailableToTrue(int id)
        {
            _mediator.Send(new ChangeCarFeatureAvailableToTrueCommand(id));

            return Ok("Güncelleme Başarılı");
        }

        [HttpPost("CreateCarFeatureByCar")]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
        {
            _mediator.Send(command);
            return Ok("Ekleme Yapıldı");
        }
    }
}
