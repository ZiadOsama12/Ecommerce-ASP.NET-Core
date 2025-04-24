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
            entity.HasKey(e => e.OrderNo);

            entity.ToTable("Order");

            entity.Property(e => e.OrderNo)
                .ValueGeneratedOnAdd()
                .HasColumnName("order_no");

            entity.Property(e => e.TotalPrice)
                .HasColumnName("total_price")
                .HasPrecision(18, 2); // total 18 digits, 2 after decimal

            entity.Property(e => e.OrderDate).HasColumnName("order_date")
                .ValueGeneratedOnAddOrUpdate(); 
                //.HasDefaultValue();

            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");

            entity.HasOne(o => o.User).WithMany().HasForeignKey(o => o.UserId);

            entity.HasMany(o => o.Products).WithMany(p => p.Orders)
                .UsingEntity<OrderProduct>(
                    l => l.HasOne(op => op.Product).WithMany(p => p.OrderProducts).HasForeignKey(op => op.ProductId),
                    r => r.HasOne(op => op.Order).WithMany(o => o.OrderProducts).HasForeignKey(op => op.OrderId),
                    j =>
                    {
                        j.HasKey(e => new { e.OrderId, e.ProductId }); 
                        j.ToTable("OrderProduct");
                        j.Property(e => e.OrderId).HasColumnName("order_no");
                        j.Property(e => e.ProductId).HasColumnName("product_id");
                        j.Property(e => e.Amount).HasColumnName("amount");
                        j.Property(e => e.UnitPrice)
                            .HasColumnName("unit_price")
                            .HasPrecision(18, 2); // total 18 digits, 2 after decimal
                        
                    }


                );

            //entity.HasMany(d => d.Products).WithMany(p => p.OrderNos)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "OrderProduct",
            //        r => r.HasOne<Product>().WithMany()
            //            .HasForeignKey("PId")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("FK__OrderProdu__p_id__5AEE82B9"),
            //        l => l.HasOne<Order>().WithMany()
            //            .HasForeignKey("OrderNo")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("FK__OrderProd__order__59FA5E80"),
            //        j =>
            //        {
            //            j.HasKey("OrderNo", "PId").HasName("PK__OrderPro__4E728700990B8282");
            //            j.ToTable("OrderProduct");
            //            j.IndexerProperty<int>("OrderNo").HasColumnName("order_no");
            //            j.IndexerProperty<int>("PId").HasColumnName("p_id");
            //        });
        }
    }
}
