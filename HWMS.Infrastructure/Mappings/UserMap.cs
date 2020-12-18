using System;
using HWMS.DoMain.Models.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HWMS.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id);

            builder.Property(c => c.UserName)
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(c => c.Passwork)
                            .HasMaxLength(100)
                            .IsRequired();
        }
    }

}