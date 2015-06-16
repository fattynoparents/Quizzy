using MahApps.Metro.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace QuizzyExe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainContext = this.DataContext as MainWindowViewModel;

            if (mainContext != null)
            {
                mainContext.RequestClose += (sender, args) =>
                {
                    this.Close();
                };
            }
        }


    }
}
