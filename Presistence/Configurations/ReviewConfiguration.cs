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
    internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Review");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.Comment)
                .HasMaxLength(1000)
                .HasColumnName("comment");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate).HasColumnName("review_date")
                .ValueGeneratedOnAddOrUpdate();
            entity.Property(e => e.UserId)
                .HasMaxLength(450)
                .HasColumnName("user_id");


            entity.HasOne(d => d.Prodcut).WithMany(p => p.Reviews).HasForeignKey(p => p.ProductId);
            entity.HasOne(d => d.User).WithMany().HasForeignKey(p => p.UserId);

        }
    }
}
