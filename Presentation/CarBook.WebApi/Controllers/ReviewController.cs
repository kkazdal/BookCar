using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Review : ControllerBase
    {
        private readonly IMediator mediator;

        public Review(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetReviewByCarIdList")]
        public async Task<IActionResult> GetReviewByCarIdList(int carId)
        {
            var response = mediator.Send(new GetReviewByCarIdQuery(carId));
            return Ok(response);
        }
    }
}
