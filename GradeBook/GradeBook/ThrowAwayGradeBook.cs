using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {           
            Grades.Remove(base.ComputeStatistics().LowestGrade);
            return base.ComputeStatistics();
        }
    }
}
