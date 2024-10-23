using CarBook.Application.Features.CQRS.Commands.Contact;
using CarBook.Application.Features.CQRS.Handlers.ContactHandler;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly CreateContactHandle _createContactHandler;
        private readonly GetContactByIdQueryHandle _getContactByIdQueryHandler;
        private readonly GetContactQueryHandle _getContactQueryHandler;
        private readonly UpdateContactHandle _updateContactHandle;
        private readonly RemoveContactHandle _removeContactHandle;


        public ContactController(
            CreateContactHandle createContactHandler,
            GetContactByIdQueryHandle getContactByIdQueryHandle,
            GetContactQueryHandle getContactQueryHandle,
            UpdateContactHandle updateContactHandle,
            RemoveContactHandle removeContactHandle
        )
        {
            _createContactHandler = createContactHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandle;
            _getContactQueryHandler = getContactQueryHandle;
            _updateContactHandle = updateContactHandle;
            _removeContactHandle = removeContactHandle;
        }

        [HttpGet("GetContactList")]
        public async Task<IActionResult> ContactList()
        {
            var response = await _getContactQueryHandler.Handle();
            return Ok(response);
        }

        [HttpGet("GetContactById")]
        public async Task<IActionResult> GetContact(int id)
        {
            var response = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(response);
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(CreateContactCommands createContactCommands)
        {
            await _createContactHandler.Handle(createContactCommands);
            return Ok("Kayıt Başarılı.");
        }

        [HttpDelete("DeleteContact")]
        public async Task<IActionResult> DeleteContact(RemoveContactCommands removeContactCommands)
        {
            await _removeContactHandle.Handle(removeContactCommands);
            return Ok("Kayıt Silindi");
        }

        [HttpPut("UpdateContact")]
        public async Task<IActionResult> UpdateContact(UpdateContactCommands updateContactCommands)
        {
            await _updateContactHandle.Handle(updateContactCommands);
            return Ok("Kayıt güncellendi");
        }

    }
}
