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

namespace _260213
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        SubWindow subWindow = new();
        public Main main = new();

        public MainWindow()
        {
            InitializeComponent();
            subWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            subWindow.Close();
        }

        public void ShowSubWindow()
        {
            subWindow = new SubWindow();
            subWindow.Show();
            subWindow.Owner = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            subWindow.Owner = this;
        }
    }

    public class Main
    {
        public int flags = 0;
        public int time = 0;
        public int mines = 0;
        public void InitGame()
        {

        }
    }
}