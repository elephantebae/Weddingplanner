using Microsoft.EntityFrameworkCore;

namespace weddingplanner.Models
{
    public class WeddingContext :DbContext
    {
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) { }

        public DbSet<User> Users {get;set;}
        public DbSet<Wedding> weddings {get;set;}
        public DbSet<Rsvp> Rsvping {get;set;}
    }
}