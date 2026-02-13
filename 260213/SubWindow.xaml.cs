using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _260213
{
    /// <summary>
    /// Interaction logic for SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            InitializeComponent();
            txtNum.Text = ((MainWindow)this.Owner).main.mines.ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!(PresentationSource.FromVisual(this.Owner) == null))
            {
                ((MainWindow)this.Owner).ShowSubWindow();
            }
        }

        public int NumValue
        {
            get { return ((MainWindow)this.Owner).main.mines; }
            set
            {
                ((MainWindow)this.Owner).main.mines = value;
                txtNum.Text = value.ToString();
            }
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            if (NumValue <= 10 * 11 / 3)
            {
                NumValue++;
            }
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if (NumValue > 3)
            {
                NumValue--;
            }
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out ((MainWindow)this.Owner).main.mines))
                txtNum.Text = ((MainWindow)this.Owner).main.mines.ToString();
        }

    }
}
