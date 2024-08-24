using Microsoft.EntityFrameworkCore;
using Storing_and_retriving_Web_Api.Model.Domains;

namespace Storing_and_retriving_Web_Api.Data
{
    public class ContextDB:DbContext
    {
        public ContextDB(DbContextOptions options):base(options)
        {
             
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
