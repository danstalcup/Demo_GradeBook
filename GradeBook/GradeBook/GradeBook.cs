using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            _name = "New Gradebook";
            Grades = new List<float>();
        }

        public override void AddGrade(float grade)
        {
            Grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in Grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / Grades.Count;


            return stats;
        }

        public override IEnumerator GetEnumerator()
        {
            return Grades.GetEnumerator();
        }

        public override void WriteGrades(TextWriter destination)
        {
            foreach (var grade in Grades)
            {
                destination.WriteLine(grade);
            }
        }
    
        protected List<float> Grades;
    }
}
