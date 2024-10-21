using CarBook.Application.Features.CQRS.Commands.Banner;
using CarBook.Application.Features.CQRS.Results.Banner;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly CreateBannerHandle _createBannerHandler;
        private readonly GetBannerByIdQueryHandle _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandle _getBannerQueryHandler;
        private readonly UpdateBannerHandle _updateBannerHandle;
        private readonly RemoveBannerHandle _removeBannerHandle;
        public BannerController(
            CreateBannerHandle createBannerHandler,
            GetBannerByIdQueryHandle getBannerByIdQueryHandle,
            GetBannerQueryHandle getBannerQueryHandle,
            UpdateBannerHandle updateBannerHandle,
            RemoveBannerHandle removeBannerHandle
        )
        {
            _createBannerHandler = createBannerHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandle;
            _getBannerQueryHandler = getBannerQueryHandle;
            _updateBannerHandle = updateBannerHandle;
            _removeBannerHandle = removeBannerHandle;
        }

        [HttpGet("GetBannerList")]
        public async Task<IActionResult> GetBannerList()
        {
            var response = await _getBannerQueryHandler.Handle();
            return Ok(response);
        }

        [HttpGet("GetBanner")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var response = await _getBannerByIdQueryHandler.handle(new GetBannerQueryByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand createBannerCommand)
        {
            await _createBannerHandler.Handle(createBannerCommand);
            return Ok("Kayıt başarılı");
        }

        [HttpDelete("DeleteBanner")]
        public async Task<IActionResult> DeleteAbout(RemoveBannerCommand removeBannerCommand)
        {
            await _removeBannerHandle.handle(removeBannerCommand);
            return Ok("Kayıt Silindi");
        }

        [HttpPut("UpdateBanner")]
        public async Task<IActionResult> UpdateAbout(UpdateBannerCommand updateBannerCommands)
        {
            await _updateBannerHandle.handle(updateBannerCommands);
            return Ok("Kayıt güncellendi");
        }

    }
}
