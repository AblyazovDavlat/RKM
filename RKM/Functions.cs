using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RKM
{
    public struct Step
    {
        public double x;
        public double u;
        public double k1;
        public double k2;
        public double k3;
        public double k4;
    }

    public struct StepSystem
    {
        public double x;
        public double u;
        public double z;
        public double k1;
        public double k2;
        public double k3;
        public double k4;

        public double l1;
        public double l2;
        public double l3;
        public double l4;
    }

    class Functions
    {
        public static double TestFunction(double u)
        {
            return 2 * u;
        }

        public static double FirstMainFunction(double x, double u)
        {
            return ((Math.Pow(x, 3) + 1) / (Math.Pow(x, 5) + 1) * Math.Pow(u, 2) + u - Math.Pow(u, 3) * Math.Sin(10 * x));
        }

        public static double SystemFunction1(double z)
        {
            return z;
        }

        public static double SystemFunction2(double x, double u, double z, double a, double b, double c)
        {
            return -(a * z * Math.Abs(z) + b * z + c * u);
        }



        public static double OtherMainFunction(double x, double u)
        {
            return 3 * Math.Sin(2 * u) + x;
        }



        public static Step[] RKMdecision(double left, double right, double Nmax, double U0, double h, double a, double b, double c)
        {
            double n = (right - left) / h;
            n = n > Nmax ? Nmax : n;

            Step[] steps = new Step[(int)n + 1];

            steps[0].x = left;
            steps[0].u = U0;

            for (int i = 1; i <= n; i++)
            {
                steps[i].x = left + i * h;
                steps[i].k1 = h * FirstMainFunction(steps[i - 1].x, steps[i - 1].u);
                steps[i].k2 = h * FirstMainFunction(steps[i - 1].x + h / 2.0, steps[i - 1].u + steps[i].k1 / 2.0);
                steps[i].k3 = h * FirstMainFunction(steps[i - 1].x + h / 2, steps[i - 1].u + steps[i].k2 / 2);
                steps[i].k4 = h * FirstMainFunction(steps[i - 1].x + h, steps[i - 1].u + steps[i].k3);
                steps[i].u = steps[i - 1].u + (steps[i].k1 + 2 * steps[i].k2 + 2 * steps[i].k3 + steps[i].k4) / 6;
            }

            return steps;
        }

        public static void RKMdecisionForSystem(double left, double right, double Nmax, double U0, double z0, double h, double a, double b, double c)
        {
            double n = (right - left) / h;
            n = n > Nmax ? Nmax : n;

            StepSystem[] steps = new StepSystem[(int)n + 1];

            steps[0].x = left;
            steps[0].u = U0;
            steps[0].z = z0;

            for (int i = 1; i <= n; i++)
            {
                steps[i].x = left + i * h;
                steps[i].k1 = h * SystemFunction1(steps[i - 1].z);
                steps[i].l1 = h * SystemFunction2(steps[i - 1].x, steps[i - 1].u, steps[i - 1].z, a, b, c);
                steps[i].k2 = h * SystemFunction1(steps[i - 1].z + steps[i].l1/2);
                steps[i].l2 = h * SystemFunction2(steps[i - 1].x + h / 2, steps[i - 1].u + steps[i].k1 / 2, steps[i - 1].z + steps[i].l1 / 2, a, b, c);
                steps[i].k3 = h * SystemFunction1(steps[i - 1].z + steps[i].l2 / 2);
                steps[i].l3 = h * SystemFunction2(steps[i - 1].x + h / 2, steps[i - 1].u + steps[i].k2 / 2, steps[i - 1].z + steps[i].l2 / 2, a, b, c);
                steps[i].k4 = h * SystemFunction1(steps[i - 1].z + steps[i].l3 / 2);
                steps[i].l4 = h * SystemFunction2(steps[i - 1].x + h, steps[i - 1].u + steps[i].k3, steps[i - 1].z + steps[i].l3, a, b, c);
                steps[i].u = steps[i - 1].u + (steps[i].k1 + 2 * steps[i].k2 + 2 * steps[i].k3 + steps[i].k4) / 6;
                steps[i].z = steps[i - 1].z + (steps[i].l1 + 2 * steps[i].l2 + 2 * steps[i].l3 + steps[i].l4) / 6;

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