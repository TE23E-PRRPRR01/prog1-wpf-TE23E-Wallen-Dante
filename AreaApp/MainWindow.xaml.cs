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

namespace AreaApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Title = "Fortnite: Battle Royale";
    }

    private void CalculateArea(object sender, RoutedEventArgs e)
    {
        // Hämta bredd och höjd från textfälten
        int width = int.Parse(vwidth.Text);
        int height = int.Parse(vheight.Text);

        // Beräkna arean
        int area = width * height;

        // Visa resultatet i textfältet
        varea.Text = area.ToString();

        // Tömmer "Rensat! :)"-fältet
        notis.Text = "".ToString();
    }

    private void Clear(object sender, RoutedEventArgs e)
    {
        vwidth.Text = "".ToString();
        vheight.Text = "".ToString();
        varea.Text = "".ToString();

        notis.Text = "Rensat! :)".ToString();
    }

}