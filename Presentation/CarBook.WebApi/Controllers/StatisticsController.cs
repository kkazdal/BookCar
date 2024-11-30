using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTotalCarCount")]
        public async Task<ActionResult> GetTotalCarCount()
        {
            var response = await _mediator.Send(new GetStatisticsCarCountQuery());
            return Ok(response);
        }

        [HttpGet("GetLocationCount")]
        public async Task<ActionResult> GetLocationCount()
        {
            var response = await _mediator.Send(new GetLocationCountQuery());
            return Ok(response);
        }

        [HttpGet("GetBlogCount")]
        public async Task<ActionResult> GetBlogCount()
        {
            var response = await _mediator.Send(new GetTotalBlogNumberQuery());
            return Ok(response);
        }

        [HttpGet("GetBlogTitleByMaxComment")]
        public async Task<ActionResult> GetBlogTitleByMaxComment()
        {
            var response = await _mediator.Send(new GetBlogTitleByMaxCommentQuery());
            return Ok(response);
        }

        [HttpGet("BrandNameByMaxCar")]
        public async Task<ActionResult> BrandNameByMaxCar()
        {
            var response = await _mediator.Send(new BrandNameByMaxCarQuery());
            return Ok(response);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<ActionResult> GetAuthorCount()
        {
            var response = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(response);
        }

        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<ActionResult> GetAvgRentPriceForDaily()
        {
            var response = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(response);
        }

        [HttpGet("GetAvgRentPriceForMontly")]
        public async Task<ActionResult> GetAvgRentPriceForMontly()
        {
            var response = await _mediator.Send(new GetAvgRentPriceForMontlyQuery());
            return Ok(response);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<ActionResult> GetAvgRentPriceForWeekly()
        {
            var response = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(response);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<ActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var response = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(response);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<ActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var response = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(response);
        }


        [HttpGet("GetCarCountByKmSmallerThan1000")]
        public async Task<ActionResult> GetCarCountByKmSmallerThan1000()
        {
            var response = await _mediator.Send(new GetCarCountByKmSmallerThan1000Query());
            return Ok(response);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<ActionResult> GetCarCountByFuelElectric()
        {
            var response = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(response);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<ActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var response = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(response);
        }

        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public async Task<ActionResult> GetCarCountByTransmissionIsAuto()
        {
            var response = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(response);
        }

        [HttpGet("GetNumberOfRentalByYear")]
        public async Task<ActionResult> GetNumberOfRentalByYear()
        {
            var response = await _mediator.Send(new NumberOfRentalByYearQuery());
            return Ok(response);
        }

        [HttpGet("GetNumberOfVehiclesByCar")]
        public async Task<ActionResult> GetNumberOfVehiclesByCar()
        {
            var response = await _mediator.Send(new NumberOfVehiclesByCarQuery());
            return Ok(response);
        }

    }
}
