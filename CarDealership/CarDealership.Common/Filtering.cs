using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Common
{
    public class Filtering
    {
        //public string Query { get; set; }
        public DateTime? MadeBefore { get; set; }
        public DateTime? MadeAfter { get; set; }
        public bool HasBodyType { get; set; }
        public Filtering(DateTime? madeBefore, DateTime? madeAfter, bool hasBT)
        {
            MadeBefore = madeBefore;
            MadeAfter = madeAfter;
            HasBodyType = hasBT;
        }
    }
}
