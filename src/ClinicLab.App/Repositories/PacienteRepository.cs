using ClinicLab.App.Data;
using ClinicLab.App.Helpers;
using ClinicLab.App.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicLab.App.Repositories;

public class PacienteRepository
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(AppConfig.ConnectionString)
            .Options;
        return new AppDbContext(options);
    }

    public static async Task<List<Paciente>> ListarAsync()
    {
        await using var context = CreateContext();
        return await context.Pacientes.ToListAsync();
    }

    public static async Task Salvar(Paciente paciente)
    {
        await using var context = CreateContext();
        context.Pacientes.Add(paciente);
        await context.SaveChangesAsync();
    }

    public static async Task Atualizar(Paciente paciente)
    {
        await using var context = CreateContext();
        context.Pacientes.Update(paciente);
        await context.SaveChangesAsync();
    }    

    public static async Task Excluir(Paciente paciente)
    {
        await using var context = CreateContext();
        context.Pacientes.Remove(paciente);
        await context.SaveChangesAsync();
    }   

    public static async Task<List<Paciente>> Listar()
    {
        await using var context = CreateContext();
        return await context.Pacientes
            .OrderBy(p => p.Nome)
            .ToListAsync();
    }     

    public static async Task<List<Paciente>> Buscar(string termo)
    {
        await using var context = CreateContext();
        if (string.IsNullOrWhiteSpace(termo))
            return await Listar();

        termo = termo.ToLower();

        return context.Pacientes
            .Where(p =>
                p.Nome.ToLower().Contains(termo) ||
                p.Cpf.ToLower().Contains(termo)
            )
            .OrderBy(p => p.Nome)
            .ToList();
    }    

    public int Contar()
    {   using var context = CreateContext();
        return context.Pacientes.Count();
    }

    public Paciente? ObterUltimoCadastro()
    {
        using var context = CreateContext();
        return context.Pacientes
            .OrderByDescending(p => p.DataCadastro)
            .FirstOrDefault();
    }    
}
