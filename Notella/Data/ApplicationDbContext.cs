using Notella.Models;
using Microsoft.EntityFrameworkCore;

namespace Notella.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Notes> Notes { get; set; }
    }
}
