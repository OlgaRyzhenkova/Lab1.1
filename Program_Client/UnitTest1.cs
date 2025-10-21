using Xunit;
using Lab11;
using System;

namespace Lab11.Tests
{
    public class TETriangleTests
    {
        [Fact]
        public void Perimeter_Correct()
        {
            var t = new TETriangle(3);
            Assert.Equal(9, t.Perimeter());
        }

        [Fact]
        public void Area_Correct()
        {
            var t = new TETriangle(2);
            double expected = Math.Sqrt(3) / 4 * 4;
            Assert.InRange(t.Area(), expected - 0.0001, expected + 0.0001);
        }

        [Fact]
        public void Constructor_Negative_Side_ResetsTo1()
        {
            var t = new TETriangle(-5);
            Assert.Equal(1, t.Side);
        }

        [Fact]
        public void Property_Negative_Set_ResetsTo1()
        {
            var t = new TETriangle(8);
            t.Side = -10;
            Assert.Equal(1, t.Side);
        }

        [Fact]
        public void Copy_Constructor_Correct()
        {
            var t = new TETriangle(5);
            var copy = new TETriangle(t);
            Assert.Equal(t.Side, copy.Side);
        }

        [Fact]
        public void Operator_Equality_Works()
        {
            var t1 = new TETriangle(7);
            var t2 = new TETriangle(7);
            var t3 = new TETriangle(9);
            Assert.True(t1 == t2);
            Assert.True(t1 != t3);
        }

        [Fact]
        public void Operator_Mul_Left_Right_Works()
        {
            var t = new TETriangle(4);
            Assert.Equal(8, (t * 2).Side);
            Assert.Equal(12, (3 * t).Side);
        }

        [Fact]
        public void ToString_Contains_Side()
        {
            var t = new TETriangle(5);
            var str = t.ToString();
            Assert.Contains("Сторона", str);
        }
    }
}
