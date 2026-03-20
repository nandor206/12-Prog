using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace Konyvtar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Main main = new();
        SaveLoad saveLoad = new SaveLoad();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            faj.ItemsSource = Enum.GetValues(typeof(FajEnum)); // Faj ComboBox feltöltése
            main.mainWindow = this;
            ObservableCollection<AllatData> allatLista = saveLoad.Load();
            if (allatLista != null)
            {
                main.allatLista = allatLista;
            }
            adatLista.ItemsSource = main.allatLista;
        }

        private void nev_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = nev.Text;
            if (string.IsNullOrEmpty(text)) return;

            main.Nev = text;
            main.Check();
        }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            switch (radioButton.Content)
            {
                case "Hím":
                    main.Nem = NemEnum.Hím;
                    break;
                case "Nőstény":
                    main.Nem = NemEnum.Nőstény;
                    break;
                default:
                    break;
            }
            main.Check();
        }

        private void behozatal_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = behozatal.SelectedDate;
            if (selectedDate == null) return;

            DateOnly date = DateOnly.FromDateTime(selectedDate.Value);
            main.Behozatal = date;

            main.Check();
        }

        private void hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            main.HozzaAdas();
        }

        private void faj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = faj.SelectedIndex;
            if (faj.SelectedIndex == -1) return;

            main.Faj = (FajEnum)id;
            main.Check();
        }

        public void ResetForm()
        {
            nev.Text = "";
            faj.SelectedIndex = -1;
            behozatal.SelectedDate = null;

            himRadio.IsChecked = false;
            nostenyRadio.IsChecked = false;

            hozzaadas.IsEnabled = false;
        }

        private void adatLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = adatLista.SelectedIndex;
            if (id < 0)
            {
                torles.IsEnabled = false;
                return;
            }

            main.Id = id;
            torles.IsEnabled = true;
        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            main.Torles();
        }
    }

    public class Main
    {
        public MainWindow? mainWindow;
        SaveLoad saveLoad = new();
        public ObservableCollection<AllatData> allatLista = new();

        public string? Nev = null;
        public FajEnum? Faj = null;
        public NemEnum? Nem = null;
        public DateOnly? Behozatal = null;
        public int Id = -1;

        public void Check()
        {
            bool valid = Nev != null && Faj != null && Nem != null && Behozatal != null;
            mainWindow!.hozzaadas.IsEnabled = valid;
        }

        public void HozzaAdas()
        {
            AllatData allatData = new AllatData();
            allatData.nev = Nev!;
            allatData.faj = (FajEnum)Faj!;
            allatData.nem = (NemEnum)Nem!;
            allatData.behozatal = (DateOnly)Behozatal!;

            string adatok = $"Az állat neve: {allatData.nev}, faja: {allatData.faj.ToString()}, neme: {allatData.nem.ToString()}, behozatalának időpontja: {allatData.behozatal.ToString()}";

            MessageBoxResult result = MessageBox.Show($"Jó adatokat írtál be?\n{adatok}", "Ellenőrzés", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;

            allatLista.Add(allatData);
            saveLoad.Mentes(allatLista.ToList());

            mainWindow!.ResetForm();
            Reset();
        }

        public void Torles()
        {
            AllatData allatData = allatLista[Id];
            string adatok = $"Az állat neve: {allatData.nev}, faja: {allatData.faj.ToString()}, neme: {allatData.nem.ToString()}, behozatalának időpontja: {allatData.behozatal.ToString()}";

            MessageBoxResult result = MessageBox.Show($"Biztos törölni szeretnéd ezt az állatot?\n{adatok}", "Ellenőrzés", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;

            allatLista.RemoveAt(Id);
            saveLoad.Mentes(allatLista.ToList());
        }

        public void Reset()
        {
            Nev = null;
            Faj = null;
            Nem = null;
            Behozatal = null;
        }

    }

    public class SaveLoad
    {

        static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Menhely");
        static string filename = "mentes.csv";
        static string file = Path.Combine(path, filename);

        public void Mentes(List<AllatData> list)
        {
            if (!File.Exists(file))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Menhely"));
                
            }
            MentesFrissitese(list);
        }

        void MentesFrissitese(List<AllatData> list)
        {
            List<string> buffer = new();

            foreach (var item in list)
            {
                string data = $"{item.nev};{(int)item.faj};{(int)item.nem};{item.behozatal.ToString()}";
                buffer.Add(data);
            }

            File.WriteAllLines(file, buffer);
        }

        public ObservableCollection<AllatData>? Load()
        {
            ObservableCollection<AllatData> allatLista = new();

            if (!File.Exists(file))
            {
                return null;
            }

            string[] buffer =  File.ReadAllLines(file);

            foreach (var item in buffer)
            {
                string[] adat = item.Split(';');
                AllatData allatData = new();
                allatData.nev = adat[0];
                allatData.faj = (FajEnum)int.Parse(adat[1]);
                allatData.nem = (NemEnum)int.Parse(adat[2]);
                allatData.behozatal = DateOnly.Parse(adat[3]);

                allatLista.Add(allatData);
            }

            return allatLista;
        }
    }

    public enum FajEnum
    {
        Kutya,
        Macska,
        Hörcsög,
        Madár
    }
    public enum NemEnum
    {
        Hím,
        Nőstény
    }
    public struct AllatData
    {
        public string nev { get; set; }
        public FajEnum faj { get; set; }
        public NemEnum nem { get; set; }
        public DateOnly behozatal { get; set; }
    }
}