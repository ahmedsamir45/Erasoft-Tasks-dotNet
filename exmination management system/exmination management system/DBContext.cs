using System.Collections.Generic;

namespace ExaminationManagementSystem
{
    public class DBContext
    {
     
        private static DBContext _instance;

        public static DBContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DBContext();

                return _instance;
            }
        }

        
        private DBContext() { }

        public List<WritingQuestion> WritingQuestions { get; } = new();
        public List<TrueOrFalseQuestion> TrueOrFalseQuestions { get; } = new();
        public List<ChoicesQuestion> ChoicesQuestions { get; } = new();
    }
}
