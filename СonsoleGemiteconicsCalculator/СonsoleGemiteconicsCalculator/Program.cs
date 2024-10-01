using ConsoleGemiteconicsCalculator;
using СonsoleGemiteconicsCalculator;

namespace ConsoleGemiteconicsCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в калькулятор морф гемитекониксов!\nДавайте зададим гены родителей? ДA/НЕТ");
            if (Console.ReadLine().ToLower() == "да")
            {
                ParentsGen();
            }
            else
            {
                Console.WriteLine("Пока!");
                return;
            }
        }

        private static void ParentsGen()
        {
            List<Gen> GenFemale = GetGensFromUser("самки");
            Console.WriteLine($"Cамка имеет гены: {string.Join(", ", GenFemale.Select(g => g.NameGen))}");

            List<Gen> GenMale = GetGensFromUser("самца");
            Console.WriteLine($"Cамец имеет гены: {string.Join(", ", GenMale.Select(g => g.NameGen))}");

            СalculatorMorph(GenFemale, GenMale);
        }

        private static List<Gen> GetGensFromUser(string parentType)
        {
            List<Gen> gens = new List<Gen>();

            Console.WriteLine($"Давайте заполним гены {parentType}\nЕсли хотите закончить заполнение генов введите \"Закончить\"");

            string genInput;
            do
            {
                genInput = Console.ReadLine();
                if (genInput.ToLower() == "wo")
                {
                    gens.Add(new Gen("WO", Gen.TypeGenEnum.Dominant));
                }
                else if (genInput.ToLower() == "zulu")
                {
                    gens.Add(new Gen("Zulu", Gen.TypeGenEnum.Recessive));
                }
                else if (genInput.ToLower() == "zero")
                {
                    gens.Add(new Gen("Zero", Gen.TypeGenEnum.CoDominant));
                }
                else if (genInput.ToLower() != "закончить")
                {
                    Console.WriteLine("Такого гена нет");
                }
            }
            while (genInput.ToLower() != "закончить");

            return gens;
        }

        private static void СalculatorMorph(List<Gen> GenFemale, List<Gen> GenMale)
        {
            var morphs = new List<string>();
            var genCombinations = new List<string>();

            var allGens = new List<Gen>();
            allGens.AddRange(GenFemale);
            allGens.AddRange(GenMale);

            foreach (var femaleGen in GenFemale)
            {
                foreach (var maleGen in GenMale)
                {
                    if (femaleGen.TypeGen == Gen.TypeGenEnum.Dominant) 
                    {
                        // Если у самки доминантный ген, он проявится в потомстве
                        genCombinations.Add(femaleGen.NameGen);
                    }
                    else if (femaleGen.TypeGen == Gen.TypeGenEnum.Recessive && maleGen.TypeGen == Gen.TypeGenEnum.Recessive)
                    {
                        // Если у самки и самца есть рецессивные гены, то потомство будет иметь рецессивный ген
                        genCombinations.Add(femaleGen.NameGen);
                    }
                    else if (femaleGen.TypeGen == Gen.TypeGenEnum.CoDominant || maleGen.TypeGen == Gen.TypeGenEnum.CoDominant)
                    {
                        // Если один из генов кодоминантный, то оба гена проявятся
                        genCombinations.Add($"{femaleGen.NameGen}/{maleGen.NameGen}");
                    }
                }
            }
            // Убираем дубликаты
            var uniqueMorphs = genCombinations.Distinct().ToList();

            Console.WriteLine($"Потомство от пары самка {string.Join(", ", GenFemale.Select(g => g.NameGen))} и самец {string.Join(", ", GenMale.Select(g => g.NameGen))} имеет морфы:");
            foreach (var morph in uniqueMorphs)
            {
                Console.WriteLine($"{morph}");
            }
        }
    }
}
