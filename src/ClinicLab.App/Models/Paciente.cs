namespace ClinicLab.App.Models;

public class Paciente
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string CPF { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string Convenio { get; set; } = string.Empty;

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}