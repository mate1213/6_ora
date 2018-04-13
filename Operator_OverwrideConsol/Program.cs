using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_OverwrideConsol
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(2, 2);
            Random rand = new Random();
            m1.Generate(rand);
            Console.WriteLine(m1);

            Matrix m2 = m1 * 3;
            Console.WriteLine(m2);

            Console.WriteLine(m1.Equals(m2) ? "Egyezik":"Nem egyezik");
            Console.ReadLine();
        }
    }
}
