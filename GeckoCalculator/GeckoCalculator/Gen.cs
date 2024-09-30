using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoCalculator
{
    public class Gen
    {
        public string NameGen { get; set; }
        public TypeGenEnum TypeGen { get; set; }

        public Gen(string nameGen, TypeGenEnum typeGen)
        {
            NameGen = nameGen;
            TypeGen = typeGen;
        }

        public enum TypeGenEnum
        {
            Dominant,
            Recessive, 
            CoDominant
        }

       // Gen enigma = new Gen(TypeGenEnum.Dominant);
    }
}
