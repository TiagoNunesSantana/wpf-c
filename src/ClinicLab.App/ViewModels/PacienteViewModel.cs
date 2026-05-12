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

    [ObservableProperty]
    private Paciente? pacienteSelecionado;  

    partial void OnPacienteSelecionadoChanged(Paciente? value)
    {
        if (value == null)
            return;

        Nome = value.Nome;
        Cpf = value.Cpf;
        Telefone = value.Telefone;
        Convenio = value.Convenio;
    }     

    private void LimparCampos()
    {
        PacienteSelecionado = null;
        Nome = string.Empty;
        Cpf = string.Empty;
        Telefone = string.Empty;
        Convenio = string.Empty;
    }     

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
            if (PacienteSelecionado == null)
            {            
                var paciente = new Paciente
                {
                    Nome = Nome,
                    Cpf = Cpf,
                    Telefone = Telefone,
                    Convenio = Convenio
                };

                await PacienteRepository.Salvar(paciente);

                Nome = string.Empty;
                Cpf = string.Empty;
                Telefone = string.Empty;
                Convenio = string.Empty;

                await Carregar();
            }
            else
            {
                PacienteSelecionado.Nome = Nome;
                PacienteSelecionado.Cpf = Cpf;
                PacienteSelecionado.Telefone = Telefone;
                PacienteSelecionado.Convenio = Convenio;

                await PacienteRepository.Atualizar(PacienteSelecionado);

                await Carregar();
            }

            LimparCampos();

            MessageBox.Show(
                "Paciente salvo com sucesso.",
                "Sucesso",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );            
        }
        catch (Exception ex)
        {
            var mensagem = ex.InnerException?.Message ?? ex.Message;
            MessageBox.Show(mensagem, "Erro ao salvar",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    [RelayCommand]
    private void Excluir()
    {
        try
        {
            if (PacienteSelecionado == null)
            {
                MessageBox.Show(
                    "Selecione um paciente para excluir.",
                    "Validação",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            var confirmacao = MessageBox.Show(
                $"Deseja realmente excluir o paciente {PacienteSelecionado.Nome}?",
                "Confirmar exclusão",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (confirmacao != MessageBoxResult.Yes)
                return;
            

            PacienteRepository.Excluir(PacienteSelecionado);

            LimparCampos();
            Carregar();

            MessageBox.Show(
                "Paciente excluído com sucesso.",
                "Sucesso",
                MessageBoxButton.OK,
                MessageBoxImage.Information
            );
        }
        catch (Exception ex)
        {
            var mensagem = ex.InnerException != null
                ? ex.InnerException.Message
                : ex.Message;

            MessageBox.Show(
                mensagem,
                "Erro ao excluir",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
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
