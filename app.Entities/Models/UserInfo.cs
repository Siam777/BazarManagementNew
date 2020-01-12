
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class UserInfo: Entity
    {
        public int Id { get; set; }
     //   public int UserInfoTypeId { get; set; }
       // public Nullable<int> InstituteId { get; set; }
      //  public string PIN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string EmailAddress { get; set; }
      //  public string SSN { get; set; }
        //public string PassportNo { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        //public Nullable<int> GenderId { get; set; }
        //public Nullable<int> NationalityId { get; set; }
        //public Nullable<int> ReligionId { get; set; }
        //public Nullable<int> BloodGroupId { get; set; }
        //public string GoogleId { get; set; }
        //public string FacebookId { get; set; }
        //public string MicrosoftId { get; set; }
        //public string TwitterId { get; set; }
        public bool IsActive { get; set; }
        public int InstituteId { get; set; }
        public virtual Institute Institute { get; set; }
        public virtual ICollection<CollectionForBazarAndInstallation> CollectionForBazarAndInstallation { get; set; }
        public virtual ICollection<CollectionForHouseHold> CollectionForHouseHold { get; set; }
    }
}
