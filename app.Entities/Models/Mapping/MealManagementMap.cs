using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class MealManagementMap : EntityTypeConfiguration<MealManagement>
    {
        public MealManagementMap(){

        this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("MealManagement");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.IsDay).HasColumnName("IsDay");
            this.Property(t => t.IsNight).HasColumnName("IsNight");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            this.HasRequired(t => t.Institute)
                 .WithMany(t => t.MealManagement)
                 .HasForeignKey(d => d.InstituteId);
        }
}
}
