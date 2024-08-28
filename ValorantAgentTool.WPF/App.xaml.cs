using System.Configuration;
using System.Data;
using System.Windows;
using ValorantAgentTool.WPF.Repositories;
using ValorantAgentTool.WPF.Stores;
using ValorantAgentTool.WPF.ViewModels;

namespace ValorantAgentTool.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedAgentStore _selectedAgentStore = new SelectedAgentStore();

        public App()
        {
            _selectedAgentStore = new SelectedAgentStore();
        }



        override protected void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new ValorantAgentToolViewModel(_selectedAgentStore);
            mainWindow.Show();
        }
    }

}
