using ObjectLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace QuizzyExe
{
    public class AnswerItemViewModel : INotifyPropertyChanged
    {
        private AnswerItem answerModel;
        public QuestionItemViewModel CurrentQuestionItemViewModel { get; set; }
        public AnswerItem AnswerModel
        {
            get { return answerModel; }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public AnswerItemViewModel(AnswerItem aItem, QuestionItemViewModel curQuestion)
        {
            answerModel = aItem;
            CurrentQuestionItemViewModel = curQuestion;
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public bool MarkedCorrect
        {
            get { return answerModel.MarkedCorrect; }
            set
            {
                answerModel.MarkedCorrect = value;
                OnPropertyChanged("MarkedCorrect");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private bool showCorrect;
        public bool ShowCorrect 
        {
            get 
            {
                return showCorrect;
            }
            set
            {
                showCorrect = value;
                OnPropertyChanged("ShowCorrect");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public string Value
        {
            get { return answerModel.Value; }
            set
            {
                answerModel.Value = value;
                OnPropertyChanged("Value");
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
