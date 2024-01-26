using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wood.Infrastructure.Persistance.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Request.Domain.Entitites.deliver;
    using Request.Domain.Entitites.Products;
    using Request.Domain.Entitites.Request;
    using Request.Domain.Entitites.Users;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.UserName);
            builder.Property(u => u.Password);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.PhoneNumber);
            builder.Property(u => u.Address);
            builder.Property(u => u.ProductId);

            builder.HasOne(u => u.Product);
 

            builder.HasMany(u => u.Orders)
                   .WithOne(o => o.User)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class RequestingConfiguration : IEntityTypeConfiguration<Requesting>
    {
        public void Configure(EntityTypeBuilder<Requesting> builder)
        {
            builder.HasKey(r => r.RequestId);

            builder.Property(r => r.FirstName).IsRequired();
            builder.Property(r => r.LastName).IsRequired();
            builder.Property(r => r.Email).IsRequired();
            builder.Property(r => r.PhoneNumber);
            builder.Property(r => r.Message);
        }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price);
            builder.Property(p => p.UserId);

            builder.HasOne(p => p.User);





            builder.HasMany(p => p.Orders)
                   .WithOne(o => o.Product)
                   .HasForeignKey(o => o.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.UserId);
            builder.Property(o => o.ProductId);

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Product)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(o => o.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
