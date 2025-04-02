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

namespace GissaApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    // Variabler
    // Slumpa fram ett tal 1-100
    int slumptal = Random.Shared.Next(1, 101);
    List<int> listaGissningar = [];

    public MainWindow()
    {
        InitializeComponent();
    }

    private void KlickGissa(object sender, RoutedEventArgs e)
    {
        // Läs av ruta Gissning
        string inputText = tbxGissning.Text;
        int gissning = 0;

        // Konvertera till ett heltal
        bool success = int.TryParse(inputText, out gissning);

        // Lyckades konverteringen?
        if (success)
        {
            // Spara gissningen i listan
            listaGissningar.Add(gissning);

            // Jämföra gissning med slumptal
            if (gissning == slumptal)
            {
                tbxResultat.Text = "Din gissning var rätt";
            }
            else if (gissning < slumptal)
            {
                tbxResultat.Text = $"Det rätta svaret är större än {gissning}";
            }
            else if (gissning > slumptal)
            {
                tbxResultat.Text = $"Det rätta svaret är mindre än {gissning}";
            }
            else
            {
                tbxResultat.Text = "Felaktig inmatning. Försök igen.";
            }
        }
        else
        {
            tbxResultat.Text = "Felaktig inmatning. Försök igen.";
        }

    }

    private void KlickVisaFacit(object sender, RoutedEventArgs e)
    {
        tbxResultat.Text = $"Rätt svar är {slumptal}";
    }

    private void KlickVisaGissningar(object sender, RoutedEventArgs e)
    {
        tbxVisaGissningar.Text = "";

        // Skriv ut alla gissningar som finns i listan
        foreach (var gissatTal in listaGissningar)
        {
            tbxVisaGissningar.Text += $"▪ {gissatTal}\n";
        }
    }

    // Slumpar ett nytt tal
    private void KlickSlumpaNyttTal(object sender, RoutedEventArgs e)
    {
        // Slumpa fram ett nytt tal 1-100
        slumptal = Random.Shared.Next(1, 101);

        // Nollställ allt
        tbxGissning.Text = "";
        tbxResultat.Text = "";
        tbxVisaGissningar.Text = "";
        
        listaGissningar = [];
    }
}