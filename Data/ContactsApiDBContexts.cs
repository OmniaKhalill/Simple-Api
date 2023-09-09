using SimpleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi.Data
{
    public class ContactsApiDBContexts : DbContext
    {
        public ContactsApiDBContexts(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        
        
    }
}