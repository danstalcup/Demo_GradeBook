using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBook.Test.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(87.1f, grades[2]);
        }

        private void AddGrades(float[] grades)
        {
            grades[0] = 37.1f;
            grades[1] = 90;
            grades[2] = 87.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "dan";
            name.ToUpper(); // immutable
            Assert.AreEqual(name,"dan");            
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2000,6,9);
            date = date.AddDays(1); // immutable but set to reference

            Assert.AreEqual(date.Day,10);
        }

        [TestMethod]
        public void OutKeywordPassesPointerToValue()
        {
            int x = 5;
            OutZeroifyNumber(out x);
            Assert.AreEqual(x, 0);
        }

        private void OutZeroifyNumber(out int number)
        {
            number = 0;
        }

        [TestMethod]
        public void RefKeywordPassesPointerToValue()
        {
            int x = 5;
            RefIncrementNumber(ref x);
            Assert.AreEqual(x,6);
        }

        private void RefIncrementNumber(ref int number)
        {
            number++;
        }

        [TestMethod]
        public void ValueTypePassesByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46,x);
        }

        private void IncrementNumber(int number)
        {
            //copy is passed
            number++;
        }

        [TestMethod]
        public void ReferenceTypePassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);

            Assert.AreEqual(book1.Name, "Testy 1");
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "Testy 1";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string s1 = "dan";
            string s2 = "Dan";
            bool isEqual = string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);

            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Dan's 1";
            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1,x2);
        }
    }
}
