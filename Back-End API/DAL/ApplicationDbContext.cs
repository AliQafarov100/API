using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_End_API.Configurations.ProductConfigurations;
using Back_End_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End_API.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCofiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
