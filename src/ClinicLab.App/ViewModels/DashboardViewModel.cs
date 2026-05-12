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
    private int totalExames;

    [ObservableProperty]
    private string ultimoPaciente = "Nenhum paciente cadastrado";

    [ObservableProperty]
    private string ultimaAtualizacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

    public DashboardViewModel()
    {
        _ = CarregarDados();
    }

    public async Task CarregarDados()
    {
        TotalPacientes = _pacienteRepository.Contar();

        TotalExames = await ExameRepository.Contar();

        Paciente? paciente = _pacienteRepository.ObterUltimoCadastro();

        UltimoPaciente = paciente != null
            ? paciente.Nome
            : "Nenhum paciente cadastrado";

        UltimaAtualizacao = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }
}