using System.Windows;
using System.Windows.Controls;
using ClinicLab.App.Models;
using ClinicLab.App.Services;

namespace ClinicLab.App.Views;

public partial class SetupWizardWindow : Window
{
    private const string LocalConnection =
        "Host=localhost;Port=5432;Database=cliniclab;Username=postgres;Password=postgres";

    private const string RailwayTemplate =
        "Host=SEU_HOST;Port=SUA_PORTA;Database=railway;Username=postgres;Password=SUA_SENHA;SSL Mode=Require;Trust Server Certificate=true";

    public SetupWizardWindow()
    {
        InitializeComponent();

        ConnectionStringTextBox.Text = LocalConnection;
    }

    private void DatabaseTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ConnectionStringTextBox == null)
            return;

        ConnectionStringTextBox.Text = DatabaseTypeCombo.SelectedIndex == 0
            ? LocalConnection
            : RailwayTemplate;
    }

    private void UseLocal_Click(object sender, RoutedEventArgs e)
    {
        ConnectionStringTextBox.Text = LocalConnection;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ConnectionStringTextBox.Text))
        {
            MessageBox.Show(
                "Informe a connection string.",
                "Validação",
                MessageBoxButton.OK,
                MessageBoxImage.Warning
            );

            return;
        }

        ConfigService.Save(new AppSettings
        {
            ConnectionString = ConnectionStringTextBox.Text.Trim()
        });

        MessageBox.Show(
            "Configuração salva com sucesso.",
            "Sucesso",
            MessageBoxButton.OK,
            MessageBoxImage.Information
        );

        DialogResult = true;
        Close();
    }
}