using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class InstallationCost: Entity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }   
        public decimal Cost { get; set; }   
        public string Description { get; set; } 
        public int InstituteId { get; set; }
        public virtual Institute Institute { get; set; }
    }
}
