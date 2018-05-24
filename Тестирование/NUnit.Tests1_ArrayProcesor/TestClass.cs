using Array_Procesor;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1_ArrayProcesor
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Delete_repeating_elements()
        {
            int[] X = { -5, -5, -5, -5, -5 };
            int[] Y = new int[X.Length];
            ArrayProcessor array = new ArrayProcessor();
            Y = array.SortAndFilter(X);
            Assert.AreEqual(-5, Y[0]);
        }
        [Test]
        public void Sort_elements()
        {
            int[] X = { -5, -2, -8, 10, 11, 45 };
            int[] Y = new int[X.Length];
            ArrayProcessor array = new ArrayProcessor();
            Y = array.SortAndFilter(X);
            Array.Sort(X);
            CollectionAssert.AreEqual(X, Y);
        }
        [Test]
        public void Test_elements_Array()
        {
            ArrayProcessor array = new ArrayProcessor();
            int[] X = { -5, -2, -2, -2, -8, -5, 10, 11, 11, 45 };
            int[] B = { -5, -2, -8, 10, 11, 45 };
            int a = array.SortAndFilter(X).Length;
            int[] Y = new int[a];
            Y = array.SortAndFilter(X);
            Array.Sort(B);
            CollectionAssert.AreEquivalent(B, Y);
        }
    }
}
