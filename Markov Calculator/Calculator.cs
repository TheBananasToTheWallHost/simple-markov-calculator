using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markov_Calculator
{
    public class Calculator
    {
        double[,] transition;
        double[,] init_x;
        int col_dim;
        int row_dim;

        int result_row_dim;
        int result_col_dim;

        public Calculator(double[,] transition, double[,] prev_x)
        {
            this.transition = transition;
            this.init_x = prev_x;

            col_dim = transition.GetLength(1);
            row_dim = prev_x.GetLength(0);

            if (col_dim != row_dim)
                throw new ArgumentException("Argument dimensions not valid for a dot product");

            result_row_dim = transition.GetLength(0);
            result_col_dim = prev_x.GetLength(1);
        }

        public double[][,] CalculateXs(int iterations)
        {
            double[][,] xs = new double[iterations][,];
            double[,] x = init_x;

            xs[0] = x;

            for (int i = 1; i < iterations; i++)
            {
                x = Dot(x);
                xs[i] = x;
            }

            return xs;
        }

        private double[,] Dot(double[,] x)
        {
            double[,] next_x = new double[result_row_dim,result_col_dim];

            for(int k = 0; k < result_col_dim; k++)
            {
                for (int i = 0; i < result_row_dim; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < row_dim; j++)
                    {
                        sum += transition[i, j] * x[j, k];
                    }

                    next_x[i, k] = sum;
                }
            }

            return next_x;
        }
    }
}
