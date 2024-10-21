using CarBook.Application.Features.CQRS.Commands.About;
using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly CreateAboutHandle _createAboutHandler;
        private readonly GetAboutByIdQueryHandle _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandle _getAboutQueryHandler;
        private readonly UpdateAboutHandle _updateAboutHandle;
        private readonly RemoveAboutHandle _removeAboutHandle;


        public AboutController(
            CreateAboutHandle createAboutHandler,
            GetAboutByIdQueryHandle getAboutByIdQueryHandle,
            GetAboutQueryHandle getAboutQueryHandle,
            UpdateAboutHandle updateAboutHandle,
            RemoveAboutHandle removeAboutHandle
        )
        {
            _createAboutHandler = createAboutHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandle;
            _getAboutQueryHandler = getAboutQueryHandle;
            _updateAboutHandle = updateAboutHandle;
            _removeAboutHandle = removeAboutHandle;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var response = await _getAboutQueryHandler.Handle();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var response = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommands createAboutCommands)
        {
            await _createAboutHandler.Handle(createAboutCommands);
            return Ok("Hakkımda Bilgisi Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(RemoveAboutCommands removeAboutCommands)
        {
            await _removeAboutHandle.Handle(removeAboutCommands);
            return Ok("Hakkımda Bilgisi Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommands updateAboutCommands)
        {
            await _updateAboutHandle.Handle(updateAboutCommands);
            return Ok("Hakkımda bilgisi güncellendi");
        }

    }
}
