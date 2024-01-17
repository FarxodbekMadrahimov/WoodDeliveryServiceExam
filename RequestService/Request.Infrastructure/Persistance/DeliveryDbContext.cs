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
        public DbSet<Requests> requests { get ; set ; }
        public DbSet<Order> order { get ; set ; }
        public DbSet<Product> products { get ; set ; }


    }
}
