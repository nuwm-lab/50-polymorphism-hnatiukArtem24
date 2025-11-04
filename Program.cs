using System;
using System.Collections.Generic;

namespace LabWork.Geometry
{
   
    abstract class LinearSystem
    {
        public abstract void Input();
        public abstract void Print();
        public abstract void CheckSolution();
    }


    class System2x2 : LinearSystem
    {
        private double[,] _a = new double[2, 2];
        private double[] _b = new double[2];

        public override void Input()
        {
            Console.WriteLine("Введіть коефіцієнти системи 2x2 (a11 a12 b1; a21 a22 b2):");
            for (int i = 0; i < 2; i++)
            {
                while (true)
                {
                    Console.Write($"Рівняння {i + 1}: ");
                    string? line = Console.ReadLine();

                    if (line == null) continue;

                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 3)
                    {
                        Console.WriteLine("❌ Потрібно ввести 3 числа!");
                        continue;
                    }

                    if (double.TryParse(parts[0], out _a[i, 0]) &&
                        double.TryParse(parts[1], out _a[i, 1]) &&
                        double.TryParse(parts[2], out _b[i]))
                        break;
                    else
                        Console.WriteLine("❌ Введено некоректні числа. Спробуйте ще раз.");
                }
            }
        }

        public override void Print()
        {
            Console.WriteLine("\nСистема рівнянь 2x2:");
            for (int i = 0; i < 2; i++)
                Console.WriteLine($"{_a[i, 0]}*x1 + {_a[i, 1]}*x2 = {_b[i]}");
        }

        public override void CheckSolution()
        {
            Console.Write("Введіть вектор X (x1 x2): ");
            string[] parts = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

            if (parts.Length != 2 ||
                !double.TryParse(parts[0], out double x1) ||
                !double.TryParse(parts[1], out double x2))
            {
                Console.WriteLine("❌ Невірний формат вводу!");
                return;
            }

            bool ok = true;
            for (int i = 0; i < 2; i++)
            {
                double left = _a[i, 0] * x1 + _a[i, 1] * x2;
                if (Math.Abs(left - _b[i]) > 1e-6)
                    ok = false;
            }

            Console.WriteLine(ok ? "✅ Вектор задовольняє систему." : "❌ Вектор не задовольняє систему.");
        }
    }


    class System3x3 : LinearSystem
    {
        private double[,] _a = new double[3, 3];
        private double[] _b = new double[3];

        public override void Input()
        {
            Console.WriteLine("Введіть коефіцієнти системи 3x3 (a11 a12 a13 b1; a21 a22 a23 b2; a31 a32 a33 b3):");
            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    Console.Write($"Рівняння {i + 1}: ");
                    string? line = Console.ReadLine();
                    if (line == null) continue;

                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 4)
                    {
                        Console.WriteLine("❌ Потрібно ввести 4 числа!");
                        continue;
                    }

                    if (double.TryParse(parts[0], out _a[i, 0]) &&
                        double.TryParse(parts[1], out _a[i, 1]) &&
                        double.TryParse(parts[2], out _a[i, 2]) &&
                        double.TryParse(parts[3], out _b[i]))
                        break;
                    else
                        Console.WriteLine("❌ Введено некоректні числа. Спробуйте ще раз.");
                }
            }
        }

        public override void Print()
        {
            Console.WriteLine("\nСистема рівнянь 3x3:");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{_a[i, 0]}*x1 + {_a[i, 1]}*x2 + {_a[i, 2]}*x3 = {_b[i]}");
        }

        public override void CheckSolution()
        {
            Console.Write("Введіть вектор X (x1 x2 x3): ");
            string[] parts = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

            if (parts.Length != 3 ||
                !double.TryParse(parts[0], out double x1) ||
                !double.TryParse(parts[1], out double x2) ||
                !double.TryParse(parts[2], out double x3))
            {
                Console.WriteLine("❌ Невірний формат вводу!");
                return;
            }

            bool ok = true;
            for (int i = 0; i < 3; i++)
            {
                double left = _a[i, 0] * x1 + _a[i, 1] * x2 + _a[i, 2] * x3;
                if (Math.Abs(left - _b[i]) > 1e-6)
                    ok = false;
            }

            Console.WriteLine(ok ? "✅ Вектор задовольняє систему." : "❌ Вектор не задовольняє систему.");
        }
    }


    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота: Поліморфізм і віртуальні методи ===\n");
            Console.WriteLine("Оберіть тип системи:");
            Console.WriteLine("1 – Система рівнянь 2x2");
            Console.WriteLine("2 – Система рівнянь 3x3");
            Console.Write("Ваш вибір: ");

            int userChoose;
            while (!int.TryParse(Console.ReadLine(), out userChoose) || (userChoose != 1 && userChoose != 2))
            {
                Console.Write("❌ Невірний вибір! Введіть 1 або 2: ");
            }

      
            LinearSystem system = (userChoose == 1) ? new System2x2() : new System3x3();

            system.Input();
            system.Print();
            system.CheckSolution();

      
            Console.WriteLine("\n=== Демонстрація поліморфізму ===");
            List<LinearSystem> systems = new List<LinearSystem>
            {
                new System2x2(),
                new System3x3()
            };
            Console.WriteLine($"Кількість різних систем у колекції: {systems.Count}");
            foreach (var s in systems)
                Console.WriteLine($"Тип об'єкта: {s.GetType().Name}");

            Console.WriteLine("\n✅ Програму виконано успішно.");
        }
    }
}
