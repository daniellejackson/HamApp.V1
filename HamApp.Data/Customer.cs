﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamApp.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }

       // public virtual List<Transaction> Transactions { get; set; }
    }
}
