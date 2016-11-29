using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {


            IGradeTracker book = CreateGradeBook();


            SetGradebookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static GradeTracker CreateGradeBook()
        {

            // SpeechSynthesizer synth = new SpeechSynthesizer();
            // synth.Speak("Hello! This is a gradebook program.");

            var book = new ThrowAwayGradeBook();

            /* book.NameChanged += OnNameChanged;
               book.NameChanged += OnNameChanged2; */

            return book;
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Grade", stats.LetterGrade);
            WriteResult("Description", stats.Description);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter fileWriter = File.CreateText("grades.txt"))
            {
                book.WriteGrades(fileWriter);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void SetGradebookName(IGradeTracker book)
        {
            Console.WriteLine("Enter gradebook name");
            try
            {
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book name changed from {args.OldName} to {args.NewName}");
        }

        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Alert! Grade book name changed!");
        }

        static void WriteResult(string description, float results)
        {
            Console.WriteLine("{0}: {1:F2}",description,results);
        }

        static void WriteResult(string description, string results)
        {
            Console.WriteLine("{0}: {1}", description, results);
        }
    }
}
