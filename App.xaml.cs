using System;
using System.Windows;
using Examen3.ViewModels;
using Examen3.Views;

namespace Examen3
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configura y muestra la ventana principal (MainWindow)
            var mainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            mainWindow.Show();
        }
    }
}
