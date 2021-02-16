using Microsoft.EntityFrameworkCore;

namespace User_API.UserClasses
{
    public class UserContext : DbContext
    {
        //Constructor to build and access to base class
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        //Creating the tables into the database (UserDb)
        public DbSet<Users> Users { get; set; }

        public DbSet<Messages> Messages { get; set; }

    }
}
