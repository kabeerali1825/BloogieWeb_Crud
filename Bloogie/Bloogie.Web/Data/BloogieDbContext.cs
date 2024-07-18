using Bloogie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloogie.Web.Data
{
    public class BloogieDbContext : DbContext
    {
        public BloogieDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
