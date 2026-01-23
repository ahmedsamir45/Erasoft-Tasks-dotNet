namespace ExaminationManagementSystem
{
    public class TrueOrFalseQuestion : Question
    {
        public override void CheckAnswer()
        {
            if (StudentAnswer.ToLower() == CorrectAnswer.ToLower())
                StudentDegree = Mark;
            else
                StudentDegree = 0;
        }
    }
}
