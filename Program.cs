using System;

namespace SystemOfEquations
{
    // Базовий клас: система рівнянь 2×2
    class SystemEquation
    {
        protected double[,] a = new double[2, 2];
        protected double[] b = new double[2];

        public virtual void Input()
        {
            Console.WriteLine("Введіть коефіцієнти для системи 2x2 (a11 a12 b1; a21 a22 b2):");
            for (int i = 0; i < 2; i++)
            {
                Console.Write($"Рівняння {i + 1}: ");
                string[] parts = Console.ReadLine().Split();
                a[i, 0] = double.Parse(parts[0]);
                a[i, 1] = double.Parse(parts[1]);
                b[i] = double.Parse(parts[2]);
            }
        }

        public virtual void Print()
        {
            Console.WriteLine("\nСистема рівнянь 2x2:");
            for (int i = 0; i < 2; i++)
                Console.WriteLine($"{a[i, 0]}*x1 + {a[i, 1]}*x2 = {b[i]}");
        }

        public virtual void CheckSolution()
        {
            Console.Write("Введіть вектор X (x1 x2): ");
            string[] parts = Console.ReadLine().Split();
            double x1 = double.Parse(parts[0]);
            double x2 = double.Parse(parts[1]);

            bool ok = true;
            for (int i = 0; i < 2; i++)
            {
                double left = a[i, 0] * x1 + a[i, 1] * x2;
                if (Math.Abs(left - b[i]) > 1e-6)
                    ok = false;
            }

            Console.WriteLine(ok ? "✅ Вектор задовольняє систему." : "❌ Вектор не задовольняє систему.");
        }
    }

    // Похідний клас: система рівнянь 3×3
    class SystemEquation3x3 : SystemEquation
    {
        private double[,] a3 = new double[3, 3];
        private double[] b3 = new double[3];

        public override void Input()
        {
            Console.WriteLine("Введіть коефіцієнти для системи 3x3 (a11 a12 a13 b1; a21 a22 a23 b2; a31 a32 a33 b3):");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Рівняння {i + 1}: ");
                string[] parts = Console.ReadLine().Split();
                a3[i, 0] = double.Parse(parts[0]);
                a3[i, 1] = double.Parse(parts[1]);
                a3[i, 2] = double.Parse(parts[2]);
                b3[i] = double.Parse(parts[3]);
            }
        }

        public override void Print()
        {
            Console.WriteLine("\nСистема рівнянь 3x3:");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{a3[i, 0]}*x1 + {a3[i, 1]}*x2 + {a3[i, 2]}*x3 = {b3[i]}");
        }

        public override void CheckSolution()
        {
            Console.Write("Введіть вектор X (x1 x2 x3): ");
            string[] parts = Console.ReadLine().Split();
            double x1 = double.Parse(parts[0]);
            double x2 = double.Parse(parts[1]);
            double x3 = double.Parse(parts[2]);

            bool ok = true;
            for (int i = 0; i < 3; i++)
            {
                double left = a3[i, 0] * x1 + a3[i, 1] * x2 + a3[i, 2] * x3;
                if (Math.Abs(left - b3[i]) > 1e-6)
                    ok = false;
            }

            Console.WriteLine(ok ? "✅ Вектор задовольняє систему." : "❌ Вектор не задовольняє систему.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Оберіть тип системи:");
            Console.WriteLine("1 – Система рівнянь 2x2");
            Console.WriteLine("2 – Система рівнянь 3x3");
            Console.Write("Ваш вибір: ");
            int userChoose = int.Parse(Console.ReadLine());

            // Динамічне створення об’єкта через базовий покажчик
            SystemEquation system;

            if (userChoose == 1)
                system = new SystemEquation();
            else
                system = new SystemEquation3x3();

            system.Input();
            system.Print();
            system.CheckSolution();

            Console.WriteLine("\nРоботу завершено!");
        }
    }
}
