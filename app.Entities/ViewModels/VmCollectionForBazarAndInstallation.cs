using app.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Entities.ViewModels
{
    [NotMapped]
    public class VmCollectionForBazarAndInstallation : CollectionForBazarAndInstallation
    {
        //public string ImagePath;
        public string Name;
    }
}
