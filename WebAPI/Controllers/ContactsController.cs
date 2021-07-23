using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("getAllContacts")]
        public IActionResult GetAll()
        {
            var result = _contactService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getByContactId")]
        public IActionResult GetById(int contactId)
        {
            var result = _contactService.GetById(contactId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("addContact")]
        public IActionResult Add(Contact contact)
        {
            var result = _contactService.Add(contact);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("deleteContact")]
        public IActionResult Delete(Contact contact)
        {
            var result = _contactService.Delete(contact);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("updateContact")]
        public IActionResult Update(Contact contact)
        {
            var result = _contactService.Update(contact);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}