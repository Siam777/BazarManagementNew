using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class InstallationMonthWiseMap : EntityTypeConfiguration<InstallationMonthWise>
    {
        public InstallationMonthWiseMap(){

        this.HasKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("InstallationMonthWise");
            this.Property(t => t.Id).HasColumnName("Id");            
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            this.Property(t => t.UserId).HasColumnName("UserId");           
            this.Property(t => t.UserName).HasColumnName("UserName");           
            this.Property(t => t.InstallationToPay).HasColumnName("InstallationToPay");
            this.Property(t => t.InstallationPaid).HasColumnName("InstallationPaid");
            this.Property(t => t.MonthId).HasColumnName("MonthId");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Month).HasColumnName("Month");
        }
}
}
