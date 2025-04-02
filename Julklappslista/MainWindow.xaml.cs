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

namespace Julklappslista;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        //Lås gränssnitt
        two.IsEnabled = false;
        lsbJulklappar.IsEnabled = false;
    }

    int maxJulklappar = 0;
    List<string> listaJulklappar = [];

    private void KlickAnge(object sender, RoutedEventArgs e)
    {
        //Läs av textbox
        string antal = tbxAntal.Text;

        //Försök enkel kontroll
        if (antal == "")
        {
            tbxStatus.Text = "Vänligen ange ett antal i form av ett heltal";
        }
        else
        {
            bool lyckas = int.TryParse(antal, out int talet);
            if (lyckas)
            {
                maxJulklappar = talet;
                tbxStatus.Text = $"Du har valt att max antalet julklappar ska vara {maxJulklappar}";

                // Koppla List till ListBox
                lsbJulklappar.ItemsSource = listaJulklappar;

                one.IsEnabled = false;
                two.IsEnabled = true;
                lsbJulklappar.IsEnabled = true;
            }
            else
            {
                tbxStatus.Text = "Vänligen ange ett antal i form av ett heltal";
            }
        }
    }

    private void KlickLäggTill(object sender, RoutedEventArgs e)
    {
        // Läs av textrutorna
        string julklapp = tbxJulklapp.Text;
        string mottagare = tbxMottagare.Text;

        if (julklapp == "" || mottagare == "")
        {
            tbxStatus.Text = "Vänligen ange en julklapp och mottagare";
        }
        else
        {
            listaJulklappar.Add($"{mottagare} kommer få en julklapp som är {julklapp}.");
            lsbJulklappar.Items.Refresh();
        }
    }

    private void KlickBytUt(object sender, RoutedEventArgs e)
    {
        tbxStatus.Text = "Den här knappen har ingen funktion ännu!";
    }
}