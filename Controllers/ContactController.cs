using dotnet5app.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet5app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private List<Contact> contacts = new List<Contact>
        {
            new Contact { Id = 1, FirstName = "Fifi", LastName = "Aleyda", Place = "Serang" },
            new Contact { Id = 2, FirstName = "Fitri", LastName = "Astuti", Place = "Karawaci"},
            new Contact { Id = 3, FirstName = "Xylona", LastName = "Adyara", Place = "Karawaci"}
        };

        // GET: api/<ContactController>
        [HttpGet]
        public ActionResult<List<Contact>> Get()
        {
            return Ok(contacts);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            Contact singleContact = contacts.FirstOrDefault(Q => Q.Id == id);
            if (singleContact == null)
            {
                return NotFound(new { Message = "Contact Has Not Found" } );
            }

            return Ok(singleContact);
        }

        // POST api/<ContactController>
        [HttpPost]
        public ActionResult<Contact> Post([FromBody] Contact value)
        {
            contacts.Add(value);
            return Ok(contacts);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public ActionResult<Contact> Put(int id, [FromBody] Contact value)
        {
            Contact contact = contacts.FirstOrDefault(Q => Q.Id == id);

            if(contact == null)
            {
                return NotFound();
            }

            contact.NickName = value.NickName;
            contact.IsDeleted = value.IsDeleted;

            return Ok(contact);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public ActionResult<Contact> Delete(int id)
        {
            Contact contact = contacts.FirstOrDefault(Q => Q.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            contacts.Remove(contact);

            return Ok(contacts);
        }
    }
}
