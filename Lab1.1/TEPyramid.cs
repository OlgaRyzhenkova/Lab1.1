using Lab11;
using System;

namespace Lab11
{
    public class TEPyramid : TETriangle
    {
        private double height;

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    height = 1;
                }
            }
        }

        public TEPyramid(double side, double h) : base(side)
        {
            Height = h;
        }

        public TEPyramid(TETriangle baseTriangle, double h) : base(baseTriangle)
        {
            Height = h;
        }

        public double Volume()
        {
            double baseArea = Area();
            return (1.0 / 3.0) * baseArea * height;
        }

        public override string ToString()
        {
            return base.ToString() + ", Висота = " + height + ", Об'єм = " + Volume();
        }
    }
}
