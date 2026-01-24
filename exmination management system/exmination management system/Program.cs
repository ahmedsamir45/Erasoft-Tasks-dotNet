using System;

namespace ExaminationManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isQuit = false;
            Exam exam = new Exam();
            ExamSolver examSolver = new ExamSolver();

            while (!isQuit)
            {
                Console.WriteLine("\nChoose your mode:");
                Console.WriteLine("1- Doctor");
                Console.WriteLine("2- Student");
                Console.WriteLine("Press 'q' to quit");

                string mode = Console.ReadLine()?.Trim().ToLower();

                switch (mode)
                {
                    case "1":
                        Console.WriteLine("\n--- Doctor Mode ---");
                        exam.IntializeExam();
                        exam.CreateQuestions();
                        exam.ShowQuestions();
                        Console.WriteLine("Enter the file Name of exporting exam reasults:");
                        string filename = Console.ReadLine();
                        examSolver.FileName = filename;
                        break;

                    case "2":
                        Console.WriteLine("\n--- Student Mode ---");
                        examSolver.SolveExam();
                        


                        break;

                    case "q":
                        Console.WriteLine("Exiting program...");
                        isQuit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please choose 1, 2, or 'q'.");
                        break;
                }
            }
        }
    }
}
