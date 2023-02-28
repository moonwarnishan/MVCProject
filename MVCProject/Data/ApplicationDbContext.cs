using Microsoft.EntityFrameworkCore;
using MVCProject.Domains;

namespace SimpleMVCProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonsInfoLanguages> PersonInfoInDifferentLanguage { get; set; }
    }
}
