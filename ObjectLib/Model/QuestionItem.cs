using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLib
{
    [Serializable]
    public class QuestionItem
    {
        public string Body { get; set; }
        public int Number { get; set; }

        List<AnswerItem> answers = new List<AnswerItem>();
        public List<AnswerItem> Answers
        {
            get { return answers; }
        }

    }
}
