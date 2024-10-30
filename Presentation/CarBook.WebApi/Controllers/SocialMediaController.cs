using CarBook.Application.Features.Mediator.Commands.SocialMedia;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSocialMediaList")]
        public async Task<IActionResult> GetSocialMediaList()
        {
            var response = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(response);
        }

        [HttpGet("GetSocialMediaById")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var response = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand createSocialMediaCommand)
        {
            await _mediator.Send(createSocialMediaCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut("UpdateSocialMedia")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            await _mediator.Send(updateSocialMediaCommand);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete("RemoveSocialMedia")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("Kayıt Silindi.");
        }
    }
}
