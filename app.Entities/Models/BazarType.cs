﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Ef6;
namespace app.Entities.Models

{
    public partial class BazarType: Entity
    {
        public int Id { get; set; }       
        public string Name { get; set; } 
       // public int InstituteId { get; set; }       
    }
}
