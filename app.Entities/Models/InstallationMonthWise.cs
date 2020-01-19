using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class InstallationMonthWise: Entity
    {
        public int Id { get; set; }         
        public Nullable<decimal> InstallationToPay { get; set; }   
        public Nullable<decimal> InstallationPaid { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int InstituteId { get; set; }
        public int MonthId { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }       
    }
}
