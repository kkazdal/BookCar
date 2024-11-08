using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAuthorList")]
        public async Task<IActionResult> GetAuthorList()
        {
            var response = await _mediator.Send(new GetAuthorQuery());
            return Ok(response);
        }

        [HttpGet("GetAuthorById")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var response = await _mediator.Send(new GetAuthorQueryById(id));
            return Ok(response);
        }

        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorCommand createAuthorCommand)
        {
            await _mediator.Send(createAuthorCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand updateAuthorCommand)
        {
            await _mediator.Send(updateAuthorCommand);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete("RemoveAuthor")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Kayıt Silindi.");
        }
    }
}
