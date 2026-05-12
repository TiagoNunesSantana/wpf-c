using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClinicLab.App.Models;
using ClinicLab.App.Repositories;

namespace ClinicLab.App.ViewModels;

public partial class PacienteViewModel : ObservableObject
{
    [ObservableProperty]
    private string nome = string.Empty;

    [ObservableProperty]
    private string cpf = string.Empty;

    [ObservableProperty]
    private string telefone = string.Empty;

    [ObservableProperty]
    private string convenio = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Paciente> pacientes = [];

    [RelayCommand]
    private async Task Salvar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
        {
            MessageBox.Show("O campo Nome é obrigatório.", "Validação",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            var paciente = new Paciente
            {
                Nome = Nome,
                Cpf = Cpf,
                Telefone = Telefone,
                Convenio = Convenio
            };

            await PacienteRepository.SalvarAsync(paciente);

            Nome = string.Empty;
            Cpf = string.Empty;
            Telefone = string.Empty;
            Convenio = string.Empty;

            await Carregar();
        }
        catch (Exception ex)
        {
            var mensagem = ex.InnerException?.Message ?? ex.Message;
            MessageBox.Show(mensagem, "Erro ao salvar",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    [RelayCommand]
    private async Task Carregar()
    {
        try
        {
            Pacientes = new ObservableCollection<Paciente>(
                await PacienteRepository.ListarAsync()
            );
        }
        catch (Exception ex)
        {
            var mensagem = ex.InnerException?.Message ?? ex.Message;
            MessageBox.Show(mensagem, "Erro ao carregar",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
