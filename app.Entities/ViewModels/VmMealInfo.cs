using app.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.ViewModels
{
    
    public class VmMealInfo
    {
        public string Name { get; set; }
        public string MealInfo { get; set; }
        public int UserId { get; set; }
        
    }
}
