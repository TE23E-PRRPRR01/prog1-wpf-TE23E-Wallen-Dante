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

namespace GissaApp_Övning;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    int random = Random.Shared.Next(1, 101);
    List<int> listaGissningar = [];

    public void klickGissa(object sender, RoutedEventArgs e)
    {
        string inputText = txbInput.Text;
        bool success = int.TryParse(inputText, out int inputGissning);

        if (success)
        {

            listaGissningar.Add(inputGissning);

            if (inputGissning == random)
            {
                txbResultat.Text = "Din gissning var rätt";
            }
            else if (inputGissning <= random)
            {
                txbResultat.Text = $"Det rätta svaret är större än {inputGissning}";
            }
            else if (inputGissning >= random)
            {
                txbResultat.Text = $"Det rätta svaret är mindre än {inputGissning}";
            }
        }
        else
        {
            txbResultat.Text = "Något blev fel med inmatningen.";
        }
    }

    private void klickVisaFacit(object sender, RoutedEventArgs e)
    {
        txbResultat.Text = $"Det rätta svaret var {random}";
    }

    private void klickHistorik(object sender, RoutedEventArgs e)
    {
        txbHistorik.Text = "";

        foreach (var item in listaGissningar)
        {
            txbHistorik.Text += $"{item}\n";
        }
    }

    public void klickSpelaIgen(object sender, RoutedEventArgs e)
    {
        random = Random.Shared.Next(1, 101);
        listaGissningar = [];

        txbResultat.Text = "";
        txbInput.Text = "";
        txbHistorik.Text = "";
    }
}