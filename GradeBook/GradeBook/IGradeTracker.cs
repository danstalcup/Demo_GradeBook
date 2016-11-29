using System.Collections;
using System.IO;

namespace GradeBook
{
    public interface IGradeTracker : IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter writer);
        string Name { get; set; }
    }
}