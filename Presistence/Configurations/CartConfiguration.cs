using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> entity)
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__2EF52A27D475683F");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId)
                .ValueGeneratedNever()
                .HasColumnName("cart_id");
            entity.Property(e => e.UId)
                .HasMaxLength(450)
                .HasColumnName("u_id");

            entity.HasMany(d => d.PIds).WithMany(p => p.Carts)
                .UsingEntity<Dictionary<string, object>>(
                    "CartProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CartProduc__p_id__619B8048"),
                    l => l.HasOne<Cart>().WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CartProdu__cart___60A75C0F"),
                    j =>
                    {
                        j.HasKey("CartId", "PId").HasName("PK__CartProd__26DB2C9E9FB5CE74");
                        j.ToTable("CartProduct");
                        j.IndexerProperty<int>("CartId").HasColumnName("cart_id");
                        j.IndexerProperty<int>("PId").HasColumnName("p_id");
                    });
        }
    }
}
