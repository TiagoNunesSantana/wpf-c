using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClinicLab.App.Models;
using ClinicLab.App.Repositories;

namespace ClinicLab.App.ViewModels;

public partial class PacienteViewModel : ObservableObject
{
    private readonly PacienteRepository _repository = new();

    [ObservableProperty]
    private string nome = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Paciente> pacientes = new();

    [RelayCommand]
    private void Salvar()
    {
        try
        {
            var paciente = new Paciente
            {
                Nome = Nome
            };

            _repository.Salvar(paciente);

            Nome = string.Empty;

            Carregar();
        }
        catch (Exception ex)
        {
            var mensagem = ex.InnerException != null
                ? ex.InnerException.Message
                : ex.Message;

            MessageBox.Show(
                mensagem,
                "Erro ao salvar",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    [RelayCommand]
    private void Carregar()
    {
        Pacientes = new ObservableCollection<Paciente>(
            _repository.Listar()
        );
    }
}