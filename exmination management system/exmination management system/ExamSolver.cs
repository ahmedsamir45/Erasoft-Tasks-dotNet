using System;

namespace ExaminationManagementSystem
{
    public class ExamSolver
    {
        private DBContext _dbContext = DBContext.Instance;
        public int StudentTotal { get; set; } = 0;
        public int ExamTotal { get; set; } = 0;
        public void SolveExam()
        {
            Console.WriteLine("\n--- Solving Exam ---");

            SolveWritingQuestions();
            SolveTrueOrFalseQuestions();
            SolveChoicesQuestions();
            CalculateTotalScore();
            PrintingScore();
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
    }
}
