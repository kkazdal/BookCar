using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTestimonialList")]
        public async Task<IActionResult> GetTestimonialList()
        {
            var response = await _mediator.Send(new GetTestimonialQuery());
            return Ok(response);
        }

        [HttpGet("GetTestimonialById")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var response = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand createTestimonialCommand)
        {
            await _mediator.Send(createTestimonialCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut("UpdateTestimonial")]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand updateTestimonialCommand)
        {
            await _mediator.Send(updateTestimonialCommand);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete("RemoveTestimonial")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Kayıt Silindi.");
        }
    }
}
