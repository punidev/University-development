using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblemSolver
{
    internal class Data
    {
        public static List<Data> Items = new List<Data>();
        public int Number { get; set; }
        public string Name { get; set; }
        public int Solved { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {2} {1} projecteuler.net/problem={0} ", Number, Name, Solved);
        }
    }
}
