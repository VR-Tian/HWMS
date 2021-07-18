using System;
using HWMS.DoMain.Models.Access;
using Microsoft.EntityFrameworkCore;

namespace HWMS.Infrastructure.Mappings.OracleMapping
{
    public class NavigationMenuMap : IEntityTypeConfiguration<NavigationMenu>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<NavigationMenu> builder)
        {
            builder.Property(p => p.ActionName).HasMaxLength(1000);
        }
    }
}