using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzy
{    
    [Serializable]
    public class AnswerItem
    {
        public int Number { get; set; }
        public string Value { get; set; }
        public bool IsCorrect { get; set; }
    }
}
