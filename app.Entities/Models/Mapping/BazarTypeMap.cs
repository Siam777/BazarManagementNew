using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class BazarTypeMap : EntityTypeConfiguration<BazarType>
    {
        public BazarTypeMap(){
            this.HasKey(t => t.Id);            
            this.ToTable("BazarType");
            this.Property(t => t.Id).HasColumnName("Id");            
            this.Property(t => t.Name).HasColumnName("Name");            
        }
}
}
