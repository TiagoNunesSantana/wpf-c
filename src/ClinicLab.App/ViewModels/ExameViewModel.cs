using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClinicLab.App.Models;
using ClinicLab.App.Repositories;

namespace ClinicLab.App.ViewModels;

public partial class ExameViewModel : ObservableObject
{
    [ObservableProperty]
    private string nome = string.Empty;

    [ObservableProperty]
    private string descricao = string.Empty;

    [ObservableProperty]
    private string valor = string.Empty;

    [ObservableProperty]
    private string prazoEntregaDias = string.Empty;

    [ObservableProperty]
    private bool ativo = true;

    [ObservableProperty]
    private string termoBusca = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Exame> exames = new();

    [ObservableProperty]
    private Exame? exameSelecionado;

    public ExameViewModel()
    {
        _ = Carregar();
    }

    partial void OnExameSelecionadoChanged(Exame? value)
    {
        if (value == null)
            return;

        Nome = value.Nome;
        Descricao = value.Descricao;
        Valor = value.Valor.ToString("N2", new CultureInfo("pt-BR"));
        PrazoEntregaDias = value.PrazoEntregaDias.ToString();
        Ativo = value.Ativo;
    }

    [RelayCommand]
    private async Task Salvar()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                MessageBox.Show(
                    "Informe o nome do exame.",
                    "Validação",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            if (!decimal.TryParse(Valor, NumberStyles.Number, new CultureInfo("pt-BR"), out decimal valorDecimal))
            {
                MessageBox.Show(
                    "Informe um valor válido.",
                    "Validação",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            if (!int.TryParse(PrazoEntregaDias, out int prazo))
            {
                MessageBox.Show(
                    "Informe o prazo de entrega em dias.",
                    "Validação",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            if (ExameSelecionado == null)
            {
                var exame = new Exame
                {
                    Nome = Nome,
                    Descricao = Descricao,
                    Valor = valorDecimal,
                    PrazoEntregaDias = prazo,
                    Ativo = Ativo
                };

                await ExameRepository.Salvar(exame);
            }
            else
            {
                ExameSelecionado.Nome = Nome;
                ExameSelecionado.Descricao = Descricao;
                ExameSelecionado.Valor = valorDecimal;
                ExameSelecionado.PrazoEntregaDias = prazo;
                ExameSelecionado.Ativo = Ativo;

                await ExameRepository.Atualizar(ExameSelecionado);
            }

            LimparCampos();
            await Carregar();

            MessageBox.Show(
                "Exame salvo com sucesso.",
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
                "Erro ao salvar",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }

    [RelayCommand]
    private async Task Excluir()
    {
        try
        {
            if (ExameSelecionado == null)
            {
                MessageBox.Show(
                    "Selecione um exame para excluir.",
                    "Validação",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );

                return;
            }

            var confirmacao = MessageBox.Show(
                $"Deseja realmente excluir o exame {ExameSelecionado.Nome}?",
                "Confirmar exclusão",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (confirmacao != MessageBoxResult.Yes)
                return;

            await ExameRepository.Excluir(ExameSelecionado);

            LimparCampos();
            await Carregar();

            MessageBox.Show(
                "Exame excluído com sucesso.",
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
    private async Task Buscar()
    {
        Exames = new ObservableCollection<Exame>(
            await ExameRepository.Buscar(TermoBusca)
        );
    }

    [RelayCommand]
    private async Task Limpar()
    {
        LimparCampos();
        TermoBusca = string.Empty;
        await Carregar();
    }

    private async Task Carregar()
    {
        Exames = new ObservableCollection<Exame>(
            await ExameRepository.Listar()
        );
    }

    private void LimparCampos()
    {
        ExameSelecionado = null;
        Nome = string.Empty;
        Descricao = string.Empty;
        Valor = string.Empty;
        PrazoEntregaDias = string.Empty;
        Ativo = true;
    }
}