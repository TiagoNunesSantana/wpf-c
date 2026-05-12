using System.Windows;
using ClinicLab.App.Views;

namespace ClinicLab.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MainContent.Content = new DashboardView();
    }

    private void Dashboard_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new DashboardView();
    }

    private void Pacientes_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new PacientesView();
    }

    private void Exames_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new ExamesView();
    }
}