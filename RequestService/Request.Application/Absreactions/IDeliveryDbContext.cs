using Microsoft.EntityFrameworkCore;
using Request.Domain.Entitites.deliver;
using Request.Domain.Entitites.Products;
using Request.Domain.Entitites.Request;
using Request.Domain.Entitites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request.Application.Absreactions
{
    public interface IDeliveryDbContext
    {
        public DbSet<User> user { get; set; }
        public DbSet<Requesting> requests { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Product> products { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
