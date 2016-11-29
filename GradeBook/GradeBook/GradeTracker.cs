using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract  void WriteGrades(TextWriter writer);
        public abstract IEnumerator GetEnumerator();
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs { NewName = value, OldName = _name };
                    NameChanged?.Invoke(this, args); // "Elvis operator"
                }
                _name = value;

            }
        }

        public event NameChangedDelegate NameChanged;

        protected string _name;
    }
}
