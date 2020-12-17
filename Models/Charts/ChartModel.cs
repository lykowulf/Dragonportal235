using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dragonportal235.Models.Charts
{
    public class ChartModel
    {
      
        public string Label { get; set; }
        public decimal  Value { get; set; }


    }

    public class TransactionChartModel
    {
        public string TLabel { get; set; }
        public decimal TValue { get; set; }
    }
}
