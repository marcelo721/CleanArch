using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Description).HasMaxLength(500);

            builder.HasData(
                new Product {
                    Id = 1, Name = "Product 1",
                    Price = 10.00m, 
                    Description = "Description for Product 1" },
                new Product {
                    Id = 2, Name = "Product 2", 
                    Price = 20.00m, 
                    Description = "Description for Product 2" },

                new Product {
                    Id = 3, Name = "Product 3",
                    Price = 30.00m, 
                    Description = "Description for Product 3" }
            );
        }
    }
}
