﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dragonportal235.Models.ViewModel
{
    public class AllTransactions
    {
        public Household Household { get; set; }
        public List<Transaction> AllTransaction { get; set; }
        
    }
}
