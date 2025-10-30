using System;
using System.Collections.Generic;

namespace GeometryShapes
{
    // --- Базовий клас (абстрактний) ---
    abstract class Shape
    {
        public abstract void Input();     // Введення координат
        public abstract void Display();   // Виведення вершин
        public abstract double Area();    // Обчислення площі
    }

    // --- Клас для трикутника ---
    class Triangle : Shape
    {
        protected (double X, double Y)[] vertices = new (double, double)[3];

        public override void Input()
        {
            Console.WriteLine("\nВведення координат вершин трикутника:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Вершина {i + 1} (x y): ");
                string[] parts = Console.ReadLine().Split();
                vertices[i] = (double.Parse(parts[0]), double.Parse(parts[1]));
            }
        }

        public override void Display()
        {
            Console.WriteLine("\nВершини трикутника:");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"A{i + 1} ({vertices[i].X}; {vertices[i].Y})");
        }

        public override double Area()
        {
            // Формула площі через визначник (метод "shoelace")
            double area = 0.5 * Math.Abs(
                vertices[0].X * (vertices[1].Y - vertices[2].Y) +
                vertices[1].X * (vertices[2].Y - vertices[0].Y) +
                vertices[2].X * (vertices[0].Y - vertices[1].Y)
            );
            return area;
        }
    }

    // --- Похідний клас: опуклий чотирикутник ---
    class ConvexQuadrilateral : Triangle
    {
        private (double X, double Y)[] quadVertices = new (double, double)[4];

        public override void Input()
        {
            Console.WriteLine("\nВведення координат вершин опуклого чотирикутника:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Вершина {i + 1} (x y): ");
                string[] parts = Console.ReadLine().Split();
                quadVertices[i] = (double.Parse(parts[0]), double.Parse(parts[1]));
            }
        }

        public override void Display()
        {
            Console.WriteLine("\nВершини чотирикутника:");
            for (int i = 0; i < 4; i++)
                Console.WriteLine($"B{i + 1} ({quadVertices[i].X}; {quadVertices[i].Y})");
        }

        public override double Area()
        {
            // Площа опуклого чотирикутника через формулу "shoelace"
            double sum1 = 0, sum2 = 0;
            for (int i = 0; i < 4; i++)
            {
                int j = (i + 1) % 4;
                sum1 += quadVertices[i].X * quadVertices[j].Y;
                sum2 += quadVertices[j].X * quadVertices[i].Y;
            }
            return 0.5 * Math.Abs(sum1 - sum2);
        }
    }

    // --- Головна програма ---
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Геометричні фігури ===");
            Console.WriteLine("1 — Трикутник");
            Console.WriteLine("2 — Опуклий чотирикутник");
            Console.Write("Оберіть фігуру: ");
            int userChoose = int.Parse(Console.ReadLine());

            Shape shape; // динамічний поліморфізм

            if (userChoose == 1)
                shape = new Triangle();
            else
                shape = new ConvexQuadrilateral();

            shape.Input();
            shape.Display();
            Console.WriteLine($"\nПлоща фігури = {shape.Area():F3}");

            Console.WriteLine("\nРоботу завершено.");
        }
    }
}
