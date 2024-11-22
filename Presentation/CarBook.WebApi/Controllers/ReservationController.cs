using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateReservation")]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand createReservationCommand)
        {
            await _mediator.Send(createReservationCommand);
            return Ok("Kayıt Başarılı");
        }
    }
}
