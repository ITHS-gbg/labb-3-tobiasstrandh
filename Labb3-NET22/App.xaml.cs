using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Labb3_NET22.DataModels;
using Labb3_NET22.ViewModel;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Här instansieras våran Model och ViewModel
            var quizModel = new QuizModel();
            var quizViewModel = new QuizViewModel(quizModel);

            //Instansierar fönstret och sätter DataContext till en ny instans av MainViewModel
            //och skickar med demoViewModel som instansierats ovanför
            var mainWindow = new MainWindow() { DataContext = new MainViewModel(quizViewModel) };

            //Visar fönstret.
            mainWindow.Show();
        }
    }
}
