using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoCalculator
{
    class CalculateGenotype
    {
        //public static List<Result> Calculate()

        private static Gen.TypeGenEnum GetTypeGen(string typeGen)
        {
            if (typeGen == "Доминантный")
            {
                return Gen.TypeGenEnum.Dominant;
            }
            else if (typeGen == "Рецессивный")
            {
                return Gen.TypeGenEnum.Recessive;
            }
            else if (typeGen == "Ко-доминантный")
            {
                return Gen.TypeGenEnum.CoDominant;
            }
            else { return Gen.TypeGenEnum.Dominant; }
        }
        public static List<Result> Calculate(Parent maleParent, Parent femaleParent)
        {
            // 
            //
            //

            return new List<Result>();
        }


    }
}
