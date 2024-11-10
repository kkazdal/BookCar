using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetBlogsWithAuthorList")]
        public async Task<IActionResult> GetBlogsWithAuthorList()
        {
            var response = await _mediator.Send(new GetBlogsWithAuthorQuery());
            return Ok(response);
        }

        [HttpGet("GetLastBlogsByNumber")]
        public async Task<IActionResult> GetLastBlogsByNumber(int blogNumber)
        {
            var response = await _mediator.Send(new GetLastBlogsQueryByNumber(blogNumber));
            return Ok(response);
        }

        [HttpGet("GetBlogList")]
        public async Task<IActionResult> GetBlogList()
        {
            var response = await _mediator.Send(new GetBlogQuery());
            return Ok(response);
        }

        [HttpGet("GetBlogById")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var response = await _mediator.Send(new GetBlogQueryById(id));
            return Ok(response);
        }

        [HttpPost("CreateBlog")]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand createBlogCommand)
        {
            await _mediator.Send(createBlogCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpPut("UpdateBlog")]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand updateBlogCommand)
        {
            await _mediator.Send(updateBlogCommand);
            return Ok("Kayıt Güncellendi.");
        }

        [HttpDelete("RemoveBlog")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Kayıt Silindi.");
        }
    }
}
