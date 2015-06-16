using FirstFloor.ModernUI.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

namespace Quizzy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Ok",
                ColorScheme = MetroDialogColorScheme.Theme
            };

            MessageDialogResult res = await this.ShowMessageAsync("A program for creating quizzes. \n\nMake your own quiz and save it as a stand-alone .exe file." +
                " \n\nIt is also possible to save a template of a quiz to disk.", 
                "", MessageDialogStyle.Affirmative, mySettings);
        }
    }
}
