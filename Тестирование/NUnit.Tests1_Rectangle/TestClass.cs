using NUnit.Framework;
using Rectangle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace NUnit.Tests1_Rectangle
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test_in_equality()
        {
            string x = "-4 -4 6 6";
            string y = "-2 3 3 -2";
            Rectangl rectangle = new Rectangl(x, y);
            double rect = Math.Round(rectangle.Diagonal());
            double rez = 11;
            Assert.AreEqual(rez, rect);

        }
        [Test]
        public void Test_on_expected()
        {
            string x = "4 4 6 6";
            string y = "0 2 2 0";
            Rectangl rectangle = new Rectangl(x, y);

            Assert.Throws<ArgumentException>(() => Math.Round(rectangle.Diagonal()));
        }
    }
}
