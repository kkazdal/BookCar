using CarBook.Application.Features.CQRS.Commands.Car;
using CarBook.Application.Features.CQRS.Handlers.Car;
using CarBook.Application.Features.CQRS.Queries.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CreateCarHandle _createCarHandler;
        private readonly GetCarByIdQueryHandle _getCarByIdQueryHandler;
        private readonly GetCarQueryHandle _getCarQueryHandler;
        private readonly UpdateCarHandle _updateCarHandle;
        private readonly RemoveCarHandle _removeCarHandle;
        private readonly GetCarListWithBrandHandle _getCarListWithBrandHandle;
        public CarController(
            CreateCarHandle createCarHandler,
            GetCarByIdQueryHandle getCarByIdQueryHandle,
            GetCarQueryHandle getCarQueryHandle,
            UpdateCarHandle updateCarHandle,
            RemoveCarHandle removeCarHandle,
            GetCarListWithBrandHandle getCarListWithBrandHandle
        )
        {
            _createCarHandler = createCarHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandle;
            _getCarQueryHandler = getCarQueryHandle;
            _updateCarHandle = updateCarHandle;
            _removeCarHandle = removeCarHandle;
            _getCarListWithBrandHandle = getCarListWithBrandHandle;
        }

        [HttpGet("GetCarList")]
        public async Task<IActionResult> GetCarList()
        {
            var response = await _getCarQueryHandler.Handle();
            return Ok(response);
        }

        [HttpGet("GetCar")]
        public async Task<IActionResult> GetCar(int id)
        {
            var response = await _getCarByIdQueryHandler.Handle(new GetCarQueryByIdQuery(id));
            return Ok(response);
        }

        [HttpGet("GetCarListWithBrands")]
        public async Task<IActionResult> GetCarListWithBrands()
        {
            var response = _getCarListWithBrandHandle.Handle();
            return Ok(response);
        }

        [HttpPost("CreateCar")]
        public async Task<IActionResult> CreateCar(CreateCarCommand createCarCommand)
        {
            await _createCarHandler.Handle(createCarCommand);
            return Ok("Kayıt başarılı");
        }

        [HttpDelete("DeleteCar")]
        public async Task<IActionResult> DeleteAbout(RemoveCarCommand removeCarCommand)
        {
            await _removeCarHandle.Handle(removeCarCommand);
            return Ok("Kayıt Silindi");
        }

        [HttpPut("UpdateCar")]
        public async Task<IActionResult> UpdateAbout(UpdateCarCommand updateCarCommands)
        {
            await _updateCarHandle.Handle(updateCarCommands);
            return Ok("Kayıt güncellendi");
        }
    }
}
