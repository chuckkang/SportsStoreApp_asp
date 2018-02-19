using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SportsStoreApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        //the database context class is the bridge between the app and the EF Core and provides access to the application
        // data using model objects.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        // this will [provide access to the product objwects in the database.
        public DbSet<Product> Products { get; set; }
        
    }
}
