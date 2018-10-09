using System.Windows;
using System.Drawing.Text;
using System.Linq;
using System.Drawing;

namespace Blocknote
{
    /// <summary>
    /// Логика взаимодействия для FontSettings.xaml
    /// </summary>
    /// 
    public partial class FontSettings : Window
    {
        private TxtFile file;

        public FontSettings(ref TxtFile txt)
        {
            InitializeComponent();
            file = txt;
            this.DataContext = file;

            InstalledFontCollection ifc = new InstalledFontCollection();
            lvFontFamilys.ItemsSource = ifc.Families.Select(FontFamily => FontFamily.Name);
            lvFontSize.ItemsSource = new double[] { 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38 };
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
