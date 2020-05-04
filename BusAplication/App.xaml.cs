using BusId.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;

namespace BusId
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            BusId.MainWindow window = new MainWindow();

            TrasaViewModel TM = new TrasaViewModel();
            window.DataContext = TM;

            window.Show();
        }
    }
}
