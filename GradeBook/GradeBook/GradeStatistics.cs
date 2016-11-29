using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;

        }
        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;

        public string Description
        {
            get
            {
                string result;
                switch (LetterGrade)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;
                    default:
                        result = "Failing";
                        break;
                }
                return result;
            }
        }

        public string LetterGrade
        {
            get
            {
                string result;
                float roundedAverage = (float)Math.Round(AverageGrade);
                if (roundedAverage >= 90)
                {
                    result = "A";
                }
                else if (roundedAverage >= 80)
                {
                    result = "B";
                }
                else if (roundedAverage >= 70)
                {
                    result = "C";
                }
                else if (roundedAverage >= 60)
                {
                    result = "D";
                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }
    }
}
