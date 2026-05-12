using ClinicLab.App.Data;
using ClinicLab.App.Helpers;
using ClinicLab.App.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicLab.App.Repositories;

public class ExameRepository
{
    private static AppDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(AppConfig.ConnectionString)
            .Options;

        return new AppDbContext(options);
    }

    public static async Task<List<Exame>> Listar()
    {
        await using var context = CreateContext();

        return await context.Exames
            .OrderBy(e => e.Nome)
            .ToListAsync();
    }

    public static async Task<List<Exame>> Buscar(string termo)
    {
        await using var context = CreateContext();

        if (string.IsNullOrWhiteSpace(termo))
            return await Listar();

        termo = termo.ToLower();

        return await context.Exames
            .Where(e =>
                e.Nome.ToLower().Contains(termo) ||
                e.Descricao.ToLower().Contains(termo)
            )
            .OrderBy(e => e.Nome)
            .ToListAsync();
    }

    public static async Task Salvar(Exame exame)
    {
        await using var context = CreateContext();

        context.Exames.Add(exame);

        await context.SaveChangesAsync();
    }

    public static async Task Atualizar(Exame exame)
    {
        await using var context = CreateContext();

        context.Exames.Update(exame);

        await context.SaveChangesAsync();
    }

    public static async Task Excluir(Exame exame)
    {
        await using var context = CreateContext();

        context.Exames.Remove(exame);

        await context.SaveChangesAsync();
    }

    public static async Task<int> Contar()
    {
        using var context = CreateContext();

        return context.Exames.Count();
    }
}