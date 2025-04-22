﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}
