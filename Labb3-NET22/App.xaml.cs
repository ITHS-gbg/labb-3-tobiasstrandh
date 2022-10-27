﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Labb3_NET22.DataModels;
using Labb3_NET22.Managers;
using Labb3_NET22.ViewModel;

namespace Labb3_NET22
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationManager _navigationManager;
        private readonly DataManger _dataManger;
        public App()
        {
            _navigationManager = new NavigationManager();
            _dataManger = new DataManger();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
            _navigationManager.CurrentViewModel = new StartViewModel(_dataManger.DataModel, _navigationManager);

            //Instansierar fönstret och sätter DataContext till en ny instans av MainViewModel
            //och skickar med demoViewModel som instansierats ovanför
            var mainWindow = new MainWindow() { DataContext = new MainViewModel(_navigationManager, _dataManger) };

            //Visar fönstret.
            mainWindow.Show();
        }
    }
}
