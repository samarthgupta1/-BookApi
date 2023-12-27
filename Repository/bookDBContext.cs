using bookapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;




namespace bookapi.Repository
{
    public class bookDBContext : DbContext
    {
        public bookDBContext()
        {

        }

        public bookDBContext(DbContextOptions<bookDBContext> options) : base(options)
        {

        }
        public DbSet<book> Books { get; set; }
    }
}
