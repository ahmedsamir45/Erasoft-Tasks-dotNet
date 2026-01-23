using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ExaminationManagementSystem
{
    public enum QuestionType
    {
        Writing = 1,
        TrueOrFalse = 2,
        Choices = 3
    }

    class Exam
    {
        public int NoQuestions { get; set; } = 2;
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public string DoctorName { get; set; }
        public string Subject { get; set; }

        private DBContext _dbContext = DBContext.Instance;


        public void IntializeExam()
        {
            Console.WriteLine("Enter Doctor Name:");
            DoctorName = Console.ReadLine();

            Console.WriteLine("Enter Subject Name:");
            Subject = Console.ReadLine();

            Console.WriteLine("How many questions?");
            string countQuestions = Console.ReadLine();

            int questionsNumber;
            if (int.TryParse(countQuestions, out questionsNumber) && questionsNumber > 0)
            {
                NoQuestions = questionsNumber;
            }
            else
            {
                Console.WriteLine("Invalid number, default value will be used.");
                NoQuestions = 2;
            }

            ExamDate = DateTime.Now;

            Console.WriteLine("\nExam Initialized Successfully!");
            Console.WriteLine($"Doctor: {DoctorName}");
            Console.WriteLine($"Subject: {Subject}");
            Console.WriteLine($"Questions Count: {NoQuestions}");
            Console.WriteLine($"Exam Date: {ExamDate}");
        }

        public void CreateQuestions()
        {
            for (int i = 0; i < NoQuestions; i++)
            {
                QuestionType type = ReadQuestionType();

                Console.Write("Enter question text: ");
                string text = Console.ReadLine();

                Console.Write("Enter level: ");
                string level = Console.ReadLine();

                Console.Write("Enter correct answer: ");
                string correctAnswer = Console.ReadLine();

                Console.Write("Enter mark: ");
                int mark = int.Parse(Console.ReadLine());

                AddQuestion(type, text, level, correctAnswer, mark);
            }
        }

        private QuestionType ReadQuestionType()
        {
            Console.WriteLine("Choose question type:");
            Console.WriteLine("1- Writing");
            Console.WriteLine("2- True or False");
            Console.WriteLine("3- Choices");

            return (QuestionType)int.Parse(Console.ReadLine());
        }

        private void AddQuestion(
            QuestionType type,
            string text,
            string level,
            string correctAnswer,
            int mark)
        {
            switch (type)
            {
                case QuestionType.Writing:
                    _dbContext.WritingQuestions.Add(new WritingQuestion
                    {
                        QuestionText = text,
                        CorrectAnswer = correctAnswer,
                        Level = level,
                        Mark = mark
                    });
                    break;


                case QuestionType.TrueOrFalse:
                    _dbContext.TrueOrFalseQuestions.Add(new TrueOrFalseQuestion
                    {
                        QuestionText = text,
                        CorrectAnswer = correctAnswer,
                        Level = level,
                        Mark = mark
                    });
                    break;

                case QuestionType.Choices:
                    var choiceQuestion = new ChoicesQuestion
                    {
                        QuestionText = text,
                        CorrectAnswer = correctAnswer,
                        Level = level,
                        Mark = mark
                    };

                    Console.Write("First choice: ");
                    choiceQuestion.FirstChoice = Console.ReadLine();

                    Console.Write("Second choice: ");
                    choiceQuestion.SecondChoice = Console.ReadLine();

                    Console.Write("Third choice: ");
                    choiceQuestion.ThirdChoice = Console.ReadLine();

                    Console.Write("Fourth choice: ");
                    choiceQuestion.FourthChoice = Console.ReadLine();

                    _dbContext.ChoicesQuestions.Add(choiceQuestion);
                    break;
            }
        }

        public void ShowQuestions()
        {
            PrintQuestions("Writing Questions", _dbContext.WritingQuestions);
            PrintQuestions("True / False Questions", _dbContext.TrueOrFalseQuestions);
            PrintChoiceQuestions();
        }

        private void PrintQuestions<T>(string title, List<T> questions)
            where T : Question
        {
            Console.WriteLine($"\n{title}");
            foreach (var q in questions)
            {
                Console.WriteLine(q.QuestionText);
                Console.WriteLine(q.Level);
                Console.WriteLine(q.Mark);
                Console.WriteLine(q.CorrectAnswer);
            }
        }

        private void PrintChoiceQuestions()
        {
            Console.WriteLine("\nChoices Questions");
            foreach (var q in _dbContext.ChoicesQuestions)
            {
                Console.WriteLine(q.QuestionText);
                Console.WriteLine(q.Mark);
                Console.WriteLine(q.Level);
                Console.WriteLine("Choices:");
                Console.WriteLine(q.FirstChoice);
                Console.WriteLine(q.SecondChoice);
                Console.WriteLine(q.ThirdChoice);
                Console.WriteLine(q.FourthChoice);
            }
        }
  
    }
}