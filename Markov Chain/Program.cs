using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markov_Calculator;

namespace Markov_Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] trans = new double[,] { { 0.8, 0.4 }, { 0.2, 0.6}  };
            double[,] init_x = new double[,] { { 0.5}, { 0.5} };

            Calculator calc = new Calculator(trans, init_x);

            double[][,] xs = calc.CalculateXs(50);

            Console.WriteLine(xs);
            Console.Read();
        }
    }
}
