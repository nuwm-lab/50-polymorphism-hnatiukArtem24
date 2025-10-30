using System;
using System.Globalization;

namespace GeometryShapes
{
 
    public struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

   
    public abstract class Shape
    {
        public abstract void Input();
        public abstract void Display();
        public abstract double Area();
    }

 
    public class Triangle : Shape
    {
        protected Point[] _vertices = new Point[3];

        public Triangle() { }

        public override void Input()
        {
            Console.WriteLine("\nВведення координат трикутника (3 вершини):");
            for (int i = 0; i < 3; i++)
            {
                _vertices[i] = ReadPoint(i + 1);
            }
        }

        public override void Display()
        {
            Console.WriteLine("\nКоординати трикутника:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: ({_vertices[i].X}; {_vertices[i].Y})");
            }
        }

        public override double Area()
        {
            double area = 0.5 * Math.Abs(
                _vertices[0].X * (_vertices[1].Y - _vertices[2].Y) +
                _vertices[1].X * (_vertices[2].Y - _vertices[0].Y) +
                _vertices[2].X * (_vertices[0].Y - _vertices[1].Y)
            );
            return area;
        }

        protected Point ReadPoint(int index)
        {
            double x, y;
            while (true)
            {
                Console.Write($"Введіть координату X{index}: ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out x))
                    break;
                Console.WriteLine("Помилка! Введіть число.");
            }

            while (true)
            {
                Console.Write($"Введіть координату Y{index}: ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out y))
                    break;
                Console.WriteLine("Помилка! Введіть число.");
            }

            return new Point(x, y);
        }
    }


    public class ConvexQuadrilateral : Shape
    {
        protected Point[] _vertices = new Point[4];

        public ConvexQuadrilateral() { }

        public override void Input()
        {
            Console.WriteLine("\nВведення координат опуклого чотирикутника (4 вершини):");
            for (int i = 0; i < 4; i++)
            {
                _vertices[i] = ReadPoint(i + 1);
            }
        }

        public override void Display()
        {
            Console.WriteLine("\nКоординати чотирикутника:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: ({_vertices[i].X}; {_vertices[i].Y})");
            }
        }

        public override double Area()
        {
           
            double sum1 = 0, sum2 = 0;
            for (int i = 0; i < 4; i++)
            {
                int j = (i + 1) % 4;
                sum1 += _vertices[i].X * _vertices[j].Y;
                sum2 += _vertices[i].Y * _vertices[j].X;
            }

            double area = 0.5 * Math.Abs(sum1 - sum2);
            return area;
        }

        protected Point ReadPoint(int index)
        {
            double x, y;
            while (true)
            {
                Console.Write($"Введіть координату X{index}: ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out x))
                    break;
                Console.WriteLine("Помилка! Введіть число.");
            }

            while (true)
            {
                Console.Write($"Введіть координату Y{index}: ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out y))
                    break;
                Console.WriteLine("Помилка! Введіть число.");
            }

            return new Point(x, y);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Обчислення площі фігури ===");
            Console.Write("Оберіть тип фігури (1 — трикутник, 2 — опуклий чотирикутник): ");

            Shape shape;

            string? choice = Console.ReadLine();
            if (choice == "1")
                shape = new Triangle();
            else if (choice == "2")
                shape = new ConvexQuadrilateral();
            else
            {
                Console.WriteLine("Невірний вибір. Завершення роботи.");
                return;
            }

         
            shape.Input();
            shape.Display();
            Console.WriteLine($"\nПлоща фігури: {shape.Area():F2}");

            Console.WriteLine("\nРоботу завершено.");
        }
    }
}
