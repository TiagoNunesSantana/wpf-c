using CommunityToolkit.Mvvm.ComponentModel;
using ClinicLab.App.Models;
using ClinicLab.App.Repositories;

namespace ClinicLab.App.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private readonly PacienteRepository _pacienteRepository = new();

    [ObservableProperty]
    private int totalPacientes;

    [ObservableProperty]
    private string ultimoPaciente = "Nenhum paciente cadastrado";

    [ObservableProperty]
    private string ultimaAtualizacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

    public DashboardViewModel()
    {
        CarregarDados();
    }

    public void CarregarDados()
    {
        TotalPacientes = _pacienteRepository.Contar();

        Paciente? paciente = _pacienteRepository.ObterUltimoCadastro();

        if (paciente != null)
        {
            UltimoPaciente = paciente.Nome;
        }

        UltimaAtualizacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }
}