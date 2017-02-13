using System;
using System.IO;
using System.Linq;

namespace TriangleEulerMethod
{
    internal class Program
    {
        static int GetMaxsum(int[,] input, int count)
        {
            for (var i = count - 2; i >= 0; i--)
                for (var j = 0; j <= i; j++)
                    input[i,j] += Math.Max(input[i + 1, j], input[i + 1, j + 1]);
            return input.Cast<int>().Max();
        }

        private static int[,] ReadInput(string filename)
        {
            string line;
            var lines = 0;
            var sr = new StreamReader(filename);
            while (sr.ReadLine() != null) lines++;

            var triangle = new int[lines, lines];

            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            var j = 0;
            while ((line = sr.ReadLine()) != null)
            {
                for (var i = 0; i < line.Split(' ').Length; i++)
                {
                    triangle[j, i] = int.Parse(line.Split(' ')[i]);
                }
                j++;
            }
            sr.Close();
            return triangle;
        }

        public static void Main()
        {
            Console.WriteLine(GetMaxsum(ReadInput("input.txt"), ReadInput("input.txt").GetLength(0)));
            Console.WriteLine(GetMaxsum(ReadInput("input2.txt"), ReadInput("input2.txt").GetLength(0)));
        }
    }
}
