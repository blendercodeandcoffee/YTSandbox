using CoreConsole.Data;
using SandboxWPF.Data;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SandboxWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> personen;

        public MainWindow()
        {
            InitializeComponent();
            GeschlechtEnum[] geschlechter = new GeschlechtEnum[2];
            geschlechter[0] = GeschlechtEnum.Maennlich;
            geschlechter[1] = GeschlechtEnum.Weiblich;
            cmbGeschlecht.ItemsSource = geschlechter;
        }

        private void Foo()
        {
            List<IPrivatObjekt> listFzg = new List<IPrivatObjekt>();
            listFzg.Add(new Mixer());
            listFzg.Add(new Mixer());
            listFzg.Add(new Mixer());
            listFzg.Add(new Bodenfahrzeug());
            listFzg.Add(new Bodenfahrzeug());
            listFzg.Add(new Bodenfahrzeug());
            listFzg.Add(new Waschmaschine());
            listFzg.Add(new Waschmaschine());
            listFzg.Add(new Waschmaschine());
            int anschaffungssumme = 0;
            foreach (var item in listFzg)
            {
                anschaffungssumme = anschaffungssumme + item.Kaufpreis;
            }


            Waschmaschine wm = new Waschmaschine();
            (wm as IWartbaresGeraet).WartungTest();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!double.IsNaN(Settings1.Default.WindowTop))
            {
                this.Top = Settings1.Default.WindowTop;
                this.Left = Settings1.Default.WindowLeft;
                this.Width = Settings1.Default.WindowWidth;
                this.Height = Settings1.Default.WindowHeight;
            }
            personen = new List<Person>();
            string[] content = File.ReadAllLines(@"D:\TestFolder\personen.csv");
            for (int i = 0; i < content.Length; i++)
            {
                personen.Add(Person.Parse(content[i]));
            }
            dgPersonen.ItemsSource = personen;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings1.Default.WindowTop = this.Top;
            Settings1.Default.WindowLeft = this.Left;
            Settings1.Default.WindowWidth = this.ActualWidth;
            Settings1.Default.WindowHeight = this.ActualHeight;
            Settings1.Default.Save();
        }

        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            string vorname = txtVorname.Text;
            string nachname = txtNachname.Text;
            int alter = int.Parse(txtAlter.Text);
            GeschlechtEnum geschlecht = (GeschlechtEnum)cmbGeschlecht.SelectedItem;
            personen.Add(new Person() { Alter = alter, Vorname = vorname, Nachname = nachname, Geschlecht = geschlecht });
            string[] persString = new string[personen.Count];
            for (int i = 0; i < persString.Length; i++)
            {
                persString[i] = personen[i].ToDateiString();
            }
            dgPersonen.Items.Refresh();
            File.WriteAllLines(@"D:\TestFolder\personen.csv", persString);
        }
    }
}
