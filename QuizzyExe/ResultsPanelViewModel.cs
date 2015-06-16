using CommonResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzyExe
{
    public class ResultsPanelViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<QuestionItemViewModel> userResults;
        private ObservableCollection<QuestionItemViewModel> correctResults;

        public ResultsPanelViewModel()
        {
        }

        public ResultsPanelViewModel(ObservableCollection<QuestionItemViewModel> userResults, ObservableCollection<QuestionItemViewModel> correctResults)
        {
            // TODO: Complete member initialization
            this.userResults = userResults;
            this.correctResults = correctResults;
            FillCorrespondenceDictionary();
            QuizResultsDescription = "Below are the quiz results. Correct answers: " + userResults.Where(x => x.AnsweredCorrect == true).Count() + " from " + correctResults.Count();
        }

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void FillCorrespondenceDictionary()
        {
            for (int i = 0; i < correctResults.Count; i++)
            {
                QuestionItemViewModel qItem = correctResults[i];

                var correctAnswers = qItem.Answers.Select(y => new { y.AnswerModel.Number, y.AnswerModel.MarkedCorrect }).Where(y => y.MarkedCorrect == true).ToList();
                var userAnswers = userResults[i].Answers.Select(x => new { x.AnswerModel.Number, x.AnswerModel.MarkedCorrect }).Where(x => x.MarkedCorrect == true).ToList();

                userResults[i].AnsweredCorrect = Enumerable.SequenceEqual(correctAnswers, userAnswers);
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private string quizResultsDescription;
        public string QuizResultsDescription
        {
            get { return quizResultsDescription; }
            set
            {
                quizResultsDescription = value;
                OnPropertyChanged("QuizResultsDescription");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public ObservableCollection<QuestionItemViewModel> Results
        {
            get
            {
                if (SourceChanged)
                {

                    foreach (var joinedItem in (from j in userResults
                                                join c in correctResults
                                                on j.Number equals c.Number
                                                select new { j, c }))
                    {
                        foreach (var jAnswer in joinedItem.j.Answers)
                        {
                            foreach (var cAnswer in joinedItem.c.Answers.Where(x => x.AnswerModel.Number == jAnswer.AnswerModel.Number &&
                                                                                    x.MarkedCorrect == true))
                            {
                                jAnswer.ShowCorrect = true;
                            }
                        }

                    }
                }
               
                return userResults;
                
            }
        }
       
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----    
        private RelayCommand seeCorrectAnswersCommand;
        public RelayCommand SeeCorrectAnswersCommand
        {
            get
            {
                if (seeCorrectAnswersCommand == null)
                {
                    seeCorrectAnswersCommand = new RelayCommand("Next question", p => this.SeeCorrectAnswers());
                }
                return seeCorrectAnswersCommand;
            }
        }

        public bool SourceChanged { get; set; }
        private void SeeCorrectAnswers()
        {
            SourceChanged = true;
            OnPropertyChanged("Results");
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
