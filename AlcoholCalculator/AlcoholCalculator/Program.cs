using System;
using System.Collections.Generic;
using System.Linq;

namespace AlcoholCalculator
{
    internal class Program
    {
        public static List<User.UserUtils> Items;
        public static List<User.UserUtils> NItems;

        public static void FindAlc()
        {
            Console.Write("Введите сумму: ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вес: ");
            int weight = Convert.ToInt32(Console.ReadLine());
            Items = new List<User.UserUtils>();
            NItems = new List<User.UserUtils>();
            User.UserUtils.Items.Clear();
            foreach (var t in Coctails.list)
            {
                User.UserUtils.Items.Add(new User.UserUtils
                {
                    Ingredient = t.Ingredients,
                    Name = t.Name,
                    Quantity = t.Quantity,
                    Weight = weight,
                    Promille = User.Calculator(t.Ingredients, weight, t.Quantity, 1, a => a.Alco*a.Part),
                    Cost = t.Cost
                });
            }
            A(key, weight);
        }


        public static void A(int a, int weight)
        {
        
            List<Alcohol> values = new List<Alcohol>();
            Items.Clear();
            Items = User.UserUtils.Items.OrderBy(s => -s.Promille).ThenBy(s => s.Cost).ToList();
            int quant = 0, cost = 0;
            foreach (var t in Items)
            {
                if (!Items.Any(v => a <= v.Cost))
                {
                    quant += t.Quantity;
                    cost += t.Cost;
                    NItems.Add(t);
                    a -= t.Cost;
                }
                else
                {
                    break;
                }
            }
            foreach (var s in NItems)
            {
                values.AddRange(s.Ingredient);
            }
            foreach (var s in NItems)
            {
                Console.WriteLine(s.ToString());
            }
            User.TypeOfAlcoholIntoxication(User.Calculator(values, weight, quant, NItems.Count,
                t => t.Alco*t.Part/NItems.Count));
            User.DisAssembly(values, t => t.Alco > 0);
            Console.WriteLine("Сумма коктейлей: " + cost);

        }

        public static void OrdinaryCount()
        {
            List<Alcohol> values = new List<Alcohol>();
            int cost = 0, quant = 0;
            Console.WriteLine("Введите название коктейля: ");
            var key = Console.ReadLine();
            foreach (var t in Coctails.list.Where(t => key == t.Name))
            {
                values.AddRange(t.Ingredients);
                cost += t.Cost;
                quant += t.Quantity;
            }
            Console.Write("Введите свой вес в кг: ");
            int weight = Convert.ToInt32(Console.ReadLine());
            User.TypeOfAlcoholIntoxication(User.Calculator(values, weight, quant,1 , t => t.Alco * t.Part));
            User.DisAssembly(values, t => t.Alco > 0);
            Console.WriteLine("Сумма коктейлей: " + cost);
        }

        public static void ShowAll()
        {
            int j = 1;
            foreach (var t in Coctails.list)
            {
                Console.WriteLine("\t{1}. {0}", t.Name, j);
                j++;
            }
        }

        public static void MultiplyCount()
        {
            List<Alcohol> values = new List<Alcohol>();
            int cost = 0, quant = 0;
            Console.Write("Введите количество коктейлей: ");
            var count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.Write("Введите название коктейля " + (i + 1) + ": ");
                var key = Console.ReadLine();
                foreach (var t in Coctails.list.Where(t => key == t.Name))
                {
                    values.AddRange(t.Ingredients);
                    cost += t.Cost;
                    quant += t.Quantity;
                }

            }
            Console.Write("Введите свой вес в кг: ");
            int weight = Convert.ToInt32(Console.ReadLine());
            User.TypeOfAlcoholIntoxication(User.Calculator(values, weight, quant, count, t => t.Alco * t.Part /count));
            User.DisAssembly(values, t => t.Alco > 0);
            Console.WriteLine("Сумма коктейлей: " + cost);
        }


        private static void Main()
        {
            bool isExit = false;
            while (!isExit)
            {
                Console.Write("Меню\n\n" +
                              "1. Расчет одного коктейля\n" +
                              "2. Расчет нескольких коктейлей\n" +
                              "3. Оптимизированный расчет\n" +
                              "4. Показать коктейльную карту\n" +
                              "5. Выход" +
                              "\n\n$ ~");
                string answer = Console.ReadLine()?.ToLower();
                switch (answer)
                {
                    case "2":
                        MultiplyCount();
                        break;
                    case "1":
                        OrdinaryCount();
                        break;
                    case "3":
                        FindAlc();
                        break;
                    case "4":
                        ShowAll();
                        break;
                    case "5":
                        isExit=true;
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
