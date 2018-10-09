using System.Windows;

namespace Blocknote
{
    /// <summary>
    /// Логика взаимодействия для AboutProgram.xaml
    /// </summary>
    public partial class AboutProgram : Window
    {
        private TxtFile file;

        public AboutProgram(ref TxtFile txt)
        {
            InitializeComponent();
            file = txt;
            this.DataContext = file;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
