using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKM
{
    struct Step
    {
        public double x;
        public double u;
        public double k1;
        public double k2;
        public double k3;
        public double k4;
    }

    class Functions
    {
        public static double TestFunction(double u)
        {
            return 2 * u;
        }

        public static double FirstMainFunction(double x, double u)
        {
            return ((Math.Pow(x, 3) + 1) / (Math.Pow(x, 5) + 1) * Math.Pow(u, 2) + u - Math.Pow(u, 3) * Math.Sin(10*x));
        }

        public static double SecondMainFunction(double x, double u)
        {
            return 3 * Math.Sin(2 * u) + x;
        }



        public static void RKMdecision(double left, double rigth , double Nmax, double U0, double h, double a, double b, double c)
        {
            double n = (rigth - left)/h;
            n = n > Nmax ? Nmax : n;

            Step[] steps = new Step[(int)n+1];

            steps[0].x = left;
            steps[0].u = U0;

            for( int i = 1; i<=n; i++)
            {
                steps[i].x = left + i * h;
                steps[i].k1 = h * FirstMainFunction(steps[i - 1].x, steps[i - 1].u);
                steps[i].k2 = h * FirstMainFunction(steps[i - 1].x + h / 2.0, steps[i - 1].u + steps[i].k1 / 2.0);
                steps[i].k3 = h * FirstMainFunction(steps[i - 1].x + h / 2, steps[i - 1].u + steps[i].k2 / 2);
                steps[i].k4 = h * FirstMainFunction(steps[i - 1].x + h, steps[i - 1].u + steps[i].k3);
                steps[i].u = steps[i - 1].u + (steps[i].k1 + 2 * steps[i].k2 + 2 * steps[i].k3 + steps[i].k4) / 6;
            }

            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(i + " " + "X" + steps[i].x);
            }

            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine(i + " " + "U" + steps[i].u);
            }

        }
    }
}
