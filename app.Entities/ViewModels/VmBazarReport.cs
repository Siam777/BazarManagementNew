using app.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.ViewModels
{
    
    public class VmBazarReport
    {
        public int Id { get; set; }
        public int TotalDayMeal { get; set; }
        public int TotalNightMeal { get; set; }
        public int InstituteId { get; set; }
        public int TotalGuestMeal { get; set; }
        public int TotalMeal { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Nullable<Decimal> MealRate { get; set; }
        public Nullable<int> GraceMeal { get; set; }
        public Nullable<decimal> AmountToPay { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public int MonthId { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }       
        public Nullable<decimal> InstallationToPay { get; set; }
        public Nullable<decimal> InstallationPaid { get; set; }
        public Nullable<decimal> TotalBazarCost { get; set; }
        public Nullable<decimal> TotalInstallationCost { get; set; }

    }
}
