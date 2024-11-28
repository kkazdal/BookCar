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
    }
}