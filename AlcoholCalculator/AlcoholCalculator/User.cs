using System;
using System.Collections.Generic;
using System.Linq;

namespace AlcoholCalculator
{
    internal class User
    {
        public static double Calculator(
            List<Alcohol> list,
            int weight,
            int quant,
            int count,
            Func<Alcohol, double> action )
        {
            double sumOfAlco = list.Sum(action);
            var res = quant * sumOfAlco * 0.79 * 0.9 / (weight * 0.7);
            return Math.Round(res, 3);
        }

        public static void DisAssembly(
            List<Alcohol> lst,
            Func<Alcohol, bool> action = null )
        {
            if (action != null)
            {
                Console.WriteLine("Только алкогольные напитки: ");
                foreach (var t in lst.Where(action).OrderBy(t=>t.Name).ToList())
                {
                    Console.WriteLine("Название - {0} : Крепкость - {1}% : Доля в коктейле - {2}", t.Name, t.Alco*100, t.Part);
                }
            }
            else
            {
                Console.WriteLine("Все напитки напитки: ");
                foreach (var t in lst)
                {
                    Console.WriteLine("Название - {0} : Крепкость - {1}% : Доля в коктейле - {2}", t.Name, t.Alco*100, t.Part);
                }
            }
        }

        internal class UserUtils : User
        {
            public static List<UserUtils> Items=new List<UserUtils>(); 
            public int Weight { get; set; }
            public string Name { get; set; }
            public List<Alcohol> Ingredient { get; set; }
            public int Quantity { get; set; }
            public double Promille { get; set; }
            public int Cost { get; set; }
            public override string ToString()
            {
                return string.Format("{0} | {1} мл., промилле = {2}, цена: {3} грн.", Name, Quantity, Promille, Cost);
            }
        }

        public static void TypeOfAlcoholIntoxication(
            double d)
        {
            string res = null;

            if (d >= 0 && d < 1.0)
                res = "Норма";
            if (d >= 1.0 && d < 2.0)
                res = "Легкая степень";
            if (d >= 2.0 && d < 3.0)
                res = "Средняя степень";
            if (d >= 3.0 && d < 4.0)
                res = "Тяжелая степень";
            if (d >= 4.0)
                res = "Cмертельная степень";

            Console.WriteLine("Ваша доза = {0} ‰\n{1} опъянения.", d, res);
        }
    }
}