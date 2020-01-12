using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class MonthlyActivatedUserMap : EntityTypeConfiguration<MonthlyActivatedUser>
    {
        public MonthlyActivatedUserMap(){

        this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("MonthlyActivatedUser");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.MonthId).HasColumnName("MonthId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            this.Property(t => t.Year).HasColumnName("Year");
            this.HasRequired(t => t.Institute)
                 .WithMany(t => t.MonthlyActivatedUser)
                 .HasForeignKey(d => d.InstituteId);
        }
}
}
