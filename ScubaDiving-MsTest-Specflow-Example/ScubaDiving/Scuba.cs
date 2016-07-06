using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScubaDiving
{
    public class Scuba
    {

        public int NumberOfBuddies { get; set; }

        public int Depth { get; set; }

        public int DiveTime { get; set; }

        public string DiveSiteName { get; set; }

        public List<string> MultipleDiveSites { get; set; }

        public object SumOfDepths { get; set; }

        public object SumOfTime { get; set; }
    }
}
