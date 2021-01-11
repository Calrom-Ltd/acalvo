using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.UserClasses
{
    public class UserDbContext : DbContext
    {
        //Contractor to access the base class
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {


        }
        //it will be a table into SqlServer into the database (UserDb)
        public DbSet<UserClass> Users { get; set; }
    }
}
