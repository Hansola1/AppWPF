using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeckoCalculator.Gen;

namespace GeckoCalculator
{
    class Result
    {
        public int Number { get; set; }
        public int Probability { get; set; }
        public string Morph { get; set; }


        public Result(int number, int probability, string morph)
        {
            Number = number;
            Probability = probability;
            Morph = morph;
        }
    }
}
