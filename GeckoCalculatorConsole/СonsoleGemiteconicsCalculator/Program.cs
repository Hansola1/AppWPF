using СonsoleGemiteconicsCalculator;

namespace ConsoleGemiteconicsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("Добро пожаловать в калькулятор морф гемитекониксов!\nДавайте зададим гены родителей? ДA/НЕТ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "ДА":
                        ParentsGen();
                        break;
                    case "НЕТ":
                        Console.WriteLine("Пока!");
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'ДА' или 'НЕТ'.");
                        continue;
                }
            }
        }

        private static void ParentsGen()
        {
            List<Gen> GenFemale = GetGensInput("самки"); //Заполняем гены самки
            Console.WriteLine($"Cамка имеет гены: {string.Join(", ", GenFemale.Select(g => g.NameGen))}");

            List<Gen> GenMale = GetGensInput("самца"); //Заполняем гены самца
            Console.WriteLine($"Cамец имеет гены: {string.Join(", ", GenMale.Select(g => g.NameGen))}");

            СalculatorMorph(GenFemale, GenMale);
        }

        private static List<Gen> GetGensInput(string parentType)
        {
            List<Gen> gens = new List<Gen>();

            Console.WriteLine($"\nДавайте заполним гены {parentType}. Закончить заполнение генов - \"Закончить\".");
            Console.WriteLine("Список доступных гево: Normal, Wo, Zulu, Amel");

            string genInput;
            while (true)
            {
                genInput = Console.ReadLine().ToLower();

                if (genInput == "закончить")
                {
                    break; 
                }

                switch (genInput)
                {
                    case "normal":
                        gens.Add(new Gen("Normal", Gen.TypeGenEnum.Dominant));
                        break;
                    case "wo":
                        gens.Add(new Gen("WO", Gen.TypeGenEnum.CoDominant));
                        break;
                    case "zulu":
                        gens.Add(new Gen("Zulu", Gen.TypeGenEnum.Recessive_homozygous));
                        break;
                    case "amel":
                        gens.Add(new Gen("Amel", Gen.TypeGenEnum.Recessive_homozygous));
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Такого гена нет.");
                        continue;                      
                }
            }
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
                    if (femaleGen.TypeGen == Gen.TypeGenEnum.Dominant || maleGen.TypeGen == Gen.TypeGenEnum.Dominant)
                    {
                        // Если у самки или самца доминант ген, потомство 50% normal, 50% gen
                        genCombinations.Add(femaleGen.NameGen);
                    }
                    else if (femaleGen.TypeGen == Gen.TypeGenEnum.Recessive_homozygous && maleGen.TypeGen == Gen.TypeGenEnum.Recessive_homozygous)
                    {
                        // Если у самки и самца есть гомо. рецесc. гены, то потомство 100% gen
                        genCombinations.Add(femaleGen.NameGen);
                    }
                }
            }
            resultMorph(genCombinations, GenFemale, GenMale); 
        }

        private static void probability()
        { 
        }

        private static void resultMorph(List<string> genCombinations, List<Gen> GenFemale, List<Gen> GenMale)
        {
            Console.WriteLine($"Потомство от пары самка " +
                $"{string.Join(", ", GenFemale.Select(g => g.NameGen))} " + $"и самец {string.Join(", ", GenMale.Select(g => g.NameGen))} имеет морфы:");

            foreach (var morph in genCombinations)
            {
                Console.WriteLine($"{morph}");
            }
        }
    }
}
