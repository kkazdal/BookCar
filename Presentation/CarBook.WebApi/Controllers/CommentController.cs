using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _genericRepository;
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator, IGenericRepository<Comment> genericRepository)
        {
            _genericRepository = genericRepository;
            _mediator = mediator;
        }
        [HttpPost("CreateMediatorComment")]
        public async Task<IActionResult> CreateMediatorComment(CreateCommand createCommand)
        {
            await _mediator.Send(createCommand);
            return Ok("Kayıt başarılı.");
        }

        [HttpGet("GetMediatorCommentsListByBlogId")]
        public IActionResult GetMediatorCommentsListByBlogId(int BlogId)
        {
            var response = _mediator.Send(new CommentListQuery(BlogId));
            return Ok(response);
        }

        [HttpGet("GetCommentsListByBlogId")]
        public IActionResult GetCommentsListByBlogId(int id)
        {
            var response = _genericRepository.GetCommentsByBlogId(id);
            return Ok(response);
        }

        [HttpGet("CommentList")]
        public async Task<IActionResult> CommentList()
        {
            var response = await _genericRepository.GetAll();
            return Ok(response);
        }

        [HttpGet("GetCommentById")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var response = await _genericRepository.GetById(id);
            return Ok(response);
        }

        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            await _genericRepository.Update(comment);
            return Ok("Güncelleme başarılı.");
        }

        [HttpDelete("RemoveComment")]
        public async Task<IActionResult> RemoveComment(int commentId)
        {
            var comment = await _genericRepository.GetById(commentId);
            await _genericRepository.Remove(comment);
            return Ok("Silme başarılı.");
        }
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            await _genericRepository.Create(comment);
            return Ok("Kayıt başarılı.");
        }
    }
}
