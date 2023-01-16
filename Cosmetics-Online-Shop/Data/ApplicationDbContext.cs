using Cosmetics_Online_Shop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cosmetics_Online_Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CosmeticTypes> CosmeticTypes { get; set; }
        public DbSet<SpecificClass> SpecificClass{ get; set; }
        public DbSet<Cosmetics> Cosmetics { get; set; }
    }
}