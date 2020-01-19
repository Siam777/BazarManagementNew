using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class CollectionForBazarAndInstallation : Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Collection { get; set; }
        public Nullable<DateTime> CollectionDate { get; set; }
        public int MonthId { get; set; }
        public int InstituteId { get; set; }
        public int BazarTypeId { get; set; }
        public Nullable<DateTime>Date {get;set;}
        public Nullable<int> Year { get; set; }
        public virtual Institute Institute { get; set; }
        public List<KeyValuePair<int, string>> BazarTypeList { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
