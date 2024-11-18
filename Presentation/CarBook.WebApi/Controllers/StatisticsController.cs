using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTotalCarCount")]
        public async Task<ActionResult> GetTotalCarCount()
        {
            var response = await _mediator.Send(new GetStatisticsCarCountQuery());
            return Ok(response);
        }

        [HttpGet("GetLocationCount")]
        public async Task<ActionResult> GetLocationCount()
        {
            var response = await _mediator.Send(new GetLocationCountQuery());
            return Ok(response);
        }

        [HttpGet("GetBlogCount")]
        public async Task<ActionResult> GetBlogCount()
        {
            var response = await _mediator.Send(new GetTotalBlogNumberQuery());
            return Ok(response);
        }
    }
}
