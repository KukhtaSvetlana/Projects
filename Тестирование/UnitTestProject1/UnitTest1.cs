using System;
using Array_Procesor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringFormat;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Delete_repeating_elements()
        {
            int[] X = { -5,-5,-5,-5,-5};
            int[] Y = new int[X.Length];
            ArrayProcessor array = new ArrayProcessor();
            Y = array.SortAndFilter(X);
            Assert.AreEqual(-5, Y[0]);
        }
        [TestMethod]
        public void Sort_elements()
        {
            int[] X = { -5, -2, -8, 10, 11, 45 };
            int[] Y = new int[X.Length];
            ArrayProcessor array = new ArrayProcessor();
            Y = array.SortAndFilter(X);
            int[] X1 = { -8, -5, -2, 10, 11, 45 };
            CollectionAssert.AreEqual(X1,Y);
        }
        [TestMethod]
        public void Test_elements_Array()
        {
            ArrayProcessor array = new ArrayProcessor();
            int[] X = { -5, -2, -2, -2, -8, -5, 10, 11, 11, 45 };
            int a = array.SortAndFilter(X).Length;
            int[] Y = new int[a];
            Y = array.SortAndFilter(X);
            int[] X1 = { -8, -5, -2, 10, 11, 45 };
            CollectionAssert.AreEquivalent(X1, Y);
        }
        [TestMethod]
        public void Test_array_()
        {
            ArrayProcessor array = new ArrayProcessor();
            int[] X = { -5, -2, -2, -2, -8, -5, 10, 11, 11, 45 };
            int a = array.SortAndFilter(X).Length;
            int[] Y = new int[a];
            Y = array.SortAndFilter(X);
            int[] X1 = { -8, -5, -2, 10, 11, 45 };
            CollectionAssert.AreEquivalent(X1, Y);
        }
    }
}
