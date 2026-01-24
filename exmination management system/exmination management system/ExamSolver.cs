using System;
using System.IO;
namespace ExaminationManagementSystem
{
    public class ExamSolver
    {
        private DBContext _dbContext = DBContext.Instance;
        public int StudentTotal { get; set; } = 0;
        public int ExamTotal { get; set; } = 0;
        public string StudentName { get; set; } = "";
        public string FileName { get; set; } = "ExamResult";
        private static bool IsFirstExport = true;


        public void SolveExam()
        {
            Console.WriteLine("\n--- Solving Exam ---");
            IntialName();
            SolveWritingQuestions();
            SolveTrueOrFalseQuestions();
            SolveChoicesQuestions();
            CalculateTotalScore();
            PrintingScore();

            ExportToTextFile($"{this.FileName}.txt");
            ResetProp();
        }
        private void IntialName()
        {
            Console.WriteLine("Enter your name: ");
            this.StudentName = Console.ReadLine();
        }
        private void SolveWritingQuestions()
        {
            foreach (var q in _dbContext.WritingQuestions)
            {
                Console.WriteLine(q.QuestionText);
                Console.Write("Your answer: ");
                q.StudentAnswer = Console.ReadLine();
                q.CheckAnswer();
            }
        }

        private void SolveTrueOrFalseQuestions()
        {
            foreach (var q in _dbContext.TrueOrFalseQuestions)
            {
                Console.WriteLine(q.QuestionText + " (true / false)");
                Console.Write("Your answer: ");
                q.StudentAnswer = Console.ReadLine();
                q.CheckAnswer();
            }
        }

        private void SolveChoicesQuestions()
        {
            foreach (var q in _dbContext.ChoicesQuestions)
            {
                Console.WriteLine(q.QuestionText);
                Console.WriteLine("1- " + q.FirstChoice);
                Console.WriteLine("2- " + q.SecondChoice);
                Console.WriteLine("3- " + q.ThirdChoice);
                Console.WriteLine("4- " + q.FourthChoice);

                Console.Write("Your answer: ");
                q.StudentAnswer = Console.ReadLine();
                q.CheckAnswer();
            }
        }

        private void CalculateTotalScore()
        {
            
            

            foreach (var q in _dbContext.WritingQuestions)
            {

                StudentTotal += q.StudentDegree;
                ExamTotal += q.Mark;
            }

            foreach (var q in _dbContext.TrueOrFalseQuestions)
            {

                StudentTotal += q.StudentDegree;
                ExamTotal += q.Mark;

            }

            foreach (var q in _dbContext.ChoicesQuestions)
            {

                StudentTotal += q.StudentDegree;
                ExamTotal += q.Mark;

            }

          
        }
        private void PrintingScore()
        {
            Console.WriteLine($"your score is {this.StudentTotal} / {this.ExamTotal}");
        }


        private void ExportToTextFile(string filePath)
        {
         
            bool appendMode = !IsFirstExport;

            using (StreamWriter writer = new StreamWriter(filePath, appendMode))
            {
                writer.WriteLine("================================");
                writer.WriteLine($"Student Result - {DateTime.Now}");
                writer.WriteLine($"Student Name - {this.StudentName}");
                writer.WriteLine("================================");

                foreach (var q in _dbContext.WritingQuestions)
                    WriteQuestion(writer, q);

                foreach (var q in _dbContext.TrueOrFalseQuestions)
                    WriteQuestion(writer, q);

                foreach (var q in _dbContext.ChoicesQuestions)
                    WriteQuestion(writer, q);

                writer.WriteLine($"Total: {StudentTotal} / {ExamTotal}");
                writer.WriteLine("\n\n");
            }

            
            IsFirstExport = false;
        }



        private void WriteQuestion(StreamWriter writer, Question q)
    {
        writer.WriteLine($"Question: {q.QuestionText}");
        writer.WriteLine($"Student Answer: {q.StudentAnswer}");
        writer.WriteLine($"Correct Answer: {q.CorrectAnswer}");
        writer.WriteLine($"Mark: {q.StudentDegree} / {q.Mark}");
        writer.WriteLine();
    }
        private void ResetProp()
        {
            this.StudentTotal = 0;
            this.ExamTotal = 0;
            this.StudentName = "";
        }
}
}
