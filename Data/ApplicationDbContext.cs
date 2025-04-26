using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Entities;
using System.Collections.Generic;

namespace ProductStore.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}