using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap(){
            this.HasKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("Image");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ImageBinaryData).HasColumnName("ImageBinaryData");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");            
        }
}
}
