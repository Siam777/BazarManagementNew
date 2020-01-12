using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class InstituteMap : EntityTypeConfiguration<Institute>
    {
        public InstituteMap(){

        this.HasKey(t => t.Id);

            // Properties
            //this.Property(t => t.PIN)
            //    .HasMaxLength(32);

            
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(128);            
            
            // Table & Column Mappings
            this.ToTable("Institute");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            
    }
}
}
