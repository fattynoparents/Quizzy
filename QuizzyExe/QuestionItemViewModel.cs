using ObjectLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzyExe
{
    public class QuestionItemViewModel : INotifyPropertyChanged
    {
        private QuestionItem question;
        public QuestionItem Question
        {
            get { return question; }
        }

        private List<AnswerItemViewModel> answers;
        public List<AnswerItemViewModel> Answers
        {
            get { return answers; }
        }
      
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public int Number
        {
            get { return question.Number; }
            set
            {
                question.Number = value;
                OnPropertyChanged("Number");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public string Body
        {
            get { return question.Body; }
            set
            {
                question.Body = value;
                OnPropertyChanged("Body");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public QuestionItemViewModel(QuestionItem q)
        {
            question = q;
            answers = new List<AnswerItemViewModel>();
            foreach (AnswerItem ans in question.Answers)
            {
                answers.Add(new AnswerItemViewModel(ans, this));
            }
        }

       
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private bool answersAreCheckBoxes;
        public bool AnswersAreCheckBoxes
        {
            get 
            {
                if (IsUnanswered)
                {
                    return answersAreCheckBoxes;
                }
                else
                {
                    return Question.Answers.Where(x => x.MarkedCorrect == true).Count() > 1;
                }
            }
            set
            {
                answersAreCheckBoxes = value;
                OnPropertyChanged("IsCheckBox");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public bool IsUnanswered { get; set; }

        //// ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        //private string questionStatus;
        //public string QuestionStatus
        //{
        //    get { return questionStatus; }
        //    set
        //    {
        //        questionStatus = value;
        //        OnPropertyChanged("QuestionStatus");
        //    }
        //}

        private bool answeredCorrect;
        public bool AnsweredCorrect
        {
            get { return answeredCorrect; }
            set
            {
                answeredCorrect = value;
                OnPropertyChanged("AnsweredCorrect");
            }
        }


      

     


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        

    }
}
