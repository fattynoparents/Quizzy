using CommonResources;
using GongSolutions.Wpf.DragDrop;
using ObjectLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzy
{
    public class QuestionItemViewModel : INotifyPropertyChanged
    {
        private QuestionItem questionModel;
        public QuestionItem QuestionModel
        {
            get { return questionModel; }
        }
        private ObservableCollection<AnswerItemViewModel> answersList = new ObservableCollection<AnswerItemViewModel>();
        public ObservableCollection<AnswerItemViewModel> AnswersList
        {
            get { return answersList; }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public QuestionItemViewModel()
        {
            questionModel = new QuestionItem(); 
            AddAnswerChoice();
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public QuestionItemViewModel(QuestionItem qi)
        {
            questionModel = qi;
            foreach (AnswerItem ai in questionModel.Answers)
            {
                answersList.Add(new AnswerItemViewModel(ai));
                SelectedAnswer = answersList.Last();
            }
        }



        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public string QuestionBody
        {
            get { return questionModel.Body; }
            set
            {
                if (questionModel.Body != value)
                {
                    questionModel.Body = value;
                    Changed = true;
                    OnPropertyChanged("QuestionBody");
                }
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public int QuestionNumber
        {
            get { return questionModel.Number; }
            set
            {
                if (questionModel.Number != value)
                {
                    questionModel.Number = value;
                    OnPropertyChanged("QuestionNumber");
                }
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private AnswerItemViewModel selectedAnswer;
        public AnswerItemViewModel SelectedAnswer
        {
            get { return selectedAnswer; }
            set
            {
                if (selectedAnswer != value)
                {
                    selectedAnswer = value;
                    OnPropertyChanged("SelectedAnswer");
                }
            }
        }


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public bool IsCheckBox
        {
            get 
            {
                if (answersList.Where(x => x.IsCorrect).Count() > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Changed { get; set; }




        // Commands
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private RelayCommand addChoiceCommand;
        public RelayCommand AddChoiceCommand
        {
            get
            {
                if (addChoiceCommand == null)
                {
                    addChoiceCommand = new RelayCommand("Add another choice", p => this.AddAnswerChoice());
                }
                return addChoiceCommand;
            }
        }

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private RelayCommand removeChoiceCommand;
        public RelayCommand RemoveChoiceCommand
        {
            get
            {
                if (removeChoiceCommand == null)
                {
                    removeChoiceCommand = new RelayCommand("Remove the choice", p => this.RemoveItem());
                }
                return removeChoiceCommand;
            }
        }

        private void RemoveItem()
        {
            // the last item can't be removed
            if (SelectedAnswer != null && AnswersList.Count > 1)
            {
                int selectedNum = SelectedAnswer.Number;
                AnswersList.Remove(SelectedAnswer);
                // recount of answers numbering 
                for (int i = 0; i < AnswersList.Count; i++)
                {
                    AnswersList[i].Number = i + 1;
                }

                // after removing the next or the previous item is selected
                SelectedAnswer = (from ans in AnswersList
                                                  where ans.Number == selectedNum
                                                  select ans).FirstOrDefault()

                                   ??

                                   (from ans in AnswersList
                                    where ans.Number == (selectedNum - 1)
                                    select ans).FirstOrDefault();
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----



        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public void AddAnswerChoice()
        {
            AnswerItemViewModel newAnswer = new AnswerItemViewModel(this);
            answersList.Add(newAnswer);
            questionModel.Answers.Add(newAnswer.Answer);
            SelectedAnswer = newAnswer;
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

    }
}
