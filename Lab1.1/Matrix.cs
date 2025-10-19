using Lab11;
using System;

namespace Lab11
{
    public class Matrix
    {
        private int[,] data;
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentException("Розміри матриці повинні бути > 0.");
            }
            Rows = rows;
            Cols = cols;
            data = new int[rows, cols];
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Cols)
                {
                    throw new IndexOutOfRangeException("Некоректні індекси.");
                }
                return data[i, j];
            }
            set
            {
                if (i < 0 || i >= Rows || j < 0 || j >= Cols)
                {
                    throw new IndexOutOfRangeException("Некоректні індекси.");
                }
                data[i, j] = value;
            }
        }

        public void InputManual()
        {
            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write("[" + i + "," + j + "] = ");
                    string line = Console.ReadLine();
                    int value;
                    if (!int.TryParse(line, out value))
                    {
                        value = 0;
                    }
                    data[i, j] = value;
                }
            }
        }

        public void FillRandom(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue > maxValue");
            }
            Random rnd = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    data[i, j] = rnd.Next(minValue, maxValue + 1);
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Матриця:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int MaxElement()
        {
            int max = data[0, 0];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (data[i, j] > max)
                    {
                        max = data[i, j];
                    }
                }
            }
            return max;
        }

        public int MinElement()
        {
            int min = data[0, 0];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (data[i, j] < min)
                    {
                        min = data[i, j];
                    }
                }
            }
            return min;
        }
    }
}
