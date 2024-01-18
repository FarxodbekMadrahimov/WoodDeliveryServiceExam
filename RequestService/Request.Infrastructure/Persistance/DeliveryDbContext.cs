using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

using Request.Application.Absreactions;
using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Products;
using Request.Domain.Entitites.Request;
using Request.Domain.Entitites.Users;


namespace Request.Infrastructure.Persistance
{
    public class DeliveryDbContext : DbContext, IDeliveryDbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) 
            : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            try
            {
                if (databaseCreator is null)
                {
                    throw new Exception("Database Not Foundd!");
                }

                if (!databaseCreator.CanConnect())
                    databaseCreator.CreateAsync();

                if (!databaseCreator.HasTables())
                    databaseCreator.CreateTablesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<User> user { get ; set ; }
        public DbSet<Requesting> requests { get ; set ; }
        public DbSet<Order> order { get ; set ; }
        public DbSet<Product> products { get ; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Product entity


            // Seed data
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Product1", Price = 100 },
                new Product { ProductId = 2, ProductName = "Product2", Price = 150 },
                new Product { ProductId = 3, ProductName = "Product3", Price = 120 },
                new Product { ProductId = 4, ProductName = "Product4", Price = 80 },
                new Product { ProductId = 5, ProductName = "Product5", Price = 190 },
                new Product { ProductId = 6, ProductName = "Product6", Price = 60 },
                new Product { ProductId = 7, ProductName = "Product7", Price = 130 },
                new Product { ProductId = 8, ProductName = "Product8", Price = 170 },
                new Product { ProductId = 9, ProductName = "Product9", Price = 90 },
                new Product { ProductId = 10, ProductName = "Product10", Price = 110 },
                new Product { ProductId = 11, ProductName = "Product11", Price = 200 },
                new Product { ProductId = 12, ProductName = "Product12", Price = 75 },
                new Product { ProductId = 13, ProductName = "Product13", Price = 140},
                new Product { ProductId = 14, ProductName = "Product14", Price = 160}
            );

            base.OnModelCreating(modelBuilder);
        }






    }
}
