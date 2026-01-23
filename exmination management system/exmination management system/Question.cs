namespace ExaminationManagementSystem
{
    public abstract class Question
    {
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public string StudentAnswer { get; set; }
        public string Level { get; set; }
        public int Mark { get; set; }
        public int StudentDegree { get; protected set; }

        public virtual void CheckAnswer()
        {
            if (StudentAnswer == CorrectAnswer)
                StudentDegree = Mark;
            else
                StudentDegree = 0;
        }
    }
}
