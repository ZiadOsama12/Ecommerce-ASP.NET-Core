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
            entity.HasKey(e => e.RId).HasName("PK__Review__C4762327E7C86255");

            entity.ToTable("Review");

            entity.Property(e => e.RId)
                .ValueGeneratedNever()
                .HasColumnName("r_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(1000)
                .HasColumnName("comment");
            entity.Property(e => e.PId).HasColumnName("p_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate).HasColumnName("review_date");
            entity.Property(e => e.UId)
                .HasMaxLength(450)
                .HasColumnName("u_id");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PId)
                .HasConstraintName("FK__Review__p_id__66603565");
        }
    }
}
