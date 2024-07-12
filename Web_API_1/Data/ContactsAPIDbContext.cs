using Microsoft.EntityFrameworkCore;
using Web_API_1.Models;

namespace Web_API_1.Data
{
    // Peform as a layer to talk with DB
    //Inherit from base DbContext class
    public class ContactsAPIDbContext : DbContext
    {
        // options are being passed to the base class
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> ContactsDb { get; set; }
    }
}
