using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.Models.Mapping
{
    class BazarExpenseMap : EntityTypeConfiguration<BazarExpense>
    {
        public BazarExpenseMap(){

        this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("BazarExpense");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Expense).HasColumnName("Expense");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.BazarTypeId).HasColumnName("BazarTypeId");
            this.Property(t => t.InstituteId).HasColumnName("InstituteId");
            this.Property(t => t.MonthId).HasColumnName("MonthId");
            this.Property(t => t.Year).HasColumnName("Year");
            this.HasRequired(t => t.Institute)
                 .WithMany(t => t.BazarExpense)
                 .HasForeignKey(d => d.InstituteId);
        }
}
}
