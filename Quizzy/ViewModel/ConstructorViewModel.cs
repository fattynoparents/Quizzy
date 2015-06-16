using CommonResources;
using Microsoft.Win32;
using ObjectLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quizzy
{
    /// <summary>
    ///  ViewModel representing the main Constructor window for creating questions and variants of replies
    /// </summary>
    public class ConstructorViewModel : INotifyPropertyChanged
    {
        private Constructor constructorWnd;

        private ObservableCollection<QuestionItemViewModel> allQuestions = new ObservableCollection<QuestionItemViewModel>();
        public ObservableCollection<QuestionItemViewModel> AllQuestions
        {
            get { return allQuestions; }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public ConstructorViewModel()
        {
        }

        public ConstructorViewModel(Constructor constructor, ObservableCollection<QuestionItem> deserialized = null)
        {
            constructorWnd = constructor;
            if (deserialized != null)
            {
                RestoreQuiz(deserialized);
            }
            else
            {
                AddNewQuestion();
            }
        }

        private void RestoreQuiz(ObservableCollection<QuestionItem> deserialized)
        {
            foreach (QuestionItem qi in deserialized)
            {
                QuestionItemViewModel nextQuestion = new QuestionItemViewModel(qi);
                CurrentQuestion = nextQuestion;
                OnPropertyChanged("QuestionLabel");
                allQuestions.Add(nextQuestion);
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void AddNewQuestion()
        {
            QuestionItemViewModel newQuestion = new QuestionItemViewModel { QuestionNumber = allQuestions.Count + 1 };
            CurrentQuestion = newQuestion;
            OnPropertyChanged("QuestionLabel");
            allQuestions.Add(newQuestion);
        }      
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private QuestionItemViewModel currentQuestion;
        public QuestionItemViewModel CurrentQuestion
        {
            get { return currentQuestion; }
            set 
            { 
                currentQuestion = value;
                OnPropertyChanged("CurrentQuestion");
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public string QuestionLabel
        {
            get { return "Question " + CurrentQuestion.QuestionNumber.ToString(); }
        }
         
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public int PrevQuestionNumber
        {
            get { return (CurrentQuestion.QuestionNumber - 1); }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public int NextQuestionNumber
        {
            get { return (CurrentQuestion.QuestionNumber + 1); }
        }


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public bool Changed 
        {
            get 
            {
                foreach (QuestionItemViewModel curQ in allQuestions)
                {
                    if (curQ.Changed)
                    {
                        return true;
                    }
                    foreach (AnswerItemViewModel ans in curQ.AnswersList)
                    {
                        if (ans.Changed)
                        {
                            return true;
                        }
                    }
                }
                return false;                
            }

            set { } 
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
       
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        // Commands
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        //private RelayCommand closeWindowCommand;
        //public RelayCommand CloseWindowCommand
        //{
        //    get
        //    {
        //        if (closeWindowCommand == null)
        //        {
        //            closeWindowCommand = new RelayCommand("Close the window", p => this.CloseWindow());
        //        }
        //        return closeWindowCommand;
        //    }
        //}

        //private void CloseWindow()
        //{
        //    if (Changed)
        //    {
        //        MessageBoxResult res = MessageBox.Show("Would you like to save your quiz to file before leaving the program?", "Quizzy", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        //        if (res == MessageBoxResult.Yes)
        //        {
        //            SaveToFile();
        //        }
        //        else if (res == MessageBoxResult.Cancel)
        //        {
        //            CancelClose = true;
        //        }
        //    }
        //    Application.Current.MainWindow.Show();
        //}

        


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        private RelayCommand recoverNextQuestionCommand;
        public RelayCommand RecoverNextQuestionCommand
        {
            get
            {
                if (recoverNextQuestionCommand == null)
                {
                    recoverNextQuestionCommand = new RelayCommand("Recover next question", p => this.RecoverNextQuestion());
                }
                return recoverNextQuestionCommand;
            }
        }

        private void RecoverNextQuestion()
        {
            // if there exists a next question, recover it, otherwise add a new one
            if (allQuestions.Where(x => x.QuestionNumber == NextQuestionNumber).FirstOrDefault() != null)
            {
                CurrentQuestion = (from q in allQuestions
                                   where q.QuestionNumber == NextQuestionNumber
                                   select q).FirstOrDefault();
                OnPropertyChanged("QuestionLabel");

            }
            else
            {
                AddNewQuestion();
            }
        }


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        private RelayCommand recoverPrevQuestionCommand;
        public RelayCommand RecoverPrevQuestionCommand
        {
            get
            {
                if (recoverPrevQuestionCommand == null)
                {
                    recoverPrevQuestionCommand = new RelayCommand("Recover previous question", p => this.RecoverPreviousQuestion());
                }
                return recoverPrevQuestionCommand;
            }
        }

        private void RecoverPreviousQuestion()
        {
            if (PrevQuestionNumber > 0)
            {
                CurrentQuestion = (from q in allQuestions
                                   where q.QuestionNumber == PrevQuestionNumber
                                   select q).FirstOrDefault();

                OnPropertyChanged("QuestionLabel");

            }
        }

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        private RelayCommand goToFirstQuestionCommand;
        public RelayCommand GoToFirstQuestionCommand
        {
            get
            {
                if (goToFirstQuestionCommand == null)
                {
                    goToFirstQuestionCommand = new RelayCommand("Go to first question", p => this.GoToFirstQuestion());
                }
                return goToFirstQuestionCommand;
            }
        }

        private void GoToFirstQuestion()
        {
            CurrentQuestion = allQuestions.First();
            OnPropertyChanged("QuestionLabel");
        }


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        private RelayCommand goToLastQuestionCommand;
        public RelayCommand GoToLastQuestionCommand
        {
            get
            {
                if (goToLastQuestionCommand == null)
                {
                    goToLastQuestionCommand = new RelayCommand("Go to last question", p => this.GoToLastQuestion());
                }
                return goToLastQuestionCommand;
            }
        }

        private void GoToLastQuestion()
        {
            CurrentQuestion = allQuestions.Last();
            OnPropertyChanged("QuestionLabel");
        }


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        private RelayCommand finishQuizCommand;
        public RelayCommand FinishQuizCommand
        {
            get
            {
                if (finishQuizCommand == null)
                {
                    finishQuizCommand = new RelayCommand("Finish Quiz", p => this.FinishQuiz());
                }
                return finishQuizCommand;
            }
        }

        private void FinishQuiz()
        {
            PreviewQuiz previewWnd = new PreviewQuiz();
            PreviewQuizVewModel previewVM = new PreviewQuizVewModel(previewWnd, allQuestions);
            previewWnd.DataContext = previewVM;
            previewWnd.Owner = constructorWnd;
            previewWnd.Show();

            constructorWnd.Hide();
        }

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        private RelayCommand saveTemplateCommand;
        public RelayCommand SaveTemplateCommand
        {
            get
            {
                if (saveTemplateCommand == null)
                {
                    saveTemplateCommand = new RelayCommand("Save to file", p => this.SaveToFile());
                }
                return saveTemplateCommand;
            }
        }

        public void SaveToFile()
        {
            List<QuestionItem> questsForSerialization = (from q in allQuestions
                                                         select q.QuestionModel).ToList();
            byte[] questions = Serializer.Serialize(questsForSerialization);

            SaveFileDialog sfd = new SaveFileDialog { Filter = "Qzz files (*.qzz)|*.qzz", CheckPathExists = true };
            if (sfd.ShowDialog() == true)
            {
                File.WriteAllBytes(sfd.FileName, questions);
                Changed = false;
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
