
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class Image: Entity
    {
        public int Id { get; set; }     
        public Nullable<int> InstituteId { get; set; }
        public Nullable <int> UserId { get; set; }
        public byte[] ImageBinaryData { get; set; }  
        public string ImagePath { get; set; }                     
    }
}
