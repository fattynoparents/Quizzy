using CommonResources;
using MahApps.Metro.Controls.Dialogs;
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
using System.Windows.Input;

namespace Quizzy
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {

        }

        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----
        // Command to open the Constructor window
        private RelayCommand makeNewQuizCommand;
        public RelayCommand MakeNewQuizCommand
        {
            get
            {
                if (makeNewQuizCommand == null)
                {
                    makeNewQuizCommand = new RelayCommand("Create a new quiz", p => CreateOrOpenQuiz());
                }
                return (makeNewQuizCommand);
            }
        }

        private void CreateOrOpenQuiz(ObservableCollection<QuestionItem> deserialized = null)
        {
            Application.Current.MainWindow.Hide();

            Constructor constructor = new Constructor();
            ConstructorViewModel constructorVM = new ConstructorViewModel(constructor, deserialized);
            constructor.DataContext = constructorVM;

            constructor.Owner = Application.Current.MainWindow;
            constructor.ShowDialog();
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----

        private RelayCommand openFromFileCommand;
        public RelayCommand OpenFromFileCommand
        {
            get
            {
                if (openFromFileCommand == null)
                {
                    openFromFileCommand = new RelayCommand("Open from file", p => OpenFromFile());
                }
                return (openFromFileCommand);
            }
        }

        private void OpenFromFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Quizzy File";
            ofd.Filter = "QZZ files|*.qzz";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var result = (bool)ofd.ShowDialog();
            if (result == true)
            {
                byte[] buff = File.ReadAllBytes(ofd.FileName);
                ObservableCollection<QuestionItem> deserialiazedResults = new ObservableCollection<QuestionItem>(Serializer.BinaryDeserialize(buff) as IEnumerable<QuestionItem>);
                if (deserialiazedResults != null)
                {
                    CreateOrOpenQuiz(deserialiazedResults);
                }
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
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----


    }
}
