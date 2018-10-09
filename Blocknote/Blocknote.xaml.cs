using System.Windows;
using System.Windows.Input;

namespace Blocknote
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TxtFile file;

        public MainWindow(ref TxtFile txt)
        {
            InitializeComponent();
            file = txt;
            this.DataContext = file;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FocusManager.SetFocusedElement(this, txtBox);
        }

        private void CreateNew(object sender, RoutedEventArgs e)
        {
            if (file.SaveCheck())
            { 
                file = new TxtFile();
                this.DataContext = file;
            }
        }

        private void AppQuit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            file.SaveFile();
        }

        private void SaveAs(object sender, RoutedEventArgs e)
        {
            file.SaveFile(true);
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            file.OpenFile();
        }

        private void FontSettings(object sender, RoutedEventArgs e)
        {
            FontSettings fs = new FontSettings(ref file);
            fs.Show();
        }

        private void AboutProgram(object sender, RoutedEventArgs e)
        {
            AboutProgram ap = new AboutProgram(ref file);
            ap.Show();
        }
    }
}
