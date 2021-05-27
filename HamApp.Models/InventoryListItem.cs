﻿using HamApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamApp.Models
{
    public class InventoryListItem
    {
        public int Id { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}