using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class HouseHoldExpenseTypeMap : EntityTypeConfiguration<HouseHoldExpenseType>
    {
        public HouseHoldExpenseTypeMap(){
            this.HasKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("HouseHoldExpenseType");
            this.Property(t => t.Id).HasColumnName("Id");            
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            this.HasRequired(t => t.Institute)
                 .WithMany(t => t.HouseHoldExpenseType)
                 .HasForeignKey(d => d.InstituteId);
        }
}
}
