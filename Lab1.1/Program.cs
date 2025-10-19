using System;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1 - Matrix");
                Console.WriteLine("2 - TETriangle + TEPyramid");
                Console.WriteLine("3 - Вийти");
                Console.Write("Виберіть пункт меню: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TestMatrix();
                        break;

                    case "2":
                        TestTETriangleAndPyramid();
                        break;

                    case "3":
                        Console.WriteLine("Завершення.");
                        return;

                    default:
                        Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine("\nДля повернення в меню натисніть Enter...");
                Console.ReadLine();
            }
        }

        static void TestMatrix()
        {
            try
            {
                int rows = ReadPositiveInt("Кількість рядків: ", 2);
                int cols = ReadPositiveInt("Кількість стовпців: ", 2);
                Matrix matrix = new Matrix(rows, cols);

                Console.WriteLine("1 - ручне введення");
                Console.WriteLine("2 - випадкове заповнення");
                Console.Write("Виберіть 1 або 2: ");
                string choiceVid = Console.ReadLine();

                if (choiceVid == "1")
                {
                    matrix.InputManual();
                }
                else if (choiceVid == "2")
                {
                    int minValue = ReadIntWithDefault("Мінімальна межа заповнення: ", 0);
                    int maxValue = ReadIntWithDefault("Максимальна межа заповнення: ", 10);
                    if (minValue > maxValue)
                    {
                        int tmp = minValue;
                        minValue = maxValue;
                        maxValue = tmp;
                    }
                    matrix.FillRandom(minValue, maxValue);
                }
                else
                {
                    Console.WriteLine("Неправильний вибір.");
                    return;
                }

                matrix.Print();
                Console.WriteLine("Max = " + matrix.MaxElement());
                Console.WriteLine("Min = " + matrix.MinElement());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void TestTETriangleAndPyramid()
        {
            Console.Write("Введіть сторону трикутника: ");
            double side;
            if (!double.TryParse(Console.ReadLine(), out side) || side <= 0)
            {
                Console.WriteLine("Некоректне значення, буде використано 1.");
                side = 1;
            }
            TETriangle t = new TETriangle(side);
            Console.WriteLine("Рівносторонній трикутник: Сторона = " + t.Side +
                ", Периметр = " + t.Perimeter() +
                ", Площа = " + t.Area());

            Console.Write("Введіть висоту піраміди: ");
            double height;
            if (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
            {
                Console.WriteLine("Некоректне значення, буде використано 1.");
                height = 1;
            }
            TEPyramid pyramid = new TEPyramid(t, height);
            Console.WriteLine("Трикутна піраміда: Сторона основи = " + pyramid.Side +
                ", Висота = " + pyramid.Height +
                ", Площа основи = " + pyramid.Area() +
                ", Периметр основи = " + pyramid.Perimeter() +
                ", Об'єм = " + pyramid.Volume());
        }

        static int ReadPositiveInt(string prompt, int defaultValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                int v;
                if (string.IsNullOrWhiteSpace(s))
                {
                    return defaultValue;
                }
                if (int.TryParse(s, out v) && v > 0)
                {
                    return v;
                }
                Console.WriteLine("Некоректне число. Введено " + defaultValue + " за замовчуванням.");
            }
        }

        static int ReadIntWithDefault(string prompt, int defaultValue)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();
            int v;
            if (int.TryParse(s, out v))
            {
                return v;
            }
            return defaultValue;
        }
    }
}
