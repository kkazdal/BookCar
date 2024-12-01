using CarBook.Application.Features.Mediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetDescriptionByCarId")]
        public async Task<IActionResult> GetDescriptionByCarId(int carId)
        {
            var response = await _mediator.Send(new GetCarDescriptionQuery(carId));
            return Ok(response);
        }
    }
}
