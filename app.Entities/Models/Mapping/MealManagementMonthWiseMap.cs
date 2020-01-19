using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class MealManagementMonthWiseMap : EntityTypeConfiguration<MealManagementMonthWise>
    {
        public MealManagementMonthWiseMap(){

        this.HasKey(t => t.Id);
            // Table & Column Mappings
            this.ToTable("MealManagementMonthWise");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TotalDayMeal).HasColumnName("TotalDayMeal");
            this.Property(t => t.TotalNightMeal).HasColumnName("TotalNightMeal");
            this.Property(t => t.TotalGuestMeal).HasColumnName("TotalGuestMeal");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");            
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.GraceMeal).HasColumnName("GraceMeal");
            this.Property(t => t.AmountToPay).HasColumnName("AmountToPay");
            this.Property(t => t.AmountPaid).HasColumnName("AmountPaid");
            this.Property(t => t.MonthId).HasColumnName("MonthId");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Month).HasColumnName("Month");
            this.Property(t => t.TotalMeal).HasColumnName("TotalMeal");

        }
}
}
