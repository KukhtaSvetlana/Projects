using NUnit.Framework;
using StringFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1_StringSafe
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test_line_change()
        {
            string stroka = "'select ddd from Actors were ggg'";
            StringSafe stringFormat = new StringSafe();
            string stroka_proverka = "'''SELECT ddd from actors were ggg'''";
            Assert.AreEqual(stroka_proverka, stringFormat.SaveString(stroka));
        }
        [Test]
        public void Test_line_zirov()
        {
            string stroka = "";
            StringSafe stringFormat = new StringSafe();
            string stroka_proverka = "";
            Assert.AreEqual(stroka_proverka, stringFormat.SaveString(stroka));
        }
        [Test]
        public void Test_line_number()
        {
            string stroka = "444";
            StringSafe stringFormat = new StringSafe();
            string stroka_proverka = "Это число";
            Assert.AreEqual(stroka_proverka, stringFormat.SaveString(stroka));
        }
        [Test]   
        public void Test_line_null()
        {
            string stroka = null;
            StringSafe stringFormat = new StringSafe();
            Assert.Throws<NullReferenceException>(()=>stringFormat.SaveString(stroka));
        }
        [Test]
        public void Test_line_()
        {
            string stroka = "text's";
            StringSafe stringFormat = new StringSafe();
            string stroka_proverka = "text's";
            Assert.AreEqual(stroka_proverka, stringFormat.SaveString(stroka));
        }
        [Test]
        public void Test_line()
        {
            string stroka = "' '";
            StringSafe stringFormat = new StringSafe();
            string stroka_proverka = "''' '''";
            Assert.AreEqual(stroka_proverka, stringFormat.SaveString(stroka));
        }
        [Test]
        public void Test_line_ToLover()
        {
            string stroka = "'Select ddd from Actors were ggg'";
            StringSafe stringFormat = new StringSafe();
            string stroka_proverka = "'''SELECT ddd from actors were ggg'''";
            Assert.AreEqual(stroka_proverka, stringFormat.SaveString(stroka));
        }
    }
}
