using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class InstallationCostMap : EntityTypeConfiguration<InstallationCost>
    {
        public InstallationCostMap(){
            this.HasKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("InstallationCost");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Cost).HasColumnName("Cost");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            this.HasRequired(t => t.Institute)
                 .WithMany(t => t.InstallationCost)
                 .HasForeignKey(d => d.InstituteId);
        }
}
}
