using CommonResources;
using GongSolutions.Wpf.DragDrop;
using MahApps.Metro.Controls.Dialogs;
using ObjectLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;


namespace Quizzy
{
    class PreviewQuizVewModel : IDropTarget, INotifyPropertyChanged
    {
        private PreviewQuiz previewWnd;

        private ObservableCollection<QuestionItemViewModel> allQuestions;

        public PreviewQuizVewModel(PreviewQuiz previewWnd, ObservableCollection<QuestionItemViewModel> allQuestions)
        {
            // TODO: Complete member initialization
            this.previewWnd = previewWnd;
            this.allQuestions = allQuestions;

            Title = ConstValues.DefaultQuizName;
            Description = ConstValues.DefaultQuizDescription;
        }

        public ObservableCollection<QuestionItemViewModel> AllQuestions
        {
            get { return allQuestions; }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public string Title { get; set; }
        public string Description { get; set; }


        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        // Commands
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private RelayCommand closeWindowCommand;
        public RelayCommand CloseWindowCommand
        {
            get
            {
                if (closeWindowCommand == null)
                {
                    closeWindowCommand = new RelayCommand("Close the window", p => this.CloseWindow());
                }
                return closeWindowCommand;
            }
        }

        private void CloseWindow()
        {
            previewWnd.Owner.Show();
        }

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private RelayCommand createExeCommand;
        public RelayCommand CreateExeCommand
        {
            get
            {
                if (createExeCommand == null)
                {
                    createExeCommand = new RelayCommand("Create an executable", p => this.CreateExe());
                }
                return createExeCommand;
            }
        }

        private async void CreateExe()
        {
            ReassignQuestionNumbers();

            byte[] title = Serializer.Serialize(Title);
            byte[] description = Serializer.Serialize(Description);

            List<QuestionItem> questsForSerialization = (from q in allQuestions
                                                         select q.QuestionModel).ToList();
            byte[] questions = Serializer.Serialize(questsForSerialization);

            // TODO: Remove debugging info
           // File.WriteAllBytes("D:\\bytes.txt", questions);

            if (InjectionIntoExe.Injection(title, description, questions) == true)
            {
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    ColorScheme = MetroDialogColorScheme.Theme
                };

                MessageDialogResult res = await previewWnd.ShowMessageAsync("File created!", "Quizzy", MessageDialogStyle.Affirmative, mySettings);
                previewWnd.Close();
            }
        }       
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----

        private RelayCommand deleteQuestionCommand;
        public RelayCommand DeleteQuestionCommand
        {
            get
            {
                if (deleteQuestionCommand == null)
                {
                    deleteQuestionCommand = new RelayCommand("Delete the question", p => this.DeleteQuestion(p));
                }
                return deleteQuestionCommand;
            }
        }

        private void DeleteQuestion(object param)
        {          
            allQuestions.Remove(allQuestions.Where(x => x.QuestionNumber == Convert.ToInt32(param)).FirstOrDefault());
        }

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void daComplete(object sender, EventArgs e, object param)
        {
            ListViewItem lvi = previewWnd.questionsListView.SelectedItem as ListViewItem;
            previewWnd.questionsListView.Items.Remove(lvi);
        }



        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        // Drag'n'drop of listview items
        public void DragOver(IDropInfo dropInfo)
        {
            QuestionItemViewModel sourceItem = dropInfo.Data as QuestionItemViewModel;
            QuestionItemViewModel targetItem = dropInfo.TargetItem as QuestionItemViewModel;

            if (sourceItem != null && targetItem != null)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = System.Windows.DragDropEffects.Move;
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        public void Drop(IDropInfo dropInfo)
        {
            QuestionItemViewModel sourceItem = dropInfo.Data as QuestionItemViewModel;
            QuestionItemViewModel targetItem = dropInfo.TargetItem as QuestionItemViewModel;

            if (sourceItem != null && targetItem != null)
            {
                int oldIndex = allQuestions.IndexOf(sourceItem);
                int newIndex = allQuestions.IndexOf(targetItem);

                allQuestions.Move(oldIndex, newIndex);
            }          

        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        private void ReassignQuestionNumbers()
        {
            foreach (QuestionItemViewModel q in allQuestions)
            {
                q.QuestionNumber = allQuestions.IndexOf(q) + 1;
            }
            OnPropertyChanged(String.Empty);
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


        public bool IsRemoved { get; set; }

        
    }
}
