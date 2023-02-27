using Microsoft.EntityFrameworkCore;
using SimpleMVCProject.Models;

namespace SimpleMVCProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
