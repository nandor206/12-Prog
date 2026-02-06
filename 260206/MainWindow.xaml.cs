using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2606
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string udv_nev = nev.Text.Trim();
            if (udv_nev == "")
            {
                MessageBox.Show("Üdvözöllek!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Üdvözöllek, {udv_nev}!", "anyád", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Cancel)
                {
                    MessageBox.Show("anyád");
                }
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show($"Fütyi size: {futyi_size.Value}");
                }
                if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Azt hiszed nagy mi");
                }
            }
        }
    }
}