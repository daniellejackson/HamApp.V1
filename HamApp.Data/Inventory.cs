﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamApp.Data
{
    public class Inventory
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
