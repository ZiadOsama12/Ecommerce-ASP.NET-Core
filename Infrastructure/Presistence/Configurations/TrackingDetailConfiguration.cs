//using Api.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Presistence.Configurations
//{
//    internal class TrackingDetailConfiguration : IEntityTypeConfiguration<TrackingDetail>
//    {
//        public void Configure(EntityTypeBuilder<TrackingDetail> entity)
//        {
//            entity.HasKey(e => e.TId).HasName("PK__Tracking__E579775FAE1A0B4F");

//            entity.ToTable("TrackingDetail");

//            entity.Property(e => e.TId)
//                .ValueGeneratedNever()
//                .HasColumnName("t_id");
//            entity.Property(e => e.OrderNo).HasColumnName("order_no");
//            entity.Property(e => e.Status)
//                .HasMaxLength(50)
//                .HasColumnName("status");

//            entity.HasOne(d => d.OrderNoNavigation).WithMany(p => p.TrackingDetails)
//                .HasForeignKey(d => d.OrderNo)
//                .HasConstraintName("FK__TrackingD__order__571DF1D5");
//        }
//    }
//}
