using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using static Rectangle.Rectangle_;

namespace Test_Rectangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_in_equality()
        {
            string x = "-4 -4 6 6";
            string y = "-2 3 3 -2";
            Rectangl rectangle = new Rectangl(x, y);
            double rect = Math.Round(rectangle.Diagonal());
            double rez = 11;
            Assert.AreEqual(rez, rect);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_on_expected()
        {
            string x = "4 4 6 6";
            string y = "0 2 2 0";
            Rectangl rectangle = new Rectangl(x, y);
            double rect = Math.Round(rectangle.Diagonal());
        }
    }
}
