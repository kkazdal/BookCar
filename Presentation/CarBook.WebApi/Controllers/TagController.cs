using CarBook.Application.Features.Mediator.Commands.TagCommands;
using CarBook.Application.Features.Mediator.Queries.TagQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTagList")]
        public async Task<IActionResult> GetTagList()
        {
            var response = await _mediator.Send(new GetTagQuery());
            return Ok(response);
        }

        [HttpGet("GetTagByBlogIdList")]
        public async Task<IActionResult> GetTagByBlogIdList(int blogId)
        {
            var response = await _mediator.Send(new GetTagByBlogIdQuery(blogId));
            return Ok(response);
        }

        [HttpGet("GetTagById")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var response = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag(CreateTagCommand createTagCommand)
        {
            await _mediator.Send(createTagCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut("UpdateTag")]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand updateTagCommand)
        {
            await _mediator.Send(updateTagCommand);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete("RemoveTag")]
        public async Task<IActionResult> RemoveTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Kayıt Silindi.");
        }
    }
}
