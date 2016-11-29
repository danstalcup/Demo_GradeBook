using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBook.Test
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
            GradeBook book = new ThrowAwayGradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(90, result.HighestGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(10, result.LowestGrade);
        }

        [TestMethod]
        public void ComputesAverageGrade()
        {
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics result = book.ComputeStatistics();

            Assert.AreEqual(85.16, result.AverageGrade, .1);
        }

        [TestMethod]
        public void ComputesLetterGrades()
        {
            GradeBook bookA = new GradeBook();
            GradeBook bookB = new GradeBook();
            GradeBook bookC = new GradeBook();
            GradeBook bookD = new GradeBook();
            GradeBook bookF = new GradeBook();

            bookA.AddGrade(90);
            bookB.AddGrade(85);
            bookC.AddGrade(77);
            bookD.AddGrade(63);
            bookF.AddGrade(21);

            Assert.AreEqual(bookA.ComputeStatistics().LetterGrade, "A");
            Assert.AreEqual(bookB.ComputeStatistics().LetterGrade, "B");
            Assert.AreEqual(bookC.ComputeStatistics().LetterGrade, "C");
            Assert.AreEqual(bookD.ComputeStatistics().LetterGrade, "D");
            Assert.AreEqual(bookF.ComputeStatistics().LetterGrade, "F");
        }
    }
}
