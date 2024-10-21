using CarBook.Application.Features.CQRS.Commands.Brand;
using CarBook.Application.Features.CQRS.Results.Brand;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly CreateBrandHandle _createBrandHandler;
        private readonly GetBrandByIdQueryHandle _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandle _getBrandQueryHandler;
        private readonly UpdateBrandHandle _updateBrandHandle;
        private readonly RemoveBrandHandle _removeBrandHandle;
        public BrandController(
            CreateBrandHandle createBrandHandler,
            GetBrandByIdQueryHandle getBrandByIdQueryHandle,
            GetBrandQueryHandle getBrandQueryHandle,
            UpdateBrandHandle updateBrandHandle,
            RemoveBrandHandle removeBrandHandle
        )
        {
            _createBrandHandler = createBrandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandle;
            _getBrandQueryHandler = getBrandQueryHandle;
            _updateBrandHandle = updateBrandHandle;
            _removeBrandHandle = removeBrandHandle;
        }

        [HttpGet("GetBrandList")]
        public async Task<IActionResult> GetBrandList()
        {
            var response = await _getBrandQueryHandler.Handle();
            return Ok(response);
        }

        [HttpGet("GetBrand")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var response = await _getBrandByIdQueryHandler.handle(new GetBrandQueryByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand createBrandCommand)
        {
            await _createBrandHandler.Handle(createBrandCommand);
            return Ok("Kayıt başarılı");
        }

        [HttpDelete("DeleteBrand")]
        public async Task<IActionResult> DeleteAbout(RemoveBrandCommand removeBrandCommand)
        {
            await _removeBrandHandle.handle(removeBrandCommand);
            return Ok("Kayıt Silindi");
        }

        [HttpPut("UpdateBrand")]
        public async Task<IActionResult> UpdateAbout(UpdateBrandCommand updateBrandCommands)
        {
            await _updateBrandHandle.handle(updateBrandCommands);
            return Ok("Kayıt güncellendi");
        }
    }
}
