using CommonResources;
using ObjectLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace QuizzyExe
{
    public class MainWindowViewModel : CloseableViewModel, INotifyPropertyChanged
    {
        private byte[] title;
        private byte[] description;
        private byte[] questions;


        // correct results of the quiz (including correct answers to questions)
        private ObservableCollection<QuestionItemViewModel> correctResults = new ObservableCollection<QuestionItemViewModel>();
        public ObservableCollection<QuestionItemViewModel> CorrectResults
        {
            get { return correctResults; }
        }

        // collection which keeps the results provided by a person taking the quiz
        private ObservableCollection<QuestionItemViewModel> userResults = new ObservableCollection<QuestionItemViewModel>();
        public ObservableCollection<QuestionItemViewModel> UserResults
        {
            get { return userResults; }
        }


        private Dictionary<int, List<bool>> correspondenceDictionary = new Dictionary<int, List<bool>>();
        public Dictionary<int, List<bool>> CorrespondenceDictionary
        {
            get { return correspondenceDictionary; }
        }


        public MainWindowViewModel()
        {
            ReadDataFromAssembly();
            FillDeserializedData();

            // TODO: Remove debugging info
            //QuizDescription = "A test quiz for testing the tested person in the abilities to give correct test answers to the test quiz questions";
            //byte[] questions = File.ReadAllBytes("D:\\bytes.txt");

            //if (questions != null)
            //{
            //    ObservableCollection<QuestionItem> deserialiazedResults = new ObservableCollection<QuestionItem>(Serializer.BinaryDeserialize(questions) as IEnumerable<QuestionItem>);
            //    if (deserialiazedResults != null)
            //    {
            //        FillQuestionViewModel(deserialiazedResults);
            //    }
            //}
            ///////////////////////////////

            FillDataToBeAnswered();

            FirstQuestionShown = true;


        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void FillDataToBeAnswered()
        {
            foreach (QuestionItemViewModel q in correctResults)
            {
                QuestionItem currentQuestion = new QuestionItem
                {
                    Number = q.Question.Number,
                    Body = q.Question.Body
                };

                foreach (AnswerItem a in q.Question.Answers)
                {
                    AnswerItem currentAnswer = new AnswerItem
                    {
                        Number = a.Number,
                        Value = a.Value,
                        MarkedCorrect = false
                    };
                    currentQuestion.Answers.Add(currentAnswer);
                }

                QuestionItemViewModel quizQuestion = new QuestionItemViewModel(currentQuestion);
                quizQuestion.IsUnanswered = true;
                quizQuestion.AnswersAreCheckBoxes = q.AnswersAreCheckBoxes;

                userResults.Add(quizQuestion);
            }

            if (userResults.Any())
            {
                CurrentSelectedQuestion = userResults.First();
            }
            if (userResults.Count == 1)
            {
                LastQuestionShown = true;
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void ReadDataFromAssembly()
        {
            var res = Assembly.GetExecutingAssembly().GetManifestResourceStream("Title");

            if (res != null)
            {
                byte[] buff = new byte[res.Length];
                res.Read(buff, 0, buff.Length);

                title = buff;
            }

            res = Assembly.GetExecutingAssembly().GetManifestResourceStream("Description");

            if (res != null)
            {
                byte[] buff = new byte[res.Length];
                res.Read(buff, 0, buff.Length);

                description = buff;
            }

            res = Assembly.GetExecutingAssembly().GetManifestResourceStream("Questions");

            if (res != null)
            {
                byte[] buff = new byte[res.Length];
                res.Read(buff, 0, buff.Length);

                questions = buff;
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void FillDeserializedData()
        {
            if (title != null)
            {
                WndTitle = Serializer.BinaryDeserialize(title).ToString();
            }
            if (description != null)
            {
                QuizDescription = Serializer.BinaryDeserialize(description).ToString();
            }
            if (questions != null)
            {
                ObservableCollection<QuestionItem> deserialiazedResults = new ObservableCollection<QuestionItem>(Serializer.BinaryDeserialize(questions) as IEnumerable<QuestionItem>);
                if (deserialiazedResults != null)
                {
                    FillQuestionViewModel(deserialiazedResults);
                }
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void FillQuestionViewModel(ObservableCollection<QuestionItem> deserQuestions)
        {
            foreach (QuestionItem q in deserQuestions)
            {
                QuestionItemViewModel qVM = new QuestionItemViewModel(q);
                correctResults.Add(qVM);
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----



        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private string windowTitle;
        public string WndTitle
        {
            get
            {
                return windowTitle;
            }
            set
            {
                windowTitle = value;
                OnPropertyChanged("WndTitle");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private string quizDescription;
        public string QuizDescription 
        {
            get { return quizDescription; }
            set
            {
                quizDescription = value;
                OnPropertyChanged("QuizDescription");
            }
        }
       

        

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private QuestionItemViewModel currentSelectedQuestion;
        public QuestionItemViewModel CurrentSelectedQuestion
        {
            get { return currentSelectedQuestion; }
            set
            {
                if (currentSelectedQuestion != value)
                {
                    currentSelectedQuestion = value;
                    OnPropertyChanged("CurrentSelectedQuestion");
                }
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public bool ResultsExist
        {
            get { return userResults.Any(); }
        }
       

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----    
        private RelayCommand nextQuestionCommand;
        public RelayCommand NextQuestionCommand
        {
            get
            {
                if (nextQuestionCommand == null)
                {
                    nextQuestionCommand = new RelayCommand("Next question", p => this.GoToNextQuestion());
                }
                return nextQuestionCommand;
            }
        }

        private void GoToNextQuestion()
        {
            FirstQuestionShown = false;
            OnPropertyChanged("FirstQuestionShown");

            CurrentSelectedQuestion = userResults.Where(x => x.Number == CurrentSelectedQuestion.Number + 1).FirstOrDefault();
            if (CurrentSelectedQuestion == userResults.Last())
            {
                LastQuestionShown = true;
                OnPropertyChanged("LastQuestionShown");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----    
        private RelayCommand prevQuestionCommand;
        public RelayCommand PrevQuestionCommand
        {
            get
            {
                if (prevQuestionCommand == null)
                {
                    prevQuestionCommand = new RelayCommand("Previous question", p => this.GoToPrevQuestion());
                }
                return prevQuestionCommand;
            }
        }

        private void GoToPrevQuestion()
        {
            LastQuestionShown = false;
            OnPropertyChanged("LastQuestionShown");

            CurrentSelectedQuestion = userResults.Where(x => x.Number == CurrentSelectedQuestion.Number - 1).FirstOrDefault();
            if (CurrentSelectedQuestion == userResults.First())
            {
                FirstQuestionShown = true;
                OnPropertyChanged("FirstQuestionShown");
            }
        }      
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        private RelayCommand seeResultsCommand;
        public RelayCommand SeeResultsCommand
        {
            get
            {
                if (seeResultsCommand == null)
                {
                    seeResultsCommand = new RelayCommand("See results", p => this.SeeResults());
                }
                return seeResultsCommand;
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void SeeResults()
        {
            ResultsPanel resultsWnd = new ResultsPanel();
            ResultsPanelViewModel resultsVM = new ResultsPanelViewModel(userResults, correctResults);
            resultsWnd.DataContext = resultsVM;
            OnRequestClose();
            resultsWnd.ShowDialog();
        }
       
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public bool FirstQuestionShown { get; set; }
        public bool LastQuestionShown { get; set; }
        

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


    public abstract class CloseableViewModel
    {
        public event EventHandler RequestClose;

        protected void OnRequestClose()
        {
            if (RequestClose != null)
                RequestClose(this, EventArgs.Empty);
        }
    }
}
