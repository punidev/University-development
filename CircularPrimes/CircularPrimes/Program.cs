using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrimes
{
    class Program
    {
        public static List<int> FindPrimes(long count)
        {
            var res = new List<int>();
            for (var i = 2; i < count; i++)
            {
                if (i % 2 == 0 && i != 2) continue;
                if (!IsPrime(i)) continue;
                res.Add(i);
            }
            return res;
        }

        public static bool IsPrime(double i)
        {
            for (var j = 3; j <= 7; j++)
            {
                if (i%j != 0 || i == j) continue;
                return false;
            }
            return true;
        }

        public static List<int> FindCircularPrimes(List<int> lstPrimes)
        {
            var res = new List<int>();
            foreach (var t in lstPrimes)
            {
                double num = t;
                if (t >= 10)
                {
                    if (t.ToString().Contains('2') || t.ToString().Contains('4') || t.ToString().Contains('6') ||
                        t.ToString().Contains('8') || t.ToString().Contains('0') || t.ToString().Contains('5'))
                        continue;
                    var isCirCulPrime = true;
                    for (var j = 0; j < t.ToString().Length; j++)
                    {
                        num = Rotate(num, t.ToString().Length);
                        if (!IsPrime(num))
                        {
                            isCirCulPrime = false;
                        }
                    }
                    if (isCirCulPrime)
                    {
                        res.Add(t);
                    }
                }
                else
                {
                    res.Add(t);
                }
            }
            return res;
        }

        public static double Rotate(double num, int noDigits)
        {
            int a = (int) num % 10,
                b = (int) num / 10;
            return a * Math.Pow(10, noDigits - 1) + b;
        }

        static void Main()
        {
            var primes = FindPrimes(1000000);
            primes = FindCircularPrimes(primes);
            Console.WriteLine(primes.Count);
            Console.ReadLine();
        }
    }
}
