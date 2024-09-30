using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoCalculator
{
    class Parent
    {
        public List<Gen> Gens { get; set; }
        public List<bool> HetStatus { get; set; }

        public Parent(List<Gen> gens, List<bool> hetStatus)
        {
            Gens = gens;
            HetStatus = hetStatus;
        }
    }
}
