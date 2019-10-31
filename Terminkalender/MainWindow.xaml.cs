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
using System.Xml.Serialization;
using Terminkalender.Data;

namespace Terminkalender
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Termin selectedTermin;
        private List<Termin> termine;
        private XmlSerializer serializer;
        private string path;

        public MainWindow()
        {
            InitializeComponent();
            path = @"D:\TestFolder\termine.xml";
            serializer = new XmlSerializer(typeof(ListWrapper));
            if (File.Exists(path))
            {
                var stream = File.OpenRead(path);
                ListWrapper lw = (ListWrapper)serializer.Deserialize(stream);
                termine = lw.Termine;
            }
            else
            {
                termine = new List<Termin>();
            }
            dtpFaelligkeit.Value = DateTime.Now;
            dgTermine.ItemsSource = termine;
        }

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            selectedTermin = new Termin() { Faelligkeit = calendar.SelectedDate ?? DateTime.Now };
            ApplySelectedTermin();
        }

        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            if (!dtpFaelligkeit.Value.HasValue)
            {
                MessageBox.Show("Es wurde kein gültiges Datum ausgewählt!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DateTime faelligkeit = dtpFaelligkeit.Value.Value;
                string kurztext = txtKurztext.Text;
                string ort = txtOrt.Text;
                string langtext = txtLangtext.Text;
                if (selectedTermin != null)
                {
                    selectedTermin.Faelligkeit = faelligkeit;
                    selectedTermin.Kurztext = kurztext;
                    selectedTermin.Ort = ort;
                    selectedTermin.Langtext = langtext;
                    if (!termine.Contains(selectedTermin))
                    {
                        termine.Add(selectedTermin);
                    }
                }
                else
                {
                    //selectedTermin = new Termin();
                    //selectedTermin.Faelligkeit = faelligkeit;
                    //selectedTermin.Kurztext = kurztext;
                    //selectedTermin.Ort = ort;
                    //selectedTermin.Langtext = langtext;

                    selectedTermin = new Termin()
                    {
                        Faelligkeit = faelligkeit,
                        Kurztext = kurztext,
                        Ort = ort,
                        Langtext = langtext
                    };
                    termine.Add(selectedTermin);
                }
                dgTermine.Items.Refresh();
            }
        }

        private void btnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            selectedTermin = null;
            ApplySelectedTermin();
        }

        private void ApplySelectedTermin()
        {
            if (selectedTermin != null)
            {
                dtpFaelligkeit.Value = selectedTermin.Faelligkeit;
                txtKurztext.Text = selectedTermin.Kurztext;
                txtOrt.Text = selectedTermin.Ort;
                txtLangtext.Text = selectedTermin.Langtext;
            }
            else
            {
                dtpFaelligkeit.Value = null;
                txtKurztext.Text = null;
                txtOrt.Text = null;
                txtLangtext.Text = null;
            }
        }

        private void dgTermine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTermin = (Termin)dgTermine.SelectedItem;
            ApplySelectedTermin();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.Delete(path);
            FileStream stream = File.Create(path);
            serializer.Serialize(stream, new ListWrapper(termine));
        }
    }

    [Serializable]
    [XmlRoot("root")]
    public class ListWrapper
    {
        [XmlArrayItem("termine")]
        public List<Termin> Termine { get; set; }

        public ListWrapper()
        {

        }

        public ListWrapper(List<Termin> termine)
        {
            this.Termine = termine;
        }
    }
}
