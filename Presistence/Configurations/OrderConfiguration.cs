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
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(e => e.OrderNo).HasName("PK__Order__465C81B94A45992A");

            entity.ToTable("Order");

            entity.Property(e => e.OrderNo)
                .ValueGeneratedNever()
                .HasColumnName("order_no");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.UId)
                .HasMaxLength(450)
                .HasColumnName("u_id");

            entity.HasMany(d => d.PIds).WithMany(p => p.OrderNos)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__OrderProdu__p_id__5AEE82B9"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderNo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__OrderProd__order__59FA5E80"),
                    j =>
                    {
                        j.HasKey("OrderNo", "PId").HasName("PK__OrderPro__4E728700990B8282");
                        j.ToTable("OrderProduct");
                        j.IndexerProperty<int>("OrderNo").HasColumnName("order_no");
                        j.IndexerProperty<int>("PId").HasColumnName("p_id");
                    });
        }
    }
}
