using Lab11;
using System;

namespace Lab11
{
    public class TETriangle
    {
        private double side;

        public double Side
        {
            get
            {
                return side;
            }
            set
            {
                if (value > 0)
                {
                    side = value;
                }
                else
                {
                    side = 1;
                }
            }
        }

        public TETriangle()
        {
            side = 1;
        }

        public TETriangle(double s)
        {
            Side = s;
        }

        public TETriangle(TETriangle other)
        {
            side = other.side;
        }

        public double Perimeter()
        {
            return 3 * side;
        }

        public double Area()
        {
            return Math.Sqrt(3) / 4 * side * side;
        }

        public void Input()
        {
            Console.Write("Side: ");
            double temp;
            if (double.TryParse(Console.ReadLine(), out temp) && temp > 0)
            {
                side = temp;
            }
            else
            {
                side = 1;
            }
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return "Side = " + side + ", Perimeter = " + Perimeter() + ", Area = " + Area();
        }

        public static bool operator ==(TETriangle t1, TETriangle t2)
        {
            return t1.side == t2.side;
        }

        public static bool operator !=(TETriangle t1, TETriangle t2)
        {
            return t1.side != t2.side;
        }

        public static TETriangle operator *(TETriangle t, double k)
        {
            return new TETriangle(t.side * k);
        }

        public static TETriangle operator *(double k, TETriangle t)
        {
            return new TETriangle(t.side * k);
        }
    }
}
