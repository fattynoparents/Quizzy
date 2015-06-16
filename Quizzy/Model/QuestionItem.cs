using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzy
{
    [Serializable]
    public class QuestionItem
    {
        public string QuestionBody { get; set; }
        public int QuestionNumber { get; set; }

        List<AnswerItem> answers = new List<AnswerItem>();
        public List<AnswerItem> Answers
        {
            get { return answers; }
        }
    }
}
