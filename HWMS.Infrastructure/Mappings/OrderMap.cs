using System;
using HWMS.DoMain.Models;
using Microsoft.EntityFrameworkCore;

namespace HWMS.Infrastructure.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(c => c.OrderNumber)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.OrderDate)
            .HasColumnType("Datetime")
            .IsRequired();

            builder.OwnsOne(s => s.Address, ar =>
            {
                ar.Property(s => s.Province)
                   .HasColumnName("Province")
                   .HasColumnType("varchar(50)");
                ar.Property(s => s.City)
                    .HasColumnName("City")
                    .HasColumnType("varchar(50)");
                ar.Property(s => s.County)
                    .HasColumnName("County")
                    .HasColumnType("varchar(50)");
                ar.Property(s => s.Street)
                    .HasColumnName("Street")
                    .HasColumnType("varchar(50)");
            });

        }
    }
}