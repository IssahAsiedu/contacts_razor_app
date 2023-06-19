using ContactsBook.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsBook.Database
{
    public class ContactDbContext: DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
