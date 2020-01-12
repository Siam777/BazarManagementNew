using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap(){

        this.HasKey(t => t.Id);

            // Properties
            //this.Property(t => t.PIN)
            //    .HasMaxLength(32);

            this.Property(t => t.FirstName)
                .HasMaxLength(128);

            this.Property(t => t.MiddleName)
                .HasMaxLength(128);

            this.Property(t => t.LastName)
                .HasMaxLength(128);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.ContactNumber1)
                .HasMaxLength(32);

            this.Property(t => t.ContactNumber2)
                .HasMaxLength(32);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(128);

            //this.Property(t => t.SSN)
            //    .HasMaxLength(128);

            //this.Property(t => t.PassportNo)
            //    .HasMaxLength(128);

            //this.Property(t => t.GoogleId)
            //    .HasMaxLength(128);

            //this.Property(t => t.FacebookId)
            //    .HasMaxLength(128);

            //this.Property(t => t.MicrosoftId)
            //    .HasMaxLength(128);

            //this.Property(t => t.TwitterId)
            //    .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("UserInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            //this.Property(t => t.UserInfoTypeId).HasColumnName("UserInfoTypeId");
           // this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            //this.Property(t => t.PIN).HasColumnName("PIN");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ContactNumber1).HasColumnName("ContactNumber1");
            this.Property(t => t.ContactNumber2).HasColumnName("ContactNumber2");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            //his.Property(t => t.SSN).HasColumnName("SSN");
            //this.Property(t => t.PassportNo).HasColumnName("PassportNo");
            this.Property(t => t.DOB).HasColumnName("DOB");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            //his.Property(t => t.GenderId).HasColumnName("GenderId");
            //this.Property(t => t.NationalityId).HasColumnName("NationalityId");
            //this.Property(t => t.ReligionId).HasColumnName("ReligionId");
            //this.Property(t => t.BloodGroupId).HasColumnName("BloodGroupId");
            // this.Property(t => t.GoogleId).HasColumnName("GoogleId");
            //this.Property(t => t.FacebookId).HasColumnName("FacebookId");
            //this.Property(t => t.MicrosoftId).HasColumnName("MicrosoftId");
            // this.Property(t => t.TwitterId).HasColumnName("TwitterId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            //this.Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime");
            // this.Property(t => t.AboutUser).HasColumnName("AboutUser");
            this.HasRequired(t => t.Institute)
                 .WithMany(t => t.UserInfo)
                 .HasForeignKey(d => d.InstituteId);
        }
}
}
