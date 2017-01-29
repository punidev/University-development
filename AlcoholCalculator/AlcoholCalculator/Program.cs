using System;
using System.Collections.Generic;
using System.Linq;

namespace AlcoholCalculator
{
    internal class Program
    {
        public static List<User.UserUtils> Items = new List<User.UserUtils>();
        public static List<User.UserUtils> NItems = new List<User.UserUtils>();
        public static void FindAlc(int weight)
        {
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
            Items = User.UserUtils.Items.OrderBy(a => -a.Promille).ThenBy(a => a.Cost).ToList();
            ///
            /// Что-то на подобии блядской машины Тьюринга
            /// 
           // int key = Convert.ToInt32(Console.ReadLine());
           // A(key, Items.Count);
            foreach(var t in Items)
                Console.WriteLine(t.ToString());
        }

        private static readonly Random rand = new Random();
        public static void A(int a, int index)
        {
            if (Items.Any(V => a <= V.Cost))
            {
                return;
            }
            Console.WriteLine(Items[rand.Next(index)].ToString());
            // Items.Remove(Items[index]);
            a -= Items[rand.Next(index)].Cost;
            A(a, index);
        }

        public static void OrdinaryCount()
        {
            List<Alcohol> values = new List<Alcohol>();
            int cost = 0, quant = 0, i = 1;
            Console.WriteLine("Введите название коктейля: ");
            foreach (var t in Coctails.list)
            {
                Console.WriteLine("\t{1}. {0}", t.Name,i);
                i++;
            }
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

        public static void MultiplyCount()
        {
            List<Alcohol> values = new List<Alcohol>();
            int cost = 0, quant = 0;
            Console.Write("Введите количество коктейлей: ");
            var count = Convert.ToInt32(Console.ReadLine());
            foreach (var t in Coctails.list)
            {
                Console.WriteLine("\t{0}", t.Name);
            }
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
            Console.Write("Вы выпили больше 1 коктейля? (y\\n): ");
            string answer = Console.ReadLine()?.ToLower();
            switch (answer)
            {
                case "y":
                    MultiplyCount();
                    break;
                case "n":
                    OrdinaryCount();
                    break;
                case "-test":
                    FindAlc(65); break;
            }
        }
    }
}
