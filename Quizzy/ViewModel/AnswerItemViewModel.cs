using ObjectLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzy
{
    public class AnswerItemViewModel: INotifyPropertyChanged, IEqualityComparer<AnswerItemViewModel>
    {
        private AnswerItem answer;
        private QuestionItemViewModel parentViewModel;

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public AnswerItemViewModel(QuestionItemViewModel parentVM)
        {
            parentViewModel = parentVM;
            AddNewAnswer();
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public AnswerItemViewModel(AnswerItem ai)
        {
            answer = new AnswerItem { Number = ai.Number, Value = ai.Value, MarkedCorrect = ai.MarkedCorrect };
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public AnswerItem Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public int Number
        {
            get { return answer.Number; }
            set 
            { 
                answer.Number = value;
                OnPropertyChanged("Number");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public string Value
        {
            get 
            {
                return answer.Value; 
            }
            set
            {
                if (answer.Value != value) 
                {
                    answer.Value = value;
                    Changed = true;
                    OnPropertyChanged("Value");
                }
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public bool IsCorrect
        {
            get { return answer.MarkedCorrect; }
            set
            {
                if (answer.MarkedCorrect != value)
                {
                    answer.MarkedCorrect = value;
                    Changed = true;
                    OnPropertyChanged("IsCorrect");
                }
            }
        }

        public bool Changed { get; set; }


        public void AddNewAnswer()
        {
            answer = new AnswerItem { Number = GetNextAnswerNumber(), Value = String.Empty, MarkedCorrect = false };
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private int GetNextAnswerNumber()
        {
            int answerID = Int32.MinValue;
            if (parentViewModel.AnswersList.Count > 0)
            {
                answerID = parentViewModel.AnswersList.Last().Number + 1;
            }
            else
            {
                answerID = 1;
            }
            return answerID;
        }

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----





        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public bool Equals(AnswerItemViewModel x, AnswerItemViewModel y)
        {
            if (x.Number == y.Number && x.Value == y.Value && x.IsCorrect == y.IsCorrect)
            {
                return true;
            }  
            return false;
        }

        public int GetHashCode(AnswerItemViewModel obj)
        {
            return obj.Value.GetHashCode();
        }
    }
}
