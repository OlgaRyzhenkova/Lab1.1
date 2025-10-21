using Lab11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Tests
{
    public class TEPyramidTests
    {
        [Fact]
        public void Constructor_Negative_Height_ResetsTo1()
        {
            var p = new TEPyramid(7, -3);
            Assert.Equal(1, p.Height);
        }

        [Fact]
        public void Set_Height_Negative_ResetsTo1()
        {
            var p = new TEPyramid(5, 4);
            p.Height = -100;
            Assert.Equal(1, p.Height);
        }

        [Fact]
        public void Volume_Correct()
        {
            var t = new TETriangle(3);
            var p = new TEPyramid(t, 6);
            double expected = 1.0 / 3.0 * t.Area() * 6;
            Assert.InRange(p.Volume(), expected - 0.0001, expected + 0.0001);
        }

        [Fact]
        public void ToString_Contains_Height_And_Volume()
        {
            var p = new TEPyramid(2, 3);
            var str = p.ToString();
            Assert.Contains("Висота", str);
            Assert.Contains("Об'єм", str);
        }

        [Fact]
        public void Inherited_Triangle_Methods_Work()
        {
            var p = new TEPyramid(2, 5);
            Assert.Equal(6, p.Perimeter());
            Assert.True(p.Area() > 0);
        }
    }
}
