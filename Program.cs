using System;

namespace SystemOfEquations
{
 
    class EquationSystem2x2
    {
        protected double[,] a = new double[2, 2];
        protected double[] b = new double[2];     

        public virtual void Input()
        {
            Console.WriteLine("\nВведення коефіцієнтів системи рівнянь 2x2:");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Рівняння {i + 1}:");
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"a[{i + 1},{j + 1}] = ");
                    a[i, j] = double.Parse(Console.ReadLine());
                }
                Console.Write($"b[{i + 1}] = ");
                b[i] = double.Parse(Console.ReadLine());
            }
        }

        public virtual void Display()
        {
            Console.WriteLine("\nСистема рівнянь 2x2:");
            Console.WriteLine($"{a[0, 0]}*x1 + {a[0, 1]}*x2 = {b[0]}");
            Console.WriteLine($"{a[1, 0]}*x1 + {a[1, 1]}*x2 = {b[1]}");
        }

        public virtual void CheckSolution()
        {
            Console.WriteLine("\nПеревірка рішення для системи 2x2:");
            Console.Write("Введіть x1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Введіть x2: ");
            double x2 = double.Parse(Console.ReadLine());

            double left1 = a[0, 0] * x1 + a[0, 1] * x2;
            double left2 = a[1, 0] * x1 + a[1, 1] * x2;

            if (Math.Abs(left1 - b[0]) < 1e-6 && Math.Abs(left2 - b[1]) < 1e-6)
                Console.WriteLine("✅ Вектор (x1, x2) задовольняє систему.");
            else
                Console.WriteLine("❌ Вектор (x1, x2) НЕ задовольняє систему.");
        }
    }

   
    class EquationSystem3x3 : EquationSystem2x2
    {
        protected double[,] a3 = new double[3, 3];
        protected double[] b3 = new double[3];

        public override void Input()
        {
            Console.WriteLine("\nВведення коефіцієнтів системи рівнянь 3x3:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Рівняння {i + 1}:");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"a[{i + 1},{j + 1}] = ");
                    a3[i, j] = double.Parse(Console.ReadLine());
                }
                Console.Write($"b[{i + 1}] = ");
                b3[i] = double.Parse(Console.ReadLine());
            }
        }

        public override void Display()
        {
            Console.WriteLine("\nСистема рівнянь 3x3:");
            Console.WriteLine($"{a3[0, 0]}*x1 + {a3[0, 1]}*x2 + {a3[0, 2]}*x3 = {b3[0]}");
            Console.WriteLine($"{a3[1, 0]}*x1 + {a3[1, 1]}*x2 + {a3[1, 2]}*x3 = {b3[1]}");
            Console.WriteLine($"{a3[2, 0]}*x1 + {a3[2, 1]}*x2 + {a3[2, 2]}*x3 = {b3[2]}");
        }

        public override void CheckSolution()
        {
            Console.WriteLine("\nПеревірка рішення для системи 3x3:");
            Console.Write("Введіть x1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Введіть x2: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.Write("Введіть x3: ");
            double x3 = double.Parse(Console.ReadLine());

            double[] left = new double[3];
            for (int i = 0; i < 3; i++)
            {
                left[i] = a3[i, 0] * x1 + a3[i, 1] * x2 + a3[i, 2] * x3;
            }

            if (Math.Abs(left[0] - b3[0]) < 1e-6 && Math.Abs(left[1] - b3[1]) < 1e-6 && Math.Abs(left[2] - b3[2]) < 1e-6)
                Console.WriteLine("✅ Вектор (x1, x2, x3) задовольняє систему.");
            else
                Console.WriteLine("❌ Вектор (x1, x2, x3) НЕ задовольняє систему.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Система рівнянь ===");
            Console.Write("Оберіть тип системи (2 або 3): ");
            int userChoose = int.Parse(Console.ReadLine());

            EquationSystem2x2 system; 

          
            if (userChoose == 2)
                system = new EquationSystem2x2();
            else
                system = new EquationSystem3x3();

          
            system.Input();
            system.Display();
            system.CheckSolution();

            Console.WriteLine("\nРоботу завершено.");
        }
    }
}
