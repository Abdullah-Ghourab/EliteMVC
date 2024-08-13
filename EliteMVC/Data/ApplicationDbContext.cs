using EliteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EliteMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public DbSet<BillItem> BillItems { get; set; }
   
    }


}

