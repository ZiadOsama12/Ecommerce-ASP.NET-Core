using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasKey(e => e.PId).HasName("PK__Payment__82E06B91C1DFF687");

            entity.ToTable("Payment");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("p_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Method)
                .HasMaxLength(50)
                .HasColumnName("method");
            entity.Property(e => e.UId)
                .HasMaxLength(450)
                .HasColumnName("u_id");
        }
    }
}
