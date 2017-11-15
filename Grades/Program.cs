using System;
using System.Collections.Generic;
using System.IO;
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

            //GradeBook book = new GradeBook();

            //book.NameChanged += new NameChangeDelegate(OnNameChanged);
            //book.NameChanged += new NameChangeDelegate(OnNameChanged2);
            //book.NameChanged += new NameChangeDelegate(OnNameChanged2);

            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;
            //book.NameChanged += OnNameChanged2;
            //book.NameChanged -= OnNameChanged2;

            //book.NameChanged += OnNameChanged;

            //book.Name = "Andrew's Grade Book";
            //book.Name = "Grade Book";
            //book.Name = null;

            GradeBook book = new GradeBook();

            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResult(book);
        }

        private static void WriteResult(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            //Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            //WriteResult("Grade", stats.LetterGrade);
            WriteResult(stats.Description, stats.LetterGrade);
            //WriteResult("Highest", (int)stats.HighestGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                //book.WriteGrades(Console.Out);
                //outputFile.Close();
                //outputFile.Dispose();
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name: ");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something went wrong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //static void OnNameChanged(string existingName, string newName)
        //{
        //    Console.WriteLine($"Grade Book changing name from {existingName} to {newName}");
        //}

        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade Book changing name from {args.ExistingName} to {args.NewName}");
        //}

        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, float result)
        {
            //Console.WriteLine(description + ": " + result);
            //Console.WriteLine("{0}: {1:F2}", description, result); //Float rounded string
            //Console.WriteLine("{0}: {1:C}", description, result); //Currency string
            //Console.WriteLine($"{description}: {result:C}", description, result); //New format
            Console.WriteLine($"{description}: {result:F2}"); //New smaller format
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}"); //New smaller format
        }
    }
}
