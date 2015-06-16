using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quizzy
{
    /// <summary>
    /// Interaction logic for Constructor.xaml
    /// </summary>
    public partial class Constructor : MetroWindow
    {
        public Constructor()
        {
            InitializeComponent();
        }

        private bool confirmed;
        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {  
            ConstructorViewModel dataContext = this.DataContext as ConstructorViewModel;
            if (dataContext != null)
            {
                if (dataContext.Changed)
                {
                    if (!confirmed)
                    {
                        e.Cancel = true;
                        var mySettings = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Yes",
                            NegativeButtonText = "No",
                            FirstAuxiliaryButtonText = "Cancel",
                            ColorScheme = MetroDialogColorScheme.Theme
                        };

                        MessageDialogResult res = await this.ShowMessageAsync("Save the quiz to a file before closing the program?", "Quizzy", 
                            MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

                        if (res == MessageDialogResult.Affirmative)
                        {
                            dataContext.SaveToFile();
                        }
                        if (res != MessageDialogResult.FirstAuxiliary)
                        {
                            confirmed = true;
                            this.Close();
                        }
                    }
                    
                }
                Application.Current.MainWindow.Show();
            }
        }

    }
}
