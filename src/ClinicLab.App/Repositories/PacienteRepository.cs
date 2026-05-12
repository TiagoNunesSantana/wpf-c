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

    public static async Task SalvarAsync(Paciente paciente)
    {
        await using var context = CreateContext();
        context.Pacientes.Add(paciente);
        await context.SaveChangesAsync();
    }
}
