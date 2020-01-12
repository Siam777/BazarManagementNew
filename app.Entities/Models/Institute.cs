
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class Institute: Entity
    {
        public int Id { get; set; }     
        public string Name { get; set; }  
        public string Url { get; set; }     
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
        public virtual ICollection<BazarExpense> BazarExpense { get; set; }
        public virtual ICollection<CollectionForBazarAndInstallation> CollectionForBazarAndInstallation { get; set; }
        public virtual ICollection<CollectionForHouseHold> CollectionForHouseHold { get; set; }
        public virtual ICollection<InstallationCost> InstallationCost { get; set; }
        public virtual ICollection<HouseHoldExpenseType> HouseHoldExpenseType { get; set; }
        public virtual ICollection<MealManagement> MealManagement { get; set; }
        public virtual ICollection<MonthlyActivatedUser> MonthlyActivatedUser { get; set; }
    }
}
