
using CRUDusingEF.Data;
using CRUDusingEF.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDusingEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
