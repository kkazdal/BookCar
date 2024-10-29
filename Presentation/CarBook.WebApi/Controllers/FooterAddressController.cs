using CarBook.Application.Features.Mediator.Commands.FooterAddress;
using CarBook.Application.Features.Mediator.Queries.FooterAddress;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetFooterAddressList")]
        public async Task<IActionResult> GetFooterAddressList()
        {
            var response = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(response);
        }

        [HttpGet("GetFooterAddress")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var response = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand createFooterAddressCommand)
        {
            await _mediator.Send(createFooterAddressCommand);
            return Ok("Kayıt Başarılı");
        }

        [HttpDelete("RemoveFooterAddress")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Başarıyla Silindi");
        }

        [HttpPut("UpdateFooterAddress")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand updateFooterAddressCommand)
        {
            await _mediator.Send(updateFooterAddressCommand);
            return Ok("Başarıyla güncellendi");
        }
    }
}
