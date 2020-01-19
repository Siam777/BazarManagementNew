using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class MealManagementMonthWise: Entity
    {
        public int Id { get; set; }                     
        public int TotalDayMeal   { get; set; }
        public int TotalNightMeal { get; set;}       
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
        public int Year {get;set;}
        public string Month { get; set; }

        // public string Name;
        //public virtual Institute Institute { get; set; }
    }
}
