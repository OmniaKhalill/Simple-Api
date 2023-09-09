
using SimpleApi.Data;
using SimpleApi.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsApiDBContexts dbContexts;
        public ContactsController (ContactsApiDBContexts dBContexts)
        {
            this.dbContexts = dBContexts;
        }



        [ HttpGet]
      public IEnumerable<Contact> GetContacts()
      {
        return dbContexts.Contacts.ToList();

      }  



      [ HttpGet]
       [Route("{id:guid}")]
      public IActionResult GetContact([FromRoute]Guid id)
      {
         var contact = dbContexts.Contacts.Find(id);
          if (contact != null)

          return Ok(contact);
          

          else return Ok(NotFound());
      }  



        [HttpPost]

        public  IActionResult AddContact(AddContactRequest addContactRequest ){

          var contact = new Contact(){

            Id = Guid.NewGuid(),
            FullName = addContactRequest.FullName,
            Email= addContactRequest.Email,
            Address = addContactRequest.Address,
            Phone = addContactRequest.Phone 
              };


              dbContexts.Contacts.Add(contact);
              dbContexts.SaveChanges();
              return Ok(contact);
        }



          [HttpPut]
          [Route("{id:guid}")]

        public  IActionResult UpdateContact([FromRoute] Guid id  ,UpdateContactRequest updateContactRequest ){

         var contact = dbContexts.Contacts.Find(id);

          if (contact != null){
            
              contact.FullName = updateContactRequest.FullName;
              contact.Email= updateContactRequest.Email;
              contact.Address = updateContactRequest.Address;
              contact.Phone = updateContactRequest.Phone ;

              dbContexts.SaveChanges();
              return Ok(contact);
            }

            else return NotFound();
            
        }


      [HttpDelete]
       [Route("{id:guid}")]
      public void DeleteContact([FromRoute]Guid id)
      {
        var contact = dbContexts.Contacts.Find(id);
        if (contact != null)
{
          dbContexts.Contacts.Remove(contact);
          dbContexts.SaveChanges();
      }
          else  Ok(NotFound());
      }  



    }
}