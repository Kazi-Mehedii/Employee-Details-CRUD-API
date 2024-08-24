using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storing_and_retriving_Web_Api.Data;
using Storing_and_retriving_Web_Api.Model;
using Storing_and_retriving_Web_Api.Model.Domains;

namespace Storing_and_retriving_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContextDB contextDB;

        public ContactsController(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        [HttpGet]
        public IActionResult GetAllcontacts()
        {
            var contacts = contextDB.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost]
        public IActionResult AddContact(AddContactDTOs request)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Favorite = request.Favorite,
            };
            contextDB.Contacts.Add(domainModelContact);
            contextDB.SaveChanges();

            return Ok(domainModelContact);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContacts(Guid id)
        {
            var contact = contextDB.Contacts.Find(id);

            if(contact is not null)
            {
                contextDB.Contacts.Remove(contact);
                contextDB.SaveChanges();
            }

            return Ok();
        }
    }
}