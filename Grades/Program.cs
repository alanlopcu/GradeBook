using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program");

            GradeBook book = new GradeBook();

            //book.NameChanged += new NameChangeDelegate(OnNameChanged);
            //book.NameChanged += new NameChangeDelegate(OnNameChanged2);
            //book.NameChanged += new NameChangeDelegate(OnNameChanged2);

            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;
            //book.NameChanged += OnNameChanged2;
            //book.NameChanged -= OnNameChanged2;

            book.NameChanged += OnNameChanged;

            book.Name = "Andrew's Grade Book";
            book.Name = "Grade Book";
            book.Name = null;
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
        }

        //static void OnNameChanged(string existingName, string newName)
        //{
        //    Console.WriteLine($"Grade Book changing name from {existingName} to {newName}");
        //}

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade Book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void WriteResult(string description, float result)
        {
            //Console.WriteLine(description + ": " + result);
            //Console.WriteLine("{0}: {1:F2}", description, result); //Float rounded string
            //Console.WriteLine("{0}: {1:C}", description, result); //Currency string
            //Console.WriteLine($"{description}: {result:C}", description, result); //New format
            Console.WriteLine($"{description}: {result:C}"); //New smaller format
        }
    }
}
