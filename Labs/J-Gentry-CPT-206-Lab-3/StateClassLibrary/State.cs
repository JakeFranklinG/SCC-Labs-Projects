using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateClassLibrary
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int Population { get; set; }
        public string FlagDescription { get; set; }
        public string StateFlower { get; set; }
        public string StateBird { get; set; }
        public string StateColors { get; set; }
        public string LargestCity1 { get; set; }
        public string LargestCity2 { get; set; }
        public string LargestCity3 { get; set; }
        public string StateCapitol { get; set; }
        public decimal MedianIncome { get; set; }
        public decimal ComputerJobsPercentage { get; set; }

        public override string ToString()
        {
            return StateName;
        }
    }
}
