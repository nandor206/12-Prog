using System.Printing;
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
        public Main main = new Main();

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameGrid();
            main.InitGame(map);
        }

        private void InitializeGameGrid()
        {
            map.Children.Clear();

            for (int row = 0; row < main.Rows; row++)
            {
                for (int col = 0; col < main.Columns; col++)
                {
                    var btn = new Button();
                    btn.Click += main.LeftClick;
                    btn.MouseRightButtonUp += main.RightClick;
                    Grid.SetRow(btn, row);
                    Grid.SetColumn(btn, col);
                    map.Children.Add(btn);
                    btn.Content = "";
                    btn.Background = Brushes.LightGray;
                }
            }
        }

        public void RestartGame()
        {
            main = new Main();
            InitializeGameGrid();
            main.InitGame(map);
        }
    }

    public struct ButtonStruct
    {
        public bool IsMine { get; set; }
        public int AdjacentMines { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
    }

    public class Main
    {
        public int mines = 7;
        public int flags = 0;
        public int correctFlags = 0;
        public int Rows = 11;
        public int Columns = 12;
        public ButtonStruct[,] Buttons_array { get; set; } = new ButtonStruct[11, 12];
        public void InitGame(Grid map)
        {
            flags = 0;
            correctFlags = 0;

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    Buttons_array[i, j] = new ButtonStruct();

            Random random = new Random();
            for (int i = 0; i < mines; i++)
            {
                int row = random.Next(Rows);
                int col = random.Next(Columns);
                if (!Buttons_array[row, col].IsMine)
                {
                    Buttons_array[row, col].IsMine = true;
                }
                else
                {
                    i--;
                }
            }

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    int count = 0;
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (x == 0 && y == 0)
                                continue;

                            int newRow = row + x;
                            int newCol = col + y;
                            if (newRow >= 0 && newRow < Rows && newCol >= 0 && newCol < Columns)
                                if (Buttons_array[newRow, newCol].IsMine)
                                    count++;
                        }
                    }
                    Buttons_array[row, col].AdjacentMines = count;
                }
            }

        }

        public void LeftClick(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;
            int x = Grid.GetRow(btn);
            int y = Grid.GetColumn(btn);

            if (Buttons_array[x, y].IsRevealed || Buttons_array[x, y].IsFlagged)
                return;

            if (Buttons_array[x, y].IsMine)
            {
                btn.Content = "M";
                btn.Background = Brushes.Red;
                RevealAllMines(btn);
                MessageBoxResult result = MessageBox.Show("Game Over! You have hit a mine. Do you want to restart?", "Game Over", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (Application.Current.MainWindow is MainWindow mw)
                        mw.RestartGame();
                }
                else
                {
                    Application.Current.Shutdown();
                }
                return;
            }
            RevealCell(x, y);
        }

        public void RevealCell(int x, int y)
        {
            if (x < 0 || x >= Rows || y < 0 || y >= Columns)
                return;
            if (Buttons_array[x, y].IsRevealed || Buttons_array[x, y].IsFlagged)
                return;

            Buttons_array[x, y].IsRevealed = true;
            Button? btn = GetButtonAt(x, y);
            if (btn == null) return;
            if (Buttons_array[x, y].AdjacentMines > 0)
            {
                btn.Content = Buttons_array[x, y].AdjacentMines.ToString();
                btn.IsEnabled = false;
                btn.Background = Brushes.White;
            }
            else
            {
                btn.Content = "";
                btn.IsEnabled = false;
                btn.Background = Brushes.White;
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                            RevealCell(x+i, y+j);
                    }
                }
            }
        }

        private void RevealAllMines(Button? triggeredBtn)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainWindow mw)
                {
                    foreach (UIElement element in mw.map.Children)
                    {
                        if (element is Button btn)
                        {
                            int x = Grid.GetRow(btn);
                            int y = Grid.GetColumn(btn);
                            if (Buttons_array[x, y].IsMine)
                            {
                                btn.Content = "M";
                                btn.Background = btn == triggeredBtn ? Brushes.Red : Brushes.OrangeRed;
                            }
                        }
                    }
                }
            }
        }

        private Button? GetButtonAt(int x, int y)
        {
            if (Application.Current.MainWindow is MainWindow mw)
            {
                foreach (UIElement element in mw.map.Children)
                {
                    if (element is Button btn && Grid.GetRow(btn) == x && Grid.GetColumn(btn) == y)
                        return btn;
                }
            }
            return null;
        }

        public void RightClick(object sender, MouseButtonEventArgs e)
        {
            Button? btn = sender as Button;
            if (btn == null) return;

            int x = Grid.GetRow(btn);
            int y = Grid.GetColumn(btn);

            if (Buttons_array[x, y].IsRevealed) return;

            if (!Buttons_array[x, y].IsFlagged && flags < mines)
            {
                Buttons_array[x, y].IsFlagged = true;
                flags++;
                btn.Content = "F";
                btn.Background = Brushes.Yellow;
                if (Buttons_array[x, y].IsMine)
                {
                    correctFlags++;
                }
            }
            else if (Buttons_array[x, y].IsFlagged)
            {
                Buttons_array[x, y].IsFlagged = false;
                flags--;
                btn.Content = "";
                btn.Background = Brushes.LightGray;
                if (Buttons_array[x, y].IsMine)
                {
                    correctFlags--;
                }
            }
            CheckWin();
        }

        private void CheckWin()
        {
            if (correctFlags == mines && flags == mines)
            {
                MessageBoxResult result = MessageBox.Show("Congratulations! You won! Do you want to play again?", "You Win!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (Application.Current.MainWindow is MainWindow mw)
                        mw.RestartGame();
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }
    }
}