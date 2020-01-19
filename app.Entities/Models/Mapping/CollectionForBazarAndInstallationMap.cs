using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class CollectionForBazarAndInstallationMap : EntityTypeConfiguration<CollectionForBazarAndInstallation>
    {
        public CollectionForBazarAndInstallationMap(){

        this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("CollectionForBazarAndInstallation");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CollectionDate).HasColumnName("CollectionDate");
            this.Property(t => t.Collection).HasColumnName("Collection");
            this.Property(t => t.MonthId).HasColumnName("MonthId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            this.Property(t => t.BazarTypeId).HasColumnName("BazarTypeId");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Date).HasColumnName("Date");
            this.HasRequired(t => t.Institute)
                 .WithMany(t => t.CollectionForBazarAndInstallation)
                 .HasForeignKey(d => d.InstituteId);
            this.HasRequired(t => t.UserInfo)
                 .WithMany(t => t.CollectionForBazarAndInstallation)
                 .HasForeignKey(d => d.UserId);
        }
}
}
