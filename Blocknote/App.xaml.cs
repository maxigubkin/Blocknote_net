using System.Windows;

namespace Blocknote
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TxtFile file;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            file = new TxtFile();
            MainWindow mw = new MainWindow(ref file);
            mw.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            file.SaveCheck();
        }
    }
}
