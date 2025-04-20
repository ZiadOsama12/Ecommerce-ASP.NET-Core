using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            
                entity.HasKey(e => e.AId).HasName("PK__Address__566AFA9A44DCAFB0");

                entity.ToTable("Address");

                entity.Property(e => e.AId)
                    .ValueGeneratedNever()
                    .HasColumnName("a_id");
                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");
                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country");
                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .HasColumnName("state");
                entity.Property(e => e.UId)
                    .HasMaxLength(450)
                    .HasColumnName("u_id");
        }
    }
}
