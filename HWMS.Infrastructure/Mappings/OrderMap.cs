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

        }
    }
}