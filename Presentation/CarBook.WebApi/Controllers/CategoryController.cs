using CarBook.Application.Features.CQRS.Commands.Category;
using CarBook.Application.Features.CQRS.Handlers.Category;
using CarBook.Application.Features.CQRS.Queries.Category;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategoryHandle _createCategoryHandler;
        private readonly GetCategoryByIdQueryHandle _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandle _getCategoryQueryHandler;
        private readonly UpdateCategoryHandle _updateCategoryHandle;
        private readonly RemoveCategoryHandle _removeCategoryHandle;
        private readonly GetCategoryByBlogNumberHandler _getCategoryByBlogNumberHandler;
        public CategoryController(
            CreateCategoryHandle createCategoryHandler,
            GetCategoryByIdQueryHandle getCategoryByIdQueryHandle,
            GetCategoryQueryHandle getCategoryQueryHandle,
            UpdateCategoryHandle updateCategoryHandle,
            RemoveCategoryHandle removeCategoryHandle,
            GetCategoryByBlogNumberHandler getCategoryByBlogNumberHandler
        )
        {
            _createCategoryHandler = createCategoryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandle;
            _getCategoryQueryHandler = getCategoryQueryHandle;
            _updateCategoryHandle = updateCategoryHandle;
            _removeCategoryHandle = removeCategoryHandle;
            _getCategoryByBlogNumberHandler = getCategoryByBlogNumberHandler;
        }

        [HttpGet("GetCategoryByBlogNumberList")]
        public async Task<IActionResult> GetCategoryByBlogNumberList()
        {
            var response = await _getCategoryByBlogNumberHandler.Handle();
            return Ok(response);
        }

        [HttpGet("GetCategoryList")]
        public async Task<IActionResult> GetCategoryList()
        {
            var response = await _getCategoryQueryHandler.Handle();
            return Ok(response);
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response = await _getCategoryByIdQueryHandler.handle(new GetCategoryQueryByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _createCategoryHandler.Handle(createCategoryCommand);
            return Ok("Kayıt başarılı");
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteAbout(RemoveCategoryCommand removeCategoryCommand)
        {
            await _removeCategoryHandle.handle(removeCategoryCommand);
            return Ok("Kayıt Silindi");
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateAbout(UpdateCategoryCommand updateCategoryCommands)
        {
            await _updateCategoryHandle.handle(updateCategoryCommands);
            return Ok("Kayıt güncellendi");
        }

    }
}
