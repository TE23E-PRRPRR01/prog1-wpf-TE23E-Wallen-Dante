using System.Net;
using System.Net.Mail;
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

namespace EpostApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void KlickaSkicka(object sender, RoutedEventArgs e)
    {
        // Läs av epost & meddelande
        string epost = tbxEpost.Text;
        string meddelande = tbxText.Text;

        // Koppla upp på en mail-server
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential("mail@gmail.com", "password");

        //Sanity check
        if (!epost.Contains("@") || meddelande == "")
        {
            lblStatus.Content = $"Kunde inte skicka meddelandet till eposten {epost}";
        }
        else
        {
            try
            {
                smtp.Send("mail@gmail.com", epost, "Epost från appen", meddelande);
                lblStatus.Content = "Meddelandet har skickats!";
            }
            catch (Exception ex)
            {
                lblStatus.Content = $"Fel: {ex.Message}";
            }
        }
    }
}