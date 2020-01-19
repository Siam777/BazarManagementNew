using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class MealManagement: Entity
    {
        public int Id { get; set; }              
        public Nullable<DateTime> Date { get; set; }
        public bool IsDay   { get; set; }
        public bool IsNight { get; set;}       
        public int InstituteId { get; set; }
        public int GuestMeal { get; set; }
        public int UserId { get; set; }
       // public string Name;
        public virtual Institute Institute { get; set; }
    }
}
