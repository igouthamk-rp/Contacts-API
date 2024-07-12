using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_1.Data;
using Web_API_1.Models;

namespace Web_API_1.Controllers
{
    //Telling this is an API Controller
    [ApiController]
    //Route of the controller
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;

        //Inject DbContext - with Constructer
        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Getting the resources
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            // IActionResult should contain some respose as it a REST API, so we are passing result with OK status
            return Ok(await dbContext.ContactsDb.ToListAsync());
        }

        //Getting Single Contact
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            var contact = await dbContext.ContactsDb.FindAsync(id);
            if (contact != null)
            {
                return Ok(contact);
            }

            return NotFound("ID not Found");
        }

        //Posting, adding some thing
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactModel addContactRequest)
        {
            // Creating an Add Instance to save in DB, from the request 
            var Contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = addContactRequest.FullName,
                Email = addContactRequest.Email,
                Address = addContactRequest.Address,
                PhoneNumber = addContactRequest.PhoneNumber,
                Age = addContactRequest.Age,
                Gender = addContactRequest.Gender,
                College = addContactRequest.College
            };
            // Adding to DB
            await dbContext.ContactsDb.AddAsync(Contact);
            await dbContext.SaveChangesAsync();
            return Ok(Contact);
        }

        //Updating the Data
        [HttpPut]
        // Fetching ID from Route
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromRoute] Guid id, UpdateContactModel updateContactRequest)
        {
            var contact = await dbContext.ContactsDb.FindAsync(id);

            if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Email = updateContactRequest.Email;
                contact.Address = updateContactRequest.Address;
                contact.PhoneNumber = updateContactRequest.PhoneNumber;
                contact.Age = updateContactRequest.Age;
                contact.Gender = updateContactRequest.Gender;
                contact.College = updateContactRequest.College;

                await dbContext.SaveChangesAsync();
                return Ok(contact);
            }

            return NotFound("ID you entered in Not Found");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await dbContext.ContactsDb.FindAsync(id);
            if (contact != null)
            {
                dbContext.ContactsDb.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok("Deleted Successfully");
            }

            return NotFound("ID not Found");
        }

        [HttpGet]
        [Route("{FullName}")]
        public async Task<IActionResult> GetContactByName([FromRoute] string FullName)
        {
            var contact = await dbContext.ContactsDb.FirstOrDefaultAsync(x => x.FullName.Equals(FullName));
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound("Name not found");
        }
    }
}
