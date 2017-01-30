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
                Console.WriteLine("������ ����������� �������: ");
                foreach (var t in lst.Where(action).OrderBy(t=>t.Name).ToList())
                {
                    Console.WriteLine("�������� - {0} : ��������� - {1}% : ���� � �������� - {2}", t.Name, t.Alco*100, t.Part);
                }
            }
            else
            {
                Console.WriteLine("��� ������� �������: ");
                foreach (var t in lst)
                {
                    Console.WriteLine("�������� - {0} : ��������� - {1}% : ���� � �������� - {2}", t.Name, t.Alco*100, t.Part);
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
                return string.Format("{0} | {1} ��., �������� = {2}, ����: {3} ���.", Name, Quantity, Promille, Cost);
            }
        }

        public static void TypeOfAlcoholIntoxication(
            double d)
        {
            string res = null;

            if (d >= 0 && d < 1.0)
                res = "�����";
            if (d >= 1.0 && d < 2.0)
                res = "������ �������";
            if (d >= 2.0 && d < 3.0)
                res = "������� �������";
            if (d >= 3.0 && d < 4.0)
                res = "������� �������";
            if (d >= 4.0)
                res = "C���������� �������";

            Console.WriteLine("���� ���� = {0} �\n{1} ���������.", d, res);
        }
    }
}