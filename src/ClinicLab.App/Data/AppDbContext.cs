using ClinicLab.App.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicLab.App.Data;

public class AppDbContext : DbContext
{
    public DbSet<Paciente> Pacientes => Set<Paciente>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=cliniclab;Username=postgres;Password=postgres"
        );
    }
}